using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase (IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEvento, IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion, ValidadorReservaExiste validadorReservaExiste, ValidadorReservaCupo validadorReservaCupo, ValidadorReservaDuplicado validadorReservaDuplicado)
{
    public void Ejecutar(Reserva reserva, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ReservaAlta)) {
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
        reserva.EstadoAsistencia = Estado.Pendiente;
        reserva.FechaAltaReserva = DateTime.Now;
        repositorioReserva.Agregar(reserva);
    }
}