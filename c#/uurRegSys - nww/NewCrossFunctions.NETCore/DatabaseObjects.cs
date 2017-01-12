using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace NewCrossFunctions.NETCore
{
    public class DatabaseObjects
    {
        public class CombineerUserEntryRegEntryAndAfwezigEntry
        {
            public RegistratieTableTableEntry RegE { get; set; } = new RegistratieTableTableEntry();
            public UserTableTableEntry UsE { get; set; } = new UserTableTableEntry();
            public bool hasTodayRegEntry { get; set; } = false;
        }

        private static T ReadFromReader<T>(IDataRecord _recoord, string _readProp)
        {
            try
            {
                Type i = typeof(T);
                if (i == typeof(DateTime))
                {
                    return (T)(object)_recoord.GetDateTime(_recoord.GetOrdinal(_readProp));
                }
                if (i == typeof(TimeSpan))
                {
                    return (T)(object)_recoord.GetDateTime(_recoord.GetOrdinal(_readProp)).TimeOfDay;
                }
                return (T)_recoord.GetValue(_recoord.GetOrdinal(_readProp));
            }
            catch
            {
                return default(T);
            }
        }

        #region Acounts
        public static class AcountsTableNames
        {
            public static string AcountsTableName = "acountsTable";
            public static string ID = "ID";
            public static string Naam = "Naam";
            public static string InlogNaam = "InlogNaam";
            public static string InlogWachtwoord = "InlogWachtwoord";
            public static string AanspreekpuntBevoegthijdLvl = "AanspreekpuntBeoegdhijd";
            public static string AdminBevoegdhijd = "AdminBevoegdhijd";
        }

        public class AcountTableEntry
        {
            public string Naam { get; set; }
            public int ID { get; set; }
            public string InlogNaam { get; set; }
            public string InlogWachtwoord { get; set; }
            public int AanspreekpuntBevoegdhijd { get; set; }
            public int AdminBevoegdhijd { get; set; }
        }

        public List<AcountTableEntry> GetListATFromReader(SqlDataReader _reader)
        {
            List<AcountTableEntry> toReturn = new List<AcountTableEntry>();
            List<string> fields = new List<string>();
            for(int i = 0; i < _reader.FieldCount; i++)
            {
                fields.Add(_reader.GetName(i));
            }
            while (_reader.Read())
            {
                AcountTableEntry entry = new AcountTableEntry();
                if (fields.Contains(AcountsTableNames.ID)) { ReadFromReader<int>((IDataRecord)_reader, AcountsTableNames.ID); }
                if (fields.Contains(AcountsTableNames.Naam)) { ReadFromReader<string>((IDataRecord)_reader, AcountsTableNames.Naam); }
                if (fields.Contains(AcountsTableNames.InlogNaam)) { ReadFromReader<string>((IDataRecord)_reader, AcountsTableNames.InlogNaam); }
                if (fields.Contains(AcountsTableNames.InlogWachtwoord)) { ReadFromReader<string>((IDataRecord)_reader, AcountsTableNames.InlogWachtwoord); }
                if (fields.Contains(AcountsTableNames.AanspreekpuntBevoegthijdLvl)) { ReadFromReader<int>((IDataRecord)_reader, AcountsTableNames.AanspreekpuntBevoegthijdLvl); }
                if (fields.Contains(AcountsTableNames.AdminBevoegdhijd)) { ReadFromReader<int>((IDataRecord)_reader, AcountsTableNames.AdminBevoegdhijd); }
                toReturn.Add(entry);
            }
            _reader.Dispose();
            return toReturn;
        }

        #endregion
         

        #region Users
        public static class UserTableNames
        {
            public static string UserTableName = "userTable";
            public static string ID = "ID";
            public static string VoorNaam = "Voornaam";
            public static string AchterNaam = "Achternaam";
            public static string NFCID = "NFCID";
            public static string DateJoined = "DateJoined";
            public static string IsActiveUser = "ZitNogOpSchool"; // !!!!!!!!
            public static string DateLeft = "DateLeft";
        }

        public class UserTableTableEntry
        {
            public int ID { get; set; }
            public string VoorNaam { get; set; }
            public string AchterNaam { get; set; }
            public string NFCID { get; set; }
            public bool IsActiveUser { get; set; }
            public DateTime DateJoined { get; set; }
            public DateTime DateLeft { get; set; }
        }

        public List<UserTableTableEntry> GetListUTFromReader(SqlDataReader _reader)
        {
            List<UserTableTableEntry> toReturn = new List<UserTableTableEntry>();
            List<string> fields = new List<string>();
            for (int i = 0; i < _reader.FieldCount; i++)
            {
                fields.Add(_reader.GetName(i));
            }
            while (_reader.Read())
            {
                UserTableTableEntry entry = new UserTableTableEntry();
                if (fields.Contains(UserTableNames.ID)) { ReadFromReader<int>((IDataRecord)_reader, UserTableNames.ID); }
                if (fields.Contains(UserTableNames.VoorNaam)) { ReadFromReader<string>((IDataRecord)_reader, UserTableNames.VoorNaam); }
                if (fields.Contains(UserTableNames.AchterNaam)) { ReadFromReader<string>((IDataRecord)_reader, UserTableNames.AchterNaam); }
                if (fields.Contains(UserTableNames.NFCID)) { ReadFromReader<string>((IDataRecord)_reader, UserTableNames.NFCID); }
                if (fields.Contains(UserTableNames.DateJoined)) { ReadFromReader<DateTime>((IDataRecord)_reader, UserTableNames.DateJoined); }
                if (fields.Contains(UserTableNames.DateLeft)) { ReadFromReader<DateTime>((IDataRecord)_reader, UserTableNames.DateLeft); }
                if (fields.Contains(UserTableNames.IsActiveUser)) { ReadFromReader<bool>((IDataRecord)_reader, UserTableNames.IsActiveUser); }
                toReturn.Add(entry);
            }
            _reader.Dispose();
            return toReturn;
        }
        #endregion


        #region reg
        public class RegistratieTableNames
        {
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
            public static string Opmerking = "Opmerking";
            public static string Verwachtetijdvanaanwezighijd = "VerwachtetijdVanaanwezighijd";
        }

        public class RegistratieTableTableEntry
        {
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
            public string Opmerking { get; set; } = "";
            public TimeSpan Verwachtetijdvanaanwezighijd { get; set; }
        }

        public List<RegistratieTableTableEntry> GetListRTFromReader(SqlDataReader _reader)
        {
            List<RegistratieTableTableEntry> toReturn = new List<RegistratieTableTableEntry>();
            List<string> fields = new List<string>();
            for (int i = 0; i < _reader.FieldCount; i++)
            {
                fields.Add(_reader.GetName(i));
            }
            while (_reader.Read())
            {
                RegistratieTableTableEntry entry = new RegistratieTableTableEntry();
                if (fields.Contains(RegistratieTableNames.ID)) { ReadFromReader<int>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IDOfUserRelated)) { ReadFromReader<int>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.Date)) { ReadFromReader<DateTime>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.TimeInteken)) { ReadFromReader<TimeSpan>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.TimeUitteken)) { ReadFromReader<TimeSpan>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.HeeftIngetekend)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsAanwezig)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsZiek)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsFlexibelverlof)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsStudieverlof)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsExcursie)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.IsLaat)) { ReadFromReader<bool>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.Opmerking)) { ReadFromReader<string>((IDataRecord)_reader, RegistratieTableNames.ID); }
                if (fields.Contains(RegistratieTableNames.Verwachtetijdvanaanwezighijd)) { ReadFromReader<TimeSpan>((IDataRecord)_reader, RegistratieTableNames.ID); }
                toReturn.Add(entry);
            }
            _reader.Dispose();
            return toReturn;
        }
        #endregion
    }
}
