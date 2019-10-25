using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Leprechaun observateur1 = new Leprechaun(1);
            Leprechaun observateur2 = new Leprechaun(2);
            Leprechaun observateur3 = new Leprechaun(3);
            CustomList<int> Sujet1 = new CustomList<int>();

            Sujet1.Register(observateur1);
            Sujet1.Register(observateur3);

            Sujet1.add(5);

            Sujet1.Register(observateur2);
            Sujet1.UnRegister(observateur3);

            Sujet1.add(4);

            Console.ReadKey();
        }
    }
}
