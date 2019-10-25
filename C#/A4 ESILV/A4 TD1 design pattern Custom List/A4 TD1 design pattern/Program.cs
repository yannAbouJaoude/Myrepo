using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD1_design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> a = new CustomList<int>();
            a.print();
            a.add(5);
            a.remove(0);
            a.remove(1);
            a.add(5);

            a.print();
            a.add(4);
            a.print();
            Console.WriteLine(a.get(1));
            Console.WriteLine(a.get(0));
            a.remove(1);
            a.print();
            Console.ReadKey();
        }
    }
}
