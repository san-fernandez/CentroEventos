namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorReservaExiste {
    public bool Validar(Reserva reserva, IRepositorioEventoDeportivo repod,IRepositorioPersona repop, out string mensajeError) {
        mensajeError = "";
        if (repod.ObtenerPorId(reserva.EventoDeportivoId) == null) {
            mensajeError += "Evento no existe\n";
        }
        if (repop.ObtenerPorId(reserva.PersonaId) == null) {
            mensajeError += "Persona no existe\n";
        } 
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}