using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nvausudoku
{
    class Program
    {

        static void Main(string[] args)
        {
            Sudoku K;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("---------------Resolutions possibles:-----------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          1)  Solution Naïve.");
            Console.WriteLine();
            Console.WriteLine("          2)  Solution Récursive.");
            int choix =Convert.ToInt32(Console.ReadLine());

            while (choix != 1 && choix != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saisir 1 OU 2");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("          1)  Solution Naïve.");
                Console.WriteLine("          2)  Solution Récursive.");
                choix = Convert.ToInt32(Console.ReadLine());
            }
            Console.ReadKey();
            Console.Clear();









            if (choix == 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("--------------------Solution Naïve------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   1) Avec une grille sudoku sur visual studio ");
                Console.WriteLine();
                Console.WriteLine("   2) Avec une grille sudoku sur Excel ");
                int souschoix = Convert.ToInt32(Console.ReadLine());
                while (souschoix != 1 && souschoix != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saisir 1 OU 2");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("   1) Avec une grille sudoku sur visual studio ");
                    Console.WriteLine();
                    Console.WriteLine("   2) Avec une grille sudoku sur Excel ");
                    souschoix = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadKey();
                Console.Clear();



                if (souschoix == 1)
                {
                    int[,] grille =
 {    {9,0,0,1,0,0,0,0,5},
        {0,0,5,0,9,0,2,0,1},
        {8,0,0,0,4,0,0,0,0},
        {0,0,0,0,8,0,0,0,0},
        {0,0,0,7,0,0,0,0,0},
        {0,0,0,0,2,6,0,0,9},
        {2,0,0,3,0,0,0,0,6},
        {0,0,0,2,0,0,9,0,0},
        {0,0,1,9,0,4,5,7,0}
  };
                    K = new Sudoku(grille);
                    K.Affichage();
                    K.Jeu();
                    K.Affichage();
                    Console.ReadKey();

                }



                if (souschoix == 2)
                {
                    K = new Sudoku("sudokufacile.csv");
                    K.Affichage();
                    K.Jeu();
                    K.Affichage();
                    Console.ReadKey();

                }
            }









            if (choix == 2)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------------Solution Récursive------------------");
                Console.WriteLine();


                int[,] grille =
       {
        {9,0,0,1,0,0,0,0,5},
        {0,0,5,0,9,0,2,0,1},
        {8,0,0,0,4,0,0,0,0},
        {0,0,0,0,8,0,0,0,0},
        {0,0,0,7,0,0,0,0,0},
        {0,0,0,0,2,6,0,0,9},
        {2,0,0,3,0,0,0,0,6},
        {0,0,0,2,0,0,9,0,0},
        {0,0,1,9,0,4,5,7,0}
    };

                Affichage1(grille);

                bool Valide = EstValide(grille, 0);
                Affichage1(grille);
                Console.ReadKey();
            }
        }


        public static void Affichage1(int[,] grille)

        {
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                Console.Write(" : ");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grille[i, j]);
                    Console.Write(" ");

                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write(": ");
                    }
                }
                Console.WriteLine();

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine(" -------------------------");
                }

            }
            Console.WriteLine();
        }

        public static bool AbsentSuruneLigne(int k, int[,] grille, int i)
        {
            for (int j = 0; j < 9; j++)
                if (grille[i, j] == k)
                    return false;
            return true;
        }

        public static bool AbsentSuruneColonne(int k, int[,] grille, int j)
        {
            for (int i = 0; i < 9; i++)
                if (grille[i, j] == k)
                    return false;
            return true;
        }

        public static bool AbsentSurunBloc(int k, int[,] grille, int i, int j)
        {
            int _i = i - (i % 3), _j = j - (j % 3);  // ou encore : _i = 3*(i/3), _j = 3*(j/3);
            for (i = _i; i < _i + 3; i++)
                for (j = _j; j < _j + 3; j++)
                    if (grille[i, j] == k)
                        return false;
            return true;
        }

        public static bool EstValide(int[,] grille, int position)
        {
            // contruction du tableau avec position ou le 1er elément= 1 (0,0), le 2ème=2 (0,1)... et le dernier élément=81(9,9)
            if (position == 9 * 9)
                return true;   // si on arrive à la dernière position par récursivité       

            int i = position / 9, j = position % 9;  // A partir de position, on récupère la ligne et la colonne (sachant que position= taille du tableau*i+j)

            if (grille[i, j] != 0)
                return EstValide(grille, position + 1);    // passage à l'élément suivant sur la même ligne

            for (int k = 1; k <= 9; k++)
            {
                if (AbsentSuruneLigne(k, grille, i) && AbsentSuruneColonne(k, grille, j) && AbsentSurunBloc(k, grille, i, j))
                {
                    grille[i, j] = k;

                    if (EstValide(grille, position + 1))
                        return true;
                }
            }
            grille[i, j] = 0;

            return false;
        }











    }
}
