namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioPersona {
    void Agregar(Persona p);
    bool Eliminar(int Id);
    Persona? ObtenerPorId(int Id);
    Boolean ExisteConDNI(int DNI);
    Boolean ExisteConEmail(string email);
    List<Persona> Listar();
}