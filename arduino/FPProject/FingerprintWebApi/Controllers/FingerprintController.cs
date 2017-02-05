using System;
using System.Web.Http;
using Newtonsoft.Json;
using FFunc.WebSendAndReturnTypes;
using Newtonsoft.Json.Linq;
using FingerprintWebApi.Models;


namespace FingerprintWebApi.Controllers {
    public class FingerprintController : ApiController {
        [HttpGet]
        public string Test() {
            TypeReturnSqlConnection reps = JsonConvert.DeserializeObject<TypeReturnSqlConnection>(muhCode.testSQLConnection());
            return "Server Time = " + DateTime.Now.ToString("h:mm:ss tt") + " | Sql connection = " + reps.canMakeConnectionToSqlServer;
        }

        [HttpPost]
        public string Post(TypeSendObjectWithPassword _inObject) {
            try {

                if (_inObject.password == settings.passwordToAccesThisServer) {
                    try {
                        JObject obj = JObject.Parse(JsonConvert.SerializeObject(_inObject.typeWithOpdra));//Baylife 
                        switch ((string)obj["ThisType"]) {
                            case "TypeAskDBEntry":
                                return muhCode.getDataFromDB(_inObject.typeWithOpdra); //werkt
                            case "TypeSendDBUpdate":
                                return muhCode.editDataFromDB(_inObject.typeWithOpdra); //werkt               
                            case "TypeSendNewDBEntry":
                                return muhCode.newEntryToDB(_inObject.typeWithOpdra); //werkt
                            case "typeForRequestingID":
                                return muhCode.wieIsDit(_inObject.typeWithOpdra); //werkt
                            case "typeForTestSqlConnection":
                                return muhCode.testSQLConnection();
                        }
                    } catch (Exception ex) {
                        TypeReturnError typeForError = new TypeReturnError();
                        typeForError.why = "(Post)" + ex.Message;
                        return JsonConvert.SerializeObject(typeForError);
                    }
                    TypeReturnError type5Error = new TypeReturnError();
                    type5Error.why = "(Post)" + "type not recognised "; 
                    return JsonConvert.SerializeObject(type5Error);
                }
                TypeReturnError type6Error = new TypeReturnError();
                type6Error.why = "(Post)" + "incorrectPassword";
                return JsonConvert.SerializeObject(type6Error);

            } catch (Exception ex) {
                TypeReturnError typeForError = new TypeReturnError();
                typeForError.why = "(Post)(transferError)" + ex.Message;
                return JsonConvert.SerializeObject(typeForError);
            }

        }

    }
}
