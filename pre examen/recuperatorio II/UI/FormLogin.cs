using System;
using System.Drawing;
using System.Windows.Forms;
using LoginApp.BLL;
using LoginApp.Domain;

namespace LoginApp.UI
{
    // Pantalla de ingreso.
    public class FormLogin : Form
    {
        private readonly SeguridadServicio servicio;
        private readonly TextBox usuario = new TextBox();
        private readonly TextBox clave = new TextBox();
        private readonly Label error = new Label();

        public FormLogin(SeguridadServicio servicio)
        {
            this.servicio = servicio;
            ArmarPantalla();
        }

        private void ArmarPantalla()
        {
            Text = "Ingreso al sistema";
            Width = 400;
            Height = 250;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label etiquetaUsuario = new Label();
            etiquetaUsuario.Text = "Usuario:";
            etiquetaUsuario.Left = 30;
            etiquetaUsuario.Top = 30;
            etiquetaUsuario.Width = 80;
            Controls.Add(etiquetaUsuario);

            usuario.Left = 120;
            usuario.Top = 25;
            usuario.Width = 220;
            Controls.Add(usuario);

            Label etiquetaClave = new Label();
            etiquetaClave.Text = "Clave:";
            etiquetaClave.Left = 30;
            etiquetaClave.Top = 70;
            etiquetaClave.Width = 80;
            Controls.Add(etiquetaClave);

            clave.Left = 120;
            clave.Top = 65;
            clave.Width = 220;
            clave.UseSystemPasswordChar = true;
            Controls.Add(clave);

            Button entrar = new Button();
            entrar.Text = "Entrar";
            entrar.Left = 120;
            entrar.Top = 105;
            entrar.Width = 220;
            entrar.Click += Entrar;
            Controls.Add(entrar);

            error.Left = 30;
            error.Top = 150;
            error.Width = 340;
            error.ForeColor = Color.DarkRed;
            Controls.Add(error);
        }

        private void Entrar(object sender, EventArgs e)
        {
            try
            {
                Sesion sesion = servicio.IniciarSesion(usuario.Text, clave.Text);

                FormPrincipal principal = new FormPrincipal(servicio, sesion);
                Hide();
                principal.ShowDialog();
                Close();
            }
            catch (SeguridadException ex)
            {
                error.Text = ex.Message;
            }
        }
    }
}
