using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019
{
    class Evaluation
    {
        public double[] cc;
        public double examen;
        public Evaluation(double[]cc, double examen)
        {
            this.cc = cc;
            this.examen = examen;
        }
        public delegate double methode();
        public double A()
        {
            return (cc.Sum() + examen)/(cc.Length+1);
        }
        public double B()
        {
            return cc.Average()*0.4+(examen*0.6);
        }
        public double C()
        {
            int pasZero = 1;// l'examen est compté même si c'est un 0
            foreach(double a in cc)
            {
                if (a != 0)
                {
                    pasZero++;
                }
            }
            return (cc.Sum() + examen) / pasZero;
        }
        public double CalculNoteFinale(methode T)
        {
            return T();
        }

    }
}
