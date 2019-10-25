using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_GRH_ABOUJAOUDE_YANN
{
    class Program
    {
        static void Main(string[] args)
        {
            int positionMenu;
            bool resterDansLeMenu;
            ConsoleKey choix;
            int annee;
            int mois;
            int number;
            string clavier;
            int jours;
            bool quitter = false;
            string phase;
            string etre;

            while (quitter == false)
            {
                Console.Clear();

                jours = 0;
                annee = 0;
                clavier = " ";
                mois = 0;
                number = 0;
                resterDansLeMenu = true;
                positionMenu = 1;
                phase = " ";
                etre = "vîmes";

                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Cette année est elle bissextile?");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Combien de jours a ce mois?");
                    Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                    Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                    Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                    Console.WriteLine("Calendrier Lunaire");
                    Console.WriteLine("Calendrier perpétuel");
                    Console.WriteLine("Quitter");
                }
                while (resterDansLeMenu)
                {
                    choix = Console.ReadKey().Key;
                    Console.Clear();
                    if (choix == ConsoleKey.UpArrow && positionMenu > 1) { positionMenu--; }
                    if (choix == ConsoleKey.DownArrow && positionMenu < 8) { positionMenu++; }

                    if (positionMenu == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 2)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 3)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 4)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 5)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Calendrier Lunaire");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 6)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");                    
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calendrier Lunaire");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Quitter");
                    }
                    else if (positionMenu == 7)
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calendrier perpétuel");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Quitter");
                    }
                    else
                    {
                        Console.WriteLine("Cette année est elle bissextile?");
                        Console.WriteLine("Combien de jours a ce mois?");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Calendrier perpétuel");
                        Console.WriteLine("Calendrier Lunaire");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Quitter");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (choix == ConsoleKey.Enter)
                    {
                        resterDansLeMenu = false;
                    }
                }

                Console.Clear();
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (positionMenu == 1)
                {
                    Console.WriteLine("Vous avez choisi : " + "Cette année est t'elle bissextile?");
                    Console.WriteLine("Veuillez entrer une année");
                    clavier = Console.ReadLine();
                    while (int.TryParse(clavier, out number) == false)
                    {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                    }
                    annee = int.Parse(clavier);

                    if (Anneebissextile(annee))
                    {
                        Console.WriteLine("Cette année est bissextile!");
                    }
                    else
                    {
                        Console.WriteLine("Cette année n'est pas bissextile!");
                    }
                }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 2)
                {
                    Console.WriteLine("Vous avez choisi : " + "Combien de jours à ce mois?");
                    Console.WriteLine("Veuillez entrer un mois (1-12)");
                    clavier = Console.ReadLine();

                    while (mois>12 || mois < 1){
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer un mois (1-12");
                            clavier = Console.ReadLine();
                        }
                        mois = int.Parse(clavier); }

                    Console.WriteLine("Veuillez entrer une année");
                    clavier = Console.ReadLine();
                    while (int.TryParse(clavier, out number) == false)
                    {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                    }
                    annee = int.Parse(clavier);
                    Console.WriteLine("Le mois " + stringmois(mois) + " à " + NombreDeJoursAnnee(mois, Anneebissextile(annee)) + " jours");
                }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 3)
                {
                    resterDansLeMenu = true;
                    Console.WriteLine("Vous avez choisi : " + "Calcul de la date de paque d'une décennies pour un calendrier Julien");
                    Console.WriteLine("Souhaitez vous utiliser la méthode de Gauss ou de Meuss ?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Gauss");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Meuss");
                    Console.WriteLine("Précédent");
                    positionMenu = 1;
                    while (resterDansLeMenu)
                    {
                        choix = Console.ReadKey().Key;
                        Console.Clear();
                        Console.WriteLine("Vous avez choisi : " + "Calcul de la date de paque d'une décennies pour un calendrier Julien");
                        Console.WriteLine("Souhaitez vous utiliser la méthode de Gauss ou de Meuss ?");

                        if (choix == ConsoleKey.UpArrow && positionMenu > 1) { positionMenu--; }
                        if (choix == ConsoleKey.DownArrow && positionMenu < 3) { positionMenu++; }
                        if (positionMenu == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Gauss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Meuss");
                            Console.WriteLine("Précédent");
                        }
                        else if (positionMenu == 2)
                        {
                            Console.WriteLine("Gauss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Meuss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Précédent");
                        }
                        else
                        {
                            Console.WriteLine("Gauss");
                            Console.WriteLine("Meuss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Précédent");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (choix == ConsoleKey.Enter)
                        {
                            resterDansLeMenu = false;
                        }
                    }
                    if (positionMenu == 1)
                    {
                        while (annee < 325) {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        annee = int.Parse(clavier);
                        if (annee < 325)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Gauss car l'année est antérieur à 325");
                        }
                    }
                    for (int i = 0; i < 10; i++)
                        {
                            jours = GaussJulien(annee + i);
                            joursdefete(jours, 3, "La Pâque", annee + i);
                        }
                    }
                    else if (positionMenu == 2)
                    {
                        while (annee < 326) {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        annee = int.Parse(clavier);
                        if (annee < 326)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Meuss car l'année est antérieur à 326");
                        }
                    }
                    for (int i = 0; i < 10; i++)
                        {
                            jours = MeeusJulien(annee + i);
                            joursdefete(jours, 3, "La Pâque", annee + i);
                        }
                    }
                }
 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 4)
                {
                    resterDansLeMenu = true;
                    Console.WriteLine("Vous avez choisi : " + "Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                    Console.WriteLine("Quel méthode souhaitez vous utiliser?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Méthode de Gauss");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Méthode de Meuss");
                    Console.WriteLine("Méthode de Conway");
                    Console.WriteLine("Précédent");
                    positionMenu = 1;
                    while (resterDansLeMenu)
                    {
                        choix = Console.ReadKey().Key;
                        Console.Clear();
                        Console.WriteLine("Vous avez choisi : " + "Calcul de la date de paque d'une décennies pour un calendrier grégorien");
                        Console.WriteLine("Quel méthode souhaitez vous utiliser?");

                        if (choix == ConsoleKey.UpArrow && positionMenu > 1) { positionMenu--; }
                        if (choix == ConsoleKey.DownArrow && positionMenu < 4) { positionMenu++; }
                        if (positionMenu == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Gauss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Méthode de Meuss");
                            Console.WriteLine("Méthode de Conway");
                            Console.WriteLine("Précédent");
                        }
                        else if (positionMenu == 2)
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Meuss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Méthode de Conway");
                            Console.WriteLine("Précédent");
                        }
                        else if (positionMenu == 3)
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.WriteLine("Méthode de Meuss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Conway");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Précédent");
                        }
                        else
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.WriteLine("Méthode de Meuss");
                            Console.WriteLine("Méthode de Conway");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Précédent");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (choix == ConsoleKey.Enter)
                        {
                            resterDansLeMenu = false;
                        }
                    }
                    if (positionMenu == 1)
                    {
                        while (annee < 1583) {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        annee = int.Parse(clavier);
                        if (annee < 1583)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Gauss car l'année est antérieur à 1583");
                        }
                    }
                    for (int i = 0; i < 10; i++)
                        {
                            jours = GaussGregrorien(annee + i);
                            joursdefete(jours, 3, "La Pâque", annee + i);
                        }
                    }
                    else if (positionMenu == 2)
                    {
                        while (annee < 1583) {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        annee = int.Parse(clavier);
                        if (annee < 1583)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Meuss car l'année est antérieur à 1583");
                        }
                    }
                    for (int i = 0; i < 10; i++)
                        {
                            jours = MeussGregorien(annee + i);
                            joursdefete(jours, 3, "La Pâque", annee + i);
                        }
                    }

                    else if (positionMenu == 3)
                    {
                        while (annee < 1583)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                            while (int.TryParse(clavier, out number) == false)
                            {
                                Console.WriteLine("Veuillez entrer une année");
                                clavier = Console.ReadLine();
                            }
                            annee = int.Parse(clavier);
                            if (annee < 1583)
                            {
                                Console.WriteLine("Le calcul est impossible avec l’algorithme de Conway car l'année est antérieur à 1583");
                            }
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            jours = ConwayGregorien(annee + i);
                            joursdefete(jours, 3, "La Pâque", annee + i);
                        }
                    }
                }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 5)
                {
                    resterDansLeMenu = true;
                    Console.WriteLine("Vous avez choisi : " + "Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                    Console.WriteLine("Quel méthode souhaitez vous utiliser?");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Méthode de Gauss");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Méthode de Meuss");
                    Console.WriteLine("Méthode de Conway");
                    Console.WriteLine("Précédent");
                    positionMenu = 1;
                    while (resterDansLeMenu)
                    {
                        choix = Console.ReadKey().Key;
                        Console.Clear();
                        Console.WriteLine("Vous avez choisi : " + "Calcul de toutes les fetes mobiles pour un calendrier grégorien");
                        Console.WriteLine("Quel méthode souhaitez vous utiliser?");

                        if (choix == ConsoleKey.UpArrow && positionMenu > 1) { positionMenu--; }
                        if (choix == ConsoleKey.DownArrow && positionMenu < 4) { positionMenu++; }
                        if (positionMenu == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Gauss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Méthode de Meuss");
                            Console.WriteLine("Méthode de Conway");
                            Console.WriteLine("Précédent");
                        }
                        else if (positionMenu == 2)
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Meuss");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Méthode de Conway");
                            Console.WriteLine("Précédent");
                        }
                        else if (positionMenu == 3)
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.WriteLine("Méthode de Meuss");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Méthode de Conway");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Précédent");
                        }
                        else
                        {
                            Console.WriteLine("Méthode de Gauss");
                            Console.WriteLine("Méthode de Meuss");
                            Console.WriteLine("Méthode de Conway");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Précédent");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (choix == ConsoleKey.Enter)
                        {
                            resterDansLeMenu = false;
                        }
                    }
                    if (positionMenu == 1)
                    {
                        while (annee < 1583) {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        if (annee < 1583)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Gauss car l'année est antérieur à 1583");
                        }
                            annee = int.Parse(clavier);
                        }
                    
                        jours = GaussGregrorien(annee);
                        TouteLesFete(jours, annee);
                    }
                    else if (positionMenu == 2)
                    {
                        while (annee < 1583) { 
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer une année");
                            clavier = Console.ReadLine();
                        }
                        annee = int.Parse(clavier);
                        if (annee < 1583)
                        {
                            Console.WriteLine("Le calcul est impossible avec l’algorithme de Meuss car l'année est antérieur à 1583");
                        }
                    }
                    jours = MeussGregorien(annee);
                        TouteLesFete(jours, annee);
                    }
                    else if (positionMenu == 3)
                    {
                        Console.WriteLine("Veuillez entrer une année");
                        while (annee < 1583)
                        {

                            clavier = Console.ReadLine();

                            while (int.TryParse(clavier, out number) == false)
                            {
                                Console.WriteLine("Veuillez entrer une année");
                                clavier = Console.ReadLine();
                            }
                            annee = int.Parse(clavier);
                            if (annee < 1583)
                            {
                                Console.WriteLine("Le calcul est impossible avec l’algorithme de Conway car l'année est antérieur à 1583");
                            }
                        }
                        jours = ConwayGregorien(annee);
                        TouteLesFete(jours, annee);
                    }
                  }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 6)
                {
                    Console.WriteLine("Vous avez choisi : " + "Calendrier lunaire");
                    Console.WriteLine("Veuillez entrer un mois (1-12)");
                    clavier = Console.ReadLine();

                    while (mois > 12 || mois < 1)
                    {
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer un mois (1-12");
                            clavier = Console.ReadLine();
                        }
                        mois = int.Parse(clavier);
                    }
                    Console.WriteLine("Veuillez entrer un jour");
                    clavier = Console.ReadLine();

                    while (jours > NombreDeJoursAnnee(mois, Anneebissextile(annee)) || jours < 1)
                    {
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer jour");
                            clavier = Console.ReadLine();
                        }
                        jours = int.Parse(clavier);
                    }
                    Console.WriteLine("Veuillez entrer une année");
                    clavier = Console.ReadLine();
                    while (int.TryParse(clavier, out number) == false)
                    {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                    }
                    annee = int.Parse(clavier);
                    phase = phaseDeLaLune(jours, mois, annee);
                    if (annee > 2016) { etre = "verrons"; }
                    Console.WriteLine("Ce soir là, nous " + etre + " " + phase + " dans le ciel.");
                }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (positionMenu == 7)
                {
                    Console.WriteLine("Vous avez choisi : " + "Calendrier perpétuel");
                    Console.WriteLine("Veuillez entrer un mois (1-12)");
                    clavier = Console.ReadLine();
                    while (mois > 12 || mois < 1)
                    {
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer un mois (1-12");
                            clavier = Console.ReadLine();
                        }
                        mois = int.Parse(clavier);
                    }
                    Console.WriteLine("Veuillez entrer un jour");
                    clavier = Console.ReadLine();
                    while (jours > NombreDeJoursAnnee(mois, Anneebissextile(annee)) || jours < 1)
                    {
                        while (int.TryParse(clavier, out number) == false)
                        {
                            Console.WriteLine("Veuillez entrer jour");
                            clavier = Console.ReadLine();
                        }
                        jours = int.Parse(clavier);
                    }
                    Console.WriteLine("Veuillez entrer une année");
                    clavier = Console.ReadLine();
                    while (int.TryParse(clavier, out number) == false)
                    {
                        Console.WriteLine("Veuillez entrer une année");
                        clavier = Console.ReadLine();
                    }
                    annee = int.Parse(clavier);
                    phase = jourDeLaSemaine(jours, mois, annee);
                    Console.WriteLine("Ce jour est un " + phase);
                }
