using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_A2_S1_sudoku
{
    class Cellule
    {
        private int valeurDeLaCase;
        private int ligne;
        private int colonne;
        private bool[] valeurPossible = new bool[] { false,false,false, false, false, false, false, false, false};
        public Cellule(int ligne, int colonne,int[,]grille)
        {
            this.ligne = ligne;
            this.colonne = colonne;
            this.valeurDeLaCase = grille[ligne,colonne];
            if (this.valeurDeLaCase == 0)
            {
                initialise(grille);
            }
        }
        void ajouterValeur(int valeur){
            valeurPossible[valeur] = true;
        }                   // jamais utilisée
        public void supprimerValeur(int valeur)
        {
            valeurPossible[valeur] = false;
        }
        public void initialise(int[,] grille)
        {
            for (int i = 1; i <= 9; i++)
            {
                this.valeurPossible[i - 1] = Program.chiffreEstOkay(i, ligne, colonne, grille);
            }
        }
        public bool egal(Cellule c)
        {
            if (this.valeurDeLaCase != c.valeurDeLaCase)
            {
                return false;     
            }
            for (int valeur = 0; valeur < 9; valeur++)
            {
                if (this.valeurPossible[valeur] != c.valeurPossible[valeur])
                {
                    return false;
                }
            }
            return true;
        }
        public int ValeurCase
        {
            get { return valeurDeLaCase; }
        }
        public void ChangerLaValeurdeLaCase(int valeur)
        {         
            this.valeurDeLaCase = valeur;
        }
        public int presqueEgal(Cellule c) 
        {
            int compteur=0;
            int valeurC=0;
            int retour=1;
            if (this.valeurDeLaCase != c.valeurDeLaCase)
            {
                retour=0;
            }
            for (int valeur = 0; valeur < 9; valeur++)
            {
                if (this.valeurPossible[valeur] != c.valeurPossible[valeur])
                {
                    if (c.valeurPossible[valeur])
                    {
                        compteur++;
                        valeurC = valeur+1;
                    }
                    else
                    {
                        retour = 0;
                    }
                }
            }
            if (compteur == 1&&retour==1)
            {
                return valeurC ;
            }
            else
            {
                retour = 0;
            }
            
            return retour;
        }   // est utilisée pour Appeler une cellule possedant 2 valeurs possible precisement etrenvoie true si la cellule en parametre possede 3 valeurs possible précisement
        public bool[] possible
        {
            get { return valeurPossible; }
        }
    }
}
