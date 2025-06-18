using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioRegistroUseCase(IRepositorioUsuario repositorio, IServicioHashHelper hashHelper, ValidadorUsuario validador, ValidadorUsuarioDuplicado validadorUsuarioDuplicado)
{
    public void Ejecutar(Usuario usuario)
    {
        if (!validador.Validar(usuario, out var mensajeError))
            throw new ValidacionException(mensajeError);

        usuario.Contraseña = hashHelper.CalcularSha256(usuario.Contraseña);
        if (!validadorUsuarioDuplicado.Validar(usuario, repositorio, out var mensajeErrorDuplicado))
            throw new DuplicadoException(mensajeErrorDuplicado);

        repositorio.Agregar(usuario);
    }
}