namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }
    public override string ToString()
    {
        return $"ID: {Id} | PersonaID: {PersonaId} | EventoID: {EventoDeportivoId} | " +
               $"Fecha Alta: {FechaAltaReserva:yyyy-MM-dd HH:mm} | Estado: {EstadoAsistencia}";
    }
    public Reserva() { }
}

