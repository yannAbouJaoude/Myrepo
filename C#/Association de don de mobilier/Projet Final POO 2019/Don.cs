using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Don
    {
        private int reference;
        private string descriptionComplementaire;
        public string statue;
        public Objet marchandise;
        public DateTime reception;
        public Adherent responsableDuDossier;
        public Donateur donateur;
        private string type;
        public Don(Objet marchandise,string descriptionComplementaire,Donateur donateur, DateTime reception)
        {
            this.marchandise = marchandise;
            reference = marchandise.reference;
            string tmp = marchandise.GetType().ToString();
            type = "";
            for (int i = 22; i < tmp.Length; i++)
            {
                type += tmp[i];
            }
            this.descriptionComplementaire = descriptionComplementaire;
            statue = "En attente";
            this.donateur = donateur;
            this.reception = reception;
            marchandise.Date_Du_Depot = reception;
            Association.monAssociation.mesDon.Add(this);
        }
        public void vendre(Beneficiaire benef,int montant,DateTime date_De_Retrait)
        {
            marchandise.montant = montant; 
            marchandise.monBeneficiaire = benef;
            marchandise.emplacement.Retirer(marchandise,date_De_Retrait);
            statue = "vendu";
            marchandise.emplacement = null;
            Association.monAssociation.mesDon.Remove(this);
            Association.monAssociation.archives.Add(this);
        }
        public void donner( Beneficiaire benef, DateTime date_De_Retrait)
        {
            marchandise.montant = 0;
            marchandise.monBeneficiaire = benef;
            marchandise.emplacement.Retirer(marchandise, date_De_Retrait);
            statue = "donné";
            marchandise.emplacement = null;
            Association.monAssociation.mesDon.Remove(this);
            Association.monAssociation.archives.Add(this); ;
        }
        public void AccepterUnDon(bool accepter)
        {
            if (accepter)
            {
                List<string> descriptifAdherent = new List<string>();
                foreach (Adherent item in Association.monAssociation.mesAdherents)
                {
                    descriptifAdherent.Add(item.ToString());
                }
                statue = "accepté";
                responsableDuDossier = Menu.askAdherent("Quel est le membre responsable du don?");

                Deplacer();
            }
            else
            {
                statue = "refusé";
                Association.monAssociation.mesDon.Remove(this);
                Association.monAssociation.archives.Add(this);
            }
        }
        public void Deplacer()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Chez le donateur");
            maListe.Add("Dans le local de l'association");
            if (Association.monAssociation.monGardeMeuble == null)
            {
                maListe.Add("Ajouter un Garde Meuble");
            }
            else
            {
                maListe.Add("Dans le Garde Meuble");
            }
            if (Association.monAssociation.depotsDeVentes.Count() == 0)
            {
                maListe.Add("Ajouter un depot de vente");
            }
            else
            {
                maListe.Add("Dans un depot de Vente");
            }
            DateTime date_Du_Depot;
            DateTime date_De_Retrait;
            switch (Menu.LaunchMenu(maListe, "Ou souhaitez vous entreposer ce don?"))
            {
                case 0:
                    Association.monAssociation.StockerUnDon(this);
                    break;
                case 1:
                    donateur.maMaison.StockerUnDon(this);
                    break;
                case 2:
                    if (Association.monAssociation.monGardeMeuble == null)
                    {
                        Association.monAssociation.MajGardeMeuble();
                    }
                    Console.WriteLine("Quel est la date de dépot de l'objet dans le garde meuble?");
                    date_Du_Depot = Menu.askDateTime();
                    Console.WriteLine("Quel est la date de retrait de l'objet dans le garde meuble?");
                    date_De_Retrait = Menu.askDateTime();
                    while (date_Du_Depot > date_De_Retrait)
                    {
                        Console.WriteLine("La date de retrait est toujours ulterieur à la date de dépot.");
                        Console.WriteLine("Quel est la date de retrait de l'objet dans le garde meuble?");
                        date_De_Retrait = Menu.askDateTime();
                    }
                    Beneficiaire monBeneficiaire = Menu.askBeneficiaireExist();
                    Association.monAssociation.monGardeMeuble.StockerUnDon(this, date_Du_Depot, date_De_Retrait, monBeneficiaire);
                    statue = "stocke";
                    break;
                case 3:
                    if (Association.monAssociation.depotsDeVentes.Count() == 0)
                    {
                        Console.WriteLine("Cette association n'a pas encore de dépot de vente.");
                        Console.WriteLine("Procedons à l'acquisition d'un dépot de vente.");
                        Association.monAssociation.depotsDeVentes.Add(new DepotVente());
                    }
                    int tmp = 0;
                    if (Association.monAssociation.depotsDeVentes.Count() > 1)
                    {
                        List<string> maListe2 = new List<string>();
                        foreach (DepotVente x in Association.monAssociation.depotsDeVentes)
                        {
                            maListe2.Add(x.ToString());
                        }
                        tmp = Menu.LaunchMenu(maListe2, "Veuillez choisir un dépot de vente:");
                        if (tmp == maListe2.Count())
                        {
                            Menu.MenuDon();
                            Menu.Quitter();
                        }
                    }
                    Console.WriteLine("Quel est la date de dépot de l'objet dans le dépot de vente ?");
                    date_Du_Depot = Menu.askDateTime();
                    Console.WriteLine("Quel est la date de retrait de l'objet dans le dépot de vente ?");
                    date_De_Retrait = Menu.askDateTime();
                    while (date_Du_Depot > date_De_Retrait)
                    {
                        Console.WriteLine("La date de retrait est toujours ulterieur à la date de dépot.");
                        Console.WriteLine("Quel est la date de retrait de l'objet dans le dépot de vente ?");
                        date_De_Retrait = Menu.askDateTime();
                    }
                    Console.WriteLine("Quel est le prix de l'objet?");
                    int montant = Menu.askInt(0, 800000);
                    Association.monAssociation.depotsDeVentes[tmp].StockerUnDon(this, montant, date_Du_Depot, date_De_Retrait);
                    statue = "stocke";
                    break;
                case 4:
                    Menu.MenuDon();
                    Menu.Quitter();
                    break;
            }
            Console.WriteLine("Le don a été déplacer avec succès");
            Console.ReadKey();
        }
        public int getRef()
        {
            return reference;
        }
       /// <summary>
       /// Renvoie une description concise d'un don,ideal pour l'afficher dans un Menu.
       /// </summary>
       /// <returns></returns>
        public override string ToString()
        {
            return "Reference: "+reference+" Nature: " + type + " Donateur: " + donateur.nom + " " + donateur.prenom+" Date de reception: "+reception + " "+descriptionComplementaire;
        }
        /// <summary>
        /// Appel une description de chaque élément du don pour en faire une description complete.
        /// </summary>
        /// <returns></returns>
        public string CompleteToString()
        {
            string result = "Reference: " + reference + "\n";
            result += "Statue:" + statue + "\n";
            result += "Donateur: " + donateur.ToString() + "\n";
            result += "Objet: " + marchandise.ToString();
            if (marchandise.Date_Du_Depot != reception)
            {
                result += "Date de la donation: " + reception + "\n";
            }
            result+= "\n"+descriptionComplementaire;
            return result;
        }

    }
}
