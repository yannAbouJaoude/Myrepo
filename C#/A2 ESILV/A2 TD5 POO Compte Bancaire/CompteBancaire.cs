using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD_6
{
    class CompteBancaire
    {
        static public int nbrClients = 0;
        static public int nbrClientsB = 0;
        static private int essaisMax = 1;

        private string client;
        private double montant;
        private bool bloque;
        private int essais = 0;

        public CompteBancaire(string client, double montant, bool bloque)
        {
            this.client = client;
            this.montant = montant;
            this.bloque = bloque;
            nbrClients++;
        }
        public CompteBancaire(string client, double montant)
        {
            this.client = client;
            this.montant = montant;
            this.bloque = false;
            nbrClients++;
        }
        public double mont
        {
            get { return montant; }
        }
        public bool bloqu
        {
            get { return bloque; }
        }
        public void Debiter(double montant)
        {
            if (!this.bloque)
            {
                if (this.montant >= montant)
                {
                    this.montant -= montant;
                    this.essais = 0;
                    if (bloque) { bloque = false; nbrClientsB--; }
                }
                else
                {
                    Console.WriteLine("Pas assez d'argent");
                    if (this.essais == essaisMax)
                    {
                        this.essais = 0;
                        this.bloque = true;
                        nbrClientsB++;
                        Console.WriteLine("Après " + essaisMax + " tentatives échouées, le compte est maintenant bloqué");
                    }
                    else
                    {
                        this.essais++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ce compte est bloqué");
            }
        }
        public void Crediter(double montant)
        {
            if (!this.bloque)
            {
                this.montant += montant;
            }
            else
            {
                Console.WriteLine("Ce compte est bloqué");
            }
        }
    }
}
