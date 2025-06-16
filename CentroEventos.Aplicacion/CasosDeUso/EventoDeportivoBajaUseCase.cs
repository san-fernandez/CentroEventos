using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion, ValidadorEventoDeportivoDependencia validadorEventoDeportivoDependencia) {
    public void Ejecutar(int IdEvento, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.EventoBaja)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorEventoDeportivoDependencia.Validar(IdEvento, repositorioReserva, out string mensajeErrorDependencia)) {
            throw new OperacionInvalidaException(mensajeErrorDependencia);
        }
        bool eliminada = repositorio.Eliminar(IdEvento);
        if (!eliminada)
        {
            throw new EntidadNotFoundException(IdEvento);
        }
    }
}