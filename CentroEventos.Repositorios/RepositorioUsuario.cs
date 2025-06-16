using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    public void Agregar(Usuario usuario)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Set<Usuario>().Add(usuario);
            context.SaveChanges();
        }
    }

    public void Modificar(Usuario usuario)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Set<Usuario>().Update(usuario);
            context.SaveChanges();
        }
    }

    public void Eliminar(int id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var usuario = context.Set<Usuario>().FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                context.Set<Usuario>().Remove(usuario);
                context.SaveChanges();
            }
        }
    }

    public Usuario? ObtenerPorId(int id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var usuario = context.Set<Usuario>().FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }

    public Usuario? ObtenerPorCorreo(string correo)
    {
        using (var context = new CentroDeportivoContext())
        {
            var usuario = context.Set<Usuario>().FirstOrDefault(u => u.CorreoElectronico == correo);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }

    public List<Usuario> ObtenerTodos()
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Usuario>().ToList();
        }
    }

    public bool UsuarioTienePermiso(int usuarioId, Permiso permisoBuscado)
{
    using (var context = new CentroDeportivoContext())
    {
        var usuario = context.Set<Usuario>()
            .Include(u => u.Permisos)
            .FirstOrDefault(u => u.Id == usuarioId);

        if (usuario != null && usuario.Permisos != null)
        {
            return usuario.Permisos.Any(p => p == permisoBuscado);
        }
        return false;
    }
}
}