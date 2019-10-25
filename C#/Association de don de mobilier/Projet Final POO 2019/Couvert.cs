using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Couvert:Vaisselle
    {
        public Couvert(int nbDePiece, string description) : base(nbDePiece, description)
        {

        }
    }
}
