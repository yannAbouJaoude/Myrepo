using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Objet_Volumineux: Objet
    {
        public double hauteur;
        public double largeur;
        public double longueur;
        public Objet_Volumineux(double hauteur, double largeur, double longueur,  string description):base(description)
        {
            this.hauteur=hauteur;
            this.largeur = largeur;
            this.longueur = longueur;
        }
        public override string ToString()
        {
            return base.ToString()+"\n"+"Dimension: \n"+"Longueur: "+longueur + "\n" + "Largeur: "+largeur + "\n" + "Hauteur: "+hauteur;
        }

    }
}
