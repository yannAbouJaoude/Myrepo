using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nvausudoku
{
    class Sudoku
    {
        //Attribut
        private Cellule[,] grille;


        // Constructeur
        public Sudoku(int[,] grille) // qui crée une instance de la classe Sudoku à partir d’une matrice
        {
            this.grille = new Cellule[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.grille[i, j] = new Cellule(grille[i, j]);
                    this.grille[i, j].Valeur = grille[i, j];
                }
            }


        }

        public Sudoku(string fichier) // qui crée une instance à partir d’un fichier.csv
        {
            this.grille = new Cellule[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.grille[i, j] = new Cellule(0);
                }
            }

            StreamReader str = OpenFile(fichier);
            ReadFile(str);
        }

        // Méthode
        public string toString() // retourne une chaîne de caractères décrivant une grille
        {
            string str = "";
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    str += grille[i, j];
                }
                Console.WriteLine();
            }
            return str;
        }

        public void ecritureFichier(string fichier) // Ecrit le contenu de la grille résolue dans un fichier de sortie
        {
        }

        public bool lacaseestpleine(int i,int j)
        {
            bool casepleine = false;
           
                    if(grille[i,j].Valeur !=0)
                    { casepleine = true; }
              
            return casepleine;
        }

        public void valeurligne(int i)
        {

            for (int j = 0; j < grille.GetLength(1); j++)
            {
                if (grille[i, j].Valeur != 0)
                {
                    for (int k = 0; k < grille.GetLength(1); k++)// on retourne au début de la ligne
                    {
                        if (k != j) // on enlève dans la ligne la valeur possible de la grille [i,j] sauf pour la cellule[i,j]
                            grille[i, k].supprimeValeur(grille[i, j].Valeur);
                    }
                }
            }

        }

        public void valeurcolonne(int j)
        {


            for (int i = 0; i < grille.GetLength(0); i++)
            {
                if (grille[i, j].Valeur != 0)
                {
                    for (int k = 0; k < grille.GetLength(0); k++)
                    {
                        if (k != i)
                            grille[k, j].supprimeValeur(grille[i, j].Valeur);
                    }
                }
            }

        }

        public void valeurrégion(int k, int l)
        {
            if (grille[k, l].Valeur != 0)
            {
                int _i = k - (k % 3);  // on ballaye la grille à partir du début du bloc en (0,0) jusqu'en (3,3)
                int _j = l - (l % 3);
                for (int ibis = _i; ibis < _i + 3; ibis++)
                {
                    for (int jbis = _j; jbis < _j + 3; jbis++)
                    {
                        if (jbis != l && ibis != k) // on modifie dans le bloc la valeur possible de la grille [i,j] sauf pour la cellule[i,j]
                        {
                            grille[ibis, jbis].supprimeValeur(grille[k, l].Valeur);
                        }
                    }
                }
            }
        }

        public void MiseAjourCellule(int i, int j)// met à jour la cellule (ligne, colonne et la région)
        {
            valeurligne(i);
            valeurcolonne(j);
            valeurrégion(i, j);
        }

        public void MiseAjourInitial()
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    MiseAjourCellule(i, j);
                }
            }
        }// met à jour toutes les cellules

        public void Supprimevaleurlignesi2casesidentiques(int i)// Si 2 cases sont identiques (possède 2 valeurs identiques) sur la même ligne, on supprime ces 2 valeurs dans toutes les autress cases de la ligne
        {
            for (int k = 0; k < 9; k++) // on compare 2 à 2 toutes les cellules de la même ligne
            {
                for (int j = k+1; j < 9; j++)
                {
                    if (grille[i, k].egal2valeurs(grille[i,j]) == true) // 2 cellules sont identiques
                    {
                     for(int t=0;t<9;t++)
                        {
                            if( grille[i,k].Possible[t]==true) //On cherche les 2 valeurs à supprimer du reste de la ligne
                            {
                                for(int y=0; y<9;y++)
                                {
                                    if(y!=k && y!=j) //on supprime les 2 valeurs dans toutes les cellules de la ligne sauf pour les 2 cellules identiques 
                                    { grille[i, y].supprimeValeur(t); }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Supprimevaleurcolonnesi2casesidentiques(int j)// Même principe que pour la ligne, mais ici on s'occuppe des colonnes
        {
            for (int k = 0; k < 9; k++) // on compare 2 à 2 toute les cellules de la même colonne
            {
                for (int i = k + 1; i < 9; i++)
                {
                    if (grille[k, j].egal2valeurs(grille[i, j]) == true) // 2 cellules sont identiques
                    {
                        for (int t = 0; t < 9; t++)
                        {
                            if (grille[k, j].Possible[t] == true) //On cherche les 2 valeurs à supprimer du reste de la ligne
                            {
                                for (int y = 0; y < 9; y++)
                                {
                                    if (y != k && y != i)
                                    { grille[y, j].supprimeValeur(t); }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void MiseAjourinitialeSi2cellulesidentiques()
        {
           for(int i=0; i<9; i++ )
            {
                Supprimevaleurlignesi2casesidentiques(i);
                Supprimevaleurcolonnesi2casesidentiques(i);
            }
        }

        public void MiseAjourSi2cellulesidentiques(int i, int j)
        {
            Supprimevaleurlignesi2casesidentiques(i);
            Supprimevaleurcolonnesi2casesidentiques(j);
        }

        public void Jeu()
        {

            MiseAjourInitial();
            MiseAjourinitialeSi2cellulesidentiques();
            for (int k = 0; k < 9; k++)
            {
                for (int l = 0; l < 9; l++)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            while (lacaseestpleine(k, l) == false)// on veut que toute la grille soit composée d'éléments differents de 0, lorsque le premier élément est différent de 0, on passe au suivant.
                            {
                                if (lacaseestpleine(i, j) == false) // on essaye de trouver une valeur parmi les éléments nulles, puisque les éléments != 0 on les connait déjà
                                {
                                    if (this.grille[i, j].ATrouverUneValeur() != 0)// on vient de trouver une valeur
                                    {
                                        MiseAjourCellule(i, j);
                                        MiseAjourSi2cellulesidentiques(i, j);
                                        //Affichage();
                                        //Console.ReadKey();

                                    }
                                    if (i == 8 && j == 8)
                                    { i = 0; j = 0; }
                                }
                            }
                        }
                    }
                }
            }


        }

        public StreamReader OpenFile(string FileName)
        {
            StreamReader flux = null;
            try { flux = new StreamReader(FileName); }
            catch (FileNotFoundException e)
            { Console.WriteLine(e.Message); }
            return flux;
        }

        public void ReadFile(StreamReader str)
        {
            string line = "";
            try
            {
                int i = 0;
                while ((line = str.ReadLine()) != null)
                {                                                    // exemple de bloc: Dupont;1000;t 
                    string[] s = Regex.Split(line, ";");             // diviser la ligne lu en sous chaine de caractère dans différentes cases à chaque;
                    for (int j = 0; j < 9; j++)
                        grille[i, j].Valeur = Convert.ToInt32(s[j]);
                    i++;
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

        }

        public void Affichage()
        {
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                Console.Write(" : ");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(this.grille[i, j].Valeur);
                    Console.Write(" ");

                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write(": ");
                    }
                }
                Console.WriteLine();

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine(" -------------------------");
                }

            }
            Console.WriteLine();
        }


    }
}