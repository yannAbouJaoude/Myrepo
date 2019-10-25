using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2TD3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exo10();
            tableMultiplication(10,10);
            tableMultiplication(5, 5);
            tableMultiplication(7, 7);
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
        static int[]GenererTableauAleatoire(int taille, int valeurMin,int valeurMax)
        {
            int[] resultat = new int[taille];
            Random alea = new Random();
            for(int i = 0; i<resultat.Length; i++)
            {
                resultat[i] = alea.Next(valeurMin, valeurMax + 1);
            }
            return resultat;
        }
        static int recherche(int[]tableau, int valeur)
        {
            int a = -1;
            for (int i = 0; i<tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    a = i;
                }
            }
            return a;
        }
        static void Exo2()
        {
            Console.WriteLine(recherche(GenererTableauAleatoire(5, 0, 10), 8));
           
        }
        static void Exo3()
        {
            int[] tab = GenererTableauAleatoire(5, 0, 10);
            afficher(tab);
            Console.WriteLine(recherche(tab, tab.Max()));
        }
        static void AfficherMatrice(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0) + 1; i++)
            {
                if (i == 0)
                {
                    Console.Write("    X   ");
                }
                else
                {
                    Console.Write(" "+ i + "\t");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < tab.GetLength(0)+1; i++)
            {
                if (i == 0)
                {
                    Console.Write("        ");
                }
                else
                {
                    Console.Write("--------");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write("    " + (i+1) +"\t" +"|");
                    }
                    Console.Write("  " + tab[i, j] + "\t" + "|");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < tab.GetLength(0)+1; i++)
            {
                if (i == 0)
                {
                    Console.Write("        ");
                }
                else
                {
                    Console.Write("--------");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static int[,] CreerMatriceAlea(int nombreLignes, int nombreColonnes, int valeurMin, int valeurMax)
        {
            int[,] MaMatrice = new int[nombreLignes, nombreColonnes];
            Random alea = new Random();
            for (int i = 0; i < MaMatrice.GetLength(0); i++)
            {
                for (int j = 0; j < MaMatrice.GetLength(1); j++)
                {
                    MaMatrice[i,j] = alea.Next(valeurMin, valeurMax + 1);
                }

            }
            return MaMatrice;
        }
        static void Exo10()
        {
            int[,] matrice1 = CreerMatriceAlea(9, 4, 0, 100);
            int[,] matrice2 = CreerMatriceAlea(6, 7, 0, 100);
            int[,] MaMatrice = additionMatrice(matrice1, matrice2);
            AfficherMatrice(matrice1);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            AfficherMatrice(matrice2);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            AfficherMatrice(MaMatrice);

        }
        static int[,] additionMatrice(int[,] matrice1, int [,] matrice2)
        {
            int[,] matrice3 = new int[Math.Max(matrice1.GetLength(0), matrice2.GetLength(0)), Math.Max(matrice1.GetLength(1), matrice2.GetLength(1))];
            for (int i = 0; i < Math.Max(matrice1.GetLength(0), matrice2.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Max(matrice1.GetLength(1), matrice2.GetLength(1)); j++)
                {
                    matrice3[i, j] = 0;
                }
            }

            for (int i = 0; i < Math.Min(matrice1.GetLength(0), matrice2.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Min(matrice1.GetLength(1), matrice2.GetLength(1)); j++)
                {
                    matrice3[i, j] = matrice1[i, j] + matrice2[i, j];
                }
            }
            return matrice3;
        }
        static void tableMultiplication(int ligne, int colonne)
        {
            int[,] matrice = new int[ligne, colonne];
            for (int i = 0; i < Math.Max(matrice.GetLength(0), matrice.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Max(matrice.GetLength(1), matrice.GetLength(1)); j++)
                {
                    matrice[i, j] = (i+1)*(j+1);
                }
            }
            AfficherMatrice(matrice);
        }
    }
}
