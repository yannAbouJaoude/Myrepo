using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_de_hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int nb = 5;
            tours('a', 'c', 'b', nb);
            Console.WriteLine("Voici le nombres de déplacements " + compteur);
            Console.ReadKey();
        }
       

        static void tours(char deplacement, char destination, char echange, int n)
        {
            if (n == 1)
            {
                Console.WriteLine("Déplacez " + deplacement + " vers " + destination);
                compteur++;
            }
            else
            {
                tours(deplacement, echange, destination, n - 1);   
                tours(deplacement, destination, echange, 1); 
                tours(echange, destination, deplacement, n - 1);   
            }
        }
        static int compteur = 0;
    }
}
