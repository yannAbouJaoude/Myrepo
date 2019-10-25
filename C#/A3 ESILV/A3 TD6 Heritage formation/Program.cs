using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entreprise> ListeEntreprise = new List<Entreprise>();
            ListeEntreprise.Add(new Entreprise("Google", "Californie"));
            ListeEntreprise.Add(new Entreprise("ESILV", "Courbevoie"));
            ListeEntreprise.Add(new Entreprise("Dassault", "Suresne"));
            ListeEntreprise.Add(new Entreprise("Airbus", "Toulouse"));
            ListeEntreprise.Add(new Entreprise("Société général", "Paris"));

            List<Participant> ListeParticipant = new List<Participant>();
            ListeParticipant.Add(new Participant(0,"Alexandre Bonan","Paris","0614558895"));
            ListeParticipant.Add(new Participant(1, "Nicolas Caillieux", "Brunoy", "0679585214"));
            ListeParticipant.Add(new Participant(2, "Louis Caujolle", "Champigny", "0614585685"));
            ListeParticipant.Add(new Participant(3, "Mael Ballet", "Paris", "0645758652"));
            ListeParticipant.Add(new Participant(4, "Nizam Benhocine", "Montgeron", "0674125478"));
            ListeParticipant.Add(new Participant(5, "Celine Bessa", "Boissy-st-Leger", "0645785263"));
            ListeParticipant.Add(new Participant(6, "Yann Abou Jaoude", "Boulogne-Billancourt", "0602520236"));
            ListeParticipant.Add(new Participant(7, "Antoine Capton", "Créteil", "0658963652"));
            ListeParticipant.Add(new Participant(8, "Rayane Aberkane", "Melun", "0715368545"));

            List<Formateur> ListeFormateur = new List<Formateur>();
            ListeFormateur.Add(new Formateur("1235245685452", "Marc-Etienne Dartus", "Riverside", "0658457598"));
            ListeFormateur.Add(new Formateur("0254568502654", "Alexandre Zajac", "Varsovie", "0698583212"));
            ListeFormateur.Add(new Formateur("4785302102567", "Pierre Debaizieux", "Versaille", "0654446202"));

            List<string> ListeMatiere = new List<string>();
            ListeMatiere.Add("Histoire paléo-chrétienne");
            ListeMatiere.Add("Sociologie");
            ListeMatiere.Add("Traitement du signal");
            ListeMatiere.Add("Géographie Yougoslave");

            LongueDuree maFormationLongueDuree = new LongueDuree(ListeFormateur, 14, "Initiation à la postéropodie", ListeParticipant);
            ListeParticipant.Add(new Participant(9, "Quentin Calais", "Chatoux", "0606854760"));
            ListeParticipant.Add(new Participant(10, "Leeroy Bitbol", "Jerusalem", "06024120"));
            ListeParticipant.Add(new Participant(11, "Amine Agoussal", "Fontainebleau", "07031202"));
            CourteDuree maFormationCourteDuree = new CourteDuree(ListeMatiere, "BAFA", ListeParticipant);
            AvecStage maFormationAvecStage = new AvecStage(ListeEntreprise, "Attestation d'aptitude à l'utilisation de machine à café", ListeParticipant);

            Console.WriteLine("Voici la liste des participants de " + maFormationLongueDuree.nom + ":\n" + maFormationLongueDuree.participantToString());
            Console.WriteLine("Voici la liste des participants de " + maFormationCourteDuree.nom + ":\n" + maFormationCourteDuree.participantToString());
            Console.WriteLine("Voici la liste des participants de " + maFormationAvecStage.nom + ":\n" + maFormationAvecStage.participantToString());
            Console.WriteLine("Voici la liste des entreprises de " + maFormationAvecStage.nom + ":\n" + maFormationAvecStage.entrepriseToString());
            Console.WriteLine("\n"+"Voici le cout de " + maFormationLongueDuree.nom + ":\n" + maFormationLongueDuree.getCout());
            Console.WriteLine("Voici le cout de " + maFormationCourteDuree.nom + ":\n" + maFormationCourteDuree.getCout());
            Console.WriteLine("Voici le cout de " + maFormationAvecStage.nom + ":\n" + maFormationAvecStage.getCout());

            List< Formation > listeFormation= new List<Formation>();
            listeFormation.Add(maFormationLongueDuree);
            listeFormation.Add(maFormationCourteDuree);
            listeFormation.Add(maFormationAvecStage);
            Console.WriteLine("\n"+"Voici les formations suivient par plus de 10 participants:");
            foreach (Formation i in listeFormation)
            {
                if (i.nombreDeParticipant > 10)
                {
                    Console.WriteLine(i.nom);
                }
            }
            Console.ReadKey();
        }
    }
}
