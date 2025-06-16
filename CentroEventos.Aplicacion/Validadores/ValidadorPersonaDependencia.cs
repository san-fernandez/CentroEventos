namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorPersonaDependencia {
    public bool Validar(int IdPersona, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva, out string mensajeError) {
        mensajeError = "";
        if (repositorioEventoDeportivo.PersonaResponsable(IdPersona)) {
            mensajeError += "La persona es responsable de un evento deportivo\n";
        }
        if (repositorioReserva.PersonaReserva(IdPersona)){
            mensajeError += "La persona tiene una reserva hecha\n";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;   
        }
        return false;
    }
}