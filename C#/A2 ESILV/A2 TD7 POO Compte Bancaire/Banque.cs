using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A2_TD7
{
    class Banque
    {
        public static void ReadFile(string filename)
        {
            string line = File.ReadAllText(filename);
            
            Console.WriteLine(line);
            
        }
    }
}
