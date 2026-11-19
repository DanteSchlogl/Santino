using System.Collections.Generic;
using System.Threading;

namespace Cocina
{
    // Donde los mozos dejan los pedidos y los cocineros los retiran.
    public class Bandeja
    {
        private readonly List<Comanda> pedidos = new List<Comanda>();
        private readonly object candado = new object();
        private readonly int capacidad;
        private bool terminado;

        public Bandeja(int capacidad)
        {
            this.capacidad = capacidad;
        }

        // Lo usa un mozo. Si no hay lugar, se queda esperando.
        public void Poner(Comanda comanda)
        {
            bool tomado = false;
            try
            {
                Monitor.Enter(candado, ref tomado);

                // while y no if: cuando despierta hay que volver a mirar,
                // otro mozo pudo haber ocupado el lugar.
                while (pedidos.Count == capacidad)
                {
                    Monitor.Wait(candado);
                }

                pedidos.Add(comanda);

                // PulseAll: hay mozos esperando lugar y cocineros esperando pedidos.
                Monitor.PulseAll(candado);
            }
            finally
            {
                if (tomado)
                {
                    Monitor.Exit(candado);
                }
            }
        }

        // Lo usa un cocinero. Si no hay pedidos, espera.
        public Comanda Sacar()
        {
            bool tomado = false;
            try
            {
                Monitor.Enter(candado, ref tomado);

                while (pedidos.Count == 0 && !terminado)
                {
                    Monitor.Wait(candado);
                }

                if (pedidos.Count == 0)
                {
                    return null;
                }

                Comanda comanda = pedidos[0];
                pedidos.RemoveAt(0);

                // Se fue uno: despierto a los mozos que esperan lugar.
                Monitor.PulseAll(candado);

                return comanda;
            }
            finally
            {
                if (tomado)
                {
                    Monitor.Exit(candado);
                }
            }
        }

        // La llama el programa cuando ya no entran mas pedidos.
        public void Terminar()
        {
            bool tomado = false;
            try
            {
                Monitor.Enter(candado, ref tomado);
                terminado = true;
                Monitor.PulseAll(candado);
            }
            finally
            {
                if (tomado)
                {
                    Monitor.Exit(candado);
                }
            }
        }
    }
}
