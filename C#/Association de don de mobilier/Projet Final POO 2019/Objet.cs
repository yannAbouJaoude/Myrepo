using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Objet
    {
        public int reference;
        public DateTime Date_Du_Depot;
        public DateTime Date_De_Retrait;
        public int montant;
        public Beneficiaire monBeneficiaire;
        public Personne_Morale emplacement;//redondant, l'objet est deja enregister dans l'emplacement en question
        private string description;
        protected Objet(string description)
        {
            Association.monAssociation.compteur++;
            montant = 0;
            reference = Association.monAssociation.compteur;
        }
        public override string ToString()
        {
            string retour = "\n";
            string tmp = GetType().ToString();
            string type = "";
            for (int i = 22; i < tmp.Length; i++)
            {
                type += tmp[i];
            }
            retour += "Type: " + type + "\n";
            if (monBeneficiaire != null)
            {
                retour +="Bénéficiaire: " +monBeneficiaire.ToString() + "\n";
            }
            if (montant == 0)
            {
                retour += "Objet GRATUIT";
            }
            else
            {
                retour += "Montant: " + montant + "\n";
            }
            retour += description + "\n";
            if (emplacement != null)
            {
                retour += "Emplacement: \n" + emplacement.ToString() + "\n";
            }
            retour += "Date du depot:  " + Date_Du_Depot + "\n";
            if (Date_De_Retrait != null)
            {
                retour += "Date de retrait: " + Date_De_Retrait;
            }
            return retour;
        }
    }
}
