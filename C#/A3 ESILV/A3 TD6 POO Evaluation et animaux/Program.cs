using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercice1();
            Exercice2();
            Console.ReadKey();

        }
        static void Exercice1(){ 
            List<Animal_Domestique> maListe = new List<Animal_Domestique>();
            maListe.Add(new Animal_Domestique("Chien", "Milou", new DateTime(2012, 06, 20), 23));
            maListe.Add(new Animal_Domestique("Chat", "Garfield", new DateTime(2008, 05, 12), 120));
            maListe.Add(new Animal_Domestique("Pousson rouge", "Nemo", new DateTime(2017, 02, 10), 0.5));
            maListe.Add(new Animal_Domestique("Tortue", "Tanguy", new DateTime(2014, 04, 20), 5));
            maListe.Add(new Animal_Domestique("Cochon d'Inde", "Alexandre Bonan", new DateTime(1998, 02, 25), 90));

            List<Animal_Domestique> poidsSup = maListe.FindAll(x => x.poids > 10);//Lambda
            Console.WriteLine("Voici les animaux domestiques pesant plus de 10 kilos:");
            foreach (Animal_Domestique a in poidsSup)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("\n"+"Voici l'animal domestique qui s'appel Garfield \n" + maListe.Find(x => x.pseudo.Equals("Garfield:")));

            Console.WriteLine("\n" + "Voici les animaux avec leur poids en pounds:");
            foreach (Animal_Domestique a in maListe)
            {
                a.poids = a.poids * 0.4536;
            }
            foreach (Animal_Domestique a in maListe)
            {
                Console.WriteLine(a);
            }

            maListe.Sort(delegate (Animal_Domestique x, Animal_Domestique y)//delegate
            {
                return x.nom.CompareTo(y.nom);
            });
            Console.WriteLine("\n" + "Voici les animaux avec trié par leurs noms:");
            foreach (Animal_Domestique a in maListe)
            {
                Console.WriteLine(a);
            }

            maListe.Sort(delegate (Animal_Domestique x, Animal_Domestique y)
            {
                return x.date_naissance.CompareTo(y.date_naissance);
            });
            Console.WriteLine("\n" + "Voici les animaux avec trié par leurs dates de naissances:");
            foreach (Animal_Domestique a in maListe)
            {
                Console.WriteLine(a);
            }

            maListe.Sort(delegate (Animal_Domestique x, Animal_Domestique y)
            {
                return x.poids.CompareTo(y.poids);
            });
            Console.WriteLine("\n" + "Voici les animaux avec trié par leurs poids:");
            foreach (Animal_Domestique a in maListe)
            {
                Console.WriteLine(a);
            }
        }
        static void Exercice2()
        {
            double[] cc = { 0.6, 0, 0.75, 0.4, 0 };
            Evaluation POO = new Evaluation(cc,0.8);
            Console.WriteLine("La moyenne en utilisant la méthode A est " + POO.CalculNoteFinale(POO.A)*20+"/20");
            Console.WriteLine("La moyenne en utilisant la méthode B est " + POO.CalculNoteFinale(POO.B) * 20 + "/20");
            Console.WriteLine("La moyenne en utilisant la méthode C est " + POO.CalculNoteFinale(POO.C) * 20 + "/20");
        }
    }
}
