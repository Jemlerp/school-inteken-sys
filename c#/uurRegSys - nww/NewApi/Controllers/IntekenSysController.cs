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
using System.Data;

namespace NewApi.Controllers {
    public class IntekenSysController : ApiController {

        static DatabaseTypesAndFunctions _DatabaseTypesAndFunctions = new DatabaseTypesAndFunctions();

        [HttpGet]
        public NetComunicationTypesAndFunctions.ServerResponse Indax() {
            return returnMetStr(IntekenSysFunctions.GetDateTimeFromSqlDatabase());
        }

        private T Deserialise<T>(string todeserialie) {
            return JsonConvert.DeserializeObject<T>(todeserialie);
        }

        private string Serilalise(object toSerialise) {
            return JsonConvert.SerializeObject(toSerialise);
        }

        private NetComunicationTypesAndFunctions.ServerResponse returnMetStr(object returnObject) {
            NetComunicationTypesAndFunctions.ServerResponse toReturn = new NetComunicationTypesAndFunctions.ServerResponse();
            toReturn.Response=returnObject;
            return toReturn;
        }

        public static DataTable webGetOverzicht() {
            return webGetOverzicht(false, "", "", true, new DateTime());
        }

        public static DataTable webGetOverzicht(bool _metPw, string _username, string _password, bool _IsDateToday, DateTime _DateToLoadFor) {
            List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry> erList = new List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry>();
            if (_metPw) { //  list active users, sort with reg entry && !_isDateToday? also list regentrys en sort with (inactive) users
                //DatabaseTypesAndFunctions.AcountTableEntry MasterRightsEntry = getUserRights(_username, _password);
                //if(MasterRightsEntry.)

            } else { // list active users, sort with reg entry      
                SqlCommand _command = new SqlCommand();
                _command.CommandText=$"select * from {DatabaseTypesAndFunctions.UserTableNames.UserTableName}";
                _command.CommandText+=$" where {DatabaseTypesAndFunctions.UserTableNames.IsActiveUser} = 1";
                List<DatabaseTypesAndFunctions.UserTableTableEntry> _userEntrys = _DatabaseTypesAndFunctions.GetListUserTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
                List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> _regEntrys = new List<DatabaseTypesAndFunctions.RegistratieTableTableEntry>();
                _command=new SqlCommand();
                _command.CommandText=$"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.Date}";
                _command.CommandText+=" = cast(getdate() as date)";
                _regEntrys=_DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
                foreach (var User in _userEntrys) {
                    if (User.IsActiveUser) {
                        DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry toPutInList = new DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry();
                        toPutInList.userN=User;
                        foreach (var Entry in _regEntrys) {
                            if (Entry.IDOfUserRelated==User.ID) {
                                toPutInList.hasTodayRegEntry=true;
                                toPutInList.regE=Entry;
                                break;
                            }
                        }
                        erList.Add(toPutInList);
                    }
                }                
            }
            return ForFormHelperFunctions.UserInfoListToDataTableForDataGridDisplay(erList, IntekenSysFunctions.GetDateTimeFromSqlDatabase());
        }

        private DatabaseTypesAndFunctions.AcountTableEntry getUserRights(string _username, string _password) {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@username", _username);
            command.Parameters.AddWithValue("@password", _password);
            command.CommandText=$"select * from {DatabaseTypesAndFunctions.AcountsTableNames.AcountsTableName} where {DatabaseTypesAndFunctions.AcountsTableNames.inlogNaam} = @username and {DatabaseTypesAndFunctions.AcountsTableNames.inlogWachtwoord} = @password";
            List<DatabaseTypesAndFunctions.AcountTableEntry> verifyMaster = _DatabaseTypesAndFunctions.GetListAcountTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(command));
            if (!(verifyMaster.Count>0)) {
                throw new Exception("Incorrect Username/Password");
            }
            return verifyMaster[0];
        }

        [HttpPost]
        public NetComunicationTypesAndFunctions.ServerResponse doHetDan(NetComunicationTypesAndFunctions.ServerRequest request) {
            try {
                DatabaseTypesAndFunctions.AcountTableEntry MasterRightsEntry = getUserRights(request.UserName, request.Password);
                JObject baylife = JObject.Parse(Serilalise(request.Request)); //nandakke>
                string instructions = Serilalise(request.Request);
                switch ((NetComunicationTypesAndFunctions.WhatIsThisEnum)Enum.Parse(typeof(NetComunicationTypesAndFunctions.WhatIsThisEnum), (string)baylife["WatIsDit"])) {
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
            } catch (Exception ex) {
                NetComunicationTypesAndFunctions.ServerResponse toReturn = new NetComunicationTypesAndFunctions.ServerResponse();
                toReturn.IsErrorOcurred=true;
                toReturn.ErrorInfo.ErrorMessage=ex.Message;
                return toReturn;
            }
        }
    }
}