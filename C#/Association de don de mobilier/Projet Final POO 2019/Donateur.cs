using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Donateur:Adherent
    {
        public Maison maMaison;       
        public Donateur(string fonction, string prenom, string nom, string adresse, string telephone):base(fonction,prenom,nom,adresse,telephone)
        {
            maMaison = new Maison(nom,adresse,telephone);
        }
        /// <summary>
        /// Constructeur qui copie  un adhérent pour en faire un donateur.
        /// </summary>
        /// <param name="a"></param>
        public Donateur(Adherent a) : base(a.Fonction, a.prenom, a.nom, a.adresse, a.telephone)
        {
            maMaison = new Maison( nom, adresse, telephone);
            Association.monAssociation.mesAdherents.Remove(a);;
        }
        public Donateur()
        {
            maMaison = new Maison(nom, adresse, telephone);
        }
    }
}
