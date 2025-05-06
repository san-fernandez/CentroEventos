using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void Agregar(Reserva reserva);
    Reserva ObtenerPorId(int id);
    List<Reserva> Listar();
    void Actualizar(Reserva reserva);
}
