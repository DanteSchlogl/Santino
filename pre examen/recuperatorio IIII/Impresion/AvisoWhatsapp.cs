using System;

namespace ImpresoraCompartida
{
    public class AvisoWhatsapp : IAviso
    {
        public void Avisar(string usuario, string archivo)
        {
            Console.WriteLine("   whatsapp a " + usuario + ": ya salio " + archivo);
        }
    }
}
