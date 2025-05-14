using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase(IRepositorioEventoDeportivo repositorio)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repositorio.Listar();
    }
}