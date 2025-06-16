using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Utilidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioAltaUseCase(IRepositorioUsuario repositorio, ValidadorUsuario validador, ValidadorUsuarioDuplicado validadorUsuarioDuplicado)
{
    public void Ejecutar(Usuario usuario)
    {
        if (!validador.Validar(usuario, out var mensajeError))
            throw new ValidacionException(mensajeError);

        usuario.Contraseña = HashHelper.CalcularSha256(usuario.Contraseña);
        if (!validadorUsuarioDuplicado.Validar(usuario, repositorio, out var mensajeErrorDuplicado))
            throw new DuplicadoException(mensajeErrorDuplicado);

        repositorio.Agregar(usuario);
    }
}