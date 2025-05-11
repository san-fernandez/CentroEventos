namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorPersona
{
    public void Validar(Persona persona)
    {
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            throw new ValidacionException("El nombre del responsable es obligatorio.");

        if (string.IsNullOrWhiteSpace(persona.CorreoElectronico))
            throw new ValidacionException("El correo del responsable es obligatorio.");

        if (_repositorio.ExisteDNI(persona.DNI))
            throw new ValidacionException("Ya existe un responsable con el mismo DNI.");
    }
}
