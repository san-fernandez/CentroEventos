namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorResponsable
{
    private readonly IRepositorioPersona _repositorio;

    public ValidadorResponsable(IRepositorioPersona repositorio)
    {
        _repositorio = repositorio;
    }

    public void Validar(Persona responsable)
    {
        if (string.IsNullOrWhiteSpace(responsable.Nombre))
            throw new ValidacionException("El nombre del responsable es obligatorio.");

        if (string.IsNullOrWhiteSpace(responsable.Correo))
            throw new ValidacionException("El correo del responsable es obligatorio.");

        if (_repositorio.ExisteDNI(responsable.DNI))
            throw new ValidacionException("Ya existe un responsable con el mismo DNI.");
    }
}
