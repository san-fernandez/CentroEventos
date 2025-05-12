namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioEventoDeportivo {
    void Agregar(EventoDeportivo e);
    bool Eliminar(int Id);
    EventoDeportivo? ObtenerPorId(int Id);
    List<EventoDeportivo> Listar();
}