using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            int taille;
            int[] tableau;
            int valeur;
            int indice;
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "Trie Bulle à double sens", "Tri Sélection", "Tri par Insertion", "Recherche d’une valeur dans un tableau trié", "Tri personnalisé",  "Quitter" };
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
                            Console.WriteLine("Quel est la taille du tableau?");
                            taille = DemanderInt();
                            tableau = new int[taille];
                            Console.WriteLine("Voici le tableau généré aléatoirement");
                            tableau = remplirTableauAleatoirement(tableau, 0, 100);
                            afficherTableau(tableau);
                            Console.WriteLine("Voici le tableau trié par le trie bulle à double sens:");
                            trieBulle(tableau);
                            afficherTableau(tableau);

                            break;
                        case 1:
                            Console.WriteLine("Quel est la taille du tableau?");
                            taille = DemanderInt();
                            tableau = new int[taille];
                            Console.WriteLine("Voici le tableau généré aléatoirement");
                            tableau = remplirTableauAleatoirement(tableau, 0, 100);
                            afficherTableau(tableau);
                            Console.WriteLine("Voici le tableau trié par séléction:");
                            trieSelection(tableau);
                            afficherTableau(tableau);
                            break;
                        case 2:
                            Console.WriteLine("Quel est la taille du tableau?");
                            taille = DemanderInt();
                            tableau = new int[taille];
                            Console.WriteLine("Voici le tableau généré aléatoirement");
                            tableau = remplirTableauAleatoirement(tableau, 0, 100);
                            afficherTableau(tableau);
                            Console.WriteLine("Voici le tableau trié par insertion:");
                            trieInsertion(tableau);
                            afficherTableau(tableau);
                            break;
                        case 3:
                            Console.WriteLine("Quel est la taille du tableau?");
                            taille = DemanderInt();
                            tableau = new int[taille];
                            Console.WriteLine("Voici le tableau généré aléatoirement");
                            tableau = remplirTableauAleatoirement(tableau, 0, 100);
                            afficherTableau(tableau);
                            Console.WriteLine("Voici le tableau trié par le trie bulle à double sens:");
                            trieBulle(tableau);
                            afficherTableau(tableau);
                            Console.WriteLine("Quel valeur souhaitez vous rechercher");
                            valeur = DemanderInt();
                            indice = rechercheDichotomique(tableau, valeur);
                            Console.WriteLine("Nous avons trouver votre valeur à la position " + indice+" du tableau");
                            break;
                        case 4:
                            Console.WriteLine("Quel est la taille du tableau?");
                            taille = DemanderInt();
                            tableau = new int[taille];
                            Console.WriteLine("Voici le tableau généré aléatoirement");
                            tableau = remplirTableauAleatoirement(tableau, 0, 100000);
                         //   afficherTableau(tableau);
                            Console.WriteLine("Voici le tableau trié mon trie par tas:");
                            DateTime exeStart = DateTime.Now;
                            trieTas(tableau);
                            TimeSpan exeDuration = DateTime.Now.Subtract(exeStart);                           
                          //  afficherTableau(tableau);
                            Console.WriteLine("Le trie à été effectué en "+ exeDuration.Hours + " heures " + exeDuration.Minutes + " minutes "+ exeDuration.Seconds + " secondes " + exeDuration.Milliseconds+" millisecondes");
                            break;
                        case 5:
                            resterDansLeMenu = false;
                            Console.WriteLine("A bientôt!");
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

        static int[] remplirTableauAleatoirement(int[]tableau, int min, int max)
        {
            Random rnd = new Random(System.DateTime.Now.Millisecond);
            for (int i = 0; i < tableau.Length; i++)
            {              
                    tableau[i] = rnd.Next(min, max);                
            }
            return tableau;
        }
        static int DemanderInt()
        {
            int a;
            string entre = "a";
            while (int.TryParse(entre, out a) == false)
            {
                entre = Console.ReadLine();
            }
            a = int.Parse(entre);
            return a;
        }
        static void afficherTableau(int[]tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
            {               
                    Console.Write(tableau[i] + "\t");              
            }
            Console.WriteLine();
        }

        static void trieBulle(int[]tableau)
        {
            int permutter;
            bool continuer = true;
            while (continuer)
            {
                continuer = false;
                for (int i = 0; i < tableau.Length-1; i++)
                {
                    if (tableau[i] > tableau[i + 1])
                    {
                        continuer = true;
                        permutter = tableau[i];
                        tableau[i] = tableau[i + 1];
                        tableau[i + 1] = permutter;
                    }
                }
                for (int i = tableau.Length - 2; i >= 0; i=i-1)
                {
                    if (tableau[i] > tableau[i+1])
                    {
                        continuer = true;
                        permutter = tableau[i];
                        tableau[i] = tableau[i + 1];
                        tableau[i + 1] = permutter;
                    }
                }
            }



        }
        static void trieSelection(int[] tableau)
        {
            int echange;
            for (int i = 0; i<tableau.Length-1; i++)
            {
                int minimum = i;
                for (int j = i + 1; j < tableau.Length; j++)
                {
                    if (tableau[j] < tableau[minimum])
                    {
                        minimum = j;
                    }
                }
                echange = tableau[minimum];
                tableau[minimum] = tableau[i];
                tableau[i] = echange;
            }
        }
        static void trieInsertion(int[] tableau)
        {
            int j;
            int echange;
            for (int i = 1; i < tableau.Length; i++)
            {
                j = i;
                while(j>0&& tableau[j]<tableau[j-1])
                {
                    echange = tableau[j];
                    tableau[j] = tableau[j - 1];
                    tableau[j - 1] = echange;
                    j--;
                }              
            }
        }
        static int rechercheDichotomique(int[] tableau, int valeur)
        {
            int indice = (tableau.Length / 2);
            int stop= tableau.Length;
            while (valeur != tableau[indice] && stop != 0)
            {
                if (valeur < tableau[indice])
                {
                    indice = (indice / 2);
                }
                else
                {
                    indice = indice + (indice / 2);
                }
                stop = stop / 2;     //au bout de 2ln(taille) essais, si rien a été trouvé, stop et retour -1          
            }
            if (stop == 0)
            {
                indice = -1;
            }
            return indice;
        }

        static void trieTas(int[] tableau)
        {
            int tailleTas = tableau.Length;
            for (int p = (tailleTas - 1) / 2; p >= 0; --p)
                faireUnTas(tableau, tailleTas, p);

            for (int i = tableau.Length - 1; i > 0; --i)
            {
                int echange = tableau[i];
                tableau[i] = tableau[0];
                tableau[0] = echange;

                --tailleTas;
                faireUnTas(tableau, tailleTas, 0);
            }
        }
        static void faireUnTas(int[] tableau, int tailleTas, int index)
        {
            int gauche = (index + 1) * 2 - 1;
            int droite = (index + 1) * 2;
            int largest = 0;
            if (gauche < tailleTas && tableau[gauche] > tableau[index])
            {
                largest = gauche;
            }
            else
            {
                largest = index;
            }
            if (droite < tailleTas && tableau[droite] > tableau[largest])
            {
                largest = droite;
            }
            if (largest != index)
            {
                int echange = tableau[index];
                tableau[index] = tableau[largest];
                tableau[largest] = echange;
                faireUnTas(tableau, tailleTas, largest);
            }
        }
    }
}