////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else
                {
                    Console.WriteLine("Au revoir et bonne année!");
                    quitter = true;
                }
                if (quitter == false) { Console.WriteLine("Appuyez sur une touche pour revenir au menu"); }
                Console.ReadKey();
            }
        }

        static string phaseDeLaLune(int jour, int mois, int annee)
        {
            jour = jour-19; //pleine lune de référence le 19 janvier 2017
            int i = annee;
            while (i < 2017)
            {
                jour = jour - 365;
                if(Anneebissextile(i))
                { jour = jour - 1; }
                i = i + 1;
            }
            while (i > 2017)
            {
                jour = jour + 365;
                i = i - 1;
                if (Anneebissextile(i))
                { jour = jour + 1; } 
            }
            i = mois;
            while(i > 1)
            {
                i = i - 1;
                jour = jour + NombreDeJoursAnnee(i,Anneebissextile(annee));
            }

            double phase = (double)jour;
            while (phase> 29.530588) { phase = phase - 29.530588; }
            while (phase < 0) { phase = phase + 29.530588; }

            if (phase > 1.84 && phase <= 5.53) { return "une Lune gibbeuse décroissante"; }
            else if (phase > 5.53 && phase <= 9.22) { return "un dernier quartier de Lune"; }
            else if (phase > 9.22 && phase <= 12.91) { return "un dernier croissant de Lune"; }
            else if (phase > 12.91 && phase <= 16.61) { return "une nouvelle Lune"; }
            else if (phase > 16.61 && phase <= 20.3) { return "un premier croissant de Lune"; }
            else if (phase > 20.3 && phase <= 23.99) { return "un premier quartier de Lune"; }
            else if (phase > 23.99 && phase <= 27.68) { return "une Lune gibbeuse croissante"; }
            else { return "une Pleine Lune"; }
        }
        static string jourDeLaSemaine(int jour, int mois, int annee)
        {
            while (annee > 1583)
            {
                if (Anneebissextile(annee))
                {
                    jour = jour + 366;
                }
                else { jour = jour + 365; }
                annee = annee - 1;
            }
            while (mois > 1)
            {
                mois = mois - 1;
                jour = jour + NombreDeJoursAnnee(mois,Anneebissextile(annee));
            }
            jour = jour % 7;
            if (jour == 4) { return "samedi"; }
            else if (jour == 5) { return "dimanche"; }
            else if (jour == 6) { return "lundi"; }
            else if (jour == 0) { return "mardi"; }
            else if (jour == 1) { return "mercredi"; }
            else if (jour == 2) { return "jeudi"; }
            else { return "vendredi"; }
        }

        static void TouteLesFete(int jours, int annee)
        {
            int mois = 3;
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();
            joursdefete(jours - 70, mois, "Le Triodion", annee);
            joursdefete(jours - 63, mois, "Le Septuagésime", annee);
            joursdefete(jours - 57, mois , "Le Samedi des âmes", annee);
            joursdefete(jours - 56, mois, "Le Sexagésime", annee);
            joursdefete(jours - 49, mois, "Le Quinquagésime", annee);
            joursdefete(jours - 48, mois, "Le Lundi Gras", annee);
            joursdefete(jours - 47, mois, "Le Mardi gras", annee);
            joursdefete(jours - 46, mois, "Le Mercredi des Cendres", annee);
            joursdefete(jours - 42, mois, "Le Dimanche de l'Orthodoxie", annee);
            joursdefete(jours - 41, mois, "The People's Sunday", annee);
            joursdefete(jours - 21, mois, "The Mothering Sunday", annee);
            joursdefete(jours - 14, mois, "Le Dimanche de la passion", annee);
            joursdefete(jours - 8, mois, "Le Samedi de Lazare", annee);
            joursdefete(jours - 7, mois, "Le Dimanche des rameaux", annee);
            joursdefete(jours - 3, mois, "Le Jeudi saint", annee);
            joursdefete(jours - 2, mois, "Le vendredi saint", annee);
            joursdefete(jours - 1, mois, "Le samedi saint", annee);
            joursdefete(jours, mois, "La Pâque", annee);
            joursdefete(jours + 3, mois, "La Fête de saint Grégoire", annee);
            joursdefete(jours + 7, mois, "La Quasimodo", annee);
            joursdefete(jours + 39, mois, "L'Ascension", annee);
            joursdefete(jours + 49, mois, "La Pentecôte", annee);
            joursdefete(jours + 50, mois, "Le Lundi de Pentecôte", annee);
            joursdefete(jours + 56, mois, "La Fête de la Sainte Trinité", annee);
            joursdefete(jours + 60, mois, "La Fête-Dieu", annee);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine();
        }
        static int NombreDeJoursAnnee(int mois, bool b)
        {
            if (mois == 2 && b) { return 29; }
            else if (mois == 2) { return 28; }
            else if (mois == 4 || mois == 6 || mois == 9 || mois == 11) { return 30; }
            else { return 31; }
        }
        static bool Anneebissextile(int annee)
        {
            if (annee / 4 * 4 == annee)
                return true;
            else
                return false;
        }
        static int NombreDeJours(int mois)
        {
            if (mois == 2) { return 28; }
            else if (mois == 4 || mois == 6 || mois == 9 || mois == 11) { return 30; }
            else { return 31; }
        }
        static void joursdefete(int jours, int mois, string fete, int annee)
        {
            string etre = "était le";
            if (annee > 2016) etre = "sera le";
            while (jours > NombreDeJoursAnnee(mois, Anneebissextile(annee)))
            {
                jours = jours - NombreDeJoursAnnee(mois, Anneebissextile(annee));
                mois = mois + 1;
            }
            while (jours < 1)
            {
                mois = mois - 1;
                jours = jours + NombreDeJoursAnnee(mois, Anneebissextile(annee));
            }
            string smois = stringmois(mois);
            Console.WriteLine(fete + " " + etre + " " + jours + " " + smois + " en " + annee);
        }
        static string stringmois(int mois)
        {
            if (mois == 1) return "janvier";
            if (mois == 2) return "février";
            if (mois == 3) return "mars";
            if (mois == 4) return "avril";
            if (mois == 5) return "mai";
            if (mois == 6) return "juin";
            if (mois == 7) return "juillet";
            if (mois == 8) return "aout";
            if (mois == 9) return "septembre";
            if (mois == 10) return "octobre";
            if (mois == 11) return "novembre";
            else return "décembre";
        }

        static int MeeusJulien(int annee)
        {
            int a = annee % 19;
            int b = annee % 7;
            int c = annee % 4;
            int d = (19 * a + 15) % 30;
            int e = ((2 * c) + (4 * b) - d + 34) % 7;
            int f = (d + e + 114) / 31;
            if (f == 4) { return ((d + e + 114) % 31) + 32; }
            else { return ((d + e + 114) % 31) + 1; }
           
        }
        static int GaussJulien(int annee)
        {
            int a = annee % 19;
            int b = annee % 4;
            int c = annee % 7;
            int m = 15;
            int n = 6;
            int d = (19 * a + m) % 30;
            int e = (2 * b + (4 * c) + (6 * d) + n) % 7;
            return 22 + d + e;
        }
        static int GaussGregrorien(int annee)
        {
            int a = annee % 19;
            int b = annee % 4;
            int c = annee % 7;
            int k = annee / 100;
            int p = (8 * k + 13) / 25;
            int q = k / 4;
            int m = (15 - p + k - q) % 30;
            int n = (4 + k - q) % 7;
            int d = (19 * a + m) % 30;
            int e = (2 * b + (4 * c) + (6 * d) + n) % 7;
            int jours = 22 + d + e;
            if (jours > 31)
            {
                if (d == 29 && e == 6)
                {
                    jours = jours - 7;
                }
                else if (d == 28 && e == 6 && 11 * m + 11 < 19)
                {
                    jours = jours - 7;
                }
            }
            return jours;
        }
        static int MeussGregorien(int annee)
        {
            int n = annee % 19;
            int c = annee / 100;
            int u = annee % 100;
            int s = c / 4;
            int t = c % 4;
            int p = (c + 8) / 25;
            int q = (c - p + 1) / 3;
            int e = (19 * n + c - s - q + 15) % 30;
            int b = u / 4;
            int d = u % 4;
            int l = (32 + (2 * t) + (2 * b) - e - d) % 7;
            int h = (n + (11 * e) + (22 * l)) / 451;
            int m = (e + l - (7 * h) + 114) / 31;
            int jours = ((e + l - (7 * h) + 114) % 31) + 1;
            if (m == 4)
            { jours = jours + 31; }
            return jours;
        }
        static int ConwayGregorien(int annee)
        {
            int s = annee / 100;
            int t = annee % 100;
            int a = t / 4;
            int p = s % 4;
            int jps = (9 - 2 * p) % 7;
            int jp = (jps + t + a) % 7;
            int g = (annee % 19) + 1; // g+1
            int b = s / 4;
            int r = (8 * (s + 11)) / 25;
            int c = b - s + r;
            int d = (((11 * g + c) % 30) + 30) % 30;
            int h = (551 - (19 * d) + g) / 544;
            int e = (50 - d - h) % 7;
            int f = (e + jp) % 7;
            int jours = 57 - d - f - h;
            return jours;
        }
    }
}



































































