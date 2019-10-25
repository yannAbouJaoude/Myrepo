using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Maison:Personne_Morale
    {
        public Maison( string nom, string adresse, string telephone) :base("Stockage chez le donateur",nom,adresse,telephone)
        {
        }        
    }
}
