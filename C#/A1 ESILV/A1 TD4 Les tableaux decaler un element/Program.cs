using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tableau = { 0, -200, 1, 78, 54, 2 };

            WWWWW(tableau);

            foreach (int val in tableau) Console.WriteLine(val);
            Console.ReadLine();
        }



  static void WWWWW(int[] tab)

        {

            bool flag = false;

            int stock = 0;

            for (int i = 0; (i <= tab.Length - 1) && (flag == true); i++)

            {

                flag = true;



                for (int j = 0; j < tab.Length - 1 - i; j++)

                {

                    if (tab[j] > tab[j + 1])

                    {

                        stock = tab[j];

                        tab[j] = tab[j + 1];

                        tab[j + 1] = stock;

                        flag = true;

                    }

                }

            }

        }
    }
}
