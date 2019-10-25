using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_4_POO_exercice_1_2019
{
    class Salarie : personne
    {
        private int salaire;
        private string email;
        private DateTime EntreeDansLEntreprise;
        public Salarie(string nom, string prenom, string adresse, string telephone, char sexe, DateTime naissance,int salaire,string email,DateTime EntreeDansLEntreprise):base(nom, prenom, adresse, telephone, sexe, naissance)
        {
            this.salaire = salaire;
            this.email = email;
            this.EntreeDansLEntreprise = EntreeDansLEntreprise;
        }
        public override string ToString()
        {
            return base.ToString()+" Salaire: "+salaire+" Email: "+email+ " Date d'entree dans l'entreprise:" +EntreeDansLEntreprise;
        }
        public int Anciennete()
        {
            return DateTime.Now.Year - EntreeDansLEntreprise.Year;
        }
        public override string Coordonnees()
        {
            return base.Coordonnees() + " Email: " + email;
        }
    }
}
