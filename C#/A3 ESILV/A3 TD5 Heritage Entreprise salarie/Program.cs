using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5_POO_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Salarie individu1 = new Salarie("Bonan", "Alexandre", "11 bis rue du Lord Byron, Paris", "0782842985", 'm', new DateTime(1998, 1, 22), 3000, "Alexandre@wanadoo.fr", new DateTime(2007, 5, 25));
            Salarie individu2 = new Salarie("Abou Jaoudé", "Yann", "38 avenue Victor Hugo, Boulogne-Billancourt", "0677595732", 'm', new DateTime(1998, 6, 9), 60000, "Yann@gmail.com", new DateTime(2008, 4, 19));
            Salarie individu3 = new Salarie("Ballet", "Mael", "30 rue des Lilas d'Espagne, Courbevoie", "0674807930", 'm', new DateTime(1998, 3, 22), 3000, "Mael@wanadoo.fr", new DateTime(2007, 5, 25));
            Salarie individu4 = new Salarie("Caujolle", "Louis", "11 allée des Tilleuls, Courbevoie ", "0759545230", 'm', new DateTime(1998, 6, 9), 60000, "Louis@gmail.com", new DateTime(2008, 4, 19));
            List<Salarie> maListe = new List<Salarie>();
            maListe.Add(individu1);
            maListe.Add(individu2);
            maListe.Add(individu3);
            maListe.Add(individu4);

            for (int i = 0; i < maListe.Count(); i++)
            {
                Console.WriteLine(maListe[i].getNom());
            }

            maListe.Sort();

            for (int i = 0; i < maListe.Count(); i++)
            {
                Console.WriteLine(maListe[i].getNom());
            }

            Console.ReadKey();
        }
    }
    

}
