using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FFunc {
    public class SqlAndWeb {

        //Ok
        /// <summary>
        /// http post gives back a class of T type
        /// </summary>
        /// <typeparam name="T">type of object to deserialise json to</typeparam>
        /// <param name="_ClassToSend">class to json and send with http request </param>
        /// <param name="_Address">web api address</param>
        /// <returns></returns>
        public static T httpPostGetObject<T>(object _ClassToSend, string _Address) {
            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("X-Accept", "application/Json");
                Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(_Address, _ClassToSend);
                response.Wait();
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result.Result);
            }
        }

        //Ok 
        /// <summary>
        /// httpPostGetObject met pw en check voor error return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ObjectToSend"></param>
        /// <param name="_Address"></param>
        /// <returns></returns>
        public static T httpPostWithErrorCheckAndPassword<T>(object _objectToSend, string _address, string password) {
            WebSendAndReturnTypes.TypeSendObjectWithPassword sendThis = new WebSendAndReturnTypes.TypeSendObjectWithPassword();
            sendThis.password = password;
            sendThis.typeWithOpdra = _objectToSend;
            string webResponse = httpPostGetObject<string>(sendThis, _address);
            JObject obj = new JObject();

            //Baylife 
            try {
                obj = JObject.Parse(webResponse);
            } catch {
                return JsonConvert.DeserializeObject<T>(webResponse);
            }

            if ((string)obj["ThisType"] == "TypeReturnError") {
                WebSendAndReturnTypes.TypeReturnError errorInfo = JsonConvert.DeserializeObject<WebSendAndReturnTypes.TypeReturnError>(webResponse);
                MessageBox.Show(errorInfo.why, "Http Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            } else {
                return JsonConvert.DeserializeObject<T>(webResponse);
            }
        }

        //Ok notMoved
        /// <summary>
        /// do sql query
        /// </summary>
        /// <param name="_ConnectionString">sql connection string</param>
        /// <param name="_Command">sql command</param>
        /// <returns></returns>
        public static DataTable SQLQuery(string _ConnectionString, SqlCommand _Command) {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection = sqlConnection;
                    sqlConnection.Open();
                    dataTable.Load(_Command.ExecuteReader());
                    return dataTable;
                } catch {
                    return null;
                }
            }
        }

        //Ok notMoved
        /// <summary>
        /// excute non query
        /// </summary>
        /// <param name="_ConnectionString">sql connetion string</param>
        /// <param name="_Command">sql command</param>
        /// <returns></returns>
        public static int SQLNonQuery(string _ConnectionString, SqlCommand _Command) {
            using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString)) {
                try {
                    _Command.Connection = sqlConnection;
                    sqlConnection.Open();
                    return _Command.ExecuteNonQuery();
                } catch {
                    return 0;
                }
            }
        }
        
    }
}
