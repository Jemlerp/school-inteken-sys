using System;
using System.Collections;
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

namespace Admin {
    public partial class MangeStudents : Form {

        public MangeStudents(string adress, string password, string comport) {
            InitializeComponent();
            _Adress = adress;
            _Password = password;
            _UsingSerial = true;
            _SerialPortName=comport;
        }

        public MangeStudents(string adress, string password) {
            InitializeComponent();
            _Adress = adress;
            _Password = password;
        }

        public string _SerialPortName = "";
        public string _Password = "";
        public string _Adress = "";
        public bool _UsingSerial = false;

        private void refreshOverview() {
            try {
                TAdminSendAskADataTable req = new TAdminSendAskADataTable();
                req.userTable=true;
                funcZ.TResiveWithPosbleError ResponeFromServer = funcZ.webFunc.httpPostWithPassword(req, _Adress, _Password);
                if (ResponeFromServer.isErrorOcured == false) {
                    DataTable erTable = JsonConvert.DeserializeObject<TAdminReturnADataTable>(JsonConvert.SerializeObject(ResponeFromServer.expectedResponse)).DataTable;

                    //for (int x = 0; x < erTable.Rows.Count; x++) {
                    //    if (!(bool)erTable.Rows[x][SQLPropertysAndFunc.UserTableNames.isVanSchoolAf]) {
                    //        erTable.Rows[x][SQLPropertysAndFunc.UserTableNames.isVanSchoolAf] = "false";
                    //    } else {
                    //        erTable.Rows[x][SQLPropertysAndFunc.UserTableNames.isVanSchoolAf] = "true";
                    //    }

                    //}

                    dataGridView1.DataSource = erTable;
                } else {
                    throw new Exception(ResponeFromServer.errorInfo.errorText);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MangeStudents_Load(object sender, EventArgs e) {
            if (!_UsingSerial) {
                buttonNewGetNFCIDFromSerial.Enabled=false;
                buttonUpdateGetNFCIDFromSerial.Enabled=false;
            }
        }

        private void buttonRefreshOverview_Click(object sender, EventArgs e) {
            refreshOverview();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            try {
                textBoxUpdateVNaam.Text = dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.voorNaam].Value.ToString();
                textBoxUpdateANaam.Text = dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.achterNaam].Value.ToString();
                textBoxUpdateNFCID.Text = dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.NFCID].Value.ToString();
                textBoxUpdateID.Text = dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.ID].Value.ToString();
                checkBoxUpdateIsVanSchoolAf.Checked = (bool)dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.isVanSchoolAf].Value;
            } catch {

            }
        }

        private void buttonUpdateSaveUpdate_Click(object sender, EventArgs e) {
            funcZ.TAdminSendChangeUsersTable request = new TAdminSendChangeUsersTable();
            request.isNewUser = false;
            request.isVanSchoolAf = checkBoxUpdateIsVanSchoolAf.Checked;
            request.voornaam = textBoxUpdateVNaam.Text;
            request.achternaam = textBoxUpdateANaam.Text;
            request.NFCID = textBoxUpdateNFCID.Text;
            request.toEditUserId = Convert.ToInt32(textBoxUpdateID.Text);
            funcZ.TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Adress, _Password);
            if (response.isErrorOcured) {
                MessageBox.Show(response.errorInfo.errorText);
            } else {
                refreshOverview();
            }
        }

        private void buttonNewSave_Click(object sender, EventArgs e) {
            if (textBoxNewVNaam.Text!="") {
                TAdminSendChangeUsersTable request = new TAdminSendChangeUsersTable();
                request.isNewUser=true;
                request.voornaam=textBoxNewVNaam.Text;
                request.achternaam=textBoxNewANaam.Text;
                request.NFCID=textBoxNewNFCID.Text;
                request.isVanSchoolAf=false;
                TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Adress, _Password);
                if (response.isErrorOcured) {
                    MessageBox.Show(response.errorInfo.errorText);
                } else {
                    refreshOverview();
                }
            } else {
                MessageBox.Show("moet een naam geven");
            }
        }

        private void buttonNewGetNFCIDFromSerial_Click(object sender, EventArgs e) {
            getNFCIDFromSerial form = new getNFCIDFromSerial(_SerialPortName);
            form.ShowDialog();
            if (form._goNFCID) {
                textBoxNewNFCID.Text=form._NFCID;
            }
        }

        private void buttonUpdateGetNFCIDFromSerial_Click(object sender, EventArgs e) {
            getNFCIDFromSerial form = new getNFCIDFromSerial(_SerialPortName);
            form.ShowDialog();
            if (form._goNFCID) {
                textBoxUpdateNFCID.Text=form._NFCID;
            }
        }
    }
}
