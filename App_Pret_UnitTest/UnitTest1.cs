using System;
using System.Collections.Generic;
using app_pret;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;

namespace App_Pret_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Objet_CreerUnObjet_True()
        {
            Objet objet1 = new Objet("star wars", Enums.StatutObjet.Disponible);
            Objet.Add(objet1);

            Objet objet2 = Objet.GetById(1);

            Assert.ReferenceEquals(objet1, objet2);
        }

        [TestMethod]
        public void Emprunteur_CreerUnEmprunteur_True()
        {
            Emprunteur emprunteur1 = new Emprunteur("Smith", "John", "mail@google.com");
            Emprunteur.Add(emprunteur1);

            Emprunteur emprunteur2 = Emprunteur.GetById(1);

            Assert.ReferenceEquals(emprunteur1, emprunteur2);
        }

        [TestMethod]
        public void Pret_CreerUnPret_True()
        {
            Objet objet1 = Objet.GetById(1);
            objet1.SetStatut(Enums.StatutObjet.Disponible);

            List<Objet> pret1Objets = new List<Objet>()
            {
                objet1
            };
            Pret pret1 = new Pret(DateTime.Now.AddDays(-55), DateTime.Now.AddDays(30), pret1Objets, Emprunteur.GetById(1));
            Assert.IsTrue(Pret.Add(pret1));
        }

        [TestMethod]
        public void Pret_CreerUnPret_False()
        {
            Objet objet1 = Objet.GetById(1);
            objet1.SetStatut(Enums.StatutObjet.Emprunte);

            List<Objet> pret1Objets = new List<Objet>()
            {
                objet1
            };
            Pret pret1 = new Pret(DateTime.Now.AddDays(-55), DateTime.Now.AddDays(30), pret1Objets, Emprunteur.GetById(1));
            Assert.IsFalse(Pret.Add(pret1));
        }
    }
}
