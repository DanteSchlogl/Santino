using System;
using System.Windows.Forms;
using LoginApp.BLL;
using LoginApp.Domain;

namespace LoginApp.UI
{
    // Pantalla principal: el menu se arma segun el perfil del usuario.
    public class FormPrincipal : Form
    {
        private readonly SeguridadServicio servicio;
        private readonly Sesion sesion;
        private readonly TreeView menu = new TreeView();
        private readonly Label abierto = new Label();

        public FormPrincipal(SeguridadServicio servicio, Sesion sesion)
        {
            this.servicio = servicio;
            this.sesion = sesion;
            ArmarPantalla();
            CargarMenu();
        }

        private void ArmarPantalla()
        {
            Text = "Pantalla principal";
            Width = 720;
            Height = 460;
            StartPosition = FormStartPosition.CenterScreen;

            Label quien = new Label();
            quien.Text = "Usuario: " + sesion.Usuario.Nombre +
                         "   -   Perfil: " + sesion.Usuario.Perfil.Nombre;
            quien.Left = 20;
            quien.Top = 15;
            quien.Width = 500;
            Controls.Add(quien);

            menu.Left = 20;
            menu.Top = 50;
            menu.Width = 310;
            menu.Height = 330;
            menu.HideSelection = false;
            menu.AfterSelect += Abrir;
            Controls.Add(menu);

            abierto.Left = 350;
            abierto.Top = 50;
            abierto.Width = 340;
            abierto.Height = 330;
            abierto.Text = "Elegi una opcion del menu.";
            abierto.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(abierto);

            Button salir = new Button();
            salir.Text = "Cerrar sesion";
            salir.Left = 350;
            salir.Top = 390;
            salir.Width = 160;
            salir.Click += Salir;
            Controls.Add(salir);
        }

        // Pide el menu ya filtrado por el perfil.
        private void CargarMenu()
        {
            MenuServicio servicioMenu = new MenuServicio();
            Funcionalidad catalogo = CatalogoFuncionalidades.Armar();
            Funcionalidad visible = servicioMenu.ArmarMenu(catalogo, sesion.Usuario.Perfil);

            menu.Nodes.Clear();
            AgregarNodos(visible, menu.Nodes);
            menu.ExpandAll();
        }

        private void AgregarNodos(Funcionalidad funcionalidad, TreeNodeCollection destino)
        {
            foreach (Funcionalidad hijo in funcionalidad.ObtenerHijos())
            {
                TreeNode nodo = destino.Add(hijo.Nombre);

                if (hijo.TieneHijos())
                {
                    AgregarNodos(hijo, nodo.Nodes);
                }
            }
        }

        private void Abrir(object sender, TreeViewEventArgs e)
        {
            // Solo las simples abren algo.
            if (e.Node.Nodes.Count == 0)
            {
                abierto.Text = "Abriendo: " + e.Node.Text;
            }
        }

        private void Salir(object sender, EventArgs e)
        {
            servicio.CerrarSesion();
            Close();
        }
    }
}
