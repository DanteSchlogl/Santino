using System;

namespace ImpresoraCompartida
{
    public class AvisoMail : IAviso
    {
        public void Avisar(string usuario, string archivo)
        {
            Console.WriteLine("   mail a " + usuario + ": ya salio " + archivo);
        }
    }
}
