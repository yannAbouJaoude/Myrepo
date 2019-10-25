using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class Entreprise
    {
        public string nom;
        private string adresse;
        public Entreprise(string nom, string adresse)
        {
            this.nom = nom;
            this.adresse = adresse;
        }
        public override string ToString()
        {
            return "nom: " + nom + " adresse: " + adresse;
        }
    }
}
