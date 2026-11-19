using System;

namespace BateriaEventos
{
    public class Bateria
    {
        // Los suscriptores se enganchan a este evento.
        public event EventHandler<CambioEstadoEventArgs> EstadoCambiado;

        private bool conectado;
        private int carga;

        public Bateria(int cargaInicial)
        {
            carga = cargaInicial;
        }

        public bool Conectado
        {
            get { return conectado; }
            set
            {
                if (conectado == value)
                {
                    return;
                }

                conectado = value;

                if (conectado)
                {
                    Avisar("Se conecto el cargador");
                }
                else
                {
                    Avisar("Se desconecto el cargador");
                }
            }
        }

        // La carga se lee pero se cambia con los metodos de abajo.
        public int Carga
        {
            get { return carga; }
        }

        public void Cargar(int puntos)
        {
            carga = carga + puntos;

            if (carga > 100)
            {
                carga = 100;
            }

            Avisar("Cargo " + puntos + " puntos");
        }

        public void Descargar(int puntos)
        {
            carga = carga - puntos;

            if (carga < 0)
            {
                carga = 0;
            }

            Avisar("Se usaron " + puntos + " puntos");
        }

        private void Avisar(string accion)
        {
            CambioEstadoEventArgs datos = new CambioEstadoEventArgs(conectado, carga, accion);

            // El ?. evita el error si nadie esta escuchando.
            EstadoCambiado?.Invoke(this, datos);
        }
    }
}
