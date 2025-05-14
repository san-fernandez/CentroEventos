namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioReserva {
    void Agregar(Reserva reserva);
    bool Eliminar(int Id);
    bool Modificar(Reserva reserva);
    Reserva? ObtenerPorId(int Id);
    List<Reserva> Listar();
    int ContarReservas(int Id);
    bool PersonaReserva(int IdPersona, int IdEventoDeportivo);
}