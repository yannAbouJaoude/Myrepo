using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_datascience_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grille = new int[9, 9] {
                      {2,0,0,0,9,0,3,0,0},
                      {0,1,9,0,8,0,0,7,4},
                      {0,0,8,4,0,0,6,2,0},
                      {5,9,0,6,2,1,0,0,0},
                      {0,2,7,0,0,0,1,6,0},
                      {0,0,0,5,7,4,0,9,3},
                      {0,8,5,0,0,9,7,0,0},
                      {9,3,0,0,5,0,8,4,0},
                      {0,0,2,0,6,0,0,0,1}};
            Console.WriteLine("Voici le sudoku du programme\n");
            afficherUneGrille(grille);
            Console.WriteLine("\nLe sudoku a été résolu de maniere récursive \n");
            resolutionRecursiveNordEnFace(0, grille);
            afficherUneGrille(grille);

            Console.ReadKey();


        }
        static void afficherUneGrille(int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(tab[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }
        static bool resolutionRecursiveNordEnFace(int pos, int[,] tab)
        {
            int i = pos / 9;
            int j = pos % 9;
            if (i == 9)
                return true;
            if (tab[i, j] != 0)
                return resolutionRecursiveNordEnFace(pos + 1, tab);
            for (int k = 1; k <= 9; k++)
            {
                if (chiffreEstOkay(k, i, j, tab) == true)
                {
                    tab[i, j] = k;
                    if (resolutionRecursiveNordEnFace(pos + 1, tab))
                        return true;
                }
            }
            tab[i, j] = 0;
            return false;
        }

        public static bool chiffreEstOkay(int valeurATester, int i, int j, int[,] grille)           //retourne true si il est possible de placer un chiffre valeurATester dansla position [i,j] d'une grille de sudoku donnée , false sinon
        {
            for (int colonne = 0; colonne < 9; colonne++)
                if (grille[i, colonne] == valeurATester)
                {
                    return false;
                }
            for (int ligne = 0; ligne < 9; ligne++)
            {
                if (grille[ligne, j] == valeurATester)
                {
                    return false;
                }
            }
            int _i = i - (i % 3), _j = j - (j % 3);
            for (i = _i; i < _i + 3; i++)
            {
                for (j = _j; j < _j + 3; j++)
                {
                    if (grille[i, j] == valeurATester)
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        //Nouvelle grille
        //grille du base + premiere case pas fixe +1
        // resollution
     


    }
}
