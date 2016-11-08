using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcZ {

    #region netz data types
    public interface IKnowType {
        string ThisType { get; }
    }

    //alles word verstuurd met dit
    public class TWrapWithPassword : IKnowType {
        public string ThisType { get { return "TWrapWithPassword"; } }
        public string password { get; set; }
        public object tSend { get; set; }
    }

    //kijk altijd uit voor deze
    public class TReturnError : IKnowType {
        public string ThisType { get { return "TReturnError"; } }
        public string waarom { get; set; }
    }

    public class TPing : IKnowType {
        public string ThisType { get { return "TPing"; } }
    }

    public class TPong : IKnowType {
        public string ThisType { get { return "TPong"; } }
        public string sqlConStats { get; set; }
    }

    public class TAskUurOverzight : IKnowType {
        public string ThisType { get { return "TAskUurOverzight"; } }
        public DateTime dezedag { get; set; }
        public DateTime totenmetdeze { get; set; }
        public int UserIdVanWieTeMaaken { get; set; }

        public int dagenSchoolGeweestTussenDeTweeDateTime { get; set; } // dit of auto
        //als ik er tijd voor over heb
        public bool shouldDetectIfSchoolDay{ get; set; } = false;
        public int aantalMensenDieOpSchoolMoetenKomenVoordatHetGeteltWordtAlsEenSchoolDag { get; set; } = 5;
    }

    public class TAskCurrentStateForDisplay : IKnowType {
        public string ThisType { get { return "TAskCurrentStateForDisplay"; } }
        }

    public class TReturnUurOverzight : IKnowType {
        public string ThisType { get { return "TReturnUurOverzight"; } }
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

    public class TSendNewIDRead : IKnowType {
        public string ThisType { get { return "TSendnewIdRead"; } }
        public string ID { get; set; }
    }

    public class TReturnInfoForDisplay : IKnowType {
        public string ThisType { get { return "TReturnInfoForDisplay"; } }
        public string testText { get; set; }
        public string errorText { get; set; }
        public bool error { get; set; }
        public bool isAanwezig { get; set; }
        public string voorNaam { get; set; }
        public string achterNaam { get; set; }
        public string nfCode { get; set; }
        public int ID { get; set; }
        public int uurVandaagOpSchool { get; set; }
        public int minutenVandaagOpSchool { get; set; }
        public DateTime tijdinofuitgetekend { get; set; }
    }

    public class TReturnCurrentStateForDisplay : IKnowType {
        public string ThisType { get { return "TReturnCurrentStateForDisplay"; } }
        public List<TsubPersonInfo> iedereen { get; set; }
        }

    #endregion

    public class TsubPersonInfo {
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
