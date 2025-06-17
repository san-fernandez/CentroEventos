using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacion(IRepositorioUsuario repositorio) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int usuarioId, Permiso permiso)
    {
        if (usuarioId == 1) return true;
        var usuario = repositorio.ObtenerPorId(usuarioId);
        if (usuario != null && usuario.Permisos != null)
        {
            return usuario.Permisos.Contains(permiso);
        }
        return false;
    }

    public bool PuedeModificarUsuario(int idUsuarioActual, int idUsuarioObjetivo)
    {
        if (idUsuarioActual == idUsuarioObjetivo)
            return true;
        return PoseeElPermiso(idUsuarioActual, Permiso.UsuarioModificacion);
    }
}