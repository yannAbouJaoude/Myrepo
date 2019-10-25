using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Adherent:Personne_physique
    {
        private string fonction;
        public string Fonction{ get; set; }
        public Adherent(string fonction, string prenom, string nom, string adresse, string telephone) : base(prenom, Association.monAssociation.compteur, nom, adresse, telephone)
        {
            this.fonction = fonction;
            Association.monAssociation.compteur++;
            if (fonction != "fantome")
            {
                Association.monAssociation.mesAdherents.Add(this);
            }
        }
        public Adherent():base()
        {
            fonction = "membre";
            identifiant = Association.monAssociation.compteur;
            Association.monAssociation.compteur++;
            Association.monAssociation.mesAdherents.Add(this);
        }
        public static List<Adherent> Lire(string fichier)
        {
            int counter = 0;
            string line;
            List<Adherent> retour = new List<Adherent>();
            System.IO.StreamReader file = new System.IO.StreamReader(fichier);
            while ((line = file.ReadLine()) != null)
            {
                
                int identifiant = line[0];
                string[] info = new string[6];
                int j = 0;
                for (int i = 2; i < line.Length; i++)
                {
                    info[j] = "";
                    
                    
                    while (line[i] != ';' && line[i] != ':'&&i < line.Length - 1)
                    {
                        info[j] += line[i];
                        i++;
                    }                
                    
                    j++;
                }
                info[4]+=line[line.Length-1];
                if (j == 5)
                {
                    if (identifiant == Association.monAssociation.compteur)
                    {
                        Console.WriteLine("Warning 201: L'identifiant de l'adhérent a été modifié afin de ne pas écraser un ancien adhérent");
                    }
                    retour.Add(new Adherent(info[4], info[3], info[0], info[1], info[2]));
                    counter++;
                }
            }
            file.Close();
            Console.WriteLine("La lecture du fichier " + fichier + " a permis l'acquision des données de " + counter + " adhérent(s)");
            return retour;
        }
        public override string ToString()
        {
            return base.ToString() + "Fonction: " + fonction;
        }
        
    }
}
