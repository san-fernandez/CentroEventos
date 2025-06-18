namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioPersona {
    void Agregar(Persona p);
    bool Eliminar(int Id);
    bool Modificar(Persona p);
    Persona? ObtenerPorId(int Id);
    bool ExisteConDNI(string dni, int? idAExcluir = null);
    bool ExisteConEmail(string email, int? idAExcluir = null);
    List<Persona> Listar();
}