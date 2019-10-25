using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        static int compteur = 0;
        static void Main(string[] args)
        {
            bool a = resolution(0);
            afficher();
            Console.WriteLine(compteur);
            Console.ReadKey();
        }
        static bool resolution(int pos)
        {
            compteur++;
            int i = pos / 9;
            int j = pos % 9;
            if (i == 9)
                return true;
            if (tab[i, j] != 0)
                return resolution(pos + 1);
            for (int k = 1; k <= 9; k++)
            {
                if (chiffreokay(k, i, j) == 1)
                {
                    tab[i, j] = k;
                    if (resolution(pos + 1))
                        return true;
                }
            }
            tab[i, j] = 0;
            return false;
        }

        static int[,] tab = new int[9, 9] {
                      {2,0,0,0,9,0,3,0,0},
                      {0,1,9,0,8,0,0,7,4},
                      {0,0,8,4,0,0,6,2,0},
                      {5,9,0,6,2,1,0,0,0},
                      {0,2,7,0,0,0,1,6,0},
                      {0,0,0,5,7,4,0,9,3},
                      {0,8,5,0,0,9,7,0,0},
                      {9,3,0,0,5,0,8,4,0},
                      {0,0,2,0,6,0,0,0,1}};
        static void afficher()
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
        static int chiffreokay(int k, int i, int j)
        {
            for (int colonne = 0; colonne < 9; colonne++)
                if (tab[i, colonne] == k)
                {
                    return 0;
                }
            for (int ligne = 0; ligne < 9; ligne++)
            {
                if (tab[ligne, j] == k)
                {
                    return 0;
                }
            }
            int _i = i - (i % 3), _j = j - (j % 3);
            for (i = _i; i < _i + 3; i++)
            {
                for (j = _j; j < _j + 3; j++)
                {
                    if (tab[i, j] == k)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
         
                      //{{1,0,0,0,0,7,0,9,0},
                      //{0,3,0,0,2,0,0,0,1},
                      //{0,0,9,6,0,0,5,0,0},
                      //{0,0,5,3,0,0,9,0,0},
                      //{0,1,0,0,8,0,0,0,2},
                      //{6,0,0,0,0,4,0,0,0},
                      //{3,0,0,0,0,0,0,1,0},
                      //{0,4,0,0,0,0,0,0,7},
                      //{0,0,7,0,0,0,3,0,0}};
    }

}
    

