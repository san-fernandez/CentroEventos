using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class ListarAsistenciaAEventoUseCase (IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva, IRepositorioPersona repositorioPersona) {

    public List<Persona> Ejecutar(int idEvento) {
        var evento = repositorioEventoDeportivo.ObtenerPorId(idEvento);
        if (evento == null) {
            throw new EntidadNotFoundException(idEvento);
        }
        if (!(evento.FechaHoraInicio < DateTime.Now)) {
            throw new ValidacionException($"El evento con ID {idEvento} aún no ha ocurrido.");
        }
        var reservas = repositorioReserva.ListarPresenteId(idEvento);
        var asistentes = new List<Persona>();

        foreach (var reserva in reservas) {
            var persona = repositorioPersona.ObtenerPorId(reserva.PersonaId);
            if (persona != null) {
                asistentes.Add(persona);
            }
        }

        return asistentes;
    }
}