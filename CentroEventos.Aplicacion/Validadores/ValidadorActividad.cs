namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
public class ValidadorActividad
{
    public void Validar(ActividadDeportiva actividad)
    {
        if (string.IsNullOrWhiteSpace(actividad.Nombre))
            throw new ValidacionException("El nombre de la actividad es obligatorio.");

        if (string.IsNullOrWhiteSpace(actividad.Descripcion))
            throw new ValidacionException("La descripción de la actividad es obligatoria.");

        if (actividad.Fecha < DateTime.Today)
            throw new FechaInvalidaException("La fecha de la actividad debe ser igual o posterior a hoy.");

        if (actividad.CupoMaximo <= 0)
            throw new ValidacionException("El cupo máximo debe ser mayor que cero.");

        if (actividad.TipoActividad == null)
            throw new ValidacionException("La actividad debe tener un tipo de actividad válido.");

        if (actividad.Responsable == null)
            throw new ValidacionException("La actividad debe tener un responsable válido.");
    }
}
