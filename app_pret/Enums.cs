using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    public class Enums
    {
        public enum StatutObjet
        {
            Disponible,
            Emprunte,
            Perdu
        }

        public enum StatutPret
        {
            Retard,
            Encours,
            Termine
        }
    }
}
