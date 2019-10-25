using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleKey choix;
            int[,] plateau = new int[20,20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    plateau[i, j] = 0;
                } 
            }
            bool resterDansLeMenu = true;
            while (resterDansLeMenu)
            {
                choix = Console.ReadKey().Key;
                Console.Clear();
                afficher(plateau);
                if (choix == ConsoleKey.Enter)
                {
                    resterDansLeMenu = false;
                }
            }




            afficher(plateau);







            Console.ReadKey();
        }



        static void afficher(int[,]plateau)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("|" + plateau[i, j]);

                }
                Console.WriteLine("|");
                Console.WriteLine("----------------------------------------");
            }
        }



    }
}
