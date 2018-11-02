using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace app_pret
{
    public class Pret
    {
        public int Id { get; set; }
        [XmlIgnore]
        public DateTime DateDebut { get; set; }
        [XmlElement("DateDebut")]
        public string DateDebutFormatted
        {
            get { return DateDebut.ToShortDateString(); }
            set { DateDebut = Convert.ToDateTime(value); }
        }
        [XmlIgnore]
        public DateTime DateFin { get; set; }
        [XmlElement("DateFin")]
        public string DateFinFormatted
        {
            get { return DateFin.ToShortDateString(); }
            set { DateFin = Convert.ToDateTime(value); }
        }
        [XmlIgnore]
        public Nullable<DateTime> DateRendu { get; set; }
        [XmlElement("DateRendu")]
        public string DateRenduFormatted
        {
            get { return (DateRendu.HasValue)? DateRendu.Value.ToShortDateString():null; }
            set { }
        }
        public Enums.StatutPret Statut { get; set; }
        public List<Objet> Objets { get; set; }
        public Emprunteur Emprunteur { get; set; }

        public Pret() { }

        public Pret(DateTime dateDebut, DateTime dateFin, List<Objet> objets, Emprunteur emprunteur)
        {
            this.Id = GetAll().Count + 1;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.DateRendu = null;
            this.Statut = Enums.StatutPret.Encours;
            this.Objets = objets;
            this.Emprunteur = emprunteur;
        }

        public static List<Pret> GetAll()
        {
            return Database<Pret>.GetAll();
        }

        public static bool Add(Pret pret)
        {
            if(pret.Validate(pret.Objets))
            {
                foreach (var objet in pret.Objets)
                {
                    objet.SetStatut(Enums.StatutObjet.Emprunte);
                }

                Database<Pret>.Create(pret);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static void Remove(int id)
        {
            Database<Pret>.Delete(id);
        }

        public static Pret GetById(int id)
        {
            List<Pret> items = GetAll();
            return items.Find(item => item.Id == id);
        }

        public void SetStatut(Enums.StatutPret statut)
        {
            List<Pret> prets = GetAll();
            var objet = prets.Find(item => item.Id == this.Id);
            prets[objet.Id - 1].Statut = statut;

            using (var fs = new FileStream("Pret.xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<Pret>));
                xs.Serialize(fs, prets);
            }
        }

        public static List<Pret> GetAllByStatut(Enums.StatutPret statut)
        {
            List<Pret> prets = GetAll();
            List<Pret> pretsByStatut = new List<Pret>();
            for (var i = 0; i < prets.Count; i++)
            {
                if (prets[i].Statut == statut)
                {
                    pretsByStatut.Add(prets[i]);
                }
            }
            return pretsByStatut;
        }

        public bool Validate(List<Objet> objets)
        {
            bool Response = false;

            // verifier si objet(s) est disponible
            foreach(var objet in objets)
            {
                Response = (objet.Statut != Enums.StatutObjet.Disponible) ? false : true;
                if (!Response) break;
            }

            return Response;
        }

    }
}
