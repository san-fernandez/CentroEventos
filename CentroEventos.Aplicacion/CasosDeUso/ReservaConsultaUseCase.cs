using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaConsultaUseCase(IRepositorioReserva repositorio)
{
    public Reserva? Ejecutar(int id)
    {
        return repositorio.ObtenerPorId(id);
    }
}