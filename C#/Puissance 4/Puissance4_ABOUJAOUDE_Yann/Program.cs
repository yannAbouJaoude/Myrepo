using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puissance4_GUI;

namespace Puissance4_ABOUJAOUDE_Yann
{
    class Program
    {
        [System.STAThreadAttribute()]
        static void Main(string[] args)
        {           
            int tourJoueur = 1;
            int fin = -1;
            int choix;
            int positionDispoVetical = 0;
            int jeton = 42;
            int tailleX = 6;
            int tailleY = 7;
            int[,] plateauJeu = new int[tailleX, tailleY];
            Fenetre gui= new Fenetre(plateauJeu);
            gui.changerMessage("Exercice réalisé par ABOU JAOUDÉ Yann ESILV A1 GH en 2017");
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    plateauJeu[x, y] = 0;
                }
            }
            while (fin == -1 && jeton >0) // tant que personne ne gagne et qu'il reste des jetons la partie continue 
            {
                choix = -1;
                while (choix > tailleY-1 || choix < 0)                    // tant qu'un joueur n'entre pas de position valide, on continue à lui demander ou joueur
                {
                    choix = int.Parse(Console.ReadLine())-1;              //le tableau commence a 0 et non a 1 comme le perçoit le joueur
                    if (choix <= tailleY-1 && choix >= 0)
                    {
                        positionDispoVetical = tailleX-1;                 // positionDispoVetical correspond a la position verticale du point durant sa chute.
                                                                          // la colonne est pleine si positionDispoVetical est nul
                                                                          // positionDispoVetical fini décrémentation sur la position ou sera joué le pion
                        while (plateauJeu[positionDispoVetical, choix] != 0 && positionDispoVetical != 0)
                        {
                            positionDispoVetical = positionDispoVetical - 1;
                        }
                        if (positionDispoVetical == 0 && plateauJeu[positionDispoVetical, choix] != 0)
                        {
                            choix = -1;
                        }
                    }
                }
                plateauJeu[positionDispoVetical, choix] = tourJoueur; 
                gui.rafraichirGrille();
                if (tourJoueur == 1) { tourJoueur = 2; }                   
                else { tourJoueur = 1; }
                gui.changerMessage("C'est au tour du joueur : " + tourJoueur);
                supprimerLigne(plateauJeu, tailleX, tailleY);                // supprime la ligne du bas si elle est pleine
                fin = Victoire(plateauJeu, tailleX, tailleY, positionDispoVetical, choix);              // vérifie la victoire éventuel d'un joueur
                jeton--;
            }
            if (fin == -1)
            {
                gui.changerMessage("“L'égalité devant la mort est une fiction de la morale que démentent les usages de la société ; mais l'égalité au puissance 4 n'est que justice.”");
            }
            else
            {
                gui.changerMessage("Le joueur " + fin + " a gagner");
            }
            Console.ReadKey();       
        }
        static void supprimerLigne(int[,]plateauJeu, int tailleX, int tailleY)   // supprime la ligne du bas si elle est pleine 
        {
            while (plateauJeu[tailleX - 1, 0]!=0&& plateauJeu[tailleX-1, 1] != 0 && plateauJeu[tailleX - 1, 2] != 0 && plateauJeu[tailleX - 1, 3] != 0 && plateauJeu[tailleX - 1, 4] != 0 && plateauJeu[tailleX - 1, 5] != 0 && plateauJeu[tailleX - 1, 6] != 0 )
            {
                for (int x = tailleX - 1; x > 0; x--)
                {
                    for (int y = tailleY - 1; y >= 0; y=y-1)
                    {
                        plateauJeu[x, y] = plateauJeu[x-1 , y];                     
                    }
                }
                for (int y = tailleY - 1; y >= 0; y = y - 1)
                {
                    plateauJeu[0, y] = 0;
                }
            }
        }   
        static int Victoire(int[,] plateauJeu, int tailleX, int tailleY,int i,  int j) // Défini l'emplacement des 2 carrés potentiellement vainqueur
        {                                                                           // retourne "fin" (-1 si iln'y a pas de victoire, 1 si le joueur 1 gagne, 2 si le joueur 2 gagne)
            int fin = -1;                                                           // appel la fonction de vérification
            if (i+1<tailleX && j + 1 < tailleY)                                     
            {
                fin = ConditionDeVictoireVerifie(plateauJeu, i, j);
            }
            if (i + 1 < tailleX && j >0&&fin == -1)
            {
                fin = ConditionDeVictoireVerifie(plateauJeu, i, j-1);
            }
            return fin;
        }
        static int ConditionDeVictoireVerifie(int[,] plateauJeu, int i, int j) //Vérifie si 4 case apartienne au meme joueur et renvoie ce joueur
        {                                                                      // iet j sont les coordonné du coin supérieur gauche////
            int quigagne = -1;                                   //-1 personne, 1 joueur 1, 2 joueur 2
            if (plateauJeu[i, j] == plateauJeu[i + 1, j] && plateauJeu[i, j] == plateauJeu[i, j + 1] && plateauJeu[i, j] == plateauJeu[i + 1, j + 1] && plateauJeu[i, j] != 0)
                {
                    quigagne = plateauJeu[i, j];   
            }
            return quigagne;
        }
    }
}