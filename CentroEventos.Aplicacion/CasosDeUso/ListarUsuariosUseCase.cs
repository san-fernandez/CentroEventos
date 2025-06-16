using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarUsuariosUseCase(IRepositorioUsuario repositorio)
{
    public List<Usuario> Ejecutar()
    {
        return repositorio.ObtenerTodos();
    }
}