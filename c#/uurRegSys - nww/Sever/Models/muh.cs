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
    public static class muh {

        private static string returnErrorWithMessage(string message) {
            funcZ.TReturnError err = new TReturnError();
            err.waarom = message;
            return JsonConvert.SerializeObject(err);
        }

        public static DateTime getSqlServerDateTime() {
            SqlCommand command = new SqlCommand();
            DataTable result = new DataTable();
            command.CommandText = "select datetime = SYSDATETIME()";
            result = sql.SQLQuery(sql.connectionString, command);
            try {
                return (DateTime)result.Rows[0]["datetime"];
            } catch {
                return default(DateTime);
            }
        }
        // Haalt alle uren van idereen op en maakt er een overzicht van.
        public static string GetUurOverZichtForAllStudents(object _inObject) {
            string wertkWel = JsonConvert.SerializeObject(_inObject);
            TAskUurOverzight instruc = JsonConvert.DeserializeObject<TAskUurOverzight>(wertkWel);
            SqlCommand command = new SqlCommand();
            TReturnUurOverzight toReturn = new TReturnUurOverzight();
            toReturn.dagenFelxiebleVerlof = new List<DateTime>();
            toReturn.dagenMinderDan4UurGemaakt = new List<DateTime>();
            toReturn.dagenNietInOfUitGetekend = new List<DateTime>();
            toReturn.dagenNietOpkomenDagen = new List<DateTime>();
            toReturn.dagenWaarUserZiekWas = new List<DateTime>();

            //uitzonderiongtable
            command.CommandText = $"select {sql.uitzondering_dateOfAffectCollumName}, {sql.uitzondering_isZiekCollumName}, {sql.uitzondering_isFlexiebelverlofCollumName}, {sql.uitzondering_uurenCorrectionToApplyCollumName}, {sql.uitzondering_minutenCorrectionToApplyCollumName} from {sql.uitzonderingTableName} where {sql.uitzondering_userToApplyToCollumName} = {instruc.UserIdVanWieTeMaaken} and {sql.uitzondering_dateOfAffectCollumName} between cast('{instruc.dezedag.Date.ToString("MM / dd / yyyy")} 00:00:00' as datetime) and cast('{instruc.totenmetdeze.Date.ToString("MM / dd / yyyy")} 23:59:59' as datetime) order by {sql.uitzondering_dateOfAffectCollumName} desc";
            DataTable result = sql.SQLQuery(sql.connectionString, command);
            for (int rooow = 0; rooow < result.Rows.Count; rooow++) {
                //ziek of flex
                if ((bool)result.Rows[rooow][sql.uitzondering_isZiekCollumName]) {
                    toReturn.dagenWaarUserZiekWas.Add((DateTime)result.Rows[rooow][sql.uitzondering_dateOfAffectCollumName]);
                    toReturn.efectiefTotaalaantalUuren += (int)result.Rows[rooow][sql.uitzondering_uurenCorrectionToApplyCollumName];
                    toReturn.efectiefTotaalaantalminuten += (int)result.Rows[rooow][sql.uitzondering_minutenCorrectionToApplyCollumName];
                } else {
                    if ((bool)result.Rows[rooow][sql.uitzondering_isFlexiebelverlofCollumName]) {
                        toReturn.dagenFelxiebleVerlof.Add((DateTime)result.Rows[rooow][sql.uitzondering_dateOfAffectCollumName]);
                        toReturn.efectiefTotaalaantalUuren += (int)result.Rows[rooow][sql.uitzondering_uurenCorrectionToApplyCollumName];
                        toReturn.efectiefTotaalaantalminuten += (int)result.Rows[rooow][sql.uitzondering_minutenCorrectionToApplyCollumName];
                    } else { // andere reden voor corectie
                        toReturn.uurenGekrijgenVanOverigeRedenen += (int)result.Rows[rooow][sql.uitzondering_uurenCorrectionToApplyCollumName];
                        toReturn.minutenGekrijgenVanOverigeRedenen += (int)result.Rows[rooow][sql.uitzondering_minutenCorrectionToApplyCollumName];
                    }
                }
            }

            //regtable
            int dagenAanwezigGeweest = 0;
            command = new SqlCommand();
            command.CommandText = $"select {sql.reg_dateTimeCollumName} from {sql.regTableName} where {sql.reg_dateTimeCollumName} between cast('{instruc.dezedag.Date.ToString("MM / dd / yyyy")} 00:00:00' as datetime) and cast('{instruc.totenmetdeze.Date.ToString("MM / dd / yyyy")} 23:59:59' as datetime) and {sql.reg_relatedUserIdCollumName} = {instruc.UserIdVanWieTeMaaken} order by {sql.reg_dateTimeCollumName} desc";
            DataTable timeEntries = sql.SQLQuery(sql.connectionString, command);
            int entriesToPross = timeEntries.Rows.Count;
            int entriesdooncount = 0;
            while (entriesdooncount < entriesToPross) {
                //pak datetime van een kijk of de volgende de zelfden datetime heeft
                dagenAanwezigGeweest += 1;
                DateTime een = (DateTime)timeEntries.Rows[entriesdooncount][sql.reg_dateTimeCollumName];
                if (!(entriesdooncount + 1 >= entriesToPross)) {
                    DateTime twee = (DateTime)timeEntries.Rows[entriesdooncount + 1][sql.reg_dateTimeCollumName];
                    if (een.Date == twee.Date) { // \\keer niet uitgetekend?
                        TimeSpan tijdDiedagOpSchool = een.Subtract(twee);
                        if (tijdDiedagOpSchool.Hours < 4) {
                            //minder dan 4 uur gemaakt
                            toReturn.dagenMinderDan4UurGemaakt.Add((DateTime)timeEntries.Rows[entriesdooncount][sql.reg_dateTimeCollumName]);
                        }
                        toReturn.efectiefTotaalaantalUuren += tijdDiedagOpSchool.Hours;
                        toReturn.efectiefTotaalaantalminuten += tijdDiedagOpSchool.Minutes;
                        toReturn.efectiefTotaalaantalseconden += tijdDiedagOpSchool.Seconds;
                        entriesdooncount += 2;
                    } else {
                        //niet in/uitgetekend
                        toReturn.dagenNietInOfUitGetekend.Add((DateTime)timeEntries.Rows[entriesdooncount][sql.aanwezig_datetimeCollumName]);
                        entriesdooncount++;
                        // ======+++++++++++++++++++++++======================================== plus 4 uur op total? ======+++++++++++++++++++++++========================================
                    }
                } else {
                    //niet in/uitgetekend
                    toReturn.dagenNietInOfUitGetekend.Add((DateTime)timeEntries.Rows[entriesdooncount][sql.aanwezig_datetimeCollumName]);
                    entriesdooncount += 1;
                    // ===============hier ook=============================================================================================================================================
                }

            }
            //zoek naar ongeoorloofd verzuim
            //dont feel like it
            return JsonConvert.SerializeObject(toReturn);
        }


        public static string nuInfoEzOverzigt(object _inObject) {
            DateTime _serverDateTime = getSqlServerDateTime();
            SqlCommand command = new SqlCommand();
            DataTable result = new DataTable();
            TReturnCurrentStateForDisplay retuuuuuuuuurn = new TReturnCurrentStateForDisplay();
            retuuuuuuuuurn.iedereen = new List<TsubPersonInfo>();
            //pak alle users
            command.CommandText = $"select * from {sql.userTableName}";
            result = sql.SQLQuery(sql.connectionString, command);
            foreach (DataRow row in result.Rows) {
                TsubPersonInfo nya = new TsubPersonInfo();
                nya.userId = (int)row[sql.user_idCollumName];
                nya.naam = (string)row[sql.user_voorNaamCollumName];
                nya.achternaam = (string)row[sql.user_achterNaamCollumName];
                retuuuuuuuuurn.iedereen.Add(nya);
            }
            //pak alle tijden
            command = new SqlCommand();
            command.CommandText = $"select {sql.reg_dateTimeCollumName}, {sql.reg_relatedUserIdCollumName} from {sql.regTableName} where {sql.reg_dateTimeCollumName} between CAST('{_serverDateTime.Date.ToString("MM / dd / yyyy")} 00:00:00' AS DATETIME) and CAST('{ _serverDateTime.Date.ToString("MM / dd / yyyy")} 23:59:59' AS DATETIME)";
            result = sql.SQLQuery(sql.connectionString, command);
            foreach (DataRow row in result.Rows) {
                int ttttid = (int)row[sql.reg_relatedUserIdCollumName];
                for (int x = 0; x < retuuuuuuuuurn.iedereen.Count; x++) {
                    if (retuuuuuuuuurn.iedereen[x].userId == ttttid) {
                        if (retuuuuuuuuurn.iedereen[x].erisinteken) {
                            retuuuuuuuuurn.iedereen[x].uittenken = (DateTime)row[sql.reg_dateTimeCollumName];
                            retuuuuuuuuurn.iedereen[x].erisuitteken = true;
                        } else {
                            retuuuuuuuuurn.iedereen[x].inteken = (DateTime)row[sql.reg_dateTimeCollumName];
                            retuuuuuuuuurn.iedereen[x].erisinteken = true;
                        }
                    }
                }
            }
            //aanwegiz schitt 
            command = new SqlCommand();
            command.CommandText = $"select {sql.aanwezig_relatedUserIDCollumName}, {sql.aanwezig_isAanwezigCollumName} from {sql.aanwezigTableName} where {sql.aanwezig_datetimeCollumName} between CAST('{_serverDateTime.Date.ToString("MM / dd / yyyy")} 00:00:00' AS DATETIME) and CAST('{ _serverDateTime.Date.ToString("MM / dd / yyyy")} 23:59:59' AS DATETIME)";
            result = sql.SQLQuery(sql.connectionString, command);
            foreach (DataRow row in result.Rows) {
                for (int x = 0; x < retuuuuuuuuurn.iedereen.Count; x++) {
                    if (retuuuuuuuuurn.iedereen[x].userId == (int)row[sql.aanwezig_relatedUserIDCollumName]) {
                        retuuuuuuuuurn.iedereen[x].isAanwegiz = (bool)row[sql.aanwezig_isAanwezigCollumName];
                    }
                }
            }
            //CALCULATE TIME als ik wil
            for (int x = 0; x < retuuuuuuuuurn.iedereen.Count; x++) {
                if(retuuuuuuuuurn.iedereen[x].erisinteken) { 
                    TimeSpan beestjetimespan = new TimeSpan();
                    if (retuuuuuuuuurn.iedereen[x].erisuitteken) {
                        beestjetimespan = retuuuuuuuuurn.iedereen[x].uittenken.Subtract(retuuuuuuuuurn.iedereen[x].inteken);
                    } else {                        
                        beestjetimespan = getSqlServerDateTime().Subtract(retuuuuuuuuurn.iedereen[x].inteken);
                    }
                    retuuuuuuuuurn.iedereen[x].uutotopschoolgeweest = beestjetimespan.Hours;
                    retuuuuuuuuurn.iedereen[x].minutetotaalopschoolgeweest = beestjetimespan.Minutes;
                    retuuuuuuuuurn.iedereen[x].secondetotaalopschoolgeweest = beestjetimespan.Seconds;
                }
            }
            return JsonConvert.SerializeObject(retuuuuuuuuurn);
        }

        private static string returnInfoForDisplay(int _userID, string errorText) {
            DateTime _serverDateTime = getSqlServerDateTime();
            TReturnInfoForDisplay RtDisplayInfo = new TReturnInfoForDisplay();
            if (errorText == "") {
                RtDisplayInfo.testText = "Klaar Met: " + _userID;
                SqlCommand command = new SqlCommand();
                DataTable result = new DataTable();

                // get from aanwezig table
                command.Parameters.AddWithValue("@eruser", _userID);
                command.CommandText = "select " + sql.aanwezig_isAanwezigCollumName + " from " + sql.aanwezigTableName + " where " + sql.aanwezig_relatedUserIDCollumName + " = @eruser and " + sql.aanwezig_datetimeCollumName + " between CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 00:00:00' AS DATETIME) and CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 23:59:59' AS DATETIME)";
                result = sql.SQLQuery(sql.connectionString, command);
                if (result == null) { return returnInfoForDisplay(8008, "sql error at returnInfoForDisplay"); }
                if (result.Rows.Count > 0) {
                    RtDisplayInfo.isAanwezig = (bool)result.Rows[0][sql.aanwezig_isAanwezigCollumName];
                } else {
                    return returnInfoForDisplay(8008, "sql error at returnInfoForDisplay");
                }

                // get from user table
                command = new SqlCommand();
                result = new DataTable();
                command.CommandText = "select * from " + sql.userTableName + " where " + sql.user_idCollumName + " = " + _userID;
                result = sql.SQLQuery(sql.connectionString, command);
                if (result == null) { return returnInfoForDisplay(8008, "sql error at returnInfoForDisplay"); }
                if (result.Rows.Count > 0) {
                    RtDisplayInfo.voorNaam = (string)result.Rows[0][sql.user_voorNaamCollumName];
                    RtDisplayInfo.achterNaam = (string)result.Rows[0][sql.user_achterNaamCollumName];
                    RtDisplayInfo.ID = _userID;
                    RtDisplayInfo.nfCode = (string)result.Rows[0][sql.user_nfcCodeCollumName];
                } else {
                    return returnInfoForDisplay(8008, "sql error at returnInfoForDisplay");
                }

            } else {
                RtDisplayInfo.error = true;
                RtDisplayInfo.errorText = errorText;
            }
            return JsonConvert.SerializeObject(RtDisplayInfo);
        }

        /// <summary>
        /// saves datetime with userid and nfc uid to database en zorgt ervoor dat aleen de eerste en laatste entrys in de database blijven
        /// </summary>
        /// <param name="_inObject"></param>
        /// <returns></returns>
        public static string nfc_scan(object _inObject) {
            string wertkWel = JsonConvert.SerializeObject(_inObject);
            TSendNewIDRead _READ = JsonConvert.DeserializeObject<TSendNewIDRead>(wertkWel);
            DateTime _serverDateTime = getSqlServerDateTime();
            SqlCommand command = new SqlCommand();
            DataTable result = new DataTable();
            int idOfPersonRelated;
            object[] arg;

            // ---usertable
            // get person related to nfcCard ID
            command.Parameters.AddWithValue("@nfcCode", _READ.ID);
            command.CommandText = string.Format("select {0} from {1} where {2} = @nfcCode", sql.user_idCollumName, sql.userTableName, sql.user_nfcCodeCollumName);
            result = sql.SQLQuery(sql.connectionString, command);
            if (result.Rows.Count == 0) { return returnErrorWithMessage("unknown card"); } // change this
            idOfPersonRelated = (int)result.Rows[0][sql.user_idCollumName];

            // ---regtable
            // check of vandaag al 2 entries van personrelated in regtable zijn alszo verwijder de laatste
            command = new SqlCommand();
            result = new DataTable();
            command.Parameters.AddWithValue("@regggdid", idOfPersonRelated);
            arg = new object[] {
                sql.reg_idCollumName,
                sql.regTableName,
                sql.reg_dateTimeCollumName,
                "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 00:00:00' AS DATETIME)",
                "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 23:59:59' AS DATETIME)",
                sql.reg_relatedUserIdCollumName };
            command.CommandText = string.Format("select {0} from {1} where {2} between {3} and {4} and {5} = @regggdid ORDER BY datetime DESC", arg);
            result = sql.SQLQuery(sql.connectionString, command);
            command = new SqlCommand();
            if (result != null) {
                if (result.Rows.Count > 1) { //delete een of meer entries
                    command.CommandText = "delete from " + sql.regTableName + " where " + sql.reg_idCollumName + " in (select top " + (result.Rows.Count - 1) + " ID from " + sql.regTableName + " where " + sql.reg_relatedUserIdCollumName + " = " + idOfPersonRelated + " order by " + sql.reg_dateTimeCollumName + " desc)";
                    int change = sql.SQLNonQuery(sql.connectionString, command);
                    if (change != result.Rows.Count - 1) {
                        return returnInfoForDisplay(0, "sqlConnectionError");
                    }
                }
            } else {
                return returnInfoForDisplay(0, "sqlConnectionError");
            }

            // ---aanwezigTable
            // kijk of er een aanwezig entry is
            command = new SqlCommand();
            result = new DataTable();
            arg = new object[] {
                sql.aanwezig_IDCollumName,
                sql.aanwezig_isAanwezigCollumName,
                sql.aanwezigTableName ,
                sql.aanwezig_datetimeCollumName,
                "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 00:00:00' AS DATETIME)",
                "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 23:59:59' AS DATETIME)",
                sql.aanwezig_relatedUserIDCollumName };
            command.Parameters.AddWithValue("@relateduserid", idOfPersonRelated);
            command.CommandText = string.Format("select {0}, {1} from {2} where {3} between {4} and {5} and {6} = @relateduserid", arg);
            result = sql.SQLQuery(sql.connectionString, command);
            if (result != null) {
                if (result.Rows.Count > 0) { // update aanwezig entry
                    command = new SqlCommand();
                    arg = new object[] {
                    sql.aanwezigTableName ,
                    sql.aanwezig_isAanwezigCollumName,
                    sql.aanwezig_relatedUserIDCollumName,
                    sql.aanwezig_datetimeCollumName,
                    "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 00:00:00' AS DATETIME)",
                    "CAST('" + _serverDateTime.Date.ToString("MM / dd / yyyy") + " 23:59:59' AS DATETIME)"
                    };
                    command.Parameters.AddWithValue("@value", !(bool)result.Rows[0][sql.aanwezig_isAanwezigCollumName]);
                    command.Parameters.AddWithValue("@relauser", idOfPersonRelated);
                    command.CommandText = string.Format("update {0} set {1} = @value where {2} = @relauser and {3} between {4} and {5}", arg);
                    int xxx = sql.SQLNonQuery(sql.connectionString, command);
                    if (xxx != 1) {
                        // DOE IETS
                    }
                } else { // create new aanwezig entry
                    command = new SqlCommand();
                    result = new DataTable();
                    arg = new object[] {
                        sql.aanwezigTableName,
                        sql.aanwezig_datetimeCollumName,
                        sql.aanwezig_relatedUserIDCollumName,
                        sql.aanwezig_isAanwezigCollumName
                    };
                    command.Parameters.AddWithValue("@userid", idOfPersonRelated);
                    command.Parameters.AddWithValue("@value", 1);
                    command.CommandText = string.Format("insert into {0} ({1}, {2}, {3}) values (getdate(), @userid, @value)", arg);
                    int rezoelt = sql.SQLNonQuery(sql.connectionString, command);
                    if (rezoelt != 1) {
                        //DOE IETS
                    }
                }
            }

            // ---regtable
            // add now to reg table
            command = new SqlCommand();
            result = new DataTable();
            command.CommandText = "insert into " + sql.regTableName + " (" + sql.reg_dateTimeCollumName + ", " + sql.reg_relatedUserIdCollumName + ", " + sql.reg_usedNfcCardIdCollumName + ") values (getdate(), " + idOfPersonRelated + ", '" + _READ.ID + "')";
            if (sql.SQLNonQuery(sql.connectionString, command) != 1) {
                return returnErrorWithMessage("sqlError"); //IETS
            } else {
                return returnInfoForDisplay(idOfPersonRelated, "");
            }
        }
    }
}