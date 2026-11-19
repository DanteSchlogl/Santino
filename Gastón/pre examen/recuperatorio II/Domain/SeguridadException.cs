using System;

namespace LoginApp.Domain
{
    // Error de login: usuario o clave que no coinciden.
    public class SeguridadException : Exception
    {
        public SeguridadException(string mensaje) : base(mensaje)
        {
        }
    }
}
