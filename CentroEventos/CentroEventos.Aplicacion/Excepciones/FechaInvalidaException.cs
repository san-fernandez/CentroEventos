namespace CentroEventos.Aplicacion.Excepciones;
public class FechaInvalidaException : Exception {
    public FechaInvalidaException() : base("La fecha de la actividad es inválida.") { }
}