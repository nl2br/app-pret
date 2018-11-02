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
            var display = new Display();
            display.LaunchApp();

            // TODO
            // - gérer les prêteurs
            //      - Obtenir les preteurs à partir de l'ID d'un objet                 
            // - vérifier les saisies
            // - PRETS :
            //      - Vérifier si un prêt est en retard avec VerifierPretsEnCours()
            //      - Si en retard, envoyer une notification par mail
            //      - Un objet est rendu
            //      - afficher les prets en cours en retard au lancement de l'app
            // - OBJET :
            //      - TrouverPret(bool encours) pour :
            //          - Retrouver l'historique des prets pour un objet
            //          - Retrouver le pret en cours d'un objet
            // - réaliser des tests unitaire digne de ce nom

        }


    }
}
