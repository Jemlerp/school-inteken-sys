using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace funcZ {
    public class webFunction {

        public static T httpPostGetObject<T>(object _ClassToSend, string _Address)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Accept", "application/Json");
                Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(_Address, _ClassToSend);
                response.Wait();
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result.Result);
            }

        }
    }
}
