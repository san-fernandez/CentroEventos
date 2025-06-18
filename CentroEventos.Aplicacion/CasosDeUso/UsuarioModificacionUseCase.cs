using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Utilidades;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class UsuarioModificacionUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorUsuario validador, ValidadorUsuarioDuplicado validadorUsuarioDuplicado)
{
    public void Ejecutar(Usuario usuario, int usuarioId)
    {
        if (!servicioAutorizacion.PuedeModificarUsuario(usuarioId, usuario.Id))
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

        if (!validadorUsuarioDuplicado.Validar(usuario, repositorio, out string mensajeErrorDuplicado))
        {
            throw new DuplicadoException(mensajeErrorDuplicado);
        }

        repositorio.Modificar(usuario);
    }
}
