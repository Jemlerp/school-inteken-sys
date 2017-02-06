using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewCrossFunctions;
using Newtonsoft.Json;
using System.IO.Ports;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NewIntekenForm {
    public partial class ArrrrFormcs : Form {

        public ArrrrFormcs(string _serkialPort, string _apiAdress, string _username, string _password, bool _startInWindowMode) {
            InitializeComponent();
            _Serialport=new SerialPort(_serkialPort, 9600);
            _ApiAddres=_apiAdress;
            _Username=_username;
            _Password=_password;
            _WINDWEDMODUSENABLED=_startInWindowMode;
        }

        bool _NOODMODUSENABLED = false;
        bool _WINDWEDMODUSENABLED = false;

        string _Username;
        string _Password;
        string _ApiAddres;
        SerialPort _Serialport = new SerialPort();
        Timer _TimerCleanUserInfoScreen = new Timer();
        Timer _TimerReloadOverzicht = new Timer();
        private delegate void handelTextDelegate(string read);
        private delegate void updateOverzichtDelegate();

        void enableNoodModus() {
            _NOODMODUSENABLED=true;
            buttonDisableNoodMode.Visible=true;
            panel1.Visible=false;
            this.BackColor=Color.Red;
            _TimerCleanUserInfoScreen.Stop();
            _TimerReloadOverzicht.Stop();
        }

        void disableNoodModus() {
            _NOODMODUSENABLED=false;
            buttonDisableNoodMode.Visible=false;
            panel1.Visible=true;
            this.BackColor=Color.Yellow; //times are outdated
            _TimerCleanUserInfoScreen.Start();
            _TimerReloadOverzicht.Start();
            updateOverzight();
        }

        List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry> _LastRecivedOverzight = new List<DatabaseTypesAndFunctions.CombineerUserEntryRegEntryAndAfwezigEntry>();

        private NetComunicationTypesAndFunctions.ServerResponse webbbbrrrrrry(object request) {
            return NetComunicationTypesAndFunctions.WebRequest(request, _Username, _Password, _ApiAddres);
        }

        private void ArrrrFormcs_Load(object sender, EventArgs e) {
            try {
                if (!_WINDWEDMODUSENABLED) {
                    FormBorderStyle=FormBorderStyle.None;
                    WindowState=FormWindowState.Maximized;
                }                
                _Serialport.Open();
                _Serialport.DataReceived+=new SerialDataReceivedEventHandler(readReadFromSerial);
                _TimerCleanUserInfoScreen.Interval=4200;
                _TimerReloadOverzicht.Interval=4000;
                _TimerCleanUserInfoScreen.Tick+=new EventHandler(ClearUserInfo_Event);
                _TimerReloadOverzicht.Tick+=new EventHandler(ReloadEtOverzicht_Event);
                updateOverzight();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        void ClearUserInfo_Event(object nee, object ja) {
            _TimerCleanUserInfoScreen.Stop();
            labelInOfUitGetekend.Text="<In/Uit>";
            labelNaam.Text="<Naam>";
        }

        void updateOverzight() {
            if (!_NOODMODUSENABLED) {
                try {
                    _TimerReloadOverzicht.Stop();
                    NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate request = new NetComunicationTypesAndFunctions.ServerRequestOverzightFromOneDate();
                    request.useToday=true;

                    NetComunicationTypesAndFunctions.ServerResponse response;

                    try {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();

                        response=webbbbrrrrrry(request);

                        label2.Text=sw.ElapsedMilliseconds.ToString();
                    } catch { // als server down is (als school in brand staat...)
                        if (MessageBox.Show("Kan Niet Verbinden Met Server", "Ga Naar Alarm Modus?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes) {
                            enableNoodModus();
                        } else {
                            this.BackColor=Color.Yellow;
                        }
                        _TimerReloadOverzicht.Start();
                        return;
                    }

                    this.BackColor=SystemColors.Control; // all OK color

                    NetComunicationTypesAndFunctions.ServerResponseOverzightFromOneDate returnedValue;
                    if (response.IsErrorOccurred) {
                        throw new Exception(response.ErrorInfo.ErrorMessage);
                    } else {

                        //--
                        int _SelectedRowNummber = 0;
                        if (dataGridView1.CurrentCell!=null) {
                            _SelectedRowNummber=dataGridView1.CurrentCell.RowIndex;
                        }
                        ListSortDirection _oldSortOrder;
                        DataGridViewColumn _oldSortCol;
                        _oldSortOrder=dataGridView1.SortOrder==SortOrder.Ascending ?
                         ListSortDirection.Ascending : ListSortDirection.Descending;
                        _oldSortCol=dataGridView1.SortedColumn;
                        ///--
                        ///
                        returnedValue = JsonConvert.DeserializeObject<NetComunicationTypesAndFunctions.ServerResponseOverzightFromOneDate>(JsonConvert.SerializeObject(response.Response));
                        dataGridView1.DataSource=ForFormHelperFunctions.UserInfoListToDataTableForDataGridDisplay(returnedValue.EtList, returnedValue.SQlDateTime);
                        dataGridView1.Refresh();
                        _LastRecivedOverzight=returnedValue.EtList;

                        //--
                        if (_oldSortCol!=null) {
                            DataGridViewColumn newCol = dataGridView1.Columns[_oldSortCol.Name];
                            dataGridView1.Sort(newCol, _oldSortOrder);
                        }
                        try {// voor als row[x] er niet (meer) is
                            if (dataGridView1.CurrentCell!=null) {
                                dataGridView1.CurrentCell=dataGridView1[1, _SelectedRowNummber];
                            }
                        } catch {
                            dataGridView1.ClearSelection();
                        }
                        ///--

                        dataGridView1.Columns[0].Width=130;
                        dataGridView1.Columns[1].Width=130;
                        dataGridView1.Columns[4].Width=dataGridView1.Width-dataGridView1.Columns[0].Width-dataGridView1.Columns[1].Width-dataGridView1.Columns[2].Width-dataGridView1.Columns[3].Width-3-20;
                        _TimerReloadOverzicht.Start();
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    _TimerReloadOverzicht.Start();
                }
            }
        }

        void ReloadEtOverzicht_Event(object nee, object ja) {
            BeginInvoke(new updateOverzichtDelegate(updateOverzight));
        }

        void HandelNfcScan(string _read) {
            if (!_NOODMODUSENABLED) {
                _TimerCleanUserInfoScreen.Stop();
                NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit request = new NetComunicationTypesAndFunctions.ServerRequestTekenInOfUit();
                request.NFCCode=_read;

                NetComunicationTypesAndFunctions.ServerResponse response;

                try {
                    response=webbbbrrrrrry(request);
                } catch {
                    if (MessageBox.Show("Kan Niet Verbinden Met Server", "Ga Naar Alarm Modus?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes) {
                        enableNoodModus();
                    } else {
                        this.BackColor=Color.Yellow;
                    }
                    return;
                }

                this.BackColor=SystemColors.Control;

                if (response.IsErrorOccurred) {
                    MessageBox.Show(response.ErrorInfo.ErrorMessage);
                } else {
                    NetComunicationTypesAndFunctions.ServerResponseInteken intekenResponse = JsonConvert.DeserializeObject<NetComunicationTypesAndFunctions.ServerResponseInteken>(JsonConvert.SerializeObject(response.Response));
                    labelNaam.Text=intekenResponse.TheUserWithEntryInfo.UsE.VoorNaam+" "+intekenResponse.TheUserWithEntryInfo.UsE.AchterNaam;
                    if (intekenResponse.uitekenengeanuleerd) { labelInOfUitGetekend.Text="Uitekenen Geanuleerd"; }
                    if (intekenResponse.ingetekened) { labelInOfUitGetekend.Text="Je Bent Nu Ingetekend"; }
                    if (intekenResponse.uitgetekened) { labelInOfUitGetekend.Text="Je Bent Nu Uitgetekend"; }
                    _TimerCleanUserInfoScreen.Start();
                    updateOverzight();
                }
            }
        }

        void readReadFromSerial(object _ebjec, object _tokdekmak) {
            string Read = _Serialport.ReadLine();
            BeginInvoke(new handelTextDelegate(HandelNfcScan), ForFormHelperFunctions.SerialReadToNormal(Read));
        }

        private void buttonDisableNoodMode_Click(object sender, EventArgs e) {
            disableNoodModus();
        }

        private void ArrrrFormcs_FormClosing(object sender, FormClosingEventArgs e) {
            _Serialport.Close();
        }
    }
}
