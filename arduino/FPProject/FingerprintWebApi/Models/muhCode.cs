using System;
using System.Collections.Generic;
using System.Linq;
using SourceAFIS.Simple;
using FFunc.WebSendAndReturnTypes;
using FFunc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace FingerprintWebApi.Models {
    public class muhCode {
        public static AfisEngine afis = new AfisEngine();

        //Ok
        /// <summary>
        /// test sql connection
        /// </summary>
        /// <returns></returns>
        public static string testSQLConnection() {
             TypeReturnSqlConnection returnType = new TypeReturnSqlConnection();
            try {
                SqlConnection testCon = new SqlConnection(settings.connectionString);
                testCon.Open();
                returnType.canMakeConnectionToSqlServer = true;
                testCon.Close();
                testCon.Dispose();
            } catch(Exception ex) {
                string degunb = ex.Message;
                returnType.canMakeConnectionToSqlServer = false;
            }
            return JsonConvert.SerializeObject(returnType);
        }

        //Ok 18-400MS
        /// <summary>
        /// get json with a list with DB data
        /// </summary>
        /// <param name="_inObject">typeForAskForBDEntry</param>
        /// <returns></returns>
        public static string getDataFromDB(object _inObject) {
            try {
                string wertkWel = JsonConvert.SerializeObject(_inObject);
                TypeAskDBEntry inObject = JsonConvert.DeserializeObject<TypeAskDBEntry>(wertkWel);
                SqlCommand command = new SqlCommand();
                if (inObject.dontUseWhereGetAll) {
                    if(inObject.getProfileImag){
                        command.CommandText = "SELECT id,voorNaam,achterNaam,profileImage FROM " + settings.studentBDTableName;
                    } else{
                        command.CommandText = "SELECT id,voorNaam,achterNaam FROM " + settings.studentBDTableName;
                    }
                } else {
                    if (inObject.getProfileImag) {
                        command.Parameters.AddWithValue("@where", inObject.whereIdIs);
                        command.CommandText = "SELECT id,voorNaam,achterNaam,profileImage FROM " + settings.studentBDTableName + " WHERE id = @where";
                    } else {
                        command.Parameters.AddWithValue("@where", inObject.whereIdIs);
                        command.CommandText = "SELECT id,voorNaam,achterNaam FROM " + settings.studentBDTableName + " WHERE id = @where";
                    }
                }
                DataTable queryResult = SqlAndWeb.SQLQuery(settings.connectionString, command);
                List<TypeReturnDBEntry> returnList = new List<TypeReturnDBEntry>();
                foreach (DataRow row in queryResult.Rows) {
                    TypeReturnDBEntry entry = new TypeReturnDBEntry();
                    entry.ID = (int)row["id"];
                    entry.voorNaam = (string)row["voorNaam"];
                    entry.achterNaam = (string)row["achterNaam"];
                    returnList.Add(entry);
                    if (inObject.getProfileImag) {
                        entry.base64profileImage = (string)row["profileImage"];
                    }
                }
                return JsonConvert.SerializeObject(returnList);
            } catch (Exception ex) {
                TypeReturnError typeForError = new TypeReturnError();
                typeForError.why = "(getDataFromDB)" + ex.Message;
                return JsonConvert.SerializeObject(typeForError);
            }
        }

        //Ok 10-40MS
        /// <summary>
        /// update DB return affected lines ( ja dat is handig )
        /// </summary>
        /// <param name="_inObject"></param>
        /// <returns></returns>
        public static string editDataFromDB(object _inObject) {
            try {
                string wertkWel = JsonConvert.SerializeObject(_inObject);
                TypeSendDBUpdate inObject = JsonConvert.DeserializeObject<TypeSendDBUpdate>(wertkWel);

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@whereID", inObject.WhereIDIs);
                if (inObject.deleteFromDB) {
                    command.CommandText = ("DELETE FROM " + settings.studentBDTableName + " WHERE id = @whereID");
                } else {
                    command.Parameters.AddWithValue("@voorNaam", inObject.newVoorNaam);
                    command.Parameters.AddWithValue("@achterNaam", inObject.newAchterNaam);
                    command.Parameters.AddWithValue("@profileImage", inObject.newBase64ProfileImage);
                    if (inObject.updateFingerprintTemplate) {
                        command.Parameters.AddWithValue("@fingerprintTemplate", inObject.newBase64FingerprintTemplate);
                        command.CommandText = "UPDATE " + settings.studentBDTableName + " SET voorNaam=@voorNaam, achterNaam=@achterNaam, profileImage=@profileImage, fingerprintTemplate=@fingerprintTemplate WHERE ID=@whereID";
                    } else {
                        command.CommandText = "UPDATE " + settings.studentBDTableName + " SET voorNaam=@voorNaam, achterNaam=@achterNaam, profileImage=@profileImage WHERE ID=@whereID";
                    }
                }
                TypeReturnDBChanged response = new TypeReturnDBChanged();
                response.linesAffected = SqlAndWeb.SQLNonQuery(settings.connectionString, command);
                return JsonConvert.SerializeObject(response);
            } catch (Exception ex) {
                TypeReturnError typeForError = new TypeReturnError();
                typeForError.why = "(editDataFromDB)" + ex.Message;
                return JsonConvert.SerializeObject(typeForError);
            }
        }

        //Ok
        /// <summary>
        /// voeg iemand to aan de DB
        /// </summary>
        /// <param name="_inObject"></param>
        /// <returns></returns>
        public static string newEntryToDB(object _inObject) {
            try {
                string wertkWel = JsonConvert.SerializeObject(_inObject);
                TypeSendNewDBEntry entryData = JsonConvert.DeserializeObject<TypeSendNewDBEntry>(wertkWel);
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@voorNaam", entryData.VoorNaam);
                command.Parameters.AddWithValue("@achterNaam", entryData.AchterNaam);
                command.Parameters.AddWithValue("@profileImage", entryData.Base64ProfileImage);
                command.Parameters.AddWithValue("@fingerprintTemplate", entryData.Base64FingerprintTemplate);
                command.CommandText = "INSERT INTO " + settings.studentBDTableName + " (voorNaam, achterNaam, profileImage, fingerprintTemplate) VALUES (@voorNaam,@achterNaam,@profileImage,@fingerprintTemplate)";
                TypeReturnDBChanged returnType = new TypeReturnDBChanged();
                returnType.linesAffected = SqlAndWeb.SQLNonQuery(settings.connectionString, command);
                //now get id of new entry
                SqlCommand comond = new SqlCommand();
                comond.CommandText = "select top 1 ID from " + settings.studentBDTableName + " order by ID desc";
                DataTable queryResult = SqlAndWeb.SQLQuery(settings.connectionString, comond);
                returnType.idOfNewDBEntry = (int)queryResult.Rows[0]["ID"];
                return JsonConvert.SerializeObject(returnType);
            } catch (Exception ex) {
                TypeReturnError typeForError = new TypeReturnError();
                typeForError.why = "(newEntryToDB)" + ex.Message;
                return JsonConvert.SerializeObject(typeForError);
            }
        }

        //Ok 12-400
        /// <summary>
        /// wie is het
        /// </summary>
        /// <param name="_inObject"></param>
        /// <returns></returns>
        public static string wieIsDit(object _inObject) {
            try {
                string wertkWel = JsonConvert.SerializeObject(_inObject);
                TypeAskID IDRequest = JsonConvert.DeserializeObject<TypeAskID>(wertkWel);
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT id,fingerprintTemplate FROM " + settings.studentBDTableName; 
                DataTable queryResult = SqlAndWeb.SQLQuery(settings.connectionString, command);
                List<Person> personList = new List<Person>();
                foreach (DataRow row in queryResult.Rows) {
                    Person person = new Person();
                    Fingerprint fingerprint = new Fingerprint();
                    person.Id = (int)row["id"];
                    string base64FingerTemplate = (string)row["fingerprintTemplate"];
                    fingerprint.Template = Convert.FromBase64String(base64FingerTemplate);
                    person.Fingerprints.Add(fingerprint);
                    personList.Add(person);
                }
                Person unknowPerson = new Person();
                Fingerprint unknowFingerprint = new Fingerprint();
                unknowFingerprint.Template = Convert.FromBase64String(IDRequest.base64FingerprintTemplate);
                unknowPerson.Fingerprints.Add(unknowFingerprint);
                Person wieHetIs = afis.Identify(unknowPerson, personList).FirstOrDefault();
                if (wieHetIs != null) {
                    SqlCommand comond = new SqlCommand();
                    comond.CommandText = "select ID,voorNaam,achterNaam,profileImage from " + settings.studentBDTableName + " where ID=" + wieHetIs.Id;
                    DataTable queryResponse = SqlAndWeb.SQLQuery(settings.connectionString, comond);
                    DataRow theRow = queryResponse.Rows[0];
                    TypeReturnID returnType = new TypeReturnID();
                    returnType.ID = (int)theRow["id"];
                    returnType.voorNaam = (string)theRow["voorNaam"];
                    returnType.achterNaam = (string)theRow["achterNaam"];
                    returnType.base64ProfileImage = (string)theRow["profileImage"];
                    return JsonConvert.SerializeObject(returnType);
                } else {
                    return JsonConvert.SerializeObject(new TypeReturnID());
                }
            } catch (Exception ex) {
                TypeReturnError typeForError = new TypeReturnError();
                typeForError.why = "(wieIsDit)" + ex.Message;
                return JsonConvert.SerializeObject(typeForError);
            }
        }
    }
}