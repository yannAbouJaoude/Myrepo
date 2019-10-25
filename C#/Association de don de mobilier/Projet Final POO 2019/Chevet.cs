using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Chevet:Mobilier_Chambre
    {
        public Chevet(double hauteur, double largeur, double longueur,  string description) : base(hauteur, largeur, longueur,  description)
        {

        }
    }
}
