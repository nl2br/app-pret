using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_pret
{
    class Emprunteur
    {
        public int ID { get;  set; }
        public string Name { get;  set; }
        private int NombreEmprunteur {get; set;}


        private Emprunteur()
        {
            this.NombreEmprunteur++;
        }

        public Emprunteur(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
