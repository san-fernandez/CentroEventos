using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioModificacionUseCase(IRepositorioUsuario repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.UsuarioModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validador.Validar(usuario, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        bool modificada = repositorio.Modificar(usuario);
        if (!modificada) {
            throw new EntidadNotFoundException(usuario.Id);
        }
    }
}