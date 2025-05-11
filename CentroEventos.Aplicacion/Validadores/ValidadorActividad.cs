namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
public class ValidadorActividad
{
    public static Boolean Validar(ActividadDeportiva actividad) {

        if (string.IsNullOrWhiteSpace(actividad.Nombre))
            throw new ValidacionException("El nombre de la actividad es obligatorio.");

        if (string.IsNullOrWhiteSpace(actividad.Descripcion))
            throw new ValidacionException("La descripción de la actividad es obligatoria.");

        if (actividad.Fecha < DateTime.Today)
            throw new FechaInvalidaException();

        if (actividad.CupoMaximo <= 0)
            throw new ValidacionException("El cupo máximo debe ser mayor que cero.");

        if (actividad.Tipo == TipoActividad.Nula)
            throw new ValidacionException("Debe asignarse un tipo de actividad.");

        if (actividad.Responsable == null)
            throw new ValidacionException("Debe asignarse un responsable.");
    }
}
