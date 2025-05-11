namespace CentroEventos.Aplicacion.Excepciones;
public class EntidadNotFoundException : Exception {
    public EntidadNotFoundException() : base("La entidad no existe") { }
}