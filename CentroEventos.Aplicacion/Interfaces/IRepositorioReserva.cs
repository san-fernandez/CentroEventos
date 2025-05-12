namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioReserva {
    void Agregar(Reserva r);
    bool Eliminar(int Id);
    Reserva? ObtenerPorId(int Id);
    List<Reserva> Listar();
}