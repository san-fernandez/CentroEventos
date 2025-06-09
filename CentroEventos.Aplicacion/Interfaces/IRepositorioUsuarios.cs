namespace CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

public interface IRepositorioUsuarios
{
    void Agregar(Usuario usuario);
    void Modificar(Usuario usuario);
    void Eliminar(int id);
    Usuario? ObtenerPorId(int id);
    Usuario? ObtenerPorCorreo(string correo);
    List<Usuario> ObtenerTodos();
}