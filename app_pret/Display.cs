using System;
using System.Collections.Generic;

namespace app_pret
{
    public class Display
    {
        public Display()
        {
            
        }

        public void LaunchApp()
        {
            Console.WriteLine("Bienvenue sur APPret");
            ListCollection();
            WhatNext();

        }

        public static void ListCollection()
        {
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
                foreach (var objet in pret.Objets)
                {
                    Console.WriteLine("L id: {0}, nom: {1}", objet.Id, objet.Nom);
                }
            }

            WhatNext();
        }

        public static void CreateObjet()
        {
            Console.WriteLine("Pour créer un objet veuillez saisir le nom de l'objet :");
            var response = Console.ReadLine();
            Objet.Add(new Objet(response, Enums.StatutObjet.Disponible));
            var objets = Objet.GetAll();
            var last = Objet.GetById(objets[objets.Count-1].Id);
            Console.WriteLine("SUCCESS Votre objet est sauvegardé en base comme suit : id {0}, nom '{1}'", last.Id,last.Nom);
            WhatNext();
        }

        public static void CreateEmprunteur()
        {
            Console.WriteLine("Pour créer un emprunteur veuillez saisir le nom, le prénom et le mail séparer par des virgules:");
            var response = Console.ReadLine();
            var props = response.Split(new[] { ',' });
            Emprunteur.Add(new Emprunteur(props[0], props[1], props[2]));
            var emprunteurs = Emprunteur.GetAll();
            var last = Emprunteur.GetById(emprunteurs[emprunteurs.Count - 1].Id);
            Console.WriteLine("SUCCESS Votre emprunteur est sauvegardé en base comme suit : id {0}, nom '{1}', prenom '{2}' mail {3}", last.Id, last.Nom, last.Prenom, last.Mail);
            WhatNext();
        }

        public static void CreatePret()
        {
            Console.WriteLine("NOT IMPLEMENTED ONLY CODE SORRY");
            WhatNext();
        }

        public static void WhatNext()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Que souhaitez vous faire ? :");
            Console.WriteLine("1 - Créer un objet");
            Console.WriteLine("2 - Créer un emprunteur");
            Console.WriteLine("3 - Créer un prêt NOT IMPLEMENTED CODE ONLY");
            Console.WriteLine("4 - Voir mes objets et mes prêts");
            Console.WriteLine("5 - QUITTER");
            var response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    CreateObjet();
                    break;
                case 2:
                    CreateEmprunteur();
                    break;
                case 3:
                    CreatePret();
                    break;
                case 4:
                    ListCollection();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void Exemple()
        {
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

    }
}