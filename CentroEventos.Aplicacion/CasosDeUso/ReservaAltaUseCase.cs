using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase (IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEvento, IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta)) {
            throw new FalloAutorizacionException();
        }
        if (!ValidadorReservaExiste.Validar(reserva, repositorioEvento, repositorioPersona, out string mensajeErrorEntidadNoEncontrada)) {
            throw new EntidadNotFoundException(mensajeErrorEntidadNoEncontrada);
        }
        if (!ValidadorReservaCupo.Validar(reserva, repositorioReserva, repositorioEvento, out string mensajeErrorCupoExcedido)) {
            throw new CupoExcedidoException(mensajeErrorCupoExcedido);
        }
        if (!ValidadorReservaDuplicado.Validar(reserva, repositorioReserva, out string mensajeErrorPersonaDuplicada)) {
            throw new DuplicadoException(mensajeErrorPersonaDuplicada);
        }
        reserva.EstadoAsistencia = Estado.Pendiente;
        reserva.FechaAltaReserva = DateTime.Now;
        repositorioReserva.Agregar(reserva);
    }
}