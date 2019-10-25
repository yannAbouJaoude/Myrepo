using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class CourteDuree:Formation
    {
        private List<string> listeDesMatieres;
        public CourteDuree(List<string> listeDesMatieres, string nom, List<Participant> listeDesParticipants) : base(nom, listeDesParticipants)
        {
            this.listeDesMatieres = listeDesMatieres;
            cout = 175*listeDesMatieres.Count();
        }
    }
}
