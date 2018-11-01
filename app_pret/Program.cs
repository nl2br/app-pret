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

            datas.SetEnvironement();
            var listObjets       = datas.DBObjets;
            var listEmpurnteurs  = datas.DBEmprunteurs;

            foreach (Emprunteur emprunteur in listEmpurnteurs)
            {
                Console.WriteLine("id: {0}, nom: {1}", emprunteur.ID, emprunteur.Name);
            }
            Console.WriteLine("Nombre d'emprunteurs : {0}", listEmpurnteurs.Count);

            foreach (ObjetCollection objet in listObjets)
            {
                Console.WriteLine("id: {0}, nom: {1}, statut: {2}", objet.ID, objet.Nom, objet.Statut);
            }
            Console.WriteLine("Nombre d'objets : {0}", listObjets.Count);

        }
    }
}
