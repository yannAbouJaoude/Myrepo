using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomTree<int> a = new CustomTree<int>();
            PreorderPrinter<int> alien = new PreorderPrinter<int>();
            InorderPrinter<int> alien2 = new InorderPrinter<int>();
            PostorderPrinter<int> alien3 = new PostorderPrinter<int>();
            a.addVisitor(alien);
            a.Add(5);
            a.Add(8);
            a.Add(9);
            alien.print(a);
            Console.WriteLine();
            alien2.print(a);
            Console.WriteLine();
            alien3.print(a);
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
