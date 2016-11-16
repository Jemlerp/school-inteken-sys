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

        public erForm(string apiAddress, string password, string serialPort) {
            InitializeComponent();
            _Password=password;
            _Address=apiAddress;
            _SerialPort=new SerialPort(serialPort, 9600);
        }

        Timer _TimerCleanUserInfoScreen = new Timer();
        Timer _TimerReloadOverzicht = new Timer();

        string _Password;
        string _Address;
        SerialPort _SerialPort;
        erFuntions _ErFunc = new erFuntions();
        List<erFuntions.combineerUserEntryRegEntryAndAfwezigEntry> _Datalist = new List<erFuntions.combineerUserEntryRegEntryAndAfwezigEntry>();
        List<erFuntions.combineerUserEntryRegEntryAndAfwezigEntry> _DatalistSearchResults = new List<erFuntions.combineerUserEntryRegEntryAndAfwezigEntry>();
        private delegate void handelTextDelegate(string read);
        private delegate void updateOverzichtDelegate(bool reloadData);

        private void erForm_Load(object sender, EventArgs e) {
            try {
                _SerialPort.Open();
                _SerialPort.DataReceived+=new SerialDataReceivedEventHandler(readReadFromSerial);

                _TimerCleanUserInfoScreen.Interval=4200;
                _TimerReloadOverzicht.Interval=42000;

                _TimerCleanUserInfoScreen.Tick+=new EventHandler(timerEventCleanUserInfoScreen);
                _TimerReloadOverzicht.Tick+=new EventHandler(timerEventReloadOverzicht);

                _TimerReloadOverzicht.Start();

                UpdateOverzichtLists(true);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void timerEventCleanUserInfoScreen(object een, object twee) {
            clearNFCScanInfo();
        }

        private void clearNFCScanInfo() {
            _TimerCleanUserInfoScreen.Stop();
            labelNaam.Text="Naam";
            labelInOfUitGetekend.Text="In/Uit";
        }

        private void timerEventReloadOverzicht(object een, object twee) {
            BeginInvoke(new updateOverzichtDelegate(UpdateOverzichtLists), true);
        }

        private void handleNFCScan(string read) {
            _TimerCleanUserInfoScreen.Stop();
            TNFCCardScan scan = new TNFCCardScan();
            scan.ID=read;
            TResiveWithPosbleError awns = webFunction.httpPostWithPassword(scan, _Address, _Password);
            if (awns.isErrorOcured) {
                MessageBox.Show(awns.errorInfo.errorText);
            } else {
                TReturnDisplayInfoForJustReadNFCCard displayInfo = JsonConvert.DeserializeObject<TReturnDisplayInfoForJustReadNFCCard>(JsonConvert.SerializeObject(awns.expectedResponse));
                labelNaam.Text=displayInfo.voornaam+" "+displayInfo.achternaam;
                if (displayInfo.doetAnuleerUitteken) { labelInOfUitGetekend.Text="Uitekenen Geanuleerd"; }
                if (displayInfo.doetInteken) { labelInOfUitGetekend.Text="Je Bent Nu Ingetekend"; }
                if (displayInfo.doetUitteken) { labelInOfUitGetekend.Text="Je Bent Nu Uitgetekend"; }
            }
            _TimerCleanUserInfoScreen.Start();
            UpdateOverzichtLists(true);
        }

        private void readReadFromSerial(object nee, object ookNee) {
            string read = _SerialPort.ReadLine();
            BeginInvoke(new handelTextDelegate(handleNFCScan), funcZ.readingFromNFCCard.serialReadToNormal(read));
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
                    _Datalist=_ErFunc.loadEnfoFromApi(_Address, _Password);
                }

                ListSortDirection _oldSortOrder;
                DataGridViewColumn _oldSortCol;
                _oldSortOrder=dataGridView1.SortOrder==SortOrder.Ascending ?
                 ListSortDirection.Ascending : ListSortDirection.Descending;
                _oldSortCol=dataGridView1.SortedColumn;


                if (textBox1.Text=="") {
                    dataGridView1.DataSource=_ErFunc.listToDataTableForDisplay(_Datalist);
                } else {
                    _DatalistSearchResults=_ErFunc.searchListByContains(textBox1.Text, _Datalist);
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

        private void textBox1_TextChanged(object sender, EventArgs e) {
            UpdateOverzichtLists(false);
        }

        private void zetAfwezighijdToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count>0) {
                string naamToSearchWith = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                erFuntions.combineerUserEntryRegEntryAndAfwezigEntry sendToForm = new erFuntions.combineerUserEntryRegEntryAndAfwezigEntry();
                foreach (erFuntions.combineerUserEntryRegEntryAndAfwezigEntry combi in _Datalist) {
                    if (combi.userN.voorNaam==naamToSearchWith) { sendToForm=combi; break; }
                }
                zetAfwezigForm form;
                if (sendToForm.hasTodayAfwEntry) {
                    form=new zetAfwezigForm(sendToForm.userN, sendToForm.afwE,_Password,_Address);
                } else {
                    form=new zetAfwezigForm(sendToForm.userN,_Password,_Address);
                }
                form.ShowDialog();
                UpdateOverzichtLists(true);
            } else {
                //mboxz
            }
        }
    }
}
