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
using NewCrossFunctions;

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
        private delegate void updateOverzichtDelegate();

        private NetComunicationTypesAndFunctions.ServerResponse webbbbrrrrrry(object request) {
            return NetComunicationTypesAndFunctions.WebRequest(request, _Username, _Password, _ApiAddres);
        }

        private void ArrrrFormcs_Load(object sender, EventArgs e) {
            try {
                _Serialport.Open();
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
            _TimerCleanUserInfoScreen.Stop();
            labelInOfUitGetekend.Text="<In/Uit>";
            labelNaam.Text="<Naam>";
        }

        void updateOverzight() {
            NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate request = new NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate();
            request.useToday=true;
            NetComunicationTypesAndFunctions.ServerResponse response = webbbbrrrrrry(request);

        }

        void ReloadEtOverzicht_Event(object nee,object ja) {
            BeginInvoke(new updateOverzichtDelegate(updateOverzight));
        }

        void HandelNfcScan(string _read) {
            NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit request = new NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit();
            request.NFCCode=_read;
            NetComunicationTypesAndFunctions.ServerResponse response = webbbbrrrrrry(request);
            if (response.IsErrorOcurred) {
                MessageBox.Show(response.ErrorInfo.ErrorMessage);
            } else {
                NetComunicationTypesAndFunctions.ServerResponseInteken intekenResponse = JsonConvert.DeserializeObject<NetComunicationTypesAndFunctions.ServerResponseInteken>(JsonConvert.SerializeObject(response));
                labelNaam.Text=intekenResponse.TheUserWithEntryInfo.userN.VoorNaam+" "+intekenResponse.TheUserWithEntryInfo.userN.AchterNaam;
                if (intekenResponse.uitekenengeanuleerd) { labelInOfUitGetekend.Text="Uitekenen Geanuleerd"; }
                if (intekenResponse.ingetekened) { labelInOfUitGetekend.Text="Je Bent Nu Ingetekend"; }
                if (intekenResponse.uitgetekened) { labelInOfUitGetekend.Text="Je Bent Nu Uitgetekend"; }
                _TimerCleanUserInfoScreen.Start();
            }
        }

        void readReadFromSerial(object _ebjec, object _tokdekmak) {
            string Read = _Serialport.ReadLine();            
            BeginInvoke(new handelTextDelegate(HandelNfcScan), ForFormHelperFunctions.SerialReadToNormal(Read));
        }

    }
}
