using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Beneficiaire:Personne_physique
    {
        public DateTime naissance;
        public Beneficiaire(DateTime naissance,string prenom, int identifiant, string nom, string adresse, string telephone):base(prenom,identifiant,nom,adresse,telephone)
        {
            this.naissance = naissance;
            Association.monAssociation.mesBeneficiaires.Add(this);
        }
        public Beneficiaire(DateTime naissance, string prenom, string nom, string adresse, string telephone) : base(prenom, Association.monAssociation.compteur, nom, adresse, telephone)
        {
            this.naissance = naissance;
            Association.monAssociation.compteur++;
            Association.monAssociation.mesBeneficiaires.Add(this);
        }
        public Beneficiaire() : base()
        {
            Console.WriteLine("Veuillez entrerla date de naissance du bénéficiaire ");
            naissance = Menu.askDateTime();
            identifiant = Association.monAssociation.compteur;
            Association.monAssociation.mesBeneficiaires.Add(this);
        }
        public static List<Beneficiaire> Lire(string fichier)
        {
            int counter = 0;
            string line;
            List<Beneficiaire> retour = new List<Beneficiaire>();
            System.IO.StreamReader file = new System.IO.StreamReader(fichier);
            while ((line = file.ReadLine()) != null)
            {        
                string[] info = new string[4];
                int j = 0;
                for (int i = 2; i < line.Length - 11; i++)
                {
                    info[j] = "";
                    while (line[i] != ';' && line[i] != ':' && i != line.Length - 11)
                    {
                        info[j] += line[i];
                        i++;
                    }
                    j++;
                }
                string jour = "" + line[line.Length - 10] + line[line.Length - 9];
                string mois = "" + line[line.Length - 7] + line[line.Length - 6];
                string annee = "" + line[line.Length - 4] + line[line.Length - 3] + line[line.Length - 2] + line[line.Length - 1];
                if (j == 4)
                {
                    retour.Add(new Beneficiaire(new DateTime(int.Parse(annee), int.Parse(mois), int.Parse(jour)), info[3], Association.monAssociation.compteur, info[0], info[1], info[2]));
                    counter++;
                    Association.monAssociation.compteur++;
                }
            }
            file.Close();
            Console.WriteLine("La lecture du fichier " + fichier + " a permis l'acquision des données de " + counter + " adhérent(s)");
            return retour;
        }
        public override string ToString()
        {
            return base.ToString()+"Naissance: "+naissance;
        }
    }
}
