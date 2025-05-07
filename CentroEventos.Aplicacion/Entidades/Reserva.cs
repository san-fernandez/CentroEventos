namespace CentroEventos.Aplicacion.Entidades;
public class Reserva {
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int ActividadDeportivaId { get; set; }
    public DateTime FechaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }
}