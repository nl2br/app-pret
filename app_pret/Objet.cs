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
    public class Objet
    {
        public int ID;
        //protected string Categorie { get; set; }
        public string Nom;
        //protected string LieuStockage { get; set; }
        public Enums.StatutObjet Statut;
        protected int NombreObjetColletion { get; set; }

        public Objet() {
            this.NombreObjetColletion++;
        }

        public Objet(int id, string nom, Enums.StatutObjet statut = Enums.StatutObjet.Disponible)
        {
            this.ID = id;
            this.Nom = nom;
            this.Statut = statut;


        }

        public void GetObjet()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Objet));
            using (StreamReader rd = new StreamReader("objet.xml"))
            {
                Objet p = xs.Deserialize(rd) as Objet;
                Console.WriteLine("Id : {0}", p.ID);
                Console.WriteLine("Nom : {0}", p.Nom);
            }
        }

        public void AddObjet()
        {
            Objet o = new Objet(this.ID, this.Nom, Enums.StatutObjet.Disponible);

            XmlDocument doc = new XmlDocument();
            doc.Load("objets.xml");

            XmlSerializer xs = new XmlSerializer(typeof(Objet));
            using (StreamWriter sw = new StreamWriter("objets.xml"))
            {
                xs.Serialize(sw, o);
            }

        }
    }
}
