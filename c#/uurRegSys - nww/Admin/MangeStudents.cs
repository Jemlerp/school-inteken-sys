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

namespace Admin {
    public partial class MangeStudents : Form {

        public MangeStudents(string adress, string password, string comport) {
            InitializeComponent();
            _Adress=adress;
            _Password=password;
            _UsingSerial=true;
        }

        public MangeStudents(string adress, string password) {
            InitializeComponent();
            _Adress=adress;
            _Password=password;
        }

        public string _Password = "";
        public string _Adress = "";
        public bool _UsingSerial = false;

        private void refreshOverview() {
            try {
                funcZ.TResiveWithPosbleError ResponeFromServer = funcZ.webFunc.httpPostWithPassword(new TAdminSendAskAllUsersDataTable(), _Adress, _Password);
                if (ResponeFromServer.isErrorOcured==false) {
                    DataTable erTable = JsonConvert.DeserializeObject<TAdminReturnAllUsersDataTable>(JsonConvert.SerializeObject(ResponeFromServer.expectedResponse)).userDataTable;
                    dataGridView1.DataSource=erTable;
                } else {
                    throw new Exception(ResponeFromServer.errorInfo.errorText);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MangeStudents_Load(object sender, EventArgs e) {

        }

        private void buttonRefreshOverview_Click(object sender, EventArgs e) {
            refreshOverview();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            try {
                textBoxUpdateVNaam.Text = dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.voorNaam].Value.ToString();
                textBoxUpdateANaam.Text =dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.achterNaam].Value.ToString();
                textBoxUpdateNFCID.Text=dataGridView1.SelectedRows[0].Cells[SQLPropertysAndFunc.UserTableNames.NFCID].Value.ToString();
            } catch {

            }
        }
    }
}
