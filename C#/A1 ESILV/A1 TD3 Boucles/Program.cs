using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercice1();
            //Exercice2();
            //Exercice3();
            //Exercice4();
            //Exercice5();
            Exercice6();
            //Exercice7();
            //Exercice8();
            //Exercice9();
            //Exercice10();
            //Exercice11();
            //Exercice12();
            Console.ReadKey();

        }
        static void Exercice1()
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorielle(a));
        }
        static int Factorielle(int a) {
            int b = 1;
            for (int i = a; i > 0; i--)
            {
                b = b * i;
            }
            return b; }

        static void Exercice2()
        {
            int a = int.Parse(Console.ReadLine());
            int exp = int.Parse(Console.ReadLine());
            Console.WriteLine(Puissance(a, exp));
        }
        static int Puissance(int a, int exp)
        {
            int b = 1;
            for (int i = exp; i > 0; i--)
            {
                b = b * a;
            }
            return b;
        }

        static void Exercice3()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Comparer(a, b);
        }
        static int Comparer(int a, int b)
        {
            if (a > b) { Console.WriteLine("a>b"); }
            if (a < b) { Console.WriteLine("a<b"); }
            return 0;
        }

        static void Exercice4() {
            int n = int.Parse(Console.ReadLine());
            Fibonacci(n);
        }
        static int Fibonacci(int n)
        {
            int a = 0, b = 1, c = 1;
            Console.WriteLine(a);
            for (int i = 0; i <= n - 2; i++)
            {
                Console.WriteLine(c);
                c = a + b;
                a = b;
                b = c;
            }
            return 0;
        }

        static void Exercice5() {

            Console.WriteLine(Conversion(Console.ReadLine())); ;

        }
        static int Conversion(string s) { 
            int b=0;
            int c = (int)s.Length;
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] == 49)
                {
                    b = b + Puissance(2, c - i-1);
                }
            }
            return b;
        }

        static void Exercice6()
        {
            string n = Console.ReadLine();
            Armstrong(n);
        }
        static int Armstrong(string a)
        {
            int b = 0;
            for (int i = 0; i < a.Length; ++i)
            { b = b + Puissance(a[i] - 48, a.Length); }
            if (b == int.Parse(a))
            {Console.WriteLine("C'est un nombre d'Armstrong!");}
            else { Console.WriteLine("Ce n'est pas un nombre d'Armstrong!"); }
            return 0;
        }


    }
}
