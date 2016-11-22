using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace funcZ {

    public interface IKnow {
        SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get; }
    }

    public enum SendAndRecieveTypesEnum {

        AdminAskUsersDataTable,
        AdminReturnUsersDataTable,

        AdminAskChangeUserTable,
        AdminReturnChangeUsersTable,

        ReturnmetMogilikeError,
        SendmetWachtwoord,
        errorReport,
        SendNFCCardScanInfo,
        ReturnInfoAboutUserFromJustReadNFCCard,

        RequestOverviewAanwezige,
        ReturnOverviewAanwezige,

        SendChangeAfwezigHijd,
        ReturnChangeAfwezighijd
    };
    
    //common
    public class TResiveWithPosbleError : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.ReturnmetMogilikeError; } }
        public TError errorInfo { get; set; }
        public bool isErrorOcured { get; set; } = false;
        public object expectedResponse { get; set; }
    }

    public class TSendWithPassword : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.SendmetWachtwoord; } }
        public string password { get; set; }
        public bool isAdminInstrucion { get; set; } = false;
        public object tSend { get; set; }
    }

    public class TError : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.errorReport; } }
        public string errorText { get; set; }
    }

    //overlord contorls
    //admin contorls

    public class TAdminSendAskAllUsersDataTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.AdminAskUsersDataTable; } }
    }

    public class TAdminReturnAllUsersDataTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.AdminReturnUsersDataTable; } }
        public DataTable userDataTable { get; set; }
    }

    public class TAdminSendChangeUsersTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.AdminAskChangeUserTable; } }
        public bool isNewUser { get; set; } = false;
        public int toEditUserId { get; set; }

        public bool isVanSchoolAf { get; set; }

        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string NFCID { get; set; }
    }

    public class TAdminReturnChangeUsersTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.AdminReturnChangeUsersTable; } }
        public bool gelukt { get; set; }
    }







    //pleb conntorls

    //aanspreekpunt 
    public class TRequestChangeAfwezigTable:IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.SendChangeAfwezigHijd; } }
        public int fromUserID { get; set; }
        public bool clearRecordOfAfwezigVandaag { get; set; } = false;
        public bool IsZiek { get; set; } = false;
        public bool IsFlexiebelverlof { get; set; } = false;
        public bool IsStudieverlof { get; set; } = false;
        public bool IsExcurtie { get; set; } = false;
        public bool IsLaat { get; set; } = false;
        public bool IsAnderereden { get; set; } = false;
        public string AnderenRedenVoorAfwezigihijd { get; set; } = "";
        public string VerwachteTijdVanAanwezighijd { get; set; } = "";
    }

    public class TReturnChangeAfwezighijdTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.ReturnChangeAfwezighijd; } }
        public bool success { get; set; } = false;
    }


    //scan
    public class TNFCCardScan : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.SendNFCCardScanInfo; } }
        public string ID { get; set; }
    }

    public class TReturnDisplayInfoForJustReadNFCCard : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.ReturnInfoAboutUserFromJustReadNFCCard; } }
        public bool doetUitteken { get; set; } = false;
        public bool doetInteken { get; set; } = false;
        public bool doetAnuleerUitteken { get; set; } = false;
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public TimeSpan tijdInteken { get; set; }
        public TimeSpan tijdUiteken { get; set; }
        public DateTime dateOfToday { get; set; }
        public int ID { get; set; }
        public string NFCID { get; set; }
        public DateTime DateTimeNow { get; set; }
    }

    //overview
    public class TRequestOverviewOfAanwezige : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.RequestOverviewAanwezige; } }
    }

    public class TReturnOverviewOfAanwezige : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.ReturnOverviewAanwezige; } }
        public List<SQLPropertysAndFunc.RegistratieTableTableEntry> todayRegData { get; set; }
        public List<SQLPropertysAndFunc.UserTableTableEntry> users { get; set; }
        public List<SQLPropertysAndFunc.AfwezigTableTableEntry> todayAfwezig { get; set; }
        public DateTime dateTimeNow { get; set; }
    }


}
