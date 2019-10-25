using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD3_POO_annuaire
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            string prenom;
            string numero;
            Particulier tmp;
            List<Particulier> annuaire = new List<Particulier>();
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "Initialisation de l'annuaire","Insérer un nouveau téléphone","Identifier un numéro", "Sauvegarder l'annuaire","Retirer un numéro", "Fin du programme" };
            for (int i = 0; i < ListeExo.GetLength(0); i++)
            {
                if (i == positionMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(ListeExo[i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            while (resterDansLeMenu)
            {
                choix = Console.ReadKey().Key;
                Console.Clear();

                if (choix == ConsoleKey.UpArrow && positionMenu > 0) { positionMenu--; }
                if (choix == ConsoleKey.DownArrow && positionMenu < ListeExo.GetLength(0) - 1) { positionMenu++; }
                if (choix == ConsoleKey.Enter)
                {
                    switch (positionMenu) ////////////////Les instructions par exercices
                    {
                        case 0:
                            string[] lines = File.ReadAllLines("annuaire.txt");
                            for (int i = 0; i < lines.Length; i++)
                            {
                                numero = "";
                                prenom = "";
                                for (int j = 0; j < 10; j++)
                                {
                                    numero +=lines[i][j];
                                }                               
                                for(int k=11;k<lines[i].Length;k++)
                                {
                                    prenom+= lines[i][k];
                                }
                                 tmp = new Particulier(numero, prenom);
                                annuaire.Add(tmp);
                            }
                            tri_insertion(annuaire);
                            break;
                        case 1:
                            Console.WriteLine("Entrez le prenom");
                            prenom = Console.ReadLine();
                            Console.WriteLine("Entrez le numero");
                            numero = Console.ReadLine();
                            tmp = new Particulier(numero, prenom);
                            annuaire.Add(tmp);
                            tri_insertion(annuaire);
                            break;
                        case 2:
                            Console.WriteLine("Entrez le numero");
                            numero = Console.ReadLine();
                            Console.WriteLine("Propriétaire: "+rechercheDicho(annuaire, numero,0,annuaire.Count()-1));
                            break;
                        case 3:
                            Console.WriteLine("Voici l'annuaire sauvegardé:");
                            string ecriture="";
                            for (int i = 0; i < annuaire.Count(); i++)
                            {
                                ecriture += annuaire[i].GetNumero() + " " + annuaire[i].GetPrenom() + "\n";
                            }
                            Console.WriteLine(ecriture);
                            System.IO.File.WriteAllText("annuaireSortie.txt", ecriture);
                            break;
                        case 4:
                            Console.WriteLine("Entrez le prenom");
                            prenom = Console.ReadLine();
                            bool trouve= false;
                            for (int i = 0; i < annuaire.Count(); i++)
                            {
                                if (annuaire[i].GetPrenom() == prenom)
                                {
                                    trouve = true;
                                    annuaire.RemoveAt(i);
                                }
                            }
                            if (trouve)
                            {
                                Console.WriteLine(" element supprimé.");
                            }
                            else
                            {
                                Console.WriteLine("element non trouvé.");
                            }
                            break;
                        case 5:
                            resterDansLeMenu = false;
                            Console.WriteLine("Au revoir");
                            break;
                        default:
                            Console.WriteLine("L'exercice n'est pas fait.");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                for (int i = 0; i < ListeExo.GetLength(0); i++)
                {
                    if (i == positionMenu)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(ListeExo[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        static void tri_insertion(List<Particulier> annuaire)
        {
            int i, j;
            for (i = 1; i < annuaire.Count(); i++)
            {
                Particulier elem = annuaire[i];
                for (j = i; j > 0 && double.Parse(annuaire[j - 1].GetNumero()) > double.Parse(elem.GetNumero()); j--)
                {
                    annuaire[j] = annuaire[j - 1];
                }
                annuaire[j] = elem;
            }             
        }
        static string rechercheDicho(List<Particulier>annuaire, string numero, int min, int max)
        {
            if (annuaire[(min+max)/2].GetNumero() == numero)
            {
                return annuaire[(min + max) / 2].GetPrenom();
            }
            else if (min==max)
            {
                return "Personne";
            }
            else if(double.Parse(annuaire[(min + max) / 2].GetNumero())> double.Parse(numero))
            {
                return rechercheDicho(annuaire, numero, (min + max) / 2, min);
            }
            else 
            {
                return rechercheDicho(annuaire, numero, (min + max) / 2, max);
            }
        }
    }
}
