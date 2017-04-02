using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewNewAdmin {
    public partial class FormInterme : Form {
        public FormInterme(DateTime _dateToday, string _username, string _password, string _address) {
            InitializeComponent();
            _UserName = _username;
            _Password = _password;
            _UserName = _username;
            _DateToday = _dateToday;
            _Address = _address;
        }

        DateTime _DateToday;
        string _Password = "";
        string _Address = "";
        string _UserName = "";
    }
}
