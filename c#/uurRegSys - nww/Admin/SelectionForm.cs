using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin {
    public partial class SelectionForm : Form {

        public SelectionForm(string adress, string password, string comport) {
            InitializeComponent();
            _Adress=adress;
            _Password=password;
            _UsingSerial=true;
            _SerialPort=comport;
        }

        public SelectionForm(string adress, string password) {
            InitializeComponent();
            _Adress=adress;
            _Password=password;
        }

        public string _Password = "";
        public string _Adress = "";
        public bool _UsingSerial = false;
        public string _SerialPort = "";

        private void buttonManageStudents_Click(object sender, EventArgs e) {
            MangeStudents form;
            if (_UsingSerial) {
                form=new MangeStudents(_Adress, _Password, _SerialPort);
            } else {
                form=new MangeStudents(_Adress, _Password);
            }
            this.Visible=false;
            form.ShowDialog();
            this.Visible=true;
        }
    }
}
