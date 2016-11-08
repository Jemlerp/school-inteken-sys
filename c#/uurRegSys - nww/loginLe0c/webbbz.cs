using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using funcZ;
using Newtonsoft.Json;

namespace loginLe0c {
    class webbbz {
        public static T httpPostGetObject<T>(object _ClassToSend, string _Address) {
            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("X-Accept", "application/Json");
                Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(_Address, _ClassToSend);
                response.Wait();
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result.Result);
                }
            }

        public static TReturnCurrentStateForDisplay wetmyweb(string addres, string password, TAskCurrentStateForDisplay versuur) {
            TWrapWithPassword etsend = new TWrapWithPassword();
            etsend.password = password;
            etsend.tSend = versuur;
            string webresponse = httpPostGetObject<string>(etsend, addres);
            TReturnCurrentStateForDisplay retuurn;
            try {
                retuurn = JsonConvert.DeserializeObject<TReturnCurrentStateForDisplay>(webresponse);
                } catch {
                retuurn = new TReturnCurrentStateForDisplay();
                }
            return retuurn;
            }

        }
    }
