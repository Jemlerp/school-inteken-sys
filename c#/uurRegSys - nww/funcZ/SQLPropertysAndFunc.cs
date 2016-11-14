using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace funcZ {

    public class SQLPropertysAndFunc {

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
            if (row.Table.Columns.Contains(LogTableNames.ID)) { if(row[LogTableNames.ID] != DBNull.Value) toReturn.ID=(int)row[LogTableNames.ID]; }
            if (row.Table.Columns.Contains(LogTableNames.IDOfUserRelated)) { if (row[LogTableNames.IDOfUserRelated]!=DBNull.Value) toReturn.IDOfUserRelated=(int)row[LogTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(LogTableNames.date)) { if (row[LogTableNames.date]!=DBNull.Value) toReturn.dateOfEntry=(DateTime)row[LogTableNames.date]; }
            if (row.Table.Columns.Contains(LogTableNames.time)) { if (row[LogTableNames.time]!=DBNull.Value) toReturn.timeOFEntry=(TimeSpan)row[LogTableNames.time]; }
            if (row.Table.Columns.Contains(LogTableNames.doetInteken)) { if (row[LogTableNames.doetInteken]!=DBNull.Value) toReturn.doetInteken=(bool)row[LogTableNames.doetInteken]; }
            if (row.Table.Columns.Contains(LogTableNames.doetUitteken)) { if (row[LogTableNames.doetUitteken]!=DBNull.Value) toReturn.doetUiteken=(bool)row[LogTableNames.doetUitteken]; }
            if (row.Table.Columns.Contains(LogTableNames.anuleerdUitteken)) { if (row[LogTableNames.anuleerdUitteken]!=DBNull.Value) toReturn.anuleerdUitTeken=(bool)row[LogTableNames.anuleerdUitteken]; }
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
            if (row.Table.Columns.Contains(RegistratieTableNames.ID)) { if (row[RegistratieTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[RegistratieTableNames.ID]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IDOfUserRelated)) { if (row[RegistratieTableNames.IDOfUserRelated]!=DBNull.Value) toReturn.IDOfUserRelated=(int)row[RegistratieTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.Date)) { if (row[RegistratieTableNames.Date]!=DBNull.Value) toReturn.Date=(DateTime)row[RegistratieTableNames.Date]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeInteken)) { if (row[RegistratieTableNames.TimeInteken]!=DBNull.Value) toReturn.TimeInteken=(TimeSpan)row[RegistratieTableNames.TimeInteken]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeUitteken)) { if (row[RegistratieTableNames.TimeUitteken]!=DBNull.Value) toReturn.TimeUitteken=(TimeSpan)row[RegistratieTableNames.TimeUitteken]; }
            if(row.Table.Columns.Contains(RegistratieTableNames.IsAanwezig)) { if (row[RegistratieTableNames.IsAanwezig]!=DBNull.Value) toReturn.IsAanwezig=(bool)row[RegistratieTableNames.IsAanwezig]; }
            return toReturn;
        }

        public List<RegistratieTableTableEntry> GetListRegistratieTableEntrysFromDataTable(DataTable table) {
            List<RegistratieTableTableEntry> toReturn = new List<RegistratieTableTableEntry>();
            foreach (DataRow row in table.Rows) {
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
            if (row.Table.Columns.Contains(UserTableNames.ID)) { if (row[UserTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[UserTableNames.ID]; }
            if (row.Table.Columns.Contains(UserTableNames.voorNaam)) { if (row[UserTableNames.voorNaam]!=DBNull.Value) toReturn.voorNaam=(string)row[UserTableNames.voorNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.achterNaam)) { if (row[UserTableNames.achterNaam]!=DBNull.Value) toReturn.achterNaam=(string)row[UserTableNames.achterNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.NFCID)) { if (row[UserTableNames.NFCID]!=DBNull.Value) toReturn.NFCID=(string)row[UserTableNames.NFCID]; }
            return toReturn;
        }

        public List<UserTableTableEntry> GetListUserTableEntriesFromDataTable(DataTable table) {
            List<UserTableTableEntry> toReturn = new List<UserTableTableEntry>();
            foreach (DataRow row in table.Rows) {
                toReturn.Add(GetUserTableEntryFromDataRow(row));
            }
            return toReturn;
        }
        #endregion

        #region AfwezigTable
        public class AfwezighijdTableNames {
            public static string AfwezighijdTableName = "afwezighijdTable";
            public static string ID = "ID";
            public static string IDOfUserRelated = "IDOfUserRelated";
            public static string Date = "Date";
            public static string IsZiek = "IsZiek";
            public static string IsFlexibelverlof = "IsFlexibelverlof";
            public static string IsStudieverlof = "IsStudieverlof";
            public static string IsExcursie = "IsExursie";
            public static string AnderenRedenVoorAfwezighijd = "AnderenRedenVoorAfwezighijd";
        }

        public class AfwezighijdTableTableEntry {
            public int ID { get; set; }
            public int IDOfRelatedPerson { get; set; }
            public bool IsZiek { get; set; }
            public bool IsFlexiebelverlof { get; set; }
            public bool IsStudieverlof { get; set; }
            public bool IsExcurtie { get; set; }
            public string AnderenRedenVoorAfwezigihijd { get; set; }
        }

        public AfwezighijdTableTableEntry GetAfwezighijdTableEntryFromDataRow(DataRow row) {
            AfwezighijdTableTableEntry toReturn = new AfwezighijdTableTableEntry();
            if (row.Table.Columns.Contains(AfwezighijdTableNames.ID)) { if (row[AfwezighijdTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[AfwezighijdTableNames.ID]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.IDOfUserRelated)) { if (row[AfwezighijdTableNames.IDOfUserRelated]!=DBNull.Value) toReturn.IDOfRelatedPerson=(int)row[AfwezighijdTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.IsExcursie)) { if (row[AfwezighijdTableNames.IsExcursie]!=DBNull.Value) toReturn.IsExcurtie=(bool)row[AfwezighijdTableNames.IsExcursie]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.IsFlexibelverlof)) { if (row[AfwezighijdTableNames.IsFlexibelverlof]!=DBNull.Value) toReturn.IsFlexiebelverlof=(bool)row[AfwezighijdTableNames.IsFlexibelverlof]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.IsStudieverlof)) { if (row[AfwezighijdTableNames.IsStudieverlof]!=DBNull.Value) toReturn.IsStudieverlof=(bool)row[AfwezighijdTableNames.IsStudieverlof]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.IsZiek)) { if (row[AfwezighijdTableNames.IsZiek]!=DBNull.Value) toReturn.IsZiek=(bool)row[AfwezighijdTableNames.IsZiek]; }
            if (row.Table.Columns.Contains(AfwezighijdTableNames.AnderenRedenVoorAfwezighijd)) { if (row[AfwezighijdTableNames.AnderenRedenVoorAfwezighijd]!=DBNull.Value) toReturn.AnderenRedenVoorAfwezigihijd=(string)row[AfwezighijdTableNames.AnderenRedenVoorAfwezighijd]; }
            return toReturn;
        }

        public List<AfwezighijdTableTableEntry> GetListAfwezighijdTableEntriesFromDataTable(DataTable table) {
            List<AfwezighijdTableTableEntry> toReturn = new List<AfwezighijdTableTableEntry>();
            foreach(DataRow x in table.Rows) {
                toReturn.Add(GetAfwezighijdTableEntryFromDataRow(x));
            }
            return toReturn;
        }

        #endregion

    }
}