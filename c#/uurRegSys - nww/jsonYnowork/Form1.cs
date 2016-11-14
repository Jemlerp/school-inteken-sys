using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funcZ;
using Newtonsoft.Json;

namespace jsonYnowork {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            TResiveWithPosbleError tttst = new TResiveWithPosbleError();
            tttst.errorInfo=new TError();
            tttst.errorInfo.errorText="test kabnker";
            tttst.expectedResponse=new TReturnDisplayInfoForJustReadNFCCard();
            string kanker = JsonConvert.SerializeObject(tttst);

            string dsdsdsd = "\"{\\\"SendAndRecieveTypesEnumValue\\\":0,\\\"errorInfo\\\":{\\\"SendAndRecieveTypesEnumValue\\\":2,\\\"errorText\\\":\\\"test kabnker\\\"},\\\"isErrorOcured\\\":false,\\\"expectedResponse\\\":{\\\"SendAndRecieveTypesEnumValue\\\":4,\\\"doetUitteken\\\":false,\\\"doetInteken\\\":false,\\\"doetAnuleerUitteken\\\":false,\\\"voornaam\\\":null,\\\"achternaam\\\":null,\\\"tijdInteken\\\":\\\"00:00:00\\\",\\\"tijdUiteken\\\":\\\"00:00:00\\\",\\\"dateOfToday\\\":\\\"0001-01-01T00:00:00\\\",\\\"ID\\\":0,\\\"NFCID\\\":null,\\\"DateTimeNow\\\":\\\"0001-01-01T00:00:00\\\"}}\"";


                try {
                TResiveWithPosbleError govekankerhkawknererkndfghbhjkuaser = JsonConvert.DeserializeObject<TResiveWithPosbleError>(kanker);
                button1.Text="werk";
            } catch {
                button1.Text="kanker kapot";
            }

            int kan = 0;

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
