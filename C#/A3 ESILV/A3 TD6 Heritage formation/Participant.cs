using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class Participant
    {
        private int id;
        public string nom;
        private string adresse;
        private string telephone;
        public Participant(int id, string nom, string adresse, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.telephone = telephone;
        }

    }
}
