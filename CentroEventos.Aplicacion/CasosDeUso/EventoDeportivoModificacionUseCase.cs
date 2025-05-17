using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repositorio, IServicioAutorizacion servicioAutorizacion) {
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (evento.FechaHoraInicio <= DateTime.Now) {
            throw new OperacionInvalidaException("No se puede modificar un evento pasado");
        }
        bool modificado = repositorio.Modificar(evento);
        if (!modificado)
        {
            throw new EntidadNotFoundException(evento.Id);
        }
    }
}