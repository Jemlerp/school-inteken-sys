using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeChangesToDB {
    public partial class StartupForm : Form {
        public StartupForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Form1 f1 = new Form1(textBox2.Text);
            this.Visible = false;
            f1.ShowDialog();
            this.Close();            
        }
    }
}
