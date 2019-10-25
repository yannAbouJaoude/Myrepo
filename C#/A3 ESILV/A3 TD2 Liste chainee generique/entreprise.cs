using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TD3_POO_liste_generique
{
    class entreprise
    {
        private static int nbTotalRecrutement;// pas toujours égale au nombre d'employé, ne diminue pas avec les licenciements
        private string nom;
        private string siegeSocial;
        private ListeChaine<Salarie> personnel;

        public entreprise(string nom, string siegeSocial)
        {
            this.nom = nom;
            this.siegeSocial = siegeSocial;
            nbTotalRecrutement = 0;
            personnel = new ListeChaine<Salarie>();
           
        }
        public string GetNom()
        {
            return nom;
        }
        public string GetSiegeSocial()
        {
            return siegeSocial;
        }
        public ListeChaine<Salarie> GetPersonnel()
        {
            return personnel;
        }
        public void recrutement(Salarie recrue)
        {
            Console.WriteLine(recrue.GetPrenom());
           
            personnel.AddQueue(recrue);
            
            
            recrue.SetNumero(nbTotalRecrutement);
            nbTotalRecrutement ++;
        }
        private void removePersonnel(int pos)
        {
            personnel.Remove(pos);
        }
        private void licenciement(string donnee)
        {
            for (int i = 0; i < personnel.Count(); i++)
            {
                if (personnel.get(i).data.GetEmail()==donnee|| personnel.get(i).data.GetPrenom() == donnee || personnel.get(i).data.GetNom() == donnee || personnel.get(i).data.GetAdressePostale() == donnee || personnel.get(i).data.GetNumero().ToString() == donnee)
                {
                    removePersonnel(i);
                    Console.WriteLine("Un damné de la terre a subit le courroux de la vile bourgeoisie");
                }
            }
        }


    }
}
