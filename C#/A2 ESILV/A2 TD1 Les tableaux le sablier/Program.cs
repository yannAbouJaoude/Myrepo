

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resterDansLeMenu= true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            int dimension;
            char symbole;
            char direction;
            int hauteur;
            string chaine;
            string mot;
            string phrase;
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "DessineMoiUneLigne(dimension)", "DessineMoiUneMatrice(symbole, dimension)", "DessineMoiUneDiagonal(symbole, dimension, direction)", "sablier(hauteur)", "matrice(dimension)","Inverse la chaine", "NombreDeMot(mot, phrase)", "Quitter" };
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
                if(choix == ConsoleKey.Enter)
                {
                    switch (positionMenu) ////////////////Les instructions par exercices
                    {
                        case 0:
                            Console.WriteLine("Dimension");
                            dimension = int.Parse(Console.ReadLine());
                            DessineMoiUneLigne(dimension);
                            break;
                        case 1:
                            Console.WriteLine("dimension");
                            dimension = int.Parse(Console.ReadLine());
                            Console.WriteLine("symbole");
                            symbole = char.Parse(Console.ReadLine());
                            DessineMoiUneMatrice(symbole, dimension);
                            break;
                        case 2:
                            Console.WriteLine("dimension");
                            dimension = int.Parse(Console.ReadLine());
                            Console.WriteLine("symbole");
                            symbole = char.Parse(Console.ReadLine());
                            Console.WriteLine("direction M ou D");
                            direction = char.Parse(Console.ReadLine());
                            DessineMoiUneDiagonal(symbole, dimension, direction);
                            break;
                        case 3:
                            Console.WriteLine("hauteur");
                            hauteur = int.Parse(Console.ReadLine());
                            sablier(hauteur);
                            break;
                        case 4:
                            Console.WriteLine("Dimension");
                            dimension = int.Parse(Console.ReadLine());
                            matrice(dimension);
                            break;
                        case 5:
                            Console.WriteLine("chaine de caractere");
                            chaine = Console.ReadLine();
                            Console.WriteLine(inverse( chaine));
                            break;
                        case 6:
                            Console.WriteLine("mot");
                            mot = Console.ReadLine();
                            Console.WriteLine("phrase");
                            phrase = Console.ReadLine();
                            Console.WriteLine(NombreDeMot(mot, phrase));
                            break;
                        case 7:
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
                    if(i== positionMenu)
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

        static void DessineMoiUneLigne(int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                Console.Write("X");
            }
        }
        static void DessineMoiUneMatrice(char symbole, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(symbole);
                }
                Console.WriteLine();
            }
        }
        static void DessineMoiUneDiagonal(char symbole, int dimension,char direction)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (direction == 'D')
                    {
                        if (i == j)
                        {
                            Console.Write(1);
                        }
                        else
                        {
                            Console.Write(symbole);
                        }
                    }
                    else if (direction == 'M')
                    {
                         if (i ==dimension-j-1)
                         {
                             Console.Write(1);
                         }
                         else
                         {
                             Console.Write(symbole);
                         }  
                    }
                }
                Console.WriteLine();
            }
        }
        static void sablier(int hauteur)
        {
            for (int i = 0; i < hauteur; i++)
            {
                
                for (int j = 0; j <= hauteur; j++)
                {
                    if (i <=hauteur/ 2)
                    {
                        if (j >= i && hauteur - i > j)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    if (i > hauteur / 2)
                    {
                        if (i >= j && i >= hauteur - j-1)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                }
                Console.WriteLine();         
            }
        }
        static void matrice(int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(i * j +"  ");
                }
                Console.WriteLine();
            }
        }
        static string inverse(string chaine)
        {
            string retour="";

            for (int i = 0; i < chaine.Length; i++)
            {
                retour += chaine[chaine.Length -i- 1];
            }
            return retour;
        }
        static int NombreDeMot(string mot, string phrase)
        {
            int resultat = 0;
            int compteur = 0;
            phrase += " ";
            mot += " ";
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == mot[compteur])
                {
                    compteur++;
                    if (compteur == mot.Length)
                    {
                        resultat++;
                        compteur = 0;
                    }                                   
                }
                else
                {
                    compteur = 0;
                }
            }
            return resultat; ;
        } 
    }
}
