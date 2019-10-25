using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{

    public abstract class Subject
    {

        protected List<Observer> lstObservers = new List<Observer>();

        public void Register(Observer observer)

        {

            lstObservers.Add(observer);

        }

        public void UnRegister(Observer observer)

        {

            lstObservers.Remove(observer);

        }

        public void UnRegisterAll()

        {

            foreach (Observer observer in lstObservers)

            {

                lstObservers.Remove(observer);

            }

        }

        public abstract void Notify();

    }
    public abstract class Observer

    {

        public abstract void Update();

    }
}
