using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ListarPersonasUseCase(IRepositorioPersona repositorio)
{
    public List<Persona> Ejecutar()
    {
        return repositorio.Listar();
    }
}