using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace TD6_BDD2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "SERVER=fboisson.ddns.net;PORT=3306;UID=moi;PASSWORD=123;SSLMODE=none;";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=root;PASSWORD=c728b2f8;SSLMODE=none;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            Console.Clear();
            Console.WriteLine("0 Lecture/ecriture de ficier csv");
            Console.WriteLine("=================\n");
            Exo0();
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            //connection.Open();
            //Console.WriteLine("fin des opérations");

            Console.Clear();
            Console.WriteLine("1.1 Liste des marques");
            Console.WriteLine("=================");
            Exo1(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n\n1.2 Liste des propriétaires avec véhicules");
            Console.WriteLine("=================");
            Exo2(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n\n1.3 Liste des véhicules par prix de journée décroissant");
            Console.WriteLine("=================");
            Exo3(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n\n1.4 Valeur moyenne des prix de journée");
            Console.WriteLine("=================");
            Exo4(connection);
            Console.WriteLine("\nappuyez sur une touche pour continuer");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n\n1.6 deuxième prix de journée minimum");
            Console.WriteLine("\n=================");
            Exo6(connection);
            Console.WriteLine("appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.WriteLine("\n1.6 deuxième prix de journée minimum version 2");
            Console.WriteLine("\n=================");
            Exo6_2(connection);
            Console.WriteLine("appuyez sur une touche pour continuer");
            Console.ReadKey();


            Console.Clear();
            Console.WriteLine("\n\n1.7 prix de journée médian");
            Console.WriteLine("\n=================");
            Exo7(connection);
            Console.WriteLine("appuyez sur une touche pour finir\n");

            Console.ReadKey();

        }//main

        static void Exo0()
        {
            //lire le fichier clients.csv
            Console.WriteLine("Lecture du fichier clients.csv");
            Console.WriteLine("----------------------------");
            string nomFichier = "clients.csv";
            Lire(nomFichier);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer...\n");
            Console.ReadKey();
            //
            // ecrire dans le fichier csv
            // le client supplémentaire
            Console.WriteLine("Ecriture dans le fichier clients.csv");
            Console.WriteLine("----------------------------");
            string nom = "Jouvet";
            string prenom = "Louis";
            int age = 80;
            string numPermis = "55555";
            string adresse = "rue du vent";
            string ville = "Paris";
            string newClient = nom + ";"
                + prenom + ";"
                + Convert.ToString(age) + ";"
                + numPermis + ";"
                + adresse + ";"
                + ville;
            bool append = true;
            Ecrire(newClient, nomFichier, append);

            //relire le fichier clients.csv
            Console.WriteLine("Relecture du fichier clients.csv");
            Console.WriteLine("----------------------------");
            Lire(nomFichier);
            Console.WriteLine("----------------------------\n");

        }
        static void Ecrire(string ligne, string fichier, bool append)
        {
            StreamWriter ecrire = new StreamWriter(fichier, true);
            ecrire.WriteLine(ligne);
            ecrire.Close();
        }
        static void Lire(string fichier)
        {
            string ligne = "";
            char[] sep = new char[1] { '1' };
            string[] datas = new string[6];

            StreamReader lecteur = new StreamReader(fichier);
            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine();
                Console.WriteLine("ligne lu" + ligne);
                datas = ligne.Split(sep);
            }
            lecteur.Close();
        }



        static void Exo1(MySqlConnection connection)
        //liste des marques
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText =
             " SELECT DISTINCT(marque) FROM voiture ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque;
            while (reader.Read())// parcours ligne par ligne
            {
                // prix = Convert.ToInt32(Console.ReadLine());
                marque = reader.GetString(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                Console.WriteLine(marque);
            }

            connection.Close();
        }

        static void Exo2(MySqlConnection connection)
        //liste des véhicules/propriétaires
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT marque, modele, immat, pseudo"
                                + " FROM voiture NATURAL JOIN proprietaire"
                                + " ORDER BY pseudo, marque, modele ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            string immat = "";
            string pseudo = "";

            while (reader.Read())   // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                immat = reader.GetString(2);  // récupération 3ème colonne colonne (selon la requête !)
                pseudo = reader.GetString(3); // récupération 4ème colonne colonne (selon la requête !)

                Console.WriteLine(pseudo + " : " + marque + " , " + modele + " , " + immat);
            }

            connection.Close();
        }

        static void Exo3(MySqlConnection connection)
        //liste des véhicules/propriétaires
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT marque, modele, prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ DESC;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            string lettre1 = "";
            string fin = "";
            int prixJ = 0;
            string marqueLettre1Maj = "";

            while (reader.Read())   // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                prixJ = reader.GetInt32(2);  // récupération 3ème colonne colonne (selon la requête !)

                lettre1 = marque.Substring(0, 1).ToUpper();
                fin = marque.Substring(1);  // <=> label.Substring(1, label.Length -1)
                marqueLettre1Maj = lettre1 + fin;

                Console.WriteLine(marqueLettre1Maj + " : " + modele + " => " + prixJ);
            }

            connection.Close();
        }

        static void Exo4(MySqlConnection connection)
        // moyenne de prix de journée
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT AVG(prixJ)"
                                + " FROM voiture";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            double moyenne = 0.00;
            while (reader.Read())                           // parcours ligne par ligne
            {
                moyenne = reader.GetDouble(0);  // récupération de la 1nde colonne (selon la requête !)
            }
            Console.WriteLine("La moyenne des prix de journée est de " + moyenne + " euros");

            connection.Close();
        }

        static void Exo5(MySqlConnection connection)
        // prix de journée min et max par modèle
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT marque, modele, min(prixJ), max(prixJ) " +
                                     "FROM voiture " +
                                     "GROUP BY marque, modele; ";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string marque = "";
            string modele = "";
            int min = 0;
            int max = 0;

            while (reader.Read())                           // parcours ligne par ligne
            {
                marque = reader.GetString(0); // récupération 1ère colonne (selon la requête !)
                modele = reader.GetString(1); // récupération 2ème colonne (selon la requête !)
                min = reader.GetInt32(2);     // récupération 3ème colonne (selon la requête !)
                max = reader.GetInt32(3);     // récupération 4ème colonne (selon la requête !)

                Console.WriteLine(marque + "  " + modele
                + "   minimum =" + min + "  maximum =" + max);
            }

            connection.Close();
        }


        static void Exo6(MySqlConnection connection)
        //Le deuxième prix de journée minimum
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ ASC ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            if (reader.Read()) // on passe le 1er élément (noter le if VERSUS while)
            {
                if (reader.Read()) // on arrive au 2nd élément
                {
                    int prix = reader.GetInt32(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                    Console.WriteLine("le deuxième prix de journée est : " + prix);
                }
            }

            connection.Close();
        }


        static void Exo6_2(MySqlConnection connection)
        //Le deuxième prix de journée minimum
        // Deuxième version
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT DISTINCT prixJ"
                                + " FROM voiture"
                                + " ORDER BY prixJ ASC ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numeroLigne = 0;
            int prix = 0;

            while (reader.Read()) // parcours ligne par ligne
            {
                numeroLigne++;   // vaut donc 1 au 1er tour de boucle
                if (numeroLigne == 2)
                {
                    prix = reader.GetInt32(0);  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                    Console.WriteLine("le deuxième prix de journée est : " + prix);
                    break; // optimisation
                }
            }

            connection.Close();
        }

        static void Exo7(MySqlConnection connection)
        //Km compteur médian (50% de voitures au-dessus, 50% de voitures au-dessous)
        {
            connection.Open();

            // Etape 1
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = " SELECT COUNT(compteur)"
                                + " FROM voiture ;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int nbVoiture = 0;
            if (reader.Read())  // noter le if VERSUS while
            {
                nbVoiture = reader.GetInt32(0);
            }

            reader.Close(); // Ne pas oublier, pour se reservir de la même variable ;-)
                            //----------------------------

            // Etape 2 (si nbProduits > 0)
            command.CommandText = " SELECT DISTINCT compteur"
                                + " FROM voiture"
                                + " ORDER BY compteur ASC;";

            reader = command.ExecuteReader();

            int numeroLigne = 0;
            int indexMilieu = nbVoiture / 2 - 1;  // division entière (le "milieu de 9, c'est 4 => index 3)
            int compteur = 0;
            while (reader.Read())  // parcours ligne par ligne
            {
                if (numeroLigne == indexMilieu)
                {
                    compteur = reader.GetInt32(0);
                    Console.WriteLine("kilométrage médian = " + compteur);
                    Console.WriteLine("il y a " + indexMilieu + " véhicules ayant un km compteur inférieur");
                    Console.WriteLine("et " + indexMilieu + " véhicules ayant un km compteur supérieur");
                    break; // pour optimisation
                }
                numeroLigne++;
            }

            connection.Close();
        }
    }
}
