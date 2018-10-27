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
        protected int NombreObjetColletion { get; set; }

        public ObjetCollection() {
            this.NombreObjetColletion++;
        }

        public ObjetCollection(int id, string nom, Enums.StatutObjet statut = Enums.StatutObjet.Disponible)
        {
            this.ID = id;
            this.Nom = nom;
            this.Statut = statut;

        }

        public void GetAllObjet()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObjetCollection));
            using (StreamReader rd = new StreamReader("objet.xml"))
            {
                ObjetCollection p = xs.Deserialize(rd) as ObjetCollection;
                Console.WriteLine("Id : {0}", p.ID);
                Console.WriteLine("Nom : {0}", p.Nom);
            }
        }

        public void AddObjet()
        {
            ObjetCollection o = new ObjetCollection(this.ID, this.Nom, Enums.StatutObjet.Disponible);

            XmlDocument doc = new XmlDocument();
            doc.Load("objets.xml");

            XmlSerializer xs = new XmlSerializer(typeof(ObjetCollection));
            using (StreamWriter sw = new StreamWriter("objets.xml"))
            {
                xs.Serialize(sw, o);
            }

        }

    }
}
