using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.Drawing;

namespace vingerPrintTest {
    class Fringer { // 36870 in <3822ms

        public SerialPort Serial;
        public List<byte> _byteList = new List<byte>();
        public Bitmap outImage;

        private void SerialEvent(object sender, SerialDataReceivedEventArgs e) {
            int bytes = Serial.BytesToRead;
            byte[] buffer = new byte[bytes];
            Serial.Read(buffer, 0, bytes);
            foreach (byte x in buffer) { _byteList.Add(x); }
        }

        public Bitmap getImage(int ietszkanker) {
            outImage = new Bitmap(256, 288);
            byte[] BytesForImage = new byte[73728];
            int pixelOffset = 0;
            for (int x = 0; x < 36864; x++) {
                byte thisByte = _byteList[x + 1];
                int neenfirstNumber = (byte)((thisByte >> 4) & (byte)0x0F);
                int neensecondNumber = (byte)(thisByte & 0x0F);

                int firstNumber = neenfirstNumber * ietszkanker;
                int secondNumber = neensecondNumber * ietszkanker;             
                
                if(firstNumber > 255) { firstNumber = 255; }
                if(secondNumber > 255) { secondNumber = 255; }

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

        public void open(string comport, int baudrate) {
            Serial = new SerialPort(comport, baudrate);
            Serial.DataReceived += new SerialDataReceivedEventHandler(SerialEvent);
            Serial.Open();
        }

        public void orderFingerprint() {
            _byteList.Clear();
            Serial.Write("q");
        }
    }
}
