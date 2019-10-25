using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_liste_generique
{
    class Salarie
    {
        private int numero;
        private string nom;
        private string prenom;
        private string email;
        private string adresse_postale;
        private int salaire;
        
        public Salarie(string prenom, string nom, string adresse_postale)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.adresse_postale = adresse_postale;
        }
        public string GetPrenom()
        {
            return prenom;
        }
        public string GetNom()
        {
            return nom;
        }
        public string GetAdressePostale()
        {
            return adresse_postale;
        }
        public string GetEmail()
        {
            return email;
        }
        public int GetNumero()
        {
            return numero;
        }
        public int GetSalaire()
        {
            return salaire;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setSalaire(int salaire)
        {
            this.salaire = salaire;
        }
        public void SetNumero(int numero)
        {
            this.numero = numero;
        }
    }
}
