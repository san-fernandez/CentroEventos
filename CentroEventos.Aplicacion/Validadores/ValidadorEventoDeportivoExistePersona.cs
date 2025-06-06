namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorEventoDeportivoExistePersona
{
    public bool Validar(EventoDeportivo evento, IRepositorioPersona repo, out string mensajeError) {
        mensajeError = "";
        if (repo.ObtenerPorId(evento.ResponsableId) == null){
            mensajeError += "Responsable del evento no existe";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}