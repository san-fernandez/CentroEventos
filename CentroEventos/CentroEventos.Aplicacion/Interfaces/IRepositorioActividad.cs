using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioActividad
{
    ActividadDeportiva ObtenerPorId(int id);
    void Agregar(ActividadDeportiva actividad);
    List<ActividadDeportiva> Listar();
    void Eliminar(int id);
}
