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
            Objet o1 = new Objet(1,"star wars");
            o1.AddObjet();
            Objet o2 = new Objet(2, "greemlins");
            o2.AddObjet();
        }
    }
}
