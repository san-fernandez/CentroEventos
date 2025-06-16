using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacion (IRepositorioUsuario repositorio) : IServicioAutorizacion 
{
    public bool PoseeElPermiso(int usuarioId, Permiso permiso)
    {
        if (usuarioId == 1) return true;
        else return repositorio.UsuarioTienePermiso(usuarioId, permiso);
    }
}