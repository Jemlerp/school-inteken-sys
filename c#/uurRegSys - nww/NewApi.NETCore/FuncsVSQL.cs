using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NewApi.NETCore
{
    public class FuncsVSQL
    {
        public static string _ConnectionString = "Server=DESKTOP-RAR7FQP\\SQLEXPRESS; Database=newTestDb; User Id=sa; password=kanker;";

        public static int SQLNonQuery(string _command)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = _command;
            return SQLNonQuery(command);
        }

        public static int SQLNonQuery(SqlCommand _command)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    _command.Connection = sqlConnection;
                    sqlConnection.Open();
                    return _command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"ERROR @ SQL Command: {_command.CommandText} | Message: {ex.Message}");
                }
            }
        }

        public static SqlDataReader SQLQuery(string _command)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = _command;
            return SQLQuery(command);
        }

        public static SqlDataReader SQLQuery(SqlCommand _command)
        {
            SqlConnection sqlConnection = new SqlConnection(_ConnectionString);
            try
            {
                _command.Connection = sqlConnection;
                sqlConnection.Open();
                return _command.ExecuteReader();
                //close? dispose?
            }
            catch (Exception ex)
            {
                sqlConnection.Dispose();
                throw new Exception($"ERROR @ SQL Command: {_command.CommandText} | Message: {ex.Message}");
            }
        }

    }
}
