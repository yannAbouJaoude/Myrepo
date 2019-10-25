using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projet_A2_S1_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            int[,] grille = new int[9, 9] {
                      {2,0,0,0,9,0,3,0,0},
                      {0,1,9,0,8,0,0,7,4},
                      {0,0,8,4,0,0,6,2,0},
                      {5,9,0,6,2,1,0,0,0},
                      {0,2,7,0,0,0,1,6,0},
                      {0,0,0,5,7,4,0,9,3},
                      {0,8,5,0,0,9,7,0,0},
                      {9,3,0,0,5,0,8,4,0},
                      {0,0,2,0,6,0,0,0,1}};
            Sudoku monSudoku;
            int[,] grilleEnRecursif;
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "Les petites démonstrations autour du nombre 45", "Résoudre le sudoku du programme de maniere itérative ", "Résoudre le sudoku du fichier .csv de maniere itérative", "Résoudre le sudoku du programme de maniere récursive", "Résoudre le sudoku du fichier .csv de maniere récursive", "Quitter" };
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
                            demonstration();
                            break;
                        case 1:
                            monSudoku = new Sudoku(grille);
                            Console.WriteLine("Voici le sudoku du programme\n");
                            Console.WriteLine(monSudoku.toString());
                            Console.WriteLine("Le sudoku a été résolu de maniere itérative \nLa méthode 3) est très rarement utilisée,\nafin de prouver son fonctionnement, nous affichons un message a chaque fois qu'elle est utile \n");
                            resolutionIterative(monSudoku);
                            Console.WriteLine(monSudoku.toString());
                            break;
                        case 2:
                            monSudoku = new Sudoku("grille.csv");
                            Console.WriteLine("Voici le sudoku du fichier\n");
                            Console.WriteLine(monSudoku.toString());
                            Console.WriteLine("Le sudoku a été résolu de maniere itérative \nLa méthode 3) est très rarement utilisée,\nafin de prouver son fonctionnement, nous affichons un message a chaque fois qu'elle est utile \n");
                            resolutionIterative(monSudoku);
                            Console.WriteLine(monSudoku.toString());
                            break;
                        case 3:
                            grilleEnRecursif = new int[9, 9];
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    grilleEnRecursif[i, j] = grille[i, j];
                                }
                            }
                            Console.WriteLine("Voici le sudoku du programme\n");
                            afficherUneGrille(grilleEnRecursif);
                            Console.WriteLine("\nLe sudoku a été résolu de maniere récursive \n");
                            resolutionRecursive(0, grilleEnRecursif);
                            afficherUneGrille(grilleEnRecursif);
                            break;
                        case 4:
                            grilleEnRecursif = Sudoku.lireUnSudoku("grille.csv");                          
                            Console.WriteLine("Voici le sudoku du fichier\n");
                            afficherUneGrille(grilleEnRecursif);
                            Console.WriteLine("\nLe sudoku a été résolu de maniere récursive \n");
                            resolutionRecursive(0, grilleEnRecursif);
                            afficherUneGrille(grilleEnRecursif);
                            break;
                        case 5:
                            resterDansLeMenu = false;
                            Console.WriteLine("A bientôt!");
                            break;                      
                        default:
                            Console.WriteLine("Cette position du menu n'a pas encore été assignée");
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
        static void demonstration()
        {
            int somme = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;
            int[,] grilleFausse = new int[9, 9] {
                      {9,6,0,9,6,0,9,6,0},
                      {0,9,6,0,9,6,0,9,6},
                      {6,0,9,6,0,9,6,0,9},
                      {9,6,0,9,6,0,9,6,0},
                      {0,9,6,0,9,6,0,9,6},
                      {6,0,9,6,0,9,6,0,9},
                      {9,6,0,9,6,0,9,6,0},
                      {0,9,6,0,9,6,0,9,6},
                      {6,0,9,6,0,9,6,0,9}
                      };
            Console.WriteLine("Démontrons que lorsqu'un sudoku est complet et correcte, la somme des valeurs des cases de chacune des lignes, colonnes ou régions est égale à 45");
            Console.WriteLine("Le sudoku est complet et correcte, donc chacune des lignes, colonnes et régions sont correctes");
            Console.WriteLine("Soit un espace alpha une ligne, une région ou une colonne d'un sudoku correcte");
            Console.WriteLine("Alpha est correcte, donc il possede 9 cases et chacuns des numéros de 1 à 9 précisément une fois");
            Console.WriteLine("1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = " + somme);
            Console.WriteLine("Donc la somme des cases de alpha est 45");
            Console.WriteLine("alpha est une ligne, colonne ou région quelquonque , donc si une grille de Sudoku est complète, \nalors pour chacune des lignes, chacune des colonnes et chacune des régions de taille 3×3, la somme des chiffres fait 45.\n\n");
            Console.WriteLine("Démontrons la réciproque: Si la somme de toutes cases de lignes, colonnes ou régions quelquonque est égale a 45 alors le sudoku est complet ");
            Console.WriteLine("voici un contre exemple");
            afficherUneGrille(grilleFausse);
            Console.WriteLine("Cette grille est fausse et incomplete, mais la somme de la valeur des cases chacune de ses lignes régions et colonnes est égale à 45");
            Console.WriteLine("Donc la réciproque est fausse");
        }
        
        static void afficherUneGrille(int[,]tab)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(tab[i, j] + " | ");
                }
                Console.WriteLine();
            }
        }
        static bool resolutionRecursive(int pos,int[,]tab)
        {
            int i = pos / 9;
            int j = pos % 9;
            if (i == 9)
                return true;
            if (tab[i, j] != 0)
                return resolutionRecursive(pos + 1,tab);
            for (int k = 1; k <= 9; k++)
            {
                if (chiffreEstOkay(k, i, j, tab) == true)
                {
                    tab[i, j] = k;
                    if (resolutionRecursive(pos + 1,tab))
                        return true;
                }
            }
            tab[i, j] = 0;
            return false;
        }
        static void resolutionIterative(Sudoku monSudoku)
        {
            int complet = 0;
            while (complet <= 81) {
                MethodeUneSeuleValeurPossible(monSudoku);
                MethodeUneSeulePositionPossible(monSudoku);
                MethodeComparerToutesLesValeursPossibles(monSudoku);
                complet++;
            }
        }
        static void MethodeUneSeuleValeurPossible(Sudoku monSudoku)
        {
           
            for (int ligne = 0; ligne < 9; ligne++)
            {
                for (int colonne = 0; colonne < 9; colonne++)
                {
                    if (monSudoku.tableauCellule[ligne, colonne].ValeurCase == 0)
                    {
                        int nombreDeValeursPossible = 0;
                        int seuleValeurPossible = 0;
                        for (int valeur = 0; valeur < 9; valeur++)
                        {
                            if(monSudoku.tableauCellule[ligne, colonne].possible[valeur])
                            {
                                nombreDeValeursPossible++;
                                seuleValeurPossible = valeur+1;
                            }
                        }
                        if (nombreDeValeursPossible == 1)
                        {
                            monSudoku.tableauCellule[ligne, colonne].ChangerLaValeurdeLaCase(seuleValeurPossible) ;
                            monSudoku.RetirerDesValeursPossibleApresUnPlacement(ligne, colonne, seuleValeurPossible-1);

                        }
                        else if(nombreDeValeursPossible == 0)
                        {
                            Console.WriteLine("Le sudoku n'a pas de solution"); //a changer 
                        }
                    }
                }
            }
        }               //correspond au 1)
        static void MethodeUneSeulePositionPossible(Sudoku monSudoku)
        {
            int compteur;
            int seuleLignePossible;
            int seuleColonnePossible;
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                compteur = 0;
                seuleColonnePossible = 0;
                seuleLignePossible = 0;
                for (int colonne = 0; colonne < 9; colonne++)
                {
                    compteur = 0;
                    seuleColonnePossible = 0;
                    seuleLignePossible = 0;
                    for (int ligne = 0; ligne < 9; ligne++)
                    {
                        if (monSudoku.tableauCellule[ligne, colonne].ValeurCase== valeur)
                        {
                            compteur++;
                            seuleLignePossible = ligne;
                            seuleColonnePossible = colonne;
                        }
                    }
                    if (compteur == 1)
                    {
                        monSudoku.tableauCellule[seuleLignePossible, seuleColonnePossible].ChangerLaValeurdeLaCase(valeur);
                        monSudoku.RetirerDesValeursPossibleApresUnPlacement(seuleLignePossible, seuleColonnePossible, valeur-1);
                        
                    }
                }

                compteur = 0;
                seuleColonnePossible = 0;
                seuleLignePossible = 0;
                for (int ligne = 0; ligne < 9; ligne++)
                {
                    compteur = 0;
                    seuleColonnePossible = 0;
                    seuleLignePossible = 0;
                    for (int colonne = 0; colonne < 9; colonne++)
                    {
                        if (monSudoku.tableauCellule[ligne, colonne].ValeurCase == valeur)
                        {
                            compteur++;
                            seuleLignePossible = ligne;
                            seuleColonnePossible = colonne;
                        }
                    }
                    if (compteur == 1)
                    {
                        monSudoku.tableauCellule[seuleLignePossible, seuleColonnePossible].ChangerLaValeurdeLaCase(valeur);
                        monSudoku.RetirerDesValeursPossibleApresUnPlacement(seuleLignePossible, seuleColonnePossible, valeur-1);

                    }
                }
                compteur = 0;
                seuleColonnePossible = 0;
                seuleLignePossible = 0;

                for (int i = 0; i < 9; i = i + 3)
                {
                    for (int j = 0; j < 9; j = j + 3)
                    {
                        compteur = 0;
                        seuleColonnePossible = 0;
                        seuleLignePossible = 0;
                        int ligne = i - (i % 3),colonne = j - (j % 3);
                        for (i = ligne; i < ligne + 3; i++)
                        {
                            for (j = colonne; j < colonne + 3; j++)
                            {
                                compteur++;
                                seuleLignePossible = ligne;
                                seuleColonnePossible = colonne;
                            }
                        }
                        if (compteur == 1)
                        {
                            monSudoku.tableauCellule[seuleLignePossible, seuleColonnePossible].ChangerLaValeurdeLaCase(valeur);
                            monSudoku.RetirerDesValeursPossibleApresUnPlacement(seuleLignePossible, seuleColonnePossible, valeur-1);
                        }
                    }
                }
            }
        }             //correspond au 2)
        static void MethodeComparerToutesLesValeursPossibles(Sudoku monSudoku)
        {
            for (int ligne = 0; ligne < 9; ligne++)
            {
                for (int colonne1 = 0; colonne1 < 8; colonne1++)
                {
                    for (int colonne2 = colonne1 + 1; colonne2 < 9; colonne2++)
                    {
                        if(monSudoku.tableauCellule[ligne,colonne1].egal(monSudoku.tableauCellule[ligne, colonne2]))
                            {
                            for (int colonne3 = 0; colonne3 < 9; colonne3++)
                            {
                                if(colonne3!=colonne1&& colonne3 != colonne1)
                                {
                                    int valeur = monSudoku.tableauCellule[ligne, colonne1].presqueEgal(monSudoku.tableauCellule[ligne, colonne3]);
                                    
                                    if (valeur!=0)
                                    {
                                        monSudoku.tableauCellule[ligne, colonne3].ChangerLaValeurdeLaCase(valeur);
                                        monSudoku.RetirerDesValeursPossibleApresUnPlacement(ligne, colonne3, valeur - 1);
                                        Console.WriteLine("Nous avons utilisé la 3eme méthode de résolution pour placer un " + valeur + " à la ligne "+  (ligne+1) + " colonne "+ (colonne3+1));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int colonne = 0; colonne < 9; colonne++)
            {
                for (int ligne1 = 0; ligne1 < 8; ligne1++)
                {
                    for (int ligne2 = ligne1 + 1; ligne2 < 9; ligne2++)
                    {
                        if (monSudoku.tableauCellule[ligne1, colonne].egal(monSudoku.tableauCellule[ligne2, colonne]))
                        {
                            for (int ligne3 = 0; ligne3 < 9; ligne3++)
                            {
                                if (ligne3 != ligne1 && ligne3 != ligne1)
                                {
                                    int valeur = monSudoku.tableauCellule[ligne1, colonne].presqueEgal(monSudoku.tableauCellule[ligne3, colonne]);

                                    if (valeur != 0)
                                    {
                                        monSudoku.tableauCellule[ligne3, colonne].ChangerLaValeurdeLaCase(valeur);
                                        monSudoku.RetirerDesValeursPossibleApresUnPlacement(ligne3, colonne, valeur - 1);
                                        Console.WriteLine("Nous avons utilisé la 3eme méthode de résolution pour placer un " + valeur + " à la ligne " +  (ligne3+1)  + " colonne " + (colonne+1));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }    //correspond au 3)
        private static bool ValeurImpossibleDansUneRegionSaufDansUneLigne(int i, int j, int ligne,Sudoku monSudoku,int valeur)
        {
            for (int _i = i; _i < i + 3; _i++)
            {
                for (int _j = j; _j < j + 3; _j++)
                {
                    if (i != ligne)
                    {
                        if (monSudoku.tableauCellule[_i, _j].possible[valeur])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }   //est utiliser dans la méthode 3
        public static bool chiffreEstOkay(int valeurATester, int i, int j,int[,]grille)           //retourne true si il est possible de placer un chiffre valeurATester dansla position [i,j] d'une grille de sudoku donnée , false sinon
        {
            for (int colonne = 0; colonne < 9; colonne++)
                if (grille[i, colonne] == valeurATester)
                {
                    return false;
                }
            for (int ligne = 0; ligne < 9; ligne++)
            {
                if (grille[ligne, j] == valeurATester)
                {
                    return false;
                }
            }
            int _i = i - (i % 3), _j = j - (j % 3);
            for (i = _i; i < _i + 3; i++)
            {
                for (j = _j; j < _j + 3; j++)
                {
                    if (grille[i, j] == valeurATester)
                    {
                        return true;
                    }
                }
            }
            return true;
        }       
    }
}
