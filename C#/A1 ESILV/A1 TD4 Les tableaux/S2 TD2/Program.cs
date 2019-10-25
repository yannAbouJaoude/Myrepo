using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_TD2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exo1();
            // Exo2();
            // Exo3();
            // Exo4();
            // Exo5();
            // Exo6();
            Console.ReadKey();
        }

        static void afficher(int[] tab)
        {
            if (tab != null)
            {
                if (tab.Length > 0)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        Console.Write(tab[i] + " ; ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Le tableau est vide!");
                }
            }
        }
        static void Exo1()
        {
            int[] tab = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            afficher(tab);
        }
        static int[] Fusionner(int[] tab1,int[]tab2)
        {
            int a;
            int b;
            if (tab1 == null)
            {
                a = 0;
            }
            else { a = tab1.Length; }
            if (tab2 == null)
            {
                b = 0; ;
            }
            else { b = tab2.Length; }
            int[] tab3 = new int[a+b];
            tab1.CopyTo(tab3, 0);
            tab2.CopyTo(tab3, tab1.Length);
            return tab3;
        }
        static void Exo2()
        {
            int[] tab1 = { 1, 23, 45, 6 };
            int[] tab2 = { 7, 89, 17 };
            int[] tab3 = Fusionner(tab1, tab2);
            afficher(tab3);
        }
        static void Exo3()
        {
            int[] tab = { 1, 23, 45, 6, 7, 89 };
            int[] tab2 = NouveauTableauInverse(tab);
            afficher(tab2);
        }
        static int[] NouveauTableauInverse(int[]tab)
        {
            int[] tab2 = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                tab2[tab.Length - i-1] = tab[i];
            }
            return tab2;
        }
        static void Exo4()
        {
            int[] tab = { 1, 23, 45, 6, 7, 89 };
            afficher(tab);
            InverserTableau(tab);
            afficher(tab);
        }
        static void InverserTableau(int[] tab)
        {
            int a;
            for(int i= 0; i < tab.Length/2; i++)
            {
                a = tab[i];
                tab[i] = tab[tab.Length - i - 1];
                tab[tab.Length - i - 1] = a;

            }
        }
        static void Exo5()
        {
            int[,] matrice = { { 1, 2, 3, 4, 5 }, { 1, 3, 5, 7, 9 } };
            AfficherMatrice(matrice);
        }
        static void AfficherMatrice(int[,]tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }

        static void Exo6()
        {
            int nbLignes = 5; // valeur pouvant être demand ée à l’ utilisateur
            int nbColonnes = 3; // idem
            int[,] matrice2D = CreerMatrice(nbLignes, nbColonnes);
            AfficherMatrice(matrice2D);
        }

        static int[,] CreerMatrice(int nombreLignes, int nombreColonnes)
        {
            int[,] MaMatrice = new int[nombreLignes, nombreColonnes];
            int a = 0;
            for (int i = 0; i < MaMatrice.GetLength(0); i++)
            {
                for (int j = 0; j < MaMatrice.GetLength(1); j++)
                {
                    a = a + 1;
                    MaMatrice[i, j] = a;
                }
                
            }



            return MaMatrice;
        }


    }
}
