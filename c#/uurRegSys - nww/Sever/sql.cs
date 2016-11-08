using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Sever {
    public class sql {


        //public static string connectionString =
        //                   "server = DESKTOP-27V2B6M;" +
        //                   "Trusted_Connection=True;" +
        //                   "database=testnfcreg; ";

        public static string connectionString = "Server=DESKTOP-27V2B6M; Database=testnfcreg; User Id=sa; password=kanker;";

        public static string databaseName = "testnfcreg";

        //tableNames    
        public static string userTableName = "userTable";
        public static string regTableName = "regTable";
        public static string uitzonderingTableName = "uitzonderingTable";
        public static string aanwezigTableName = "aanwezigTable";

        //columNames
        public static string user_voorNaamCollumName = "voorNaam";
        public static string user_achterNaamCollumName = "achterNaam";
        public static string user_nfcCodeCollumName = "nfcCode";
        public static string user_idCollumName = "ID";

        public static string reg_dateTimeCollumName = "datetime";
        public static string reg_relatedUserIdCollumName = "relatedUserID";
        public static string reg_usedNfcCardIdCollumName = "usedNFCID";
        public static string reg_idCollumName = "ID";

        public static string uitzondering_userToApplyToCollumName = "useridtoapplyto";
        public static string uitzondering_dateOfAffectCollumName = "dateofeffect";
        public static string uitzondering_isZiekCollumName = "isziek";
        public static string uitzondering_isFlexiebelverlofCollumName = "isflexiebelverlof";
        public static string uitzondering_uurenCorrectionToApplyCollumName = "uurincorectie"; // positieve en negatieve
        public static string uitzondering_minutenCorrectionToApplyCollumName = "minutincorectie"; // positieve en negatieve
        public static string uitzondering_andereRedenVoorCorectieCollumName = "andereredenvoorcorectie";
        public static string uitzondering_idCollumName = "ID";

        public static string aanwezig_datetimeCollumName = "datetime"; 
        public static string aanwezig_relatedUserIDCollumName = "relatedUserID";
        public static string aanwezig_isAanwezigCollumName = "isAanwezig";
        public static string aanwezig_IDCollumName = "ID";




        public static int SQLNonQuery(string _ConnectionString, SqlCommand _Command) {
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection = sqlConnection;
                    sqlConnection.Open();
                    return _Command.ExecuteNonQuery();
                } catch(Exception ex) {
                    string testz0r = ex.Message;
                    return 0;
                }
            }
        }

        public static DataTable SQLQuery(string _ConnectionString, SqlCommand _Command) {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection = sqlConnection;
                    sqlConnection.Open();
                    dataTable.Load(_Command.ExecuteReader());
                    return dataTable;
                } 
                catch(Exception ex) {
                    string test = ex.Message;
                    return null;
                }
            }
        }

    }
}