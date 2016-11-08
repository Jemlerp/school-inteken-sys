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

namespace toegangpunt {
    public partial class FormStartup : Form {
        public FormStartup() {
            InitializeComponent();
            
        }

        private void button_Start_Click(object sender, EventArgs e) {
            try {
                FormMain form = new FormMain(listBox_comnport.SelectedItem.ToString(), textBox_apiAdress.Text, textBox_wachtwoord.Text);
                this.Visible = false;
                form.ShowDialog();
                this.Close();
            }catch {
                MessageBox.Show("No Comport Selected", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void FormStartup_Load(object sender, EventArgs e) {
            refreshListbox(null, null);
        }

        private void refreshListbox(object sender, EventArgs e) {
            listBox_comnport.Items.Clear();
            string[] comlist = SerialPort.GetPortNames();
            foreach (string com in comlist) {
                listBox_comnport.Items.Add(com);
            }
            if(listBox_comnport.Items.Count > 0) { listBox_comnport.SelectedItem = listBox_comnport.Items[0]; }
        }
    }
}
