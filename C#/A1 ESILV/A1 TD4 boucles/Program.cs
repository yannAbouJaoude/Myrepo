using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercice3();
            // exercice4();
            // exercice5();
            exercice6();
            Console.ReadKey();
        }

        static void exercice3()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = n; i > 0; i = i - 2)
            {
                for (int j = 0; j < (n - i) / 2; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void exercice4()
        {
            int n = int.Parse(Console.ReadLine());
            double somme = 0;

            for (double i = 0; i < (double)n; i++)
            {
                somme = somme + Math.Pow(2, i);
            }
            Console.WriteLine(somme / n);
        }

        static void exercice5()
        {
            string a = Console.ReadLine();
            string b = "";
            string c = "";
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != ' ')
                {
                    b = b + a[i];
                }
            }
            for (int i = b.Length - 1; i >= 0; i = i - 1)
            {
                c = c + b[i];
            }
            Console.WriteLine(c);
            if (c == b)
            {
                Console.WriteLine(a + " +est un palindrome");
            }
            else
            {
                Console.WriteLine(" Il n'y a pas de palindrome");
            }
        }

        static void exercice6()
        {
            double x;
            double y;
            double d;
            double m = 0;
            double f;
            int n = int.Parse(Console.ReadLine());
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble();
                y = rand.NextDouble();
                d = Math.Sqrt((x * x) + (y * y));
                if (d <= 1)
                {
                    m = m + 1;
                }
            }
            f = m / (double)n * 100;
            Console.WriteLine(f + "% des points sont a moins de 1 de distance de l'origine ");

        }




    }
}
