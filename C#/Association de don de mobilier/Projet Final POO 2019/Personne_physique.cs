using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Personne_physique:Personne
    {
        public string prenom;
        protected Personne_physique( string prenom, int identifiant, string nom, string adresse, string telephone):base(identifiant,nom,adresse,telephone)
        {
            this.prenom = prenom;
        }
        public static List<Personne_physique> Lire(string fichierAdherent, string fichierBeneficiaire)
        {
            List<Personne_physique> retour = new List<Personne_physique>();
            foreach (Adherent a in Adherent.Lire("Adherents.txt"))
            {
                retour.Add(a);
            }
            foreach (Beneficiaire a in Beneficiaire.Lire("Beneficiaires.txt"))
            {
                retour.Add(a);
            }
            return retour;
        }
        public override string ToString()
        {
            return "Id: " + identifiant + " Prenom: " + prenom + " Nom: " + nom + "\n" + "Adresse: " + adresse + " telephone " + telephone + "\n";
        }
        protected Personne_physique():base()
        {
            Console.WriteLine("Veuillez entrez le prenom du nouveau venu");
            prenom = Console.ReadLine();
           
        }
    }
}
