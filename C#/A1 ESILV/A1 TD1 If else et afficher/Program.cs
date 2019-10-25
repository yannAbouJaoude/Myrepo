using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Exo1();
            //  Exo2();
            //  Exo3();
            //  Exo4();
            //  Exo5();
            //  Exo6(); 
            //  Exo7();
            //  Exo8();
            //  Exo9();
            //  Exo10();
            //  Exo11();
            //  Exo12();
            //  Exo13();
            //  Exo14();
            //  Exo14bis();
            //  Exo15();
            //  Exo16();
            //  Exo17();
            Exo18();
            Console.ReadKey();
        }

        static void Exo1()
        {
            Console.WriteLine("Bonjour le monde");
        }

        static void Exo2()
        {
            Console.WriteLine("C'est quoi ton petit prénom ?");
            string prenom = Console.ReadLine();
            Console.WriteLine("Bonjour "+ prenom + Environment.NewLine + "comment vas tu?");
        }

        static void Exo3()
        {
            int cp = 92;
            string nom = "Hauts-de-Seine";
            string phrase = "Le code postal des " + nom + " est le " + cp;
            Console.WriteLine(phrase);
        }

        static void Exo4()
        {
            Console.WriteLine("Quelle est la longueur du premier cote ?");
            double cote1;
            cote1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Quelle est la longueur du second cote ?");
            double cote2;
            cote2 = Double.Parse(Console.ReadLine());
            double surface = cote1 * cote2;
            Console.WriteLine("La surface du rectangle est " + surface); 
        }

        static void Exo5()
        {
            string syllabe = Console.ReadLine();
            syllabe = syllabe + syllabe;
            Console.WriteLine(syllabe);
        }

        static void Exo6()
        {
            string var1 = Console.ReadLine();
            string var2 = Console.ReadLine();
            Console.WriteLine("var1 = " + var1 + "  var2 = " + var2);
            string var3 = var1;
            var1 = var2;
            var2 = var3;
            Console.WriteLine("var1 = " + var1 + "  var2 = " + var2);
        }

        static void Exo7()
        {
            int nb1 = int.Parse(Console.ReadLine());
            int nb2 = int.Parse(Console.ReadLine());
            Console.WriteLine("La moyenne est " + ((double)nb1 + (double)nb2) / 2);
        }

        static void Exo8()
        {
            double temperature = double.Parse(Console.ReadLine());
            temperature = temperature * 1.8 + 32;
            Console.WriteLine("temperature = " + temperature+ " Farenheit");
        }

        static void Exo9()
        {
            int n = 0;
            while (n != 20) {
                Console.WriteLine("ça tourne");
                n++;
            };
            for (int i=0 ;i!=20;i++) { Console.WriteLine("ça tourne"); };

        }

        static void Exo10()
        {
            int n = 0;
            while (n < 100) { n = n + int.Parse(Console.ReadLine());
            }
            Console.WriteLine("la somme des n est " + n);
        }

        static void Exo11()
        {
            int n = 1;
            while (n != 0) {
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("n² = " + n * n);
            }
        }
        static void Exo12()
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;
                while (i < n) {
                    i++;
                Console.WriteLine(i);
            }
                while (i > 0)
            {
                Console.WriteLine(i);
                i--;
            }
        }

        static void Exo13()
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo14()
        {
            int n = -1;
            while (n <= 0) { n = int.Parse(Console.ReadLine()); }
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo14bis()
        {
            int n = -1;

            do { n = int.Parse(Console.ReadLine()); } while (n <= 0);
            int i = 0;
            int a = 0;
            while (i < n)
            {
                i++;
                a = a + i;
                Console.WriteLine(a);
            }
        }

        static void Exo15()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            a = a + b;
            int r = int.Parse(Console.ReadLine());
            if (r != a) {
                Console.WriteLine("retourne en primaire gros kk"); ;
           }
            else {
                Console.WriteLine("bravo"); }
        }

        static void Exo16()
        {
            int mois = 0;
            while (mois<=1 || mois>=12) { mois = int.Parse(Console.ReadLine());}
            if (mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12) {
                Console.WriteLine(" ce mois à 31 jours");
            }
            else if(mois == 2) { Console.WriteLine(" ce mois à 28 jours"); }
            else { Console.WriteLine(" ce mois à 30 jours"); }
        }

        static void Exo17()
        {
            string fin = "0";
            int somme = 0;
            int n = -1;
            while(fin != "fin") {
                somme = somme + int.Parse(fin);
                fin = Console.ReadLine();
                n++;

            }
            Console.WriteLine("vous avez rentré " + n + " termes");
            Console.WriteLine("La somme des termes entré est " + somme);
            Console.WriteLine("La moyenne est " + (double)somme / n); 
        }

        static void Exo18()
        {
            int version = 0;
            while(version != 1 && version != 2) {
                Console.WriteLine("choisir une version (1 ou 2)");
                Console.WriteLine("La version 1 te donne un nombre d'essai infini");
                Console.WriteLine("La version 2 te donne 10 essais maximums");
                version = int.Parse(Console.ReadLine());
            }
            if (version == 2) { Console.WriteLine("Attention! Tu as 10 essais au maximum!"); }
           
            Random rnd = new Random(); // c'est trop nul de le mettre en dure
            int a = rnd.Next(0, 100);
            int r = -1;
            int essai = 0;
            while (a != r) {
                if (version == 1 || essai != 10) {
                    Console.WriteLine("Entre un entier");
                    
                    r = int.Parse(Console.ReadLine());
                    if (a < r) { Console.WriteLine("c'est moins!"); }
                    if (a > r) { Console.WriteLine("c'est plus!"); }
                }
                if (essai == 10 && version == 2) { Console.WriteLine("Tu as perdu..."); a = r; }
                essai++;
            }
            
            if (version == 2 && essai != 10) { Console.WriteLine("Bravo! tu as gagné! Il t'a fallu " + essai + " coups"); }
            if(version == 1) { Console.WriteLine("Bravo! tu as gagné! Il t'a fallu " + essai + " coups"); }
        }

    }
}
