using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace funcZ {
    public class webFunction {

        public static string httpPostGetObject(object _ClassToSend, string _Address) {
            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("X-Accept", "application/Json");
                Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(_Address, _ClassToSend);
                response.Wait();
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(result.Result);
            }
        }

        public static TResiveWithPosbleError httpPostWithPassword(object _classToSend, string _address, string _password) {
            TSendWithPassword send = new TSendWithPassword();
            send.password=_password;
            send.tSend=_classToSend;
            return JsonConvert.DeserializeObject<TResiveWithPosbleError>(httpPostGetObject(send, _address));
        }
    }
}

