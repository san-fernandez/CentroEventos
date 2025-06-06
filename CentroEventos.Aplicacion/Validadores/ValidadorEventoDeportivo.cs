namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorEventoDeportivo
{
    public bool Validar(EventoDeportivo evento, out string mensajeError) {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(evento.Nombre)) {
            mensajeError += "Nombre esta vacio\n";
        }
        if (string.IsNullOrWhiteSpace(evento.Descripcion)) {
            mensajeError += "Descripcion esta vacia\n";
        }
        if (evento.FechaHoraInicio < DateTime.Now) {
            mensajeError += "La fecha del evento debe ser futura\n";
        }
        if (evento.DuracionHoras <= 0)
        {
            mensajeError += "Duracion tiene que ser mayor a 0\n";
        }
        if (evento.CupoMaximo <= 0){
            mensajeError += "CupoMaximo tiene que ser mayor a 0\n";
        }  
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}