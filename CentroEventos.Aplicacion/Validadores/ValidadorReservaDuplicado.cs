namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorReservaDuplicado {
    public bool Validar(Reserva reserva, IRepositorioReserva repo, out string mensajeError) {
        mensajeError = "";
        if (repo.PersonaReservaEvento(reserva.PersonaId, reserva.EventoDeportivoId)) {
            mensajeError += "La persona ya tiene una reserva para este evento";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}