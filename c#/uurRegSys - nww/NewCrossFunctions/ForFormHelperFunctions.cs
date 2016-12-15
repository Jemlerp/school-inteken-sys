using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace NewCrossFunctions {
    public class ForFormHelperFunctions {

        public static string SerialReadToNormal(string read) {
            string eetEenUi = "";
            char[] nummbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            foreach (char x in read) {
                foreach (char y in nummbers) {
                    if (y==x) { eetEenUi+=x; break; }
                }
            }
            return eetEenUi.TrimStart();
        }

        public DataTable listToDataTableForDisplay(List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry> _UserAndRegEntrys, DateTime _CurrentSQlDateTime) {
            DataTable ToReturn = new DataTable();
            ToReturn.Columns.Add("Voornaam");
            ToReturn.Columns.Add("Achternaam");
            ToReturn.Columns.Add("TijdIn");
            ToReturn.Columns.Add("TijdUit");
            ToReturn.Columns.Add("Totaal");
            foreach (var entry in _UserAndRegEntrys) {
                DataRow row = ToReturn.NewRow();
                row["VoorNaam"]=entry.userN.VoorNaam;
                row["AchterNaam"]=entry.userN.AchterNaam;
                if (entry.hasTodayRegEntry) {                   

                    //laat zien dat je in sys staat dat je afwezig bent
                    string watAfwezig = "";
                    bool erIsEenAfwezigNotatie = false;
                    if (entry.regE.IsZiek) {
                        watAfwezig="Z";
                    }
                    if (entry.regE.IsFlexiebelverlof) {
                        watAfwezig="FV";
                    }
                    if (entry.regE.IsStudieverlof) {

                    }
                    if (entry.regE.IsExcurtie) {

                    }
                    if (entry.regE.IsLaat) {

                    }
                    if (entry.regE.IsAndereReden) {

                    }
                    if(watAfwezig !="") { erIsEenAfwezigNotatie=true; } else {
                        row["TijdIn"]=watAfwezig;
                        row["tijdUit"]=watAfwezig;
                        row["Totaal"]=watAfwezig;
                    }

                    
                    


                }



                if (entry.hasTodayRegEntry) {
                    if (entry.regE.HeeftIngetekend) {
                        if (entry.regE.IsAanwezig) {
                            //totaal = in tot nu
                            row["TijdIn"]=entry.regE.TimeInteken.ToString("hh\\:mm");
                            row["Totaal"]=_CurrentSQlDateTime.TimeOfDay.Subtract(entry.regE.TimeInteken);
                        } else {
                            //totaal= in tot uiteken
                            row["TijdIn"]=entry.regE.TimeInteken.ToString("hh\\:mm");
                            row["TijdUit"]=entry.regE.TimeUitteken.ToString("hh\\:mm");
                            row["Totaal"]=entry.regE.TimeUitteken.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm");
                        }
                    } else {
                        //show afwezig reden
                        string redenToShow = "";
                        if (entry.regE.IsZiek) {
                            redenToShow="Z";
                        }
                        if (entry.regE.IsFlexiebelverlof) {
                            redenToShow="FV";
                        }
                        if (entry.regE.IsStudieverlof) {
                            
                        }
                        if (entry.regE.IsExcurtie) {

                        }
                        if (entry.regE.IsLaat) {

                        }
                        if (entry.regE.IsAndereReden) {

                        }

                    }                    
                }
                         
                //DataRow row = ToReturn.NewRow();
                //row["voornaam"]=entry.userN.VoorNaam;
                //row["achternaam"]=entry.userN.AchterNaam;
                //if (entry.hasTodayRegEntry) {
                //    string warom = "";
                //    if (entry.regE.IsAndereReden) { warom="xxx : "+entry.regE.AnderenRedenVoorAfwezigihijd; }
                //    if (entry.regE.IsExcurtie) { warom="EX"; }
                //    if (entry.regE.IsFlexiebelverlof) { warom="FV"; }
                //    if (entry.regE.IsStudieverlof) { warom="SV"; }
                //    if (entry.regE.IsZiek) { warom="Z"; }
                //    if (entry.regE.IsLaat) { warom="L : "+entry.regE.Verwachtetijdvanaanwezighijd; }

                //    row["tijdIn"]=warom;
                //    row["tijdUit"]=warom;
                //    row["Totaal"]=warom;

                //    if (entry.hasTodayRegEntry) {
                //        row["tijdIn"]+=" "+entry.regE.TimeInteken.ToString("hh\\:mm");
                //        if (entry.regE.TimeUitteken!=null&&!entry.regE.IsAanwezig) {
                //            row["tijdUit"]+=" "+entry.regE.TimeUitteken.ToString("hh\\:mm");
                //            row["Totaal"]+=" "+entry.regE.TimeUitteken.Subtract(entry.regE.TimeInteken).ToString();
                //        } else {
                //            row["Totaal"]+=" "+_SERVERDATETIME.TimeOfDay.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm");
                //        }
                //    }

                //} else {
                //    if (entry.hasTodayRegEntry) {
                //        row["tijdIn"]=entry.regE.TimeInteken.ToString("hh\\:mm");
                //        if (entry.regE.TimeUitteken!=null&&!entry.regE.IsAanwezig) {
                //            row["tijdUit"]=entry.regE.TimeUitteken.ToString("hh\\:mm");
                //            row["Totaal"]=entry.regE.TimeUitteken.Subtract(entry.regE.TimeInteken).ToString();
                //        } else {
                //            row["Totaal"]=_SERVERDATETIME.TimeOfDay.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm");
                //        }
                //    }
                // }
                //ToReturn.Rows.Add(row);
            }
            return ToReturn;
        }
    }
}
