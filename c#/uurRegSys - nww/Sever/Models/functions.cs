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
        public static DateTime GetSqlServerDateTime() {
            SqlCommand command = new SqlCommand();
            DataTable result = new DataTable();
            command.CommandText="select datetime = SYSDATETIME()";
            result=sql.SQLQuery(sql.connectionString, command);
            try {
                return (DateTime)result.Rows[0]["datetime"];
            } catch {
                return default(DateTime);
            }
        }

        private static void logEventToDatabase(int forUserId, bool wasInteken, bool wasUitteken, bool wasAnuleerLaatsteUitteken) {
            SqlCommand command = new SqlCommand();
            command.CommandText=$"insert into {SQLNew.LogTableNames.LogTableName}({SQLNew.LogTableNames.IDOfUserRelated}, {SQLNew.LogTableNames.date}, {SQLNew.LogTableNames.time}, {SQLNew.LogTableNames.doetInteken}, {SQLNew.LogTableNames.doetUitteken}, {SQLNew.LogTableNames.anuleerdUitteken}) values ({forUserId}, cast(GETDATE() as date), cast(GETDATE() as time), {wasInteken}, {wasUitteken}, {wasAnuleerLaatsteUitteken})";
            SQLNew.SQLNonQuery(command);
        }

        public static TReturnDisplayInfoForJustReadNFCCard nfcScan(TNFCCardScan scanInfo) {
            TReturnDisplayInfoForJustReadNFCCard _toReturn = new TReturnDisplayInfoForJustReadNFCCard();
            SQLNew _sqlfunc = new SQLNew();
            int _userID = 0;

            //get user id
            List<SQLNew.UserTableTableEntry> resultForGetUserId = _sqlfunc.GetListUserTableEntriesFromDataTable(SQLNew.SQLQuery($"select {SQLNew.UserTableNames.ID} from {SQLNew.UserTableNames.userTableName} where {SQLNew.UserTableNames.NFCID} = {scanInfo.ID}"));
            if (resultForGetUserId.Count!=1) {
                _userID=resultForGetUserId[0].ID;
            } else {
                string idsWithSameNfcCode = "";
                foreach (SQLNew.UserTableTableEntry x in resultForGetUserId) {
                    idsWithSameNfcCode+=$" {x.ID}";
                }
                throw new Exception($"Found {resultForGetUserId.Count} User(s) ({idsWithSameNfcCode}) With Code {scanInfo.ID}");
            }

            //update or create entry from registratie table and log action
            List<SQLNew.RegistratieTableTableEntry> result = _sqlfunc.GetListRegistratieTableEntrysFromDataTable(SQLNew.SQLQuery($"select {SQLNew.RegistratieTableNames.ID},{SQLNew.RegistratieTableNames.TimeInteken},{SQLNew.RegistratieTableNames.IsAanwezig} from {SQLNew.RegistratieTableNames.registratieTableName} where {SQLNew.RegistratieTableNames.Date} = CAST(getdate() as date) and {SQLNew.RegistratieTableNames.IDOfUserRelated} = {_userID}"));
            if (result.Count==0) {

                // new entry met cur time als inteken tijd en log actie      
                string erCommand = $"insert into {SQLNew.RegistratieTableNames.registratieTableName}({SQLNew.RegistratieTableNames.IDOfUserRelated}, {SQLNew.RegistratieTableNames.Date}, {SQLNew.RegistratieTableNames.TimeInteken}, {SQLNew.RegistratieTableNames.IsAanwezig}) values ({_userID}, cast(GETDATE() as date), cast)GETDATE() as time), 1)";
                if (SQLNew.SQLNonQuery(erCommand)!=1) {
                    throw new Exception($"SQL Error: Got Result 0 From {erCommand}");
                } else { logEventToDatabase(_userID, true, false, false); }

            } else if (result.Count==1) {

                //update entry fill uitchek zet aanwezighijd 0 en log actiie 
                //of zet aanwezig weer op 1 en log uitchek anuleer en keep uitcheck tijd want warom niet
                if (result[0].IsAanwezig) {
                    //doe uitchek
                } else {
                    //doe anuleer uitcheck
                }

            }

            return _toReturn;
        }

    }
}