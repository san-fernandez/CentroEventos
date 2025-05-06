using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    Persona ObtenerPorId(int id);
    void Agregar(Persona persona);
    void Eliminar(int id);
    List<Persona> Listar();
}