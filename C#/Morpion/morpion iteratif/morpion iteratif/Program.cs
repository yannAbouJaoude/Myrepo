using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morpion_iteratif
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static int tour = 1;
        static int[] resolve()
        {
            int[] retour = new int[2];
            if (tour == 1)
            {
                retour[0]=0;
                retour[1] = 0;
            }
            if (tour == 2)
            {
                if (morpion[1, 1]==0)
                {
                    retour[0] = 1;
                    retour[1] = 1;
                }
                else
                {
                    retour[0] = 0;
                    retour[1] = 0;
                }
            }
            if (tour == 3)
            {
                if (morpion[1, 1] == 1)
                {
                    retour[0] = 2;
                    retour[1] = 2;
                }
                else
                {
                    jetonAligne()
                }
            }
            if (tour == 4)
            {
                // si on a une des 2 config spé jouer surle coté sinon jouer jeton aligne
            }
        }



        //colonne ligne
        static int[,] morpion = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };//0 vide //1 humain //2 mbot
        static void jetonAligne(int dimension,int numero) //dimension 0 = colonne; 1 = ligne //repere y inverse
        {
            int[] retourAligne = { 0, 0 };//pos 0 = humain, 1 =mbot
            for (int i = 0; i < 3; i++)
            {
                if (dimension==0)
                {
                    if (morpion[numero, i] == 1)
                    {
                        retourAligne[0]++;
                    }
                    if (morpion[numero, i] == 2)
                    {
                        retourAligne[1]++;
                    }
                }
                if (dimension == 1)
                {
                    if (morpion[i, numero] == 1)
                    {
                        retourAligne[0]++;
                    }
                    if (morpion[i, numero] == 2)
                    {
                        retourAligne[1]++;
                    }
                }
            }
            resolutionCommune(retourAligne, dimension,numero);
        }
        static int[] resolutionCommune(int[] retourAligne,int dimension, int numero)
        {
            if (retourAligne[0] == 3)
            {
                int[] lost = { -2 };
                return lost;
            }
            else if(retourAligne[1]==2 && retourAligne[0] == 0)
            {
                return retrouverLaCaseBlanche(dimension, numero);
                //on a gagner
            }
            else if(retourAligne[0] == 2 && retourAligne[1] == 0)
            {
                return retrouverLaCaseBlanche(dimension, numero);
            }
            else if(retourAligne[1] == 1 &&retourAligne[0] == 0){
                return retrouverLaCaseBlanche(dimension, numero);
            }
            else
            {
               
                int[] pasDeSolution = { -1 };
                return pasDeSolution;
                //egalité
            }
        }

      static int[]retrouverLaCaseBlanche(int dimension, int numero)// retrouve la case blanche, en prio le coin
        {
            int[] ordre = { 0, 2, 1 };
            for (int i = 0; i < 3; i++)
            {
                if (dimension == 0)
                {
                    if (morpion[numero, ordre[i]] == 0)
                    {
                        int[] retour = { numero, ordre[i] };
                        return retour;
                    }
                    
                }
                if (dimension == 1)
                {
                    if (morpion[ordre[i], numero] == 0)
                    {
                        int[] retour = { ordre[i], numero };
                        return retour;
                    }                  
                }
            }
            int[] tie = { -1 };
            return tie;
        }
    }
}
