using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Table:Mobilier_Salle_Cuisine
    {
        private string type;//cuisine ou salon
        private string forme;//carree ronde ou rectangulaire
        public Table(string type, string forme,double hauteur, double largeur, double longueur, string description) : base(hauteur, largeur, longueur, description)
        {
            this.type = type;
            this.forme = forme;
        }
        public override string ToString()
        {
            return base.ToString() + "\n"+"Table de "+type+" de forme "+forme;
        }
    }
}
