using System;

namespace BateriaEventos
{
    // Muestra el cambio en la pantalla.
    public class SuscriptorVisual
    {
        public void OnEstadoCambiado(object sender, CambioEstadoEventArgs datos)
        {
            string estado;

            if (datos.Conectado)
            {
                estado = "ENCHUFADA";
            }
            else
            {
                estado = "A BATERIA";
            }

            Console.WriteLine(datos.Accion + " | " + estado + " | " + datos.Carga + "%");
        }
    }
}
