using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NewCrossFunctions;
using System.Data.SqlClient;

namespace NewApi.Models {
    public class IntekenSysFunctions {

        public static DatabaseTypesAndFunctions _DatabaseTypesAndFunctions = new DatabaseTypesAndFunctions();
         

        public static DateTime GetDateTimeFromSqlDatabase() {
            return (DateTime)SqlDingusEnUserRechten.SQLQuery("select getdate() ji").Rows[0]["ji"];
        }
         
        //inteken
        public static NetComunicationTypesAndFunctions.ServerResponseInteken inteken(DatabaseTypesAndFunctions.AcountTableEntry _MasterRightsEntry, NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit _Request) {
            NetComunicationTypesAndFunctions.ServerResponseInteken toReturn = new NetComunicationTypesAndFunctions.ServerResponseInteken();
            DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry userInfo = new DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry();
            SqlCommand command;
            //get user id
            command=new SqlCommand();
            command.Parameters.AddWithValue("@nfcode", _Request.NFCCode);
            command.CommandText=$"select * from {DatabaseTypesAndFunctions.UserTableNames.UserTableName} where {DatabaseTypesAndFunctions.UserTableNames.NFCID} = @nfcode";
            List<DatabaseTypesAndFunctions.UserTableTableEntry> foundUsersList =_DatabaseTypesAndFunctions.GetListUserTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(command));
            if(foundUsersList.Count > 0) {
                userInfo.userN=foundUsersList[0];
            } else {
                throw new Exception("nfc card unknown");
            }
            //update regEntry(niet meer laat als inteken....etc?) or create one  
            command=new SqlCommand();
            command.Parameters.AddWithValue("@userid", userInfo.userN.ID);
            command.CommandText=$"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> foundRegistratieEntrys = _DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(command));
            DatabaseTypesAndFunctions.RegistratieTableTableEntry deEntry;
            command=new SqlCommand();
            if (foundRegistratieEntrys.Count >0) {
                // edit
                deEntry = foundRegistratieEntrys[0];
                deEntry.IsLaat=false;
                deEntry.Verwachtetijdvanaanwezighijd="";
                command.Parameters.AddWithValue("@id", deEntry.ID);
                if (deEntry.HeeftIngetekend) {
                    if (deEntry.IsAanwezig) {
                        //update teken uit
                        toReturn.uitgetekened=true;
                        command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken} = cast(getdate() as time), {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 0 where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
                    } else {
                        //update anuleer uitteken
                        toReturn.uitekenengeanuleerd=true;
                        command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 1 where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
                    }
                } else {
                    //update inteken
                    toReturn.ingetekened=true;
                    command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken} = cast(getdate() as time), {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 1 where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
                }
            } else {
                //new
                //inteken
                command.Parameters.AddWithValue("@relatedUserId", foundUsersList[0].ID);
                toReturn.ingetekened=true;
                command.CommandText=$"insert into {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} ({DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated},{DatabaseTypesAndFunctions.RegistratieTableNames.Date},{DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken},{DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend},{DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig},{DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek},{DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof},{DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof},{DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie},{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat},{DatabaseTypesAndFunctions.RegistratieTableNames.IsAndereReden},{DatabaseTypesAndFunctions.RegistratieTableNames.AnderenRedenVoorAfwezighijd},{DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values (@relatedUserId, cast(getdate() as date), cast(getdate() as time), 1,1,0,0,0,0,0,0,'','')";
            }
            SqlDingusEnUserRechten.SQLNonQuery(command);
            command=new SqlCommand();
            command.Parameters.AddWithValue("@userid", userInfo.userN.ID);
            command.CommandText=$"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> endResult = _DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(command));
            toReturn.TheUserWithEntryInfo.userN=foundUsersList[0];
            toReturn.TheUserWithEntryInfo.hasTodayRegEntry=true;
            toReturn.TheUserWithEntryInfo.regE=endResult[0];
            return toReturn;
        }

        //overview
        public static NetComunicationTypesAndFunctions.ServerResponseUsersOverzightFromOneDate overzight(DatabaseTypesAndFunctions.AcountTableEntry _MasterRightsEntry, NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate _Request) {
            NetComunicationTypesAndFunctions.ServerResponseUsersOverzightFromOneDate toReturn = new NetComunicationTypesAndFunctions.ServerResponseUsersOverzightFromOneDate();
            SqlCommand command = new SqlCommand();
            if (_Request.useToday) {
                command.CommandText=$"select * from";
            }
            List<DatabaseTypesAndFunctions.UserTableTableEntry> UserEntrys = _DatabaseTypesAndFunctions.GetListUserTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery($"select * from {DatabaseTypesAndFunctions.UserTableNames.UserTableName}"));
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> RegEntrys = _DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery($"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)"));
            
            //pak alle mensen die niet verschoold zijn 
            foreach(var User in UserEntrys) {
                if (User.IsActiveUser) {
                    DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry toPutInList = new DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry();
                    toPutInList.userN=User;
                    foreach(var Entry in RegEntrys) {
                        if(Entry.IDOfUserRelated ==User.ID) {
                            toPutInList.hasTodayRegEntry=true;
                            toPutInList.regE=Entry;
                            break;
                        }
                    }
                    toReturn.EtList.Add(toPutInList);
                }
            } 
            return toReturn;
        }

        //update reg table
        public static NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable ChangeRegistatieTable(DatabaseTypesAndFunctions.AcountTableEntry _MasterRightsEntry, NetComunicationTypesAndFunctions.ServerRequestChangeRegistratieTable _Request) {
            NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable toReturn = new NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable();
            SqlCommand commamd = new SqlCommand();            
            commamd.Parameters.AddWithValue("@andered", _Request.deEntry.AnderenRedenVoorAfwezigihijd);
            commamd.Parameters.AddWithValue("@verwachtetijdvana", _Request.deEntry.Verwachtetijdvanaanwezighijd);
            if (_Request.isNieuwEntry) {
                commamd.CommandText=$"insert into {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} ({DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated}, {DatabaseTypesAndFunctions.RegistratieTableNames.Date}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie},{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsAndereReden}, {DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ({_Request.deEntry.IDOfUserRelated}, cast('{_Request.deEntry.Date}' as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit), cast('{_Request.deEntry.IsZiek}' as bit),cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit), cast('{_Request.deEntry.IsExcurtie}' as bit), cast('{_Request.deEntry.IsLaat}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit),@andered,@verwachtetijdvana)";
            } else {
                commamd.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = {_Request.deEntry.IDOfUserRelated}, {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast('{_Request.deEntry.Date}' as date), {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken} = cast('{_Request.deEntry.TimeInteken}' as time), {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken} = cast('{_Request.deEntry.TimeUitteken}' as time), {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend} = cast('{_Request.deEntry.HeeftIngetekend}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek} = cast('{_Request.deEntry.IsZiek}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof} = cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof} = cast('{_Request.deEntry.IsStudieverlof}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie} = cast('{_Request.deEntry.IsExcurtie}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat} = cast('{_Request.deEntry.IsLaat}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.AnderenRedenVoorAfwezighijd} = @andered, {DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd} = @verwachtetijdvana where {DatabaseTypesAndFunctions.RegistratieTableNames.ID} = {_Request.deEntry.ID}";
            }
            return toReturn;
        }
    }
}