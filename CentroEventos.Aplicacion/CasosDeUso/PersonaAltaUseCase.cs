using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorPersona validadorPersona, ValidadorPersonaDuplicado validadorPersonaDuplicado) {
    public void Ejecutar(Persona persona, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorPersona.Validar(persona, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        if (!validadorPersonaDuplicado.Validar(persona, repositorio, out string mensajeErrorDuplicado)) {
            throw new DuplicadoException(mensajeErrorDuplicado);
        }
        repositorio.Agregar(persona);
    }
}
