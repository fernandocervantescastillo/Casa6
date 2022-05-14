using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Casa6.extras
{
    class Archivos
    {
        static string path = "..//..//..//file//";

        public static void agregarArhivo(string name, string json)
        {
            using (StreamWriter sw = File.CreateText(path + name))
            {
                sw.WriteLine(json);
            }
        }


        public static string leerArchivo(string name)
        {
            string t = "";

            using (StreamReader sr = File.OpenText(path + name))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    t = t + s;
                }
            }

            return t;

        }

    }
}
