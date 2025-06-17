using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Utilidades;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class UsuarioModificacionUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario, int usuarioId)
    {
        if (!servicioAutorizacion.PuedeModificarUsuario(usuario.Id, usuarioId))
        {
            throw new FalloAutorizacionException();
        }

        var usuarioOriginal = repositorio.ObtenerPorId(usuario.Id);
        if (usuarioOriginal == null)
        {
            throw new EntidadNotFoundException(usuario.Id);
        }

        if (!validador.Validar(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (usuario.Contraseña != usuarioOriginal.Contraseña)
        {
            usuario.Contraseña = HashHelper.CalcularSha256(usuario.Contraseña);
        }

        repositorio.Modificar(usuario);
    }
}
