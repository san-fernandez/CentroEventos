namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public required string Nombre { get; set; } = " ";
    public required string Apellido { get; set; } = " ";
    public required string CorreoElectronico { get; set; } = " ";
    public required string Contraseña { get; set; } = " ";
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    public Usuario(string nombre, string apellido, string correoElectronico, string contraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correoElectronico;
        Contraseña = contraseña;
    }
    public Usuario() { }
}