using System.Threading;

namespace Cocina
{
    // Cada cocinero es un hilo que saca pedidos y los cocina.
    public class Cocinero
    {
        private readonly string nombre;
        private readonly Bandeja bandeja;

        public Cocinero(string nombre, Bandeja bandeja)
        {
            this.nombre = nombre;
            this.bandeja = bandeja;
        }

        public int Cocinados { get; private set; }

        public void Trabajar()
        {
            while (true)
            {
                Comanda comanda = bandeja.Sacar();

                // null quiere decir que ya no hay mas pedidos.
                if (comanda == null)
                {
                    break;
                }

                Program.Log(nombre + " agarra " + comanda);

                // Cocinar va fuera del candado: asi los demas no esperan.
                Thread.Sleep(400);

                Cocinados = Cocinados + 1;
                Program.Log(nombre + " termino " + comanda);
            }

            Program.Log(nombre + " se va");
        }
    }
}
