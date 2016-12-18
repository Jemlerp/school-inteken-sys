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
            return eetEenUi.Trim();
        }

        public static DataTable UserInfoListToDataTableForDataGridDisplay(List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry> _UserAndRegEntrys, DateTime _CurrentSQlDateTime) {
            DataTable ToReturn = new DataTable();
            ToReturn.Columns.Add("Voornaam");
            ToReturn.Columns.Add("Achternaam");
            ToReturn.Columns.Add("TijdIn");
            ToReturn.Columns.Add("TijdUit");
            ToReturn.Columns.Add("Totaal");
            string Voornaam = "Voornaam";
            string Achternaam = "Achternaam";
            string TijdIn = "TijdIn";
            string TijdUit = "TijdUit";
            string Totaal = "Totaal";
            foreach (var entry in _UserAndRegEntrys) {
                DataRow row = ToReturn.NewRow();
                row[Voornaam]=entry.userN.VoorNaam;
                row[Achternaam]=entry.userN.AchterNaam;
                if (entry.hasTodayRegEntry) {
                    string watAfwezig = "";
                    bool erIsEenAfwezigNotatie = false;
                    if (entry.regE.IsZiek) {
                        watAfwezig="Z";
                    }
                    if (entry.regE.IsFlexiebelverlof) {
                        watAfwezig="FV";
                    }
                    if (entry.regE.IsStudieverlof) {
                        watAfwezig="SF";
                    }
                    if (entry.regE.IsExcurtie) {
                        watAfwezig="EX";
                    }
                    if (entry.regE.IsLaat) {
                        watAfwezig="Laat : "+entry.regE.Verwachtetijdvanaanwezighijd.ToString("hh\\:mm\\:ss");
                    }
                    if (watAfwezig!="") {
                        erIsEenAfwezigNotatie=true;
                        row[TijdIn]=watAfwezig;
                        row[TijdUit]=watAfwezig;
                        row[Totaal]=watAfwezig;
                    } else {
                        if (!entry.regE.HeeftIngetekend) {
                            row[TijdIn]=entry.regE.Opmerking;
                            row[TijdUit]=entry.regE.Opmerking;
                            row[Totaal]=entry.regE.Opmerking;
                        }
                    }
                    if (entry.regE.HeeftIngetekend) {
                        row[TijdIn]=entry.regE.TimeInteken.ToString("hh\\:mm");
                        if (entry.regE.IsAanwezig) {
                            if (!erIsEenAfwezigNotatie) {
                                row[Totaal]=_CurrentSQlDateTime.TimeOfDay.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm\\:ss\\.fff");
                            }
                        } else {
                            row[TijdUit]=entry.regE.TimeUitteken.ToString("hh\\:mm");
                            if (!erIsEenAfwezigNotatie) {
                                row[Totaal]=entry.regE.TimeUitteken.Subtract(entry.regE.TimeInteken).ToString("hh\\:mm\\:ss\\.fff");
                            }
                        }
                    }
                }
                ToReturn.Rows.Add(row);
            }
            return ToReturn;
        }
    }
}

