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

namespace Inteken {
    public partial class setPortPaswordAndAddres : Form {
        public setPortPaswordAndAddres() {
            InitializeComponent();
        }

        private void setPortPaswordAndAddres_Load(object sender, EventArgs e) {
            button2_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();
            string[] comlist = SerialPort.GetPortNames();
            foreach (string com in comlist) {
                listBox1.Items.Add(com);
            }
            if (listBox1.Items.Count>0) { listBox1.SelectedItem=listBox1.Items[0]; }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Visible=false;
            erForm elErForm = new erForm(textBoxAddr.Text, textBoxPW.Text, (string)listBox1.SelectedItem);
            elErForm.ShowDialog();
            this.Close();
        }
    }
}
