namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class ValidadorEventoDeportivoDependencia
{
    public bool Validar(int IdEvento, IRepositorioReserva repo, out string mensajeError) {
        mensajeError = "";
        if (repo.EventoDeportivoReserva(IdEvento)){
            mensajeError += "Existen reservas para ese evento deportivo";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}