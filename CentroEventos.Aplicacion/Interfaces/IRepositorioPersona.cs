namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioPersona {
    void Agregar(Persona p);
    bool Eliminar(int Id);
    bool Modificar(Persona p);
    Persona? ObtenerPorId(int Id);
    Boolean ExisteConDNI(string DNI);
    Boolean ExisteConEmail(string email);
    List<Persona> Listar();
}