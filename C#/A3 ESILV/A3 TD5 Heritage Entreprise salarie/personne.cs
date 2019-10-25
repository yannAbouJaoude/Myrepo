using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5_POO_2019
{
    class personne
    {
        protected string nom;
        protected string prenom;
        protected DateTime naissance;
        protected char sexe;
        protected string adresse;
        protected string telephone;

        public personne(string nom, string prenom, string adresse, string telephone, char sexe, DateTime naissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.sexe = sexe;
            this.adresse = adresse;
            this.telephone = telephone;
        }
        public string getNom()
        {
            return nom;
        }
        public int age()
        {
            return DateTime.Now.Year - naissance.Year;
        }
        public override string ToString()
        {
            return "prenom: " + prenom + " nom: " + nom + " sexe: " + sexe + " adresse: " + adresse + " telephone: " + telephone;
        }
        public virtual string Coordonnees()
        {
            return "telephone: " + telephone;
        }
    }
}
