using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Final_POO_2019
{
    [Serializable]
    class Association:Personne_Morale,IMoyenne
    {

        public List<Beneficiaire> mesBeneficiaires;
        public List<Adherent> mesAdherents;
        public List<DepotVente> depotsDeVentes;
        public Garde_Meuble monGardeMeuble;
        public List<Don> mesDon;
        public List<Don> archives;
        public static Association monAssociation;//l'intégralité de l'association est stocké dans cette variable
        public int compteur;
        public Donateur remplacantMembreCongedie;

        public Association(string nom,string adresse, string telephone):base("Association",nom,adresse,telephone)
        {
            this.nom = nom;
            mesAdherents = new List<Adherent>();
            mesBeneficiaires = new List<Beneficiaire>();
            depotsDeVentes = new List<DepotVente>();
            mesDon = new List<Don>();
            archives = new List<Don>();
            monAssociation = this;
            compteur = 0;
            remplacantMembreCongedie = new Donateur("fantome", "", "Ce membre remplace les membres congedier", "", "");
        }
        
 
        public Adherent rechercheAdherentId(int identifiant)
        {
            return mesAdherents.Find(x => x.getId() == identifiant);
        }
        public int nombreDePropositionDeDonRecuTotal()
        {
            return archives.Count() + mesDon.Count();
        }
        public void MajGardeMeuble()
        {           
            if (monGardeMeuble == null)
            {
                Console.WriteLine("Votre association n'a pas encore de garde Meuble.");
                Console.WriteLine("Votre association fait l'acquisition d'un garde meuble");
                monGardeMeuble = new Garde_Meuble();
                Console.WriteLine("Votre association possede désormais un garde Meuble, Félicitation");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Vous souhaiter deplacer votre garde meuble");
                Garde_Meuble tmp = new Garde_Meuble();
                tmp.inventaire = monGardeMeuble.inventaire;
                monGardeMeuble = tmp;
                Console.WriteLine("Des bénévoles sont partie déménager le contenu de votre ancien garde meuble vers le nouveau");
                Console.WriteLine("Votre association possede désormais un garde Meuble tout neuf, Félicitation");
                Console.ReadKey();
            }
        }
        public void congedier(Adherent jeter)
        {
            List<Don> tmp = mesDon.FindAll(x => x.responsableDuDossier == jeter);
            foreach(Don x in tmp)
            {
                x.responsableDuDossier = remplacantMembreCongedie;
            }
            if (typeof(Donateur)== jeter.GetType()){
                Donateur temp = (Donateur)jeter;
                foreach(Objet x in temp.maMaison.inventaire)
                {
                    inventaire.Add(x);
                    Console.WriteLine("L'objet suivant appartiennant a l'association à été trouvé chez le congédié");
                    Console.WriteLine("Cette objet a été deplacer dans le local de l'association");
                    Console.WriteLine(x.ToString());
                    x.emplacement = monAssociation;
                }
                tmp = mesDon.FindAll(x => x.donateur == jeter);
                foreach (Don x in tmp)
                {
                    x.donateur = remplacantMembreCongedie;
                }
            }
            mesAdherents.Remove(jeter);
        }
        public void exclure(Beneficiaire jeter)
        {
            List<Don> tmp = mesDon.FindAll(x => x.marchandise.monBeneficiaire == jeter);
            foreach(Don x in tmp)
            {
                x.marchandise.monBeneficiaire = null;
            }
            mesBeneficiaires.Remove(jeter);
        }
        /// <summary>
        /// Moyenne est implémenter via l'interfaçe IMoyenne. l'utilisation d'une interface estici completement inutil,si ce n'est pour repondre au besoin du sujet
        /// </summary>
        /// <returns></returns>
        public double Moyenne()
        {
            double sum = 0;
            foreach (Beneficiaire x in mesBeneficiaires)
            {
                sum += DateTime.Today.Year - x.naissance.Year;
            }
            return sum / mesBeneficiaires.Count();
        }

        public string maxEnStock()
        {
            int electromenager=0;
            int mobilierChambre=0;
            int mobilierSalleCuisine=0;
            int vaisselle=0;
            string max = "";
            int maxi = 0;
            List<Personne_Morale> tmp = new List<Personne_Morale>();
            tmp.Add(this);
            if (monGardeMeuble != null)
            {              
                tmp.Add(monGardeMeuble);
            }          
            foreach (DepotVente x in depotsDeVentes)
            {
                tmp.Add(x);
            }
            foreach(Personne_Morale x in tmp) {
                foreach (Object y in x.inventaire)
                {
                    if(y is Mobilier_Chambre)
                    {
                        mobilierChambre++;
                    }
                    if (y is Mobilier_Salle_Cuisine)
                    {
                        mobilierSalleCuisine++;
                    }
                    if (y is Electromenager)
                    {
                        electromenager++;
                    }
                    if (y is Vaisselle)
                    {
                        vaisselle++;
                    }
                }            
            }
            if (mobilierChambre == maxi)
            {
                max += "Mobilier de Chambre ";
            }
            else if (mobilierChambre > maxi)
            {
                max = "Mobilier de Chambre "; maxi = mobilierChambre;
            }
            if (mobilierSalleCuisine == maxi)
            {
                max += "et Mobilier de Salle ou de Cuisine ";
            }
            else if (mobilierSalleCuisine > maxi)
            {
                max = "Mobilier de Salle ou de Cuisine "; maxi = mobilierSalleCuisine;
            }
            if (electromenager == maxi)
            {
                max += "et Appareil electromenager ";
            }
            else if (electromenager > maxi)
            {
                max = "Appareil electromenager "; maxi = electromenager;
            }
            if (vaisselle == maxi)
            {
                max += "et Vaisselle ";
            }
            else if (vaisselle > maxi)
            {
                max = "Vaisselle "; maxi = vaisselle;
            }
            return max+"avec "+maxi+" objets.";
        }
    }
}
