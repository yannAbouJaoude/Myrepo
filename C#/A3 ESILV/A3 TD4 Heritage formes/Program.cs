using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_POO_exercice_2_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            cercle monCercle = new cercle(4);
            Console.WriteLine("Soit un cercle de rayon 4:");
            Console.WriteLine("Aire : " + monCercle.aire());
            Console.WriteLine("Perimetre = " + monCercle.perimetre());
            rectangle monRectangle = new rectangle(4,6);
            Console.WriteLine("Soit un restangle de hauteur 4 et de largeur 6:");
            Console.WriteLine("Aire : " + monRectangle.aire());
            Console.WriteLine("Perimetre = " + monRectangle.perimetre());

            Console.ReadKey();

        }
    }
}
