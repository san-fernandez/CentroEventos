using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ReservaModificacionUseCase(IRepositorioReserva repositorioReserva, IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEvento, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Reserva reserva, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion)) {
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
        bool modificada = repositorioReserva.Modificar(reserva);
        if (!modificada) {
            throw new EntidadNotFoundException(reserva.Id);
        }
    }
}