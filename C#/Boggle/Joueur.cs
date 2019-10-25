using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_2019
{
    class Joueur
    {
        private string nom;
        private int score;
        private int nbMotTrouve;
        private string[] motTrouve;

        public Joueur(string nom)
        {
            this.nom = nom;
            nbMotTrouve = 0;
            score = 0;
            motTrouve = new string[0];
        }
        public void add_Mot(string mot)
        {         
            if (!Contain(mot))
            {
                Console.WriteLine("Mot accepté");
                string[] tmpMotTrouve=new string[nbMotTrouve+1];
                for (int i = 0; i < nbMotTrouve; i++)
                {
                    tmpMotTrouve[i] = motTrouve[i];
                }
                tmpMotTrouve[nbMotTrouve]=mot;
                nbMotTrouve++;
                motTrouve = tmpMotTrouve;
            }
        }
        public bool Contain(string mot)
        {
            for (int i = 0; i < nbMotTrouve; i++)
            {
                if (mot == motTrouve[i])
                {
                    return true;
                    Console.WriteLine("Tu as deja entré ce mot");
                }
            }
            return false;
        }
        public string ToString()
        {
            return "Le joueur " + nom + " a un score de " + score + " points";
        }
        public string GetName()
        {
            return nom;
        }
        public void scoring()
        {
            for (int i = 0; i < motTrouve.Length; i++)
            {
                score += motTrouve[i].Length;
            }
            //string[] tmpMotTrouve = new string[0];
            motTrouve = new string[0];
            nbMotTrouve = 0;
        }
    }
}
