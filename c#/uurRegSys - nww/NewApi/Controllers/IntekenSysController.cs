using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using NewCrossFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewApi.Models;
using System.Data.SqlClient;

namespace NewApi.Controllers
{
    public class IntekenSysController : ApiController
    {//jaja client krijgt json sting in een json......

        DatabaseTypesAndFunctions _DatabaseTypesAndFunctions = new DatabaseTypesAndFunctions();

        [HttpGet]
        public string Indax()
        {
            return Serilalise(IntekenSysFunctions.GetDateTimeFromSqlDatabase());
        }

        private T Deserialise<T>(string todeserialie) {
            return JsonConvert.DeserializeObject<T>(todeserialie);
        }

        private string Serilalise(object toSerialise) {
            return JsonConvert.SerializeObject(toSerialise);
        }

        private string returnMetStr(object returnObject) {
            NetComunicationTypesAndFunctions.ServerResponse toReturn = new NetComunicationTypesAndFunctions.ServerResponse();
            toReturn.Response=returnObject;
            return Serilalise(toReturn);
        }

        [HttpPost]
        public string doHetDan(NetComunicationTypesAndFunctions.ServerRequest request) {
            try {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@username", request.UserName);
                command.Parameters.AddWithValue("@password", request.Password);
                command.CommandText=$"select * from {DatabaseTypesAndFunctions.AcountsTableNames.AcountsTableName} where {DatabaseTypesAndFunctions.AcountsTableNames.inlogNaam} = @username and {DatabaseTypesAndFunctions.AcountsTableNames.inlogWachtwoord} = @password";
                List<DatabaseTypesAndFunctions.AcountTableEntry> verifyMaster = _DatabaseTypesAndFunctions.GetListAcountTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(command));
                if(!(verifyMaster.Count>0)) {
                    throw new Exception("Incorrect Username/Password");
                }

                DatabaseTypesAndFunctions.AcountTableEntry MasterRightsEntry = verifyMaster[0];
                JObject baylife = JObject.Parse(Serilalise(request.Request)); //nandake>
                string instructions = Serilalise(request.Request);
                
                switch((NetComunicationTypesAndFunctions.WhatIsThisEnum)Enum.Parse(typeof(NetComunicationTypesAndFunctions.WhatIsThisEnum), (string)baylife["WatIsDit"])) {
                    case NetComunicationTypesAndFunctions.WhatIsThisEnum.RSqlServerDateTime:
                        return returnMetStr(IntekenSysFunctions.GetDateTimeFromSqlDatabase());
                    case NetComunicationTypesAndFunctions.WhatIsThisEnum.RInteken:
                        return returnMetStr(IntekenSysFunctions.inteken(MasterRightsEntry, Deserialise<NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit>(instructions)));
                    case NetComunicationTypesAndFunctions.WhatIsThisEnum.ROneDateRegiOverzight:
                        return returnMetStr(IntekenSysFunctions.overzight(MasterRightsEntry, Deserialise<NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate>(instructions)));
                    case NetComunicationTypesAndFunctions.WhatIsThisEnum.RChangeRegTable:
                        return returnMetStr(IntekenSysFunctions.ChangeRegistatieTable(MasterRightsEntry, Deserialise<NetComunicationTypesAndFunctions.ServerRequestChangeRegistratieTable>(instructions)));   
                }
                throw new Exception("no instruction");
            } catch(Exception ex) {
                NetComunicationTypesAndFunctions.ServerResponse toReturn = new NetComunicationTypesAndFunctions.ServerResponse();
                toReturn.IsErrorOcurred=true;
                toReturn.ErrorInfo.ErrorMessage=ex.Message;
                return Serilalise(toReturn);
            }            
        }
    }
}