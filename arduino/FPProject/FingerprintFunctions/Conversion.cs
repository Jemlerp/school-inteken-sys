using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using SourceAFIS.Simple;

namespace FFunc {
    public class Conversion {
        public static AfisEngine Afis = new AfisEngine();
        //Ok
        /// <summary>
        /// convert base64 string to image
        /// </summary>
        /// <param name="_Base64String">base64 string</param>
        /// <returns></returns>
        public static Image base64ToImage(string _Base64String) {
            byte[] bytesFromBase64 = Convert.FromBase64String(_Base64String);
            
            using (MemoryStream ms = new MemoryStream(bytesFromBase64, 0, bytesFromBase64.Length)) {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        //Ok
        /// <summary>
        /// image to base64 string
        /// </summary>
        /// <param name="_Image">the image to convert</param>
        /// <returns></returns>
        public static string imageToBase64String(Bitmap _Image) {
            using (MemoryStream ms = new MemoryStream()) {
                _Image.Save(ms, ImageFormat.Bmp);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        //Ok 
        /// <summary>
        /// FingerprintTemplate From Image
        /// </summary>
        /// <param name="_FingerImage">fingerprint image</param>
        /// <returns></returns>
        public static byte[] fingerprintImageToFingerprintTemplate(Bitmap _FingerImage) {
            Person unknownPerson = new Person();
            Fingerprint unknownFingerprint = new Fingerprint();
            unknownFingerprint.AsBitmap = _FingerImage;
            unknownPerson.Fingerprints.Add(unknownFingerprint);
            Afis.Extract(unknownPerson);
            return unknownPerson.Fingerprints[0].Template;
        }

        //Ok
        /// <summary>
        /// convert byte[] zmf-20 to bitmap
        /// </summary>
        /// <param name="_ImageBytes">byte[] from zmf-20 (2 grayscale values per byte)</param>
        /// <param name="_ColorAmp">contrast ( default is 17 )</param>
        /// <returns></returns>
        public static Bitmap zmf20ByteArrayToImage(byte[] _ImageBytes, int _ColorAmp) {
            Bitmap outImage = new Bitmap(256, 288);
            byte[] BytesForImage = new byte[73728];
            int pixelOffset = 0;
            for (int x = 0; x < 36864; x++) {
                byte thisByte = _ImageBytes[x + 1];
                int neenfirstNumber = (byte)((thisByte >> 4) & (byte)0x0F);
                int neensecondNumber = (byte)(thisByte & 0x0F);
                int firstNumber = neenfirstNumber * _ColorAmp;
                int secondNumber = neensecondNumber * _ColorAmp;
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

    }
}
