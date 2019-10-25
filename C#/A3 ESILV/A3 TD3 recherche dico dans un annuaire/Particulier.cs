using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_annuaire
{
    class Particulier
    {
        private string numero;
        private string prenom;

        public Particulier(string numero, string prenom)
        {
            this.numero = numero;
            this.prenom = prenom;
        }
        public string GetPrenom()
        {
            return prenom;
        }
        public string GetNumero()
        {
            return numero;
        }
    }
}
