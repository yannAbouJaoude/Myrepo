using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7_Tris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Je genere un tableau aléatoire");
            int[] tab = GenererTableauAleatoire(10, 0, 100);
            afficher(tab);
            Console.WriteLine('\n'+"Je tris le tableau");
            TriBulles(tab);
            afficher(tab);
            for (int i = 0; i < 999999999; i++)
            {


                Console.WriteLine('\n' + "Je mélange le tableau");
                shuffle(tab, 200);
                afficher(tab);
                Console.WriteLine('\n' + "Je tris le tableau");
                TriBulles(tab);
                afficher(tab);
            }      
            Console.ReadKey();
        }
        static void TriBulles(int[] tableau)
        {
            int permuter = -1;
            bool fin = false;
            for (int i = tableau.Length - 1; i >= (tableau.Length - 1)/2; i--)
            {
                fin = true;
                for (int j = tableau.Length - i -1; j < i; j++)
                {
                    if (tableau[j] > tableau[j + 1])
                    {
                        permuter = tableau[j];
                        tableau[j] = tableau[j + 1];
                        tableau[j + 1] = permuter;
                        fin = false;
                    }
                }
                for (int j = i; j > tableau.Length - i-1; j--)
                {
                    if (tableau[j-1] > tableau[j])
                    {
                        permuter = tableau[j-1];
                        tableau[j-1] = tableau[j ];
                        tableau[j ] = permuter;
                        fin = false;
                    }
                }
                if (fin)
                {
                    break;
                }
            }
        }
        static int[] GenererTableauAleatoire(int taille, int valeurMin, int valeurMax)
        {
            int[] resultat = new int[taille];
            Random alea = new Random();
            for (int i = 0; i < resultat.Length; i++)
            {
                resultat[i] = alea.Next(valeurMin, valeurMax + 1);
            }
            return resultat;
        }
        static void afficher(int[] tab)
        {
            if (tab != null)
            {
                if (tab.Length > 0)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        Console.Write(tab[i] + " ; ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Le tableau est vide!");
                }
            }
        }
        static void shuffle(int[] tab, int Melange) //nombre de permutations, augmenter -> + aleatoire 
        {
            Random alea = new Random();
            int Permutation = 0;
            int terme1 = 0;
            int terme2 = 0;
            for (int i = Melange; i > 0; i--)
            {
                terme1 = alea.Next(0, tab.Length);
                terme2 = alea.Next(0, tab.Length);
                Permutation = tab[terme1];
                tab[terme1]= tab[terme2];
                tab[terme2] = Permutation;
            }           
        }
    }
}
