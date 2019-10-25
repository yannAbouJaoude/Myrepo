using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD7
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque.ReadFile("Clients.csv");
            Console.ReadKey();
        }
    }
}
