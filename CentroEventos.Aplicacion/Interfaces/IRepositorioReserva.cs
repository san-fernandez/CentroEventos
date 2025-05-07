using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void Agregar(Reserva reserva);
    void Actualizar(Reserva reserva);
    Reserva ObtenerPorId(int id);
    List<Reserva> Listar();
}
