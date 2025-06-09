using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace Almacen.Aplicacion.CasosDeUso;

public class EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion, ValidadorEventoDeportivo validadorEventoDeportivo, ValidadorEventoDeportivoExistePersona validadorEventoDeportivoExistePersona) {
    public void Ejecutar(EventoDeportivo evento, int idUsuario) {
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.EventoAlta)) {
            throw new FalloAutorizacionException();
        }
        if (!validadorEventoDeportivo.Validar(evento, out string mensajeError)) {
            throw new ValidacionException(mensajeError);
        }
        if (!validadorEventoDeportivoExistePersona.Validar(evento, repositorioPersona, out string mensajePersonaNoExiste)) {
            throw new EntidadNotFoundException(evento.ResponsableId);
        }   
        repositorio.Agregar(evento);
    }
}
