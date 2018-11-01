using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace app_pret
{
    public class ObjetCollection
    {
        public int ID;
        //protected string Categorie { get; set; }
        public string Nom;
        //protected string LieuStockage { get; set; }
        public Enums.StatutObjet Statut;
        private int NombreObjetColletion = 0;

        public ObjetCollection() {
            this.NombreObjetColletion++;
        }

        public ObjetCollection(int id, string nom, Enums.StatutObjet statut = Enums.StatutObjet.Disponible)
        {
            this.ID = id;
            this.Nom = nom;
            this.Statut = statut;

        }

        public static List<ObjetCollection> GetAllObjet()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ObjetCollection>));
            using (StreamReader rd = new StreamReader("objets.xml"))
            {
                return xs.Deserialize(rd) as List<ObjetCollection>;
            }
        }

        public static void AddObjet(ObjetCollection objet)
        {
            var allObjets = new List<ObjetCollection>();

            if (!File.Exists("objets.xml"))
            {
                var fl = File.Create("objets.xml");
                fl.Close();
            }
            else
            {
                // recupérer tous les objets du fichier XML
                allObjets = GetAllObjet();
            }

            allObjets.Add(objet);

            // recréer le fichier XML avec les anciennes données + la nouvelle
            using (var fs = new FileStream("objets.xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<ObjetCollection>));
                xs.Serialize(fs, allObjets);
            }
        }

        public static void AddObjet(List<ObjetCollection> objets)
        {
            var allObjets = new List<ObjetCollection>();

            if (!File.Exists("objets.xml"))
            {
                var fl = File.Create("objets.xml");
                fl.Close();
            }
            else
            {
                // recupérer tous les objets du fichier XML
                allObjets = GetAllObjet();
            }

            foreach(var objet in objets)
            {
                allObjets.Add(objet);
            }
            
            // recréer le fichier XML avec les anciennes données + les nouvelles
            using (var fs = new FileStream("objets.xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<ObjetCollection>));
                xs.Serialize(fs, allObjets);
            }
        }

        public static void RemoveObjet(int id)
        {
            List<ObjetCollection> objets = GetAllObjet();

            for(var i = 0; i < objets.Count; i++)
            {
                if(objets[i].ID == id)
                {
                    objets.Remove(objets[i]);
                }
            }

            // recréer le fichier XML avec les anciennes données - la nouvelle
            using (var fs = new FileStream("objets.xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<ObjetCollection>));
                xs.Serialize(fs, objets);
            }
        }
    }
}
