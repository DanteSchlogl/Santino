using System;
using LoginApp.BLL;
using LoginApp.Domain;

namespace LoginApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SeguridadServicio seguridad = FabricaSeguridad.Crear();

            Console.Write("Ingrese usuario: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese clave: ");
            string clave = Console.ReadLine();

            try
            {
                Sesion sesion = seguridad.IniciarSesion(nombre, clave);
                MostrarMenu(sesion);
                seguridad.CerrarSesion();
            }
            catch (SeguridadException ex)
            {
                Console.WriteLine("No se pudo ingresar: " + ex.Message);
            }
        }

        private static void MostrarMenu(Sesion sesion)
        {
            Console.WriteLine();
            Console.WriteLine("Acceso concedido: " + sesion.Usuario.Nombre + " (" + sesion.Usuario.Perfil.Nombre + ")");
            Console.WriteLine();
            Console.WriteLine("MENU");

            Funcionalidad catalogo = CatalogoFuncionalidades.Armar();
            Funcionalidad visible = new MenuServicio().ArmarMenu(catalogo, sesion.Usuario.Perfil);

            Dibujar(visible, 1);
        }

        private static void Dibujar(Funcionalidad funcionalidad, int nivel)
        {
            string espacios = "";

            for (int i = 0; i < nivel; i++)
            {
                espacios = espacios + "   ";
            }

            foreach (Funcionalidad hijo in funcionalidad.ObtenerHijos())
            {
                Console.WriteLine(espacios + hijo.Nombre);
                Dibujar(hijo, nivel + 1);
            }
        }
    }
}
