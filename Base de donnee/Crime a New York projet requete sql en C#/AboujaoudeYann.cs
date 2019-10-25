using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;

namespace projetBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fin = false;
            bool valid = true;
            string lecture = "";
            //string connectionString = "SERVER=fboisson.ddns.net;PORT=3306;UID=moi;PASSWORD=123;SSLMODE=none;";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=NY_Crimes;UID=esilvs6;PASSWORD=;SSLMODE=none;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            //Menu interactif
            //---------------
            do
            {
                fin = false;
                //
                Console.WriteLine();
                Console.WriteLine("1 : Importer une journée de crimes");
                Console.WriteLine("2 : Exporter le bilan journalier");
                Console.WriteLine("3 : Saisie d'un crime");
                Console.WriteLine("4 : Le nombre de crimes par quartier et par catégorie");
                Console.WriteLine("5 : Récapitulatif pour un mois");
                Console.WriteLine("6 : Evolution mois par mois");
                Console.WriteLine("7 : Palmarès annuel");
                Console.WriteLine("8 : La fonction de votre choix");
                Console.WriteLine("9 : fin");
                //
                do
                {
                    lecture = "";
                    valid = true;

                    Console.Write("\nchoisissez un programme > ");
                    lecture = Console.ReadLine();
                    Console.WriteLine(lecture);
                    if (lecture == "" || !"123456789".Contains(lecture[0]))
                    {
                        Console.WriteLine("votre choix <" + lecture + "> n'est pas valide = > recommencez ");
                        valid = false;
                    }
                } while (!valid);
                //
                //
                switch (lecture[0])
                {
                    case '1':
                        Console.Clear();
                        InsertionJournee(connection);
                        break;
                    case '2':
                        Console.Clear();
                        ExporterBilanJournalier(connection);
                        break;
                    case '3':
                        Console.Clear();
                        SaisirUnCrime(connection);
                        break;
                    case '4':
                        Console.Clear();
                        CrimesParQuartier(connection);
                        break;
                    case '5':
                        Console.Clear();
                        RecapitulatifMensuel(connection);
                        break;
                    case '6':
                        Console.Clear();
                        EvolutionMoisParMois(connection);
                        break;
                    case '7':
                        Console.Clear();
                        PalmaresAnnuel(connection);
                        break;
                    case '8':
                        Console.Clear();
                        VotreFonction(connection);
                        break;
                    case '9':
                        Console.Clear();
                        Console.WriteLine("fin de programme...");
                        Console.ReadKey();
                        fin = true;
                        break;
                    default:
                        Console.WriteLine("\nchoix non valide => faites un autre choix....");
                        break;
                }
            } while (!fin);

        }

        /// <summary>
        /// commentaires...
        /// </summary>
        
            static void InsertionJournee(MySqlConnection connection)
        {
                connection.Open();




                Console.WriteLine("\n1 => Importer une journée de crimes (question 1.1)");
                Console.WriteLine("-----------------\n");

                /// <summary>

                /// </summary>

                XmlTextReader reader = new XmlTextReader("texte.xml");
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);
                            Console.WriteLine(">");
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            Console.WriteLine(reader.Value);
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            Console.Write("</" + reader.Name);
                            Console.WriteLine(">");
                            break;
                    }
                }
                Console.ReadLine();



                connection.Close();
            
        }
        /// <summary>
        /// commentaires...
        /// </summary>
        static void ExporterBilanJournalier(MySqlConnection connection)
        {
            Console.WriteLine("\n2 => Exporter le bilan journalier (question 1.2)");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText =
             "select date,borough,coord_X,coord_Y,crime_description_id,jurisdiction_id from NY_Crimes.Crime where date ='03/01/2012;";

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
        /// <summary>
        /// L'utilisateur entre des information d'un crime qui seront enregistrer dansla BDD
        /// </summary>
        /// <param name="connection"></param>
        static void SaisirUnCrime(MySqlConnection connection)
        {
            Console.WriteLine("\n3 => Saisie d'un crime (question 2.1)");
            Console.WriteLine("-----------------\n");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            Console.WriteLine("Veuillez entrer une date");
            string askDate = Console.ReadLine();
            Console.WriteLine("Veuillez entrer un quartier");
            string askQuartier = Console.ReadLine();
            Console.WriteLine("Veuillez entrer une coordonnée X");
            string askcoordX = Console.ReadLine();
            Console.WriteLine("Veuillez entrer une coordonnée Y");
            string askcoordY = Console.ReadLine();
            Console.WriteLine("Veuillez entrer un identifiant de description");
            string askid1 = Console.ReadLine();
            Console.WriteLine("Veuillez entrer un identifidant de juridiction");
            string askid2 = Console.ReadLine();
           //command.CommandText = "INSERT INTO NY_Crimes.Crime(date, borough, coord_X, coord_Y, crime_description_id, jurisdiction_id) VALUES('03/01/2012', 'MANHATTAN', 984061, 206906, 14, 1); ";
            command.CommandText = "INSERT INTO NY_Crimes.Crime(date, borough, coord_X, coord_Y, crime_description_id, jurisdiction_id) VALUES('"+askDate+"', '"+askQuartier+"', "+askcoordX+", "+askcoordY+", "+askid1+", "+askid2+"); ";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            Console.WriteLine("-----------------\n\n");
        }
        /// <summary>
        /// Affiche le nombre de crime de chaque quartier àune date donnée par l'utilisateur
        /// </summary>
        /// <param name="connection"></param>
        static void CrimesParQuartier(MySqlConnection connection)
        {
            // string date = "01/01/2012";
            Console.WriteLine("Veuillez entrer une date");
            string date = Console.ReadLine();
            connection.Open();
            Console.WriteLine("\n4 => Le nombre de crimes par quartier et par catégorie (question 3.1)");
            Console.WriteLine("-----------------\n");           
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select distinct borough from NY_Crimes.Crime where date = '"+date+"';";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> quartier=new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                quartier.Add(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
            }
            reader.Close();
            command.CommandText = "Select distinct description from NY_Crimes.Crime_description d, ny_crimes.Crime c where d.id=c.crime_description_id;";
            reader = command.ExecuteReader();
            List<string> categories = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                categories.Add(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
            }
            reader.Close();
            foreach (string x in quartier)
            {
                Console.Write("Voici le Nombre de crime à " + x + " le " + date + " : ");
                command.CommandText = "Select COUNT('') from NY_Crimes.Crime where date = '"+date+"' and borough='"+x+"';";
                reader = command.ExecuteReader();
                while (reader.Read())// parcours ligne par ligne
                {
                    Console.WriteLine(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                }
                reader.Close();
            }
            foreach (string x in categories)
            {
                Console.Write("Voici le Nombre de crime ayant pour description " + x + " le " + date + " : ");
                command.CommandText = "Select count('')from NY_Crimes.Crime c, NY_Crimes.Crime_description d where c.date = '" + date+"'and c.crime_description_id=d.id and d.description = '"+x + "'";
                reader = command.ExecuteReader();
                while (reader.Read())// parcours ligne par ligne
                {
                    Console.WriteLine(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
                }
                reader.Close();
            }
            connection.Close();
            Console.WriteLine("-----------------\n\n");
        }
        /// <summary>
        /// Demande a l'utilisateur un mois et affiche tout les détails de toutles crimes de ce mois
        /// </summary>
        /// <param name="connection"></param>
        static void RecapitulatifMensuel(MySqlConnection connection)
        {
            Console.WriteLine("\n5 => Récapitulatif pour un mois (question 3.2)");
            Console.WriteLine("-----------------\n");
            string month="x";
            while (month != "01" && month != "02" && month != "03" && month != "04" && month != "05" && month != "06" && month != "07" && month != "08" && month != "09" && month != "10" && month != "11" && month != "12")
            {
                Console.WriteLine("Veuillez entrer un mois (0-12)");
                month = Console.ReadLine();
                if(month != "1" || month != "2" || month != "3" || month != "4" || month != "5" || month != "6" || month != "7" || month != "8" || month == "9")
                {
                    string a = "0";
                    a += month;
                    month = a;
                }
            }

            //string month = "01";
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select date, coord_X, coord_Y,desc_specificity,name,borough from NY_Crimes.Crime c, NY_Crimes.Crime_description d, NY_Crimes.Jurisdiction j where('" + month + "/00/2012' < c.date and '" + month + "/32/2012' > c.date and d.description = 'grand larceny'and d.id = c.crime_description_id and j.id = c.jurisdiction_id) order by c.borough;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string quartierPrecedent="" ;
            while (reader.Read())// parcours ligne par ligne
            {
                if(quartierPrecedent != reader.GetString(5))
                {
                    Console.WriteLine("\n\n\n\n"+"Voici les <<grand larcery>> du quartier "+ reader.GetString(5)+ "\n\n\n");
                    quartierPrecedent = reader.GetString(5);
                }
                Console.WriteLine(reader.GetString(0)+" Coordonnées x: "+ reader.GetString(1)+" y: "+ reader.GetString(2)+"\t Description:"+ reader.GetString(3)+"\t Juridiction: "+ reader.GetString(4));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
            }
            reader.Close();
            connection.Close();
            Console.WriteLine("-----------------\n\n");
        }
        /// <summary>
        /// Pour chaque quartier et pour chaque mois, Affiche la part de grand larcery du quartier dans le total des crime du mois
        /// </summary>
        /// <param name="connection"></param>
        static void EvolutionMoisParMois(MySqlConnection connection)
        {
            connection.Open();
            Console.WriteLine("\n6 => Evolution mois par mois (question 3.2)");
            Console.WriteLine("-----------------\n");
            string[] month = { "01","02","03","04","05","06","07","08","09","10","11","12" };
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select distinct borough from NY_Crimes.Crime";//on recupere tout les quartier différent, tout les quartiers sont present a cette date
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> quartier = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                quartier.Add(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
            }
            reader.Close();
            int totalCrime = 0;
            int GLCrime = 0; ;
            for (int j = 0; j < quartier.Count(); j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    command.CommandText = "Select COUNT('') from ny_crimes.crime where'" + month[i] + "/00/2012' < date and '" + month[i] + "/32/2012' > date;";
                    reader = command.ExecuteReader();
                    reader.Read();
                    totalCrime = int.Parse(reader.GetString(0));
                    reader.Close();
                    if (totalCrime != 0)
                    {
                        command.CommandText = "Select COUNT('') from ny_crimes.crime c ,ny_crimes.crime_description d where'" + month[i] + "/00/2012' < date and '" + month[i] + "/32/2012' > date and d.description = 'grand larceny'and d.id = c.crime_description_id  and borough='" + quartier[j] + "';";
                        reader = command.ExecuteReader();
                        reader.Read();
                        GLCrime = int.Parse(reader.GetString(0));
                        reader.Close();
                        Console.WriteLine("Durant la mois: " + month[i] + ", " + (double)GLCrime / totalCrime * 100 + "% des crimes était des <<grand larcery>> à " + quartier[j]);
                    }
                }
            }
            connection.Close();
            Console.WriteLine("-----------------\n\n");
        }
        /// <summary>
        /// Pour chaque quartier,affiche le nombre de crime total d'un quatier
        /// Affiche le quartier le plus criminel
        /// Affiche le crime le plus souvent commis danslequartier le plus criminel, ainsi quele nombre de fois où il a été commis.
        /// </summary>
        /// <param name="connection"></param>
        static void PalmaresAnnuel(MySqlConnection connection)
        {
            Console.WriteLine("\n7 => Palmarès annuel (question 4.1)");
            Console.WriteLine("-----------------\n");

            connection.Open();
            Console.WriteLine("\n4 => Le nombre de crimes par quartier et par catégorie (question 3.1)");
            Console.WriteLine("-----------------\n");
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select distinct borough from NY_Crimes.Crime;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            
            List<string> quartier = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                quartier.Add(reader.GetString(0));  // récupération de la 1ère colonne (il n'y en a qu'une dans la requête !)
            }
            reader.Close();
            int max = 0;
            string maxQuartier = "";
            for (int j = 0; j < quartier.Count(); j++)
            {
                command.CommandText = "Select Count('') from NY_Crimes.Crime where borough='"+quartier[j]+"';";
                reader = command.ExecuteReader();
                reader.Read();
                Console.WriteLine("Voici le nombre de crime du quartier " + quartier[j] + " : " + reader.GetString(0));
                if (max < int.Parse(reader.GetString(0)))
                {
                    max = int.Parse(reader.GetString(0));
                    maxQuartier = quartier[j];
                }
                reader.Close();
                
            }
            Console.WriteLine("Le quartier le plus criminel est " + maxQuartier);

            command.CommandText = "select description, count('') as n from NY_Crimes.Crime_description d, ny_crimes.Crime c where c.crime_description_id = d.id and borough = '"+maxQuartier+"' group by description order by n desc;";
            reader = command.ExecuteReader();
            reader.Read();
            Console.WriteLine("Le crime le plus commis dans ce quartier est le " + reader.GetString(0).ToString() + " Il a été commis " + reader.GetString(1).ToString() + " fois");
            connection.Close();
        }
        static void VotreFonction(MySqlConnection connection)
        {
            Console.WriteLine("\n8La fonction de votre choix (question 5.1)");
            Console.WriteLine("-----------------\n");
            Console.WriteLine("Fonction non encore implémentée");
            Console.WriteLine("A vous de faire");
            Console.WriteLine("-----------------\n\n");
        }
    }
}
