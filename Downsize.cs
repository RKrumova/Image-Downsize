using System;
using System.Collections.Generic;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Downsizer
{
    internal class Downsize
    {
        static byte[] imageByte;
        static int h;
        static int w;
        static long[] newByteImg;
        
        
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
        private static int percentage;
        public static void startProcess(int number)
        {
            percentage = number;
            int chunkCount = 3;
            int chunkWidth = w / chunkCount;
            int chunkHeight = h;
            byte[][] processedChunks = new byte[chunkCount][];
            Thread[] imgThreads = new Thread[3];
            for (int i = 0; i < chunkCount; i++)
            {
                imgThreads[i] = new Thread(() => changePicture(i * chunkWidth, (i + 1) * chunkWidth));
                imgThreads[i].Start();
            }
            foreach (Thread thread in imgThreads)
            {
                thread.Join();
            }
        }
        public static string getDementions()
        {

            return "h:" + h + "w:" + w;


        }

        //
        public static void changePicture(int startX, int endX)
        {
            Console.WriteLine(percentage);
            if (percentage != 0) {
                Console.WriteLine("hi");
                int newH = h * percentage;
                int newW = w *percentage;
                
                //nPixie = new byte[newH, newW];

                //newByteImg = new byte[newH, newW];
                //  MATRIX !!!!!!!!!!!!!!!!!!!
                /* [][][]  --- [][] 
                 * [][][]      [][]
                 * [][][]      
                */
                int length = (int)newH * newW * 3;
                Console.Write(" " + length);

                newByteImg = new long[length]; //rbg

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
