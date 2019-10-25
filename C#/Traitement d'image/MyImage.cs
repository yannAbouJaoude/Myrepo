using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace Projet_info_A2S2
{
    class MyImage
    {
        private string typeImage;
        private int tailleImage;
        private int tailleOffset;
        private int largeurImage;
        private int hauteurImage;
        private int nbByteParCouleur;
        private Mypixel[,] matriceRGB;

        public MyImage(string myfile)
        {
            byte[] tableauDeLecture =File.ReadAllBytes(myfile);
            if (myfile.Split('.')[1]=="csv")
            {

            }
            else if (myfile.Split('.')[1] == "bmp")
            {
                this.typeImage = "BM";
                this.tailleOffset = Convertir_Endian_To_Int(tableauDeLecture, 10,4);
                this.tailleImage = Convertir_Endian_To_Int(tableauDeLecture, 2,4);
                this.largeurImage = Convertir_Endian_To_Int(tableauDeLecture, 18,4);
                this.hauteurImage= Convertir_Endian_To_Int(tableauDeLecture, 22, 4); ;
                this.nbByteParCouleur= Convertir_Endian_To_Int(tableauDeLecture, 28, 2);
                this.matriceRGB  = new Mypixel[largeurImage, hauteurImage];
                Console.WriteLine(tableauDeLecture[54]);
            //    matriceRGB = new Mypixel[largeurImage, hauteurImage];
                for (int i = 54; i < tailleImage-3; i = i + 3)
                {
                    this.matriceRGB[(i/3-18)/largeurImage, (i/3 - 18) % largeurImage] =new Mypixel(tableauDeLecture[i], tableauDeLecture[i+1], tableauDeLecture[i+2]);
                     Console.WriteLine(tableauDeLecture[i]);
                }

                Console.WriteLine(this.typeImage);
                Console.WriteLine(this.tailleOffset);
                Console.WriteLine(this.tailleImage);
                Console.WriteLine(this.largeurImage);
                Console.WriteLine(this.hauteurImage);
                Console.WriteLine(this.nbByteParCouleur);
                
            }           
        }
        public void From_Image_To_File(byte[] file)
        {
            for (int i = 54; i < tailleImage; i = i+(largeurImage*3))
            {

                for (int j = 0; j < largeurImage*3; j=j+3)
                {
                    file[i + j] = matriceRGB[(i-54)%largeurImage, j/3].Rouge;
                    file[i + j+1] = matriceRGB[(i-54) % largeurImage, j/3].Vert;
                    file[i + j+2] = matriceRGB[(i-54) % largeurImage, j/3].Bleu;
                    Console.WriteLine(matriceRGB[(i - 54) % largeurImage, j / 3].Rouge);
                }
            }
        }
        public int Convertir_Endian_To_Int(byte[] tab,int position,int size)
        {
            int resultat=0;
            for (int i = 0; i < size; i++)
            {
                resultat = resultat + tab[i + position]*(int)(Math.Pow(256, i));
                Console.WriteLine(tab[i + position]);

            }
            
            return resultat;
        }
        public byte[] Convertir_Int_To_Endian(int val)
        {
            int reste = val;
            byte[] resultat = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                resultat[i] = (byte)(reste % 256);
                reste = reste / 256;
            }
            return resultat;
        }
        public void rotation90()
        {
            Mypixel[,] nouvelleMatriceRGB = new Mypixel[hauteurImage, largeurImage];
            for (int j = 0; j < largeurImage; j++)
            {
                for (int i = 0; i < hauteurImage; i++)
                {
                    nouvelleMatriceRGB[i, largeurImage-j-1] = matriceRGB[j, i];
                }
            }


            int temp = largeurImage;
            largeurImage = hauteurImage;
            hauteurImage = temp;
            this.matriceRGB = nouvelleMatriceRGB;




        }
    }
}
