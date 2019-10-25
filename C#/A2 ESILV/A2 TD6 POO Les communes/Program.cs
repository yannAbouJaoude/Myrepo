using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD6
{
    class Program
    {
        static void Main(string[] args)
        {
            Commune Paris = new Commune("Paris", 75, "France","Hidalgo", 2200000);
            Commune Rouen = new Commune("Rouen", 76, "France","Robert", 111000);
            Paris.Population = 2220000;
            string s = Rouen.toString();
            bool b = Paris.equals(Rouen);
            Console.WriteLine(s);
            Console.WriteLine(b);
            Console.ReadKey();
        }
       
    }
}
