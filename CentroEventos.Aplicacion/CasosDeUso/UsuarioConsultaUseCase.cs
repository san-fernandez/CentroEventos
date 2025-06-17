using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioConsultaUseCase(IRepositorioUsuario repositorio)
{
    public Usuario? Ejecutar(int id)
    {
        return repositorio.ObtenerPorId(id);
    }
}