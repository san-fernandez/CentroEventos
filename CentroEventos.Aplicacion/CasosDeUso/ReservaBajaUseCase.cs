using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class ReservaBajaUseCase(IRepositorioReserva repositorio, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int id, int usuarioId) {
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.ReservaBaja)) {
            throw new FalloAutorizacionException();
        }
        bool eliminada = repositorio.Eliminar(id);
        if (!eliminada)
        {
            throw new EntidadNotFoundException(id);
        }
    }
}