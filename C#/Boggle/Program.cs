using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TD1_2019
{
    class Program
    {
        private static Timer aTimer;
        private static Jeu monJeu;
        private static int maxtour;
        static void Main(string[] args)
        {
            Console.WriteLine("Combien y a t'il de tours durant votre partie de boggle?");
            maxtour = Jeu.DemanderInt(1, 80);
            monJeu = new Jeu();
            
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 40000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
            string reponse;
            Console.Clear();
            Console.WriteLine("C'est au tour de " + monJeu.GetJoueur().GetName());
            Console.WriteLine(monJeu.GetPlateau().ToString());
            while (monJeu.GetTour() < maxtour)
            {

                reponse = Console.ReadLine();
                if (monJeu.GetDico().IsInDico(reponse))
                {
                    if (monJeu.GetPlateau().Test_Plateau(reponse))
                    {
                        monJeu.GetJoueur().add_Mot(reponse);
                    }
                    else
                    {
                        Console.WriteLine("Le mot n'est pas sur le plateau");
                    }
                }
                else
                {
                    Console.WriteLine("Le mot n'est pas dans le dictionnaire");
                }

               
            }

        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.Clear();
            monJeu.JoueurSuivant();           
            if(monJeu.GetTour() >= maxtour)
            {
                Console.WriteLine("Le jeu est fini");
                Console.WriteLine(monJeu.ScoreFinaux());
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("C'est au tour de " + monJeu.GetJoueur().GetName());
                Console.WriteLine(monJeu.GetPlateau().ToString());
            }
            
        }
    }    
}

