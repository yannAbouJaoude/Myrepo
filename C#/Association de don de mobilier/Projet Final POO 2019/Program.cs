using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projet_Final_POO_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            // Debut de la serialization
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Sauvegarde.txt", FileMode.Open, FileAccess.Read);
            Association.monAssociation = (Association)formatter.Deserialize(stream);
            stream.Close();
            // Fin de la serialization


            //Association monAssociation = new Association("Aider Donner Agir", "38 avenue victor hugo", "0674637930");
            while (true)//A la fin de chaque action, on reviens systématiquement au menu. Le point de sortie du programme se trouve dans la fonction Menu.Quitter()
            {
                Menu.MenuPrincipal();
            }

        }
    }
}
