using System;

namespace BateriaObservada.Domain
{
    // Error propio del dominio de la bateria.
    public class BateriaException : Exception
    {
        public BateriaException(string mensaje) : base(mensaje)
        {
        }
    }
}
