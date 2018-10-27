using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    class Datas_environement
    {
        public void SetEnvironement()
        {
            ObjetCollection objet1 = new ObjetCollection(1, "star wars", Enums.StatutObjet.Emprunte);
            ObjetCollection objet2 = new ObjetCollection(2, "Greemlins", Enums.StatutObjet.Disponible);
            ObjetCollection objet3 = new ObjetCollection(3, "retour vers le futur", Enums.StatutObjet.Emprunte);
        }
    }
}
