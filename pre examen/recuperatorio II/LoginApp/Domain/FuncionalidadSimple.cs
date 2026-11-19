namespace LoginApp.Domain
{
    // Funcionalidad atomica: representa una funcion concreta del software.
    public class FuncionalidadSimple : Funcionalidad
    {
        public FuncionalidadSimple(string nombre)
        {
            Nombre = nombre;
        }
    }
}
