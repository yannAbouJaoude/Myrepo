using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace sudoku
{
    class Cellule
    {
        private int valeur;
        private bool[] possible = new bool[9];

        public Cellule(int valeur)
        {
            this.valeur = valeur;
            MiseAJourPossibilite();
        }
        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
        public bool[] Possible
        {
            get { return possible; }
            set { possible = value; }
        }

        public void suprimeValeur(int V)
        {
            this.possible[V] = false;       // possible devient faux pour la valeur V
        }
        public void ajouteValeur(int V)
        {
            this.possible[V] = true;        // possible devient vrai pour la valeur V
        }
        public void initialiseToutPossible()
        {
            for (valeur = 0; valeur <= 8; valeur++)
            {
                this.possible[valeur] = true;       //toutes les valeurs de la cellule deviennent possibles
            }
        }
        public void initialiseToutImpossible()
        {
            for (valeur = 0; valeur <= 8; valeur++)
            {
                this.possible[valeur] = false;       //toutes les valeurs de la cellule deviennent possibles
            }
        }
        public void MiseAJourPossibilite()
        {
            if (this.Valeur != 0)
            {
                initialiseToutImpossible();
                ajouteValeur(Valeur-1);
            }
            else
            {
                initialiseToutPossible();
            }
        }
    }

    class Sudoku
    {
        public static bool egal(Cellule premiere, Cellule seconde)
        {
            for (int valeur = 0; valeur <= 8; valeur++)
            {
                if (premiere.Possible[valeur] != seconde.Possible[valeur])
                {
                    return false;                   //retourne faux si les classes sont différentes
                }
            }
            return true;
        }
        private Cellule[,] _case = new Cellule[9, 9];
        public Sudoku(int[,] grille)
        {
            for (int ligne = 0; ligne <= 8; ligne++)
            {
                for (int colonne = 0; colonne <= 8; colonne++)
                {
                    this.Case[ligne, colonne] = new Cellule(grille[ligne, colonne]);  //on declare une nouvelle cellule
                }                                                                       //quand il passe par le constructeur il actualise les attributs de la Cellule donc []Possible
            }
        }
        internal Cellule[,] Case
        {
            get { return _case; }
            set { _case = value; }
        }
        public string ToSTRING()
        {
            string Affichage = "";
            for (int ligne = 0; ligne <= 8; ligne++)
            {
                for (int colonne = 0; colonne <= 8; colonne++)
                {
                    Affichage = Affichage + this.Case[ligne, colonne].Valeur + " ";
                }
                Affichage = Affichage + "\n";
            }
            return Affichage;
        }
        public bool LigneValide(int ligne, int colonne, int valeur) //si "valeur" present sur "ligne" alors retourne false
        {
            if (Case[ligne, colonne].Valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                for (colonne = 0; colonne <= 8; colonne++)
                {
                    if (Case[ligne, colonne].Valeur == valeur)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool ColonneValide(int ligne, int colonne, int valeur) //si "valeur" present  sur "colonne" alors retourne false
        {
            if (valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                for (ligne = 0; (ligne < 9); ligne++)
                {
                    if (Case[ligne, colonne].Valeur == valeur)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static int NumBlocLigne(int ligne, int colonne)   //le but de retrouve la position verticale du bloc
        {                                                   //le numéro retourné nous servira pour methode ZoneValide
            int Num = 0;                                    //on laisse ligne en variable muette
            if (colonne < 9)
            {
                if (colonne < 6)
                {
                    if (colonne < 3)
                    {
                        Num = 0;
                    }
                    else Num = 1;
                }
                else Num = 2;
            }
            return Num;
        }
        static int NumBlocColonne(int ligne, int colonne)   //le but de retrouve la position horizontale du bloc
        {                                                   //le numéro retourné nous servira pour methode ZoneValide
            int Num = 0;                                    //on laisse colonne en variable muette
            if (ligne < 9)
            {
                if (ligne < 6)
                {
                    if (ligne < 3)
                    {
                        Num = 0;
                    }
                    else Num = 1;
                }
                else Num = 2;
            }
            return Num;
        }
        bool ZoneValide(int ligne, int colonne, int valeur)
        {
            if (valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                int NumCol = NumBlocLigne(ligne, colonne) * 3;         // on le mutilplie par 3 puisqu'il va donner le départ de nos boucles en fonction des zones
                int NumLig = NumBlocLigne(ligne, colonne) * 3;         // soit 0,3 ou 6 comme depart en fonction de la zone
                for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++)
                {
                    for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                    {
                        if (Case[ligne, colonne].Valeur == valeur)
                        {
                            return false;                   //return false si la "valeur" est présente dans la zone
                        }
                    }
                }
            }
            return true;
        }
        public void Possible_lig_col_zon() //pour chacune des cellules de la grille on regarde qu elles sont les valeurs possibles et on modifie le tableau possible de chaque cellule
        {
            for (int compteur = 1; compteur <= 27; compteur++) //on repete l'opération pour les 27 possibilités
            {
                for (int ligne = 0; ligne <= 8; ligne++)
                {                                               //on parcourt notre grille
                    for (int colonne = 0; colonne <= 8; colonne++)
                    {
                        for (int valeur = 1; valeur <= 9; valeur++)     //on regarde pour toutes les valeurs de 1 a 9, inutile de regarder pour 0
                        {                                               // si les conditions sont vérifies  alors on affecte à [valeur]Possible --> true
                            if (ZoneValide(ligne, colonne, valeur) && ColonneValide(ligne, colonne, valeur) && LigneValide(ligne, colonne, valeur))
                            {
                                Case[ligne, colonne].Possible[valeur - 1] = true; //on met -1 puisqu'on a commencé à 1 ainsi on respecte la taille de []Possible
                            }
                            else
                            {
                                Case[ligne, colonne].Possible[valeur - 1] = false;
                            }
                        }
                    }
                }
            }
        }
        public void TestPossibilites(int ligne, int colonne)
        {
            for (int valeur = 1; valeur < 9; ++valeur)     //on regarde pour toutes les valeurs de 1 a 9, inutile de regarder pour 0
            {
                Console.Write(valeur + " ");
                Console.Write(Case[ligne, colonne].Possible[valeur - 1]);
                Console.WriteLine();
            }
        }
        public void PossibleUnique()
        {
            int compteur = 0;
            int ValeurFinal = 0;
            for (int ligne = 0; ligne <= 8; ligne++)
            {
                for (int colonne = 0; colonne <= 8; colonne++)
                {
                    for (int valeur = 0; valeur <= 8; valeur++)
                    {
                        if (Case[ligne, colonne].Possible[valeur] == true)
                        {
                            ValeurFinal = valeur;
                            compteur++;
                        }

                        if (compteur == 1)
                        {
                            Case[ligne, colonne].Valeur = ValeurFinal;
                        }
                    }
                }
            }
        }
        public void UniqueLigne(int ligne, int colonne)     //voir si une valeur possible d'une Cellule est la seule sur sa ligne
        {
            int[] compteur = new int[9];        // tableau puisque compteur pour 9 Possibilités
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                int L = 0;
                int C = 0;
                for (colonne = 0; colonne <= 8; colonne++)
                {
                    if (Case[ligne, colonne].Possible[valeur - 1] == true)
                    {
                        L = ligne;      //on recupere les coordonnées de la cellule pour pouvoir changer sa .Valeur au cas ou le compteur sera égal à 1
                        C = colonne;
                        compteur[valeur - 1]++;                     //on incremente la tableau(compteur) a son index correspondant à la valeur
                    }
                    if (compteur[valeur - 1] == 1)          //si compteur (valeur du tableau avec index correspondant) est égal à 1
                    {
                        Case[L, C].Valeur = valeur;
                    }
                }
            }
        }

        public void UniqueColonne(int ligne, int colonne)     //voir si une valeur possible d'une Cellule est la seule sur sa colonne
        {
            int[] compteur = new int[9];        // tableau puisque compteur pour 9 Possibilités
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                int L = 0;
                int C = 0;
                for (ligne = 0; ligne <= 8; ligne++)
                {
                    if (Case[ligne, colonne].Possible[valeur - 1] == true)
                    {
                        L = ligne;      //on recupere les coordonnées de la cellule pour pouvoir changer sa .Valeur au cas ou le compteur sera égal à 1
                        C = colonne;
                        compteur[valeur - 1]++;                     //on incremente la tableau(compteur) a son index correspondant à la valeur
                    }
                    if (compteur[valeur - 1] == 1)          //si compteur (valeur du tableau avec index correspondant) est égal à 1
                    {
                        Case[L, C].Valeur = valeur;
                    }
                }
            }
        }
        public void UniqueZone(int ligne, int colonne)
        {
            int[] compteur = new int[9];        // tableau puisque compteur pour 9 Possibilités
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                int L = 0;
                int C = 0;
                int NumCol = NumBlocLigne(ligne, colonne) * 3;         // on le mutilplie par 3 puisqu'il va donner le départ de nos boucles en fonction des zones
                int NumLig = NumBlocLigne(ligne, colonne) * 3;
                for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++)   // soit 0,3 ou 6 comme depart en fonction de la zone
                {
                    for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                    {
                        if (Case[ligne, colonne].Possible[valeur - 1] == true)
                        {
                            L = ligne;      //on recupere les coordonnées de la cellule pour pouvoir changer sa .Valeur au cas ou le compteur sera égal à 1
                            C = colonne;
                            compteur[valeur - 1]++;                     //on incremente la tableau(compteur) a son index correspondant à la valeur
                        }
                        if (compteur[valeur - 1] == 1)          //si compteur (valeur du tableau avec index correspondant) est égal à 1
                        {
                            Case[L, C].Valeur = valeur;
                        }
                    }
                }
            }
        }
        public void Unique_lig_col_zon() // Sur une même ligne, ou même colonne ou même région, si une valeur n’est possible que dans une seule case alors cette case prend cette valeur
        {
            for (int compteur = 1; compteur <= 27; compteur++)
            {
                for (int ligne = 0; ligne <= 8; ligne++)
                {                                               //on parcourt notre grille
                    for (int colonne = 0; colonne <= 8; colonne++)
                    {
                        UniqueZone(ligne, colonne);
                        UniqueLigne(ligne, colonne);         //on lance nos algos ci-dessus
                        UniqueColonne(ligne, colonne);
                    }
                }
            }
        }
        //Stratégie des chiffres exclusifs: si, à l’intérieur d’une Région, deux ou trois chiffres identiques figurent dans une Ligne et qu’ils ne figurent pas ailleurs dans la Région,
        //on peut alors supprimer sans autre ce chiffre se trouvant dans les autres Régions sur la même Ligne. Cette stratégie s’applique également pour une Colonne.
        public void Stra_Chiffres_Exclusifs_ligne(int ligne, int colonne)
        {
            bool[] NumColonneFinal = new bool[9];   //on declare pour recuperer les coordonnes des colonnes
            bool[] ValeurPossibleTrouve = new bool[9]; //on declare pour trouver quelles sont les possibilitees qui nous interressent
            int NumCol = NumBlocLigne(ligne, colonne) * 3;
            int NumLig = NumBlocLigne(ligne, colonne) * 3;
            int NumLigneDepart = ligne;

            for (int index = 0; index <= 8; ++index)
            {
                NumColonneFinal[index] = false;                //on suppose que la possibilite n'est pas presente sur la colonne==index
            }
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                bool ResteZoneSansPossible = true;
                int compteur = 0;
                for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                {
                    if (Case[ligne, colonne].Possible[valeur - 1])  //si la possibilite est presente dans la case
                    {
                        NumColonneFinal[colonne] = true;
                        compteur++; //on incremente le compteur
                    }
                    for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++) //on parcourt le reste 
                    {
                        if (ligne != NumLigneDepart) //sans prendre en compteur la ligne ou sont present les possibilites
                        {
                            for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                            {
                                if (Case[ligne, colonne].Possible[valeur - 1])
                                {
                                    ResteZoneSansPossible = false;  //il y a les possibilites presente dans la zone ailleurs que sur la ligne
                                }
                            }
                        }
                    }
                    if (compteur > 1 && ResteZoneSansPossible)       //si nos deux conditions verifiés
                    {
                        for (colonne = 0; colonne <= 8; colonne++)
                        {
                            if (!NumColonneFinal[colonne])       //si nous ne parlons pas des cases de la region
                            {
                                Case[NumLigneDepart, colonne].Possible[valeur - 1] = false;      //les autres cases de la ligne n'ont plus la valeur comme Possibilite
                            }
                        }
                    }
                }
            }
            for (int index = 0; index <= 8; index++)
            {
                for (colonne = 0 + NumLig; colonne < 3 + NumLig; colonne++) //on parcourt la ligne qui nous interesse
                {
                    if (!ValeurPossibleTrouve[index]) //si la possibilite est autre que celle trouve avec l'algo
                    {
                        Case[NumLigneDepart, colonne].Possible[index] = false;      //la ou la possibilite==index est absente on indique que la valeur est absente
                    }                                                               //cela nous permet de supprimer toutes les possibilites de la ligne autre que celle reperee avec notre algo
                }
            }
        }
        public void Stra_Chiffres_Exclusifs_colonne(int ligne, int colonne)
        {
            bool[] NumLigneFinal = new bool[9]; //on declare pour recuperer les coordonnes des lignes
            bool[] ValeurPossibleTrouve = new bool[9]; //on declare pour trouver quelles sont les possibilitees qui nous interressent
            int NumCol = NumBlocColonne(ligne, colonne) * 3;
            int NumLig = NumBlocLigne(ligne, colonne) * 3;
            int NumColonneDepart = colonne;
            for (int index = 0; index <= 8; index++)
            {
                NumLigneFinal[index] = false;                //on suppose que la possibilite n'est pas presente sur la ligne==index
            }
            for (int valeur = 1; valeur <= 9; valeur++)
            {
                bool ResteZoneSansPossible = true;
                int compteur = 0;
                for (ligne = 0 + NumCol; (ligne < 3 + NumCol); ligne++) //ligne varie mais colonne reste stable 
                {
                    if (Case[ligne, colonne].Possible[valeur - 1])  //si la possibilite est presente dans la case
                    {
                        NumLigneFinal[colonne] = true; //on recupere les coordonnées verticales ou est presente la valeur
                        compteur++; //on incremente le compteur
                    }

                    for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                    {
                        if (colonne != NumColonneDepart) //sans prendre en compte la colonne ou sont present les possibilites
                        {
                            for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++) //on parcourt le reste de la zone de ligne en ligne 
                            {
                                if (Case[ligne, colonne].Possible[valeur - 1])
                                {
                                    ResteZoneSansPossible = false;  //il y a les possibilites presentes dans la zone ailleurs que sur la ligne
                                }
                            }
                        }
                    }
                    if (compteur > 1 && ResteZoneSansPossible)       //si nos deux conditions verifiés
                    {
                        for (ligne = 0; ligne <= 8; ligne++)
                        {
                            if (!NumLigneFinal[ligne])       //on ne modifie pas la valeur des case de la region
                            {
                                Case[ligne, NumColonneDepart].Possible[valeur - 1] = false; //les autres cases de la ligne n'ont plus la valeur comme Possibilite
                            }
                        }
                        ValeurPossibleTrouve[valeur] = true; //valeur nous interresse
                    }
                }
            }
            for (int index = 0; index <= 8; index++)
            {
                for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++) //on parcourt la colonne qui nous interesse
                {
                    if (!ValeurPossibleTrouve[index])
                    {
                        Case[ligne, NumColonneDepart].Possible[index] = false;      //la ou la possibilite==index est absante on indique que la valeur est absente
                    }                                                               //cela nous permet de supprimer toutes les possibilites de la colonne autre que celle reperee avec notre algo
                }
            }
        }
        //Stratégie des paires exclusives: si dans une Unité se trouve deux Cases dans lesquelles les deux mêmes chiffres peuvent figurer (par exemple 2/7 et 2/7), 
        //alors on peut supprimer sans autre ces deux chiffres de l’Unité.
        public void Paires_Exclusives(int ligne, int colonne)
        {
            int NumColonneDepart = colonne;
            int NumLigneDepart = ligne;
            int PaireCol = 0;
            int PaireLig = 0;
            int compteur = 0;
            bool[] ValeurPossibleTrouve = new bool[9];              // qu elle sont les valeurs possibles trouvees
            int NumCol = NumBlocColonne(ligne, colonne) * 3;
            int NumLig = NumBlocLigne(ligne, colonne) * 3;
            for (ligne = 0 + NumCol; (ligne < 3 + NumCol); ligne++) //on parcourt notre region
            {
                for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                {
                    if (egal(Case[NumLigneDepart, NumColonneDepart], Case[colonne, ligne])) //si deux cases ont le meme tableau des possibles
                    {
                        PaireCol = colonne;
                        PaireLig = ligne; //on recupere les coordonnes de la deuxieme case
                        compteur++;
                    }
                }
            }
            if (compteur == 1) //on verifie que seulement deux cases sont egales
            {
                for (int valeur = 1; valeur <= 9; valeur++)
                {
                    if (Case[NumLigneDepart, NumColonneDepart].Possible[valeur - 1]) //on supprime la possibilité "valeur" que si la Case a cette valeur possible
                    {
                        for (ligne = 0 + NumCol; (ligne < 3 + NumCol); ligne++) //on reparcourt notre region
                        {
                            for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                            {
                                if ((colonne != NumColonneDepart) || (colonne != PaireCol) || (ligne != NumLigneDepart) || (ligne != PaireLig))
                                {                                                       //exception pour les deux cases ayant les memes possibilités
                                    Case[ligne, colonne].Possible[valeur - 1] = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ValeurF_Exlusif() // Sur une même ligne, ou même colonne ou même région, si une valeur n’est possible que dans une seule case alors cette case prend cette valeur
        {
            for (int compteur = 1; compteur <= 27; compteur++)
            {
                for (int ligne = 0; ligne <= 8; ligne++)
                {                                               //on parcourt notre grille
                    for (int colonne = 0; colonne <= 8; colonne++)
                    {
                        Paires_Exclusives(ligne, colonne);
                        Stra_Chiffres_Exclusifs_ligne(ligne, colonne);
                        Stra_Chiffres_Exclusifs_colonne(ligne, colonne);
                    }
                }
            }
        }
        public bool GrilleRemplie()
        {
            for (int ligne = 0; ligne <= 8; ligne++)
            {
                for (int colonne = 0; colonne <= 8; colonne++)
                {
                    if (Case[ligne, colonne].Valeur == 0)  //
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void SudokuPOO()
        {
            ToSTRING();
            while (!GrilleRemplie())
            {
                Possible_lig_col_zon();
                Unique_lig_col_zon();
                ValeurF_Exlusif();
            }
            ToSTRING();
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            int[,] grille =
    {
        {2,0,0,0,9,0,3,0,0},
        {0,1,9,0,8,0,0,7,4},
        {0,0,8,4,0,0,6,2,0},
        {5,9,0,6,2,1,0,0,0},
        {0,2,7,0,0,0,1,6,0},
        {0,0,0,5,7,4,0,9,3},
        {0,8,5,0,0,9,7,0,0},
        {9,3,0,0,5,0,8,4,0},
        {0,0,2,0,6,0,0,0,1}
            };
            Sudoku grille1 = new Sudoku(grille);
            grille1.TestPossibilites(1, 0);
            grille1.Possible_lig_col_zon();
            Recursive Exemple1 = new Recursive(grille);
            MenuDefillant(grille1,Exemple1);
            Console.ReadKey();
        }
        static void MenuDefillant(Sudoku exemple0, Recursive exemple1)
        {
            int Exo = 0;
            Console.WriteLine("utiliser les fleches pour se déplacer dans le menu sinon tapper sur Q");
            Console.WriteLine("Menu  :");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Methode 1 : Resolution sudoku en Brut-Force");
            Console.ResetColor();
            Console.WriteLine("Methode 2 : Resolution sudoku avec POO");
            Console.WriteLine();
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            while (cki.Key != ConsoleKey.Q)
            {
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    Exo = Exo + 1;
                    if (Exo > 1)
                    {
                        Exo = 0;
                    }
                    Console.Clear();
                }
                if (cki.Key == ConsoleKey.UpArrow)
                {
                    Exo = Exo - 1;
                    if (Exo < 0)
                    {
                        Exo = 1;
                    }
                    Console.Clear();
                }
                if (cki.Key == ConsoleKey.Enter)
                {
                    Exo = Exo + 2;
                    Console.Clear();
                }
                switch (Exo)
                {
                    case 0:
                        Console.WriteLine("utiliser les fleches pour se déplacer dans le menu sinon tapper sur Q");
                        Console.WriteLine("Menu  :");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Methode 1 : Resolution sudoku en Brut-Force");
                        Console.ResetColor();
                        Console.WriteLine("Methode 2 : Resolution sudoku avec POO");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine("utiliser les fleches pour se déplacer dans le menu sinon tapper sur Q");
                        Console.WriteLine("Menu  :");
                        Console.WriteLine("Methode 1 : Resolution sudoku en Brut-Force");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Methode 2 : Resolution sudoku avec POO");
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("utiliser les fleches pour se déplacer dans le menu sinon tapper sur Q");
                        Console.WriteLine("Menu  :");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Methode 1 : Resolution sudoku en Brut-Force");
                        Console.ResetColor();
                        Console.WriteLine("Methode 2 : Resolution sudoku avec POO");
                        Console.WriteLine();
                        exemple1.SudokuRecursive();
                        break;
                    case 3:
                        Console.WriteLine("utiliser les fleches pour se déplacer dans le menu sinon tapper sur Q");
                        Console.WriteLine("Menu  :");
                        Console.WriteLine("Methode 1 : Resolution sudoku en Brut-Force");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Methode 2 : Resolution sudoku avec POO");
                        Console.ResetColor();
                        Console.WriteLine();
                        exemple0.SudokuPOO();
                        break;
                }
                cki = Console.ReadKey();
            }
        }
        
    }
    class Recursive
    {
        public int[,] grille;

        public Recursive(int[,] grille)
        {
            this.grille = grille;
        }

        public void SudokuRecursive()
        {
            AffichageGrille();
            Valide(grille, 0);
            Console.WriteLine();
            AffichageGrille();
        }
        public void AffichageGrille()
        {
            Console.WriteLine();
            for (int ligne = 0; ligne < 9; ligne++)
            {
                for (int colonne = 0; colonne < 9; colonne++)
                {
                    Console.Write(grille[ligne, colonne] + " ");
                }
                Console.WriteLine();
            }
        }
        public bool LigneValide(int ligne, int valeur) //si "valeur" present 1 fois sur "ligne" alors retourne false
        {
            if (valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                for (int colonne = 0; (colonne < 9); colonne++)
                {
                    if (grille[ligne, colonne] == valeur)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public bool ColonneValide(int colonne, int valeur) //si "valeur" present 1 fois sur "colonne" alors retourne false
        {
            if (valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                for (int ligne = 0; (ligne < 9); ligne++)
                {
                    if (grille[ligne, colonne] == valeur)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public int NumBlocLigne(int ligne, int colonne)    //le but de retrouve la position horizontale du bloc
        {                                                   //le numéro retourné nous servira pour methode ZoneValide
            int Num = 0;                                    //on laisse colonne en variable muette
            if (ligne < 9)
            {
                if (ligne < 6)
                {
                    if (ligne < 3)
                    {
                        Num = 0;
                    }
                    else Num = 1;
                }
                else Num = 2;
            }
            return Num;
        }

        public int NumBlocColonne(int ligne, int colonne)   //le but de retrouve la position verticale du bloc
        {                                                   //le numéro retourné nous servira pour methode ZoneValide
            int Num = 0;                                    //on laisse ligne en variable muette
            if (colonne < 9)
            {
                if (colonne < 6)
                {
                    if (colonne < 3)
                    {
                        Num = 0;
                    }
                    else Num = 1;
                }
                else Num = 2;
            }
            return Num;
        }

        public bool ZoneValide(int ligne, int colonne, int valeur)
        {

            if (valeur != 0)        // 0 n'est pas considéré comme valeur
            {
                int NumCol = NumBlocColonne(ligne, colonne) * 3;         // on le mutilplie par 3 puisqu'il va donner le départ de nos boucles en fonction des zones
                int NumLig = NumBlocLigne(ligne, colonne) * 3;            // soit 0,3 ou 6 comme depart en fonction de la zone
                for (ligne = 0 + NumCol; ligne < 3 + NumCol; ligne++)
                {
                    for (colonne = 0 + NumLig; (colonne < 3 + NumLig); colonne++)
                    {
                        if (grille[ligne, colonne] == valeur)
                        {
                            return false;                   //return false si la "valeur" est présente dans la zone
                        }

                    }
                }
            }
            return true;
        }
        public int Position_Numero(int colonne, int ligne)
        {
            return ligne * 9 + colonne;
        }

        public bool Valide(int[,] grille, int position)
        {
            //AffichageGrille(grille);
            if (position > 80)            //le programme se stoppe à partir de la 82 ieme case
            {
                return true;
            }
            int colonne = position % 9;         //on utilisera plusieurs return puisqu'on fait de la recursivité
            int ligne = position / 9;
            if (grille[ligne, colonne] != 0)
            {
                return Valide(grille, position + 1);    //on return la methode en passant à la position suivante    
            }                                            //si la valeur différent 0 (soit une case deja remplie)
            for (int valeur = 1; valeur <= 9; valeur++)  //on va tester toutes les valeurs une à une
            {
                if (ZoneValide(colonne, ligne, valeur) && LigneValide(ligne, valeur) && ColonneValide(colonne, valeur))
                {                                                               //on a verifie que la valeur était bien possible 
                    grille[ligne, colonne] = valeur;
                    if (Valide(grille, position + 1))
                    {
                        return true;
                    }

                }
                grille[ligne, colonne] = 0; //sinon quand on va repasser dans (valeur != 0, il ne va pas return la methode) 
            }
            return false;
        }



    }
}
