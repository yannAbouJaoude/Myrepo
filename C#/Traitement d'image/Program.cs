using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Projet_info_A2S2
{
    class Program
    {
        static void Main(string[] args)
        {
            string myfile = "Test003.bmp";
            MyImage MonImage = new MyImage(myfile);
            byte[] mfile = File.ReadAllBytes("Test003.bmp");
           /* for (int i = 54; i < mfile.Length; i++)
            {
                Console.Write(mfile[i] + "\t");
            }*/
                Process.Start("Test003.bmp");
            MonImage.rotation90();
            Console.WriteLine("Header \n");
              for (int i = 0; i < 14; i++)
                  Console.Write(mfile[i] + " ");
              Console.WriteLine("\n HEADER INFO \n\n");
              for (int i = 14; i < 54; i++)
                  Console.Write(mfile[i] + " ");
              Console.WriteLine("\n\n IMAGE \n");
            /*     for (int i = 54; i < mfile.Length; i++)
                 {
                     Console.Write(mfile[i] + "\t");
                     if (mfile[i] == 0) mfile[i] = 255;
                     else mfile[i] = 0;
                 }*/
            MonImage.From_Image_To_File(mfile);
              File.WriteAllBytes("Sortie.bmp", mfile);
              Process.Start("Sortie.bmp");
            Console.ReadKey();
        }
    }
}
