namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int Id { get; set; }
    public required string Nombre { get; set; } = " ";
    public required string Descripcion { get; set; } = " ";
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }
    public override string ToString()
    {
        return $"ID: {Id} | Nombre: {Nombre} | Descripción: {Descripcion} | " +
               $"Fecha y Hora: {FechaHoraInicio:yyyy-MM-dd HH:mm} | " +
               $"Duración: {DuracionHoras}h | Cupo Máximo: {CupoMaximo} | Responsable ID: {ResponsableId}";
    }
    public EventoDeportivo() { }
}