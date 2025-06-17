using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class OtorgarPermisoAUsuarioUseCase(IRepositorioUsuario repositorio)
{
    public void Ejecutar(int usuarioId, Permiso permiso)
    {
        var usuario = repositorio.ObtenerPorId(usuarioId);
        if (usuario == null)
            throw new Exception("Usuario no encontrado.");
        if (!usuario.Permisos.Contains(permiso))
        {
            usuario.Permisos.Add(permiso);
            repositorio.Modificar(usuario);
        }
    }
}