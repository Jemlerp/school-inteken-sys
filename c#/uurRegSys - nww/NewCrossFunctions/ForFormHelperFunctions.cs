using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
