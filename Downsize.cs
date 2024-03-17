using System;
using System.Collections.Generic;

using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Image_Downsizer
{
    internal class Downsize
    {
        static byte[] imageByte;
        static int h;
        static int w;
        static byte[] newByteImg;
        

        public static byte[] ImageBytes { get; set; }
        
        public static void uploadByte()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String filePath = ofd.FileName;
                    
                 byte[] header = new byte[54]; //54 is standered info
                 byte[] imageByte =File.ReadAllBytes(filePath);
                
                //System.IO.IOException: 'The process cannot access the file 'C:\Users\bitchin25\Pictures\Capture.PNG' because it is being used by another process.'
                byte[] image = new  byte[imageByte.Length - 54]; ;
                //the width and height are stored as 32-bit integers
                h = BitConverter.ToInt32(imageByte, 18);
                w = BitConverter.ToInt32(imageByte, 22);

                //}
            }/*
            Console.WriteLine();
            for (int i = 0; i < imageByte.Length; i++) {
                Console.Write(imageByte[i] + " ");
            }*/
            //return ImageBytes;
        }

        //first 24 bytes of the image file, typically include information about the image dimensions.


        public static string getDementions()
        {

            return "h:" + h + "w:" + w;


        }

        //
        public static void changePicture(int percentage)
        {
            Console.WriteLine(percentage);
            if (percentage != 0 || percentage.Equals("")) {
                Console.WriteLine("hi");
                long newH = h * percentage;
                long newW = w *percentage;
                
                //nPixie = new byte[newH, newW];

                //newByteImg = new byte[newH, newW];
                //  MATRIX !!!!!!!!!!!!!!!!!!!
                /* [][][]  --- [][] 
                 * [][][]      [][]
                 * [][][]      
                */
                long length = (long)newH * newW * 3;
                Console.Write(" " + length);

                newByteImg = new byte[length]; //rbg

                for (int hi = 0, wi=0;hi<newH; hi++){
                for(;wi<newW; wi++){
                        long x = (long)(wi*w)/newW;
                        long y = (long)(hi*h)/newH;
                        long oldIndex = (y*w + x) * 3; //
                        long newINdex = ((hi * newW + wi) * 3)+1;
                        Console.WriteLine("works");
                        Console.WriteLine("x, y: " + x +" "+ y + " old, new" + oldIndex + " "+ newINdex);
                        //!!!! dfs?
                        newByteImg[newINdex] = imageByte[oldIndex]; //null?
                        newByteImg[newINdex+1] = imageByte[oldIndex+1];
                        newByteImg[newINdex + 2] = imageByte[oldIndex + 2];
                        
                }}
                for (int i=0; i < newByteImg.Length - 1; i++)
                {
                    Console.Write(newByteImg[i] + " ");
                }
            }
            else
            {
                String smt =  "Error"; //change me later
                MessageBox.Show(smt);
            }
        }
        public static void downloadByte()
        {
            //imageBytes

        }

    }
}
