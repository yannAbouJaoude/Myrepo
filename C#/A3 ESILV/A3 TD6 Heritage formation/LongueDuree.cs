using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class LongueDuree : Formation
    {
        private List<Formateur> listeDesFormateurs;
        public LongueDuree(List<Formateur> listeDesFormateurs,int dureeEnJour ,string nom,List<Participant>listeDesParticipants) : base(nom, listeDesParticipants)
        {
            this.listeDesFormateurs = listeDesFormateurs;
            cout = 200*dureeEnJour;
        }
    }
}
