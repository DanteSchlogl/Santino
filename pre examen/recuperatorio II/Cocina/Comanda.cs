namespace Cocina
{
    // Un pedido que toma un mozo.
    public class Comanda
    {
        public int Numero;
        public int Mesa;
        public string Plato;
        public string Mozo;

        public Comanda(int numero, int mesa, string plato, string mozo)
        {
            Numero = numero;
            Mesa = mesa;
            Plato = plato;
            Mozo = mozo;
        }

        public override string ToString()
        {
            return "#" + Numero + " mesa " + Mesa + " (" + Plato + ")";
        }
    }
}
