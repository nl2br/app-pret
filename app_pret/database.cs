using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace app_pret
{

    // TODO Singleton pour éviter d'avoir +ieurs instances
    // TODO ADD REMOVE GET SET
    public class Database<T>
    {
        public static void Create(T objet)
        {
            var all = new List<T>();


            if (!File.Exists(typeof(T).Name + ".xml"))
            {
                var fl = File.Create(typeof(T).Name + ".xml");
                fl.Close();
            }
            else
            {
                // recupérer tous les objets du fichier XML
                all = GetAll();
            }

            all.Add(objet);

            // recréer le fichier XML avec les anciennes données + la nouvelle
            using (var fs = new FileStream(typeof(T).Name + ".xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<T>));
                xs.Serialize(fs, all);
            }
        }

        public static List<T> GetAll()
        {
            if (File.Exists(typeof(T).Name + ".xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                using (StreamReader rd = new StreamReader(typeof(T).Name + ".xml"))
                {
                    return xs.Deserialize(rd) as List<T>;
                }
            }
            else
            {
                return new List<T>();
            }
        }

        public static void Delete(int id)
        {
            List<T> items = GetAll();

            items.RemoveAt(id-1);

            // recréer le fichier XML avec les anciennes données - la nouvelle
            using (var fs = new FileStream(typeof(T).Name + ".xml", FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<T>));
                xs.Serialize(fs, items);
            }
        }

    }
}
