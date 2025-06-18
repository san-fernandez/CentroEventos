namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorReservaCupo
{
    public bool Validar(Reserva reserva, IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEventoDeportivo, out string mensajeError, bool excluirReserva = false)
    {
        mensajeError = "";
        int reservas = repositorioReserva.ContarReservas(reserva.EventoDeportivoId);
        int cupoMaximo = repositorioEventoDeportivo.ObtenerCupoMaximo(reserva.EventoDeportivoId);
        if (excluirReserva) reservas -= 1;
        if (reservas == cupoMaximo)
        {
            mensajeError += "No hay cupos disponibles";
        }
        if (string.IsNullOrWhiteSpace(mensajeError))
        {
            return true;
        }
        return false;
    }
}