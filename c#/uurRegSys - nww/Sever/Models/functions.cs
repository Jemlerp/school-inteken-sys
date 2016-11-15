using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using funcZ;

namespace Sever.Models {
    public class functions {
        private static SQLPropertysAndFunc _Sqlfunc = new SQLPropertysAndFunc();

        public static DateTime GetSqlServerDateTime() {
            return (DateTime)SQlOnlquery.SQLQuery("select datetime = SYSDATETIME()").Rows[0]["datetime"];
        }

        public static bool TestSqlConnetion() {
            try {
                DateTime test = GetSqlServerDateTime();
                return true;
            } catch {
                return false;
            }
        }

        private static void logEventToDatabase(int forUserId, bool wasInteken, bool wasUitteken, bool wasAnuleerLaatsteUitteken) {
            SqlCommand command = new SqlCommand();
            command.CommandText=$"insert into {SQLPropertysAndFunc.LogTableNames.LogTableName}({SQLPropertysAndFunc.LogTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.LogTableNames.date}, {SQLPropertysAndFunc.LogTableNames.time}, {SQLPropertysAndFunc.LogTableNames.doetInteken}, {SQLPropertysAndFunc.LogTableNames.doetUitteken}, {SQLPropertysAndFunc.LogTableNames.anuleerdUitteken}) values ({forUserId}, cast(GETDATE() as date), cast(GETDATE() as time), cast('{wasInteken}' as bit), cast('{wasUitteken}' as bit), cast('{wasAnuleerLaatsteUitteken}' as bit))";
            SQlOnlquery.SQLNonQuery(command);
        }

        public static TRespondChangeAfwezighijdTable changeAfwezighijdVoorEenIemand(TRequestChangeAfwezigTable request) {
            TRespondChangeAfwezighijdTable toReturn = new TRespondChangeAfwezighijdTable();

            SqlCommand command = new SqlCommand();
            command.CommandText=$"delete from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated} = {request.fromUserID} and {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast(getdate() as date)";
            try {
                SQlOnlquery.SQLNonQuery(command);
            } catch (Exception ex) { throw new Exception(ex.Message); }

            if (!request.clearRecordOfAfwezigVandaag) {
                command=new SqlCommand();
                command.Parameters.AddWithValue("@texty", request.AnderenRedenVoorAfwezigihijd);
                command.CommandText=$"insert into {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} ({SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.AfwezigTableNames.Date}, {SQLPropertysAndFunc.AfwezigTableNames.IsExcursie}, {SQLPropertysAndFunc.AfwezigTableNames.IsFlexibelverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsStudieverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsZiek}, {SQLPropertysAndFunc.AfwezigTableNames.IsAndereReden}, {SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd}) values ('{request.fromUserID}' , cast(getdate() as date), cast('{request.IsExcurtie}' as bit), cast('{request.IsFlexiebelverlof}'as  bit), cast('{request.IsStudieverlof}' as bit), cast('{request.IsZiek}' as bit),cast('{request.IsAnderereden}' as bit), @texty)";
                if (SQlOnlquery.SQLNonQuery(command)!=1) {
                    throw new Exception("Could Not Insert New Afwezig Entry To Database");
                }
            }
            toReturn.success=true;
            return toReturn;
        }

