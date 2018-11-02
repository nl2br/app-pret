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
        public int Id { get; set; }
        public string Nom { get; set; }
        public Enums.StatutObjet Statut;

        public Objet() { }

        public Objet(string nom, Enums.StatutObjet statut = Enums.StatutObjet.Disponible)
        {
            this.Id = GetAll().Count + 1;
            this.Nom = nom;
            this.Statut = statut;
        }

        public static List<Objet> GetAll()
        {
            return Database<Objet>.GetAll();
        }

        public static void Add(Objet objet)
        {
            Database<Objet>.Create(objet);
        }

        public static void Remove(int id)
        {
            Database<Objet>.Delete(id);
        }

        public static Objet GetById(int id)
        {
            List<Objet> items = GetAll();
            return items.Find(item => item.Id == id);
        }

        public void SetStatut(Enums.StatutObjet statut)
        {
            List<Objet> objets = GetAll();
            var objet = objets.Find(item => item.Id == this.Id);
            objets[objet.Id-1].Statut = statut;

            using (var fs = new FileStream("Objet.xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<Objet>));
                xs.Serialize(fs, objets);
            }
        }

        public static List<Objet> GetAllByStatut(Enums.StatutObjet statut)
        {
            List<Objet> objets = GetAll();
            List<Objet> objetsByStatut = new List<Objet>();
            for(var i=0; i < objets.Count; i++)
            {
                if(objets[i].Statut == statut)
                {
                    objetsByStatut.Add(objets[i]);
                }
            }
            return objetsByStatut;
        }
    }
}
