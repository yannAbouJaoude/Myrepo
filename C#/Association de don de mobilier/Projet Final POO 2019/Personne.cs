using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Personne
    {
        protected int identifiant;
        public string nom;
        public string adresse;
        public string telephone;


        protected Personne(int identifiant, string nom,string adresse,string telephone)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.identifiant = identifiant;
        }
        /// <summary>
        /// Constructeur destiner àl'entréepar un utilisateur
        /// </summary>
        protected Personne()
        {
            Console.WriteLine("Veuillez entrez le nom");
            nom = Console.ReadLine();
            Console.WriteLine("Veuillez entrez l'adresse");
            adresse = Console.ReadLine();
            Console.WriteLine("Veuillez entrez le numero de telephone");
            telephone = Console.ReadLine();
        }
        public int getId()
        {
            return identifiant;
        }
        
        public override string ToString()
        {
            return "Id: "+ identifiant+"\n"+ "Nom: " + nom + "\n"+"Adresse: " + adresse + "\n"+"Telephone: " + telephone;
        }
    }
}
