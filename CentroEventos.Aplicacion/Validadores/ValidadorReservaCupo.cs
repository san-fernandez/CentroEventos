namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorReservaCupo {
    public bool Validar(Reserva reserva, IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEventoDeportivo, out string mensajeError) {
        mensajeError = "";
        if (repositorioReserva.ContarReservas(reserva.EventoDeportivoId) == repositorioEventoDeportivo.ObtenerCupoMaximo(reserva.EventoDeportivoId)) { 
            mensajeError += "No hay cupos disponibles";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
          return true;
        }
        return false;
    }
}