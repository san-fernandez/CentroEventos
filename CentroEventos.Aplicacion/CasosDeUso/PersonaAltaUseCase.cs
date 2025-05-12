using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase(IRepositorioPersona repositorio, ValidadorPersona validador1, ValidadorPersona2 validador2)
{
    public void Ejecutar(Persona persona)
    {
        if (!validador1.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!validador2.Validar(persona, out string mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        repositorio.Agregar(persona);
    }
}
