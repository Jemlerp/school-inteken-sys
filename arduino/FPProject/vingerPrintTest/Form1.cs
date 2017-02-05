using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceAFIS.Simple;
using System.IO;

namespace vingerPrintTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Fringer finger = new Fringer();
        Stopwatch stopwatch = new Stopwatch();
        static AfisEngine Afis = new AfisEngine();
        List<Student> iedereen = new List<Student>();

        private void button1_Click(object sender, EventArgs e) {
            label5.Text = "";
            stopwatch.Reset();
            stopwatch.Stop();
            finger._byteList.Clear();
            finger.orderFingerprint();

            while (finger._byteList.Count < 36870) {
                if (!stopwatch.IsRunning) {
                    if (finger._byteList.Count > 1) { stopwatch.Start(); }
                }
                if (stopwatch.ElapsedMilliseconds > 4500) {
                    label5.Text = "ERROR";
                    break;
                }
            }
            label6.Text = stopwatch.ElapsedMilliseconds.ToString();
            pictureBox1.Image = finger.getImage(Convert.ToInt32(textBox3.Text));
        }

        private void button4_Click(object sender, EventArgs e) {
            finger.open(textBox1.Text, Convert.ToInt32(textBox2.Text));
            label4.Text = "Open";
        }

        private void button2_Click(object sender, EventArgs e) {
            label1.Text = finger._byteList.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e) {
            pictureBox1.Image = finger.getImage(Convert.ToInt32(textBox3.Text));
        }

        private void button6_Click(object sender, EventArgs e) {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.ShowDialog();
            finger.outImage.Save(ofd.FileName);
        }

        private void button7_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            pictureBox2.Image = Image.FromFile(ofd.FileName);
        }

        private void button5_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            DirectoryInfo d = new DirectoryInfo(fbd.SelectedPath);
            FileInfo[] Files = d.GetFiles("*.bmp");

            foreach(FileInfo file in Files) {
                Student stu = new Student();
                stu.Name = file.Name;

                Fingerprint dezePrint = new Fingerprint();
                dezePrint.AsBitmap = (Bitmap)Image.FromFile(fbd.SelectedPath + "\\" + file.Name);
                stu.VingerInfo.Fingerprints.Add(dezePrint);

                Afis.Extract(stu.VingerInfo);
                iedereen.Add(stu);
            }

            //float score = Afis.Verify(pers1,pers2);
            label7.Text = "Made";
        }

        private void button8_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            pictureBox1.Image = Image.FromFile(ofd.FileName);
            label8.Text = ofd.SafeFileName;
        }

        private void button9_Click(object sender, EventArgs e) {
            textBox4.Text = "";
            Person person = new Person();
            Fingerprint finger = new Fingerprint();
            finger.AsBitmap = (Bitmap)pictureBox1.Image;
            person.Fingerprints.Add(finger);
            Afis.Extract(person);
            foreach (Student stu in iedereen) {
                float bannaam = Afis.Verify(stu.VingerInfo, person);
                textBox4.Text += bannaam.ToString() + " - " + stu.Name + "\r\n";
            }
        }

        private void button10_Click(object sender, EventArgs e) {
            Person person = new Person();
            Fingerprint fiunger = new Fingerprint();
            fiunger.AsBitmap = (Bitmap)pictureBox1.Image;
            person.Fingerprints.Add(fiunger);
            Afis.Extract(person);

            textBox5.Text = "thisVsThis=" + Afis.Verify(person, person).ToString() + "\r\n";

            textBox5.Text += "templateSize=" + person.Fingerprints[0].Template.Count().ToString();

        }
    }

    public class Student {
        public Person VingerInfo = new Person();
        public string Name = "";
    }
}
