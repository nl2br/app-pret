using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    class Program
    {
        static void Main(string[] args)
        {
            var datas = new Database();

            //datas.SetEnvironement();
            //List<ObjetCollection> listObjets = datas.DBObjets;
            //List<Emprunteur> listEmpurnteurs  = datas.DBEmprunteurs;

            //ObjetCollection.AddObjetToXML(listObjets);
            //listObjets.Clear();

            //List<ObjetCollection> objetsFromXml = ObjetCollection.GetAllObjetFromXML();

            //foreach (var objet in objetsFromXml)
            //{
            //    listObjets.Add(objet);
            //}


            // ecrire
            //ObjetCollection.AddObjet(new ObjetCollection(1, "star wars", Enums.StatutObjet.Emprunte));
            //ObjetCollection.AddObjet(new ObjetCollection(2, "Greemlins", Enums.StatutObjet.Disponible));
            //ObjetCollection.AddObjet(new ObjetCollection(3, "retour vers le futur", Enums.StatutObjet.Emprunte));
            ////ObjetCollection.RemoveObjet(1);


            // lire
            var objetsList = ObjetCollection.GetAllObjet();
            foreach (var objet in objetsList)
            {
                Console.WriteLine("id: {0}, nom: {1}, statut: {2}", objet.ID, objet.Nom, objet.Statut);
            }


        }
    }
}
