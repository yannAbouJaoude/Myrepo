using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Garde_Meuble:Personne_Morale
    {
        
        public Garde_Meuble( string nom, string adresse, string telephone):base("Garde Meuble",nom,adresse,telephone)
        {           
        }
        public Garde_Meuble():base("Garde Meuble")
        {
        }
        public override void Retirer(Objet marchandise, DateTime vente)
        {
            marchandise.Date_De_Retrait = vente;
            inventaire.Remove(marchandise);
        }
        public void StockerUnDon(Don don, DateTime date_Du_Depot,DateTime Date_De_Retrait, Beneficiaire monBeneficiaire)
        {
            don.marchandise.Date_Du_Depot = date_Du_Depot;
            don.marchandise.Date_De_Retrait = Date_De_Retrait;
            inventaire.Add(don.marchandise);
            don.marchandise.emplacement = this;
            don.statue = "stocké";
        }
    }
}
