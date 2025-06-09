namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioReserva {
    void Agregar(Reserva reserva);
    bool Eliminar(int Id);
    bool Modificar(Reserva reserva);
    Reserva? ObtenerPorId(int Id);
    List<Reserva> Listar();
    List<Reserva> ListarPresenteId(int IdEventoDeportivo);
    int ContarReservas(int Id);
    bool PersonaReserva(int IdPersona);
    bool PersonaReservaEvento(int IdPersona, int IdEventoDeportivo);
    bool EventoDeportivoReserva(int IdEventoDeportivo);
}