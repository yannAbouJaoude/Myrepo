using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Personne_Morale:Personne
    {
        public List<Objet> inventaire;
        public string typeDActivitee;
        private static int compteur=1;// compte les identifiants des personnes morales

        public Personne_Morale(string typeDActivitee, string nom, string adresse, string telephone):base(compteur,nom,adresse,telephone)
        {
            this.typeDActivitee = typeDActivitee;
            inventaire= new List<Objet>();
            compteur++;
        }
        public Personne_Morale(string typeDActivitee):base()
        {
            identifiant = compteur;
            this.typeDActivitee = typeDActivitee;
            inventaire = new List<Objet>();
        }
        public virtual void Retirer(Objet marchandise, DateTime depart)
        {
            marchandise.Date_De_Retrait = depart;
            inventaire.Remove(marchandise);
        }
        public override string ToString()
        {
            return "Type de lieu de stokage: "+typeDActivitee+"\n"+base.ToString();
        }
        public void StockerUnDon(Don don)
        {
            inventaire.Add(don.marchandise);
            don.marchandise.emplacement = this;
        }
        public List<Objet> TrisParVolume()
        {
            List<Objet_Volumineux> ov = new List<Objet_Volumineux>();
            List<Vaisselle> vaisselle = new List<Vaisselle>();
            List<Objet> retour = new List<Objet>();
            foreach (Objet x in inventaire)
            {
                if (x is Objet_Volumineux)
                {
                    ov.Add((Objet_Volumineux)x);
                }
                else if (x is Vaisselle)
                {
                    vaisselle.Add((Vaisselle)x);
                }              
            }
            ov.Sort(delegate (Objet_Volumineux x, Objet_Volumineux y)
            {
                double volumeX= x.longueur * x.largeur * x.hauteur;
                double volumeY= y.longueur * y.largeur * y.hauteur;
                return volumeX.CompareTo(volumeY);
            });
            vaisselle.Sort(delegate (Vaisselle x, Vaisselle y)
            {
                return x.nbDePiece.CompareTo(y.nbDePiece);
            });
            foreach (Objet x in ov)
            {
                retour.Add(x);
            }
            foreach (Objet x in vaisselle)
            {
                retour.Add(x);
            }
            return retour;

        }
        public TimeSpan MoyenneTempsStockage()
        {
            TimeSpan sum = new TimeSpan(0,0,0);
            foreach (Objet y in inventaire.FindAll(x => x.Date_De_Retrait != null && x.Date_Du_Depot != null))
            {
                if (y.Date_De_Retrait > y.Date_Du_Depot)
                {
                    sum = sum + (y.Date_De_Retrait - y.Date_Du_Depot);
                }
            }
            if (sum.Ticks==0)
            {
                Console.WriteLine("Aucun objet n'est encore rentré et sortie dans cette entrepot.");
                return new TimeSpan(0);
            }
            return new TimeSpan(sum.Ticks / inventaire.FindAll(x => x.Date_De_Retrait != null && x.Date_Du_Depot != null).Count());
        }
    }
}
