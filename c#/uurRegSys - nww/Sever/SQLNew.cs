using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sever {
    public class SQLNew {
        public static string _ConnectionString = "Server=DESKTOP-M1ICC4F\\GENERICNAME; Database=testnfcreg; User Id=sa; password=kanker;";
        //public static string databaseName = "inprovedreg";

        #region logTable

        public static class LogTableNames {
            public static string LogTableName = "logTable";
            public static string ID = "ID";
            public static string IDOfUserRelated = "IDOfUserRelated";
            public static string date = "date";
            public static string time = "time";
            public static string doetInteken = "doetInteken";
            public static string doetUitteken = "doetuitteken";
            public static string anuleerdUitteken = "anuleerdUitteken";
        }

        public class LogTableTableEntry {
            public int ID { get; set; }
            public int IDOfUserRelated { get; set; }
            public DateTime dateOfEntry { get; set; }
            public TimeSpan timeOFEntry { get; set; }
            public bool doetInteken { get; set; }
            public bool doetUiteken { get; set; }
            public bool anuleerdUitTeken { get; set; }
        }

        public LogTableTableEntry GetLogTableEntryFromDataRow(DataRow row) {
            LogTableTableEntry toReturn = new LogTableTableEntry();
            if (row.Table.Columns.Contains(LogTableNames.ID)) { toReturn.ID=(int)row[LogTableNames.ID]; }
            if (row.Table.Columns.Contains(LogTableNames.IDOfUserRelated)) { toReturn.IDOfUserRelated=(int)row[LogTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(LogTableNames.date)) { toReturn.dateOfEntry=(DateTime)row[LogTableNames.date]; }
            if (row.Table.Columns.Contains(LogTableNames.time)) { toReturn.timeOFEntry=(TimeSpan)row[LogTableNames.time]; }
            if (row.Table.Columns.Contains(LogTableNames.doetInteken)) { toReturn.doetInteken=(bool)row[LogTableNames.doetInteken]; }
            if (row.Table.Columns.Contains(LogTableNames.doetUitteken)) { toReturn.doetUiteken=(bool)row[LogTableNames.doetUitteken]; }
            if (row.Table.Columns.Contains(LogTableNames.anuleerdUitteken)) { toReturn.anuleerdUitTeken=(bool)row[LogTableNames.anuleerdUitteken]; }
            return toReturn;
        }

        public List<LogTableTableEntry> GetListLogTableEntrysFromDateTable(DataTable table) {
            List<LogTableTableEntry> toReturn = new List<LogTableTableEntry>();
            foreach (DataRow row in table.Rows) {
                toReturn.Add(GetLogTableEntryFromDataRow(row));
            }
            return toReturn;
        }
        #endregion

        #region RegTable

        public class RegistratieTableNames {
            public static string registratieTableName = "registratieTable";
            public static string ID = "ID";
            public static string IDOfUserRelated = "IDOfUserRelated";
            public static string Date = "date";
            public static string TimeInteken = "timeInteken";
            public static string TimeUitteken = "timeUitteken";
            public static string IsAanwezig = "isAanwezig";
        }

        public class RegistratieTableTableEntry {
            public int ID { get; set; }
            public int IDOfUserRelated { get; set; }
            public DateTime Date { get; set; } // db heeft aleen date want als datetime is zoeken lastiger: datetime between x and x ionplaaats vcan date=
            public TimeSpan TimeInteken { get; set; } // db heeft aleen tijd en niet date aleen nu is dit makelijker
            public TimeSpan TimeUitteken { get; set; }
            public bool IsAanwezig { get; set; }
        }

         public RegistratieTableTableEntry GetRegistratieTableEntryFromDataRow(DataRow row) {
            RegistratieTableTableEntry toReturn = new RegistratieTableTableEntry();
            if (row.Table.Columns.Contains(RegistratieTableNames.ID)) { toReturn.ID=(int)row[RegistratieTableNames.ID]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IDOfUserRelated)) { toReturn.IDOfUserRelated=(int)row[RegistratieTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.Date)) { toReturn.Date=(DateTime)row[RegistratieTableNames.Date]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeInteken)) { toReturn.TimeInteken=(TimeSpan)row[RegistratieTableNames.TimeInteken]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeUitteken)) { toReturn.TimeUitteken=(TimeSpan)row[RegistratieTableNames.TimeUitteken]; }
            return toReturn;
        }

        public List<RegistratieTableTableEntry> GetListRegistratieTableEntrysFromDataTable(DataTable table) {
            List<RegistratieTableTableEntry> toReturn = new List<RegistratieTableTableEntry>();
            foreach(DataRow row in table.Rows) {
                toReturn.Add(GetRegistratieTableEntryFromDataRow(row));
            }
            return toReturn;
        }
        #endregion

        #region UserTable

        public static class UserTableNames {
            public static string userTableName = "userTable";
            public static string ID = "ID";
            public static string voorNaam = "voorNaam";
            public static string achterNaam = "achterNaam";
            public static string NFCID = "NFCID";
        }

       public class UserTableTableEntry {
            public int ID { get; set; }
            public string voorNaam { get; set; }
            public string achterNaam { get; set; }
            public string NFCID { get; set; }
        }

        public UserTableTableEntry GetUserTableEntryFromDataRow(DataRow row) {
            UserTableTableEntry toReturn = new UserTableTableEntry();
            if (row.Table.Columns.Contains(UserTableNames.ID)) { toReturn.ID=(int)row[UserTableNames.ID]; }
            if (row.Table.Columns.Contains(UserTableNames.voorNaam)) { toReturn.voorNaam=(string)row[UserTableNames.voorNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.achterNaam)) { toReturn.achterNaam=(string)row[UserTableNames.achterNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.NFCID)) { toReturn.NFCID=(string)row[UserTableNames.NFCID]; }
            return toReturn;
        }

        public List<UserTableTableEntry> GetListUserTableEntriesFromDataTable(DataTable table) {
            List<UserTableTableEntry> toReturn = new List<UserTableTableEntry>();
            foreach(DataRow row in table.Rows) {
                toReturn.Add(GetUserTableEntryFromDataRow(row));
            }
            return toReturn;
        }
        #endregion

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