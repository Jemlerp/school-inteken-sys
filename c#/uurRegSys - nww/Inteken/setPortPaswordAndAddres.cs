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
            
        }



        private void button1_Click(object sender, EventArgs e) {
            this.Visible=false;
            erForm elErForm = new erForm(textBoxAddr.Text, textBoxPW.Text);
            elErForm.ShowDialog();
            this.Close();
        }
    }
}
