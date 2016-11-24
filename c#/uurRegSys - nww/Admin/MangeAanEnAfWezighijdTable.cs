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
    public partial class MangeAanEnAfWezighijdTable : Form {

        public MangeAanEnAfWezighijdTable(string address, string password) {
            InitializeComponent();
            _Address=address;
            _Password=password;
        }

        public string _Address = "";
        public string _Password = "";
        public List<string> _SelectEdUsersIDs = new List<string>();
        private bool _UsingaanwezigTable = false;
        private int _SelectedRowNummber;
        SQLPropertysAndFunc _Funcc = new SQLPropertysAndFunc();

        private void relaodErDataGrid() {
            if (_SelectEdUsersIDs.Count>0) {
                TAdminSendAskADataTable request = new TAdminSendAskADataTable();
                ListSortDirection _oldSortOrder;
                DataGridViewColumn _oldSortCol;
                _oldSortOrder=dataGridViewEr.SortOrder==SortOrder.Ascending ?
                 ListSortDirection.Ascending : ListSortDirection.Descending;
                _oldSortCol=dataGridViewEr.SortedColumn;
                if (dataGridViewEr.CurrentCell!=null) {
                    _SelectedRowNummber=dataGridViewEr.CurrentCell.RowIndex;
                }
                if (_UsingaanwezigTable) {
                    request.aanwezighijdTable=true;
                } else {
                    request.afwezighijdTable=true;
                }
                request.getForSpecificUsers=true;
                request.listOfUsersToGetFrom=_SelectEdUsersIDs;
                request.dateOf=dateTimePicker1.Value.Date;
                if (checkBoxUseAllBetweenDates.Checked) {
                    request.useBetweenDates=true;
                    request.dataTotEnMet=dateTimePicker2.Value.Date;
                }
                try {
                    TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                    if (response.isErrorOcured) {
                        MessageBox.Show(response.errorInfo.errorText);
                    } else {
                        dataGridViewEr.DataSource=JsonConvert.DeserializeObject<TAdminReturnADataTable>(JsonConvert.SerializeObject(response.expectedResponse)).DataTable;
                        foreach (DataGridViewColumn x in dataGridViewEr.Columns) {
                            x.SortMode=DataGridViewColumnSortMode.Automatic;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                try { //bleh
                    if (_oldSortCol!=null) {
                        DataGridViewColumn newCol = dataGridViewEr.Columns[_oldSortCol.Name];
                        dataGridViewEr.Sort(newCol, _oldSortOrder);
                        dataGridViewEr.CurrentCell=dataGridViewEr[1, _SelectedRowNummber];
                    }
                } catch {

                }
            }
        }

        private void MangeAanEnAfWezighijdTable_Load(object sender, EventArgs e) {
            dateTimePickerAANUpdateTimeIn.ShowUpDown=true;
            dateTimePickerAANUpdateTimeIn.CustomFormat="HH:mm:ss tt";
            dateTimePickerAANUpdateTimeIn.Format=System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePickerAANUpdateTimeUit.ShowUpDown=true;
            dateTimePickerAANUpdateTimeUit.CustomFormat="HH:mm:ss tt";
            dateTimePickerAANUpdateTimeUit.Format=System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePickerAANNewTimeIn.ShowUpDown=true;
            dateTimePickerAANNewTimeIn.CustomFormat="HH:mm:ss tt";
            dateTimePickerAANNewTimeIn.Format=System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePickerAANNewTimeUit.ShowUpDown=true;
            dateTimePickerAANNewTimeUit.CustomFormat="HH:mm:ss tt";
            dateTimePickerAANNewTimeUit.Format=System.Windows.Forms.DateTimePickerFormat.Custom;
            TAdminSendAskADataTable request = new TAdminSendAskADataTable();
            request.userTable=true;
            TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
            if (response.isErrorOcured) {
                MessageBox.Show(response.errorInfo.errorText);
                Close();
            } else {
                dataGridViewUsers.DataSource=JsonConvert.DeserializeObject<TAdminReturnADataTable>(JsonConvert.SerializeObject(response.expectedResponse)).DataTable;
                listBox1.SelectedIndex=listBox1.FindString("AanwezighijdTable");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)listBox1.SelectedItem=="AanwezighijdTable") {
                _UsingaanwezigTable=true;
                panelafwezigControlls.SendToBack();
            } else {
                _UsingaanwezigTable=false;
                panelaanwezigcontorls.SendToBack();
            }
            relaodErDataGrid();
        }

        private void buttonLoadDataFromUsers_Click(object sender, EventArgs e) {
            relaodErDataGrid();
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e) {
            _SelectEdUsersIDs.Clear();
            foreach (DataGridViewRow row in dataGridViewUsers.SelectedRows) {
                _SelectEdUsersIDs.Add(row.Cells[0].Value.ToString());
            }
            if (_SelectEdUsersIDs.Count>0) {
                textBoxAANNewUserID.Text=_SelectEdUsersIDs[0].ToString();
                textBoxAFNewUserID.Text=_SelectEdUsersIDs[0].ToString();
            }
            relaodErDataGrid(); // --------------------------- te langzaam dan?
        }

        private void MangeAanEnAfWezighijdTable_Resize(object sender, EventArgs e) {
            dataGridViewEr.Width=this.Width-620;
        }

        private void checkBoxUseAllBetweenDates_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxUseAllBetweenDates.Checked) {
                dateTimePicker2.Enabled=true;
            } else {
                dateTimePicker2.Enabled=false;
            }
            relaodErDataGrid();
        }

        private void dataGridViewEr_SelectionChanged(object sender, EventArgs e) {
            if (dataGridViewEr.SelectedRows.Count!=0) {
                if (_UsingaanwezigTable) {
                    textBoxAANUpdateID.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.ID].Value.ToString();
                    textBoxAANUpdateUserID.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.IDOfUserRelated].Value.ToString();
                    dateTimePickerAANUpdateDate.Value=Convert.ToDateTime(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.Date].Value.ToString());
                    try {
                        dateTimePickerAANUpdateTimeIn.Value=Convert.ToDateTime(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.TimeInteken].Value.ToString());
                    } catch { }
                    try {
                        dateTimePickerAANUpdateTimeUit.Value=Convert.ToDateTime(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.TimeUitteken].Value.ToString());
                        checkBoxAANUpdateZetNietsOpUIteken.Checked=false;
                    } catch { checkBoxAANUpdateZetNietsOpUIteken.Checked=true; }
                    checkBoxAANUpdateIsAanwezig.Checked=Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.RegistratieTableNames.IsAanwezig].Value);
                } else {
                    textBoxAFUpdateID.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.ID].Value.ToString();
                    textBoxAfUpdateUserID.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IDOfUserRelated].Value.ToString();
                    dateTimePickerAFUpdateDate.Value=Convert.ToDateTime(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.Date].Value.ToString());
                    int watIsSelected = 0;
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsZiek].Value.ToString())) {
                        watIsSelected=1;
                    }
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsFlexibelverlof].Value.ToString())) {
                        watIsSelected=3;
                    }
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsStudieverlof].Value.ToString())) {
                        watIsSelected=2;
                    }
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsExcursie].Value.ToString())) {
                        watIsSelected=4;
                    }
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsLaat].Value.ToString())) {
                        watIsSelected=6;
                        textBoxAFUpdateOmschrijving.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd].ToString();
                    }
                    if (Convert.ToBoolean(dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.IsAndereReden].Value.ToString())) {
                        watIsSelected=5;
                        textBoxAFUpdateOmschrijving.Text=dataGridViewEr.SelectedRows[0].Cells[SQLPropertysAndFunc.AfwezigTableNames.AnderenRedenVoorAfwezighijd].ToString();
                    }
                    comboBoxAFUpdateRedenAfdwezighijd.SelectedItem=comboBoxAFUpdateRedenAfdwezighijd.Items[watIsSelected];
                }
            }
        }

        private void buttonAANUpdateUpdate_Click(object sender, EventArgs e) {
            try {
                TAdminSendChangeRegistratieTable request = new TAdminSendChangeRegistratieTable();
                request.IDToChange=Convert.ToInt32(textBoxAANUpdateID.Text);
                request.IDUserRelated=Convert.ToInt32(textBoxAANUpdateUserID.Text);
                request.Date=dateTimePickerAANUpdateDate.Value;
                request.TimeIn=Convert.ToDateTime(dateTimePickerAANUpdateTimeIn.Value).TimeOfDay;

                if (!checkBoxAANUpdateZetNietsOpUIteken.Checked) {
                    request.TimeUit=Convert.ToDateTime(dateTimePickerAANUpdateTimeUit.Value).TimeOfDay;
                } else {
                    request.HeeftGeenUiteken=true;
                }

                request.IsAanwezig=checkBoxAANUpdateIsAanwezig.Checked;
                TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                if (response.isErrorOcured) {
                    MessageBox.Show(response.errorInfo.errorText);
                } else {
                    relaodErDataGrid();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAANNewSave_Click(object sender, EventArgs e) {
            try {
                TAdminSendChangeRegistratieTable request = new TAdminSendChangeRegistratieTable();
                request.IsNewEntry=true;
                request.IDUserRelated=Convert.ToInt32(textBoxAANNewUserID.Text);
                request.Date=dateTimePickerAANNewDate.Value;
                request.IsAanwezig=checkBoxAANNewIsAanwezig.Checked;
                request.TimeIn=Convert.ToDateTime(dateTimePickerAANNewTimeIn.Value).TimeOfDay;

                if (!checkBoxAANNewZetNietsOpUitekene.Checked) {
                    request.TimeUit=Convert.ToDateTime(dateTimePickerAANNewTimeUit.Value).TimeOfDay;
                } else {
                    request.HeeftGeenUiteken=true;
                }

                TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                if (response.isErrorOcured) {
                    MessageBox.Show(response.errorInfo.errorText);
                }
                relaodErDataGrid();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxAANUpdateZetNietsOpUIteken_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxAANUpdateZetNietsOpUIteken.Checked) {
                dateTimePickerAANUpdateTimeUit.Enabled=false;
            } else {
                dateTimePickerAANUpdateTimeUit.Enabled=true;
            }
        }

        private void checkBoxAANNewZetNietsOpUitekene_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxAANNewZetNietsOpUitekene.Checked) {
                dateTimePickerAANNewTimeUit.Enabled=false;
            } else {
                dateTimePickerAANNewTimeUit.Enabled=true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            relaodErDataGrid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) {
            relaodErDataGrid();
        }

        private void buttonAANUpdateDelete_Click(object sender, EventArgs e) {
            var confirmResult = MessageBox.Show("Are you sure to delete this entry ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult==DialogResult.Yes) {
                if (textBoxAANUpdateID.Text!="") {
                    TAdminSendChangeRegistratieTable request = new TAdminSendChangeRegistratieTable();
                    request.DELETE=true;
                    request.IDToChange=Convert.ToInt32(textBoxAANUpdateID.Text);
                    TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                    if (response.isErrorOcured) {
                        MessageBox.Show(response.errorInfo.errorText);
                    } else {
                        MessageBox.Show("Deleted Entry "+request.IDToChange.ToString());
                        relaodErDataGrid();
                    }
                } else {
                    MessageBox.Show("none selected");
                }
            }
        }

        private void comboBoxAF_SelectedIndexChanged(object sender, EventArgs e) {
            var butt = sender as ComboBox;
            if (butt.SelectedItem.ToString()=="Laat") {
                labelAFUpdateOmschijvinf.Text="verwachte tijd aanwezighijd";
            }
            if (butt.SelectedItem.ToString()=="Anders") {
                labelAFUpdateOmschijvinf.Text="omschijving";
            }
        }

        private void comboBoxAfNewRedenAfwezighijd_SelectedIndexChanged(object sender, EventArgs e) {
            var butt = sender as ComboBox;
            if (butt.SelectedItem.ToString()=="Laat") {
                labelAfNewRedenAfwezig.Text="verwachte tijd aanwezig";
            }
            if (butt.SelectedItem.ToString()=="Anders") {
                labelAfNewRedenAfwezig.Text="omschijving";
            }
        }

        private void buttonAfUpdateDelete_Click(object sender, EventArgs e) {
            var confirmResult = MessageBox.Show("Are you sure to delete this entry ??",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult==DialogResult.Yes) {
                if (textBoxAANUpdateID.Text!="") {
                    TAdminSendChangeAfwezigTable request = new TAdminSendChangeAfwezigTable();
                    request.DELETE=true;
                    request.IDToChage=Convert.ToInt32(textBoxAFUpdateID.Text);
                    TResiveWithPosbleError response = webFunc.httpPostWithPassword(request, _Address, _Password);
                    if (response.isErrorOcured) {
                        MessageBox.Show(response.errorInfo.errorText);
                    } else {
                        MessageBox.Show("Deleted Entry "+request.IDToChage.ToString());
                        relaodErDataGrid();
                    }
                } else {
                    MessageBox.Show("none selected");
                }
            }
        }

        private void buttonAfUpdateUpdate_Click(object sender, EventArgs e) {

        }

        private void buttonAfNewSave_Click(object sender, EventArgs e) {

        }
    }
}
