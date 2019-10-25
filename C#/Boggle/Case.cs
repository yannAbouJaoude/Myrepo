using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_2019
{
    class Case
    {
        private string lettresPossibles;
        private char lettreVisible;
        public Case(string s,Random r)
        {
            lettresPossibles = "";
            for (int i = 0; i < 12; i=i+2)
            {
                lettresPossibles += s[i];
            }
            lance(r);
        }
        public void lance(Random r)
        {
            int tmp = r.Next(0, 6);
            lettreVisible = lettresPossibles[tmp];
        }
        public string toString()
        {
            return "La lettre visible est \n"+lettreVisible+ "\n Les lettres possibles sont \n"+ lettresPossibles+"\n";
        }
        public char getVisible()
        {
            return lettreVisible;
        }
    }
}
