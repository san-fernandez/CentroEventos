namespace CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
public class ValidadorUsuarioDuplicado {
    public bool Validar(Usuario usuario, IRepositorioUsuario repo, out string mensajeError) {
        mensajeError = "";
        if (repo.ExistePorCorreo(usuario.CorreoElectronico, usuario.Id))
        {
            mensajeError += "Ese email ya está en uso\n";
        }
        if (string.IsNullOrWhiteSpace(mensajeError)){
            return true;   
        }
        return false;
    }
}