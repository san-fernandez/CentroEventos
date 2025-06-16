using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public bool Validar(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            mensajeError += "El nombre no puede estar vacío\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError += "El apellido no puede estar vacío\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.CorreoElectronico))
        {
            mensajeError += "El correo electrónico no puede estar vacío\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
        {
            mensajeError += "La contraseña no puede estar vacía\n";
        }
        if (string.IsNullOrWhiteSpace(mensajeError))
        {
            return true;
        }
        return false;
    }
}