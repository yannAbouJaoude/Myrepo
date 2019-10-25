using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_POO_2019_Exercice_3
{
    class AvecStage : Formation
    {
        private List<Entreprise> listeDesEntreprises;
        public AvecStage(List<Entreprise> listeDesEntreprises, string nom, List<Participant> listeDesParticipants) : base(nom, listeDesParticipants)
        {
            this.listeDesEntreprises = listeDesEntreprises;
            cout = 0;
        }
        private void TrieParEntreprise()
        {
            listeDesEntreprises.Sort(delegate (Entreprise x, Entreprise y)
            {
                return x.nom.CompareTo(y.nom);
            });
        }
        public string entrepriseToString()
        {
            string retour = "";
            foreach (Entreprise i in listeDesEntreprises)
            {
                retour += i.ToString() + "\n";
            }
            return retour;
        }
    }
}
