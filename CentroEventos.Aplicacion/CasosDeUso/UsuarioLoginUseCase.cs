using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Utilidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioLoginUseCase(IRepositorioUsuario repositorio)
{
    public Usuario? Ejecutar(string email, string passwordPlano)
    {
        string passwordHash = HashHelper.CalcularSha256(passwordPlano);

        var usuario = repositorio.ObtenerPorCorreo(email);

        if (usuario != null && usuario.Contraseña == passwordHash)
        {
            return usuario;
        }
        return null;
    }
}