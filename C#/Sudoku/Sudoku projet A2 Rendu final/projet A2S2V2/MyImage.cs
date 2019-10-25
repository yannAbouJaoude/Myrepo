using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projet_A2S2V2
{

    class MyImage
    {
        // je nomme toujours mes variable de la façon suivante:
        // nom_positionOffset_taille
        // la position de l'offset est donné en décimal, la taille en bytes
        
        //14 byte
        private int typeImage_0_2;  //ASCII , nous devrions avoir BM soit 66+77*256 
        private int tailleFichier_2_4;//en bytes
        //2 application de création
        //2 application de création
        private int debutDeLImage_10_4; //54
        //40 bytes header
        private int tailleHeader_14_4;
        private int largeurEnPixel_18_4;
        private int hauteurEnPixel_22_4;
        private int nombrePlanCouleur_26_2;//1
        private int nombreDeBitParPixel_28_2;//24 en général, valeurs usuelles: 1,4,8,12,24,32
        //4 compression
        private int tailleImage_34_4;//en bytes, tailleFichier_2_4 -54
        //4 resolution en pixel/metre vertical
        //4 resolution en pixel/metre horizontal
        //4 palette de couleur, vaut 0
        //4 couleurs importante, vaut 0
        private byte[,,] tableauDePixel;// hauteur largeur couleur

        /// <summary>
        /// Constructeur MyImage à partir d'une image existante
        /// </summary>
        /// <param name="myfile"></param>
        public MyImage(string myfile)
        {
            byte[] tableauDeLecture = File.ReadAllBytes(myfile);
            this.typeImage_0_2 = Convertir_Endian_To_Int(tableauDeLecture, 0, 2);
            this.tailleFichier_2_4 = Convertir_Endian_To_Int(tableauDeLecture, 2, 4);
            this.debutDeLImage_10_4 = Convertir_Endian_To_Int(tableauDeLecture, 10, 4);
            this.tailleHeader_14_4 = Convertir_Endian_To_Int(tableauDeLecture, 14, 4);
            this.largeurEnPixel_18_4 = Convertir_Endian_To_Int(tableauDeLecture, 18, 4);
            this.hauteurEnPixel_22_4= Convertir_Endian_To_Int(tableauDeLecture, 22, 4);
            this.nombrePlanCouleur_26_2 = Convertir_Endian_To_Int(tableauDeLecture, 26, 2);
            this.nombreDeBitParPixel_28_2 = Convertir_Endian_To_Int(tableauDeLecture, 28, 2);
            this.tailleImage_34_4 = Convertir_Endian_To_Int(tableauDeLecture, 34, 4);
            this.tableauDePixel = new byte[hauteurEnPixel_22_4, largeurEnPixel_18_4, nombreDeBitParPixel_28_2 / 8];
            int compteurByte = debutDeLImage_10_4;
            for (int i = 0; i < hauteurEnPixel_22_4; i++)
            {
                for (int j = 0; j < largeurEnPixel_18_4; j++)
                {
                    for (int k = nombreDeBitParPixel_28_2 / 8 - 1; k >= 0 / 8; k = k - 1)
                    {
                        tableauDePixel[i, j, k] = tableauDeLecture[compteurByte];
                        compteurByte++;                   
                    }
                }
            }
        }
        /// <summary>
        /// Constructeur MyImage a partir de ses dimensions
        /// </summary>
        /// <param name="hauteur"></param>
        /// <param name="largeur"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        public MyImage(int hauteur, int largeur, int rouge, int vert, int bleu) // la somme doit etre positive
          {
              this.typeImage_0_2 = 77 * 256 + 66;       
              this.debutDeLImage_10_4 = 54;
              this.tailleHeader_14_4 = 40;
              this.largeurEnPixel_18_4 = largeur;
            this.hauteurEnPixel_22_4 = hauteur;
            this.nombrePlanCouleur_26_2 = 1;
              this.nombreDeBitParPixel_28_2 = 24;
              this.tailleImage_34_4 = largeurEnPixel_18_4*hauteurEnPixel_22_4*3;
              this.tailleFichier_2_4 = tailleImage_34_4 + debutDeLImage_10_4;
              tableauDePixel = new byte[hauteurEnPixel_22_4, largeurEnPixel_18_4, nombreDeBitParPixel_28_2 / 8];
              int compteurByte = debutDeLImage_10_4;
              for (int i = 0; i < hauteurEnPixel_22_4; i++)
              {
                  for (int j = 0; j < largeurEnPixel_18_4; j++)
                  {
                      
                    tableauDePixel[i, j, 0] = (byte)rouge;
                    tableauDePixel[i, j, 1] = (byte)vert;
                    tableauDePixel[i, j, 2] = (byte)bleu;

                }
              }
          }   

        /// <summary>
        /// Transforme un objet MyImage en un fichier bmp
        /// </summary>
        /// <param name="file"></param>
        public void From_Image_To_File(string file)
        {
            byte[] tableauEcriture = new byte[tailleFichier_2_4];
            for (int i = 0; i < this.debutDeLImage_10_4; i++)
            {
                tableauEcriture[i] = 0;
            }
            for (int i = 0; i < 2; i++)
            {
                tableauEcriture[i] = Convertir_Int_To_Endian(typeImage_0_2,2)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 2] = Convertir_Int_To_Endian(tailleFichier_2_4,4)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 10] = Convertir_Int_To_Endian(debutDeLImage_10_4, 4)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 14] = Convertir_Int_To_Endian(tailleHeader_14_4, 4)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 18] = Convertir_Int_To_Endian(largeurEnPixel_18_4, 4)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 22] = Convertir_Int_To_Endian(hauteurEnPixel_22_4, 4)[i];
            }
            for (int i = 0; i < 2; i++)
            {
                tableauEcriture[i + 26] = Convertir_Int_To_Endian(nombrePlanCouleur_26_2, 2)[i];
            }
            for (int i = 0; i < 2; i++)
            {
                tableauEcriture[i + 28] = Convertir_Int_To_Endian(nombreDeBitParPixel_28_2, 2)[i];
            }
            for (int i = 0; i < 4; i++)
            {
                tableauEcriture[i + 34] = Convertir_Int_To_Endian(tailleImage_34_4, 4)[i];
            }
            int compteurByte = debutDeLImage_10_4;
            for (int i = 0; i < hauteurEnPixel_22_4; i++)
            {
                for (int j = 0; j < largeurEnPixel_18_4; j ++)
                {
                    for (int k = (nombreDeBitParPixel_28_2 / 8)-1; k>=0; k=k-1)
                    {
                        tableauEcriture[compteurByte] = tableauDePixel[i,j,k];
                        compteurByte++;
                    }
                }
            }


            File.WriteAllBytes(file, tableauEcriture);
        }

        /// <summary>
        /// Convertie un nombre en base 256 se lisant de gauche a droite dans la base 10 de droite a gauche
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int Convertir_Endian_To_Int(byte[] tab, int position, int size)
        {
            int resultat = 0;
            for (int i = 0; i < size; i++)
            {
                resultat = resultat + tab[i + position] * (int)(Math.Pow(256, i));
            }
            return resultat;
        }

        /// <summary>
        /// Convertie un nombre en base 10 se lisant de droite a gauche dans la base 256  de gauche a droite.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="tailleResultat"></param>
        /// <returns></returns>
        public byte[] Convertir_Int_To_Endian(int val,int tailleResultat)
        {
            int reste = val;
            byte[] resultat = new byte[tailleResultat];
            for (int i = 0; i < tailleResultat; i++)
            {
                resultat[i] = (byte)(reste % 256);
                reste = reste / 256;
            }           
            return resultat;
        }

        /// <summary>
        /// Effectue une rotation de l'image de 90° en sens indirecte (sens horaire).
        /// </summary>
        public void rotation90()
        {
            byte[,,] nouveauTableauDePixel = new byte[largeurEnPixel_18_4, hauteurEnPixel_22_4, nombreDeBitParPixel_28_2 / 8];
            for (int j = 0; j < largeurEnPixel_18_4; j++)
            {
                for (int i = 0; i < hauteurEnPixel_22_4; i++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        nouveauTableauDePixel[j, i,k] = tableauDePixel[i, largeurEnPixel_18_4-j-1,k];
                    }                    
                }
            }
            int temp = largeurEnPixel_18_4;
            largeurEnPixel_18_4 = hauteurEnPixel_22_4;
            hauteurEnPixel_22_4 = temp;
            this.tableauDePixel = nouveauTableauDePixel;
        }

        /// <summary>
        /// Effectue deux rotation de l'image de 90° en sens indirecte (sens horaire).
        /// </summary>
        public void rotation180()
        {
            rotation90();
            rotation90();
        }

        /// <summary>
        /// Effectue trois rotation de l'image de 90° en sens indirecte (sens horaire) soit une rotation de 90° en sens anti-horaire.
        /// </summary>
        public void rotation270()
        {
            rotation90();
            rotation90();
            rotation90();
        }

        /// <summary>
        /// Multiplie un certain nombre entier de fois  la hauteur d'une Image et sa largeur.
        /// La hauteur etla largeur sont geré indépendamment
        /// On peux donc ainsi, alonger une image , l'élargir etc
        /// Pour avoir  un simple agrandissement, il suffit d'avoir le meme multiplicateur en hauteur et largeur
        /// </summary>
        /// <param name="multiplicateurHauteur"></param>
        /// <param name="multiplicateurLargeur"></param>
        public void Agrandir(int multiplicateurHauteur,int multiplicateurLargeur)
        {
            byte[,,] nouveauTableauDePixel = new byte[hauteurEnPixel_22_4*multiplicateurHauteur, largeurEnPixel_18_4*multiplicateurLargeur, nombreDeBitParPixel_28_2 / 8];
            for (int i = 0; i < hauteurEnPixel_22_4; i++)
            {
                for (int j = 0; j < largeurEnPixel_18_4; j++)
                {
                    for (int k = 0; k < multiplicateurHauteur; k++)
                    {
                        for (int l = 0; l < multiplicateurLargeur; l++)
                        {
                            for (int m = 0; m < nombreDeBitParPixel_28_2 / 8; m++)
                            {
                                nouveauTableauDePixel[i*multiplicateurHauteur+k,j*multiplicateurLargeur+l,m]= tableauDePixel[i, j, m];
                            }
                        }
                    }
                }
            }
            tableauDePixel = nouveauTableauDePixel;
            hauteurEnPixel_22_4 = hauteurEnPixel_22_4 * multiplicateurHauteur;
            largeurEnPixel_18_4 = largeurEnPixel_18_4 * multiplicateurLargeur;
            tailleImage_34_4 = tailleImage_34_4 * multiplicateurHauteur * multiplicateurLargeur;
            tailleFichier_2_4 = debutDeLImage_10_4 + tailleImage_34_4;
        }

        /// <summary>
        /// Divise un certain nombre entier de fois  la hauteur d'une Image et sa largeur.
        /// La hauteur etla largeur sont geré indépendamment
        /// On peux donc ainsi affiner une image , l'aplatir etc
        /// Pour avoir  un simple rétrécissement, il suffit d'avoir le meme diviseur en hauteur et largeur
        /// </summary>
        /// <param name="diviseurHauteur"></param>
        /// <param name="diviseurLargeur"></param>
        public void Retrecir(int diviseurHauteur, int diviseurLargeur)
        {
            int temp;
            byte[,,] nouveauTableauDePixel = new byte[hauteurEnPixel_22_4 / diviseurHauteur, largeurEnPixel_18_4 /diviseurLargeur, nombreDeBitParPixel_28_2 / 8];
            for (int i = 0; i < hauteurEnPixel_22_4 / diviseurHauteur; i++)
            {
                for (int j = 0; j < largeurEnPixel_18_4 / diviseurLargeur; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        temp = 0;                      
                        for (int l = 0; l < diviseurHauteur; l++)
                        {
                            for (int m = 0; m < diviseurLargeur; m++)
                            {
                                temp = temp + tableauDePixel[i*diviseurHauteur + l, j*diviseurLargeur + m, k];
                            }
                        }
                        temp = temp / (diviseurHauteur * diviseurLargeur);
                        nouveauTableauDePixel[i, j, k] = (byte)temp;
                    }
                }
            }
            tableauDePixel = nouveauTableauDePixel;
            hauteurEnPixel_22_4 = hauteurEnPixel_22_4 / diviseurHauteur;
            largeurEnPixel_18_4 = largeurEnPixel_18_4 /diviseurLargeur;
            tailleImage_34_4 = tailleImage_34_4 /(diviseurHauteur * diviseurLargeur);
            tailleFichier_2_4 = debutDeLImage_10_4 + tailleImage_34_4;



        }

        /// <summary>
        /// Redimmensionne la hauteur d'une Image et sa largeur.
        /// La hauteur etla largeur sont geré indépendamment
        /// On cherche l'écriture fractionnaire des coefficient demandé afin d'obtenir des entiers
        /// Puis cette fonction Appel les fonction aggrandir et retrecir
        /// </summary>
        /// <param name="coefficientHauteur"></param>
        /// <param name="coefficientLargeur"></param>
        public void Redimmensionner(double coefficientHauteur, double coefficientLargeur)            
        {
            Console.WriteLine("hey1" + (nombrefractionnaire(coefficientHauteur)[0]));
            Console.WriteLine("hey1" + (nombrefractionnaire(coefficientHauteur)[1]));
            Console.WriteLine("hey1"+(nombrefractionnaire(coefficientLargeur)[0]));
            Console.WriteLine("hey1" + (nombrefractionnaire(coefficientLargeur)[1]));

            int[] rapportHauteur = ApproximationDUneFraction(nombrefractionnaire(coefficientHauteur));
            int[] rapportLargeur = ApproximationDUneFraction(nombrefractionnaire(coefficientLargeur));
            Console.WriteLine("hey"+rapportHauteur[0]);
            Console.WriteLine("hey"+rapportHauteur[1]);
            Console.WriteLine("hey"+rapportLargeur[0]);
            Console.WriteLine("hey"+rapportLargeur[1]);
            Agrandir(rapportHauteur[0], rapportLargeur[0]);
            Retrecir(rapportHauteur[1], rapportLargeur[1]);
        }

        /// <summary>
        /// Utile pour le redimmensionnement
        /// Sert a réduire le nombre de calcul
        /// Par exemple, le coefficient 2,01 a pour ecriture fractionnaire 201/100
        /// Soit un agrandissement de 201 et un retrecissement de 100, dépassant la minute
        /// Pour finalement un résultat extremement proche de celui du coefficient 2
        /// Cette fonction fera l'approximation de la fraction 201/100 pour la remplacer par 2/1 dans notre exemple.
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        static int[] ApproximationDUneFraction(int[] fraction)
        {
            while (fraction[0]>20&& fraction[1] > 20)
            {
                fraction[0] = fraction[0] / 10;
                fraction[1] = fraction[1] / 10;
            }
            return fraction;
        }

        /// <summary>
        /// Utile pour le redimmensionnement
        /// Le dividende sera le coefficient d'aggrandissement
        /// Le diviseur sera le coefficient de retrecissement
        /// La fraction est déterminer grace au PGCD
        /// </summary>
        /// <param name="coefficient"></param>
        /// <returns></returns>
        static int[]nombrefractionnaire(double coefficient)
        {
               int temp = Convert.ToInt32(coefficient);
            int retrecissement=1;
            int[]resultat = new int[2];//0 pour le multiplicateur, 1 pour le diviseur           
            while (coefficient-(double)temp>=0.0001)// Parceque !=0 posaisprobeme pour 2,01 sans raison apparente
            {
                Console.WriteLine("pouet");
                coefficient = coefficient * 10;
                retrecissement = retrecissement * 10;
                temp = Convert.ToInt32(coefficient);              
            }
            int multiplicateur = (int)coefficient;
            int pgcd = PGCD(multiplicateur, retrecissement);
            resultat[0] = multiplicateur / pgcd;
            resultat[1] = retrecissement / pgcd;
            return resultat;
        }

        /// <summary>
        /// Utile pour derterminer le nombre fractionnaire issue du coefficient du redimmensionnement
        /// Méthode récursive, récupéré dans un cours de 3eme
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int PGCD(int a, int b)
        {
            int temp = a % b;
            if (temp == 0)
                return b;
            return PGCD(b, temp);
        }

        /// <summary>
        /// Superpose laseconde image sur la premiere
        /// Lesimages sont aligné en bas a gauche
        /// Les pixels d'une image sortant de la dimension de l'autre image sont afficher avec des couleur/2
        /// </summary>
        /// <param name="SecondeImage"></param>
        public void Superposition(MyImage SecondeImage) //verifier les couleur noir et blanc + fonction
        {
            if (this.nombreDeBitParPixel_28_2 == SecondeImage.nombreDeBitParPixel_28_2)
            {
                int nouvelleLargeurEnPixel;
                int nouvelleHauteurEnPixel;
                if (this.largeurEnPixel_18_4 > SecondeImage.largeurEnPixel_18_4)
                {
                    nouvelleLargeurEnPixel = this.largeurEnPixel_18_4;
                }
                else
                {
                    nouvelleLargeurEnPixel = SecondeImage.largeurEnPixel_18_4;
                }
                if (this.hauteurEnPixel_22_4 > SecondeImage.hauteurEnPixel_22_4)
                {
                    nouvelleHauteurEnPixel = this.hauteurEnPixel_22_4;
                }
                else
                {
                    nouvelleHauteurEnPixel = SecondeImage.hauteurEnPixel_22_4;
                }
                byte[,,] nouveauTableauDePixel = new byte[nouvelleHauteurEnPixel, nouvelleLargeurEnPixel, nombreDeBitParPixel_28_2 / 8];
                for (int i = 0; i < nouvelleLargeurEnPixel; i++)
                {
                    for (int j = 0; j < nouvelleHauteurEnPixel; j++)
                    {
                        for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                        {
                            nouveauTableauDePixel[j, i, k] = 0;
                        }
                    }
                }
                for (int i = 0; i < this.largeurEnPixel_18_4; i++)
                {
                    for (int j = 0; j < this.hauteurEnPixel_22_4; j++)
                    {
                        for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                        {
                            nouveauTableauDePixel[j, i, k] = (byte)(this.tableauDePixel[j, i, k] / 2);
                        }
                    }
                }
                for (int i = 0; i < SecondeImage.largeurEnPixel_18_4; i++)
                {
                    for (int j = 0; j < SecondeImage.hauteurEnPixel_22_4; j++)
                    {
                        for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                        {
                            nouveauTableauDePixel[j, i, k] = (byte)(nouveauTableauDePixel[j, i, k]+(SecondeImage.tableauDePixel[j, i, k] / 2));
                        }
                    }
                }
                this.tableauDePixel = nouveauTableauDePixel;
                this.largeurEnPixel_18_4 = nouvelleLargeurEnPixel;
                this.hauteurEnPixel_22_4 = nouvelleHauteurEnPixel;
                this.tailleImage_34_4 = largeurEnPixel_18_4 * hauteurEnPixel_22_4 * nombreDeBitParPixel_28_2 / 8;
                this.tailleFichier_2_4 = tailleImage_34_4 + debutDeLImage_10_4;
            }
            else
            {
                Console.WriteLine("Les deux images ne sont pas compatible");
            }
        }

        /// <summary>
        /// Replace chaque couleur de chaque pixel par la moyenne des couleur de son pixel
        /// </summary>
        public void NuanceNoirEtBlanc()
        {
            byte[,,] nouveauTableauDePixel = new byte[hauteurEnPixel_22_4, largeurEnPixel_18_4, nombreDeBitParPixel_28_2/8];
            for (int i = 0; i < this.largeurEnPixel_18_4; i++)
            {
                for (int j = 0; j < this.hauteurEnPixel_22_4; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        for (int l = 0; l < nombreDeBitParPixel_28_2 / 8; l++)
                        {
                            nouveauTableauDePixel[j, i, l] = (byte)(nouveauTableauDePixel[j, i, l]+(this.tableauDePixel[j, i, k] / (nombreDeBitParPixel_28_2 / 8)));
                        }                     
                    }
                }
            }
            this.tableauDePixel = nouveauTableauDePixel;
        }

        /// <summary>
        /// Appel Nuance noir et blanc puis assigne la couleur noir au case noir ou gris foncé et blanche au autres
        /// </summary>
        public void SansNuanceNoirEtBlanc()
        {
            NuanceNoirEtBlanc();
            byte[,,] nouveauTableauDePixel = new byte[hauteurEnPixel_22_4, largeurEnPixel_18_4, nombreDeBitParPixel_28_2 / 8];
            for (int i = 0; i < this.largeurEnPixel_18_4; i++)
            {
                for (int j = 0; j < this.hauteurEnPixel_22_4; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        if (tableauDePixel[j, i, k] < 128)
                        {
                            nouveauTableauDePixel[j, i, k] = 0;
                        }
                        else
                        {
                            nouveauTableauDePixel[j, i, k] = 255;
                        }
                    }
                }
            }
            this.tableauDePixel = nouveauTableauDePixel;
        }

        /// <summary>
        /// Applique une matrice de convolution 3*3 à une image. 
        /// Les contours n'étant pas touchée par la matrice, ilsont gardé intacte en étant directement copié de l'ancienne matrice de pixel à la nouvelle
        /// </summary>
        /// <param name="convMatrice"></param>
        /// <param name="diviseur"></param>
        void AppliquerConvMatrice(int[,] convMatrice, int diviseur) //étendre
        {
            byte[,,] nouveauTableauDePixel = new byte[hauteurEnPixel_22_4, largeurEnPixel_18_4, nombreDeBitParPixel_28_2 / 8];
            for (int i = 1; i < hauteurEnPixel_22_4-1; i++)
            {
                for (int j = 1; j < largeurEnPixel_18_4-1; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2/8; k++)
                    {
                        int temp = ((tableauDePixel[i - 1, j - 1, k] * convMatrice[0, 0]) + (tableauDePixel[i, j - 1, k] * convMatrice[1, 0]) + (tableauDePixel[i + 1, j - 1, k] * convMatrice[2, 0]) + (tableauDePixel[i - 1, j, k] * convMatrice[0, 1]) + (tableauDePixel[i, j, k] * convMatrice[1, 1]) + (tableauDePixel[i + 1, j, k] * convMatrice[2, 1]) + (tableauDePixel[i - 1, j + 1, k] * convMatrice[0, 2]) + (tableauDePixel[i, j + 1, k] * convMatrice[1, 2]) + (tableauDePixel[i + 1, j + 1, k] * convMatrice[2, 2]))/diviseur;
                        if (temp < 0)
                        {
                            nouveauTableauDePixel[i, j, k] = 0;
                        }
                        else if (temp > 255)
                        {
                            nouveauTableauDePixel[i, j, k] = 255;
                        }
                        else
                        {
                            nouveauTableauDePixel[i, j, k] = (byte)temp;
                        }
                    }
                }
            }
            for (int i = 1; i < hauteurEnPixel_22_4 - 1; i++)
            {
                for (int k = 0; k < nombreDeBitParPixel_28_2/8; k++)
                {
                    nouveauTableauDePixel[i, 0, k] = nouveauTableauDePixel[i, 1, k];
                    nouveauTableauDePixel[i, largeurEnPixel_18_4-1, k] = nouveauTableauDePixel[i, largeurEnPixel_18_4-2, k];
                }               
            }
            for (int j = 0; j < largeurEnPixel_18_4; j++)
            {
                for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                {
                    nouveauTableauDePixel[0, j, k] = nouveauTableauDePixel[1, j, k];
                    nouveauTableauDePixel[hauteurEnPixel_22_4-1, j ,k] = nouveauTableauDePixel[hauteurEnPixel_22_4-2, j , k];
                }
            }
            tableauDePixel = nouveauTableauDePixel;


        }

        /// <summary>
        /// 
        /// </summary>
        public void Flou()
        {
            int[,] convMatrice = new int[3, 3];
            convMatrice[0, 0] = 1;
            convMatrice[0, 1] = 1;
            convMatrice[0, 2] = 1;
            convMatrice[1, 0] = 1;
            convMatrice[1, 1] = 1;
            convMatrice[1, 2] = 1;
            convMatrice[2, 0] = 1;
            convMatrice[2, 1] = 1;
            convMatrice[2, 2] = 1;
            AppliquerConvMatrice(convMatrice,9);
        }

        /// <summary>
        /// Applique une matrice de convolution du flou à une image.
        /// </summary>
        public void AugmenterLeContraste()
        {
            int[,] convMatrice = new int[3, 3];
            convMatrice[0, 0] = 0;
            convMatrice[0, 1] = -1;
            convMatrice[0, 2] = 0;
            convMatrice[1, 0] = -1;
            convMatrice[1, 1] = 5;
            convMatrice[1, 2] = -1;
            convMatrice[2, 0] = 0;
            convMatrice[2, 1] = -1;
            convMatrice[2, 2] = 0;
            AppliquerConvMatrice(convMatrice, 1);
        }

        /// <summary>
        /// Applique une matrice de convolution du renforcement des bords à une image.
        /// </summary>
        public void RenforcementDesBord()
        {
            int[,] convMatrice = new int[3, 3];
            convMatrice[0, 0] = 0;
            convMatrice[0, 1] = 0;
            convMatrice[0, 2] = 0;
            convMatrice[1, 0] = -1;
            convMatrice[1, 1] = 1;
            convMatrice[1, 2] = 0;
            convMatrice[2, 0] = 0;
            convMatrice[2, 1] = 0;
            convMatrice[2, 2] = 0;
            AppliquerConvMatrice(convMatrice, 1);
        }

        /// <summary>
        /// Applique une matrice de convolution de la detection des bords à une image.
        /// </summary>
        public void DetectionDesBords()
        {
            int[,] convMatrice = new int[3, 3];
            convMatrice[0, 0] = 0;
            convMatrice[0, 1] = 1;
            convMatrice[0, 2] = 0;
            convMatrice[1, 0] = 1;
            convMatrice[1, 1] = -4;
            convMatrice[1, 2] = 1;
            convMatrice[2, 0] = 0;
            convMatrice[2, 1] = 1;
            convMatrice[2, 2] = 0;
            AppliquerConvMatrice(convMatrice, 1);
        }

        /// <summary>
        /// Applique une matrice de convolution du reppoussage à une image.
        /// </summary>
        public void Repoussage()
        {
            int[,] convMatrice = new int[3, 3];
            convMatrice[0, 0] = -2;
            convMatrice[0, 1] = -1;
            convMatrice[0, 2] = 0;
            convMatrice[1, 0] = -1;
            convMatrice[1, 1] = 1;
            convMatrice[1, 2] = 1;
            convMatrice[2, 0] = 0;
            convMatrice[2, 1] = 1;
            convMatrice[2, 2] = 2;
            AppliquerConvMatrice(convMatrice, 1);
        }

        /// <summary>
        /// Renvoie le maximum des 2 entiers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int max(int a , int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        /// <summary>
        /// Renvoie le minimum des 2 entiers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            return b;
        }

        /// <summary>
        /// Utile pour afficher le pourcentage de calculs des opérations les plus longues
        /// </summary>
        public static int compteur = 0;

        /// <summary>
        /// Affiche le pourcentage de calculs des opérations les plus longues
        /// </summary>
        /// <param name="total"></param>
        public void EtatChargement(int total)
        {
            Console.WriteLine((double)compteur / (double)total * 100 + " %");
        }

        /// <summary>
        /// Trace un segment d'un point A à un point B
        /// On trouve l'équation de droite y=Ax+b ou x=y
        /// et on regarde pour chaque pixel si il vérifie l'équation dans l'interval [Ax, Bx] ou [Ay,By]
        /// Linterval de tolérance lors de la vérification de l'équation determine l'épaisseur
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="epaisseur"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        /// <param name="chargement"></param>
        public void TracerUnSegment(int x1, int y1, int x2,int y2,double epaisseur, byte rouge, byte vert, byte bleu,int chargement)
        {
            compteur++;
            if (chargement != 0) {
                EtatChargement(chargement);
            }

            double a = ((double)y2 - (double)y1) / ((double)x2 - (double)x1);
            double b = (double)y1 - (a * (double)x1);
            int maxX = max(x1, x2);
            int minX = min(x1, x2);
            for (double i = 0; i < largeurEnPixel_18_4; i++)
            {
                for (double j = 0; j < hauteurEnPixel_22_4; j++)
                {
                      if ((a*i+b<j+epaisseur && a * i + b >j- epaisseur) && (i>= min(x1, x2) && i<= max(x1, x2) && j>= min(y1, y2) && j<= max(y1, y2)))
                    {                     
                        tableauDePixel[(int)i, (int)j, 0] = rouge;
                        tableauDePixel[(int)i, (int)j, 1] = vert;
                        tableauDePixel[(int)i, (int)j, 2] = bleu;
                    }
                }
            }
            if (x1 == x2||a>500)
            {
                for (int i = min(y1,y2); i < max(y1,y2); i++)
                {     
                    for (int j = x1; j < (int)(x1 + 2*epaisseur); j++)
                    {
                        tableauDePixel[(int)j, (int)i, 0] = bleu;
                        tableauDePixel[(int)j, (int)i, 1] = vert;
                        tableauDePixel[(int)j, (int)i, 2] = rouge;
                    }
                }
            }
        }

        /// <summary>
        /// Appel la fonction tracer un Segment avec la coordonné des points des segment a tracer
        /// Pour cela on se déplace sur un cercle avec un pas de 2 *pi/ nombredecote
        /// Le polygone sera inscrit dans ce cercle
        /// </summary>
        /// <param name="centreX"></param>
        /// <param name="centreY"></param>
        /// <param name="rayon"></param>
        /// <param name="nombredecote"></param>
        /// <param name="epaisseur"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        /// 
        public void polygone(int centreX, int centreY, double rayon, int nombredecote, double epaisseur, byte rouge, byte vert, byte bleu) 
        {            
            for (int i = 0; i < nombredecote; i++)
            {
                TracerUnSegment((int)(rayon * Math.Cos(2 * Math.PI * i / nombredecote))+ centreX, (int)(rayon * Math.Sin(2 * Math.PI * i / nombredecote))+ centreY, (int)(rayon * Math.Cos(2 * Math.PI * (i + 1) / nombredecote))+ centreX, (int)(rayon * Math.Sin(2 * Math.PI * (i + 1) / nombredecote))+ centreY, epaisseur, rouge, vert, bleu,nombredecote);

            }
        }
        /// <summary>
        /// Appel la fonction tracer un Segment avec la coordonné des points des segment a tracer
        /// Pour cela on se déplace sur 2 cercle avec un pas de 2 *pi/ nombredecote
        /// L'origine radial d'un des cercle est décalé de pi/ nombredecote
        /// Les coordonnés des points sont les meme que pour 2 polygones 
        /// </summary>
        /// <param name="centreX"></param>
        /// <param name="centreY"></param>
        /// <param name="rayon"></param>
        /// <param name="nombredecote"></param>
        /// <param name="epaisseur"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        /// <param name="rayon2"></param>
        public void Etoile(int centreX, int centreY, double rayon, int nombredecote, double epaisseur, byte rouge, byte vert, byte bleu,double rayon2)
        {
            compteur = compteur - 1;
            for (int i = 0; i < nombredecote; i++)
            {
                TracerUnSegment((int)(rayon * Math.Cos(2 * Math.PI * i / nombredecote)) + centreX, (int)(rayon * Math.Sin(2 * Math.PI * i / nombredecote)) + centreY, (int)(rayon2 * Math.Cos(2 * Math.PI * (i + 0.5) / nombredecote)) + centreX, (int)(rayon2 * Math.Sin(2 * Math.PI * (i + 0.5) / nombredecote)) + centreY, epaisseur, rouge, vert, bleu, nombredecote);
                TracerUnSegment((int)(rayon * Math.Cos(2 * Math.PI * (i + 1) / nombredecote)) + centreX, (int)(rayon * Math.Sin(2 * Math.PI * (i + 1) / nombredecote)) + centreY, (int)(rayon2 * Math.Cos(2 * Math.PI * (i + 0.5) / nombredecote)) + centreX, (int)(rayon2 * Math.Sin(2 * Math.PI * (i + 0.5) / nombredecote)) + centreY, epaisseur, rouge, vert, bleu, nombredecote);
                compteur = compteur - 1;
            }
        }

        /// <summary>
        /// Dessine une fractal qui remplace l'image
        /// L'ensemble de Mandelbrot donné dans à la sortie peut être trompeur, car il y a plein de couleurs, mais en réalité la fractale n'est qu'une figure.
        /// l'ensemble de Mandelbrot est une fractale définie comme l'ensemble des points c du plan complexe pour lesquels la suite de nombres complexes définie par récurrence par :
        /// Z indice(0)=0;
        /// Z indice(n+1)=Z²indice(n) +c 
        /// </summary>
        /// <param name="ZOOM"></param>
        /// <param name="START_Y"></param>
        /// <param name="START_X"></param>
        /// <param name="MAX_ITERATION"></param>
        public void fractalMandelbrot(double ZOOM, double START_Y, double START_X, int MAX_ITERATION) {
            for (int y = 0; y < hauteurEnPixel_22_4; y++) {
                double partieImaginaire = (y - largeurEnPixel_18_4 / 2.0) / (0.5 * ZOOM * hauteurEnPixel_22_4) + START_Y;

                // Pour chaque pixel en X
                for (int x = 0; x < largeurEnPixel_18_4; ++x) {
                    double partieReel = 1.5 * (x - largeurEnPixel_18_4 / 2.0) / (0.5 * ZOOM * largeurEnPixel_18_4) + START_X;
                    double nouveauReel = 0, nouveauImaginaire = 0, ancienReel = 0, ancienImaginaire = 0;
                    int i = 0;

                    while ((nouveauReel * nouveauReel + nouveauImaginaire * nouveauImaginaire) < 4.0 && i < MAX_ITERATION) {
                        ancienReel = nouveauReel;
                        ancienImaginaire = nouveauImaginaire;
                        nouveauReel = ancienReel * ancienReel - ancienImaginaire * ancienImaginaire + partieReel;
                        nouveauImaginaire = 2.0 * ancienReel * ancienImaginaire + partieImaginaire;
                        ++i;
                    }
                    tableauDePixel[y, x, 0] = (byte)(25*i);// (byte) fait une troncature, donc recommence a 0 si il dépasse 255
                    tableauDePixel[y, x, 1] = (byte)(45*i);
                    tableauDePixel[y, x, 2] = (byte)(60*i);
                    compteur++;
                    if (compteur % 360000 == 0)
                    {
                        Console.WriteLine((int)(((double)compteur / (double)(tailleImage_34_4/3)) * 100) + " %");
                    }
                }
                
            } }

        /// <summary>
        /// Les ensembles de Julia sont basés sur le même principe que l'ensemble de Mandelbrot. La formule est exactement la même
        /// Z indice(n+1)=Z²indice(n) +c 
        /// Seul les valeurs de départ c changent.
        /// La fractale prend la place de l'image
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="zoom"></param>
        /// <param name="iteration_max"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        /// <param name="c_r"></param>
        /// <param name="c_i"></param>
        public void fractalJulia(double x1, double x2, double y1, double y2, double zoom, int iteration_max, byte rouge, byte vert, byte bleu, double c_r, double c_i)
        {
            double image_x = (x2 - x1) * zoom;
            double image_y = (y2 - y1) * zoom;
            for (int x = 0; x < image_x; x++)
            {
                for (int y = 0; y < image_y; y++)
                {
                    double zPartieReel = x / zoom + x1;
                    double zPartieImaginaire = y / zoom + y1;
                    int i = 0;
                    do
                    {
                        double temp = zPartieReel;
                        zPartieReel = zPartieReel * zPartieReel - zPartieImaginaire * zPartieImaginaire + c_r;
                         zPartieImaginaire = 2 * zPartieImaginaire * temp + c_i;
                        i = i + 1;
                    } while (zPartieReel * zPartieReel + zPartieImaginaire * zPartieImaginaire < 4 && i < iteration_max);
              
                        tableauDePixel[x, y, 0] = (byte)(bleu * i);
                        tableauDePixel[x, y, 1] = (byte)(vert * i);
                        tableauDePixel[x, y, 2] = (byte)(rouge * i);
                    
                }
                if (x % 100 == 0) {
                    Console.WriteLine(((double)x/(double)image_x)*100 +" %");
                }
            }
        }

        /// <summary>
        /// Méthode récursive 
        /// Appel tracer un segment si l'itération voulu et atteinte
        /// Sinon s'appel 4 fois
        /// Fournie les coordonnées nécéssaire pour tracer les segments
        /// doit etre appeler 3 fois pour tracer un flocon, selon lesangle d'un triangle équilatéral
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="level"></param>
        /// <param name="epaisseur"></param>
        /// <param name="rouge"></param>
        /// <param name="vert"></param>
        /// <param name="bleu"></param>
        /// <param name="chargement"></param>
        public void fractaleFlocon(int x1, int y1, int x2, int y2, int level,int epaisseur, byte rouge, byte vert, byte bleu,int chargement)
        {
            if (level > 0)
            {
                int x3 = (2 * x1 + x2) / 3;
                int y3 = (2 * y1 + y2) / 3;
                int x5 = (x1 + 2 * x2) / 3;
                int y5 = (y1 + 2 * y2) / 3;
                int x4 = (int)(x3 + (x5 - x3) / 2 + (y5 - y3) * 1.732 / 2);
                int y4 = (int)(y3 - (x5 - x3) * 1.732 / 2 + (y5 - y3) / 2);
                fractaleFlocon(x1, y1, x3, y3, level - 1, epaisseur, rouge, vert, bleu, chargement);
                fractaleFlocon(x3, y3, x4, y4, level - 1, epaisseur, rouge, vert, bleu, chargement);
                fractaleFlocon(x4, y4, x5, y5, level - 1, epaisseur, rouge, vert, bleu, chargement);
                fractaleFlocon(x5, y5, x2, y2, level - 1, epaisseur, rouge, vert, bleu, chargement);
            }
            else
            {
                TracerUnSegment(x1,y1,x2,y2,epaisseur,rouge, vert,bleu,chargement);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Histogramme()
        {
            int[,] tableauHistogramme = new int[256, nombreDeBitParPixel_28_2 / 8];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < nombreDeBitParPixel_28_2 / 8; j++)
                {
                    tableauHistogramme[i, j] = 0;
                }
            }
            for (int i = 0; i < this.hauteurEnPixel_22_4; i++)
            {
                for (int j = 0; j < this.largeurEnPixel_18_4; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        tableauHistogramme[tableauDePixel[i, j, k], k]++;
                    }
                }
            }
            int maxHistogramme = 100;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < nombreDeBitParPixel_28_2 / 8; j++)
                {
                    if (tableauHistogramme[i, j] > maxHistogramme)
                    {
                        maxHistogramme = tableauHistogramme[i, j];
                    }
                }
            }
            byte[,,] nouveauTableauDePixel = new byte[maxHistogramme*3, 256, nombreDeBitParPixel_28_2 / 8];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < maxHistogramme*3; j++)
                {
                    for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                    {
                        nouveauTableauDePixel[j, i, k] = 0;
                    }
                }
            }

            for (int i = 0; i < 256; i++)
            {
                for (int k = 0; k < nombreDeBitParPixel_28_2 / 8; k++)
                {
                    for(int j =0; j <  tableauHistogramme[i, k]; j++)
                    {
                        nouveauTableauDePixel[j+(k*maxHistogramme), i, k] = 255;
                    }
                }
            }
            tableauDePixel = nouveauTableauDePixel;
            hauteurEnPixel_22_4 = maxHistogramme*3;
            largeurEnPixel_18_4 = 256;
            tailleImage_34_4 = hauteurEnPixel_22_4*largeurEnPixel_18_4*3;
            tailleFichier_2_4 = tailleImage_34_4 + 54;
       
            Redimmensionner(0.125, maxHistogramme / 1024 + 1);
        }

        /// <summary>
        /// Rend disponible en lecture la plus petite des dimensions (hauteur ou largeur) d'une image 
        /// </summary>
        public int petiteDimension
     {
         get { return min(largeurEnPixel_18_4,hauteurEnPixel_22_4); }      
     }

        /// <summary>
        /// Rend disponible en lecture la largeur d'une image
        /// </summary>
        public int LaLargeur
        {
            get { return largeurEnPixel_18_4; }
        }

        /// <summary>
        /// Rend disponible en lecture la hauteur d'une image
        /// </summary>
        public int LaHauteur
        {
            get { return hauteurEnPixel_22_4; }
        }
    }
}
