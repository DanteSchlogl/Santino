using System;
using System.Threading;

namespace Cocina
{
    // Cada mozo es un hilo que lleva pedidos a la bandeja.
    public class Mozo
    {
        private static readonly string[] Platos =
            { "Milanesa", "Tallarines", "Ensalada", "Pizza", "Pollo", "Pure", "Sopa" };

        private static int contador;

        private readonly string nombre;
        private readonly Bandeja bandeja;
        private readonly int cantidad;
        private readonly Random azar;

        public Mozo(string nombre, Bandeja bandeja, int cantidad, int semilla)
        {
            this.nombre = nombre;
            this.bandeja = bandeja;
            this.cantidad = cantidad;
            azar = new Random(semilla);
        }

        public void TomarPedidos()
        {
            for (int i = 0; i < cantidad; i++)
            {
                // Un rato entre pedido y pedido, como en la vida real.
                Thread.Sleep(azar.Next(250, 650));

                int numero = Interlocked.Increment(ref contador);
                Comanda comanda = new Comanda(
                    numero,
                    azar.Next(1, 9),
                    Platos[azar.Next(Platos.Length)],
                    nombre);

                Program.Log(nombre + " lleva " + comanda);
                bandeja.Poner(comanda);
            }

            Program.Log(nombre + " termino el turno");
        }
    }
}
