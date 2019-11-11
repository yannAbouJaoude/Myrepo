using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Design_pattern_MVC
{
    class Dispencer
    {
        private List<Drink> choices;
        private string state;
        public int euros;
        private View myview;
        public Controller mycontroller;
        public string State
        {
            get
            {
                return state;
            }
        }
        public List<Drink> Choices
        {
            get
            {
                return choices;
            }
        }

        public Dispencer(List<Drink> a)
        {
            choices = a;
            state = "Please select a choice";
            mycontroller = new Controller(this);
            myview = new View(this);
            myview.showState();
        }
        public void distribute(int choice)
        {
            while (euros < choices[choice].cost)
            {
                state = "waiting for money";
                myview.showState();
                euros+=mycontroller.waitForMoney();
            }
            state = "Distributing";
            myview.showState();
            myview.MovingTheDrink();
            state = "Done";
            myview.showState();
            GoingBackToNormal();
           
        }
        public void badChoice()
        {
            state = "Error";
            myview.showState();
            GoingBackToNormal();
        }
        private void GoingBackToNormal()
        {
            state = "Please select a choice";
            myview.showState();
            euros=0;
        }
    }
}
