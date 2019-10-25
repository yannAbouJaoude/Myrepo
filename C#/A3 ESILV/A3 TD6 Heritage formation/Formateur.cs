using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class Formateur
    {
        private string securiteSocial;
        private string nom;
        private string adresse;
        private string telephone;

        public Formateur(string securiteSocial,string nom,string adresse,string telephone)
        {
            this.securiteSocial = securiteSocial;
            this.nom = nom;
            this.adresse = adresse;
            this.telephone = telephone;
        }
    }
}
