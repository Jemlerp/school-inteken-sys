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
using Newtonsoft.Json;

namespace Inteken {
    public partial class zetAfwezigForm : Form {

        public zetAfwezigForm(SQLPropertysAndFunc.UserTableTableEntry userEntry, SQLPropertysAndFunc.AfwezigTableTableEntry afwezigEntry, string password, string apiaddres) {
            InitializeComponent();
            _GotAfwezigEntry=true;
            _UserEntry=userEntry;
            _AfwezigEntry=afwezigEntry;
            _Password=password;
            _Address=apiaddres;
        }

        public zetAfwezigForm(SQLPropertysAndFunc.UserTableTableEntry userEntry, string password, string apiadress) {
            InitializeComponent();
            _GotAfwezigEntry=false; 
            _UserEntry=userEntry;
            _Password=password;
            _Address=apiadress;
        }

        string _Password;
        string _Address;
        bool _GotAfwezigEntry;
        SQLPropertysAndFunc.UserTableTableEntry _UserEntry;
        SQLPropertysAndFunc.AfwezigTableTableEntry _AfwezigEntry;
        string andereRedenVoorAfwezighijdBackUpForJeWeet = "";

        private void zetAfwezigForm_Load(object sender, EventArgs e) {
            label3.Text=_UserEntry.voorNaam+" "+_UserEntry.achterNaam;
            if (_GotAfwezigEntry) {
                if (_AfwezigEntry.IsAndereReden) { comboBox1.SelectedItem=comboBox1.Items[5]; textBox1.Text+=_AfwezigEntry.AnderenRedenVoorAfwezigihijd; }
                if (_AfwezigEntry.IsExcurtie) { comboBox1.SelectedItem=comboBox1.Items[4]; }
                if (_AfwezigEntry.IsFlexiebelverlof) { comboBox1.SelectedItem=comboBox1.Items[3]; }
                if (_AfwezigEntry.IsStudieverlof) { comboBox1.SelectedItem=comboBox1.Items[2]; }
                if (_AfwezigEntry.IsZiek) { comboBox1.SelectedItem=comboBox1.Items[1]; }
            } else {
                comboBox1.SelectedItem=comboBox1.Items[0];
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            TRequestChangeAfwezigTable request = new TRequestChangeAfwezigTable();
            request.AnderenRedenVoorAfwezigihijd="";
            try {
                switch (comboBox1.SelectedIndex) {
                    case 0:
                        if (textBox1.Text=="") {
                            request.clearRecordOfAfwezigVandaag=true;
                        }
                        break;
                    case 1:
                        request.IsZiek=true;
                        break;
                    case 3:
                        request.IsFlexiebelverlof=true;
                        break;
                    case 2:
                        request.IsStudieverlof=true;
                        break;
                    case 4:
                        request.IsExcurtie=true;
                        break;
                    case 5:
                        request.IsAnderereden= true;
                        if (textBox1.Text=="") {
                            throw new Exception("Provide Descripton");
                        } else {
                            request.AnderenRedenVoorAfwezigihijd=textBox1.Text;
                        }
                        break;
                }
                request.fromUserID=_UserEntry.ID;
                TResiveWithPosbleError response = webFunction.httpPostWithPassword(request, _Address, _Password);
                if (response.isErrorOcured) {
                    throw new Exception(response.errorInfo.errorText);
                } else {
                    TRespondChangeAfwezighijdTable jaOfNee = JsonConvert.DeserializeObject<TRespondChangeAfwezighijdTable>(JsonConvert.SerializeObject(response.expectedResponse));
                    if (jaOfNee.success) {
                        this.Close();
                    } else {
                        throw new Exception("Did Not Save Changes");
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if(comboBox1.SelectedItem.ToString()!="Anders") {
                textBox1.Enabled=false;
                andereRedenVoorAfwezighijdBackUpForJeWeet=textBox1.Text;
                textBox1.Text="";
            } else {
                textBox1.Enabled=true;
                textBox1.Text=andereRedenVoorAfwezighijdBackUpForJeWeet;
            }
        }
    }
}
