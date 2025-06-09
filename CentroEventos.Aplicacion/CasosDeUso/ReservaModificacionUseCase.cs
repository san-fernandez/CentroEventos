using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEvento, IServicioAutorizacion servicioAutorizacion, ValidadorReservaExiste validadorReservaExiste, ValidadorReservaCupo validadorReservaCupo, ValidadorReservaDuplicado validadorReservaDuplicado)
{
    public void Ejecutar(Reserva reserva, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorReservaExiste.Validar(reserva, repositorioEvento, repositorioPersona, out string mensajeErrorEntidadNoEncontrada)) {
            throw new EntidadNotFoundException(mensajeErrorEntidadNoEncontrada);
        }
        if (!validadorReservaCupo.Validar(reserva, repositorioReserva, repositorioEvento, out string mensajeErrorCupoExcedido)) {
            throw new CupoExcedidoException(mensajeErrorCupoExcedido);
        }
        if (!validadorReservaDuplicado.Validar(reserva, repositorioReserva, out string mensajeErrorPersonaDuplicada)) {
            throw new DuplicadoException(mensajeErrorPersonaDuplicada);
        }
        var evento = repositorioEvento.ObtenerPorId(reserva.Id);
        if (evento != null && evento.FechaHoraInicio <= DateTime.Now) {
            throw new OperacionInvalidaException("No se puede modificar una reserva de un evento ya ocurrido");
        }
        bool modificada = repositorioReserva.Modificar(reserva);
        if (!modificada) {
            throw new EntidadNotFoundException(reserva.Id);
        }
    }
}