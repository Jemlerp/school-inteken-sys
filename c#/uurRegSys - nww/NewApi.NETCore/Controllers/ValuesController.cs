using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewCrossFunctions.NETCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NewApi.NETCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        [HttpGet]
        public NetComObjects.ServerResponse tieME()
        {
            NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            toReturn.Response = FuncsVController.GetDateTimeFromSqlDatabase();
            return toReturn;
        }

        private T Deserialise<T>(string _toDeserialie)
        {
            return JsonConvert.DeserializeObject<T>(_toDeserialie);
        }

        private string Serilalise(object _toSerialise)
        {
            return JsonConvert.SerializeObject(_toSerialise);
        }

        private DatabaseObjects.AcountTableEntry GetUser(string _username, string _password)
        {
            return default(DatabaseObjects.AcountTableEntry);
        }
    
        [HttpPost]
        public NetComObjects.ServerResponse tokidokiaru([FromBody]NetComObjects.ServerRequest _request)
        {
            NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            toReturn.IsErrorOccurred = false;
            try
            {
                DatabaseObjects.AcountTableEntry usingUser = GetUser(_request.UserName, _request.Password);
                string param = Serilalise(_request.Request);
                JObject baylife = JObject.Parse(param);
                switch ((NetComObjects.WhatIsThisEnum)Enum.Parse(typeof(NetComObjects.WhatIsThisEnum), (string)baylife["WatIsDit"]))
                {
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
                }
                return toReturn;
                throw new Exception("ahodashi");
            }
            catch (Exception ex)
            {
                toReturn.IsErrorOccurred = true;
                toReturn.ErrorInfo.ErrorMessage = ex.Message;
                return toReturn;
            }
        }

    }

}
