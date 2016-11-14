using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcZ {

    public interface IKnow {
        SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get; }
    }

    public enum SendAndRecieveTypesEnum {
        metMogilikeError,
        metWachtwoord,
        errorReport,
        NFCCardScanInfo,
        returnInfoAboutUserFromJustReadNFCCard,
        requestOverviewAanwezige,
        returnOverviewAanwezige,
        testSeverConnetionRequest,
        testSeverConnetionAwnser,
        requestChangeAfwezigHijd,
        respondChangeAfwezighijd
    };

    public class TTestServerConnenction : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.testSeverConnetionRequest; } }
    }

    public class TRespondServerConnection : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.testSeverConnetionAwnser; } }
    }


    public class TResiveWithPosbleError : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.metMogilikeError; } }
        public TError errorInfo { get; set; }
        public bool isErrorOcured { get; set; } = false;
        public object expectedResponse { get; set; }
    }

    public class TSendWithPassword : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.metWachtwoord; } }
        public string password { get; set; }
        public object tSend { get; set; }
    }

    public class TError : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.errorReport; } }
        public string errorText { get; set; }
    }
    
    public class TRequestIfPasswordsAreCorrect {

    }

    public class TReturnIfPassordsAreCorrect {

    }

    public class TRequestChangeAfwezigTable:IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.requestChangeAfwezigHijd; } }
        public int fromUserID { get; set; }
        public bool clearRecordOfAfwezigVandaag { get; set; }
        public bool IsZiek { get; set; } = false;
        public bool IsFlexiebelverlof { get; set; } = false;
        public bool IsStudieverlof { get; set; } = false;
        public bool IsExcurtie { get; set; } = false;
        public string AnderenRedenVoorAfwezigihijd { get; set; }
    }

    public class TRespondChangeAfwezighijdTable : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.respondChangeAfwezighijd; } }
        public bool success { get; set; } = false;
    }


    //scan
    public class TNFCCardScan : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.NFCCardScanInfo; } }
        public string ID { get; set; }
    }

    public class TReturnDisplayInfoForJustReadNFCCard : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.returnInfoAboutUserFromJustReadNFCCard; } }
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
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.requestOverviewAanwezige; } }
    }

    public class TReturnOverviewOfAanwezige : IKnow {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.returnOverviewAanwezige; } }
        public List<SQLPropertysAndFunc.RegistratieTableTableEntry> todayRegData { get; set; }
        public List<SQLPropertysAndFunc.UserTableTableEntry> users { get; set; }
        public List<SQLPropertysAndFunc.AfwezighijdTableTableEntry> todayAfwezig { get; set; }
        public DateTime dateTimeNow { get; set; }
    }


}
