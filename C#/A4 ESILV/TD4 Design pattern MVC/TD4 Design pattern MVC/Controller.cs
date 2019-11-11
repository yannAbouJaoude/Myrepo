using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Design_pattern_MVC
{
    class Controller
    {
        private Dispencer myDispencer;
        public void addChoice(Drink a)
        {
            myDispencer.Choices.Add(a);
        }
        public void removeChoice(Drink a)
        {
            myDispencer.Choices.Remove(a);
        }
        public int waitForMoney()
        {
            return int.Parse(Console.ReadLine());
        }
        public Controller(Dispencer a)
        {
            myDispencer = a;
        }
        public void SelectADrink()
        {
            int choice = int.Parse(Console.ReadLine());
            if (choice < myDispencer.Choices.Count)
            {
                myDispencer.distribute(choice);
            }
            else
            {
                myDispencer.badChoice();
            }
        }
        

    }
}
