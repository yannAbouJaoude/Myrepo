using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_POO_exercice_2_2019
{
    class rectangle:figure
    {
        private int hauteur;
        private int largeur;
        public rectangle(int hauteur, int largeur)
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            point_dorigine = "Coin en haut a droite";
        }
        public override double aire()
        {
            return hauteur*largeur;
        }
        public override double perimetre()
        {
            return 2 * (hauteur+largeur);
        }
    }
}