        public static TReturnDisplayInfoForJustReadNFCCard NFCScan(TNFCCardScan scanInfo) {
            int _userID = 0;
            //get user id
            List<SQLPropertysAndFunc.UserTableTableEntry> resultForGetUserId = _Sqlfunc.GetListUserTableEntriesFromDataTable(SQlOnlquery.SQLQuery($"select {SQLPropertysAndFunc.UserTableNames.ID},{SQLPropertysAndFunc.UserTableNames.voorNaam},{SQLPropertysAndFunc.UserTableNames.achterNaam} from {SQLPropertysAndFunc.UserTableNames.userTableName} where {SQLPropertysAndFunc.UserTableNames.NFCID} = '{scanInfo.ID}'"));
            if (resultForGetUserId.Count==1) {
                _userID=resultForGetUserId[0].ID;
            } else {
                string idsWithSameNfcCode = "";
                foreach (SQLPropertysAndFunc.UserTableTableEntry x in resultForGetUserId) {
                    idsWithSameNfcCode+=$" {x.ID}";
                }
                throw new Exception($"Found {resultForGetUserId.Count} User(s) ({idsWithSameNfcCode}) With Code {scanInfo.ID}");
            }
            //update or create entry from registratie table and log action
            List<SQLPropertysAndFunc.RegistratieTableTableEntry> result = _Sqlfunc.GetListRegistratieTableEntrysFromDataTable(SQlOnlquery.SQLQuery($"select {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig} from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.Date} = CAST(getdate() as date) and {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {_userID}"));
            bool doetUitteken = false;
            bool doetInteken = false;
            bool doetAnuleerdUiteken = false;
            string erCommand = "";
            if (result.Count==0) {
                // new entry
                erCommand=$"insert into {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName}({SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.RegistratieTableNames.Date}, {SQLPropertysAndFunc.RegistratieTableNames.TimeInteken}, {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig}) values ({_userID}, cast(GETDATE() as date), cast(GETDATE() as time), 1)";
                doetInteken=true;
            } else if (result.Count==1) {
                if (result[0].IsAanwezig) {
                    //uitchek
                    erCommand=$"update {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} set {SQLPropertysAndFunc.RegistratieTableNames.TimeUitteken} = CAST(getdate() as time), {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig} = 0 where {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {_userID} and {SQLPropertysAndFunc.RegistratieTableNames.Date} = CAST(getdate() as date)";
                    doetUitteken=true;
                } else {
                    //anuleer uitcheck
                    erCommand=$"update {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} set {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig} = 1 where {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {_userID} and {SQLPropertysAndFunc.RegistratieTableNames.Date} = CAST(getdate() as date)";
                    doetAnuleerdUiteken=true;
                }
            }
            if (SQlOnlquery.SQLNonQuery(erCommand)!=1) {
                throw new Exception($"SQL Error: Got Result 0 From {erCommand}");
            } else { logEventToDatabase(_userID, doetInteken, doetUitteken, doetAnuleerdUiteken); }
            //fill retunr info            
            List<SQLPropertysAndFunc.RegistratieTableTableEntry> elntetry = _Sqlfunc.GetListRegistratieTableEntrysFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {_userID} and {SQLPropertysAndFunc.RegistratieTableNames.Date} = CAST(getdate() as date)"));
            TReturnDisplayInfoForJustReadNFCCard _toReturn = new TReturnDisplayInfoForJustReadNFCCard();
            _toReturn.voornaam=resultForGetUserId[0].voorNaam;
            _toReturn.achternaam=resultForGetUserId[0].achterNaam;
            _toReturn.ID=resultForGetUserId[0].ID;
            _toReturn.NFCID=scanInfo.ID;
            _toReturn.doetInteken=doetInteken;
            _toReturn.doetUitteken=doetUitteken;
            _toReturn.doetAnuleerUitteken=doetAnuleerdUiteken;
            _toReturn.tijdInteken=elntetry[0].TimeInteken;
            _toReturn.tijdUiteken=elntetry[0].TimeUitteken;
            _toReturn.dateOfToday=elntetry[0].Date;
            _toReturn.DateTimeNow=GetSqlServerDateTime();
            return _toReturn;
        }

        public static TReturnOverviewOfAanwezige overzigt() {
            TReturnOverviewOfAanwezige _toReturn = new TReturnOverviewOfAanwezige();
            _toReturn.todayRegData=_Sqlfunc.GetListRegistratieTableEntrysFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.Date} = CAST(getdate() as date)"));
            _toReturn.users=_Sqlfunc.GetListUserTableEntriesFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.UserTableNames.userTableName}"));
            _toReturn.todayAfwezig=_Sqlfunc.GetListAfwezighijdTableEntriesFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast(GETDATE() as date)"));
            _toReturn.dateTimeNow=GetSqlServerDateTime();
            return _toReturn;
        }

    }
}