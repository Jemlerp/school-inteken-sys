using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewCrossFunctions;
using Newtonsoft.Json;
using System.IO.Ports;

namespace NewIntekenForm {
    public partial class ArrrrFormcs : Form {

        public ArrrrFormcs(string _serkialPort, string _apiAdress, string _username, string _password) {
            InitializeComponent();
            _Serialport=new SerialPort(_serkialPort, 9600);
            _ApiAddres=_apiAdress;
            _Username=_username;
            _Password=_password;
        }

        string _Username;
        string _Password;
        string _ApiAddres;
        SerialPort _Serialport = new SerialPort();
        Timer _TimerCleanUserInfoScreen = new Timer();
        Timer _TimerReloadOverzicht = new Timer();
        private delegate void handelTextDelegate(string read);
        private delegate void updateOverzichtDelegate(bool reloadData);

        private void ArrrrFormcs_Load(object sender, EventArgs e) {
            try {
                //_Serialport.Open();
                _Serialport.DataReceived+=new SerialDataReceivedEventHandler(readReadFromSerial);
                _TimerCleanUserInfoScreen.Interval=4200;
                _TimerReloadOverzicht.Interval=42000;
                _TimerCleanUserInfoScreen.Tick+=new EventHandler(ClearUserInfo_Event);
                _TimerReloadOverzicht.Tick+=new EventHandler(ReloadEtOverzicht_Event);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        void ClearUserInfo_Event(object nee, object ja) {

        }

        void ReloadEtOverzicht_Event(object nee,object ja) {

        }

        void HandelNfcScan(string _read) {

        }

        void readReadFromSerial(object _ebjec, object _tokdekmak) {
            string Read = _Serialport.ReadLine();
            ForFormHelperFunctions.SerialReadToNormal(Read);
        }
    }
}
