using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repositorio, IServicioAutorizacion servicioAutorizacion, ValidadorEventoDeportivo validadorEventoDeportivo) {
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoModificacion)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorEventoDeportivo.Validar(evento, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        
        var eventoOriginal = repositorio.ObtenerPorId(evento.Id);
        if (eventoOriginal != null && eventoOriginal.FechaHoraInicio <= DateTime.Now) {
            throw new OperacionInvalidaException("No se puede modificar un evento ya ocurrido");
        }
        bool modificado = repositorio.Modificar(evento);
        if (!modificado)
        {
            throw new EntidadNotFoundException(evento.Id);
        }
    }
}