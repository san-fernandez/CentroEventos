namespace CentroEventos.Aplicacion.Entidades;
public class Persona {
    public int Id { get; set; }
    public required string DNI { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public required string Telefono { get; set; }
    public override string ToString()
    {
        return $"ID: {Id} | DNI: {DNI} | Nombre: {Nombre} {Apellido} | Email: {Email} | Teléfono: {Telefono}";
    }
}