using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioAltaUseCase(IServicioAutorizacion servicioAutorizacion, IServicioHashHelper hashHelper, IRepositorioUsuario repositorio, ValidadorUsuario validador, ValidadorUsuarioDuplicado validadorUsuarioDuplicado)
{
    public void Ejecutar(Usuario usuario, int usuarioId)
    {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.UsuarioAlta))
        {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validar(usuario, out var mensajeError))
            throw new ValidacionException(mensajeError);

        usuario.Contraseña = hashHelper.CalcularSha256(usuario.Contraseña);
        if (!validadorUsuarioDuplicado.Validar(usuario, repositorio, out var mensajeErrorDuplicado))
            throw new DuplicadoException(mensajeErrorDuplicado);

        repositorio.Agregar(usuario);
    }
}