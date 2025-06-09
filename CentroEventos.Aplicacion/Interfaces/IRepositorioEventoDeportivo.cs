namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioEventoDeportivo {
    void Agregar(EventoDeportivo e);
    bool Eliminar(int Id);
    bool Modificar(EventoDeportivo evento);
    EventoDeportivo? ObtenerPorId(int Id);
    List<EventoDeportivo> Listar();
    int ObtenerCupoMaximo(int Id);
    bool PersonaResponsable(int IdPersona);
}