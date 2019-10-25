using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5_POO_2019
{
    class Salarie:personne,IComparable
    {
        private int salaire;
        private string email;
        private DateTime EntreeDansLEntreprise;
        public Salarie(string nom, string prenom, string adresse, string telephone, char sexe, DateTime naissance, int salaire, string email, DateTime EntreeDansLEntreprise) : base(nom, prenom, adresse, telephone, sexe, naissance)
        {
            this.salaire = salaire;
            this.email = email;
            this.EntreeDansLEntreprise = EntreeDansLEntreprise;
        }
        public override string ToString()
        {
            return base.ToString() + " Salaire: " + salaire + " Email: " + email + " Date d'entree dans l'entreprise:" + EntreeDansLEntreprise;
        }
        public int Anciennete()
        {
            return DateTime.Now.Year - EntreeDansLEntreprise.Year;
        }
        public override string Coordonnees()
        {
            return base.Coordonnees() + " Email: " + email;
        }
      /*  public int CompareTo(Salarie item)
        {
            if (getNom() == item.getNom())
            {
                for (int i = 0; i < getNom().Length && i < item.getNom().Length; i++)
                {

                    if (getNom()[i] > item.getNom()[i])
                    {
                        return 1;
                    }
                    else if (getNom()[i] < item.getNom()[i])
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return 0;
            }
            return 0;
        }*/
        public int CompareTo(object item)
        {
            return nom.CompareTo(((Salarie)(item)).nom);
        }

    }
}
