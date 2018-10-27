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
            ObjetCollection o1 = new ObjetCollection(1,"star wars");
            o1.AddObjet();
            ObjetCollection o2 = new ObjetCollection(2, "greemlins");
            o2.AddObjet();
        }
    }
}
