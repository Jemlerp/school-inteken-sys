using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewCrossFunctions.NETCore;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


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

        public static NetComObjects.ServerResponseOverzightFromMultipleDates alleDagOverzightenVanTussenTweDatums(DatabaseObjects.AcountTableEntry _userAcount, NetComObjects.ServerRequestOverzightFromMultipleDates _request) {
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

        //user
        public static NetComObjects.ServerResponseGetUserTable GetUserTable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestGetUserTable _request) {
            NetComObjects.ServerResponseGetUserTable toReturn = new NetComObjects.ServerResponseGetUserTable();
            SqlCommand command = new SqlCommand();
            if (_request.aleenDieNogOpSchoolZitten) {
                command.CommandText = $"select * from {DatabaseObjects.UserTableNames.UserTableName} where ZitNogOpSchool = 1";
            } else {
                command.CommandText = $"select * from {DatabaseObjects.UserTableNames.UserTableName}";
            }
            toReturn.deEntrys = FuncsVSQL.GetListUTFromReader(command);
            return toReturn;
        }

        public static NetComObjects.ServerResponseChangeUserTable ChangeUserTable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestChangeUserTable _request) {
            NetComObjects.ServerResponseChangeUserTable toReturn = new NetComObjects.ServerResponseChangeUserTable();
            SqlCommand command = new SqlCommand();
            
            if (!_request.IsNewUser || _request.DeleteEntry) {
                command.Parameters.AddWithValue("@ID", _request.deEntry.ID);
            }

            if (_request.DeleteEntry) {
                command.CommandText = $"delete from {DatabaseObjects.UserTableNames.UserTableName} where {DatabaseObjects.UserTableNames.ID} = @ID";
            } else {

                bool baylife = false;

                command.Parameters.AddWithValue("@Voornaam", _request.deEntry.VoorNaam);
                command.Parameters.AddWithValue("@Achternaam", _request.deEntry.AchterNaam);
                command.Parameters.AddWithValue("@NFCID", _request.deEntry.NFCID);
                command.Parameters.AddWithValue("@DateJoined", _request.deEntry.DateJoined);
                command.Parameters.AddWithValue("@IsActive", _request.deEntry.IsActiveUser);

                try {

                    command.Parameters.AddWithValue("@DateLeft", _request.deEntry.DateLeft);

                } catch { baylife = true; }

                if (_request.IsNewUser) {
                    if (baylife) {
                        command.CommandText = $"insert into {DatabaseObjects.UserTableNames.UserTableName} ({DatabaseObjects.UserTableNames.VoorNaam}, {DatabaseObjects.UserTableNames.AchterNaam}, {DatabaseObjects.UserTableNames.NFCID}, {DatabaseObjects.UserTableNames.DateJoined}, {DatabaseObjects.UserTableNames.IsActiveUser}, {DatabaseObjects.UserTableNames.DateLeft} ) values (@Voornaam, @Achternaam, @NFCID, cast(@DateJoined as date), cast(@IsActive as bit), cast(@DateLeft as date))";
                    } else {
                        command.CommandText = $"insert into {DatabaseObjects.UserTableNames.UserTableName} ({DatabaseObjects.UserTableNames.VoorNaam}, {DatabaseObjects.UserTableNames.AchterNaam}, {DatabaseObjects.UserTableNames.NFCID}, {DatabaseObjects.UserTableNames.DateJoined}, {DatabaseObjects.UserTableNames.IsActiveUser}) values (@Voornaam, @Achternaam, @NFCID, cast(@DateJoined as date), cast(@IsActive as bit))";
                    }
                } else {
                    if (baylife) {
                        command.CommandText = $"update {DatabaseObjects.UserTableNames.UserTableName} set {DatabaseObjects.UserTableNames.VoorNaam} = @Voornaam, {DatabaseObjects.UserTableNames.AchterNaam} = @Achternaam, {DatabaseObjects.UserTableNames.NFCID} = @NFCID, {DatabaseObjects.UserTableNames.DateJoined} = cast(@DateJoined as date), {DatabaseObjects.UserTableNames.IsActiveUser} = cast(@IsActive as bit), {DatabaseObjects.UserTableNames.DateLeft} = cast(@DateLeft as date) where {DatabaseObjects.UserTableNames.ID} = @ID";
                    } else {
                        command.CommandText = $"update {DatabaseObjects.UserTableNames.UserTableName} set {DatabaseObjects.UserTableNames.VoorNaam} = @Voornaam, {DatabaseObjects.UserTableNames.AchterNaam} = @Achternaam, {DatabaseObjects.UserTableNames.NFCID} = @NFCID, {DatabaseObjects.UserTableNames.DateJoined} = cast(@DateJoined as date), {DatabaseObjects.UserTableNames.IsActiveUser} = cast(@IsActive as bit) where {DatabaseObjects.UserTableNames.ID} = @ID";
                    }
                }
            }
            if(FuncsVSQL.SQLNonQuery(command) != 1) {
                toReturn.OK = false;
            }
            return toReturn;
        }

        //mod
        public static NetComObjects.ServerResponseGetModTable GetModtable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestGetModTable _request) {
            NetComObjects.ServerResponseGetModTable toReturn = new NetComObjects.ServerResponseGetModTable();
            toReturn.deEntrys = FuncsVSQL.GetListMTFromReader($"select * from {DatabaseObjects.ModifierTableNames.ModifierTableName}");
            return toReturn;
        }

        public static NetComObjects.ServerResponseChangeModTable ChangeModtable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestChangeModTable _request) {
            NetComObjects.ServerResponseChangeModTable toReturn = new NetComObjects.ServerResponseChangeModTable();
            SqlCommand command = new SqlCommand();

            if(!_request.IsNewEntry || _request.DeleteEntry) {
                command.Parameters.AddWithValue("@ID", _request.deEntry.ID);
            }

            if (_request.DeleteEntry) {
                command.CommandText = $"delete from {DatabaseObjects.ModifierTableNames.ModifierTableName} where {DatabaseObjects.ModifierTableNames.ID} = @ID";
            } else {
                command.Parameters.AddWithValue("@dateVan", _request.deEntry.DateVanafEnMet);
                command.Parameters.AddWithValue("@dateTot", _request.deEntry.DateTotEnMet);
                command.Parameters.AddWithValue("@daysOfEffect",  JsonConvert.SerializeObject(_request.deEntry.DaysOfEffect));
                command.Parameters.AddWithValue("@users", JsonConvert.SerializeObject(_request.deEntry.UserIDs));
                command.Parameters.AddWithValue("@hoursToAdd", _request.deEntry.HoursToAdd);
                command.Parameters.AddWithValue("@omschrij", _request.deEntry.omschrijveing);
                command.Parameters.AddWithValue("@isStudiev", _request.deEntry.isStudieVerlof);
                command.Parameters.AddWithValue("@isExcur", _request.deEntry.isExurtie);
                command.Parameters.AddWithValue("@isFlexy", _request.deEntry.isFlexibelverlofoeorfsjklcghiur);
                if (_request.IsNewEntry) {
                    command.CommandText = $"insert into {DatabaseObjects.ModifierTableNames.ModifierTableName} ({DatabaseObjects.ModifierTableNames.DateVanafEnMet}, {DatabaseObjects.ModifierTableNames.DateTotEnMet}, {DatabaseObjects.ModifierTableNames.DaysOfEffect}, {DatabaseObjects.ModifierTableNames.UserIDs}, {DatabaseObjects.ModifierTableNames.HoursToAdd}, {DatabaseObjects.ModifierTableNames.Omschrijving}, {DatabaseObjects.ModifierTableNames.isStudiever}, {DatabaseObjects.ModifierTableNames.isExur}, {DatabaseObjects.ModifierTableNames.isflexy}) values (cast(@dateVan as date), cast(@dateTot as date), @daysOfEffect, @users, @hoursToAdd, @omschrij, @isStudiev, @isExcur, @isFlexy)";
                } else {
                    command.CommandText = $"update {DatabaseObjects.ModifierTableNames.ModifierTableName} set {DatabaseObjects.ModifierTableNames.DateVanafEnMet} = cast(@dateVan as date), {DatabaseObjects.ModifierTableNames.DateTotEnMet} = @dateTot, {DatabaseObjects.ModifierTableNames.DaysOfEffect} = @daysOfEffect, {DatabaseObjects.ModifierTableNames.UserIDs} = @users, {DatabaseObjects.ModifierTableNames.HoursToAdd} = @hoursToAdd,  {DatabaseObjects.ModifierTableNames.Omschrijving} = @omschrij, {DatabaseObjects.ModifierTableNames.isStudiever} = @isStudiev, {DatabaseObjects.ModifierTableNames.isExur} = @isStudiev, {DatabaseObjects.ModifierTableNames.isflexy} = @isFlexy where {DatabaseObjects.ModifierTableNames.ID} = @ID";
                }
            }
            if (FuncsVSQL.SQLNonQuery(command) != 1) {
                toReturn.OK = false;
            }
            return toReturn;
        }

        //acount
        public static NetComObjects.ServerResponseGetAcountTable GetAcountTable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestGetAcountsTable _request) {
            NetComObjects.ServerResponseGetAcountTable toReturn = new NetComObjects.ServerResponseGetAcountTable();
            toReturn.deEntrys = FuncsVSQL.GetListATFromReader($"select * from {DatabaseObjects.AcountsTableNames.AcountsTableName}");
            return toReturn;
        }

        public static NetComObjects.ServerResponseChangeAcountTable ChangeAcountTable(DatabaseObjects.AcountTableEntry _MasterRightsEnty, NetComObjects.ServerRequestChangeAcountTable _request) {
            NetComObjects.ServerResponseChangeAcountTable toReturn = new NetComObjects.ServerResponseChangeAcountTable();
            SqlCommand command = new SqlCommand();

            if (!_request.IsNewEntry || _request.DeleteEntry) {

                command.Parameters.AddWithValue("@ID", _request.deEntry.ID);
            }

            if (_request.DeleteEntry) {

                command.CommandText = $"delete from {DatabaseObjects.AcountsTableNames.AcountsTableName} where {DatabaseObjects.AcountsTableNames.ID} = @ID";

            } else {
                command.Parameters.AddWithValue("@aansprBevoeg", _request.deEntry.AanspreekpuntBevoegdhijd);
                command.Parameters.AddWithValue("@adminBevoeg", _request.deEntry.AdminBevoegdhijd);
                command.Parameters.AddWithValue("@inlogNaam", _request.deEntry.InlogNaam);
                command.Parameters.AddWithValue("@pw", _request.deEntry.InlogWachtwoord);
                command.Parameters.AddWithValue("@naam", _request.deEntry.Naam);

                if (_request.IsNewEntry) {

                    command.CommandText = $"insert into {DatabaseObjects.AcountsTableNames.AcountsTableName} ({DatabaseObjects.AcountsTableNames.Naam}, {DatabaseObjects.AcountsTableNames.InlogNaam}, {DatabaseObjects.AcountsTableNames.InlogWachtwoord}, {DatabaseObjects.AcountsTableNames.AanspreekpuntBevoegthijdLvl}, {DatabaseObjects.AcountsTableNames.AdminBevoegdhijd}) values (@naam, @inlogNaam, @pw, @aansprBevoeg, @adminBevoeg)";

                } else {

                    command.CommandText = $"update {DatabaseObjects.AcountsTableNames.AcountsTableName} set {DatabaseObjects.AcountsTableNames.Naam}= @naam, {DatabaseObjects.AcountsTableNames.InlogNaam} = @inlogNaam, {DatabaseObjects.AcountsTableNames.InlogWachtwoord} = @pw, {DatabaseObjects.AcountsTableNames.AanspreekpuntBevoegthijdLvl} = @aansprBevoeg, {DatabaseObjects.AcountsTableNames.AdminBevoegdhijd} = @adminBevoeg where {DatabaseObjects.AcountsTableNames.ID} = @ID";

                }
            }

            if (FuncsVSQL.SQLNonQuery(command) != 1) {

                toReturn.OK = false;
            }

            return toReturn;
        }
    }
}
