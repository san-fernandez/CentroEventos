namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorReservaExiste {
    public static bool Validar(Reserva reserva, out string mensajeError,IRepositorioEventoDeportivo repod,IRepositorioPersona repop) {
        mensajeError = "";
        if (repod.ObtenerPorId(reserva.EventoDeportivoId) == null) {
            mensajeError += "Evento no existe";
        }
        if (repop.ObtenerPorId(reserva.PersonaId) == null) {
            mensajeError += "Persona no existe";
        } 
        if(string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}