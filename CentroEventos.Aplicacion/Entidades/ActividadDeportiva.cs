namespace CentroEventos.Aplicacion.Entidades;
public enum TipoActividad { Pendiente, Asistio, Ausente, Cancelada }
public class ActividadDeportiva {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public List<DayOfWeek> DiasDisponibles { get; set; } 
    public int CupoMaximo { get; set; }
    public Persona Responsable { get; set; }
    public override string ToString() => $"{Nombre} (Cupo: {CupoMaximo})";
}