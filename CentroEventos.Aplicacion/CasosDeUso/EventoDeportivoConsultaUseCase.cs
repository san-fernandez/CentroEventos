using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoConsultaUseCase(IRepositorioEventoDeportivo repositorio)
{
    public EventoDeportivo? Ejecutar(int id)
    {
        return repositorio.ObtenerPorId(id);
    }
}