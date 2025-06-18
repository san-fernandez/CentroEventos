using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class OtorgarPermisoAUsuarioUseCase(IRepositorioUsuario repositorio)
{
    public void Ejecutar(int usuarioId, Permiso permiso)
    {
        var usuario = repositorio.ObtenerPorId(usuarioId);
        if (usuario == null)
            throw new Exception("Usuario no encontrado.");
        if (usuario.Permisos.Contains(permiso))
        {
            throw new DuplicadoException("El usuario ya tiene este permiso");
        }
        usuario.Permisos.Add(permiso);
        repositorio.Modificar(usuario);
    }
}