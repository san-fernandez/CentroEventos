using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarReservasUseCase(IRepositorioReserva repositorio)
{
    public List<Reserva> Ejecutar()
    {
        return repositorio.Listar();
    }
}