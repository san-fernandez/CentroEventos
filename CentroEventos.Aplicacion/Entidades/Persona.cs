namespace CentroEventos.Aplicacion.Entidades;
public abstract class Persona {
    public int Id { get; set; }
    public string NumeroCarnet { get; set; }
    public int DNI { get; set; }
    public required string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Facultad { get; set; }
    public string Telefono { get; set; }
    public required string CorreoElectronico { get; set; }
    public override string ToString() => $"{Nombre} {Apellido} ({NumeroCarnet})";
}