using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios
{
    public class ServicioAutorizacionProvisorio : IServicioAutorizacion
    {
        public bool PoseeElPermiso(int idUsuario, Permiso permiso)
        {
            if (idUsuario == 1)
            {
                return true;
            }

            return false;
        }
    }
}