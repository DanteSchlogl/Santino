using System;
using System.Windows.Forms;
using LoginApp.BLL;

namespace LoginApp.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SeguridadServicio servicio = FabricaSeguridad.Crear();
            Application.Run(new FormLogin(servicio));
        }
    }
}
