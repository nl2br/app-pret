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
    class Database
    {
        public List<ObjetCollection> DBObjets { get; set; }
        public List<Emprunteur> DBEmprunteurs { get; set; }

        public void SetEnvironement()
        {
            Objets();
            Emprunteurs();
        }

        public void Objets()
        {
            List<ObjetCollection> objets = new List<ObjetCollection> {
                new ObjetCollection(1, "star wars", Enums.StatutObjet.Emprunte),
                new ObjetCollection(2, "Greemlins", Enums.StatutObjet.Disponible),
                new ObjetCollection(3, "retour vers le futur", Enums.StatutObjet.Emprunte)
            };

            this.DBObjets = objets;


        }

        public void Emprunteurs()
        {
            List<Emprunteur> emprunteurs = new List<Emprunteur> {
                new Emprunteur(1, "Jean"),
                new Emprunteur(2, "Lenny"),
                new Emprunteur(3, "Christophe")
            };

            this.DBEmprunteurs = emprunteurs;
        }
    }
}
