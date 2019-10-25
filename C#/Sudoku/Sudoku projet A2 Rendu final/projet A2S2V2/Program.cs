using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace projet_A2S2V2
{
    class Program
    {
        static void Main(string[] args)
        {
            string imageParDefaut = "coco.bmp";
            while (!File.Exists(imageParDefaut))
            {
                Console.WriteLine("L'image " + imageParDefaut + " n'a pas été trouvée ou n'existe pas a l'emplacement spécifié");
                Console.WriteLine("Veuillez entrer le nom d'une image");
                imageParDefaut = Console.ReadLine();
                if (imageParDefaut[imageParDefaut.Length - 1] != 'p')
                {
                    imageParDefaut += ".bmp";
                }
            }
            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            
            string nomDeLImageChargee = imageParDefaut;
            MyImage maSuperImageOfTheDead= new MyImage(imageParDefaut);
            int rouge;
            int vert;
            int bleu;
            int largeur;
            int hauteur;
            int epaisseur;
            string imageDeSortie = "sortie.bmp";
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "Ouvrir une image","Créer une image vierge","Noir et blanc", "Nuance de gris", "Rotation 90", "Rotation 180", "Rotation 270","Agrandir","Retrecir","Superposition","Detection des contours","Renforcement des bords","Flou","Repoussage","Créer une image décrivant une forme géométrique (Polygone) ","Redimmensionner","Flocon de neige","Fractal de Julia", "Fractale de Mandelbrot", "Tracer un Segment", "Histogramme", "Créer une image décrivant une forme géométrique ( ETOILE )", "Enregistrer sous ","Enregistrer et Afficher","Quitter" };
            for (int i = 0; i < ListeExo.GetLength(0); i++)
            {
                if (i == positionMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(ListeExo[i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            while (resterDansLeMenu)
            {
                choix = Console.ReadKey().Key;
                Console.Clear();

                if (choix == ConsoleKey.UpArrow && positionMenu > 0) { positionMenu--; }
                if (choix == ConsoleKey.DownArrow && positionMenu < ListeExo.GetLength(0) - 1) { positionMenu++; }
                if (choix == ConsoleKey.Enter)
                {
                    switch (positionMenu) ////////////////Les instructions par exercices
                    {
                        case 0:
                            Console.WriteLine("L'image chargée par défaut est " + imageParDefaut);
                            Console.WriteLine("L'image actuellement chargé est " + nomDeLImageChargee);
                            Console.WriteLine("Veuillez entrer le nom de la photo");
                            nomDeLImageChargee = Console.ReadLine();
                            if (nomDeLImageChargee[nomDeLImageChargee.Length-1] != 'p')
                            {
                                nomDeLImageChargee+=".bmp";
                            }
                            if (File.Exists(nomDeLImageChargee))
                            {
                                Console.WriteLine("L'image "+nomDeLImageChargee+" à été chargée avec succès");
                                maSuperImageOfTheDead = new MyImage(nomDeLImageChargee);
                            }
                            else
                            {
                                Console.WriteLine("Echec du chargement de l'image");
                                Console.WriteLine("Chargement de l'image par défaut : " + imageParDefaut);
                                nomDeLImageChargee = imageParDefaut;
                                maSuperImageOfTheDead = new MyImage(imageParDefaut);
                            }
                            break;
                        case 1:
                            Console.WriteLine("Quel sera la résolution de l'image?");
                            Console.WriteLine("Largeur : ");
                            largeur = DemanderInt(8,12800)/4*4;
                            Console.WriteLine("Hauteur : ");
                            hauteur = DemanderInt(8, 12800)/4*4;
                            Console.WriteLine("Quel sera la couleur de fond l'image? (code RGB)");
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(0, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(0, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(0, 255);
                            maSuperImageOfTheDead=new MyImage(hauteur, largeur, rouge, vert, bleu);
                            nomDeLImageChargee = "NouvelleImage.bmp";
                            Console.WriteLine("Nouvelle Image a été créée.");
                            Console.WriteLine("Avec les parametre " + largeur + " " + hauteur + " " + rouge + " " + vert + " " + bleu);
                            Console.WriteLine("L'image "+ nomDeLImageChargee+" à été chargé avec succès");
                            break;
                        case 2:
                             Console.WriteLine("L'image "+ nomDeLImageChargee+ " à été mise en noir et blanc" );
                            maSuperImageOfTheDead.SansNuanceNoirEtBlanc();
                            break;
                        case 3:
                            Console.WriteLine("L'image " + nomDeLImageChargee + " à été mise en nuance de gris");
                            maSuperImageOfTheDead.NuanceNoirEtBlanc();
                            break;
                        case 4:
                            Console.WriteLine("L'image " + nomDeLImageChargee + " à subit une rotation de 90°");
                            maSuperImageOfTheDead.rotation90();
                            break;
                        case 5:
                            Console.WriteLine("L'image " + nomDeLImageChargee + " à subit une rotation de 180°");
                            maSuperImageOfTheDead.rotation180();
                            break;
                        case 6:
                            Console.WriteLine("L'image " + nomDeLImageChargee + " à subit une rotation de 270°");
                            maSuperImageOfTheDead.rotation270();
                            
                            break;
                        case 7:
                            Console.WriteLine("Veuillez entrer un coefficient d'agrandissement");
                            double agrandissement = DemanderDouble(1, 100);
                            maSuperImageOfTheDead.Redimmensionner(agrandissement, agrandissement);
                            Console.WriteLine(nomDeLImageChargee + " a été agrandie");

                            break;
                        case 8:
                            Console.WriteLine("Veuillez entrer un coefficient de retrecissement");
                            double retrecissement = DemanderDouble(0.01, 1);
                            maSuperImageOfTheDead.Redimmensionner(retrecissement, retrecissement);
                            Console.WriteLine(nomDeLImageChargee + " a été rétrécie");
                            break;
                        case 9:
                            Console.WriteLine("Veuillez entrer le nom de la seconde image qui sera superposée à l'image " + nomDeLImageChargee);
                            string nomImageSuperposition = Console.ReadLine();
                            if (nomImageSuperposition[nomImageSuperposition.Length - 1] != 'p')
                            {
                                nomImageSuperposition += ".bmp";                            
                            }
                            MyImage SecondeImage;
                            if (File.Exists(nomImageSuperposition))
                            {
                                Console.WriteLine("L'image " + nomImageSuperposition + " est prête à être superposée");
                                 SecondeImage = new MyImage(nomImageSuperposition);
                                maSuperImageOfTheDead.Superposition(SecondeImage);
                                Console.WriteLine("L'image "+nomImageSuperposition+" a été superposée à l'image " + nomDeLImageChargee);
                            }
                            else
                            {
                                Console.WriteLine("Echec de la superposition: le fichier spécifié n'a pas été trouvé");
                            }                          
                            break;
                        case 10:
                            Console.WriteLine("La matrice de convolution da la détection des bords à été appliquée à l'image " + nomDeLImageChargee);
                            maSuperImageOfTheDead.DetectionDesBords();
                            break;
                        case 11:
                            Console.WriteLine("La matrice de convolution du renforcement des bords à été appliquée à l'image " + nomDeLImageChargee);
                            maSuperImageOfTheDead.RenforcementDesBord();
                            break;
                        case 12:
                            Console.WriteLine("La matrice de convolution du flou à été appliquée à l'image " + nomDeLImageChargee);
                            maSuperImageOfTheDead.Flou();
                            break;
                        case 13:
                            Console.WriteLine("La matrice de convolution du repoussage à été appliquée à l'image " + nomDeLImageChargee);
                            maSuperImageOfTheDead.Repoussage();
                            break;
                        case 14: 
                                                                                 
                            Console.WriteLine("Veuillez entrer le nombre de cotés du polygone. Entrez un nombre élevé pour tracer un cercle");
                            Console.WriteLine("Nombre de cotés : ");
                            int nombreDeCotes = DemanderInt(3, 250);
                            Console.WriteLine("Veuillez entrer le rayon, et les position du centre du cercle dans lequelle polygone sera inscrit");
                            Console.WriteLine("Rayon : ");
                            int rayon = DemanderInt(2, maSuperImageOfTheDead.petiteDimension/2-2);
                            Console.WriteLine("Abscisse du centre : ");
                            int centreX = DemanderInt(rayon, maSuperImageOfTheDead.petiteDimension - rayon);
                            Console.WriteLine("Ordonnée du centre : ");
                            int centreY = DemanderInt(rayon, maSuperImageOfTheDead.petiteDimension - rayon);
                            Console.WriteLine("Veuillez entrer l'épaisseur et la couleur (code RGB) du contour du polygone");
                            Console.WriteLine("Epaisseur : ");
                            epaisseur = DemanderInt(1, 10);
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(0, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(0, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(0, 255);
                            maSuperImageOfTheDead.polygone(centreX,centreY,rayon,nombreDeCotes,epaisseur,(byte)rouge, (byte)vert, (byte)bleu);
                            Console.WriteLine("Le polygone à été tracé avec succès sur l'image " + nomDeLImageChargee);
                            break;
                        case 15:
                            Console.WriteLine("Veuillez entrer un coefficient de redimmensionnement en hauteur et en largeur");
                            Console.WriteLine("Coefficient en hauteur : ");
                            double coefHauteur = DemanderDouble(0.01, 100);
                            Console.WriteLine("Coefficient en largeur : ");
                            double coefLargeur = DemanderDouble(0.01, 100);
                            maSuperImageOfTheDead.Redimmensionner(coefHauteur, coefLargeur);
                            Console.WriteLine( nomDeLImageChargee+ " a été redimmensionnée");
                            break; 
                        case 16:
                            Console.WriteLine("Indiquez la taille du flocon: ");
                            Console.WriteLine("2 est la plus petite taille et " + MyImage.min(80, maSuperImageOfTheDead.petiteDimension / 60) + " représente un flocon s'étendant sur toute l'image. ");
                            int tailleFractale = DemanderInt(2,MyImage.min(80, maSuperImageOfTheDead.petiteDimension/60));
                            Console.WriteLine("Indiquez le nombre d'itérations : ");
                            int nombreAppel = DemanderInt(1,(5- maSuperImageOfTheDead.petiteDimension/2000));
                            int chargement = (int)(3 * Math.Pow(4, nombreAppel));
                            Console.WriteLine("Veuillez entrer l'épaisseur et la couleur (code RGB) du contour ");
                            Console.WriteLine("Epaisseur : ");
                            epaisseur = DemanderInt(1, 10);
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(0, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(0, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(0, 255);
                            maSuperImageOfTheDead.fractaleFlocon(tailleFractale * 32, tailleFractale * 2, tailleFractale * 52, tailleFractale * 37, nombreAppel, epaisseur, (byte)rouge, (byte)vert, (byte)bleu, chargement); // gauche/haut
                            maSuperImageOfTheDead.fractaleFlocon(tailleFractale * 52, tailleFractale * 37, tailleFractale * 12, tailleFractale * 37, nombreAppel, epaisseur, (byte)rouge, (byte)vert, (byte)bleu, chargement); //haut/ bas
                            maSuperImageOfTheDead.fractaleFlocon(tailleFractale * 12, tailleFractale * 37, tailleFractale * 32, tailleFractale * 2, nombreAppel, epaisseur, (byte)rouge, (byte)vert, (byte)bleu, chargement); //bas gauche*/
                            Console.WriteLine("Une fractale de Flocon a été tracée sur " + nomDeLImageChargee);
                            break;
                        case 17:
                            Console.WriteLine("Veuillez indiquer le diametre en pixel du motif élémentaire le plus grand ");
                            Console.WriteLine("Taille de la fractal: Il semble que "+ (maSuperImageOfTheDead.petiteDimension / 2)+" serait une bonne valeur");
                            double zoom = DemanderDouble(3,maSuperImageOfTheDead.petiteDimension*10);//2;petitedimension/2   1200-600
                            double x1 = -1*maSuperImageOfTheDead.petiteDimension/(zoom*2);
                            double x2 = 1* maSuperImageOfTheDead.petiteDimension / (zoom*2);
                            double y1 = -1 * maSuperImageOfTheDead.petiteDimension / (zoom * 2);
                            double y2 = 1* maSuperImageOfTheDead.petiteDimension / (zoom * 2);
                            Console.WriteLine("Indiquez le nombre d'itérations :");
                            int iteration=DemanderInt(19,700);
                            Console.WriteLine("Veuillez entrer la graine de la couleur (code RGB) de la fractale. ");
                            Console.WriteLine("Nous obtenons un jolie resultat avec par exemple: 80 120 45");
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(1, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(1, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(1, 255);
                            Console.WriteLine("Veuillez entrer la graine de la couleur (code RGB) de la fractale. ");
                            double c_r = 0.285;
                            double c_i = 0.01;
                            //Valeurs sympas :
                            //c =-1.417022285618 ;
                            //c = -1.417022285618+0.0099534i (avec unn zoom 9 fois superieur à la valeur conseiller
                            //c= 0,285+0,01i
                            maSuperImageOfTheDead.fractalJulia(x1, x2, y1, y2, zoom, iteration,(byte)rouge, (byte)vert, (byte)bleu,c_r,c_i);

                            //Les quatre premiers paramètres que l'on définit sont les coordonnés de la zone que l'on veut tracer.Voici à quoi ils correspondent:
                            // x1 correspond à la limite gauche de l'image
                            // x2 correspond à la limite droite de l'image
                            //y1 correspond à la limite du haut de l'image
                            //y2 correspond à la limite du bas de l'image
                            //Par exemple, si on augmente x1, l'image sera plus petite vers la droite. En diminuant x2, l'image sera petite vers la gauche. Et de même pour y1 et y2.
                            //les ensembles de julia sont centrés sur l’origine du repère, la forme changera donc en fonction de coordonnés de x1, x2, y1 et y2 
                            Console.WriteLine("Une fractale de Julia a été tracée sur " + nomDeLImageChargee);
                            // l'integralité des parametre ne sont pas demander al'utilisation juste pour que ça soit plus pratique.
                            break;
                        case 18:
                            Console.WriteLine("Veuillez indiquer la taille de la fractal( 1 à 10 )");
                            Console.WriteLine("Taille de la fractal:");
                            double Zoom = DemanderDouble(1, 10)/10;
                            double startX = 0.75 ; //repere de Mandelbrot
                            double startY=0;
                            Console.WriteLine("Indiquez le nombre d'itérations :");
                            int Iteration = DemanderInt(5, 250);
                            maSuperImageOfTheDead.fractalMandelbrot(Zoom, startX, -startY, Iteration);
                            Console.WriteLine("Une fractale de Mandelbrot a été tracée sur " + nomDeLImageChargee);
                            break;
                        case 22:
                            Console.WriteLine("Veuillez entrer le nom du fichier de sortie : ");
                            imageDeSortie = Console.ReadLine();
                            if (imageDeSortie[imageDeSortie.Length - 1] != 'p')
                            {
                                imageDeSortie += ".bmp";
                            }
                            maSuperImageOfTheDead.From_Image_To_File(imageDeSortie);
                            Console.WriteLine("L'image " + nomDeLImageChargee + " a été enregistrer sous " + imageDeSortie);
                            Process.Start(imageDeSortie);
                            Console.WriteLine(imageDeSortie + " a  été afficher");
                            break;
                        case 19:
                            Console.WriteLine("Veuillez entrer les coordonnées des pixels");
                            Console.WriteLine("A: (x,y) : ");
                            Console.WriteLine("x = ");
                            int xs1=DemanderInt(0,maSuperImageOfTheDead.LaLargeur);
                            Console.WriteLine("y = ");
                            int ys1 = DemanderInt(0, maSuperImageOfTheDead.LaHauteur);
                            Console.WriteLine("B: (x,y) : ");
                            Console.WriteLine("x = ");
                            int xs2 = DemanderInt(0, maSuperImageOfTheDead.LaLargeur);
                            Console.WriteLine("y = ");
                            int ys2 = DemanderInt(0, maSuperImageOfTheDead.LaHauteur);
                            Console.WriteLine("Veuillez entrer l'épaisseur et la couleur (code RGB) du contour ");
                            Console.WriteLine("Epaisseur : ");
                            epaisseur = DemanderInt(1, 10);
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(0, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(0, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(0, 255);
                            maSuperImageOfTheDead.TracerUnSegment(ys1, xs1, ys2, xs2, epaisseur, (byte)rouge, (byte)vert, (byte)bleu, 0);
                            Console.WriteLine("Un segment a été tracé sur " + nomDeLImageChargee);
                            break;
                        case 20:
                            Console.WriteLine(nomDeLImageChargee+" a été remplacer par son Histogramme");
                            maSuperImageOfTheDead.Histogramme(); 
                            break;
                        case 21:
                            Console.WriteLine("Veuillez entrer le pointes de cotés de l'etoile.");
                            Console.WriteLine("Nombre de pointes : ");
                            int nombreDePointes = DemanderInt(3, 80);
                            Console.WriteLine("Veuillez entrer le rayon extérieur, et les position du centre du cercle dans lequelle l'étoile sera inscrite");
                            Console.WriteLine("Rayon : ");
                            int rayonext = DemanderInt(2, maSuperImageOfTheDead.petiteDimension / 2 - 2);
                            
                            Console.WriteLine("Abscisse du centre : ");
                            int centrex = DemanderInt(rayonext, maSuperImageOfTheDead.petiteDimension - rayonext);
                            Console.WriteLine("Ordonnée du centre : ");
                            int centrey = DemanderInt(rayonext, maSuperImageOfTheDead.petiteDimension - rayonext);
                            Console.WriteLine("Veuillez entrer le rayon intérieur de l'étoile");
                            Console.WriteLine("Rayon intérieur: ");
                            int rayonint = DemanderInt(2, maSuperImageOfTheDead.petiteDimension / 2 - 2);
                            Console.WriteLine("Veuillez entrer l'épaisseur et la couleur (code RGB) du contour de l'étoile");
                            Console.WriteLine("Epaisseur : ");
                            epaisseur = DemanderInt(1, 10);
                            Console.WriteLine("Rouge : ");
                            rouge = DemanderInt(0, 255);
                            Console.WriteLine("Vert : ");
                            vert = DemanderInt(0, 255);
                            Console.WriteLine("Bleu : ");
                            bleu = DemanderInt(0, 255);
                            maSuperImageOfTheDead.Etoile(centrex, centrey, rayonext, nombreDePointes, epaisseur, (byte)rouge, (byte)vert, (byte)bleu, rayonint);
                            Console.WriteLine("L'étoile à été tracé avec succès sur l'image " + nomDeLImageChargee);
                            break;
                        case 23:
                            maSuperImageOfTheDead.From_Image_To_File(imageDeSortie);
                            Console.WriteLine("L'image " + nomDeLImageChargee + " a été enregistrer sous " + imageDeSortie);
                            Process.Start(imageDeSortie);
                            Console.WriteLine(imageDeSortie + " a  été afficher");
                            break;
                        case 24:
                            resterDansLeMenu = false;
                            Console.WriteLine("A bientôt!");                          
                            break;
                        default:
                            Console.WriteLine("L'exercice n'est pas fait.");
                            break;
                    }
                    Console.ReadKey();
                    MyImage.compteur = 0;
                    Console.Clear();
                }
                for (int i = 0; i < ListeExo.GetLength(0); i++)
                {
                    if (i == positionMenu)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(ListeExo[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        static int DemanderInt(int min, int max)
        {
            int a;
            string entre = "a";
            while (int.TryParse(entre, out a) == false)
            {
                if (entre != "a")
                {
                    Console.WriteLine("veuillez saisir un nombre entier");
                }
                entre = Console.ReadLine();              
            }
            a = int.Parse(entre);
            if(a<min || a > max)
            {
                Console.WriteLine("Pour des raisons de temps de calculs ou de formats, veuillez saisir un entier compris entre " + min+ " et " + max);
                a=DemanderInt( min,  max);
            }
            return a;
        }
        static double DemanderDouble(double min, double max)
        {
            double a;
            string entre = "a";
            while (double.TryParse(entre, out a) == false)
            {
                if (entre != "a")
                {
                    Console.WriteLine("veuillez saisir un nombre");
                }
                entre = Console.ReadLine();
            }
            a = double.Parse(entre);
            if (a < min || a > max)
            {
                Console.WriteLine("Pour des raisons de temps de calculs ou de formats, veuillez saisir un entier compris entre " + min + " et " + max);
                a = DemanderDouble(min, max);
            }
            return a;
        }
    }
}

