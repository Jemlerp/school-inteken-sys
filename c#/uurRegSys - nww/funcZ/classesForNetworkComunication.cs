using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcZ
{

    public interface IKnow
    {
        SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get; }
    }

    public enum SendAndRecieveTypesEnum
    {
        metWachtwoord,
        errorReport,
        vraagUurOverzichtVanEenPersoon,
        returnUurOverzichtVanEenPersoon,
        NFCCardScanInfo,
        returnInfoAboutUserFromJustReadNFCCard,
        vraagAanwezighijdsOverzichtVanVandaag,
        returnAanwezighijdsOverZichtVanVandaag,
    };

    //alles word verstuurd met dit
    public class TWrapWithPassword : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.metWachtwoord; } }
        public string password { get; set; }
        public object tSend { get; set; }
    }

    //kijk altijd uit voor deze
    public class TReturnError : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.errorReport; } }
        public string errorText { get; set; }
    }

    //niet af
    public class TAskUurOverzightVanEenPersoon : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.vraagUurOverzichtVanEenPersoon; } }
        public DateTime dezedag { get; set; }
        public DateTime totenmetdeze { get; set; }
        public int UserIdVanWieTeMaaken { get; set; }

        public int dagenSchoolGeweestTussenDeTweeDateTime { get; set; } // dit of auto
        //als ik er tijd voor over heb
        public bool shouldDetectIfSchoolDay { get; set; } = false;
        public int aantalMensenDieOpSchoolMoetenKomenVoordatHetGeteltWordtAlsEenSchoolDag { get; set; } = 5;
    }

    //niet af
    public class TReturnUurOverzichtVanEenPersoon : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.returnUurOverzichtVanEenPersoon; } }
        public List<DateTime> dagenWaarUserZiekWas { get; set; }
        public List<DateTime> dagenFelxiebleVerlof { get; set; }
        public int uurenGekrijgenVanOverigeRedenen { get; set; } = 0;
        public int minutenGekrijgenVanOverigeRedenen { get; set; } = 0;
        public List<DateTime> dagenMinderDan4UurGemaakt { get; set; } // date-time. date is de dag waneer en time is hoeveel uuren hij die dag heeft ( nog niet )
        public List<DateTime> dagenNietInOfUitGetekend { get; set; } // time is hoelaat de scan van die dag was ( nog niet )
        public List<DateTime> dagenNietOpkomenDagen { get; set; }
        public int efectiefTotaalaantalUuren { get; set; } = 0;
        public int efectiefTotaalaantalminuten { get; set; } = 0;
        public int efectiefTotaalaantalseconden { get; set; } = 0;
    }

    public class TNFCCardScan : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.NFCCardScanInfo; } }
        public string ID { get; set; }
    }

    public class TReturnDisplayInfoForJustReadNFCCard : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.returnInfoAboutUserFromJustReadNFCCard; } }
        public bool isAanwezig { get; set; }
        public string voorNaam { get; set; }
        public string achterNaam { get; set; }
        public string nfCode { get; set; }
        public int ID { get; set; }
        public int uurVandaagOpSchool { get; set; }
        public int minutenVandaagOpSchool { get; set; }
        public DateTime tijdinofuitgetekend { get; set; }
    }

    public class TAskAanwezigheidsOverzigtVanVandaag : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.vraagAanwezighijdsOverzichtVanVandaag; } }
    }

    public class TReturnAanwezigheidsOverzigtVanVandaag : IKnow
    {
        public SendAndRecieveTypesEnum SendAndRecieveTypesEnumValue { get { return SendAndRecieveTypesEnum.returnAanwezighijdsOverZichtVanVandaag; } }
        public List<TInfoOverEenPersoon> iedereen { get; set; }
    }

    public class TInfoOverEenPersoon
    {
        public int userId { get; set; }

        public string naam { get; set; }
        public string achternaam { get; set; }

        public DateTime inteken { get; set; }
        public DateTime uittenken { get; set; }
        public bool erisinteken { get; set; } = false;
        public bool erisuitteken { get; set; } = false;

        public bool isAanwegiz { get; set; } = false;

        public int uutotopschoolgeweest { get; set; }
        public int minutetotaalopschoolgeweest { get; set; }
        public int secondetotaalopschoolgeweest { get; set; }
    }
}
