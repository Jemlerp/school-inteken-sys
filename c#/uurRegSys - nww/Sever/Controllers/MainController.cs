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

        /*
        [HttpGet]
        public string leave() {
            funcZ.TSendNewIDRead neb = new TSendNewIDRead();
            return "ServerTime = " + muh.getSqlServerDateTime().ToString();
            }
            */

        [HttpGet]
        public string test()
        {
            return JsonConvert.SerializeObject(new funcZ.TReturnError());
        }



        [HttpPost]
        public string Post(TWrapWithPassword instruction)
        {
            try
            {
                if (instruction.password == funcZ.TESTwachtwoord.testwachtwoord)
                {
                    /*
                    JObject identifyInstruction = JObject.Parse(JsonConvert.SerializeObject(instruction.tSend));                    
                    switch ((SendAndRecieveTypesEnum)Convert.ToInt32((string)identifyInstruction["SendAndRecieveTypesEnumValue"])){
                        case SendAndRecieveTypesEnum.NFCCardScanInfo:
                        */
                    switch (instruction.SendAndRecieveTypesEnumValue)
                    {
                        case SendAndRecieveTypesEnum.NFCCardScanInfo:
                            return functionsThatHaveToDoWithDataBase.nfc_scan(instruction.tSend);

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

        /*
[HttpPost]
public string Post(TWrapWithPassword _inObject)
{
    if (_inObject.password == funcZ.TESTwachtwoord.testwachtwoord)
    {
        try
        {
            JObject obj = JObject.Parse(JsonConvert.SerializeObject(_inObject.tSend));
            switch ((string)obj["ThisType"])
            {
                case "TSendnewIdRead":
                    return muh.nfc_scan(_inObject.tSend);
                case "TAskCurrentStateForDisplay":
                    return muh.nuInfoEzOverzigt(_inObject);
            }

        }
        catch (Exception ex)
        {
            string test = ex.Message;
            TReturnError retu = new TReturnError();
            retu.errorText = "ぜんぶ壊れた";
            return JsonConvert.SerializeObject(retu);
        }
    }
    else
    {
        TReturnError retu = new TReturnError();
        retu.errorText = "Post: " + "アクセス きょひされました";
        return JsonConvert.SerializeObject(retu);
    }
    return "";
}
*/
    }

}
