using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewApi {
    public class SqlDingusEnUserRechten {

        /* aanspreekpunt rechten lvl 1 = je kan alles van vandaag aanpassen; lvl 2 = je kan ook dingen van andere dagen aanpassen
         * nieuw users rechten lvl 1 = je mag mensen in het syseem stoppen en mensen hun nfc code aanpassen en naam...; lvl2 je kan mensen ook verwijderen, dat niet niet ongedaan gemaakt worden! (not recomended tho(tenzij een lvl1 noob een nieuw user peroncheluk heeft ingezet))
         * uurAdministrator lvl 1 = je kan overzichte uitdraaien; lvl2 je kan ook alles aanpassen ( maar aanpassingen gaan waarschijlijk toch aleen gedaan kunnen worden met aanspreekpunt form 
         */


        //public static string _ConnectionString = "Server=shishidou-pc/sqlexpress; Database=newTestDb;";
        public static string _ConnectionString = "Server=DESKTOP-M1ICC4F\\GENERICNAME; Database=newTestDb; User Id=sa; password=kanker;";
        //public static string _ConnectionString = "Server=DESKTOP-27V2B6M; Database=inprovedreg; User Id=sa; password=kanker;";        

        public static int SQLNonQuery(string _Command) {
            SqlCommand command = new SqlCommand();
            command.CommandText=_Command;
            return SQLNonQuery(command);
        }

        public static int SQLNonQuery(SqlCommand _Command) {
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection=sqlConnection;
                    sqlConnection.Open();
                    return _Command.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new Exception($"ERROR @ SQL Command: | {_Command} | ERROR Message: {ex.Message}");
                }
            }
        }

        public static DataTable SQLQuery(string _Command) {
            SqlCommand command = new SqlCommand();
            command.CommandText=_Command;
            return SQLQuery(command);
        }

        public static DataTable SQLQuery(SqlCommand _Command) {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection=sqlConnection;
                    sqlConnection.Open();
                    dataTable.Load(_Command.ExecuteReader());
                    return dataTable;
                } catch (Exception ex) {
                    throw new Exception($"ERROR @ SQL Command: | {_Command} | ERROR Message: {ex.Message}");
                }
            }
        }
    }
}