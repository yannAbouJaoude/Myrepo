using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD6
{
    class Commune
    {
        private int populationPrivee;
        private int départementPrivee;
        private string paysPrivee;
        private string mairePrivee;
        private string nomPrivee;

        

        public Commune(string nom, int département, string pays, string maire, int population)
        {
            if (population > 0)
            {
                populationPrivee = population;
            }
            else
            {
                populationPrivee = -1;
            }
            if (département > 0)
            {
                départementPrivee = département;
            }
            else
            {
                départementPrivee = -1;
            }
            paysPrivee = pays.ToUpper();
            nomPrivee = nom.ToUpper();
            mairePrivee = maire.ToLower();
        }

        public string toString()
        {
            
            return ("Commune : " + nomPrivee + " Population : " + populationPrivee + " Pays : " + paysPrivee + " Départemant : " + départementPrivee + " Maire : " + mairePrivee);
         
        }
        public bool equals(Commune uneCommune)
        {
            return (populationPrivee == uneCommune.populationPrivee);
        }

        public static bool  staticEquals(Commune uneCommune, Commune pas)
        {
            return (uneCommune.populationPrivee == pas.populationPrivee);
        }
        public int Population
        {
            get { return populationPrivee; }
            set {
                if (value>0)
                {
                    populationPrivee = value;
                }
                else
                {
                    populationPrivee = -1;
                }
            }
        }
        public string Maire
        {
            get { return mairePrivee; }
            set { mairePrivee = value; }
        }
    }
}
