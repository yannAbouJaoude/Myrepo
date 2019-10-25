using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Vaisselle:Objet
    {
        public int nbDePiece;
        protected Vaisselle(int nbDePiece,string description) : base(description)
        {
            this.nbDePiece = nbDePiece;
        }
        public override string ToString()
        {
            return base.ToString() + "\n"+"Nombre de pièces "+nbDePiece;
        }
    }
}
