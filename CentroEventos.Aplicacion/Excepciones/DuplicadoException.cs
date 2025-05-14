namespace CentroEventos.Aplicacion.Excepciones;
public class DuplicadoException : Exception {
    public DuplicadoException(string message) : base(message) { }
}