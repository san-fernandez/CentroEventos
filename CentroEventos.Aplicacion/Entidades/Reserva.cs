namespace CentroEventos.Aplicacion.Entidades;
public class Reserva {
    public int Id { get; set; }
    public int PersonaId { get; set; }  // tiene que existir
    public int EventoDeportivoId { get; set; }  // tiene que existir
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }
}

// misma persona no puede reservar dos veces el mismo evento
// verificar cuantos cupos quedan en el evento deportivo