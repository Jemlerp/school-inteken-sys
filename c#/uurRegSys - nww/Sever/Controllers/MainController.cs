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
            //return JsonConvert.SerializeObject(functions.GetSqlServerDateTime());
            //return JsonConvert.SerializeObject(new funcZ.TReturnError());
            //TNFCCardScan test = new TNFCCardScan();
            //test.ID="251 227 234 245";
            return serialise(functions.overzigt());
        }

        private static string serialise(object toSerialise)
        {
            TResiveWithPosbleError retu = new TResiveWithPosbleError();
            retu.isErrorOcured=false;
            retu.expectedResponse=toSerialise;
            return JsonConvert.SerializeObject(retu);
        }

        private static string serialise(TError toSerialise) {
            TResiveWithPosbleError retu = new TResiveWithPosbleError();
            retu.isErrorOcured=true;
            retu.errorInfo=toSerialise;
            return JsonConvert.SerializeObject(retu);
        }

        private static T deserialise<T>(string toDeserialise)
        {
            return JsonConvert.DeserializeObject<T>(toDeserialise);
        }

        [HttpPost]
        public string Post(TSendWithPassword instruction)
        {
            try
            {
                if (instruction.password == TestServerPassword.testWAchtwooed)
                {
                    JObject getEnumFromObjectInInstruction = JObject.Parse(JsonConvert.SerializeObject(instruction.tSend));
                    string instructionArgumentsInJson = JsonConvert.SerializeObject(instruction.tSend);
                    switch ((SendAndRecieveTypesEnum)Enum.Parse(typeof(SendAndRecieveTypesEnum), (string)getEnumFromObjectInInstruction["SendAndRecieveTypesEnumValue"]))
                    {
                        case SendAndRecieveTypesEnum.SendNFCCardScanInfo:
                            return serialise(functions.NFCScan(deserialise<TNFCCardScan>(instructionArgumentsInJson)));
                        case SendAndRecieveTypesEnum.RequestOverviewAanwezige:
                            return serialise(functions.overzigt());
                        case SendAndRecieveTypesEnum.SendChangeAfwezigHijd:
                            return serialise(functions.changeAfwezighijdVoorEenIemand(deserialise<TRequestChangeAfwezigTable>(instructionArgumentsInJson)));
                            
                    }
                    throw new Exception("No Instruction");                    
                }
                else
                {
                    throw new Exception("Bad Password");
                }
            }
            catch (Exception ex)
            {
                TError ret = new TError();
                ret.errorText=ex.Message;
                return serialise(ret);
            }
        }
    }

}
