using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ListarReservasUseCase(IRepositorioReserva repositorio)
{
    public List<Reserva> Ejecutar()
    {
        return repositorio.Listar();
    }
}