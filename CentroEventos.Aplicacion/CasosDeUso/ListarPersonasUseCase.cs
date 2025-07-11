using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase(IRepositorioPersona repositorio)
{
    public List<Persona> Ejecutar()
    {
        return repositorio.Listar();
    }
}