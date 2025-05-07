using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioActividad
{
    void Agregar(ActividadDeportiva actividad);
    void Eliminar(int id);
    ActividadDeportiva ObtenerPorId(int id);
    List<ActividadDeportiva> Listar();
}
