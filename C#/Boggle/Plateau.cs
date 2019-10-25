using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_2019
{
    class Plateau
    {
        private Case[,]tab=new Case[4,4];
        public Plateau(string fichier)
        {
            Random r = new Random();
            lire(fichier, r);
        }
        public void Relance()
        {
            Random r = new Random();
            for (int i = 0; i < 16; i++)
            {               
                tab[i / 4, i % 4].lance(r);
            }
        }
        public string ToString()
        {
            string retour = "";
            for (int i = 0; i < 16; i++)
            {
                retour += "|";
                retour += tab[i / 4, i % 4].getVisible();
                if(i % 4 == 3)
                {
                    retour += "|\n";
                }
            }
            return retour;
        }
        public void lire(string fichier, Random r)
        {
            string s; try
            {
                StreamReader sr = new StreamReader(fichier);
                for (int i = 0; i < 16; i++)
                {
                    s = sr.ReadLine();
                    tab[i / 4, i % 4] = new Case(s, r);      
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
        }
        public bool Test_Plateau(string mot)
        {
            bool[,] passage = new bool[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    passage[i, j] = false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (recherche(i, j, mot, 1, passage)) {
                        return true;
                    }
                }
            }           
            return false;
        }
        private void initNewPassage(bool[,] a, bool[,] n, int x,int y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    n[i,j]=a[i,j];
                }
            }
            n[x, y] = true;
        }
        private bool recherche(int x, int y, string mot, int lettre, bool[,] passage)
        {
            if (x > 3 || x < 0 || y > 3 || y < 0||passage[x,y])
            {
                return false;
            }
            else if (mot[lettre-1]!=tab[x,y].getVisible())
            {
                return false;
            }
            else if(lettre==mot.Length)
            {
                return true;
            }
            else{
                bool[,] newPassage = new bool[4, 4];
                bool retour = false;
                initNewPassage(passage, newPassage,x,y);                
                if (recherche(x - 1, y, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage,x,y);
                if (recherche(x + 1, y, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage,x,y);
                if (recherche(x , y - 1, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage,x,y);
                if (recherche(x , y + 1, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage, x, y);
                if (recherche(x - 1, y - 1, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage, x, y);
                if (recherche(x + 1, y + 1, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage, x, y);
                if (recherche(x + 1, y - 1, mot, lettre + 1, newPassage)) { retour = true; }
                initNewPassage(passage, newPassage, x, y);
                if (recherche(x - 1, y + 1, mot, lettre + 1, newPassage)) { retour = true; }
                return retour;
            }
        }
    }
}
