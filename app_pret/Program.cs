using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{

    public class Program
    {
        static void Main(string[] args)
        {
            LaunchApp();

            // ecrire
            //Objet.Add(new Objet("star wars", Enums.StatutObjet.Emprunte));
            //Objet.Add(new Objet("Greemlins", Enums.StatutObjet.Disponible));
            //Objet.Add(new Objet("retour vers le futur", Enums.StatutObjet.Emprunte));
            //Emprunteur.Add(new Emprunteur("Smith", "John", "mail@google.com"));
            //Emprunteur.Add(new Emprunteur("BeGood", "Johnny", "mail@google.com"));
            //Emprunteur.Add(new Emprunteur("Mad", "Max", "mail@google.com"));

            // supprimer
            //Objet.Remove(1);
            //Console.WriteLine("film index 1 : {0}", Objet.GetById(1).Nom);

            // Changer le statut
            //var objet1 = Objet.GetById(1);
            //objet1.SetStatut(Enums.StatutObjet.Perdu);

            // Ajouter un pret
            //var pret1Objets = new List<Objet>()
            //{
            //    Objet.GetById(1)
            //};
            //var pret1 = new Pret(DateTime.Now.AddDays(-55), DateTime.Now.AddDays(30), pret1Objets, Emprunteur.GetById(2));
            //if(!Pret.Add(pret1))
            //    Console.WriteLine("L'un des objets demandés n'est pas disponible");



            // lire les prets
            //var objetsList = Objet.GetAllByStatut(Enums.StatutObjet.Emprunte);
            //foreach (var objet in objetsList)
            //{
            //    Console.WriteLine("id: {0}, nom: {1}, statut: {2}", objet.Id, objet.Nom, objet.Statut);
            //}
        }

        public static void LaunchApp()
        {
            Console.WriteLine("Bienvenue sur APPret");
            Console.WriteLine("Voici vos objets :");

            var objetsList = Objet.GetAll();
            foreach (var objet in objetsList)
            {
                Console.WriteLine("id: {0}, nom: {1}, statut: {2}", objet.Id, objet.Nom, objet.Statut);
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("vos prêts :");

            var pretsList = Pret.GetAll();
            foreach (var pret in pretsList)
            {
                Console.WriteLine("id: {0}, Emprunteur: {1}, date début: {2}, date fin: {3}, statut: {4}", pret.Id, pret.Emprunteur.Nom, pret.DateDebutFormatted, pret.DateFinFormatted, pret.Statut);
                foreach(var objet in pret.Objets)
                {
                    Console.WriteLine("         id: {0}, nom: {1}", objet.Id, objet.Nom);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");
        }
    }
}
