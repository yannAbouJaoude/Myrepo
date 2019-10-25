using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercice1();
            // exercice2();
            exercice4();
            Console.ReadKey();
        }


        static int F(int x)
        {
            return 2 * x + 2;
        }

        static void exercice1()
        {
            Console.WriteLine(" On fait appel a la méthode F avec l'argument x = " + 3);
            int res = F(3);
            Console.WriteLine("res = " + res);
            int z = 2;
            Console.WriteLine("res = " + res + "    z = " + z );
            Console.WriteLine(" On fait appel a la méthode F avec l'argument x = " + z);
            res = F(z);
            Console.WriteLine("res = " + res + "    z = " + z);
            Console.WriteLine(" On fait appel a la méthode F avec l'argument x = " + res);
            res = F(res);
            Console.WriteLine("res = " + res + "    z = " + z);
            Console.WriteLine(" On fait appel a la méthode F avec l'argument x = " + res);
            Console.WriteLine("F(res) = " + F(res));
        }

        static void exercice2()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a == 0 || b == 0) { Console.WriteLine("Le produit est nul"); }
            else if (a > 0 && b > 0) { Console.WriteLine("Le produit est positif"); }
            else if (a < 0 && b < 0) { Console.WriteLine("Le produit est positif"); }
            else { Console.WriteLine("Le produit est négatif"); }

        }


        static void exercice4v2()
        {
            string s = Console.ReadLine();
            int x = int.Parse(Console.ReadLine());
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i != x)
                {
                    str = str + s[i];
                }
            }
            Console.WriteLine(str);
        }

        static void exercice4()
        {
            string s = Console.ReadLine();
            int x = int.Parse(Console.ReadLine());
            s=s.Remove(x-1, 1);
            Console.WriteLine(s);
        }


    }
}
