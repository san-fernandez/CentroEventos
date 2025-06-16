using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios;
public class ServicioUsuarioSesion : IServicioUsuarioSesion
{
    public Usuario? UsuarioActual { get; private set; }
    public void IniciarSesion(Usuario usuario)
    {
        UsuarioActual = usuario;
    }
    public void CerrarSesion()
    {
        UsuarioActual = null;
    }
    public bool EstaAutenticado => UsuarioActual != null;
}