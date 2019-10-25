using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    abstract class Formation
    {
        public string nom;
        protected List<Participant> listeDesParticipants;
        public int nombreDeParticipant;
        protected int cout;

        public Formation(string nom, List<Participant> listeDesParticipants)
        {
            this.nom = nom;
            nombreDeParticipant = listeDesParticipants.Count();
            this.listeDesParticipants = listeDesParticipants;
        }

        private void TrieParNom()
        {
            listeDesParticipants.Sort(delegate (Participant x, Participant y)
            {
                return x.nom.CompareTo(y.nom);
            });
        }
        public string participantToString()
        {
            string retour = "";
            foreach(Participant i in listeDesParticipants)
            {
                retour += i.nom + "\n";
            }
            return retour;
        }
        public int getCout()
        {
            return cout;
        }

    }
}
