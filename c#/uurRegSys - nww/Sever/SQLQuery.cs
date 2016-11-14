using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sever {
    public class SQlOnlquery {

        public static string _ConnectionString = "Server=DESKTOP-M1ICC4F\\GENERICNAME; Database=inprovedreg; User Id=sa; password=kanker;";

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
                    throw new Exception($"SQL Command: | {_Command} | Error Message: {ex.Message}");
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
                    throw new Exception($"SQL Command: | {_Command} | Error Message: {ex.Message}");
                }
            }
        }
    }
}