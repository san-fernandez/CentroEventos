namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioReserva {
    void Agregar(Reserva r);
    void Eliminar(int Id);
    Reserva? ObtenerPorId(int Id);
    List<Reserva> Listar();
}