using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_info_A2S2
{
    class Mypixel
    {
        private byte rouge;
        private byte vert;
        private byte bleu;

        public Mypixel(byte rouge, byte vert, byte bleu)
        {

            this.rouge  =rouge;
            Console.WriteLine(this.rouge+"numero 2 ");
            this.vert = vert;
            this.bleu = bleu;
        }
        public byte Rouge
        {
            
 
             get {
                Console.WriteLine(rouge);
                return rouge; }
        }
        public byte Vert
        {
            get { return vert; }
        }
        public byte Bleu
        {
            get { return bleu; }
        }
    }
}
