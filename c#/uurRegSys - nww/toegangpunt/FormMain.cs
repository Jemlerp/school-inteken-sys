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
using System.IO.Ports;
using System.Diagnostics;
using Newtonsoft.Json;


namespace toegangpunt {
    public partial class FormMain : Form {
        public FormMain(string comport, string apiAdress, string password) {
            InitializeComponent();
            _Comport=comport;
            _ApiAdress=apiAdress;
            _Password=password;
        }

        public string _ApiAdress = "";
        public string _Password = "";
        public string _Comport = "";
        private delegate void handelTextDelegate(string read);
        SerialPort _serial = new SerialPort();

        private void FormMain_Load(object sender, EventArgs e) {
            _serial=new SerialPort(_Comport, 9600);
            _serial.DataReceived+=new SerialDataReceivedEventHandler(readReadFromCom);
            try { _serial.Open(); } catch { MessageBox.Show("Can't Open Serialport", "Error"); /* gebrt nooit */  }
        }

        private void readReadFromCom(object een, object twee) {
            string x = _serial.ReadLine();
            BeginInvoke(new handelTextDelegate(handleText), x);
        }

        private void handleText(string read) {
            textBox1.Text="";
            string eetZelfEenUi = funcZ.readingFromNFCCard.serialReadToNormal(read);

            TNFCCardScan scan = new TNFCCardScan();
            scan.ID=eetZelfEenUi;
            TResiveWithPosbleError awns = webFunction.httpPostWithPassword(scan, _ApiAdress, _Password);
            if (awns.isErrorOcured) {
                MessageBox.Show(awns.errorInfo.errorText);
            } else {
                TReturnDisplayInfoForJustReadNFCCard kkkk = JsonConvert.DeserializeObject<TReturnDisplayInfoForJustReadNFCCard>(JsonConvert.SerializeObject(awns.expectedResponse));
                label1.Text=kkkk.voornaam+" "+kkkk.achternaam;
                label2.Text=kkkk.ID+" ||||| "+kkkk.NFCID;
                label3.Text=$"inteken:{kkkk.doetInteken}.  uitteken:{kkkk.doetUitteken}.  anhuleeruitken:{kkkk.doetAnuleerUitteken}.";
                textBox1.Text=$"voornaam = {kkkk.voornaam} \r\n achtenaam = {kkkk.achternaam} \r\n inteken {kkkk.doetInteken}.\r\n uitteken {kkkk.doetUitteken}.\r\n anuleeruiteken {kkkk.doetAnuleerUitteken}\r\n id = {kkkk.ID}\r\n nfcid = {kkkk.NFCID}\r\n tijdinteken = {kkkk.tijdInteken.ToString()}\r\n tijduiteken = {kkkk.tijdUiteken.ToString()}\r\n datetodayt = {kkkk.dateOfToday.ToString()}";
            }
        }
    }
}
    
