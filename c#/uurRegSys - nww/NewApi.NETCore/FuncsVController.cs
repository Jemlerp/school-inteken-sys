using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewCrossFunctions.NETCore;
using System.Data.SqlClient;
using System.Data;


namespace NewApi.NETCore {
    public class FuncsVController {

        public static DatabaseObjects _DatabaseObjects = new DatabaseObjects();

        public static DateTime GetDateTimeFromSqlDatabase() {
            return FuncsVSQL.GetDateTimeFromSQLServer();
        }

        public static IEnumerable<DateTime> ElkeDatumTussenTweDatums(DateTime from, DateTime thru) {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public static NetComObjects.ServerResponseInteken inteken(DatabaseObjects.AcountTableEntry _userAcount, NetComObjects.ServerRequestTekenInOfUit _request) {
            NetComObjects.ServerResponseInteken toReturn = new NetComObjects.ServerResponseInteken();
            SqlCommand command;

            //get userID of scan
            command = new SqlCommand();
            command.Parameters.AddWithValue("@nfcode", _request.NFCCode);
            command.CommandText = $"select * from {DatabaseObjects.UserTableNames.UserTableName} where {DatabaseObjects.UserTableNames.NFCID} = @nfcode";
            List<DatabaseObjects.UserTableTableEntry> foundUsers = FuncsVSQL.GetListUTFromReader(command); //_DatabaseObjects.GetListUTFromReader(FuncsVSQL.SQLQuery(command));
            if (foundUsers.Count > 0) {
                toReturn.TheUserWithEntryInfo.UsE = foundUsers[0];
            } else {
                throw new Exception("Card Unknown");
            }

            //inteken/uiteken
            command = new SqlCommand();
            command.Parameters.AddWithValue("@userid", toReturn.TheUserWithEntryInfo.UsE.ID);
            command.CommandText = $"select * from {DatabaseObjects.RegistratieTableNames.RegistratieTableName} where {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseObjects.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseObjects.RegistratieTableTableEntry> _existingRegEntry = FuncsVSQL.GetListRTFromReader(command); //_DatabaseObjects.GetListRTFromReader(FuncsVSQL.SQLQuery(command));
            DatabaseObjects.RegistratieTableTableEntry existingRegEntry;
            command = new SqlCommand();
            if (_existingRegEntry.Count > 0) {
                // edit
                existingRegEntry = _existingRegEntry[0];
                existingRegEntry.IsLaat = false;
                existingRegEntry.Verwachtetijdvanaanwezighijd = new TimeSpan();

                command.Parameters.AddWithValue("@id", existingRegEntry.ID);
                if (existingRegEntry.HeeftIngetekend) {
                    if (existingRegEntry.IsAanwezig) {
                        //update teken uit
                        toReturn.uitgetekened = true;
                        command.CommandText = $"update {DatabaseObjects.RegistratieTableNames.RegistratieTableName} set {DatabaseObjects.RegistratieTableNames.TimeUitteken} = cast(getdate() as time), {DatabaseObjects.RegistratieTableNames.IsAanwezig} = 0 ,{DatabaseObjects.RegistratieTableNames.IsLaat} = 0 where {DatabaseObjects.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = {toReturn.TheUserWithEntryInfo.UsE.ID}";
                    } else {
                        //update anuleer uitteken
                        toReturn.uitekenengeanuleerd = true;
                        command.CommandText = $"update {DatabaseObjects.RegistratieTableNames.RegistratieTableName} set {DatabaseObjects.RegistratieTableNames.IsAanwezig} = 1, {DatabaseObjects.RegistratieTableNames.IsLaat} = 0  where {DatabaseObjects.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = {toReturn.TheUserWithEntryInfo.UsE.ID}";
                    }
                } else {
                    //update inteken
                    toReturn.ingetekened = true;
                    command.CommandText = $"update {DatabaseObjects.RegistratieTableNames.RegistratieTableName} set {DatabaseObjects.RegistratieTableNames.HeeftIngetekend} = 1, {DatabaseObjects.RegistratieTableNames.TimeInteken} = cast(getdate() as time), {DatabaseObjects.RegistratieTableNames.IsAanwezig} = 1, {DatabaseObjects.RegistratieTableNames.IsLaat} = 0  where {DatabaseObjects.RegistratieTableNames.Date} = cast(getdate() as date) and {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = {toReturn.TheUserWithEntryInfo.UsE.ID}";
                }
            } else {
                //new
                //inteken
                command.Parameters.AddWithValue("@relatedUserId", foundUsers[0].ID);
                toReturn.ingetekened = true;
                command.CommandText = $"insert into {DatabaseObjects.RegistratieTableNames.RegistratieTableName} ({DatabaseObjects.RegistratieTableNames.IDOfUserRelated},{DatabaseObjects.RegistratieTableNames.Date},{DatabaseObjects.RegistratieTableNames.TimeInteken},{DatabaseObjects.RegistratieTableNames.HeeftIngetekend},{DatabaseObjects.RegistratieTableNames.IsAanwezig},{DatabaseObjects.RegistratieTableNames.IsZiek},{DatabaseObjects.RegistratieTableNames.IsFlexibelverlof},{DatabaseObjects.RegistratieTableNames.IsStudieverlof},{DatabaseObjects.RegistratieTableNames.IsExcursie},{DatabaseObjects.RegistratieTableNames.IsLaat},{DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig},{DatabaseObjects.RegistratieTableNames.Opmerking},{DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values (@relatedUserId, cast(getdate() as date), cast(getdate() as time), 1,1,0,0,0,0,0,0,'','')";
            }
            FuncsVSQL.SQLNonQuery(command);
            command = new SqlCommand();
            command.Parameters.AddWithValue("@userid", toReturn.TheUserWithEntryInfo.UsE.ID);
            command.CommandText = $"select * from {DatabaseObjects.RegistratieTableNames.RegistratieTableName} where {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = @userid and {DatabaseObjects.RegistratieTableNames.Date} = cast(getdate() as date)";
            List<DatabaseObjects.RegistratieTableTableEntry> endResult = FuncsVSQL.GetListRTFromReader(command); //_DatabaseObjects.GetListRTFromReader(FuncsVSQL.SQLQuery(command));
            toReturn.TheUserWithEntryInfo.hasTodayRegEntry = true;
            toReturn.TheUserWithEntryInfo.RegE = endResult[0];
            return toReturn;
        }

        public static NetComObjects.ServerResponseOverzightFromOneDate overzight(DatabaseObjects.AcountTableEntry _userAcount, NetComObjects.ServerRequestOverzightFromOneDate _request) {
            NetComObjects.ServerResponseOverzightFromOneDate toReturn = new NetComObjects.ServerResponseOverzightFromOneDate();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"select * from {DatabaseObjects.UserTableNames.UserTableName}";
            if (!_request.alsoReturnExUsers) {
                command.CommandText += $" where {DatabaseObjects.UserTableNames.IsActiveUser} = 1";
            }
            List<DatabaseObjects.UserTableTableEntry> userEntrys = FuncsVSQL.GetListUTFromReader(command); //_DatabaseObjects.GetListUTFromReader(FuncsVSQL.SQLQuery(command));
            List<DatabaseObjects.RegistratieTableTableEntry> regEntrys = new List<DatabaseObjects.RegistratieTableTableEntry>();

            command = new SqlCommand();
            command.CommandText = $"select * from {DatabaseObjects.RegistratieTableNames.RegistratieTableName} where {DatabaseObjects.RegistratieTableNames.Date}";
            if (_request.useToday) {
                command.CommandText += " = cast(getdate() as date)";
            } else {
                command.CommandText += $" = cast('{_request.dateToGetOverzightFrom.Date.ToString("yyyy-MM-dd")}' as date)";
            }

            regEntrys = FuncsVSQL.GetListRTFromReader(command); //_DatabaseObjects.GetListRTFromReader(FuncsVSQL.SQLQuery(command));
            foreach (var User in userEntrys) {
                if (User.IsActiveUser) {
                    DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry toPutInList = new DatabaseObjects.CombineerUserEntryRegEntryAndAfwezigEntry();
                    toPutInList.UsE = User;
                    foreach (var Entry in regEntrys) {
                        if (Entry.IDOfUserRelated == User.ID) {
                            toPutInList.hasTodayRegEntry = true;
                            toPutInList.RegE = Entry;
                            break;
                        }
                    }
                    toReturn.EtList.Add(toPutInList);
                }
            }
            toReturn.SQlDateTime = GetDateTimeFromSqlDatabase();
            return toReturn;
        }

        public static NetComObjects.ServerResponseOverzightFromMultipleDates compleetOverzightVanTussenTweDatums(DatabaseObjects.AcountTableEntry _userAcount, NetComObjects.ServerRequestOverzightFromMultipleDates _request) {
            NetComObjects.ServerResponseOverzightFromMultipleDates toReturn = new NetComObjects.ServerResponseOverzightFromMultipleDates();

            foreach (DateTime dag in ElkeDatumTussenTweDatums(_request.FromAndWithThisDate, _request.TotEnMetDezeDatum)) {

                NetComObjects.ServerResponseOverzightFromMultipleDatesSubType toAddToList = new NetComObjects.ServerResponseOverzightFromMultipleDatesSubType();
                toAddToList.DateOfOverzight = dag;

                NetComObjects.ServerRequestOverzightFromOneDate moreRequest = new NetComObjects.ServerRequestOverzightFromOneDate();
                moreRequest.alsoReturnExUsers = _request.getForExUsers;
                moreRequest.useToday = false;
                moreRequest.dateToGetOverzightFrom = dag;

                toAddToList.OverZichtFromThisDate = overzight(_userAcount, moreRequest);

                toReturn.allesDatJeNodigHebt.Add(toAddToList);
            }
            return toReturn;
        }

        public static NetComObjects.ServerResponseChangeRegistratieTable ChangeRegistatieTable(DatabaseObjects.AcountTableEntry _MasterRightsEntry, NetComObjects.ServerRequestChangeRegistratieTable _Request) {
            NetComObjects.ServerResponseChangeRegistratieTable _toReturn = new NetComObjects.ServerResponseChangeRegistratieTable();
            SqlCommand _commamd = new SqlCommand();
            _commamd.Parameters.AddWithValue("@andered", _Request.deEntry.Opmerking);
            _commamd.Parameters.AddWithValue("@verwachtetijdvana", _Request.deEntry.Verwachtetijdvanaanwezighijd);

            if (_Request.isNieuwEntry) {
                if (_Request.newEntryDateIsToday) {
                    _commamd.CommandText = $"insert into {DatabaseObjects.RegistratieTableNames.RegistratieTableName}( {DatabaseObjects.RegistratieTableNames.IDOfUserRelated}, {DatabaseObjects.RegistratieTableNames.Date}, {DatabaseObjects.RegistratieTableNames.TimeInteken}, {DatabaseObjects.RegistratieTableNames.TimeUitteken}, {DatabaseObjects.RegistratieTableNames.HeeftIngetekend}, {DatabaseObjects.RegistratieTableNames.IsAanwezig}, {DatabaseObjects.RegistratieTableNames.IsZiek}, {DatabaseObjects.RegistratieTableNames.IsFlexibelverlof}, {DatabaseObjects.RegistratieTableNames.IsStudieverlof}, {DatabaseObjects.RegistratieTableNames.IsExcursie}, {DatabaseObjects.RegistratieTableNames.IsLaat}, {DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig}, {DatabaseObjects.RegistratieTableNames.Opmerking}, {DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ( {_Request.deEntry.IDOfUserRelated}, cast('{_Request.deEntry.Date.ToString("yyyy\\/MM\\/dd")}' as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit),  cast('{_Request.deEntry.IsZiek}' as bit), cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit),  cast('{_Request.deEntry.IsExcurtie}' as bit),  cast('{_Request.deEntry.IsLaat}' as bit), cast('{_Request.deEntry.IsToegestaalAfwezig}' as bit, @andered, {_Request.deEntry.Verwachtetijdvanaanwezighijd})";

                    //_commamd.CommandText = $"insert into {DatabaseObjects.RegistratieTableNames.RegistratieTableName} ({DatabaseObjects.RegistratieTableNames.IDOfUserRelated}, {DatabaseObjects.RegistratieTableNames.Date}, {DatabaseObjects.RegistratieTableNames.TimeInteken}, {DatabaseObjects.RegistratieTableNames.TimeUitteken}, {DatabaseObjects.RegistratieTableNames.HeeftIngetekend}, {DatabaseObjects.RegistratieTableNames.IsAanwezig}, {DatabaseObjects.RegistratieTableNames.IsZiek}, {DatabaseObjects.RegistratieTableNames.IsFlexibelverlof}, {DatabaseObjects.RegistratieTableNames.IsStudieverlof}, {DatabaseObjects.RegistratieTableNames.IsExcursie},{DatabaseObjects.RegistratieTableNames.IsLaat}, {DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig}, {DatabaseObjects.RegistratieTableNames.Opmerking}, {DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ({_Request.deEntry.IDOfUserRelated}, cast(getdate() as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit), cast('{_Request.deEntry.IsZiek}' as bit),cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit), cast('{_Request.deEntry.IsExcurtie}' as bit), cast('{_Request.deEntry.IsLaat}' as bit), cast('{_Request.deEntry.IsToegestaalAfwezig}' as bit), @andered, cast(@verwachtetijdvana as time))";
                } else {
                    //_commamd.CommandText = $"insert into {DatabaseObjects.RegistratieTableNames.RegistratieTableName} ({DatabaseObjects.RegistratieTableNames.IDOfUserRelated}, {DatabaseObjects.RegistratieTableNames.Date}, {DatabaseObjects.RegistratieTableNames.TimeInteken}, {DatabaseObjects.RegistratieTableNames.TimeUitteken}, {DatabaseObjects.RegistratieTableNames.HeeftIngetekend}, {DatabaseObjects.RegistratieTableNames.IsAanwezig}, {DatabaseObjects.RegistratieTableNames.IsZiek}, {DatabaseObjects.RegistratieTableNames.IsFlexibelverlof}, {DatabaseObjects.RegistratieTableNames.IsStudieverlof}, {DatabaseObjects.RegistratieTableNames.IsExcursie},{DatabaseObjects.RegistratieTableNames.IsLaat},{DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig}, {DatabaseObjects.RegistratieTableNames.Opmerking}, {DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ({_Request.deEntry.IDOfUserRelated}, cast('{_Request.deEntry.Date.ToString("yyyy\\/MM\\/dd")}' as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit), cast('{_Request.deEntry.IsZiek}' as bit),cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit), cast('{_Request.deEntry.IsExcurtie}' as bit), cast('{_Request.deEntry.IsLaat}' as bit),cast('{_Request.deEntry.IsToegestaalAfwezig}' as bit), @andered, cast(@verwachtetijdvana as time))";

                    _commamd.CommandText = $"insert into {DatabaseObjects.RegistratieTableNames.RegistratieTableName}( {DatabaseObjects.RegistratieTableNames.IDOfUserRelated}, {DatabaseObjects.RegistratieTableNames.Date}, {DatabaseObjects.RegistratieTableNames.TimeInteken}, {DatabaseObjects.RegistratieTableNames.TimeUitteken}, {DatabaseObjects.RegistratieTableNames.HeeftIngetekend}, {DatabaseObjects.RegistratieTableNames.IsAanwezig}, {DatabaseObjects.RegistratieTableNames.IsZiek}, {DatabaseObjects.RegistratieTableNames.IsFlexibelverlof}, {DatabaseObjects.RegistratieTableNames.IsStudieverlof}, {DatabaseObjects.RegistratieTableNames.IsExcursie}, {DatabaseObjects.RegistratieTableNames.IsLaat}, {DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig}, {DatabaseObjects.RegistratieTableNames.Opmerking}, {DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd}) values ( {_Request.deEntry.IDOfUserRelated}, cast(getdate() as date), cast('{_Request.deEntry.TimeInteken}' as time), cast('{_Request.deEntry.TimeUitteken}' as time), cast('{_Request.deEntry.HeeftIngetekend}' as bit), cast('{_Request.deEntry.IsAanwezig}' as bit),  cast('{_Request.deEntry.IsZiek}' as bit), cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), cast('{_Request.deEntry.IsStudieverlof}' as bit),  cast('{_Request.deEntry.IsExcurtie}' as bit),  cast('{_Request.deEntry.IsLaat}' as bit), cast('{_Request.deEntry.IsToegestaalAfwezig}' as bit), @andered,cast(@verwachtetijdvana as time) )";

                }

                if (FuncsVSQL.SQLNonQuery(_commamd) > 0) {
                    //_toReturn.deEntry=_Request.deEntry;
                    // _toReturn.deEntry.ID=(int)SqlDingusEnUserRechten.SQLQuery("select SCOPE_IDENTITY() as [yui]").Rows[0]["yui"];
                } else {
                    throw new Exception("SQL CHANGED_0 ERROR AT: " + _commamd.CommandText);
                }
            } else {

                _commamd.CommandText = $@"update {DatabaseObjects.RegistratieTableNames.RegistratieTableName} set {DatabaseObjects.RegistratieTableNames.IDOfUserRelated} = {_Request.deEntry.IDOfUserRelated}, {DatabaseObjects.RegistratieTableNames.Date} = cast('{_Request.deEntry.Date.ToString("yyyy\\/MM\\/dd")}' as date), {DatabaseObjects.RegistratieTableNames.TimeInteken} = cast('{_Request.deEntry.TimeInteken}' as time), {DatabaseObjects.RegistratieTableNames.TimeUitteken} = cast('{_Request.deEntry.TimeUitteken}' as time), {DatabaseObjects.RegistratieTableNames.IsAanwezig} = cast('{_Request.deEntry.IsAanwezig}' as bit), {DatabaseObjects.RegistratieTableNames.HeeftIngetekend} = cast('{_Request.deEntry.HeeftIngetekend}' as bit), {DatabaseObjects.RegistratieTableNames.IsZiek} = cast('{_Request.deEntry.IsZiek}' as bit), {DatabaseObjects.RegistratieTableNames.IsFlexibelverlof} = cast('{_Request.deEntry.IsFlexiebelverlof}' as bit), {DatabaseObjects.RegistratieTableNames.IsStudieverlof} = cast('{_Request.deEntry.IsStudieverlof}' as bit), {DatabaseObjects.RegistratieTableNames.IsExcursie} = cast('{_Request.deEntry.IsExcurtie}' as bit), {DatabaseObjects.RegistratieTableNames.IsLaat} = cast('{_Request.deEntry.IsLaat}' as bit), {DatabaseObjects.RegistratieTableNames.IsToegestaanAfwezig} = cast('{_Request.deEntry.IsToegestaalAfwezig}' as bit), {DatabaseObjects.RegistratieTableNames.Opmerking} = @andered, {DatabaseObjects.RegistratieTableNames.Verwachtetijdvanaanwezighijd} = cast(@verwachtetijdvana as time) where {DatabaseObjects.RegistratieTableNames.ID} = {_Request.deEntry.ID}";

                if (FuncsVSQL.SQLNonQuery(_commamd) > 0) {
                    //_toReturn.deEntry=_Request.deEntry;
                } else {
                    throw new Exception("SQL CHANGED_0 ERROR AT: " + _commamd.CommandText);
                }
            }
            return _toReturn;
        }

    }
}
