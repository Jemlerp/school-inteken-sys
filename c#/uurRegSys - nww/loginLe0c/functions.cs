using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using funcZ;
using Newtonsoft.Json;

namespace loginLe0c {
    class functions {

        public static TReturnAanwezigheidsOverzigtVanVandaag wetmyweb(string addres, string password, TAskAanwezigheidsOverzigtVanVandaag versuur) {
            TWrapWithPassword etsend = new TWrapWithPassword();
            etsend.password = password;
            etsend.tSend = versuur;
            string webresponse = funcZ.webFunction.httpPostGetObject<string>(etsend, addres);
            TReturnAanwezigheidsOverzigtVanVandaag retuurn;
            try {
                retuurn = JsonConvert.DeserializeObject<TReturnAanwezigheidsOverzigtVanVandaag>(webresponse);
                } catch {
                retuurn = new TReturnAanwezigheidsOverzigtVanVandaag();
                }
            return retuurn;
            }

        }
    }
