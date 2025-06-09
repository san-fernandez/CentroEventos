using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioUsuarioSesion
{
    Usuario? UsuarioActual { get; }
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
    bool EstaAutenticado { get; }
}