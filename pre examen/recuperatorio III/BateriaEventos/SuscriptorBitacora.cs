using System;
using System.IO;

namespace BateriaEventos
{
    // Anota el cambio en un archivo, uno por dia.
    public class SuscriptorBitacora
    {
        public void OnEstadoCambiado(object sender, CambioEstadoEventArgs datos)
        {
            try
            {
                // La fecha en el nombre: un archivo por dia, sin tener que borrar nada.
                string archivo = "bitacora_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                string estado;
                if (datos.Conectado)
                {
                    estado = "ENCHUFADA";
                }
                else
                {
                    estado = "A BATERIA";
                }

                string linea = DateTime.Now.ToString("HH:mm:ss") +
                               " | " + datos.Accion +
                               " | " + estado +
                               " | " + datos.Carga + "%";

                File.AppendAllText(archivo, linea + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo escribir la bitacora: " + ex.Message);
            }
        }
    }
}
