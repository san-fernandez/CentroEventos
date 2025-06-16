using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Utilidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioAltaUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario, int usuarioSolicitanteId)
    {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioSolicitanteId, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException();

        if (!validador.Validar(usuario, out var mensajeError))
            throw new ValidacionException(mensajeError);

        usuario.Contraseña = HashHelper.CalcularSha256(usuario.Contraseña);
        repositorio.Agregar(usuario);
    }
}