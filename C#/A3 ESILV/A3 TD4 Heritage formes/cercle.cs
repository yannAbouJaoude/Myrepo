using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_POO_exercice_2_2019
{
    class cercle:figure
    {
        private int rayon;
        public cercle(int rayon)
        {
            this.rayon = rayon;
            point_dorigine = "Centre du cercle";
        }
        public override double aire()
        {
            return rayon * rayon * 3.1415;
        }
        public override double perimetre()
        {
            return 2 * rayon * 3.1415;
        }
    }
}
