using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_TD2
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            //////////////////////////////// Les variables
            int n;
            int n1;
            int n2;
            int m1;
            int m2;
            int[,] matrice1;
            int[,] matrice2;
            ////////////////////////////////// Les noms des exercices
            string[] ListeExo = { "Un tableau de n nombres pairs", "Ajout de 2 matrices", "Multiplication d’un vecteur et d’une matrice", "Multiplication de 2 matrices", "Un carré magique", "les points cols.", "DecaleNombreElements", "Quitter" };
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
                            Console.WriteLine("entrer la taille du tableau");
                            n = DemanderInt();
                            tableauDeNombrePair(n);
                            break;
                        case 1:
                            Console.WriteLine("Entrez la hauteur de la matrice 1");
                            n1 = DemanderInt();
                            Console.WriteLine("Entrez la largeur de la matrice 1");
                            n2 = DemanderInt();
                            matrice1 = new int[n1, n2];
                            Console.WriteLine("Entrez la hauteur de la matrice 2");
                            m1 = DemanderInt();
                            Console.WriteLine("Entrez la largeur de la matrice 2");
                            m2 = DemanderInt();
                            matrice2 = new int[m1, m2];
                            matrice1 = remplirLesMatricesAleatoirement(matrice1, 0, 10);
                            Console.WriteLine("La matrice 1 a été générée aléatoirement");
                            afficherMatrice(matrice1);
                            Console.WriteLine("La matrice 2 a été générée aléatoirement");
                            matrice2 = remplirLesMatricesAleatoirement(matrice2, 0, 10);
                            afficherMatrice(matrice2);
                            Console.WriteLine("Voici la somme des 2 matrices");
                            matrice1 = AjoutDeuxMatrices(matrice1, matrice2);
                            afficherMatrice(matrice1);
                            break;
                        case 3:
                            Console.WriteLine("Entrez la hauteur de la matrice 1");
                            n1 = DemanderInt();
                            Console.WriteLine("Entrez la largeur de la matrice 1");
                            n2 = DemanderInt();
                            matrice1 = new int[n1, n2];
                            Console.WriteLine("Entrez la hauteur de la matrice 2");
                            m1 = DemanderInt();
                            Console.WriteLine("Entrez la largeur de la matrice 2");
                            m2 = DemanderInt();
                            matrice2 = new int[m1, m2];
                            matrice1 = remplirLesMatricesAleatoirement(matrice1, 0, 10);
                            Console.WriteLine("La matrice 1 a été générée aléatoirement");
                            afficherMatrice(matrice1);
                            Console.WriteLine("La matrice 2 a été générée aléatoirement");
                            matrice2 = remplirLesMatricesAleatoirement(matrice2, 0, 10);
                            afficherMatrice(matrice2);
                            Console.WriteLine("Voici le produit des 2 matrices");
                            matrice1 = MultiplierMatrices(matrice1, matrice2);
                            afficherMatrice(matrice1);
                            break;
                        case 4:
                            int[,] carre = new int[3, 3] { { 8, 1,6 }, { 3, 5,7 }, { 4, 9,2 } };
                            afficherMatrice(carre);
                            Console.WriteLine("cette matrice est elle carré ?  " + unCarreMagique(carre));
                            break;
                        case 5:
                            int[,] matrice = new int[3, 3] { { 1, 2, 3 }, { -7, 8, 9 }, { -6, -3, -4 } };
                            afficherMatrice(matrice);
                            pointsCols(matrice);
                            break;
                        case 6:
                            Console.WriteLine("Entrez la hauteur de la matrice ");
                            n1 = DemanderInt();
                            Console.WriteLine("Entrez la largeur de la matrice ");
                            n2 = DemanderInt();
                            matrice1 = new int[n1, n2];
                            matrice1 = remplirLesMatricesAleatoirement(matrice1, 0, 100);
                            Console.WriteLine("La matrice 1 a été générée aléatoirement");
                            afficherMatrice(matrice1);
                            Console.WriteLine("De combien doit-t-on décaler les éléments?");
                            int nombre = DemanderInt();
                            Console.WriteLine("Voici la matrice décalé");
                            matrice1 = DecaleNombreElements(matrice1, nombre);
                            afficherMatrice(matrice1);
                            break;
                        case 7:
                            resterDansLeMenu = false;
                            Console.WriteLine("A bientôt!");
                            break;
                        default:
                            Console.WriteLine("L'exercice n'est pas fait.");
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

       static void tableauDeNombrePair(int n)
        {
            int[] monTableau = new int[n];
            for (int i = 0; i < n; i++)
            {
                monTableau[i] = i * 2;
                Console.WriteLine(monTableau[i]);
            }
        }
       static int[,] AjoutDeuxMatrices(int[,] matrice1, int[,] matrice2)
        {
            if (matrice1!=null&& matrice2 != null) {
                if (matrice1.GetLength(0) == matrice2.GetLength(0) && matrice1.GetLength(1) == matrice2.GetLength(1))
                {
                    for (int i = 0; i < matrice1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrice1.GetLength(1); j++)
                        {
                            matrice1[i, j] = matrice1[i, j] + matrice2[i, j];
                        }
                    }
                }
            }
            return matrice1;
        }       
       static int[,] remplirLesMatricesAleatoirement(int[,] matrice, int min, int max)
        {
            Random rnd = new Random(System.DateTime.Now.Millisecond);
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    matrice[i, j] = rnd.Next(min,max);
                }
            }
            return matrice;
        }
       static void afficherMatrice(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j]+"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
       static int DemanderInt()
        {
            int a;
            string entre="a";
            while (int.TryParse(entre, out a) == false)
            {
                entre = Console.ReadLine();
            }
            a = int.Parse(entre);
            return a;
        }
        static int[,] MultiplierMatrices(int[,] mat2, int[,] mat1)
        {
            int[,] mat = null;

            if (mat1.GetLength(0) == mat2.GetLength(1) && mat1.GetLength(0) == mat2.GetLength(1))
            {
                mat = new int[mat2.GetLength(0), mat1.GetLength(1)];

                for (int i = 0; i < mat2.GetLength(0); i++)
                {
                    for (int j = 0; j < mat1.GetLength(1); j++)
                    {
                        for (int k = 0; k < mat1.GetLength(0); k++)
                        {
                            mat[i, j] += mat1[k, j] * mat2[i, k];
                        }
                    }
                }
            }
            return mat;
        }
        static bool unCarreMagique(int[,] carre)
        {
            bool result = false;

            if (carre != null )
            {
                if(carre.GetLength(0)== carre.GetLength(1))
                {
                    result = true;
                    int test = 0;
                    for (int i = 0; i < carre.GetLength(0); i++)
                    {
                        test = test + carre[i, 0];
                    }
                    int testColonne;
                    int testLigne;
                    int testDiago;
                        for (int i = 0; i < carre.GetLength(0); i++)
                    {
                        testColonne = 0;
                        testLigne = 0;
                        testDiago = 0;
                        for (int j = 0; j < carre.GetLength(1); j++)
                        {
                            testColonne = testColonne + carre[j, i];
                            testLigne = testLigne + carre[i, j];
                            if (i == 0)
                            {
                                testDiago = testDiago + carre[j, j];
                            }
                            else if (i == 1)
                            {
                                testDiago = testDiago + carre[j, carre.GetLength(0)-1 - j];
                            }
                            else { testDiago = 15; }
                        }   
                        if(testColonne!=test|| testLigne != test || testDiago != test)
                        {                           
                            result = false;
                        }                                           
                    }
                }
            }

                return result;
        }
       static void pointsCols(int[,]matrice)
        {
            bool[,] result = new bool[matrice.GetLength(0), matrice.GetLength(1)];

            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    result[i, j] = true;
                    for (int k = 0; k < matrice.GetLength(0); k++)
                    {
                        if(matrice[i, k]< matrice[i, j]|| matrice[k, j] > matrice[i, j])
                        {
                            result[i, j] = false;
                        }
                    }
                }               
            }
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
       static int[,] DecaleNombreElements(int[,] matrice, int nombre)
        {
            int a;
            int b = 0;
            for(int k =0; k<nombre; k++)
            {
                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        a = matrice[i, j];
                        matrice[i, j] = b;
                        b = a;
                    }                   
                }
                matrice[0, 0] = b;
            }
            return matrice;
        }
    }
}
