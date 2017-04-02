using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewCrossFunctions.NETCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NewApi.NETCore.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {

        [HttpGet]
        public string tieYOU(string inpout) {
            //NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            //toReturn.Response = FuncsVController.GetDateTimeFromSqlDatabase();

            DatabaseObjects.AcountTableEntry sysUser = new DatabaseObjects.AcountTableEntry();

            NetComObjects.ServerRequestOverzightFromOneDate request = new NetComObjects.ServerRequestOverzightFromOneDate();
            request.useToday = true;
            request.alsoReturnExUsers = false;

            NetComObjects.ServerResponseOverzightFromOneDate resp = FuncsVController.overzight(sysUser, request);

            DateTime lkNu = FuncsVController.GetDateTimeFromSqlDatabase();

            List<string> DaiNiBan = new List<string>();

            //List<string> DaiSanBan = new List<string>();
            // foreach (var x in resp.EtList) {
            //     DaiNiBan.Add(x.UsE.VoorNaam + " # " + x.UsE.AchterNaam);
            // }

            string DaiIkan = lkNu.ToString() + "\r\n \n";

            foreach (var x in resp.EtList) {
                string toAdd = "";
                toAdd = x.UsE.VoorNaam + "  " + x.UsE.AchterNaam;
                if (x.hasTodayRegEntry) {
                    if (x.RegE.HeeftIngetekend) {
                        toAdd += "   In:" + x.RegE.TimeInteken.ToString("hh\\:mm\\:ss");                        
                        if (x.RegE.IsAanwezig) {
                            toAdd += "   Uit:Aanwezig   Totaal:" + lkNu.Subtract(x.RegE.TimeInteken).ToString("hh\\:mm\\:ss\\.fff");
                        } else {
                            toAdd += $"   Uit:{x.RegE.TimeUitteken.ToString("hh\\:mm\\:ss")}   Totaal:" + x.RegE.TimeUitteken.Subtract(x.RegE.TimeInteken).ToString("hh\\:mm\\:ss\\.fff");
                        }
                    }
                }
                DaiNiBan.Add(toAdd + "\r\n \n");
            }

            foreach(var x in DaiNiBan.OrderBy(x => x.Length)) {
                DaiIkan += x;
            }

            return DaiIkan;

            //toReturn.Response = DaiIkan;

            //return toReturn;
        }

        private T Deserialise<T>(string _toDeserialie) {
            return JsonConvert.DeserializeObject<T>(_toDeserialie);
        }

        private string Serilalise(object _toSerialise) {
            return JsonConvert.SerializeObject(_toSerialise);
        }

        private DatabaseObjects.AcountTableEntry GetUser(string _username, string _password) {
            return default(DatabaseObjects.AcountTableEntry);
        }

        [HttpPost]
        public NetComObjects.ServerResponse tokidokiaru([FromBody]NetComObjects.ServerRequest _request) {
            NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            toReturn.IsErrorOccurred = false;
            try {
                DatabaseObjects.AcountTableEntry usingUser = GetUser(_request.UserName, _request.Password);
                string param = Serilalise(_request.Request);
                JObject baylife = JObject.Parse(param);
                switch ((NetComObjects.WhatIsThisEnum)Enum.Parse(typeof(NetComObjects.WhatIsThisEnum), (string)baylife["WatIsDit"])) {
                    case NetComObjects.WhatIsThisEnum.RSqlServerDateTime:
                        toReturn.Response = FuncsVController.GetDateTimeFromSqlDatabase();
                        break;
                    case NetComObjects.WhatIsThisEnum.RInteken:
                        toReturn.Response = FuncsVController.inteken(usingUser, Deserialise<NetComObjects.ServerRequestTekenInOfUit>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.ROneDateRegiOverzight:
                        toReturn.Response = FuncsVController.overzight(usingUser, Deserialise<NetComObjects.ServerRequestOverzightFromOneDate>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.RChangeRegTable:
                        toReturn.Response = FuncsVController.ChangeRegistatieTable(usingUser, Deserialise<NetComObjects.ServerRequestChangeRegistratieTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.RMultiDateRegiOverzight:
                        toReturn.Response = FuncsVController.alleDagOverzightenVanTussenTweDatums(usingUser, Deserialise<NetComObjects.ServerRequestOverzightFromMultipleDates>(param));
                        break;
                        //newr
                    case NetComObjects.WhatIsThisEnum.GetUserTable:
                        toReturn.Response = FuncsVController.GetUserTable(usingUser, Deserialise<NetComObjects.ServerRequestGetUserTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.ChangeUserTable:
                        toReturn.Response = FuncsVController.ChangeUserTable(usingUser, Deserialise<NetComObjects.ServerRequestChangeUserTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.GetModTable:
                        toReturn.Response = FuncsVController.GetModtable(usingUser, Deserialise<NetComObjects.ServerRequestGetModTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.ChangeModTable:
                        toReturn.Response = FuncsVController.ChangeModtable(usingUser, Deserialise<NetComObjects.ServerRequestChangeModTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.GetAcountsTable:
                        toReturn.Response = FuncsVController.GetAcountTable(usingUser, Deserialise<NetComObjects.ServerRequestGetAcountsTable>(param));
                        break;
                    case NetComObjects.WhatIsThisEnum.ChangeAcountTable:
                        toReturn.Response = FuncsVController.ChangeAcountTable(usingUser, Deserialise<NetComObjects.ServerRequestChangeAcountTable>(param));
                        break;
                }
                return toReturn;
                throw new Exception("ahodashi");
            } catch (Exception ex) {
                toReturn.IsErrorOccurred = true;
                toReturn.ErrorInfo.ErrorMessage = ex.Message;
                return toReturn;
            }
        }

    }

}
