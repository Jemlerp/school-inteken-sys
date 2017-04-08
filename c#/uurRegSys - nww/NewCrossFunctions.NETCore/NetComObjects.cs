using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace NewCrossFunctions.NETCore {
    public class NetComObjects {
        public class ServerRequest {
            public string UserName { get; set; }
            public string Password { get; set; }
            public object Request { get; set; }
        }

        public class ServerResponse {
            public bool IsErrorOccurred { get; set; } = false;
            public ERRORINFO ErrorInfo { get; set; } = new ERRORINFO();
            public object Response { get; set; }
        }

        public class ERRORINFO {
            public string ErrorMessage { get; set; }
        }

        public interface IKnow {
            WhatIsThisEnum WatIsDit { get; }
        }

        public enum WhatIsThisEnum {
            RSqlServerDateTime,
            RInteken,
            ROneDateRegiOverzight,
            RMultiDateRegiOverzight,
            RChangeRegTable,

            GetUserTable, ChangeUserTable,
            GetModTable, ChangeModTable,
            GetAcountsTable, ChangeAcountTable
        }

        //base
        public class ServerRequestSqlDateTime : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.RSqlServerDateTime; } }
        }

        public class serverResponseSqlDateTime {
            public DateTime SqlDateTime { get; set; }
        }


        public class ServerRequestOverzightFromMultipleDates : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.RMultiDateRegiOverzight; } }
            public DateTime FromAndWithThisDate { get; set; }
            public DateTime TotEnMetDezeDatum { get; set; }
            public bool getForExUsers { get; set; }
        }

        public class ServerResponseOverzightFromMultipleDates {
            //baylife
            public List<ServerResponseOverzightFromMultipleDatesSubType> allesDatJeNodigHebt { get; set; } = new List<ServerResponseOverzightFromMultipleDatesSubType>();
        }

        public class ServerResponseOverzightFromMultipleDatesSubType {
            public ServerResponseOverzightFromOneDate OverZichtFromThisDate { get; set; } = new ServerResponseOverzightFromOneDate();
            public DateTime DateOfOverzight { get; set; }
        }


        public class ServerRequestTekenInOfUit : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.RInteken; } }
            public string NFCCode { get; set; }
        }

        public class ServerResponseInteken {
            public DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry TheUserWithEntryInfo { get; set; } = new DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry();
            public bool ingetekened { get; set; } // is nu 3
            public bool uitgetekened { get; set; } // is nu 1
            public bool uitekenengeanuleerd { get; set; } // in nu 2
            // deze week uur (tekort:D) overzight>?
        }


        public class ServerRequestOverzightFromOneDate : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.ROneDateRegiOverzight; } }
            public bool useToday { get; set; } = false;
            public bool alsoReturnExUsers { get; set; } = false;
            public DateTime dateToGetOverzightFrom { get; set; }
        }

        public class ServerResponseOverzightFromOneDate {
            public List<DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry> EtList { get; set; } = new List<DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry>();
            public DateTime SQlDateTime { get; set; }
        }


        public class ServerRequestChangeRegistratieTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.RChangeRegTable; } }
            public bool isNieuwEntry { get; set; } = false; //als true ignore DatabaseTypesAndFunctions.RegistratieTableTableEntry.ID
            public bool newEntryDateIsToday { get; set; } = true;
            public DatabaseObjects.RegistratieTableTableEntry deEntry { get; set; } = new DatabaseObjects.RegistratieTableTableEntry();
        }

        public class ServerResponseChangeRegistratieTable {
            //public DatabaseTypesAndFunctions.RegistratieTableTableEntry deEntry { get; set; } // voor DatabaseTypesAndFunctions.RegistratieTableTableEntry.ID als het nietuw as //SCOPE_IDENTITY() wwerrk nie
        }

        // newR

        //user
        public class ServerRequestGetUserTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.GetUserTable; } }
            public bool aleenDieNogOpSchoolZitten { get; set; } = true;
        }

        public class ServerResponseGetUserTable {
            public List<DatabaseObjects.UserTableTableEntry> deEntrys { get; set; } = new List<DatabaseObjects.UserTableTableEntry>();
        }


        public class ServerRequestChangeUserTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.ChangeUserTable; } }
            public bool IsNewUser { get; set; } = false;
            public bool DeleteEntry { get; set; } = false;
            public DatabaseObjects.UserTableTableEntry deEntry { get; set; }
        }

        public class ServerResponseChangeUserTable {
            public bool OK { get; set; } = true;
        }

        //mod
        public class ServerRequestGetModTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.GetModTable; } }
            public DateTime AllesWaarvanErEffectIsTussenDeze { get; set; }
            public DateTime EnDezeDatums { get; set; }
        }

        public class ServerResponseGetModTable {
            public List<DatabaseObjects.ModifierTableEntry> deEntrys { get; set; } = new List<DatabaseObjects.ModifierTableEntry>();
        }


        public class ServerRequestChangeModTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.ChangeModTable; } }
            public bool IsNewEntry { get; set; } = false;
            public bool DeleteEntry { get; set; } = false;
            public DatabaseObjects.ModifierTableEntry deEntry { get; set; } = new DatabaseObjects.ModifierTableEntry();
        }

        public class ServerResponseChangeModTable {
            public bool OK { get; set; } = true;
        }

        //acount
        public class ServerRequestGetAcountsTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.GetAcountsTable; } }
        }

        public class ServerResponseGetAcountTable {
            public List<DatabaseObjects.AcountTableEntry> deEntrys { get; set; } = new List<DatabaseObjects.AcountTableEntry>();
        }


        public class ServerRequestChangeAcountTable : IKnow {
            public WhatIsThisEnum WatIsDit { get { return WhatIsThisEnum.ChangeAcountTable; } }
            public bool IsNewEntry { get; set; } = false;
            public bool DeleteEntry { get; set; } = false;
            public DatabaseObjects.AcountTableEntry deEntry { get; set; }
        }

        public class ServerResponseChangeAcountTable {
            public bool OK { get; set; } = true;
        }
    }
}
