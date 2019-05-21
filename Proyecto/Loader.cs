using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.IO;

namespace Proyecto
{
    class Loader
    {
        public static ObjectModel FromFile(string filename)
        {
            ObjectModel obj = new ObjectModel();
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
                {
                    Console.WriteLine("Leyendo archivo...");
                    obj.ProcessFile(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Archivo no encontrado: {0}", filename);
            }
            catch (Exception)
            {
                Console.WriteLine("Error cargando archivo: {0}", filename);
            }

            return obj;
        }
    }
}
