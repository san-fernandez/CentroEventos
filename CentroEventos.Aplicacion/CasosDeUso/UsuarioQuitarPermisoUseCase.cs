using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class QuitarPermisoAUsuarioUseCase(IRepositorioUsuario repositorio)
{
    public void Ejecutar(int usuarioId, Permiso permiso)
    {
        var usuario = repositorio.ObtenerPorId(usuarioId);
        if (usuario == null)
            throw new Exception("Usuario no encontrado.");

        if (usuario.Permisos != null && !usuario.Permisos.Contains(permiso))
        {
            throw new OperacionInvalidaException("El usuario no tiene este permiso");
        }
        if (usuario.Permisos != null)
        {
            usuario.Permisos.Remove(permiso);
            repositorio.Modificar(usuario);
        }
    }
}