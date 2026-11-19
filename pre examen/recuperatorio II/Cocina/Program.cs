using System;
using System.Collections.Generic;
using System.Threading;

namespace Cocina
{
    class Program
    {
        private const int Capacidad = 4;
        private const int CantidadMozos = 3;
        private const int PedidosPorMozo = 5;
        private const int CantidadCocineros = 2;

        public static void Log(string texto)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "  " + texto);
        }

        static void Main(string[] args)
        {
            Bandeja bandeja = new Bandeja(Capacidad);

            List<Thread> hilosMozos = new List<Thread>();
            for (int i = 1; i <= CantidadMozos; i++)
            {
                Mozo mozo = new Mozo("Mozo " + i, bandeja, PedidosPorMozo, i * 13);
                hilosMozos.Add(new Thread(mozo.TomarPedidos));
            }

            Cocinero[] cocineros = new Cocinero[CantidadCocineros];
            List<Thread> hilosCocineros = new List<Thread>();
            for (int i = 0; i < CantidadCocineros; i++)
            {
                cocineros[i] = new Cocinero("Cocinero " + (i + 1), bandeja);
                hilosCocineros.Add(new Thread(cocineros[i].Trabajar));
            }

            foreach (Thread hilo in hilosCocineros)
            {
                hilo.Start();
            }

            foreach (Thread hilo in hilosMozos)
            {
                hilo.Start();
            }

            // Espero a que todos los mozos terminen de mandar.
            foreach (Thread hilo in hilosMozos)
            {
                hilo.Join();
            }

            bandeja.Terminar();

            // Y ahora si, espero a los cocineros.
            foreach (Thread hilo in hilosCocineros)
            {
                hilo.Join();
            }

            int total = CantidadMozos * PedidosPorMozo;
            int cocinados = 0;
            for (int i = 0; i < CantidadCocineros; i++)
            {
                cocinados = cocinados + cocineros[i].Cocinados;
            }

            Console.WriteLine();
            Console.WriteLine("Pedidos: " + total + " | Cocinados: " + cocinados);

            if (cocinados == total)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FALTAN PEDIDOS");
            }
        }
    }
}
