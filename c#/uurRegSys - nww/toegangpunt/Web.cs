using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using funcZ;
using System.Windows.Forms;

namespace toegangpunt {
    static class Web {

        public static T httpPostGetObject<T>(object _ClassToSend, string _Address) {
            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("X-Accept", "application/Json");
                Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(_Address, _ClassToSend);
                response.Wait();
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result.Result);
                }
            }

        public static TReturnInfoForDisplay sendNewRead(string _address, string _password, string _Read) {
            TSendNewIDRead sendInfo = new TSendNewIDRead();
            sendInfo.ID = _Read;
            TWrapWithPassword send = new TWrapWithPassword();
            send.password = _password;
            send.tSend = sendInfo;
            string webResponse = httpPostGetObject<string>(send, _address);
            TReturnInfoForDisplay retuu = new TReturnInfoForDisplay();
            try {
                retuu = JsonConvert.DeserializeObject<TReturnInfoForDisplay>(webResponse);
                } catch {
                retuu.error = true;
                retuu.errorText = "unexpected response from server";
                }
            return retuu;
            }
        }
    }
