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
using System.Diagnostics;

namespace getImageFromzmf_20Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        SerialPort port;
        //white cable to 18
        //green cable to 19

        private bool busyWithImage = false;
        private Stopwatch stopwatch = new Stopwatch();
        private Timer timer = new Timer();
        private bool stopGettigImage = false;

        private void handleImage(object een,object twee) {
            if (!busyWithImage) {
                busyWithImage = true;
                List<byte> bytelist = new List<byte>();
                timer = new Timer();
                timer.Interval = 4500;
                timer.Tick += new EventHandler(stopResievingImage);
                timer.Start();
                stopwatch.Reset();
                stopwatch.Start();
                while (bytelist.Count < 36870) {
                    if (stopGettigImage) { return; }
                    int bytes = port.BytesToRead;
                    byte[] buffer = new byte[bytes];
                    port.Read(buffer, 0, bytes);
                    foreach (byte x in buffer) { bytelist.Add(x); }
                    if(bytelist.Count == 0) { }
                }
                stopwatch.Stop();

                string kanker = stopwatch.ElapsedMilliseconds.ToString();

                timer.Stop();

                pictureBox1.Image = getImage(bytelist.ToArray());

                busyWithImage = false;
            }
        }

        private void stopResievingImage(object a, object b) {
            stopGettigImage = true;
        }

        public Bitmap getImage(byte[] bytez) {
            Bitmap outImage = new Bitmap(256, 288);
            byte[] BytesForImage = new byte[73728];
            int pixelOffset = 0;
            for (int x = 0; x < 36864; x++) {
                byte thisByte = bytez[x + 1];
                int neenfirstNumber = (byte)((thisByte >> 4) & (byte)0x0F);
                int neensecondNumber = (byte)(thisByte & 0x0F);

                int firstNumber = neenfirstNumber * 17;
                int secondNumber = neensecondNumber * 17;

                if (firstNumber > 255) { firstNumber = 255; }
                if (secondNumber > 255) { secondNumber = 255; }

                Color firls = Color.FromArgb(firstNumber, firstNumber, firstNumber);
                Color second = Color.FromArgb(secondNumber, secondNumber, secondNumber);

                int line = pixelOffset / 256;
                int lineOff = pixelOffset - (line * 256);
                outImage.SetPixel(lineOff, line, firls);
                pixelOffset++;

                line = pixelOffset / 256;
                lineOff = pixelOffset - (line * 256);
                outImage.SetPixel(lineOff, line, second);
                pixelOffset++;
            }
            return outImage;
        }

        private void button1_Click(object sender, EventArgs e) {
            port = new SerialPort(textBox1.Text, 115200);
            port.DataReceived += new SerialDataReceivedEventHandler(handleImage);
            port.Open();
            button1.Text = "Open";
        }

        private void button2_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }
    }
}
