using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_2019
{
    class Jeu
    {
        private int joueurCourant;
        private Joueur[] mesJoueurs;
        private Plateau monPlateau;
        private Dictionnaire dico;
        private int tour;
        private int nbDeJoueurs;

        public Jeu()
        {
            dico = new Dictionnaire("MotsPossibles.txt");
            Console.WriteLine("Entrez le nombre de joueur");
            nbDeJoueurs = DemanderInt(1,64);
            mesJoueurs = new Joueur[nbDeJoueurs];
            string nom;
            for (int i = 0; i < nbDeJoueurs; i++)
            {
                Console.WriteLine("Entrez le nom du joueur" + (i + 1));
                nom = Console.ReadLine();
                mesJoueurs[i] = new Joueur(nom);
            }
            monPlateau = new Plateau("Des.txt");
            joueurCourant = 0;
            tour = 0;
        }
        public void JoueurSuivant()
        {
            mesJoueurs[joueurCourant].scoring();
            joueurCourant++;
            if(joueurCourant== nbDeJoueurs)
            {
                tour++;
                joueurCourant=0;
            }
            monPlateau.Relance();
        }
        public int GetTour()
        {
            return tour;
        }
        public Dictionnaire GetDico()
        {
            return dico;
        }
        public Plateau GetPlateau()
        {
            return monPlateau;
        }
        public static int DemanderInt(int min, int max)
        {
            int a;
            string entre = "a";
            while (int.TryParse(entre, out a) == false)
            {
                if (entre != "a")
                {
                    Console.WriteLine("veuillez saisir un nombre entier");
                }
                entre = Console.ReadLine();
            }
            a = int.Parse(entre);
            if (a < min || a > max)
            {
                Console.WriteLine("Impossible! veuillez saisir un entier compris entre " + min + " et " + max);
                a = DemanderInt(min, max);
            }
            return a;
        }
        public Joueur GetJoueur()
        {
            return mesJoueurs[joueurCourant];
        }
        public string ScoreFinaux()
        {
            string retour = "";
            for (int i = 0; i < nbDeJoueurs; i++)
            {
                retour += mesJoueurs[i].ToString()+" \n";
            }
            return retour;
        }
    }
}
