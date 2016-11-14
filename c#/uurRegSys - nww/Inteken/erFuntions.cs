using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using funcZ;
using Newtonsoft.Json;

namespace Inteken {
    class erFuntions {

        public DateTime _SERVERDATETIME = new DateTime();

        public class combineerUserEntryRegEntryAndAfwezigEntry {
            public SQLPropertysAndFunc.AfwezighijdTableTableEntry afwE { get; set; }
            public SQLPropertysAndFunc.RegistratieTableTableEntry regE { get; set; }
            public SQLPropertysAndFunc.UserTableTableEntry userN { get; set; }
            public bool hasTodayRegEntry { get; set; } = false;
            public bool hasTodayAfwEntry { get; set; } = false;
        }

        public List<combineerUserEntryRegEntryAndAfwezigEntry> loadEnfoFromApi(string _addres, string _password) {
            List<combineerUserEntryRegEntryAndAfwezigEntry> toReturn = new List<combineerUserEntryRegEntryAndAfwezigEntry>();
            TResiveWithPosbleError resp = webFunction.httpPostWithPassword(new TRequestOverviewOfAanwezige(), _addres, _password);
            if (resp.isErrorOcured) {
                throw new Exception(resp.errorInfo.errorText);
            } else {
                TReturnOverviewOfAanwezige lists = JsonConvert.DeserializeObject<TReturnOverviewOfAanwezige>(JsonConvert.SerializeObject(resp.expectedResponse));
                _SERVERDATETIME=lists.dateTimeNow;
                foreach (var user in lists.users) {
                    combineerUserEntryRegEntryAndAfwezigEntry forReturnlist = new combineerUserEntryRegEntryAndAfwezigEntry();
                    forReturnlist.userN=user;
                    foreach (var regEntry in lists.todayRegData) {
                        if (regEntry.IDOfUserRelated==user.ID) {
                            forReturnlist.regE=regEntry;
                            forReturnlist.hasTodayRegEntry=true;
                            break;
                        }
                    }
                    foreach(var afwEntry in lists.todayAfwezig) {
                        if(afwEntry.IDOfRelatedPerson ==user.ID) {
                            forReturnlist.afwE=afwEntry;
                            forReturnlist.hasTodayAfwEntry=true;
                            break;
                        }
                    }
                    toReturn.Add(forReturnlist);
                }

                return toReturn;
            }
        }

        public List<combineerUserEntryRegEntryAndAfwezigEntry> searchListByContains(string voornaamOfAchtenaamContains, List<combineerUserEntryRegEntryAndAfwezigEntry> listToSearchIn) {
            List<combineerUserEntryRegEntryAndAfwezigEntry> toReturn = new List<combineerUserEntryRegEntryAndAfwezigEntry>();
            foreach (var entry in listToSearchIn) {
                if (entry.userN.voorNaam.Contains(voornaamOfAchtenaamContains)||entry.userN.achterNaam.Contains(voornaamOfAchtenaamContains)) {
                    toReturn.Add(entry);
                }
            }
            return toReturn;
        }

        public DataTable listToDataTableForDisplay(List<combineerUserEntryRegEntryAndAfwezigEntry> deList) {
            DataTable ToReturn = new DataTable();
            ToReturn.Columns.Add("voornaam");
            ToReturn.Columns.Add("achternaam");
            ToReturn.Columns.Add("tijdIn");
            ToReturn.Columns.Add("tijdUit");
            ToReturn.Columns.Add("Totaal");

            foreach (var entry in deList) {
                DataRow row = ToReturn.NewRow();
                row["voornaam"]=entry.userN.voorNaam;
                row["achternaam"]=entry.userN.achterNaam;
                if (entry.hasTodayRegEntry) {

                    row["tijdIn"]=entry.regE.TimeInteken.ToString("hh\\:mm");
                    if (entry.regE.TimeUitteken!=null && !entry.regE.IsAanwezig) {
                        row["tijdUit"]=entry.regE.TimeUitteken.ToString("hh\\:mm");
                        row["Totaal"]=entry.regE.TimeUitteken.Subtract(entry.regE.TimeInteken).ToString();
                    } else {
                        row["Totaal"]=_SERVERDATETIME.TimeOfDay.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm");
                    }
                }
                ToReturn.Rows.Add(row);
            }
            return ToReturn;
        }

    }
}
