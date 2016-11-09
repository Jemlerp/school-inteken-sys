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

namespace Sever.Controllers
{
    public class MainController : ApiController
    {

        [HttpGet]
        public string test()
        {
            return JsonConvert.SerializeObject(functions.GetSqlServerDateTime());
            //return JsonConvert.SerializeObject(new funcZ.TReturnError());
        }


        private static string serialise(object toSerialise)
        {
            return JsonConvert.SerializeObject(toSerialise);
        }

        private static T deserialise<T>(string toDeserialise)
        {
            return JsonConvert.DeserializeObject<T>(toDeserialise);
        }

        [HttpPost]
        public string Post(TWrapWithPassword instruction)
        {
            try
            {
                if (instruction.password == funcZ.TESTwachtwoord.testwachtwoord)
                {
                    JObject getEnumFromObjectInInstruction = JObject.Parse(JsonConvert.SerializeObject(instruction.tSend));
                    string instructionArgumentsInJson = JsonConvert.SerializeObject(instruction.tSend);
                    switch ((SendAndRecieveTypesEnum)Enum.Parse(typeof(SendAndRecieveTypesEnum), (string)getEnumFromObjectInInstruction["SendAndRecieveTypesEnumValue"]))
                    {
                        case SendAndRecieveTypesEnum.NFCCardScanInfo:
                            return serialise(functionsThatHaveToDoWithDataBase.nfc_scan(deserialise<TNFCCardScan>(instructionArgumentsInJson)));
                        case SendAndRecieveTypesEnum.errorReport:
                            break;

                    }
                    throw new Exception("No Instruction");
                    
                }
                else
                {
                    TReturnError ret = new TReturnError();
                    ret.errorText = "Bad Password";
                    return JsonConvert.SerializeObject(ret); 
                }
            }
            catch (Exception ex)
            {
                TReturnError ret = new TReturnError();
                ret.errorText = "(IN POST) " + ex.Message;
                return JsonConvert.SerializeObject(ret);
            }
        }
    }

}
