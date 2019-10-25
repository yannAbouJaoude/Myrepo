using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Exo1();
            //  Exo2();
            //  Exo3();
            //  Exo4();
            //  Exo5();
            //  Exo6(); 
            //  Exo7();
            //  Exo8();
            //  Exo9();
            //  Exo10();
            //  Exo11();
            //  Exo12();
            //  Exo13();
            //  Exo14();
            //  Exo14bis();
            //  Exo15();
             // Exo16();
            //  Exo17();
            //  Exo18();
              Puissance4();
            Console.ReadKey();
        }

        static void Exo1()
        {
            Console.WriteLine("Bonjour le monde");
        }

        static void Exo2()
        {
            Console.WriteLine("C'est quoi ton petit prénom ?");
            string prenom = Console.ReadLine();
            Console.WriteLine("Bonjour " + prenom + Environment.NewLine + "comment vas tu?");
        }

        static void Exo3()
        {
            int cp = 92;
            string nom = "Hauts-de-Seine";
            string phrase = "Le code postal des " + nom + " est le " + cp;
            Console.WriteLine(phrase);
        }

        static void Exo4()
        {
            Console.WriteLine("Quelle est la longueur du premier cote ?");
            double cote1;
            cote1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Quelle est la longueur du second cote ?");
            double cote2;
            cote2 = Double.Parse(Console.ReadLine());
            double surface = cote1 * cote2;
            Console.WriteLine("La surface du rectangle est " + surface);
        }

        static void Exo5()
        {
            string syllabe = Console.ReadLine();
            syllabe = syllabe + syllabe;
            Console.WriteLine(syllabe);
        }

        static void Exo6()
        {
            string var1 = Console.ReadLine();
            string var2 = Console.ReadLine();
            Console.WriteLine("var1 = " + var1 + "  var2 = " + var2);
            string var3 = var1;
            var1 = var2;
            var2 = var3;
            Console.WriteLine("var1 = " + var1 + "  var2 = " + var2);
        }

        static void Exo7()
        {
            int nb1 = int.Parse(Console.ReadLine());
            int nb2 = int.Parse(Console.ReadLine());
            Console.WriteLine("La moyenne est " + ((double)nb1 + (double)nb2) / 2);
        }

        static void Exo8()
        {
            double temperature = double.Parse(Console.ReadLine());
            temperature = temperature * 1.8 + 32;
            Console.WriteLine("temperature = " + temperature + " Farenheit");
        }

        static void Exo9()
        {
            int n = 0;
            while (n != 20)
            {
                Console.WriteLine("ça tourne");
                n++;
            };
            for (int i = 0; i != 20; i++) { Console.WriteLine("ça tourne"); };

        }

        static void Exo10()
        {
            int n = 0;
            while (n < 100)
            {
                n = n + int.Parse(Console.ReadLine());
            }
            Console.WriteLine("la somme des n est " + n);
        }

        static void Exo11()
        {
            int n = 1;
            while (n != 0)
            {
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("n² = " + n * n);
            }
        }
        static void Exo12()
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < n)
            {
                i++;
                Console.WriteLine(i);
            }
            while (i > 0)
            {
                Console.WriteLine(i);
                i--;
            }
        }

        static void Exo13()
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo14()
        {
            int n = -1;
            while (n <= 0) { n = int.Parse(Console.ReadLine()); }
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo14bis()
        {
            int n = -1;

            do { n = int.Parse(Console.ReadLine()); } while (n <= 0);
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo15()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            a = a + b;
            int r = int.Parse(Console.ReadLine());
            if (r != a)
            {
                Console.WriteLine("retourne en primaire gros kk"); ;
            }
            else
            {
                Console.WriteLine("bravo");
            }
        }

        static void Exo16()
        {
            int mois = 0;
            while (mois <= 1 || mois >= 12) { mois = int.Parse(Console.ReadLine()); }
            if (mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12)
            {
                Console.WriteLine(" ce mois à 31 jours");
            }
            else if (mois == 2) { Console.WriteLine(" ce mois à 28 jours"); }
            else { Console.WriteLine(" ce mois à 30 jours"); }
        }

        static void Exo17()
        {
            string fin = "0";
            int somme = 0;
            int n = -1;
            while (fin != "fin")
            {
                somme = somme + int.Parse(fin);
                fin = Console.ReadLine();
                n++;

            }
            Console.WriteLine("vous avez rentré " + n + " termes");
            Console.WriteLine("La somme des termes entré est " + somme);
            Console.WriteLine("La moyenne est " + (double)somme / n);
        }

        static void Exo18()
        {
            int version = 0;
            while (version != 1 && version != 2)
            {
                Console.WriteLine("choisir une version (1 ou 2)");
                Console.WriteLine("La version 1 te donne un nombre d'essai infini");
                Console.WriteLine("La version 2 te donne 10 essais maximums");
                version = int.Parse(Console.ReadLine());
            }
            if (version == 2) { Console.WriteLine("Attention! Tu as 10 essais au maximum!"); }

            Random rnd = new Random(); // c'est trop nul de le mettre en dure
            int a = rnd.Next(0, 100);
            int r = -1;
            int essai = 0;
            while (a != r)
            {
                if (version == 1 || essai != 10)
                {
                    Console.WriteLine("Entre un entier");

                    r = int.Parse(Console.ReadLine());
                    if (a < r) { Console.WriteLine("c'est moins!"); }
                    if (a > r) { Console.WriteLine("c'est plus!"); }
                }
                if (essai == 10 && version == 2) { Console.WriteLine("Tu as perdu..."); a = r; }
                essai++;
            }

            if (version == 2 && essai != 10) { Console.WriteLine("Bravo! tu as gagné! Il t'a fallu " + essai + " coups"); }
            if (version == 1) { Console.WriteLine("Bravo! tu as gagné! Il t'a fallu " + essai + " coups"); }
        }

        //ecrire un programme qui permet à deux joueurs de jouer à la puissance 4
        //tant que partie non finie (4 jetons consécutifs alignés horizontal, vertical, diag) rejouer
        //6, 7






        static void Puissance4()
        {
            int[,] plateau = new int[6, 7];
            int tourJoueur = 1;
            int fin = -1;
            int choix;
            int plein = 0;
            int vx1;
            int vx2;
            int vx3;
            int vx4;

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    plateau[x, y] = 0;
                }
            }
            while (fin != 0)
            {
                choix = -1;
                while (choix > 6 || choix < 0)
                {
                    choix = int.Parse(Console.ReadLine());
                    if (choix <= 6 && choix >= 0)
                    {
                        plein = 5;
                        while (plateau[plein, choix] != 0 && plein != 0) { plein = plein - 1; }
                        if (plein == 0 && plateau[plein, choix] != 0) { choix = -1; }
                    }
                }
                plateau[plein, choix] = tourJoueur;

                //affiche le tableau
                for (int x = 0; x < 6; x++)
                {
                    for (int y = 0; y < 7; y++)
                    {Console.Write(plateau[x, y]);}
                    Console.WriteLine();
                }

                //alterne les joueurs
                if (tourJoueur == 1) { tourJoueur = 2; }
                else { tourJoueur = 1; }


                //vérifie la victoire
                
                for (int vx=0; vx < 6
                    ; vx++)
                {
                   // Horizontalement
                    if (plateau[vx, 0] == 1 && plateau[vx,1] == 1&& plateau[vx,2] == 1 && plateau[vx,3] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 1 && plateau[vx, 1] == 1 && plateau[vx, 2] == 1 && plateau[vx, 3] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 1 && plateau[vx, 5] == 1 && plateau[vx, 2] == 1 && plateau[vx, 3] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 1 && plateau[vx, 5] == 1 && plateau[vx, 6] == 1 && plateau[vx, 3] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 0] == 2 && plateau[vx, 1] == 2 && plateau[vx, 2] == 2 && plateau[vx, 3] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 2 && plateau[vx, 1] == 2 && plateau[vx, 2] == 2 && plateau[vx, 3] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 2 && plateau[vx, 5] == 2 && plateau[vx, 2] == 2 && plateau[vx, 3] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                    if (plateau[vx, 4] == 2 && plateau[vx, 5] == 2 && plateau[vx, 6] == 2 && plateau[vx, 3] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                }

                //verticalement

                for (int vy = 0; vy < 7; vy++)
                {
                    if (plateau[0, vy] == 1 && plateau[1,vy] == 1 && plateau[2,vy] == 1 && plateau[3, vy] == 1) {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[4, vy] == 1 && plateau[1, vy] == 1 && plateau[2, vy] == 1 && plateau[3, vy] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[4, vy] == 1 && plateau[5, vy] == 1 && plateau[2, vy] == 1 && plateau[3, vy] == 1)
                    {
                        Console.WriteLine("joueur 1 a gagné");
                        fin = 0;
                    }
                    if (plateau[0, vy] == 2 && plateau[1, vy] == 2 && plateau[2, vy] == 2 && plateau[3, vy] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                    if (plateau[4, vy] == 2 && plateau[1, vy] == 2 && plateau[2, vy] == 2 && plateau[3, vy] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                    if (plateau[4, vy] == 2 && plateau[5, vy] == 2 && plateau[2, vy] == 2 && plateau[3, vy] == 2)
                    {
                        Console.WriteLine("joueur 2 a gagné");
                        fin = 0;
                    }
                }
                // Diagonalement haut droite
                for(int v1=0; v1<3; v1++)
                {
                    vx1 = 0 + v1;
                    vx2 = 1 + v1;
                    vx3 = 2 + v1;
                    vx4 = 3 + v1;
                    for (int k = 1; k < 3; k++)
                    {
                        if (plateau[vx1, 0] == k && plateau[vx2, 1] == k && plateau[vx3, 2] == k && plateau[vx4, 3] == k)
                        {
                            Console.WriteLine("joueur " +k+ " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 1] == k && plateau[vx2, 2] == k && plateau[vx3, 3] == k && plateau[vx4, 4] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 2] == k && plateau[vx2, 3] == k && plateau[vx3, 5] == k && plateau[vx4, 6] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 3] == k && plateau[vx2, 4] == k && plateau[vx3, 5] == k && plateau[vx4, 6] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 6] == k && plateau[vx2, 5] == k && plateau[vx3, 4] == k && plateau[vx4, 3] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 5] == k && plateau[vx2, 4] == k && plateau[vx3, 3] == k && plateau[vx4, 2] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 4] == k && plateau[vx2, 3] == k && plateau[vx3, 2] == k && plateau[vx4, 1] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }
                        if (plateau[vx1, 3] == k && plateau[vx2, 2] == k && plateau[vx3, 1] == k && plateau[vx4, 0] == k)
                        {
                            Console.WriteLine("joueur " + k + " a gagné");
                            fin = 0;
                        }

                    }



                }

            }
        }
    }
}
