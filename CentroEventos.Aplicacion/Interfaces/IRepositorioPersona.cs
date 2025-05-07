using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    void Eliminar(int id);
    Persona ObtenerPorId(int id);
    List<Persona> Listar();
}