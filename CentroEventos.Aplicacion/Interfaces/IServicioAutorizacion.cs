using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int usuarioId, Permiso permiso);
    bool PuedeModificarUsuario(int idUsuarioActual, int idUsuarioObjetivo);
}