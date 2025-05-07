namespace CentroEventos.Aplicacion.Entidades;
public class ActividadDeportiva {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public TipoActividad Tipo { get; set; } = default(TipoActividad);
    public int CupoMaximo { get; set; }
    public Docente Responsable { get; set; }
    public DateTime Fecha { get; set; }
    public override string ToString() => $"{Nombre} (Cupo: {CupoMaximo})";
}