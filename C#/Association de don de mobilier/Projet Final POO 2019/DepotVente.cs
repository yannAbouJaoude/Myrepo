using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class DepotVente : Personne_Morale,IMoyenne
    { 
        private double solde;
        private double commission;
        public DepotVente(string nom, string adresse, string telephone,double commission):base("Dépot de vente",nom,adresse,telephone)
        {
            solde = 1000;
            inventaire = new List<Objet>();
            this.commission = commission;
        }
        public DepotVente():base("Dépot de vente")
        {
            solde = 1000;
            inventaire = new List<Objet>();
            Console.WriteLine("Quel est le taux de commission de ce nouveau dépot de vente?");
            commission = Menu.askDouble(0,1);
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + "Taux de commission: " + commission * 100 + "%";
        }
        public override void Retirer(Objet marchandise,DateTime vente)
        {
            solde += marchandise.montant * commission;
            marchandise.Date_De_Retrait = vente;
            inventaire.Remove(marchandise);
        }
        public void StockerUnDon(Don don, int montant, DateTime date_Du_Depot, DateTime dateDeVente)
        {
            // Association.monAssociation.depotsDeVentes.Find(delegate (DepotVente x) { return x == lieu; }).Deposer(marchandise, depot);
            don.marchandise.Date_Du_Depot = date_Du_Depot;
            inventaire.Add(don.marchandise);
            don.marchandise.montant = montant;
            don.marchandise.emplacement = this;
            don.statue = "stocké";
        }
        public double Moyenne() {
            double sum = 0;
            foreach(Objet x in inventaire)
            {
                sum += x.montant;
            }
            return sum / inventaire.Count();
                }
    }
}
