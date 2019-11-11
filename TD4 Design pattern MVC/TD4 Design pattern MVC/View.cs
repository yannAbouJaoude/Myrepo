using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Design_pattern_MVC
{
    class View
    {
        private string state;
        private Dispencer myDispencer;
        private string contents;
        public View(Dispencer a)
        {
            myDispencer = a;
            state = "waiting";
            updateContents();
        }
        private void updateContents()
        {
            state="";
            foreach(Drink a in myDispencer.Choices)
            {
                state += a.ToString();
            }
        }
        public void showState()
        {
            Console.WriteLine(myDispencer.State);
        }
        public void MovingTheDrink()
        {
            Console.WriteLine("tzzzzz pff shuuuuussss");
        }

    }
}
