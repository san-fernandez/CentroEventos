using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorio, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoBaja)) {
            throw new FalloAutorizacionException();
        }
        bool eliminada = repositorio.Eliminar(evento.Id);
        if (!eliminada)
        {
            throw new EntidadNotFoundException(evento.Id);
        }
    }
}