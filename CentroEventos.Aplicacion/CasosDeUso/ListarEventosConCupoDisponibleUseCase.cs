using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosConCupoDisponibleUseCase (IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva) {
    public List<EventoDeportivo> Ejecutar() {
        var eventos = repositorioEventoDeportivo.Listar();
        var eventosConCupoDisponible = new List<EventoDeportivo>();

        foreach (var evento in eventos) {
            if (evento.FechaHoraInicio > DateTime.Now) {
                int reservas = repositorioReserva.ContarReservas(evento.Id);
                if (reservas < evento.CupoMaximo) {
                    eventosConCupoDisponible.Add(evento);
                }
            }
        }
        return eventosConCupoDisponible;
    }
}