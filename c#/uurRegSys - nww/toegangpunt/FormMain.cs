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


namespace toegangpunt {
    public partial class FormMain : Form {
        public FormMain(string comport, string apiAdress, string password) {
            InitializeComponent();
            _Comport = comport;
            _ApiAdress = apiAdress;
            _Password = password;
            }

        public string _ApiAdress = "";
        public string _Password = "";
        public string _Comport = "";
        private delegate void handelTextDelegate(string read);
        SerialPort _serial = new SerialPort();

        string getServerStatus() {
            TWrapWithPassword send = new TWrapWithPassword();
            send.tSend = new funcZ.TPing();
            send.password = _Password;


            return "slecht";
            }

        private void FormMain_Load(object sender, EventArgs e) {
            _serial = new SerialPort(_Comport, 9600);
            _serial.DataReceived += new SerialDataReceivedEventHandler(readReadFromCom);
            try { _serial.Open(); } catch { MessageBox.Show("Can't Open Serialport", "Error"); /* gebrt nooit */  }
            }

        private void readReadFromCom(object een, object twee) {
            string x = _serial.ReadLine();
            BeginInvoke(new handelTextDelegate(handleText), x);
            }

        private void handleText(string read) 
            {            
            textBox1.Text = "";
            string eetEenUi = "";
            char[] nummbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
            foreach (char x in read) {
                foreach (char y in nummbers) {
                    if (y == x) { eetEenUi += x; break; }
                    }
                }
            string eetZelfEenUi = eetEenUi.TrimStart();
            Stopwatch stopwa = new Stopwatch();
            stopwa.Start();
            TReturnInfoForDisplay awns = Web.sendNewRead(_ApiAdress, _Password, eetZelfEenUi);
            stopwa.Stop();
            if (awns.error) {
                textBox1.Text += "ERROR \r\n " + awns.errorText;
                } else {
                textBox1.Text += " voornaam=" + awns.voorNaam + " \r\nachternaam=" + awns.achterNaam + " \r\nnfccardui=" + awns.nfCode + " \r\nID=" + awns.ID + "\r\nTime=" + stopwa.ElapsedMilliseconds.ToString() + " \r\naanwezig =" + awns.isAanwezig;
                label1.Text = awns.voorNaam + " " + awns.achterNaam;
                label2.Text = awns.ID + " - " + awns.nfCode;
                if (awns.isAanwezig) {
                    label3.Text = "INGETEKEND";
                    } else {
                    label3.Text = "UITGETEKEND";
                    }
                }
            }

    }
    }
