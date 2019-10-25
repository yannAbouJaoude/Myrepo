using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{
    class Leprechaun:Observer
    {
        int numero;
        public Leprechaun(int numero)
        {
            this.numero = numero;
        }
        override public void Update()
        {
            Console.WriteLine("Leprechaune numero " + numero + " a reçu une notification et est devenu tout bleu!");
        }
    }
}
