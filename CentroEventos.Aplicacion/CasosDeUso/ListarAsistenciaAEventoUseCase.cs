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
        if (evento.FechaHoraInicio > DateTime.Now)
        {
            throw new Exception($"El evento con ID {idEvento} aún no ha ocurrido.");  // necesario?
        }

        var reservas = repositorioReserva.Listar();
        var asistentes = new List<Persona>();

        foreach (var reserva in reservas) {
            if ((reserva.EventoDeportivoId == idEvento) && (reserva.EstadoAsistencia == Estado.Presente)) {
                var persona = repositorioPersona.ObtenerPorId(reserva.PersonaId);
                if (persona != null) {
                    asistentes.Add(persona);
                }
            }
        }

        return asistentes;
    }
}