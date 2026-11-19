namespace LoginApp.Domain
{
    // La sesion abierta: quien esta usando el sistema.
    public class Sesion
    {
        public Sesion(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Usuario Usuario { get; set; }
    }
}
