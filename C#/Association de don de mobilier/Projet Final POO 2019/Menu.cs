using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projet_Final_POO_2019
{
    class Menu
    {
        /// <summary>
        /// Prend une liste de choix et le titre du menu (question posé a l'utilisateur )
        /// renvoie un entier pour un switch case
        /// </summary>
        /// <param name="maListe"></param>
        /// <param name="titre"></param>
        /// <returns></returns>
        public static int LaunchMenu(List<string> maListe, string titre)
        {
            Console.Clear();
            maListe.Add("Quitter");
            bool resterDansLeMenu = true;
            ConsoleKey choix;
            int positionMenu = 0;
            Console.WriteLine(titre);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(maListe[0]);
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 1; i < maListe.Count(); i++)
            {                            
                Console.WriteLine(maListe[i]);
            }
            while (resterDansLeMenu)
            {
                choix = Console.ReadKey().Key;
                Console.Clear();

                if (choix == ConsoleKey.UpArrow && positionMenu > 0) { positionMenu--; }
                if (choix == ConsoleKey.DownArrow && positionMenu < maListe.Count() - 1) { positionMenu++; }
                if (choix == ConsoleKey.Enter)
                {
                   // Console.Clear();
                    return positionMenu;
                }
                Console.WriteLine(titre);
                for (int i = 0; i < maListe.Count(); i++)
                {
                    if (i == positionMenu)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(maListe[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
             }
             return 0;
        }
        public static void MenuPrincipal()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Module Don");
            maListe.Add("Module Personne");
            maListe.Add("Module Tris");
            maListe.Add("Module Statistique");
            maListe.Add("Module Autre");
            switch (LaunchMenu(maListe,"Menu Principal: "))
            {
                case 0:
                    MenuDon();
                    break;
                case 1:
                    MenuPersonne();
                    break;
                case 2:
                    MenuTris();
                    break;
                case 3:
                    MenuStatistiques();
                    break;
                case 4:
                    MenuAutre();
                    break;
                case 5:
                    Quitter();
                    break;
            }
        }
        public static void MenuDon()
        {
            Objet tmpMarchandise;
            string tmpDescription;
            Donateur tmpDonateur;
            DateTime tmpreception;
            Beneficiaire tmpBenef;
            List<Don> donDispo;
            int reponse;
            List<string> maListe = new List<string>();
            maListe.Add("Recevoir un nouveau don");
            maListe.Add("Accepter un don");
            maListe.Add("Vendre un don");
            maListe.Add("Donner un don");
            maListe.Add("Deplacer un don");
            maListe.Add("Consulter l'état d'un don");
            List<string> maListe2 = new List<string>();
            List<string> maListe3 = new List<string>();
            int tmp;
            switch (LaunchMenu(maListe, "Gestion des propositions de dons: "))
            {
                case 0:              
                    tmpDonateur= askDonateur();
                    tmpMarchandise = askMarchandise("Quel genre de marchandise souhaitez vous donner?");
                    Console.WriteLine("Veuillez ajouter ne breve description complémentaire a votre don");
                    tmpDescription = Console.ReadLine();
                    Console.WriteLine("Quel est la date de ce don?");
                    tmpreception = askDateTime();
                    Don a = new Don(tmpMarchandise, tmpDescription, tmpDonateur , tmpreception);

                    break;
                case 1:
                    List<Don>mesDonEnAttente = Association.monAssociation.mesDon.FindAll(x => x.statue == "En attente");                   
                    foreach(Don x in mesDonEnAttente)
                    {
                        maListe2.Add(x.ToString());
                    }
                    maListe3.Add("OUI");
                    maListe3.Add("NON");
                    bool accepter=true;
                    int tmp1 = LaunchMenu(maListe2, "Quel don voulez vous Traiter?");
                    if (tmp1 == maListe2.Count()-1)
                    {
                        MenuDon();
                        Quitter();// On n'arrivera normalement jamais a ce genre de "quitter()", il est là juste en cas l'erreur
                    }
                    switch (LaunchMenu(maListe3, "Voulez vous accepter ce don?"))
                    {
                        case 0:
                            accepter = true;
                            break;
                        case 1:
                            accepter = false;
                            break;
                        case 2:
                            MenuDon();
                            Quitter();
                            break;
                    }
                    mesDonEnAttente[tmp1].AccepterUnDon(accepter);
                    break;
                case 2:
                    tmpBenef = askBeneficiaireExist();
                    maListe2 = new List<string>();
                    donDispo = Association.monAssociation.mesDon.FindAll(x => x.statue == "Stocke" || x.statue == "Accepter");
                    foreach (Don y in donDispo)
                    {
                        maListe2.Add(y.ToString());
                    }
                    tmp = LaunchMenu(maListe2, "Quel don souhaiter vous vendre?");
                    if (tmp == maListe2.Count-1)
                    {
                        MenuDon();
                        Quitter();
                    }
                    Console.WriteLine("Quel est la date d'obtention de ce don par le bénéficiaire? ");
                    tmpreception = askDateTime();
                    int tmpMontant= donDispo[tmp].marchandise.montant;
                    switch(LaunchMenu(new List<string> {"Vendre au prix proposé","Je choisis mon prix"},"Le prix de vente conseillé est "+ tmpMontant+" euros: "))
                    {
                        case 1: tmpMontant = askInt(0, 800000);
                            break;
                        case 2:
                            MenuDon();
                            Quitter();
                            break;
                    }
                    donDispo[tmp].vendre(tmpBenef,tmpMontant, tmpreception);
                    Console.WriteLine("Le don a été vendu");
                    Console.ReadKey();
                    break;
                case 3:
                    tmpBenef = askBeneficiaireExist();
                    maListe2 = new List<string>();
                    donDispo = Association.monAssociation.mesDon.FindAll(x => x.statue == "Stocke" || x.statue == "Accepter");
                    foreach(Don y in donDispo)
                    {
                        maListe2.Add(y.ToString());
                    }
                    tmp = LaunchMenu(maListe2, "Quel don souhaiter vous donner?");
                    if (tmp == maListe2.Count)
                    {
                        MenuDon();
                        Quitter();
                    }
                    Console.WriteLine("Quel est la date d'obtention de ce don par le bénéficiaire? ");
                    tmpreception = askDateTime();
                    donDispo[tmp].donner(tmpBenef, tmpreception);
                    Console.WriteLine("Le don a été donné");
                    
                    break;
                case 4:
                    foreach (Don x in Association.monAssociation.mesDon)
                    {
                        maListe2.Add(x.ToString());
                    };
                    tmp = LaunchMenu(maListe2, "Quel don voulez vous deplacer?");
                    if (tmp == maListe2.Count())
                    {
                        MenuDon();
                        Quitter();
                    }
                    if (Association.monAssociation.mesDon[tmp].statue=="En attente")
                    {
                        Console.WriteLine("Ce don n'a pas encore été accepter.");
                        Console.WriteLine("Il doit d'abord être accepter pour être stocké.");
                        if (LaunchMenu(new List<string>{"Poursuivre"},"Souhaitez vous que l'association accepte ce don?") == 0)
                        {
                            Console.WriteLine("Très bien, ce don est désormais accepté.");
                            Association.monAssociation.mesDon[tmp].AccepterUnDon(true);
                        }
                        else
                        {
                            MenuDon();
                            Quitter();
                        }
                    }
                    else
                    {
                        Association.monAssociation.mesDon[tmp].Deplacer();
                    }                   
                    break;
                case 5:
                    foreach (Don x in Association.monAssociation.mesDon)
                    {
                        maListe2.Add(x.ToString());
                    }
                    int pasArchive = maListe2.Count();
                    foreach (Don x in Association.monAssociation.archives)
                    {
                        maListe2.Add(x.ToString());
                    }
                    reponse = LaunchMenu(maListe2, "Choisissez un don à consulter");
                    if(reponse==maListe2.Count()-1)
                    {
                        MenuDon();
                        Quitter();
                    }
                    if (reponse<pasArchive)
                    {
                        Console.WriteLine(Association.monAssociation.mesDon[reponse].CompleteToString());
                    }
                    else
                    {

                        Console.WriteLine(Association.monAssociation.archives[reponse-pasArchive].CompleteToString());
                        
                    }
                    
                    break;
            }
            Console.ReadKey();
            MenuPrincipal();        
        }
        public static void MenuPersonne()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Charger une liste d'adherents");
            maListe.Add("Charger une liste de beneficiaires");
            maListe.Add("Inscrire un membre");
            maListe.Add("Rechercher un beneficiaire par telephone");
            maListe.Add("Rechercher un beneficiaire par nom");
            maListe.Add("Rechercher un adherent par nom");
            maListe.Add("Congedier un Adherent");
            maListe.Add("Exclure un Beneficiaire");
            maListe.Add("Modifier les informations personnels d'un Adherent");
            string fichier;
            switch(LaunchMenu(maListe,"Module Personne"))
            {
                case 0:
                    Console.WriteLine("Veuillez entrer le nom du fichier à charger");
                    fichier = "Adherents.txt";
                    Console.WriteLine("Vous avez choisis de charger <<Adherents.txt>>");
                    Adherent.Lire(fichier);
                    break;
                case 1:
                    Console.WriteLine("Veuillez entrer le nom du fichier à charger");
                    fichier = "Beneficiaires.txt";
                    Console.WriteLine("Vous avez choisis de charger <<Beneficiaires.txt>>");
                    Beneficiaire.Lire(fichier);
                    break;
                case 2:
                    Console.WriteLine("Vous souhaitez inscrire un membre");
                    Adherent a = new Adherent();
                    Console.WriteLine("Voici le résumé du nouvel adhérent: ");
                    Console.WriteLine(Association.monAssociation.mesAdherents[Association.monAssociation.mesAdherents.Count()-1].ToString());
                    break;
                case 3:
                    Console.WriteLine("Vous recherchez un bénéficiaire grâce a son numero de telephone");
                    Console.WriteLine("Veuillez entrer un numero");
                    string telephone = Console.ReadLine();
                    List<Beneficiaire> benef =Association.monAssociation.mesBeneficiaires.FindAll(x => x.telephone == telephone);
                    Console.WriteLine("Nous avons trouvé " + benef.Count() + " resultats");
                    foreach(Beneficiaire x in benef)
                    {
                        Console.WriteLine(x.ToString());
                    }
                    break;
                case 4:
                    Console.WriteLine("Vous recherchez un bénéficiaire grâce a son nom");
                    Console.WriteLine("Veuillez entrer un nom");
                    string nom1 = Console.ReadLine();
                    List<Beneficiaire> benef1 = Association.monAssociation.mesBeneficiaires.FindAll(x => x.nom == nom1);
                    Console.WriteLine("Nous avons trouvé " + benef1.Count() + " resultats");
                    foreach (Beneficiaire x in benef1)
                    {
                        Console.WriteLine(x.ToString());
                    }
                    break;
                case 5:
                    Console.WriteLine("Vous recherchez un adhérent grâce a son nom");
                    Console.WriteLine("Veuillez entrer un nom");
                    string nom2 = Console.ReadLine();
                    List<Adherent> adhe = Association.monAssociation.mesAdherents.FindAll(x => x.nom == nom2);
                    Console.WriteLine("Nous avons trouvé " + adhe.Count() + " resultats");
                    foreach (Adherent x in adhe)
                    {
                        Console.WriteLine(x.ToString());
                    }
                    break;
                case 6:
                    Adherent jeter = askAdherent("Quel adherent souhaitez vous congedier?");
                    Association.monAssociation.congedier(jeter);
                    Console.WriteLine("Vous n'entendrez plus parler de lui.");
                    break;
                case 7:
                    Beneficiaire exclu = askBeneficiaire("Quel bénéficiaire souhaitez vous exclure?");
                    Association.monAssociation.exclure(exclu);
                    Console.WriteLine("Vous n'entendrez plus parler de lui.");                  
                    break;
                case 8:
                    MenuChangementDonneePersonnel();
                    break;

            }
            Console.ReadKey();
            MenuPrincipal();
        }
        public static void MenuTris()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Dons Refusé trié par date");
            maListe.Add("Dons Accepté ou Stocké trié par identifiant");
            maListe.Add("Dons Accepté ou Stocké trié par nom du donateur");
            maListe.Add("Don Vendu ou Donnée trié par numéro de bénéficiaire");
            maListe.Add("Don Vendu ou Donnée selon un mois");
            maListe.Add("Observer l'inventaire d'un entrepot trié par catégorie");
            maListe.Add("Observer l'inventaire d'un entrepot trié par volume");
            maListe.Add("Observer l'inventaire d'un depot de vente trié par prix");
            List<Don> result = new List<Don>();
            switch (LaunchMenu(maListe,"Module Tris: "))
            {
                case 0:
                    Console.WriteLine("Dons Refusé trié par date: ");
                    result = Association.monAssociation.archives.FindAll(x => x.statue == "refusé");
                    result.Sort(delegate (Don z, Don y)
                    {
                        return z.reception.CompareTo(y.reception);
                    });
                    foreach(Don x in result)
                    {
                        Console.WriteLine(x.CompleteToString());
                    }
                    break;
                case 1:
                    Console.WriteLine("Dons Accepté ou Stocké trié par identifiant: ");
                    result = Association.monAssociation.mesDon.FindAll(x => x.statue == "accepté"|| x.statue == "stocke");
                    result.Sort(delegate (Don z, Don y)
                    {
                        return z.getRef().CompareTo(y.getRef());
                    });
                    foreach (Don x in result)
                    {
                        Console.WriteLine(x.CompleteToString());
                    }
                    break;
                case 2:
                    Console.WriteLine("Dons Accepté ou Stocké trié par nom du donateur: ");
                    result = Association.monAssociation.mesDon.FindAll(x => x.statue == "accepté" || x.statue == "stocke");
                    result.Sort(delegate (Don z, Don y)
                    {
                        return z.donateur.nom.CompareTo(y.donateur.nom);
                    });
                    foreach (Don x in result)
                    {
                        Console.WriteLine(x.CompleteToString());
                    }
                    break;
                case 3:
                    Console.WriteLine("Don Vendu ou Donnée trié par numéro de bénéficiaire: ");
                    result = Association.monAssociation.archives.FindAll(x => x.statue == "vendu" || x.statue == "donné");
                    result.Sort(delegate (Don z, Don y)
                    {
                        return z.marchandise.monBeneficiaire.getId().CompareTo(y.marchandise.monBeneficiaire.getId());
                    });
                    foreach (Don x in result)
                    {
                        Console.WriteLine(x.CompleteToString());
                    }
                    break;
                case 4:
                    Console.WriteLine("Don Vendu ou Donnée selon un mois: ");
                    Console.WriteLine("Quel est ce mois?");
                    Console.WriteLine("Entrez un moi 1-12");
                    int mois = askInt(1, 12);
                    Console.WriteLine("De quel année?");
                    int annee = askInt(1, 9000);
                    result = Association.monAssociation.archives.FindAll(x => (x.statue == "vendu" || x.statue == "donné")&&x.marchandise.Date_De_Retrait.Month==mois&&x.marchandise.Date_De_Retrait.Year==annee);
                    foreach (Don x in result)
                    {
                        Console.WriteLine(x.CompleteToString());
                    }
                    break;
                case 5:
                    Personne_Morale tmp = askPersonneMorale("De quel espace souhaitez vous consulter l'inventaire?");
                    tmp.inventaire.Sort(delegate (Objet z, Objet y)
                    {
                        return z.GetType().ToString().CompareTo(y.GetType().ToString());
                    });
                    Console.WriteLine("Observer l'inventaire d'un entrepot trié par catégorie");
                    foreach(Objet x in tmp.inventaire)
                    {
                        Console.WriteLine(x.ToString());
                    }
                    break;
                case 6:
                    Personne_Morale tmp2 = askPersonneMorale("De quel espace souhaitez vous consulter l'inventaire?");
                    Console.WriteLine("Voici l'inventaire de l' entrepot trié par volume");
                    foreach (Objet x in tmp2.TrisParVolume())
                    {
                        Console.WriteLine(x.ToString());//la vaisselle est inclue a la fin même si sont volume est nulle
                    }
                    break;
                case 7:
                    DepotVente tmp3 = askDepotVente("De quel dépot de vente souhaitez vous consulter l'inventaire?");
                    Console.WriteLine("Voici l'inventaire du dépot de vente trié par prix");
                    tmp3.inventaire.Sort(delegate (Objet z, Objet y)
                    {
                        return z.montant.CompareTo(y.montant);
                    });

                    foreach (Objet x in tmp3.inventaire)
                    {
                        Console.WriteLine(x.ToString());
                    }
                    break;
            }
            Console.ReadKey();
            MenuPrincipal();
        }
        public static void MenuStatistiques()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Consulter le temps moyen de stockage d'un objet dans un entrepot");
            maListe.Add("Calculer la moyenne des prix dans un depot de vente");
            maListe.Add("Calculer la moyenne d'age des beneficiaires");
            maListe.Add("Nombre de propositions de dons reçues en tout");
            maListe.Add("Nombre de propositions de dons reçues en attente");
            maListe.Add("Nombre de donateurs et de bénéficiaires");
            maListe.Add("Nombre de propositions de dons acceptées et ratio reçues/ acceptées pour les objets volumineux");
            maListe.Add("Volume des ventes suivant le dépot de vente");
            maListe.Add("Principales catégories d’articles en stock");
            double result;
            TimeSpan resultTime;

            switch(LaunchMenu(maListe,"Module Statistique"))
            {
                case 0:                   
                    resultTime=askPersonneMorale("De quel entrepot souhaitez vous observer le temps de stockage moyen?").MoyenneTempsStockage();
                    Console.WriteLine("Un Objet dans cette entrepot y séjourne en moyenne" + resultTime);
                    break;
                case 1:                  
                    result = askDepotVente("De quel dépot de ventet souhaitez vous observer le prix moyen?").Moyenne();
                    Console.WriteLine("Les objets de ce dépot de vente ont un prix moyen de " + result + " euros");
                    break;
                case 2:
                    Console.WriteLine("La moyenne d'age des beneficiaires est " + Association.monAssociation.Moyenne() + " ans");
                    break;
                case 3:
                    Console.WriteLine("Voici Le nombre de proposition de don reçu depuis l'ouverture de l'association: " + (Association.monAssociation.mesDon.Count()+ Association.monAssociation.archives.Count()));
                    break;
                case 4:
                    Console.WriteLine("Voici Le nombre de proposition de don reçu en attente" +Association.monAssociation.mesDon.FindAll(x=>x.statue== "En attente").Count());
                    break;
                case 5:
                    Console.WriteLine("Nombre de donateurs : "+ Association.monAssociation.mesAdherents.FindAll(x=>x is Donateur).Count());
                    Console.WriteLine("Nombre de bénéficiaires : "+ Association.monAssociation.mesBeneficiaires.Count());
                    break;
                case 6:
                    Console.WriteLine("Nombre de propositions de dons reçues: "+ (Association.monAssociation.mesDon.Count() + Association.monAssociation.archives.Count()));
                    Console.WriteLine("Nombre de propositions de dons acceptées: "+ (Association.monAssociation.mesDon.FindAll(x => x.statue != "En attente").Count() + Association.monAssociation.archives.FindAll(x => x.statue != "refusé").Count()));
                    int ovr= Association.monAssociation.mesDon.FindAll(x => x.marchandise is Objet_Volumineux).Count() + Association.monAssociation.archives.FindAll(x => x.marchandise is Objet_Volumineux).Count();
                    int ova = Association.monAssociation.mesDon.FindAll(x => x.statue != "En attente" && x.marchandise is Objet_Volumineux).Count() + Association.monAssociation.archives.FindAll(x => x.statue != "refusé" && x.marchandise is Objet_Volumineux).Count();
                    Console.WriteLine("Nombre de propositions de dons contenant des objets volumineux reçues: " + ovr);
                    Console.WriteLine("Nombre de propositions de dons contenant des objets volumineux acceptées:"+ ova);
                    Console.WriteLine("Soit un ratio acceptées/reçues pour les objets volumineux de " + ((double)ova/ovr)*100 +"%");
                    break;
                case 7:
                    double sum = 0;
                    foreach(Objet_Volumineux y in askDepotVente("De quel depot de vente souhaitez vous connaitre le volume de vente?").inventaire)
                    {
                        sum += y.hauteur * y.largeur * y.longueur;
                    }
                    Console.WriteLine("Le volume de vente dans ce dépot de vente est: "+sum+"mètres cube");

                    break;
                case 8:
                    Console.WriteLine("Voici la/les catégories d'objet les plus réprésenté: ");
                    Console.WriteLine(Association.monAssociation.maxEnStock());
                    break;
        }
            Console.ReadKey();
            MenuPrincipal();
        }
        public static void MenuAutre()
        {
            List<string> maListe = new List<string>();
            maListe.Add("Supprimer les doublons de personnes");
            maListe.Add("Modifier le nom de l'association");
            maListe.Add("Elire le président et le trésorier");
            maListe.Add("Quitter sans enregistrer");
            maListe.Add("Créer une nouvelle association");
            maListe.Add("Ajouter un depot de vente");
            switch(LaunchMenu(maListe,"Module Autre"))
            {
                case 0:
                    Console.WriteLine("Suppression des doublons de personnes");
                    Association.monAssociation.mesAdherents.Sort(delegate (Adherent x, Adherent y)
                    {
                        return x.nom.CompareTo(y.nom);
                    });
                    Association.monAssociation.mesBeneficiaires.Sort(delegate (Beneficiaire x, Beneficiaire y)
                    {
                        return x.nom.CompareTo(y.nom);
                    });
                    int i = 0;
                    while ( i < Association.monAssociation.mesAdherents.Count()-1)
                    {
                        if (Association.monAssociation.mesAdherents[i].nom == Association.monAssociation.mesAdherents[i + 1].nom && Association.monAssociation.mesAdherents[i].prenom == Association.monAssociation.mesAdherents[i + 1].prenom)
                        {
                            Console.WriteLine("Cette adhérent a été trouvé en double, son doublon a été supprimé");
                            Console.WriteLine(Association.monAssociation.mesAdherents[i + 1].ToString());
                            Association.monAssociation.congedier(Association.monAssociation.mesAdherents[i + 1]);
                            i--;
                        }
                        i++;
                    }
                    i =0;
                    while (i < Association.monAssociation.mesBeneficiaires.Count() - 1)
                    {
                        if (Association.monAssociation.mesBeneficiaires[i].nom == Association.monAssociation.mesBeneficiaires[i + 1].nom && Association.monAssociation.mesBeneficiaires[i].prenom == Association.monAssociation.mesBeneficiaires[i + 1].prenom)
                        {
                            Console.WriteLine("Ce bénéficiaire a été trouvé en double, son doublon a été supprimé");
                            Console.WriteLine(Association.monAssociation.mesBeneficiaires[i + 1].ToString());
                            Association.monAssociation.exclure(Association.monAssociation.mesBeneficiaires[i + 1]);
                            i--;
                        }
                        i++;
                    }
                    break;
                case 1:
                    Console.WriteLine("Quel sera le nouveau nom de l'association?");
                    Association.monAssociation.nom = Console.ReadLine();
                    Console.WriteLine("L'association s'appel désormais "+ Association.monAssociation.nom);
                    break;
                case 2:
                    Adherent president = askAdherent("Qui sera le nouveau président ?");
                    foreach(Adherent y in Association.monAssociation.mesAdherents.FindAll(x => x.Fonction == "president"))
                    {
                        y.Fonction = "membre";
                    }
                    president.Fonction = "president";
                    Console.WriteLine("Ce membre est désormais président");
                    Console.WriteLine(president.ToString());
                    Console.ReadKey();
                    Adherent tresorier = askAdherent("Qui sera le nouveau trésorier ?");
                    foreach (Adherent y in Association.monAssociation.mesAdherents.FindAll(x => x.Fonction == "tresorier"))
                    {
                        y.Fonction = "membre";
                    }
                    tresorier.Fonction = "tresorier";
                    Console.WriteLine("Ce membre est désormais trésorier");
                    Console.WriteLine(tresorier.ToString());
                    break;
                case 3:
                    Thread.CurrentThread.Abort();//#coupure de courant
                    break;
                case 4:
                    Console.WriteLine("Vous vous appretez à créer une nouvelle association");
                    Console.WriteLine("Cette opération est irréversible et supprimera l'intégralité des données");//Enfaite si c'est reversible sion quitte sans enregistrer :-)
                    Console.WriteLine("Pour continuer, entrez <<supprimer>>");
                    if (Console.ReadLine() == "supprimer")
                    {
                        Console.WriteLine("L'association a été supprimée");
                        Console.WriteLine("Entrez le nom de la nouvelle association");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Entrez l'adresse de la nouvelle association");
                        string adresse = Console.ReadLine();
                        Console.WriteLine("Entrez le numéro de la nouvelle association");
                        string numero = Console.ReadLine();
                        Association monAssociation = new Association(nom, adresse, numero);
                    }
                    else
                    {
                        Console.WriteLine("Fort heureusement, vous avez choisis de conserver votre magnifique association");
                    }
                    break;
                case 5:
                    Console.WriteLine("Vous souhaitez ajouter un dépot vente");
                    Association.monAssociation.depotsDeVentes.Add(new DepotVente());
                    break;
                case 6:
                    MenuPrincipal();
                    break;
            }
            Console.ReadKey();
            MenuPrincipal();
        }

        public static void MenuChangementDonneePersonnel()
        {
            Adherent tmp = askAdherent("De quel adherent souhaitez vous modifier les données personnelles?");
            List<string> maListe = new List<string>();
            maListe.Add("Nom");
            maListe.Add("Prenom");
            maListe.Add("Adresse");
            maListe.Add("telephone");
            switch(LaunchMenu(maListe,"Que souhaitez vous modifier?"))
            {
                case 0:
                    Console.WriteLine("Veuillez entrez le nouveau nom");
                    tmp.nom = Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine("Veuillez entrez le nouveau prenom");
                    tmp.prenom = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Veuillez entrez la nouvelle adresse");
                    tmp.adresse = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Veuillez entrez le nouveau numero de telephone");
                    tmp.telephone = Console.ReadLine();
                    break;
            }
            MenuPrincipal();
        }

        private static Objet askMarchandise(string titre)
        {
            List<string> maListe = new List<string>();
            maListe.Add("Mobilier de Chambre");
            maListe.Add("Mobilier de Salle ou cuisine");
            maListe.Add("Electro-ménager");
            maListe.Add("Vaisselle");
            int userAnswer1 = LaunchMenu(maListe,titre);
            List<string> maListe2= new List<string>();
            int userAnswer2;
            switch (userAnswer1)
            {
                case 0:
                    maListe2.Add("Matelas");
                    maListe2.Add("Chevet");
                    maListe2.Add("Armoire");
                    break;
                case 1:
                    maListe2.Add("Table");
                    maListe2.Add("Chaise");
                    break;
                case 2:
                    maListe2.Add("Cuisiniere");
                    maListe2.Add("Réfrigérateur");
                    maListe2.Add("Lave-Linge");
                    break;
                case 3:
                    maListe2.Add("Couverts");
                    maListe2.Add("Assiettes");
                    break;
                case 4:
                    MenuDon();
                    Quitter();
                    break;          
            }
            userAnswer2 = LaunchMenu(maListe2, titre);
            if (userAnswer2 == maListe2.Count()-1)
                {
                MenuDon();
                Quitter();
                }
            double largeur=0;
            double longueur=0;
            double hauteur=0;
            int nombreDePieces=0;
            string type="erreur 105";
            string forme="erreur 106";
            int puissance=0;
            int nbDePlaques=0;
            if (userAnswer1 == 1 && userAnswer2 == 0)
            {
                List<string> maListe3 = new List<string>();
                maListe3.Add("Table de Cuisine");
                maListe3.Add("Table de Salon");
                switch(LaunchMenu(maListe3, titre))
                {
                    case 0:
                        type = "cuisine";
                        break;
                    case 1:
                        type = "salon";
                        break;
                    case 2:
                        return askMarchandise(titre);
                }
                maListe3 = new List<string>();
                maListe3.Add("Table de forme reclangulaire");
                maListe3.Add("Table de forme carrée");
                maListe3.Add("Table de forme ronde");
                switch (LaunchMenu(maListe3, titre))
                {
                    case 0:
                        forme = "rectangulaire";
                        break;
                    case 1:
                        forme = "carree";
                        break;
                    case 2:
                        forme = "ronde";
                        break;
                    case 3:
                        return askMarchandise(titre);
                }
            }
            if (userAnswer1 == 3)
            {
                Console.WriteLine("Combien souhaitez-vous en donner? ");
                nombreDePieces=askInt(0, 5000);
            }
            else
            {
                if (userAnswer1 == 2 && userAnswer2 == 0)
                {
                    Console.WriteLine("Quel est la puissance de votre cuisinière?");
                    puissance = askInt(0,9000);
                    Console.WriteLine("Combien de plaques compte votre cuisinière?");
                    puissance = askInt(0, 40);
                }
                Console.WriteLine("Votre objet est volumineux.");
                Console.WriteLine("Veuillez entrer sa largeur en mètre:");
                largeur = askDouble(0,50);
                Console.WriteLine("Veuillez entrer sa longueur en mètre:");
                longueur = askDouble(0,50);
                Console.WriteLine("Veuillez entrer sa hauteur en mêtre:");
                hauteur = askDouble(0,50);
            }
            Console.WriteLine("Veuillez ajouter une description a votre objet");
            string description = Console.ReadLine();
            switch (userAnswer1)
            {
                case 0: switch (userAnswer2)
                    {
                        case 0: return new Matelas(hauteur, largeur, longueur, description);
                        case 1: return new Chevet(hauteur, largeur, longueur, description);
                        case 2: return new Armoire(hauteur, largeur, longueur, description);
                    }
                    break;
                case 1:
                    switch (userAnswer2)
                    {
                        case 0: return new Table(type,forme,hauteur, largeur, longueur, description);
                        case 1: return new Chaise(hauteur, largeur, longueur, description);
                    }
                    break;
                case 2:
                    switch (userAnswer2)
                    {
                        case 0: return new Cuisiniere(hauteur, largeur, longueur, description,puissance,nbDePlaques);
                        case 1: return new Refrigerateur(hauteur, largeur, longueur, description);
                        case 2: return new Lave_Linge(hauteur, largeur, longueur, description);
                    }
                    break;
                case 3:
                    switch (userAnswer2)
                    {
                        case 0: return new Couvert(nombreDePieces,description);
                        case 1: return new Assiette(nombreDePieces, description);
                    }
                    break;
            }
            return new Matelas(0,0,0,"Erreur 107: echec de la création d'un objet parl'utilisateur");
        }
        /// <summary>
        /// Demande un donateur pour un nouveau don. Si le donateur n'existe pas, créé un donateur
        /// </summary>
        /// <returns></returns>
        private static Donateur askDonateur()
        {
            List<string> maListe = new List<string>();
            maListe.Add("OUI");
            maListe.Add("NON");
            switch(LaunchMenu(maListe,"Le donateur est-il deja membre de l'association?"))
            {
                case 0:
                    Adherent tmp = askAdherent("Qui est le membre donateur?");
                    if (tmp.GetType() == typeof(Donateur))
                    {
                        return (Donateur)tmp;
                    }
                    else
                    {
                        return new Donateur(tmp);
                    }
                case 1:
                    Console.WriteLine("Vous souhaitez ajouter un Donateur, nous allons proceder a son inscription");
                    Donateur temp = new Donateur();
                    return temp;
                case 2:
                    MenuDon();
                    Quitter();
                    break;
            }
            return new Donateur("Erreur 110 Echec de la creation d'un donnateur par l'utilisateur","0", "0", "0", "0");
        }
        /// <summary>
        /// Affiche la liste des beneficiaire de l'association sous forme de menu , et renvoie le choix de l'utilisateur. Si le bénéficiaire n'est pas encore dans la bae de donnée, propose a l'utilisateur de le créé et le renvois.
        /// </summary>
        /// <returns></returns>
        public static Beneficiaire askBeneficiaireExist()
        {
            List<string> maListe = new List<string>();
            maListe.Add("OUI");
            maListe.Add("NON");
            switch (LaunchMenu(maListe, "Le beneficiaire l'a-t-il deja été dans notre association?"))
            {
                case 0:
                    return askBeneficiaire("Qui est le membre donateur?");
                    
                case 1:
                    Console.WriteLine("Vous souhaitez ajouter un Beneficiaire, nous allons proceder a son inscription");
                    Beneficiaire temp = new Beneficiaire();
                    return temp;
                case 2:
                    MenuDon();
                    Quitter();
                    break;
            }
            return new Beneficiaire(new DateTime(1,1,1),"Erreur 110 Echec de la creation d'un donateur par l'utilisateur", "0", "0", "0");
        }
        /// <summary>
        /// Affiche la liste des adherent de l'association sous forme de menu , et renvoie lechoix de l'utilisateur
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public static Adherent askAdherent(string titre)
        {
            List<string> descriptifAdherent = new List<string>();
            foreach (Adherent item in Association.monAssociation.mesAdherents)
            {
                descriptifAdherent.Add(item.ToString());
            }
            int tmp = LaunchMenu(descriptifAdherent, titre);           
            if (tmp == descriptifAdherent.Count()-1) {
                MenuPrincipal();
                Quitter();
            }
            return Association.monAssociation.mesAdherents[tmp];
        }
        public static Beneficiaire askBeneficiaire(string titre)
        {
            List<string> maListe = new List<string>();
            foreach (Beneficiaire item in Association.monAssociation.mesBeneficiaires)
            {
                maListe.Add(item.ToString());
            }
            int tmp = LaunchMenu(maListe, titre);
            if (tmp == maListe.Count())
            {
                MenuPrincipal(); ;
                Quitter();
            }
            return Association.monAssociation.mesBeneficiaires[tmp];
        }  
        /// <summary>
        /// Afficher tout leslieux de stockages possible sauf les maisons de donateurs dans un menu et renvois sa réponse
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public static Personne_Morale askPersonneMorale(string titre)
        {
            List<string> maListe = new List<string>();
            List<Personne_Morale> mesDepots = new List<Personne_Morale>();
            maListe.Add(Association.monAssociation.ToString());
            mesDepots.Add(Association.monAssociation);
            if (Association.monAssociation.monGardeMeuble != null)
            {
                maListe.Add(Association.monAssociation.monGardeMeuble.ToString());
                mesDepots.Add(Association.monAssociation.monGardeMeuble);
            }
            
            foreach (DepotVente x in Association.monAssociation.depotsDeVentes)
            {
                maListe.Add(x.ToString());
                mesDepots.Add(x);
            }
            int tmp = LaunchMenu(maListe, titre);
            if (tmp == maListe.Count() - 1)
            {
                MenuPrincipal();
                Quitter();
            }
            return mesDepots[tmp];
        }
        public static DepotVente askDepotVente(string titre)
        {
            List<string> maListe = new List<string>();
            List<DepotVente> mesDepots = new List<DepotVente>();
            foreach (DepotVente x in Association.monAssociation.depotsDeVentes)
            {
                maListe.Add(x.ToString());
                mesDepots.Add(x);
            }
            int tmp = LaunchMenu(maListe, titre);
            if (tmp == maListe.Count() - 1)
            {
                MenuPrincipal();
                Quitter();
            }
            return mesDepots[tmp];
        }
        /// <summary>
        /// Fonction de blindage demandant un doublea l'utilisateur
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double askDouble(double min, double max)
        {
            double a;
            string entre = "a";
            while (double.TryParse(entre, out a) == false)
            {
                if (entre != "a")
                {
                    Console.WriteLine("veuillez saisir un nombre décimal valide");
                }
                entre = Console.ReadLine();
            }
            a = double.Parse(entre);
            if (a < min || a > max)
            {
                Console.WriteLine("Pour des raisons de temps de calculs ou de formats, veuillez saisir un entier compris entre " + min + " et " + max);
                a = askDouble(min, max);
            }
            return a;
        }
        /// <summary>
        /// Fonction de blindage demandant un int a l'utilisateur
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int askInt(int min, int max)
        {
            int a;
            string entre = "a";
            while (int.TryParse(entre, out a) == false)
            {
                if (entre != "a")
                {
                    Console.WriteLine("veuillez saisir un nombre entier");
                }
                entre = Console.ReadLine();
            }
            a = int.Parse(entre);
            if (a < min || a > max)
            {
                Console.WriteLine("Pour des raisons de temps de calculs ou de formats, veuillez saisir un entier compris entre " + min + " et " + max);
                a = askInt(min, max);
            }
            return a;
        }
        /// <summary>
        /// Fonction de blindage demandant 3 int a l'utilisateur
        /// </summary>
        /// <returns></returns>
        public static DateTime askDateTime()
        {
            Console.WriteLine("Entrez une année");
            int annee = askInt(1, 9000);
            Console.WriteLine("Entrez un mois (1-12)"); 
            int mois = askInt(1, 12);
            int jour;
            Console.WriteLine("Entrez un jour");
            if (annee % 4 == 0 && mois == 2)
            {
                jour = askInt(1, 29);
            }
            else if(annee % 4 != 0 && mois == 2)
            {
                jour = askInt(1, 28);
            }
            else if(mois == 4 || mois == 6 || mois == 9 || mois == 11)
            {
                jour = askInt(1, 30);
            }
            else
            {
                jour = askInt(1, 31);
            }
            return new DateTime(annee, mois, jour);
        }

        public static void Quitter()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Sauvegarde.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Association.monAssociation);                          
            stream.Close();
            Thread.CurrentThread.Abort();
        }
    }
}
