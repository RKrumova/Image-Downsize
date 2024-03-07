using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Image_Downsizer
{
    internal class Downsize
    {

        static byte[] imageByte;
        public static byte[] ImageBytes { get; set; }
        public static void uploadByte()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String filePath = ofd.FileName;
                imageByte = System.IO.File.ReadAllBytes(filePath);
            }
            Console.WriteLine();
            for (int i = 0; i < imageByte.Length; i++) {
                Console.Write(imageByte[i]+" ");
            }
            //return ImageBytes;
        }
        private static void getDementions() {
            //first 24 bytes of the image file, typically include information about the image dimensions.
            int hight = imageByte.
        }
        private static void setDementions()
        {
            //from the percentage to dementions
        }
        public static void downloadByte()
        {
            //imageBytes
        }
        
    }
}
