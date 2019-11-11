using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Design_pattern_MVC
{
    class Drink
    {
        public int cost;
        public string name;
        public Drink(int cost, string name)
        {
            this.cost = cost;
            this.name = name;
        }
        public override string ToString()
        {
            return (name + "Prix : " + cost);
        }
    }
}
