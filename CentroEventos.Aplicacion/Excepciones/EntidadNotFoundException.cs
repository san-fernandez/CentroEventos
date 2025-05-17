namespace CentroEventos.Aplicacion.Excepciones;
public class EntidadNotFoundException : Exception {
    public EntidadNotFoundException(int id) : base($"La entidad con id {id} no existe") { }
    public EntidadNotFoundException(string message) : base(message) { }
}