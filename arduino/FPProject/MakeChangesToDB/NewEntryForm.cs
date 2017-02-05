using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceAFIS.Simple;
using System.IO.Ports;
using System.Diagnostics;
using FFunc;
using FFunc.WebSendAndReturnTypes;

namespace MakeChangesToDB {
    public partial class NewEntryForm : Form {
        public NewEntryForm(string serverAdr,string passw) {
            InitializeComponent();
            _serverAdress = serverAdr;
            _password = passw;
        }

        private string _serverAdress;
        private string _password;
        private delegate void handleImageDelegate(Bitmap image);
        private delegate void updateInfoLabelDelegate(string text);
        private static AfisEngine _afis = new AfisEngine();
        private bool _receivingImage = false;
        private SerialPort _serialPort;

        private void recieveImage(object o1, object o2) {
            if (!_receivingImage) {
                _receivingImage = true;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                List<byte> bytelist = new List<byte>();
                while (bytelist.Count < 36870) {
                    int bytes = _serialPort.BytesToRead;
                    byte[] buffer = new byte[bytes];
                    _serialPort.Read(buffer, 0, bytes);
                    foreach (byte x in buffer) { bytelist.Add(x); }
                    if (bytelist.Count == 0) { stopwatch.Stop(); _receivingImage = false; return; }
                    if (stopwatch.ElapsedMilliseconds > 4000) {
                        BeginInvoke(new updateInfoLabelDelegate(updateInfoLabel), "Transfer Error");
                    }
                }
                stopwatch.Stop();
                BeginInvoke(new handleImageDelegate(handelImage), Conversion.zmf20ByteArrayToImage(bytelist.ToArray(), 17));
                BeginInvoke(new updateInfoLabelDelegate(updateInfoLabel), "Transfer Complete");
                _receivingImage = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                checkBox_IM1_useThisOne.Checked = true;
                checkBox_IM2_useThisOne.Checked = false;
                checkBox_IM3_useThisOne.Checked = false;
                makeExtendedFingerprintInfo();
            }
        }

        public static Person makePersonObjFromImage(Bitmap img) {
            Person toReturn = new Person();
            Fingerprint fingerPrint = new Fingerprint();
            fingerPrint.AsBitmap = img;
            toReturn.Fingerprints.Add(fingerPrint);
            _afis.Extract(toReturn);
            return toReturn;
        }

        public static string compairFingerprints(Person f1, Person f2) {
            return _afis.Verify(f1, f2).ToString();
        }

        void makeExtendedFingerprintInfo() {
            if (pictureBox1.Image != null) {
                Person p1 = makePersonObjFromImage((Bitmap)pictureBox1.Image);
                textBox_IM1.Text = "templateSize=" + p1.Fingerprints[0].Template.Count().ToString() + "\r\n";
                textBox_IM1.Text += "thisVsThis=" + compairFingerprints(p1, p1) + "\r\n";
                if (pictureBox2.Image != null) {
                    Person p2 = makePersonObjFromImage((Bitmap)pictureBox2.Image);
                    textBox_IM1.Text += "thisVsImage2=" + compairFingerprints(p1, p2) + "\r\n";
                }
                if (pictureBox3.Image != null) {
                    Person p3 = makePersonObjFromImage((Bitmap)pictureBox3.Image);
                    textBox_IM1.Text += "thisVsImage3=" + compairFingerprints(p1, p3) + "\r\n";
                }
            }
            if (pictureBox2.Image != null) {
                Person p2 = makePersonObjFromImage((Bitmap)pictureBox2.Image);
                textBox_IM2.Text = "templateSize=" + p2.Fingerprints[0].Template.Count().ToString() + "\r\n";
                textBox_IM2.Text += "thisVsThis=" + compairFingerprints(p2, p2) + "\r\n";
                if (pictureBox1.Image != null) {
                    Person p1 = makePersonObjFromImage((Bitmap)pictureBox2.Image);
                    textBox_IM2.Text += "thisVsImage1=" + compairFingerprints(p2, p1) + "\r\n";
                }
                if (pictureBox3.Image != null) {
                    Person p3 = makePersonObjFromImage((Bitmap)pictureBox3.Image);
                    textBox_IM2.Text += "thisVsImage3=" + compairFingerprints(p2, p3) + "\r\n";
                }
            }
            if (pictureBox3.Image != null) {
                Person p3 = makePersonObjFromImage((Bitmap)pictureBox3.Image);
                textBox_IM3.Text = "templateSize=" + p3.Fingerprints[0].Template.Count().ToString() + "\r\n";
                textBox_IM3.Text += "thisVsThis=" + compairFingerprints(p3, p3) + "\r\n";
                if (pictureBox1.Image != null) {
                    Person p1 = makePersonObjFromImage((Bitmap)pictureBox2.Image);
                    textBox_IM3.Text += "thisVsImage1=" + compairFingerprints(p3, p1) + "\r\n";
                }
                if (pictureBox2.Image != null) {
                    Person p2 = makePersonObjFromImage((Bitmap)pictureBox3.Image);
                    textBox_IM3.Text += "thisVsImage2=" + compairFingerprints(p3, p2) + "\r\n";
                }
            }
        }

        private void NewEntryForm_Load(object sender, EventArgs e) {
            string[] portnames = SerialPort.GetPortNames();
            if (portnames.Count() > 0) {
                textBox_port.Text = portnames[0];
            }
        }

        void handelImage(Bitmap image) {
            if (checkBox_IM1_imageHere.Checked) {
                pictureBox1.Image = image;
                makeExtendedFingerprintInfo();
                return;
            }
            if (checkBox_IM2_imageHere.Checked) {
                pictureBox2.Image = image;
                makeExtendedFingerprintInfo();
                return;
            }
            if (checkBox_IM3_imageHere.Checked) {
                pictureBox3.Image = image;
                makeExtendedFingerprintInfo();
                return;
            }
        }

        void updateInfoLabel(string text) {
            label_Info.Text = text;
        }

        private void button3_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                pictureBox4.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                _serialPort = new SerialPort(textBox_port.Text, Convert.ToInt32(textBox_baud.Text));
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(recieveImage);
                _serialPort.Open();
                label_Info.Text = "Connected";
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            try {
                TypeSendNewDBEntry newEntry = new TypeSendNewDBEntry();
                newEntry.VoorNaam = textBox_voornaam.Text;
                newEntry.AchterNaam = textBox_achternaam.Text;
                if (pictureBox4.Image != null) {
                    newEntry.Base64ProfileImage = Conversion.imageToBase64String((Bitmap)pictureBox4.Image);
                } else {
                    newEntry.Base64ProfileImage = "nietz";
                }

                if (checkBox_IM1_useThisOne.Checked) {
                    newEntry.Base64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate((Bitmap)pictureBox1.Image));
                } else {
                    if (checkBox_IM2_useThisOne.Checked) {
                        newEntry.Base64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate((Bitmap)pictureBox2.Image));
                    } else {
                        if (checkBox_IM3_useThisOne.Checked) {
                            newEntry.Base64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate((Bitmap)pictureBox3.Image));
                        } else {
                            MessageBox.Show("select a fingerprint image to use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                TypeReturnDBChanged resp = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnDBChanged>(newEntry, _serverAdress, _password);
                MessageBox.Show("linesAfected=" + resp.linesAffected + " id of new person= " + resp.idOfNewDBEntry, "db update info");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
