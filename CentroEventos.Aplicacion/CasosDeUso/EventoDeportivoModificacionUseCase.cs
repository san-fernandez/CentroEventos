using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoModificacionUseCase(IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva, IServicioAutorizacion servicioAutorizacion, ValidadorEventoDeportivo validadorEventoDeportivo) {
    public void Ejecutar(EventoDeportivo evento, int usuarioId) {
        
        if (!servicioAutorizacion.PoseeElPermiso(usuarioId, Permiso.EventoModificacion))
        {
            throw new FalloAutorizacionException();
        }
        if (!validadorEventoDeportivo.Validar(evento, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        
        var eventoOriginal = repositorio.ObtenerPorId(evento.Id);
        if (eventoOriginal != null && eventoOriginal.FechaHoraInicio <= DateTime.Now) {
            throw new OperacionInvalidaException("No se puede modificar un evento ya ocurrido");
        }
        if (eventoOriginal != null && (evento.CupoMaximo) < (repositorioReserva.ContarReservas(eventoOriginal.Id))) {
            throw new CupoExcedidoException("El cupo máximo del evento debe ser mayor a la cantidad de reservas ya hechas");
        }
        bool modificado = repositorio.Modificar(evento);
        if (!modificado)
        {
            throw new EntidadNotFoundException(evento.Id);
        }
    }
}