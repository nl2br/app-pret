using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    public class Emprunteur
    {
        public int Id { get;  set; }
        public string Nom { get;  set; }
        public string Prenom { get;  set; }
        public string Mail { get;  set; }

        private Emprunteur() { }

        public Emprunteur(string nom, string prenom, string mail)
        {
            this.Id = GetAll().Count + 1; ;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Mail = mail;
        }

        public static List<Emprunteur> GetAll()
        {
            return Database<Emprunteur>.GetAll();
        }

        public static void Add(Emprunteur objet)
        {
            Database<Emprunteur>.Create(objet);
        }

        public static void Remove(int id)
        {
            Database<Emprunteur>.Delete(id);
        }

        public static Emprunteur GetById(int id)
        {
            List<Emprunteur> items = GetAll();
            return items.Find(x => x.Id == id);
        }
    }
}
