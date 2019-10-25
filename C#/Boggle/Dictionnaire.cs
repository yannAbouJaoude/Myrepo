using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_2019
{
    class Dictionnaire
    {
        private string[] tab = new string[130600];
        private int[] changementDuNombreDeLettre = new int[16];
        private int nbDeMot;
        public Dictionnaire(string fichier)
        {
            for (int i = 0; i < 130600; i++)
            {
                tab[i] = "";
            }
            for (int i = 0; i < 16; i++)
            {
                changementDuNombreDeLettre[i] =0;
            }
            nbDeMot =0;
            int numeroDeLigne = 0;
            
            string text = System.IO.File.ReadAllText(fichier);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    numeroDeLigne++;
                    if (numeroDeLigne % 2==0)
                    {
                        changementDuNombreDeLettre[numeroDeLigne / 2 + 2] = nbDeMot;
                    }
                }
                else if(text[i] == ' ')
                {
                    nbDeMot++;
                }
                else
                {
                    tab[nbDeMot] += text[i];
                }
            }
        }
        public bool IsInDico(string mot)
        {
            int tmp = mot.Length;
            if (tmp < 15 && tmp>2) {
                
                return RechercheDico(changementDuNombreDeLettre[tmp], changementDuNombreDeLettre[tmp + 1], mot);
                }
            else if (tmp==15)
            {
                return RechercheDico(changementDuNombreDeLettre[tmp], nbDeMot, mot);
            }
            else
            {
                Console.WriteLine("Le mot entré doit faire entre 3 et 15 lettres, veuillez réessayer");
                return false;
            }
        }
        private bool RechercheDico(int min, int max, string mot)
        {
            if (tab[min] == mot|| tab[max] == mot|| tab[(min+max)/2] == mot)
            {
                return true;
            }
            else if(min >= max) {
             
            return false;
            }
            else if (ordreAlpha(tab[((min + max) / 2)], mot,0))
            {
                min = ((min + max) / 2+1);
                return RechercheDico(min, max, mot);
            }
            else
            {
                max = ((min + max) / 2);
                return RechercheDico(min, max, mot);
            }
            return false;
        }
        private bool ordreAlpha(string a, string b,int pos)
        {
            if (a[pos] < b[pos])
            {
                return true;
            }
            else if (a[pos] > b[pos])
            {
                return false;
            }
            else
            {
                return ordreAlpha(a, b, pos + 1);
            }
        }
        public string toString()
        {
            string retour = "Il y a "+(nbDeMot-14) + " mot dans ce dictionnaire \n";
            for (int i = 2; i < 15; i++)
            {
                retour += "Il y a " + (changementDuNombreDeLettre[i+1] - changementDuNombreDeLettre[i]-1)+ " mots de "+i+" lettres dans ce dictionnaire \n";
            }
            retour += "Il y a " + (nbDeMot -changementDuNombreDeLettre[15] - 14) + " de " + 15 + " lettres dans ce dictionnaire \n";
            return retour;
        }
    }
}
