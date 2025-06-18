using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioLoginUseCase(IRepositorioUsuario repositorio, IServicioHashHelper hashHelper)
{
    public Usuario? Ejecutar(string email, string passwordPlano)
    {
        string passwordHash = hashHelper.CalcularSha256(passwordPlano);

        var usuario = repositorio.ObtenerPorCorreo(email);

        if (usuario != null && usuario.Contraseña == passwordHash)
        {
            return usuario;
        }
        return null;
    }
}