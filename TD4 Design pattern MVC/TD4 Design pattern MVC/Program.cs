using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Design_pattern_MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Drink> mydrinks = new List<Drink>();
            mydrinks.Add(new Drink(2, "coca"));
            mydrinks.Add(new Drink(3, "fanta"));
            mydrinks.Add(new Drink(4, "orangina"));
            Dispencer myDispencer= new Dispencer(mydrinks);
            myDispencer.mycontroller.SelectADrink();
            Console.ReadKey();
        }
    }
}
