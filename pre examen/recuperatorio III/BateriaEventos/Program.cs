using System;

namespace BateriaEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BATERIA DE LA NOTEBOOK");
            Console.WriteLine();

            Bateria bateria = new Bateria(35);

            SuscriptorVisual visual = new SuscriptorVisual();
            SuscriptorBitacora bitacora = new SuscriptorBitacora();

            // Los dos suscriptores al mismo evento.
            bateria.EstadoCambiado += visual.OnEstadoCambiado;
            bateria.EstadoCambiado += bitacora.OnEstadoCambiado;

            // Se enchufa y va cargando.
            bateria.Conectado = true;
            bateria.Cargar(30);
            bateria.Cargar(40);

            // Se desenchufa y empieza a usar bateria.
            bateria.Conectado = false;
            bateria.Descargar(25);
            bateria.Descargar(20);

            Console.WriteLine();
            Console.WriteLine("Fin. La bitacora quedo en el archivo del dia.");
        }
    }
}
