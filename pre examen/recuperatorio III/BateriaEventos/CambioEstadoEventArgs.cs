using System;

namespace BateriaEventos
{
    public class CambioEstadoEventArgs : EventArgs
    {
        public bool Conectado { get; }
        public int Carga { get; }
        public string Accion { get; }

        public CambioEstadoEventArgs(bool conectado, int carga, string accion)
        {
            Conectado = conectado;
            Carga = carga;
            Accion = accion;
        }
    }
}
