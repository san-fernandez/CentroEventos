using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaConsultaUseCase(IRepositorioPersona repositorio)
{
    public Persona? Ejecutar(int id)
    {
        return repositorio.ObtenerPorId(id);
    }
}