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
            NetComunicationTypesAndFunctions.ServerResponseInteken _toReturn = new NetComunicationTypesAndFunctions.ServerResponseInteken();
            SqlCommand _command;
            //get user id
            _command=new SqlCommand();
            _command.Parameters.AddWithValue("@nfcode", _Request.NFCCode);
            _command.CommandText=$"select * from {DatabaseTypesAndFunctions.UserTableNames.UserTableName} where {DatabaseTypesAndFunctions.UserTableNames.NFCID} = @nfcode";
            List<DatabaseTypesAndFunctions.UserTableTableEntry> foundUsersList = _DatabaseTypesAndFunctions.GetListUserTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
            if (foundUsersList.Count>0) {
                _toReturn.TheUserWithEntryInfo.UsE=foundUsersList[0];                
            } else {
                throw new Exception("nfc card unknown");
            }
            //update regEntry(niet meer laat als inteken....etc?) or create one  
            _command=new SqlCommand();
            _command.Parameters.AddWithValue("@userid", _toReturn.TheUserWithEntryInfo.UsE.ID);
            _command.CommandText=$"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> foundRegistratieEntrys = _DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
            DatabaseTypesAndFunctions.RegistratieTableTableEntry deEntry;
            _command=new SqlCommand();
            if (foundRegistratieEntrys.Count>0) {
                // edit
                deEntry=foundRegistratieEntrys[0];
                deEntry.IsLaat=false;
                deEntry.Verwachtetijdvanaanwezighijd=new TimeSpan();
                _command.Parameters.AddWithValue("@id", deEntry.ID);
                if (deEntry.HeeftIngetekend) {
                    if (deEntry.IsAanwezig) {
                        //update teken uit
                        _toReturn.uitgetekened=true;
                        _command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken} = cast(getdate() as time), {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 0 ,{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat} = 0 where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = {_toReturn.TheUserWithEntryInfo.UsE.ID}";
                    } else {
                        //update anuleer uitteken
                        _toReturn.uitekenengeanuleerd=true;
                        _command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 1, {DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat} = 0  where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = {_toReturn.TheUserWithEntryInfo.UsE.ID}";
                    }
                } else {
                    //update inteken
                    _toReturn.ingetekened=true;
                    _command.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend} = 1, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken} = cast(getdate() as time), {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig} = 1, {DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat} = 0  where {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = {_toReturn.TheUserWithEntryInfo.UsE.ID}";
                }
            } else {
                //new
                //inteken
                _command.Parameters.AddWithValue("@relatedUserId", foundUsersList[0].ID);
                _toReturn.ingetekened=true;
                _command.CommandText=$"insert into {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} ({DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated},{DatabaseTypesAndFunctions.RegistratieTableNames.Date},{DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken},{DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend},{DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig},{DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek},{DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof},{DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof},{DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie},{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat},{DatabaseTypesAndFunctions.RegistratieTableNames.Opmerking},{DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values (@relatedUserId, cast(getdate() as date), cast(getdate() as time), 1,1,0,0,0,0,0,'','')";
            }
            SqlDingusEnUserRechten.SQLNonQuery(_command);
            _command=new SqlCommand();
            _command.Parameters.AddWithValue("@userid", _toReturn.TheUserWithEntryInfo.UsE.ID);
            _command.CommandText=$"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> endResult = _DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
            _toReturn.TheUserWithEntryInfo.hasTodayRegEntry=true;
            _toReturn.TheUserWithEntryInfo.RegE=endResult[0];
            return _toReturn;
        }
        
        //overview
        public static NetComunicationTypesAndFunctions.ServerResponseOverzightFromOneDate overzight(DatabaseTypesAndFunctions.AcountTableEntry _MasterRightsEntry, NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate _Request) {
            NetComunicationTypesAndFunctions.ServerResponseOverzightFromOneDate toReturn = new NetComunicationTypesAndFunctions.ServerResponseOverzightFromOneDate();
            SqlCommand _command = new SqlCommand();
            _command.CommandText=$"select * from {DatabaseTypesAndFunctions.UserTableNames.UserTableName}";
            if (!_Request.alsoReturnExUsers) {
                _command.CommandText+=$" where {DatabaseTypesAndFunctions.UserTableNames.IsActiveUser} = 1";
            }
            List<DatabaseTypesAndFunctions.UserTableTableEntry> _userEntrys = _DatabaseTypesAndFunctions.GetListUserTableEntriesFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
            List<DatabaseTypesAndFunctions.RegistratieTableTableEntry> _regEntrys = new List<DatabaseTypesAndFunctions.RegistratieTableTableEntry>();

            _command=new SqlCommand();
            _command.CommandText = $"select * from {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} where {DatabaseTypesAndFunctions.RegistratieTableNames.Date}";
            if (_Request.useToday) {
                _command.CommandText+=" = cast(getdate() as date)";
            } else {
                _command.CommandText+=$" = cast('{_Request.dateToGetOverzightFrom.Date.ToString("yyyy-MM-dd")}' as date)";
            }
            _regEntrys=_DatabaseTypesAndFunctions.GetListRegistratieTableEntrysFromDataTable(SqlDingusEnUserRechten.SQLQuery(_command));
            foreach (var User in _userEntrys) {
                if (User.IsActiveUser) {
                    DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry toPutInList = new DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry();
                    toPutInList.UsE=User;
                    foreach (var Entry in _regEntrys) {
                        if (Entry.IDOfUserRelated==User.ID) {
                            toPutInList.hasTodayRegEntry=true;
                            toPutInList.RegE=Entry;
                            break;
                        }
                    }
                    toReturn.EtList.Add(toPutInList);
                }
            }
            toReturn.SQlDateTime=GetDateTimeFromSqlDatabase();
            return toReturn;
        }

        //update reg table
        public static NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable ChangeRegistatieTable(DatabaseTypesAndFunctions.AcountTableEntry _MasterRightsEntry, NetComunicationTypesAndFunctions.ServerRequestChangeRegistratieTable _Request) {
            NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable _toReturn = new NetComunicationTypesAndFunctions.ServerResponseChangeRegistratieTable();
            SqlCommand _commamd = new SqlCommand();
            _commamd.Parameters.AddWithValue("@andered", _Request.deEntry.Opmerking);
            _commamd.Parameters.AddWithValue("@verwachtetijdvana", _Request.deEntry.Verwachtetijdvanaanwezighijd);
            if (_Request.isNieuwEntry) {
                if (_Request.newEntryDateIsToday) { //date is getdate()
                    _commamd.CommandText=$"insert into {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} ({DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated}, {DatabaseTypesAndFunctions.RegistratieTableNames.Date}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie},{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat}, {DatabaseTypesAndFunctions.RegistratieTableNames.Opmerking}, {DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ({_Request.deEntry.IDOfUserRelated}, cast(getdate() as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit), cast('{_Request.deEntry.IsZiek}' as bit),cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit), cast('{_Request.deEntry.IsExcurtie}' as bit), cast('{_Request.deEntry.IsLaat}' as bit), @andered, cast(@verwachtetijdvana as time))";
                } else {
                    _commamd.CommandText=$"insert into {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} ({DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated}, {DatabaseTypesAndFunctions.RegistratieTableNames.Date}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken}, {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsAanwezig}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof}, {DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie},{DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat}, {DatabaseTypesAndFunctions.RegistratieTableNames.Opmerking}, {DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ({_Request.deEntry.IDOfUserRelated}, cast('{_Request.deEntry.Date.ToString("yyyy\\/MM\\/dd")}' as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit), cast('{_Request.deEntry.IsZiek}' as bit),cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit), cast('{_Request.deEntry.IsExcurtie}' as bit), cast('{_Request.deEntry.IsLaat}' as bit), @andered, cast(@verwachtetijdvana as time))";
                }
                if (SqlDingusEnUserRechten.SQLNonQuery(_commamd)>0) {
                    //_toReturn.deEntry=_Request.deEntry;
                   // _toReturn.deEntry.ID=(int)SqlDingusEnUserRechten.SQLQuery("select SCOPE_IDENTITY() as [yui]").Rows[0]["yui"];
                } else {
                    throw new Exception("SQL CHANGED_0 ERROR AT: "+_commamd.CommandText);
                }
            } else {
                _commamd.CommandText=$"update {DatabaseTypesAndFunctions.RegistratieTableNames.RegistratieTableName} set {DatabaseTypesAndFunctions.RegistratieTableNames.IDOfUserRelated} = {_Request.deEntry.IDOfUserRelated}, {DatabaseTypesAndFunctions.RegistratieTableNames.Date} = cast('{_Request.deEntry.Date.ToString("yyyy\\/MM\\/dd")}' as date), {DatabaseTypesAndFunctions.RegistratieTableNames.TimeInteken} = cast('{_Request.deEntry.TimeInteken}' as time), {DatabaseTypesAndFunctions.RegistratieTableNames.TimeUitteken} = cast('{_Request.deEntry.TimeUitteken}' as time), {DatabaseTypesAndFunctions.RegistratieTableNames.HeeftIngetekend} = cast('{_Request.deEntry.HeeftIngetekend}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsZiek} = cast('{_Request.deEntry.IsZiek}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsFlexibelverlof} = cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsStudieverlof} = cast('{_Request.deEntry.IsStudieverlof}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsExcursie} = cast('{_Request.deEntry.IsExcurtie}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.IsLaat} = cast('{_Request.deEntry.IsLaat}' as bit), {DatabaseTypesAndFunctions.RegistratieTableNames.Opmerking} = @andered, {DatabaseTypesAndFunctions.RegistratieTableNames.Verwachtetijdvanaanwezighijd} = cast(@verwachtetijdvana as time) where {DatabaseTypesAndFunctions.RegistratieTableNames.ID} = {_Request.deEntry.ID}";
                if (SqlDingusEnUserRechten.SQLNonQuery(_commamd)>0) {
                    //_toReturn.deEntry=_Request.deEntry;
                } else {
                    throw new Exception("SQL CHANGED_0 ERROR AT: "+_commamd.CommandText);
                }
            }
            return _toReturn;
        }
    }
}