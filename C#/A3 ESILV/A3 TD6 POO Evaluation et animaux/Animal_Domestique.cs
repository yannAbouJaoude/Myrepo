using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019
{
    class Animal_Domestique
    {
        public string nom;
        public string pseudo;
        public DateTime date_naissance;
        public double poids;
        public Animal_Domestique(string nom, string pseudo, DateTime date_naissance, double poids)
        {
            this.nom = nom;
            this.pseudo = pseudo;
            this.date_naissance = date_naissance;
            this.poids = poids;
        }
        public override string ToString()
        {
            return "nom: "+nom +" pseudo: "+ pseudo +" date de naissance: "+ date_naissance+" poids: "+poids;
        }
    }
}
