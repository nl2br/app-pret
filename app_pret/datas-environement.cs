using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    class Datas_environement
    {
        public static void SetEnvironement()
        {
            Objets();
            Emprunteurs();
        }

        public static void Objets()
        {
            ObjetCollection objet1 = new ObjetCollection(1, "star wars", Enums.StatutObjet.Emprunte);
            ObjetCollection objet2 = new ObjetCollection(2, "Greemlins", Enums.StatutObjet.Disponible);
            ObjetCollection objet3 = new ObjetCollection(3, "retour vers le futur", Enums.StatutObjet.Emprunte);

            var objets = new List<ObjetCollection>() { objet1, objet2, objet3 };

            foreach (var o in objets)
            {
                Console.WriteLine("id: {0}, nom: \"{1}\", statut: {2}", o.ID, o.Nom, o.Statut);
            }

            Console.WriteLine("Nombre total d'objet : {0}", objets.Count);
        }

        public static void Emprunteurs()
        {
            List<Emprunteur> emprunteurs = new List<Emprunteur>
            {
                new Emprunteur(1, "Jean"),
                new Emprunteur(2, "Lenny"),
                new Emprunteur(3, "Christophe")
            };

            foreach (Emprunteur emprunteur in emprunteurs)
            {
                Console.WriteLine("id: {0}, nom: {1}", emprunteur.ID, emprunteur.Name);
            }

            Console.WriteLine("Nombre d'emprunteur : {0}", emprunteurs.Count);
        }
    }
}
