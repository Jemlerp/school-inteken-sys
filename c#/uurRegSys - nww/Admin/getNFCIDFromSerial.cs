using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Admin {
    public partial class getNFCIDFromSerial : Form {

        public getNFCIDFromSerial(string serialport) {
            InitializeComponent();
            _SerialPort=new SerialPort(serialport, 9600);
        }

        SerialPort _SerialPort;

        public string _NFCID = "";
        public bool _goNFCID = false;

        delegate void readings(string read);

        private void getNFCIDFromSerial_Load(object sender, EventArgs e) {
            try {
                _SerialPort.Open();
                _SerialPort.DataReceived+=new SerialDataReceivedEventHandler(readReadFromSerial);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void readReadFromSerial(object nee, object ookNee) {
            string read = _SerialPort.ReadLine();
            BeginInvoke(new readings(handleRead), funcZ.readingFromNFCCard.serialReadToNormal(read));
        }

        private void handleRead(string read) {
            textBox1.Text=read;
            buttonnnnn.Text="use";
        }

        private void buttonnnnn_Click(object sender, EventArgs e) {
            _NFCID=textBox1.Text.Trim();
            _goNFCID=true;
            this.Close();
        }

        private void getNFCIDFromSerial_FormClosing(object sender, FormClosingEventArgs e) {
            _SerialPort.Close();
        }
    }
}
