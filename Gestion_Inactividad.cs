using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Power
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Gestion_Archivo
    {
        private string rutaArchivo;

        public Gestion_Archivo()
        {
            rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuracion.txt");
        }

        public void CrearArchivo()
        {
            try
            {
              
                if (!File.Exists(rutaArchivo))
                {
            
                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Apagado=Desactivado");
                        sw.WriteLine("Inactividad=Desactivado");
                        sw.WriteLine("Tiempo_Inactividad=60");
                    }
                    Console.WriteLine("Archivo creado con valores predeterminados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el archivo: {ex.Message}");
            }
        }

        public void Modificar_Archivo(string apagado, string inactividad, string tiempo)
        {
            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"Apagado={apagado}");
                    sw.WriteLine($"Inactividad={inactividad}");
                    sw.WriteLine($"Tiempo_Inactividad={tiempo}");
                }
                Console.WriteLine($"Archivo guardado correctamente: Apagado={apagado}, Inactividad={inactividad}, Tiempo={tiempo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el archivo: {ex.Message}");
            }
        }

        public List<string> Levantar_Datos()
        {
            List<string> datos = new List<string>();
            string apagadoValor = "Desactivado";
            string inactividadValor = "Desactivado";
            string tiempo = "60";

            try
            {
              
                if (File.Exists(rutaArchivo))
                {
                 
                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] partes = linea.Split('=');
                            if (partes.Length == 2)
                            {
                                switch (partes[0].Trim())
                                {
                                    case "Apagado":
                                        apagadoValor = partes[1].Trim();
                                        break;
                                    case "Inactividad":
                                        inactividadValor = partes[1].Trim();
                                        break;
                                    case "Tiempo_Inactividad":
                                        tiempo = partes[1].Trim();
                                        break;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Archivo leído correctamente: Apagado={apagadoValor}, Inactividad={inactividadValor}, Tiempo={tiempo}");
                }
                else
                {
                    CrearArchivo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }

            datos.Add(apagadoValor);
            datos.Add(inactividadValor);
            datos.Add(tiempo);
            return datos;
        }
    }
}
