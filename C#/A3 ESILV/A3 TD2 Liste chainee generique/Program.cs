using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_liste_generique
{
    class Program
    {
        static void Main(string[] args)
        {
            entreprise google = new entreprise("google", "San Franscisco");
            Salarie gilbert = new Salarie("Gilbert", "Montagnier", "38 avenue du perou");
            Salarie nicolas = new Salarie("Nicolas", "Fontaine", "14 avenue de la republique");
            Salarie robin = new Salarie("Robin", "Prevert", "48 rue de Verdun");
            Salarie pierre = new Salarie("Pierre", "Jaquelin", "110 boulevard des généraux");
            google.recrutement(gilbert);
            google.recrutement(nicolas);
            google.recrutement(robin);
            google.recrutement(pierre);
            Console.ReadKey();
        }
    }
}
