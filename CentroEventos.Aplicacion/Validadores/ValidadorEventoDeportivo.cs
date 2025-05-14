namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorEventoDeportivo
{
    public static bool Validar(EventoDeportivo evento, out string mensajeError) {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(evento.Nombre)) {
            mensajeError += "Nombre esta vacio ";
        }
        if (string.IsNullOrWhiteSpace(evento.Descripcion)) {
            mensajeError += "Descripcion esta vacia ";
        }
        if (evento.DuracionHoras<=0) {
            mensajeError += "Duracion tiene que ser mayor a 0 ";
        }
        if (evento.CupoMaximo<=0){
            mensajeError += "CupoMaximo tiene que ser mayor a 0 ";
        }  
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}