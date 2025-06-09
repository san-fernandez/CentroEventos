using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(Usuario usuario, Permiso permiso) => usuario.Permisos.Contains(permiso);
}