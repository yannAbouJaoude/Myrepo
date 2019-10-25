using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nvausudoku
{
    class Cellule
    {
        //Attributs
        private bool[] possible = new bool[9];
        private int valeur;

        // constructeur
        public Cellule(int valeur)
        {
            if (valeur == 0)
            {
                for (int i = 0; i < possible.Length; i++)
                { possible[i] = true; }
            }
            else { initialise(); }
            this.valeur = valeur;
        }
        // getteur
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public bool [] Possible
        {
            get { return possible; }
            set { possible = value; }
        }

        //Méthode
        public string toString()
        {
            string str = "";
            str = "La cellule comporte la valeur: " + valeur;
            str += "\n";
            for (int i = 0; i < possible.Length; i++)
            {
                str += possible[i] + " ";
            }
            str += "\n";
            for (int i = 0; i < possible.Length; i++)
            {
                str += (i + 1) + " ";
            }
            return str;
        }

        public void supprimeValeur(int valeur)// qui retire une valeur du champ des possibles(ou impossibles)
        {
            possible[valeur - 1] = false;
        }

        public void ajouteValeur(int valeur)// qui ajoute une valeur au champ des possibles(ou impossibles)
        {
            possible[valeur - 1] = true;
        }

        public void initialise()// qui initialise/ou réinitialise le champ des possibles(ou impossibles)
        {
            if (valeur != 0)
            {
                for (int i = 0; i < possible.Length; i++)
                { possible[i] = false; }
                possible[valeur - 1] = true;
            }
        }

        public bool egal2valeurs(Cellule C)// 2 Cellules ont les memes possibilités de valeurs
        {
            bool retour = false;
            int compteur = 0;
            int compteur1 = 0;
            for (int i = 0; i < 9; i++)
            {
                if (possible[i] == true)// Seulement 2 possibilités dans la cellule
                { compteur++; }

                if (possible[i] = C.possible[i])// les 2 cellules sont-elles identiques?
                { compteur1++; }

            }           
            if (compteur==2 && compteur1==9)// Si 
            { retour = true; }
           
            return retour;
        }

        public int ATrouverUneValeur()
        {     
            int Val = 0;
            int compteur = 0;
            for (int i = 0; i < possible.Length; i++)
            {
                if (possible[i] == true)// valeur possible
                {
                    Val = i;
                    compteur++;
                }
            }
            if (compteur == 1)// toutes les valeurs sont impossibles sauf une
            { Valeur = Val + 1; }
            return Valeur;
        }

        

    }
}
