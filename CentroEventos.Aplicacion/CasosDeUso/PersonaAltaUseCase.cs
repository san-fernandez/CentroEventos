using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar(Persona persona, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta)) {
            throw new FalloAutorizacionException();
        }
        if (!ValidadorPersona.Validar(persona, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        if (!ValidadorPersonaDuplicado.Validar(persona, repositorio, out string mensajeErrorDuplicado)) {
            throw new DuplicadoException(mensajeErrorDuplicado);
        }
        repositorio.Agregar(persona);
    }
}
