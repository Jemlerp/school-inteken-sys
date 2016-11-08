using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using funcZ;
using Sever.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Sever.Controllers {
    public class MainController : ApiController {

        /*
        [HttpGet]
        public string leave() {
            funcZ.TSendNewIDRead neb = new TSendNewIDRead();
            return "ServerTime = " + muh.getSqlServerDateTime().ToString();
            }
            */

        [HttpGet]
        public string test() {
            return muh.getSqlServerDateTime().ToString();
            }

        [HttpPost]
        public string Post(TWrapWithPassword _inObject) {
            if (_inObject.password == funcZ.TEST.testwachtwoord) {
                try {
                    JObject obj = JObject.Parse(JsonConvert.SerializeObject(_inObject.tSend));
                    switch ((string)obj["ThisType"]) {
                        case "TSendnewIdRead":
                            return muh.nfc_scan(_inObject.tSend);
                        case "TAskCurrentStateForDisplay":
                            return muh.nuInfoEzOverzigt(_inObject);
                        }
                    
                    } catch (Exception ex) {
                    string test = ex.Message;
                    TReturnError retu = new TReturnError();
                    retu.waarom = "ぜんぶ壊れた";
                    return JsonConvert.SerializeObject(retu);
                    }
                } else {
                TReturnError retu = new TReturnError();
                retu.waarom = "Post: " + "アクセス きょひされました";
                return JsonConvert.SerializeObject(retu);
                }
            return "";
            }
        }
    }
