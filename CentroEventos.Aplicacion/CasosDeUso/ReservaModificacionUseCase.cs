using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEvento, IServicioAutorizacion servicioAutorizacion, ValidadorReservaExiste validadorReservaExiste, ValidadorReservaCupo validadorReservaCupo, ValidadorReservaDuplicado validadorReservaDuplicado)
{
    public void Ejecutar(Reserva reserva, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ReservaModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorReservaExiste.Validar(reserva, repositorioEvento, repositorioPersona, out string mensajeErrorEntidadNoEncontrada)) {
            throw new EntidadNotFoundException(mensajeErrorEntidadNoEncontrada);
        }
        if (!validadorReservaCupo.Validar(reserva, repositorioReserva, repositorioEvento, out string mensajeErrorCupoExcedido, true)) {
            throw new CupoExcedidoException(mensajeErrorCupoExcedido);
        }
        if (!validadorReservaDuplicado.Validar(reserva, repositorioReserva, out string mensajeErrorPersonaDuplicada, reserva.Id))
        {
            throw new DuplicadoException(mensajeErrorPersonaDuplicada);
        }
        var evento = repositorioEvento.ObtenerPorId(reserva.EventoDeportivoId);
        if (evento != null && evento.FechaHoraInicio.AddHours(evento.DuracionHoras) <= DateTime.Now) {
            throw new OperacionInvalidaException("No se puede modificar una reserva de un evento ya ocurrido");
        }
        bool modificada = repositorioReserva.Modificar(reserva);
        if (!modificada) {
            throw new EntidadNotFoundException(reserva.Id);
        }
    }
}