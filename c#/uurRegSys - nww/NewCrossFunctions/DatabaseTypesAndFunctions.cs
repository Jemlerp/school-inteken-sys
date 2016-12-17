using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCrossFunctions {
    public class DatabaseTypesAndFunctions {

        public class CombineerUserEntryRegEntryAndAfwezigEntry {
            public RegistratieTableTableEntry regE { get; set; } = new RegistratieTableTableEntry();
            public UserTableTableEntry userN { get; set; } = new UserTableTableEntry();
            public bool hasTodayRegEntry { get; set; } = false;
        }

        #region acounts/rechten
        public static class AcountsTableNames {
            public static string AcountsTableName = "acountsTable";
            public static string ID = "ID";
            public static string Naam = "Naam";
            public static string inlogNaam = "InlogNaam";
            public static string inlogWachtwoord = "InlogWachtwoord";
            public static string aanspreekpuntBevoegthijdLvl = "AanspreekpuntBeoegdhijd";
            public static string adminBevoegdhijd = "AdminBevoegdhijd";
        }

        public class AcountTableEntry {
            public string Naam { get; set; }
            public int ID { get; set; }
            public string inlogNaam { get; set; }
            public string inlogWachtwoord { get; set; }
            public int aanspreekpuntBevoegdhijd { get; set; }
            public int adminBevoegdhijd { get; set; }
        }

        public AcountTableEntry GetAcountTableEntryFromDataRow(DataRow row) {
            AcountTableEntry toReturn = new AcountTableEntry();
            if (row.Table.Columns.Contains(AcountsTableNames.Naam)) { if (row[AcountsTableNames.Naam]!=DBNull.Value) toReturn.Naam=(string)row[AcountsTableNames.Naam]; }
            if (row.Table.Columns.Contains(AcountsTableNames.ID)) { if (row[AcountsTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[AcountsTableNames.ID]; }
            if (row.Table.Columns.Contains(AcountsTableNames.inlogNaam)) { if (row[AcountsTableNames.inlogNaam]!=DBNull.Value) toReturn.inlogNaam=(string)row[AcountsTableNames.inlogNaam]; }
            if (row.Table.Columns.Contains(AcountsTableNames.inlogWachtwoord)) { if (row[AcountsTableNames.inlogWachtwoord]!=DBNull.Value) toReturn.inlogWachtwoord=(string)row[AcountsTableNames.inlogWachtwoord]; }
            if (row.Table.Columns.Contains(AcountsTableNames.aanspreekpuntBevoegthijdLvl)) { if (row[AcountsTableNames.aanspreekpuntBevoegthijdLvl]!=DBNull.Value) toReturn.aanspreekpuntBevoegdhijd=(int)row[AcountsTableNames.aanspreekpuntBevoegthijdLvl]; }
            if (row.Table.Columns.Contains(AcountsTableNames.adminBevoegdhijd)) { if (row[AcountsTableNames.adminBevoegdhijd]!=DBNull.Value) toReturn.adminBevoegdhijd=(int)row[AcountsTableNames.adminBevoegdhijd]; }
            return toReturn;
        }
        public List<AcountTableEntry> GetListAcountTableEntriesFromDataTable(DataTable table) {
            List<AcountTableEntry> toReturn = new List<AcountTableEntry>();
            foreach (DataRow row in table.Rows) {
                toReturn.Add(GetAcountTableEntryFromDataRow(row));
            }
            return toReturn;
        }
        #endregion

        #region UserTable
        public static class UserTableNames {
            public static string UserTableName = "userTable";
            public static string ID = "ID";
            public static string VoorNaam = "Voornaam";
            public static string AchterNaam = "Achternaam";
            public static string NFCID = "NFCID";
            public static string DateJoined = "DateJoined";
            public static string IsActiveUser = "ZitNogOpSchool"; // !!!!!!!!
            public static string DateLeft = "DateLeft";
        }
        public class UserTableTableEntry {
            public int ID { get; set; }
            public string VoorNaam { get; set; }
            public string AchterNaam { get; set; }
            public string NFCID { get; set; }
            public bool IsActiveUser { get; set; }
            public DateTime DateJoined { get; set; }
            public DateTime DateLeft { get; set; }
        }
        public UserTableTableEntry GetUserTableEntryFromDataRow(DataRow row) {
            UserTableTableEntry toReturn = new UserTableTableEntry();
            if (row.Table.Columns.Contains(UserTableNames.ID)) { if (row[UserTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[UserTableNames.ID]; }
            if (row.Table.Columns.Contains(UserTableNames.VoorNaam)) { if (row[UserTableNames.VoorNaam]!=DBNull.Value) toReturn.VoorNaam=(string)row[UserTableNames.VoorNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.AchterNaam)) { if (row[UserTableNames.AchterNaam]!=DBNull.Value) toReturn.AchterNaam=(string)row[UserTableNames.AchterNaam]; }
            if (row.Table.Columns.Contains(UserTableNames.NFCID)) { if (row[UserTableNames.NFCID]!=DBNull.Value) toReturn.NFCID=(string)row[UserTableNames.NFCID]; }
            if (row.Table.Columns.Contains(UserTableNames.IsActiveUser)) { if (row[UserTableNames.IsActiveUser]!=DBNull.Value) toReturn.IsActiveUser=(bool)row[UserTableNames.IsActiveUser]; }
            if (row.Table.Columns.Contains(UserTableNames.DateJoined)) { if (row[UserTableNames.DateJoined]!=DBNull.Value) toReturn.DateJoined=(DateTime)row[UserTableNames.DateJoined]; }
            if (row.Table.Columns.Contains(UserTableNames.DateLeft)) { if (row[UserTableNames.DateLeft]!=DBNull.Value) toReturn.DateLeft=(DateTime)row[UserTableNames.IsActiveUser]; }
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

        #region RegTable
        public class RegistratieTableNames {
            public static string RegistratieTableName = "registratieTable";
            public static string ID = "ID";
            public static string IDOfUserRelated = "IDOfUserRelated";
            public static string Date = "date";
            public static string TimeInteken = "TimeInteken";
            public static string TimeUitteken = "TimeUitteken";
            public static string HeeftIngetekend = "HeeftIngetekend";
            public static string IsAanwezig = "IsAanwezig";
            public static string IsZiek = "IsZiek";
            public static string IsFlexibelverlof = "IsFlexibelverlof";
            public static string IsStudieverlof = "IsStudieverlof";
            public static string IsExcursie = "IsExursie";
            public static string IsLaat = "IsLaat";
            public static string IsAndereReden = "IsAndereReden";
            public static string AnderenRedenVoorAfwezighijd = "OmscrijvingAnderenReden";
            public static string Verwachtetijdvanaanwezighijd = "VerwachtetijdVanaanwezighijd";
        }
        public class RegistratieTableTableEntry {
            public int ID { get; set; }
            public int IDOfUserRelated { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan TimeInteken { get; set; }
            public TimeSpan TimeUitteken { get; set; }
            public bool HeeftIngetekend { get; set; } = false;
            public bool IsAanwezig { get; set; } = false;
            public bool IsZiek { get; set; } = false;
            public bool IsFlexiebelverlof { get; set; } = false;
            public bool IsStudieverlof { get; set; } = false;
            public bool IsExcurtie { get; set; } = false;
            public bool IsLaat { get; set; } = false;
            public bool IsAndereReden { get; set; } = false;
            public string AnderenRedenVoorAfwezigihijd { get; set; } = "";
            public string Verwachtetijdvanaanwezighijd { get; set; } = "";
        }
        public RegistratieTableTableEntry GetRegistratieTableEntryFromDataRow(DataRow row) {
            RegistratieTableTableEntry toReturn = new RegistratieTableTableEntry();
            if (row.Table.Columns.Contains(RegistratieTableNames.ID)) { if (row[RegistratieTableNames.ID]!=DBNull.Value) toReturn.ID=(int)row[RegistratieTableNames.ID]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IDOfUserRelated)) { if (row[RegistratieTableNames.IDOfUserRelated]!=DBNull.Value) toReturn.IDOfUserRelated=(int)row[RegistratieTableNames.IDOfUserRelated]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.Date)) { if (row[RegistratieTableNames.Date]!=DBNull.Value) toReturn.Date=(DateTime)row[RegistratieTableNames.Date]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeInteken)) { if (row[RegistratieTableNames.TimeInteken]!=DBNull.Value) toReturn.TimeInteken=(TimeSpan)row[RegistratieTableNames.TimeInteken]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.TimeUitteken)) { if (row[RegistratieTableNames.TimeUitteken]!=DBNull.Value) toReturn.TimeUitteken=(TimeSpan)row[RegistratieTableNames.TimeUitteken]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.HeeftIngetekend)) { if (row[RegistratieTableNames.HeeftIngetekend]!=DBNull.Value) toReturn.HeeftIngetekend=(bool)row[RegistratieTableNames.HeeftIngetekend]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsAanwezig)) { if (row[RegistratieTableNames.IsAanwezig]!=DBNull.Value) toReturn.IsAanwezig=(bool)row[RegistratieTableNames.IsAanwezig]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsExcursie)) { if (row[RegistratieTableNames.IsExcursie]!=DBNull.Value) toReturn.IsExcurtie=(bool)row[RegistratieTableNames.IsExcursie]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsFlexibelverlof)) { if (row[RegistratieTableNames.IsFlexibelverlof]!=DBNull.Value) toReturn.IsFlexiebelverlof=(bool)row[RegistratieTableNames.IsFlexibelverlof]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsStudieverlof)) { if (row[RegistratieTableNames.IsStudieverlof]!=DBNull.Value) toReturn.IsStudieverlof=(bool)row[RegistratieTableNames.IsStudieverlof]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsZiek)) { if (row[RegistratieTableNames.IsZiek]!=DBNull.Value) toReturn.IsZiek=(bool)row[RegistratieTableNames.IsZiek]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsLaat)) { if (row[RegistratieTableNames.IsLaat]!=DBNull.Value) toReturn.IsLaat=(bool)row[RegistratieTableNames.IsLaat]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.IsAndereReden)) { if (row[RegistratieTableNames.IsAndereReden]!=DBNull.Value) toReturn.IsAndereReden=(bool)row[RegistratieTableNames.IsAndereReden]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.AnderenRedenVoorAfwezighijd)) { if (row[RegistratieTableNames.AnderenRedenVoorAfwezighijd]!=DBNull.Value) toReturn.AnderenRedenVoorAfwezigihijd=(string)row[RegistratieTableNames.AnderenRedenVoorAfwezighijd]; }
            if (row.Table.Columns.Contains(RegistratieTableNames.Verwachtetijdvanaanwezighijd)) { if (row[RegistratieTableNames.Verwachtetijdvanaanwezighijd]!=DBNull.Value) toReturn.Verwachtetijdvanaanwezighijd=(string)row[RegistratieTableNames.Verwachtetijdvanaanwezighijd]; }
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

    }
}
