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
using NewCrossFunctions;
using Newtonsoft.Json;

namespace NewIntekenForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            //test server connection/login gegevens
            try {
                NetComunicationTypesAndFunctions.ServerResponse response = NetComunicationTypesAndFunctions.WebRequest(new NetComunicationTypesAndFunctions.ServerRequestSqlDateTime(), textBoxUserName.Text, textBoxPassword.Text, textBoxApiAddres.Text);
                if (response.IsErrorOcurred) {
                    if (MessageBox.Show(response.ErrorInfo.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop)==DialogResult.Retry) {
                        buttonStart_Click(null, null);
                    } else {
                        return;
                    }
                }
            } catch {
                if (MessageBox.Show("Kan Niet Met Server Verbinden", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop)==DialogResult.Retry) {
                    buttonStart_Click(null, null);
                } else {
                    return;
                }
                return;
            }

            //do
            try {
                ArrrrFormcs form = new ArrrrFormcs((string)listBox1.SelectedItem, textBoxApiAddres.Text, textBoxUserName.Text, textBoxPassword.Text,checkBoxStartWindowed.Checked);
                Visible=false;
                form.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private bool testSerialPort(string port) {
            try {
                SerialPort porrt = new SerialPort(port, 9600);
                porrt.Open();
                porrt.Close();
                return true;
            } catch {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            buttonRefreshSerialPorts_Click(null, null);
        }

        private void buttonRefreshSerialPorts_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();
            string[] comlist = SerialPort.GetPortNames();
            foreach (string com in comlist) {
                listBox1.Items.Add(com);
            }
            if (listBox1.Items.Count>0) { listBox1.SelectedItem=listBox1.Items[0]; }
        }
    }
}
