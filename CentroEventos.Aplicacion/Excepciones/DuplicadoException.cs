namespace CentroEventos.Aplicacion.Excepciones;
public class DuplicadoException : Exception {
    public DuplicadoException() : base("Entidad ya existente") { }
}