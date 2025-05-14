using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int id, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja)) {
            throw new FalloAutorizacionException();
        }
        bool eliminada = repositorio.Eliminar(id);
        if (!eliminada)
        {
            throw new EntidadNotFoundException(id);
        }
    }
}