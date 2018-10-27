using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ObjetCollection objet1 = new ObjetCollection(1, "star wars", Enums.StatutObjet.Emprunte);
            ObjetCollection objet2 = new ObjetCollection(2, "Greemlins", Enums.StatutObjet.Disponible);
            ObjetCollection objet3 = new ObjetCollection(3, "retour vers le futur", Enums.StatutObjet.Emprunte);

            var objets = new List<ObjetCollection>() { objet1, objet2, objet3 };

            this.DBObjets = objets;
        }

        public void Emprunteurs()
        {
            List<Emprunteur> emprunteurs = new List<Emprunteur>
            {
                new Emprunteur(1, "Jean"),
                new Emprunteur(2, "Lenny"),
                new Emprunteur(3, "Christophe")
            };

            this.DBEmprunteurs = emprunteurs;
        }
    }
}
