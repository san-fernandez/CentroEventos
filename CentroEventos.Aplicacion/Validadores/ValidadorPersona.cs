namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorPersona {
    public static bool Validar(Persona persona, out string mensajeError) {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(persona.Nombre)) {
            mensajeError += "Nombre esta vacio";
        }
        if (string.IsNullOrWhiteSpace(persona.Apellido)) {
            mensajeError += "Apellido esta vacio";
        }
        if (string.IsNullOrWhiteSpace(persona.DNI)) {
            mensajeError += "DNI está vacío";
        }
        if (string.IsNullOrWhiteSpace(persona.Email)) {
            mensajeError += "Email en blanco";
        }
        if( string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}