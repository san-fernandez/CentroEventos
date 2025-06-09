namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorPersonaDuplicado {
    public bool Validar(Persona persona, IRepositorioPersona repo, out string mensajeError) {
        mensajeError = "";
        if (repo.ExisteConDNI(persona.DNI)) {
            mensajeError += "DNI duplicado\n";
        }
        if (repo.ExisteConEmail(persona.Email)){
            mensajeError += "Email duplicado\n";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;   
        }
        return false;
    }
}