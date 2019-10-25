using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace projet_A2_S1_sudoku
{
    class Sudoku
    {   private Cellule[,] maGrille = new Cellule[9, 9];
    
        public Sudoku(int[,] grille)
        {
            for (int ligne = 0; ligne < 9; ligne++)
            {
                for (int colonne = 0; colonne < 9; colonne++)
                {
                    maGrille[ligne, colonne] = new Cellule(ligne, colonne, grille) ;
                    
                }
            }
        }
        public Cellule[,]tableauCellule
        {
            get { return maGrille; }
        }
        public static int[,] lireUnSudoku(string fichier)
        {
            int[,] grille = new int[9, 9];
            int caractere; try
            {
                StreamReader sr = new StreamReader(fichier);
                caractere = sr.Read() - 48;
                int i = 0;
                int j = 0;
                //Continue to read until you reach end of file
                while (caractere != -49)
                {
                    if (caractere != -38 && caractere != -35 && caractere != 11)
                    {
                        grille[j, i] = caractere;
                        i++;
                        if (i == 9)
                        {
                            i = 0;
                            j++;
                        }
                    }
                    caractere = sr.Read() - 48;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
            }
            return grille;
        }       //public afin d'etre egalement utiliser pour la méthode récursive
        public Sudoku(string fichier)
        {
            int[,] grille = lireUnSudoku(fichier);
            for (int ligne = 0; ligne < 9; ligne++)
            {
                for (int colonne = 0; colonne < 9; colonne++)
                {
                    maGrille[ligne, colonne] = new Cellule(ligne, colonne, grille);

                }
            }

        }
        public void RetirerDesValeursPossibleApresUnPlacement(int i,int j,int valeur)
        {
            for (int colonne = 0; colonne < 9; colonne++)
            {
                this.maGrille[i, colonne].supprimerValeur(valeur);
            }
                
            for (int ligne = 0; ligne < 9; ligne++)
            {
                this.maGrille[ligne, j].supprimerValeur(valeur);
            }
            int _i = i - (i % 3), _j = j - (j % 3);
            for (i = _i; i < _i + 3; i++)
            {
                for (j = _j; j < _j + 3; j++)
                {
                    this.maGrille[_i, _j].supprimerValeur(valeur);
                }
            }
            
        }
        public void ecritureFichier(string fichier)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fichier);
                sw.WriteLine(toString());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }       //jamais utilisée


        public string toString()
        {
            string retour = "";
            string Valeur;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Valeur = Convert.ToString(this.maGrille[i, j].ValeurCase);
                   retour = retour + Valeur + " | ";
                   }
                retour = retour + "\r\n";
            }
            return retour;
        }

    }
}
