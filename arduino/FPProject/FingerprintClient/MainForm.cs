using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFunc.WebSendAndReturnTypes;
using FFunc;
using System.Diagnostics;
using System.IO.Ports;

namespace FingerprintClient {

    public partial class MainForm : Form {

        public MainForm(string Comport, string Webaddres) {
            InitializeComponent();
            _webAddress = Webaddres;
            _serialPort = new SerialPort(Comport, 115200);
        }

        private static string _wachtwoord = "testWachtwoord";
        public string _webAddress;
        public Stopwatch _stopWatch = new Stopwatch();
        public SerialPort _serialPort;
        public Timer _timerCleanUI = new Timer();
        public Timer _timerStopReceivingImage = new Timer();       
        public bool _busyReceivingImage = false;
        public bool _stopReceivingImage = false;
        private delegate void handelImageDelegate(Bitmap receivedImage);
        public string _imageTransferTime;
        public string _processTime;

        private void receiveImage(object a, object b) {
            if (!_busyReceivingImage) {
                _busyReceivingImage = true;
                _stopWatch.Restart();
                _timerStopReceivingImage = new Timer();
                _timerStopReceivingImage.Interval = 4500;
                _timerStopReceivingImage.Tick += new EventHandler(stopReceivingImageEvent);
                _timerStopReceivingImage.Start();
                List<byte> bytelist = new List<byte>();
                while (bytelist.Count < 36870) {
                    if (_stopReceivingImage) { return; }
                    int bytes = _serialPort.BytesToRead;
                    byte[] buffer = new byte[bytes];
                    _serialPort.Read(buffer, 0, bytes);
                    foreach (byte x in buffer) { bytelist.Add(x); }
                    if(bytelist.Count == 0) { _busyReceivingImage = false; return; }
                }
                _timerStopReceivingImage.Stop();
                Bitmap receivedImage = Conversion.zmf20ByteArrayToImage(bytelist.ToArray(),17);
                _stopWatch.Stop();
                _imageTransferTime = _stopWatch.ElapsedMilliseconds.ToString();
                _busyReceivingImage = false;
                BeginInvoke(new handelImageDelegate(handleImage), receivedImage);
            }
        }

        private void stopReceivingImageEvent(object a, object b) {
            _timerStopReceivingImage.Stop();
            _stopReceivingImage = true;
        }

        private void handleImage(Bitmap fingerprintimage) {
            _stopWatch.Restart();
            pictureBox1.Image = fingerprintimage; // remove&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            TypeAskID request = new TypeAskID();
            request.base64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate(fingerprintimage));
            TypeReturnID awnser = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnID>(request, _webAddress, _wachtwoord);
            _stopWatch.Stop();
            _processTime = _stopWatch.ElapsedMilliseconds.ToString();
            if (awnser.ID != 0) {
                label2.Text = "ID: " + awnser.ID.ToString();
                label3.Text = "voornaam: " + awnser.voorNaam;
                label4.Text = "achternaam: " + awnser.achterNaam;
                label5.Text = "ImageTransferTime=" + _imageTransferTime;
                label6.Text = "ProcessTime=" + _processTime;
                label7.Text = "Total=" + (Convert.ToInt32(_imageTransferTime) + Convert.ToInt32(_processTime)); 
                //pictureBox1.Image = ServerFunctions.SFuncs.getImageFromBase64String(awnser.base64ProfileImage); &&&&&&&&&&&&&&&&&
                showExtaInfo(awnser);
            } else {
                label2.Text = "ID: unknown";
                label3.Text = "voornaam: kanNietVinden";
                label4.Text = "achternaam: kanNietVinden";
                label5.Text = "ImageTransferTime=" + _imageTransferTime;
                label6.Text = "ProcessTime=" + _processTime;
                label7.Text = "Total=" + (Convert.ToInt32(_imageTransferTime) + Convert.ToInt32(_processTime));
                //pictureBox1.Image = null;
            }
            _timerCleanUI.Start();
        }

        private void showExtaInfo(TypeReturnID id) {
            //hier dingen met uur reg server
        }

        private void clearUI(object ja, object nee) {
            _timerCleanUI.Stop();
            label2.Text = "ID:";
            label3.Text = "voornaam:";
            label4.Text = "achternaam:";
            pictureBox1.Image = null;
            label7.Text = "Total=";
            label6.Text = "ProcessTime=";
            label7.Text = "ImageTransferTime=";
        }

        private void MainForm_Load(object sender, EventArgs e) {
            _serialPort.WriteBufferSize = 40000;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(receiveImage);
            _serialPort.Open();
            _timerCleanUI.Tick += new EventHandler(clearUI);
            _timerCleanUI.Interval = 5000;
        }
    }

}
