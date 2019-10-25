using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_4_POO_exercice_1_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            personne individu1 = new personne("Bonan", "Alexandre", "11 bis rue du Lord Byron, Paris", "0782842985", 'm', new DateTime(1998, 1, 22));
            personne individu2 = new personne("Abou Jaoudé", "Yann", "38 avenue Victor Hugo, Boulogne-Billancourt", "0677595732", 'm', new DateTime(1998, 6, 9));
            Console.WriteLine(individu1.ToString() + " Age " + individu1.age());
            Console.WriteLine(individu2.ToString() + " Age " + individu2.age());

            Salarie individu3 = new Salarie("Ballet", "Mael", "30 rue des Lilas d'Espagne, Courbevoie", "0674807930", 'm', new DateTime(1998, 3, 22),3000,"Mael@wanadoo.fr", new DateTime(2007, 5, 25));
            Salarie individu4 = new Salarie("Caujolle", "Louis", "11 allée des Tilleuls, Courbevoie ", "0759545230", 'm', new DateTime(1998, 6, 9), 60000, "Louis@gmail.com", new DateTime(2008, 4, 19));
            Console.WriteLine(individu3.ToString() + " Age " + individu3.age()+" Ancienneté: "+individu3.Anciennete());
            Console.WriteLine(individu4.ToString() + " Age " + individu4.age() + " Ancienneté: " + individu4.Anciennete());

            //Salarie p = new personne("Bonan", "Alexandre", "11 bis rue du Lord Byron, Paris", "0782842985", 'm', new DateTime(1998, 1, 22)); 
            //une personne n'est pas un salarié

            personne individu5 = new Salarie("Caillieux", "Nicolas", "110 rue de Verdun, Paris", "0674807930", 'm', new DateTime(1998, 3, 27), 30500, "Nicolas@wanadoo.fr", new DateTime(2007, 6, 25));
            //Un salarié est une personne, tout est normal
            Console.WriteLine(individu5.Coordonnees());
            //On utilise la fonction de la classe personnage si Coordonnee n'est pas virtual
            //On utilise la fonction de la classe personnage si Coordonnee est virtual
            //Console.WriteLine(individu5.Anciennete());
            //ça ne fonctionne pas, il n'y a pas de fonction anciennete dans la classe personne 


            Console.ReadKey();
        }
    }
}
