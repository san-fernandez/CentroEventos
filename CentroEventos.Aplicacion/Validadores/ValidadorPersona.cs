namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorPersona {
    public bool Validar(Persona persona, out string mensajeError) {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(persona.Nombre)) {
            mensajeError += "Nombre esta vacio\n";
        }
        if (string.IsNullOrWhiteSpace(persona.Apellido)) {
            mensajeError += "Apellido esta vacio\n";
        }
        if (string.IsNullOrWhiteSpace(persona.DNI)) {
            mensajeError += "DNI está vacío\n";
        }
        if (string.IsNullOrWhiteSpace(persona.Email)) {
            mensajeError += "Email en blanco\n";
        }
        if( string.IsNullOrWhiteSpace(mensajeError)){
            return true;
        }
        return false;
    }
}