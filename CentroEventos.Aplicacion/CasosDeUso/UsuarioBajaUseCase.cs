using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioBajaUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuarioABorrar, int idUsuarioSolicitante)
    {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuarioSolicitante, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException();

        var usuario = repositorio.ObtenerPorId(idUsuarioABorrar);
        if (usuario == null)
            throw new EntidadNotFoundException("Usuario no encontrado.");

        repositorio.Eliminar(idUsuarioABorrar);
    }
}
