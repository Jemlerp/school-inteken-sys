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
    public static class functions {
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

        //admin

        public static TAdminReturnADataTable adminGetADataTable(TAdminSendAskADataTable request) {
            TAdminReturnADataTable returnDingus = new TAdminReturnADataTable();
            if (request.userTable) {
                returnDingus.DataTable=SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.UserTableNames.userTableName}");
            } else {
                string command = "";
                string IDColumnName = "";
                if (request.afwezighijdTable) { command=$"select * from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.Date}"; IDColumnName=SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated; }
                if (request.aanwezighijdTable) { command=$"select * from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.Date}"; IDColumnName=SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated; }

                if (request.aanwezighijdTable||request.afwezighijdTable) {
                    if (request.useBetweenDates) {
                        command+=$" between cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date) and cast('{request.dataTotEnMet.ToString("yyyy-MM-dd HH:mm:ss")}' as date)";
                    } else {
                        command+=$" = cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date)";
                    }

                    if (request.getForSpecificUsers) {
                        command+=$" and {IDColumnName} in ({string.Join(",", request.listOfUsersToGetFrom.ToArray())})";
                    }
                } else {
                    throw new Exception("adminGetDateTable: no table selected");
                }

                //if (request.afwezighijdTable) {
                //    if (request.useBetweenDates) {
                //        returnDingus.DataTable=SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date)");
                //    } else {
                //        returnDingus.DataTable=SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.Date} between cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date) and cast('{request.dataTotEnMet.ToString("yyyy-MM-dd HH:mm:ss")}' as date)");
                //    }
                //}
                //if (request.aanwezighijdTable) {
                //    if (request.useBetweenDates) {
                //        returnDingus.DataTable=SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.Date} = cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date)");
                //    } else {
                //        returnDingus.DataTable=SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.Date} between cast('{request.dateOf.ToString("yyyy-MM-dd HH:mm:ss")}' as date) and cast('{request.dataTotEnMet.ToString("yyyy-MM-dd HH:mm:ss")}' as date)");
                //    }
                //}

                returnDingus.DataTable=SQlOnlquery.SQLQuery(command);
            }
            return returnDingus;
        }

        public static TAdminReturnChangedATable adminChangeUsersTable(TAdminSendChangeUsersTable request) {
            TAdminReturnChangedATable toReturn = new TAdminReturnChangedATable();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@vNaam", request.voornaam);
            command.Parameters.AddWithValue("@aNaam", request.achternaam);
            command.Parameters.AddWithValue("@NFCC", request.NFCID);
            if (request.isNewUser) {
                command.CommandText=$"insert into {SQLPropertysAndFunc.UserTableNames.userTableName} ({SQLPropertysAndFunc.UserTableNames.voorNaam},{SQLPropertysAndFunc.UserTableNames.achterNaam},{SQLPropertysAndFunc.UserTableNames.NFCID}) values (@vNaam, @aNaam, @nfcc)";
            } else {
                command.CommandText=$"update {SQLPropertysAndFunc.UserTableNames.userTableName} set {SQLPropertysAndFunc.UserTableNames.voorNaam} = @vNaam, {SQLPropertysAndFunc.UserTableNames.achterNaam} = @aNaam, {SQLPropertysAndFunc.UserTableNames.NFCID} = @nfcc, {SQLPropertysAndFunc.UserTableNames.isVanSchoolAf} = cast('{request.isVanSchoolAf}' as bit) where {SQLPropertysAndFunc.UserTableNames.ID} = {request.toEditUserId}";
            }
            if (SQlOnlquery.SQLNonQuery(command)>0) {
                toReturn.gelukt=true;
            } else {
                throw new Exception($"query did not change anything || query : {command.CommandText}");
            }
            return toReturn;
        }

        public static TAdminReturnChangedATable adminChangeRegistratieTable(TAdminSendChangeRegistratieTable request) {
            TAdminReturnChangedATable toReturn = new TAdminReturnChangedATable();
            SqlCommand command = new SqlCommand();
            if (request.DELETE) {
                command.CommandText=$"delete from {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} where {SQLPropertysAndFunc.RegistratieTableNames.ID} = {request.IDToChange}";
            } else {
                if (request.IsNewEntry) {
                    if (request.HeeftGeenUiteken) {
                        command.CommandText=$"insert into {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} ({SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.RegistratieTableNames.Date}, {SQLPropertysAndFunc.RegistratieTableNames.TimeInteken},{SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig}) values ({request.IDUserRelated}, cast('{request.Date.ToString("yyyy-MM-dd")}' as date), cast('{request.TimeIn}' as time), cast('{request.IsAanwezig}' as bit))";
                    } else {
                        command.CommandText=$"insert into {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} ({SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.RegistratieTableNames.Date}, {SQLPropertysAndFunc.RegistratieTableNames.TimeInteken}, {SQLPropertysAndFunc.RegistratieTableNames.TimeUitteken},{SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig}) values ({request.IDUserRelated}, cast('{request.Date.ToString("yyyy-MM-dd")}' as date), cast('{request.TimeIn}' as time), cast('{request.TimeUit}' as time), cast('{request.IsAanwezig}' as bit))";
                    }
                } else {
                    if (request.HeeftGeenUiteken) {
                        command.CommandText=$"update {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} set {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {request.IDUserRelated}, {SQLPropertysAndFunc.RegistratieTableNames.Date} = cast('{request.Date.ToString("yyyy-MM-dd")}' as date), {SQLPropertysAndFunc.RegistratieTableNames.TimeInteken} = cast('{request.TimeIn}' as time), {SQLPropertysAndFunc.RegistratieTableNames.TimeUitteken} = null, {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig} = cast('{request.IsAanwezig}' as bit) where {SQLPropertysAndFunc.RegistratieTableNames.ID} = {request.IDToChange}";
                    } else {
                        command.CommandText=$"update {SQLPropertysAndFunc.RegistratieTableNames.registratieTableName} set {SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated} = {request.IDUserRelated}, {SQLPropertysAndFunc.RegistratieTableNames.Date} = cast('{request.Date.ToString("yyyy-MM-dd")}' as date), {SQLPropertysAndFunc.RegistratieTableNames.TimeInteken} = cast('{request.TimeIn}' as time), {SQLPropertysAndFunc.RegistratieTableNames.TimeUitteken} = cast('{request.TimeUit}' as time), {SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig} = cast('{request.IsAanwezig}' as bit) where {SQLPropertysAndFunc.RegistratieTableNames.ID} = {request.IDToChange}";
                    }
                }
            }
            int rowsChanged = SQlOnlquery.SQLNonQuery(command);
            if (rowsChanged==1) {
                toReturn.gelukt=true;
            }
            return toReturn;
        }

        public static TAdminReturnChangedATable adminChageAfwezigTable(TAdminSendChangeAfwezigTable request) {
            TAdminReturnChangedATable toReturn = new TAdminReturnChangedATable();
            SqlCommand command = new SqlCommand();
            if (request.DELETE) {
                command.CommandText=$"delete from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.ID} = {request.IDToChage}";
            } else {
                if (request.IsNewEntry) {
                    command.CommandText=$"insert into {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName}  ({SQLPropertysAndFunc.AfwezigTableNames.Date}, {SQLPropertysAndFunc.AfwezigTableNames.IsZiek}, {SQLPropertysAndFunc.AfwezigTableNames.IsFlexibelverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsStudieverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsExcursie}, {SQLPropertysAndFunc.AfwezigTableNames.IsLaat}, {SQLPropertysAndFunc.AfwezigTableNames.IsAndereReden}, {SQLPropertysAndFunc.AfwezigTableNames.Verwachtetijdvanaanwezighijd}, {SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd}) values (cast('{request.Date}' as date), cast('{request.IsZiek}' as bit), cast('{request.IsFleciebleverlof}' as bit), cast('{request.IsStudioverlof}' as bit), cast('{request.IsExurie}' as bit), cast('{request.IsLaat}' as bit), cast('{request.ISAndereReden}' as bit), '{request.VerwachteTijdVanAanwezighijd}', {request.AndrenRedenVanAfwezighijd}) where {SQLPropertysAndFunc.AfwezigTableNames.ID} = {request.IDToChage}";
                } else {
                    command.CommandText=$"update {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} set {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast('{request.Date}' as date), {SQLPropertysAndFunc.AfwezigTableNames.IsZiek} = cast('{request.IsZiek}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.IsFlexibelverlof} = cast('{request.IsFleciebleverlof}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.IsStudieverlof} = cast('{request.IsStudioverlof}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.IsExcursie} = cast('{request.IsExurie}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.IsLaat} = cast('{request.IsLaat}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.IsAndereReden} = cast('{request.ISAndereReden}' as bit), {SQLPropertysAndFunc.AfwezigTableNames.Verwachtetijdvanaanwezighijd} = {request.VerwachteTijdVanAanwezighijd}, {SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd} = {request.AndrenRedenVanAfwezighijd} where {SQLPropertysAndFunc.AfwezigTableNames.ID} = {request.IDToChage}";
                }
            }
            int rowsChanged = SQlOnlquery.SQLNonQuery(command);
            if (rowsChanged==1) {
                toReturn.gelukt=true;
            }
            return toReturn;
        }

        //other

        private static void logEventToDatabase(int forUserId, bool wasInteken, bool wasUitteken, bool wasAnuleerLaatsteUitteken) {
            SqlCommand command = new SqlCommand();
            command.CommandText=$"insert into {SQLPropertysAndFunc.LogTableNames.LogTableName}({SQLPropertysAndFunc.LogTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.LogTableNames.date}, {SQLPropertysAndFunc.LogTableNames.time}, {SQLPropertysAndFunc.LogTableNames.doetInteken}, {SQLPropertysAndFunc.LogTableNames.doetUitteken}, {SQLPropertysAndFunc.LogTableNames.anuleerdUitteken}) values ({forUserId}, cast(GETDATE() as date), cast(GETDATE() as time), cast('{wasInteken}' as bit), cast('{wasUitteken}' as bit), cast('{wasAnuleerLaatsteUitteken}' as bit))";
            SQlOnlquery.SQLNonQuery(command);
        }

        public static TReturnChangeAfwezighijdTable changeAfwezighijdVoorEenIemand(TRequestChangeAfwezigTable request) {
            TReturnChangeAfwezighijdTable toReturn = new TReturnChangeAfwezighijdTable();
            SqlCommand command = new SqlCommand();
            command.CommandText=$"delete from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated} = {request.fromUserID} and {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast(getdate() as date)";
            try {
                SQlOnlquery.SQLNonQuery(command);
            } catch (Exception ex) { throw new Exception(ex.Message); }

            if (!request.clearRecordOfAfwezigVandaag) {
                command=new SqlCommand();
                command.Parameters.AddWithValue("@texty", request.AnderenRedenVoorAfwezigihijd);
                command.Parameters.AddWithValue("@tijdjetexty", request.VerwachteTijdVanAanwezighijd);
                command.CommandText=$"insert into {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} ({SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated}, {SQLPropertysAndFunc.AfwezigTableNames.Date}, {SQLPropertysAndFunc.AfwezigTableNames.IsExcursie}, {SQLPropertysAndFunc.AfwezigTableNames.IsFlexibelverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsStudieverlof}, {SQLPropertysAndFunc.AfwezigTableNames.IsZiek},{SQLPropertysAndFunc.AfwezigTableNames.IsLaat}, {SQLPropertysAndFunc.AfwezigTableNames.IsAndereReden}, {SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd}, {SQLPropertysAndFunc.AfwezigTableNames.Verwachtetijdvanaanwezighijd}) values ('{request.fromUserID}' , cast(getdate() as date), cast('{request.IsExcurtie}' as bit), cast('{request.IsFlexiebelverlof}'as  bit), cast('{request.IsStudieverlof}' as bit), cast('{request.IsZiek}' as bit),cast('{request.IsLaat}' as bit), cast('{request.IsAnderereden}' as bit), @texty, @tijdjetexty)";
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
            //delete afwezigtable entry als je als laat staat
            SQlOnlquery.SQLNonQuery($"delete from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated} = {_userID} and {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast(getdate() as date) and {SQLPropertysAndFunc.AfwezigTableNames.IsLaat} = 1");


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
            _toReturn.users=_Sqlfunc.GetListUserTableEntriesFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.UserTableNames.userTableName} where {SQLPropertysAndFunc.UserTableNames.isVanSchoolAf} = cast('false' as bit)"));
            _toReturn.todayAfwezig=_Sqlfunc.GetListAfwezighijdTableEntriesFromDataTable(SQlOnlquery.SQLQuery($"select * from {SQLPropertysAndFunc.AfwezigTableNames.AfwezighijdTableName} where {SQLPropertysAndFunc.AfwezigTableNames.Date} = cast(GETDATE() as date)"));
            _toReturn.dateTimeNow=GetSqlServerDateTime();
            return _toReturn;
        }

    }
}