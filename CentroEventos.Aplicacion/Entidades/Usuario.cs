namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string CorreoElectronico { get; set; }
    public required string Contraseña { get; set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();
}
// crear validador usuario