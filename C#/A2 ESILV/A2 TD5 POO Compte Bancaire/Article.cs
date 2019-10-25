using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD_6
{
    class Article
    {
        private long reference;
        private string intitule;
        private float prixHT;
        private int quantiteEnStock;
        public Article(long reference, string intitule, float prixHT, int quantiteEnStock)
        {
            this.reference = reference;
            this.intitule = intitule;
            this.prixHT = prixHT;
            this.quantiteEnStock = quantiteEnStock;
        }
        public long reff
        {
            get { return reference; }
            set { reference = value; }
        }
        public string inti
        {
            get { return intitule; }
            set { intitule = value; }
        }
        public float HT
        {
            get { return prixHT; }
            set { prixHT = value; }
        }
        public int qte
        {
            get { return quantiteEnStock; }
            set { quantiteEnStock = value; }
        }
        public void approvisionner(int nombreUnites)
        {
            quantiteEnStock += nombreUnites;
            Console.WriteLine(nombreUnites + " Unités ont étés ajoutées");
        }
        public bool vendre(int nombreUnites)
        {
            bool rep = false;
            if (nombreUnites > quantiteEnStock)
            {
                Console.WriteLine("Pas assez de stock");
            }
            else
            {
                quantiteEnStock -= nombreUnites;
                Console.WriteLine("Vente effectuée");
                rep = true;
            }
            return rep;
        }
        public float prixTTC()
        {
            return (float)(prixHT * 1.2);
        }
        public string toString()
        {
            return "{ref: " + reference + ", intitulé: " + intitule + ", PrixHT: " + prixHT + "}";
        }
        public bool equals(Article unArticle)
        {
            bool rep = false;

            if (this.reference == unArticle.reff)
            {
                rep = true;
            }

            return rep;
        }
    }
}
