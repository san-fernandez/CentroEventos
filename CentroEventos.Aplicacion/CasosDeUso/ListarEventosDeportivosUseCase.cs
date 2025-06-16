using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosDeportivosUseCase(IRepositorioEventoDeportivo repositorio)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repositorio.Listar();
    }
}