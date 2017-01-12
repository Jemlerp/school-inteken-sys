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
        /*
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
       }
       */

        [HttpGet]
        public NetComObjects.ServerResponse tieME()
        {
            NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            toReturn.Response = FuncsVController.GetDateTimeFromSqlDatabase();
            return toReturn;
        }

        [HttpGet("{id}")]
        public string kankerhoer(int id)
        {
            return id.ToString() + "  rsgngkjbhdsrilouhjgkloi ";
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
        public void Post([FromBody]string value)
        {

        }

        /*
        [HttpPost]
        public NetComObjects.ServerResponse tokidokiaru(string _BLINrequest)
        {
            int x = 8;
            NetComObjects.ServerRequest _request = new NetComObjects.ServerRequest();
            NetComObjects.ServerResponse toReturn = new NetComObjects.ServerResponse();
            try
            {
                DatabaseObjects.AcountTableEntry usingUser = GetUser(_request.UserName, _request.Password);
                string param = Serilalise(_request.Request);
                JObject baylife = JObject.Parse(param);
                switch ((NetComObjects.WhatIsThisEnum)Enum.Parse(typeof(NetComObjects.WhatIsThisEnum), (string)baylife["WatIsDit"]))
                {
                    case NetComObjects.WhatIsThisEnum.RSqlServerDateTime:
                        toReturn.Response = FuncsVController.GetDateTimeFromSqlDatabase();
                        return toReturn;
                    case NetComObjects.WhatIsThisEnum.RInteken:
                        toReturn.Response = FuncsVController.inteken(usingUser, Deserialise<NetComObjects.ServerRequestTekenInOfUit>(param));
                        return toReturn;
                    case NetComObjects.WhatIsThisEnum.ROneDateRegiOverzight:
                        toReturn.Response = FuncsVController.overzight(usingUser, Deserialise<NetComObjects.ServerRequestOverzightFromOneDate>(param));
                        return toReturn;
                    case NetComObjects.WhatIsThisEnum.RChangeRegTable:
                        toReturn.Response = FuncsVController.ChangeRegistatieTable(usingUser, Deserialise<NetComObjects.ServerRequestChangeRegistratieTable>(param));
                        return toReturn;
                }
                throw new Exception("ahodashi");
            }
            catch (Exception ex)
            {
                toReturn.IsErrorOcurred = true;
                toReturn.ErrorInfo.ErrorMessage = ex.Message;
                return toReturn;
            }
        }
        */

    }


}
