namespace CentroEventos.Aplicacion.Interfaces;

using CentroEventos.Aplicacion.Entidades;
public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    bool Modificar(Usuario usuario);
    bool Eliminar(int id);
    Usuario? ObtenerPorId(int id);
    Usuario? ObtenerPorCorreo(string correo);
    bool ExistePorCorreo(string correo, int? idAExcluir = null);
    bool ExistePorContraseña(string contraseña, int? idAExcluir = null);
    List<Usuario> ObtenerTodos();
    bool UsuarioTienePermiso(int usuarioId, Permiso permisoBuscado);
    bool OtorgarPermiso(int usuarioId, Permiso permiso);
    bool QuitarPermiso(int usuarioId, Permiso permiso);

}