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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void checkBoxUserSerialPort_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxUserSerialPort.Checked) {
                panelSerial.Enabled=false;
                listBox1.Items.Clear();
            } else {
                panelSerial.Enabled=true;
                refreshSerialportsList(null,null);
            }
        }

        private void refreshSerialportsList(object sender, EventArgs e) {
            listBox1.Items.Clear();
            string[] comlist = SerialPort.GetPortNames();
            foreach (string com in comlist) {
                listBox1.Items.Add(com);
            }
            if (listBox1.Items.Count>0) { listBox1.SelectedItem=listBox1.Items[0]; }
        }

        private void testSerialPort(object sender, EventArgs e) {
            try {
                SerialPort testPort = new SerialPort((string)listBox1.SelectedItem, 9600);
                testPort.Open();
                testPort.Close();
                MessageBox.Show("successful");
            }catch(Exception ex) {
                MessageBox.Show("Connection Failed");
            }
        }

        private void testServerConnection(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.Items.Count>0) {
                buttonTestSerial.Enabled=true;
            }else {
                buttonTestSerial.Enabled=false;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            SelectionForm form;
            if (checkBoxUserSerialPort.Checked) {
                form=new SelectionForm(textBoxAdress.Text, textBoxPassword.Text, (string)listBox1.SelectedItem);
            } else {
               form = new SelectionForm(textBoxAdress.Text, textBoxPassword.Text);
            }
            this.Visible=false;
            form.ShowDialog();
            this.Close();
        }
    }
}
