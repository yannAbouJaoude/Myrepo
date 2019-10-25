using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Cuisiniere:Electromenager
    {
        private int puissance;
        private int nbDePlaques;
        public Cuisiniere(double hauteur, double largeur, double longueur,  string description,int puissance,int nbDePlaques) : base(hauteur, largeur, longueur,  description)
        {
            this.puissance = puissance;
            this.nbDePlaques = nbDePlaques;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + "Puissance: " + puissance + "\n" + "Nombre de plaques: " + nbDePlaques;
        }
    }
}
