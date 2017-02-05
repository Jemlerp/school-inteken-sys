using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.NetworkInformation;

namespace FingerprintClient {
    public partial class StartupForm : Form {
        public StartupForm() {
            InitializeComponent();
        }
        public static string fileSavelocation = "comportPreset.txt";

        string webAddr = "";
        string comPort = "";

        private void StartupForm_Load(object sender, EventArgs e) {
            if (File.Exists(fileSavelocation)) {
                string[] ffile = File.ReadAllText(fileSavelocation).Split('@');
                comPort = ffile[0];
                webAddr = ffile[1];
                if (canMakeConnectionToComPort(comPort)) {
                    if (canMakeConnectionToServer(webAddr)) {
                        doeHetDan();
                    } else {
                        labelMessage.Text = "Error Connecting To API @ " + webAddr;
                    }
                } else {
                    labelMessage.Text = "Error Connecting To Comport " + comPort;
                }
            } else {
                labelMessage.Text = "Settings";
                foreach(string x in SerialPort.GetPortNames()) {
                    listBox1.Items.Add(x);
                    listBox1.SelectedIndex = 0;
                }
            }
        }

        public bool canMakeConnectionToComPort(string comport) {
            try {
                using (SerialPort port = new SerialPort(comport, 115200)) {
                    port.Open();
                    port.Close();
                }
                return true;
            } catch {
                return false;
            }
        }

        public bool canMakeConnectionToServer(string serverAddres) {

            return true; // no such host is known
            /*
            if (serverAddres != "") {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(serverAddres, timeout, buffer, options);
                if (reply.Status == IPStatus.Success) {
                    return true;
                }
            }
            return false;
            */
        }

        public void doeHetDan() {
            MainForm mainForm = new MainForm(comPort, webAddr);
            Visible = false;
            mainForm.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            comPort = listBox1.SelectedItem.ToString();
            webAddr = textBox1.Text;
            if (canMakeConnectionToComPort(comPort)) {
                if (canMakeConnectionToServer(webAddr)) {
                    File.WriteAllText(fileSavelocation, comPort + "@" + webAddr);
                    doeHetDan();
                } else {
                    labelMessage.Text = "Error Connecting To API @ " + webAddr;
                }
            } else {
                labelMessage.Text = "Error Connecting To Comport " + comPort;
            }
        }
    }


}
