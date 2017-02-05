using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using FFunc;
using FFunc.WebSendAndReturnTypes;

namespace webApiTester {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        static string password = "testWachtwoord";
        string base64FingerprintTemplate = "";
        string wieIsHetBase64FingerprintTemplate = "";

        static string serverAddres = "http://localhost:56294/api/fingerprint";

        private void button1_Click(object sender, EventArgs e) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TypeAskDBEntry question = new TypeAskDBEntry();
            question.dontUseWhereGetAll = true;
            question.whereIdIs = "4";
            List<TypeReturnDBEntry> response = SqlAndWeb.httpPostWithErrorCheckAndPassword<List<TypeReturnDBEntry>>(question, serverAddres, password);
            stopwatch.Stop();
            textBox1.Text = stopwatch.ElapsedMilliseconds.ToString() + "\r\n";
            foreach(TypeReturnDBEntry x in response) {
                textBox1.Text += x.ID + " " + x.voorNaam + " " + x.achterNaam + "\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e) {            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TypeSendDBUpdate quest = new TypeSendDBUpdate();            
            quest.deleteFromDB = checkBox1.Checked;
            quest.updateFingerprintTemplate = checkBox2.Checked;
            quest.WhereIDIs = Convert.ToInt32(textBox2.Text);
            quest.newVoorNaam = textBox3.Text;
            quest.newAchterNaam = textBox4.Text;
            quest.newBase64ProfileImage = textBox5.Text;
            quest.newBase64FingerprintTemplate = textBox6.Text;
            string setupTime = stopwatch.ElapsedMilliseconds.ToString();
            stopwatch.Restart();
            TypeReturnDBChanged resp = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnDBChanged>(quest, serverAddres, password);
            stopwatch.Stop();
            MessageBox.Show("L Affectd=" + resp.linesAffected + " setuptime=" + setupTime + " httpTime=" + stopwatch.ElapsedMilliseconds.ToString());
        }

        private void button4_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK) {
                base64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate((Bitmap)Image.FromFile(ofd.FileName)));
                button4.Text = "SET";
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            button4.Text = "SetFingerprintTemplate";
            TypeSendNewDBEntry opdracht = new TypeSendNewDBEntry();
            opdracht.VoorNaam = textBox7.Text;
            opdracht.AchterNaam = textBox8.Text;
            opdracht.Base64ProfileImage = textBox9.Text;
            opdracht.Base64FingerprintTemplate = base64FingerprintTemplate;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TypeReturnDBChanged resp = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnDBChanged>(opdracht, serverAddres, password);
            stopwatch.Stop();
            MessageBox.Show("idOfNewEntry="+ resp.idOfNewDBEntry + " linesAffected=" + resp.linesAffected + " Time=" + stopwatch.ElapsedMilliseconds.ToString());
            base64FingerprintTemplate = "";
        }

        private void button6_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK) {
                wieIsHetBase64FingerprintTemplate = Convert.ToBase64String(Conversion.fingerprintImageToFingerprintTemplate((Bitmap)Image.FromFile(ofd.FileName)));
                button6.Text = "SET";
            }

        }

        private void button5_Click(object sender, EventArgs e) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TypeAskID req = new TypeAskID();
            req.base64FingerprintTemplate = wieIsHetBase64FingerprintTemplate;
            TypeReturnID awns = SqlAndWeb.httpPostWithErrorCheckAndPassword<TypeReturnID>(req, serverAddres,password);
            stopwatch.Stop();
            if (awns != null) {
                textBox10.Text = awns.ID.ToString() + " " + awns.voorNaam + " " + awns.achterNaam + " " + awns.base64ProfileImage + " Time=" + stopwatch.ElapsedMilliseconds;
            } else {
                textBox10.Text = "null";
            }
        }
    }
}
