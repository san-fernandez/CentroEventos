using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repositorio, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion, ValidadorPersonaDependencia validadorPersonaDependencia)
{
    public void Ejecutar(int id, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorPersonaDependencia.Validar(id, repositorioEventoDeportivo, repositorioReserva, out string mensajeErrorDependencia)) {
            throw new OperacionInvalidaException(mensajeErrorDependencia);
        }
        bool eliminada = repositorio.Eliminar(id);
        if (!eliminada)
        {
            throw new EntidadNotFoundException(id);
        }
    }
}