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
using Newtonsoft.Json;
using funcZ;
using System.Diagnostics;

namespace Inteken {
    public partial class erForm : Form {

        public erForm(string apiAddress, string password) {
            InitializeComponent();
            _Password=password;
            _Address=apiAddress;
        }


        Timer _TimerReloadOverzicht = new Timer();

        string _Password;
        string _Address;
        dataTableHelpFunc _ErFunc = new dataTableHelpFunc();
        dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry _CurrentlySelectedUser = new dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry();
        List<dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry> _DatalistLatestOverviewInfo = new List<dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry>();
        List<dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry> _DatalistSearchResults = new List<dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry>();
        private delegate void handelTextDelegate(string read);
        private delegate void updateOverzichtDelegate(bool reloadData);

        private void erForm_Load(object sender, EventArgs e) {
            try {
                dateTimePickerTijdIn.ShowUpDown=true;
                dateTimePickerTijdIn.CustomFormat="HH:mm:ss tt";
                dateTimePickerTijdIn.Format=System.Windows.Forms.DateTimePickerFormat.Custom;

                dateTimePickerTimeUit.ShowUpDown=true;
                dateTimePickerTimeUit.CustomFormat="HH:mm:ss tt";
                dateTimePickerTimeUit.Format=System.Windows.Forms.DateTimePickerFormat.Custom;

                _TimerReloadOverzicht.Interval=42000;
                _TimerReloadOverzicht.Tick+=new EventHandler(timerEventReloadOverzicht);
                _TimerReloadOverzicht.Start();
                UpdateOverzichtLists(true);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void timerEventReloadOverzicht(object een, object twee) {
            BeginInvoke(new updateOverzichtDelegate(UpdateOverzichtLists), true);
        }

        private void UpdateOverzichtLists(bool reloadFromServer) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int _SelectedRowNummber = 9999;
            if (dataGridView1.CurrentCell!=null) {
                _SelectedRowNummber=dataGridView1.CurrentCell.RowIndex;
            }
            _TimerReloadOverzicht.Stop();
            try {
                if (reloadFromServer) {
                    _DatalistLatestOverviewInfo=_ErFunc.loadEnfoFromApi(_Address, _Password);
                }
                ListSortDirection _oldSortOrder;
                DataGridViewColumn _oldSortCol;
                _oldSortOrder=dataGridView1.SortOrder==SortOrder.Ascending ?
                 ListSortDirection.Ascending : ListSortDirection.Descending;
                _oldSortCol=dataGridView1.SortedColumn;
                if (textBoxZoekOp.Text=="") {
                    dataGridView1.DataSource=_ErFunc.listToDataTableForDisplay(_DatalistLatestOverviewInfo);
                } else {
                    _DatalistSearchResults=_ErFunc.searchListByContains(textBoxZoekOp.Text, _DatalistLatestOverviewInfo);
                    dataGridView1.DataSource=_ErFunc.listToDataTableForDisplay(_DatalistSearchResults);
                }
                dataGridView1.Columns[0].Width=110;
                dataGridView1.Columns[1].Width=120;
                dataGridView1.Columns[4].Width=dataGridView1.Width-dataGridView1.Columns[0].Width-dataGridView1.Columns[1].Width-dataGridView1.Columns[2].Width-dataGridView1.Columns[3].Width-3-20;
                if (_oldSortCol!=null) {
                    DataGridViewColumn newCol = dataGridView1.Columns[_oldSortCol.Name];
                    dataGridView1.Sort(newCol, _oldSortOrder);
                }
                try {
                    if (dataGridView1.CurrentCell!=null) {
                        dataGridView1.CurrentCell=dataGridView1[1, _SelectedRowNummber];
                    }
                } catch {
                    dataGridView1.ClearSelection();
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _TimerReloadOverzicht.Start();
            sw.Stop();
            label2.Text=sw.ElapsedMilliseconds.ToString();
        }

        private void textBoxZoekOp_TextChanged(object sender, EventArgs e) {
            UpdateOverzichtLists(false);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count==0) { return; }
            textBoxOmschrijving.Text="";
            string naapje = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var usersData = new dataTableHelpFunc.combineerUserEntryRegEntryAndAfwezigEntry();
            foreach (var xyzdoeookeensmee in _DatalistLatestOverviewInfo) {
                if (xyzdoeookeensmee.userN.voorNaam==naapje) { usersData=xyzdoeookeensmee; break; }
            }
            labelVoorNaam.Text=usersData.userN.voorNaam;
            labelAchterNaam.Text=usersData.userN.achterNaam;

            if (usersData.regE.IsAanwezig) {
                dateTimePickerTijdIn.Value=Convert.ToDateTime(usersData.regE.TimeInteken);
            }

            _CurrentlySelectedUser=usersData;

            //afwezig box
            if (usersData.hasTodayAfwEntry) {
                if (usersData.afwE.IsLaat) { comboBox1.SelectedItem=comboBox1.Items[6]; textBoxOmschrijving.Text=usersData.afwE.Verwachtetijdvanaanwezighijd; labelOmschrijving.Text="Verwachte Tijd Van Aankomst"; }
                if (usersData.afwE.IsAndereReden) { comboBox1.SelectedItem=comboBox1.Items[5]; textBoxOmschrijving.Text+=usersData.afwE.AnderenRedenVoorAfwezigihijd; labelOmschrijving.Text="Reden Voor Afwezighijd"; }
                if (usersData.afwE.IsExcurtie) { comboBox1.SelectedItem=comboBox1.Items[4]; }
                if (usersData.afwE.IsFlexiebelverlof) { comboBox1.SelectedItem=comboBox1.Items[3]; }
                if (usersData.afwE.IsStudieverlof) { comboBox1.SelectedItem=comboBox1.Items[2]; }
                if (usersData.afwE.IsZiek) { comboBox1.SelectedItem=comboBox1.Items[1]; }
            } else {
                comboBox1.SelectedItem=comboBox1.Items[0];
            }

            //in uit teken buttons 
            buttonAnuleeruiteken.Enabled=false;
            buttonTekenIn.Enabled=false;
            buttonTekenUit.Enabled=false;
            if (usersData.hasTodayRegEntry) {
                if (usersData.regE.IsAanwezig) {
                    buttonTekenUit.Enabled=true;
                } else {
                    buttonAnuleeruiteken.Enabled=true;
                }
            } else {
                buttonTekenIn.Enabled=true;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            UpdateOverzichtLists(true);
        }

        private void textBoxOmschrijving_TextChanged(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            _TimerReloadOverzicht.Stop(); // er
            _TimerReloadOverzicht.Start();

            textBoxOmschrijving.Visible=false;
            labelOmschrijving.Visible=false;
            textBoxOmschrijving.Enabled=false;

            if (comboBox1.SelectedItem.ToString()=="Anders") {
                textBoxOmschrijving.Enabled=true;
                textBoxOmschrijving.Visible=true;
                labelOmschrijving.Text="Reden Voor Afwezighijd";
                labelOmschrijving.Visible=true;
                return;
            }

            if (comboBox1.SelectedItem.ToString()=="Laat") {
                textBoxOmschrijving.Enabled=true;
                textBoxOmschrijving.Visible=true;
                labelOmschrijving.Text="Verwachte Tijd Van Aankomst";
                labelOmschrijving.Visible=true;
            }
        }

        private void buttonTekenInOFUit_Click(object sender, EventArgs e) {
            TNFCCardScan fakeScan = new TNFCCardScan();
            fakeScan.ID=_CurrentlySelectedUser.userN.NFCID;
            TResiveWithPosbleError awns = webFunc.httpPostWithPassword(fakeScan, _Address, _Password);
            if (awns.isErrorOcured) {
                MessageBox.Show($"Server Error: {awns.errorInfo.errorText}");
            } else {
                UpdateOverzichtLists(true);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            TRequestChangeAfwezigTable request = new TRequestChangeAfwezigTable();
            request.fromUserID=_CurrentlySelectedUser.userN.ID;
            try {
                switch (comboBox1.SelectedIndex) {
                    case 0:
                        request.clearRecordOfAfwezigVandaag=true;
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
                        request.IsAnderereden=true;
                        if (textBoxOmschrijving.Text=="") {
                            throw new Exception("Provide Descripton");
                        } else {
                            request.AnderenRedenVoorAfwezigihijd=textBoxOmschrijving.Text;
                        }
                        break;
                    case 6:
                        request.IsLaat=true;
                        if (textBoxOmschrijving.Text=="") {
                            throw new Exception("wat is de verwachte tijd?");
                        } else {
                            request.VerwachteTijdVanAanwezighijd=textBoxOmschrijving.Text;
                        }
                        break;
                }
                TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                if (response.isErrorOcured) {
                    throw new Exception(response.errorInfo.errorText);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            UpdateOverzichtLists(true);
        }
    }
}

