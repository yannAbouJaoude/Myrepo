using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo1_2_3_4();
            //Exo5_6_7();
            //Exo8();
            //Exo10();
            Console.ReadKey();
        }

        static void Exo1_2_3_4()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i]);
                if (i < tab.Length - 1)
                    Console.Write(" ; ");
            }
            Console.WriteLine();

            foreach (int a in tab)
            {
                Console.Write(a+"   ");
            }
            Console.WriteLine();

            for (int i = tab.Length-1; i >=0 ; i=i-1)
            {
                Console.Write(tab[i] + "   ");
            }
            Console.WriteLine();
            // exo 4 
            for (int i = 1; i < tab.Length; i=i+2)          
            {               
                    Console.Write(tab[i] + " ");
            }
        }
        static void Exo5_6_7()
        {         
            int a = int.Parse(Console.ReadLine());
            int[] tab = new int[a];

            //exo 5
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = a;
                a = a - 1;
                Console.Write(tab[i] + "    ");
            }
            Console.WriteLine();

            // exo 6
            a = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = a;
                a = a + 2 ;
                Console.Write(tab[i] + "    ");
            }
            Console.WriteLine();

           // Exo7
            a = 2;
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = a;
                a = a * 2;
                Console.Write(tab[i] + "    ");
            }

        }
        static void Exo8()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(tab[j] + "   ");
                }
                Console.WriteLine();
            }
        }
        static void Exo10()
        {
            string a = Console.ReadLine();
            bool b = true;
            int i = 0;
            while ( i < a.Length/2 && b)
            {
                if (a[i] != a[a.Length - i - 1])
                {
                    b = false;
                }
                i++;
            }
            Console.WriteLine(b);
        }
    }

}
