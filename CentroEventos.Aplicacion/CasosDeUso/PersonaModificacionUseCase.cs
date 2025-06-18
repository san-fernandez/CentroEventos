using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaModificacionUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorPersona validadorPersona, ValidadorPersonaDuplicado validadorPersonaDuplicado)
{
    public void Ejecutar(Persona persona, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.UsuarioModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorPersona.Validar(persona, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        if (!validadorPersonaDuplicado.Validar(persona, repositorio, out string mensajeErrorDuplicado))
        {
            throw new DuplicadoException(mensajeErrorDuplicado);
        }
        bool modificada = repositorio.Modificar(persona);
        if (!modificada) {
            throw new EntidadNotFoundException(persona.Id);
        }
    }
}