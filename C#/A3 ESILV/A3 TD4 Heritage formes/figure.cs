using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_POO_exercice_2_2019
{
    abstract class figure
    {
        protected string point_dorigine;
        abstract public double aire();
        abstract public double perimetre();
    }
}
