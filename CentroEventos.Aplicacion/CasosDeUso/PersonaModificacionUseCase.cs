using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaModificacionUseCase(IRepositorioPersona repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorPersona validadorPersona)
{
    public void Ejecutar(Persona persona, Usuario usuario) {
        if (!servicioAutorizacion.PoseeElPermiso(usuario, Permiso.UsuarioModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorPersona.Validar(persona, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        bool modificada = repositorio.Modificar(persona);
        if (!modificada) {
            throw new EntidadNotFoundException(persona.Id);
        }
    }
}