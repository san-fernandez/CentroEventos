namespace CentroEventos.Aplicacion.Entidades;
public enum Permiso
{
    ActividadAlta,
    ActividadModificacion,
    ActividadBaja,
    DeporteAlta,
    DeporteModificacion,
    DeporteBaja,
    InscripcionAlta,
    InscripcionModificacion,
    InscripcionBaja,
    UsuarioAlta,
    UsuarioModificacion,
    UsuarioBaja
}
public class Usuario {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public Permiso Permisos { get; set; }
}