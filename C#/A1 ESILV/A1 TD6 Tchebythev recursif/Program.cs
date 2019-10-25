using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD34
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercice1();
            // Exercice2();
            // Exercice3();
            // Exercice4();
            // Exercice5();
            // Exercice6();C:\Users\Yann Abou Jaoude\Documents\Visual Studio 2015\Projects\TD34\TD34\App.config
            // Exercice7();
            // Exercice8();
            // Exercice9();
            // ExerciceRecursif();
            // ExerciceRecursifFibonacci();
             ExerciceRecursifTchebychev();
            // trouverUnTresor2();
            Console.ReadKey();
        }

        static void Exercice1()
        {   //ce programme affiche la somme des "a" de 1 à jusqu'a celle de "n-1"
            int
            a = 1, b = 0, n = 5;
            while
            (a <= n)
            {
                b += a++;
            }
            Console.WriteLine(a + ", " + b);
        }
        static void Exercice2()
        {
            Console.WriteLine("Entrez i");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez j");
            int j = int.Parse(Console.ReadLine());
            if (i == j) { Console.WriteLine("i=j"); }
            else if (j < i) { Console.WriteLine("i>j"); }
            else
            {
                Console.WriteLine("i<j");
                if (i != (i / 2) * 2) { i++; }
                while (i <= j) { Console.WriteLine(i); i = i + 2; }
            }
        }
        static void Exercice3()
        {
            Console.WriteLine("Entrez i");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez j");
            int j = int.Parse(Console.ReadLine());

            if (i != (i / 2) * 2) { i = 1; }
            else { i = 0; }
            if (j != (j / 2) * 2) { j = 1; }
            else { j = 0; }

            if (i == j) { Console.WriteLine("La case est noir"); }
            else { Console.WriteLine("La case est blanche"); }
        }
        static void Exercice4()
        {
            Console.WriteLine("Entrez la hauteur de la croix");
            int i = int.Parse(Console.ReadLine()) + 1;
            string[,] plateau = new string[i, i];
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                { plateau[x, y] = " "; }
            }

            int j = 1;
            while (j < i)
            {
                plateau[j, j] = "X";
                plateau[j, i - j] = "X";
                j++;
            }
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                { Console.Write(plateau[x, y]); }
                Console.WriteLine();
            }
        }
        static void Exercice5()
        {
            int a = 0;
            int b = 0;
            while (a <= 100)
            {
                Console.WriteLine(a);
                b++;
                a = b * 5 * 7;
            }
        }
        static void Exercice6()
        {
            Console.WriteLine("Nombres divisible par 2");
            int a = 0;
            int b = 0;
            while (a <= 100)
            {
                Console.WriteLine(a);
                b++;
                a = b * 2;
            }
            Console.WriteLine("Nombres divisible par 9");
            a = 0;
            b = 0;
            while (a <= 100)
            {
                Console.WriteLine(a);
                b++;
                a = b * 9;
            }
        }
        static void Exercice7()
        {
            Console.WriteLine("Entrez x");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Entrez y");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Voici x^y");
            Console.WriteLine(Math.Pow(x, y));
        }
        static void Exercice8()
        {
            int a = 1;
            for (int b = int.Parse(Console.ReadLine()); b > 0; b = b - 1)
            {
                a = a * b;
            }
            Console.WriteLine("La factoriel est " + a);
        }
        static void Exercice9()
        {
            int a = 0, b = 1, c = 1;
            Console.WriteLine(a);
            for (int i = 0; i <= 30; i++)
            {
                Console.WriteLine(c);
                c = a + b;
                a = b;
                b = c;
            }
        }
        static void ExerciceRecursif()
        {
            int a = int.Parse(Console.ReadLine());
            a = factorielle(a);

            Console.WriteLine(a);
        }
        static int factorielle(int x)
        {
            if (x == 0) { return 1; }
            else
            {
                return x * factorielle(x - 1);
            }
        }
        static void ExerciceRecursifFibonacci()
        {
            int a = int.Parse(Console.ReadLine());
            a = fibonacci(a);
            Console.WriteLine(a);
        }
        static int fibonacci(int x)
        {
            ;
            if (x <= 1)
            {
                return x;
            }
            else { return fibonacci(x - 1) + fibonacci(x - 2); }
        }
        static void ExerciceRecursifTchebychev()
        {
            Console.WriteLine("entrez le rang ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("entrez le parametre X ");
            int k = int.Parse(Console.ReadLine());
            a = tchebychev(a, k);
            Console.WriteLine(a);
        }
        static int tchebychev(int x, int k)
        {

            if (x == 1)
            {
                return k;
            }
            else if (x == 0)
            {
                return 1;
            }
            else
            {
                return 2 * k * tchebychev(x - 1, k) - tchebychev(x - 2, k);
            }
        }


        //     public static int[,] plateau = new int[12, 12];

        /*    static void trouverUnTresor() {
                int i = 12;


                Random rnd = new Random();
                int xstart = rnd.Next(0, i - 1);
                int ystart = rnd.Next(0, i - 1);
                int xtresor = rnd.Next(0, i - 1);
                int ytresor = rnd.Next(0, i - 1);
                int a = 1;
                for (int x = 0; x < i; x++)
                {
                    for (int y = 0; y < i; y++)
                    { plateau[x, y] = 0; }
                }
                plateau[xtresor, ytresor] = i*2 + 1;
                if (xstart != xtresor || ystart != ytresor)
                {
                    plateau[xstart, ystart] = a;
                }
                else { Console.WriteLine("Tresor sur la position de départ"); }

                for (int x = 0; x < i; x++)
                {
                    for (int y = 0; y < i; y++)
                    { Console.Write(plateau[x, y] ); }
                    Console.WriteLine();
                }
                recherche(xstart, ystart, xtresor,ytresor);





            }
            static int recherche (int x, int y,int xtresor,int ytresor)
            {
                if(xtresor == x && ytresor == y)
                {
                    return 1;
                }

                return 1;

            }*/



       
        static void trouverUnTresor2()
        {
            int i = int.Parse(Console.ReadLine()); 
            int[,] plateau = new int[i, i];
       
        
            Random rnd = new Random();
            int xstart = rnd.Next(0, i - 1);
            int ystart = rnd.Next(0, i - 1);
            int xtresor = rnd.Next(0, i - 1);
            int ytresor = rnd.Next(0, i - 1);
            int a = i * 2 + 2;
            int b;
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                { plateau[x, y] = 0; }
            }
            plateau[xtresor, ytresor] = i * 2 + 1;
            if (xstart != xtresor || ystart != ytresor)
            {
                plateau[xstart, ystart] = a;
            }
            else { Console.WriteLine("Tresor sur la position de départ"); }

            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                {
                    if (plateau[x, y]!= i * 2 + 2 && plateau[x, y]!= i * 2 + 1) { plateau[x, y] = (int)System.Math.Sqrt((xtresor - x) * (xtresor - x)) + (int)System.Math.Sqrt((ytresor - y) * (ytresor - y)); }
                }
            }
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < i; y++)
                { Console.Write(plateau[x, y]+ "    "); }
                Console.WriteLine();
            }
            while (plateau[xstart, ystart] != i * 2 + 1)
            {
          


                if(plateau[xstart+1, ystart]< plateau[xstart-1, ystart]|| plateau[xstart ,ystart+1] < plateau[xstart, ystart - 1])
                {
                    if (plateau[xstart + 1, ystart] < plateau[xstart, ystart + 1])
                    {
                        xstart = xstart + 1;
                    }
                    else { ystart = ystart + 1; }
                }
                else
                {
                    if(plateau[xstart - 1, ystart]< plateau[xstart, ystart - 1]) {
                        xstart = xstart - 1;
                    }
                    else { ystart = ystart - 1; }
                }


                Console.WriteLine("Indiana Jones se déplace en " + xstart + " ; " + ystart);
                if (plateau[xstart, ystart] != i * 2 + 1)
                {
                    plateau[xstart, ystart] = 130;
                }



            }
            Console.Write("a trouvé le trésor en" + xstart + " ; " + ystart);




        }


    }
}
