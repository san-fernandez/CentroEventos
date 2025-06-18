using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CentroEventos.Repositorios;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void Agregar(Persona p)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Set<Persona>().Add(p);
            context.SaveChanges();
        }
    }

    public bool Eliminar(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var persona = context.Set<Persona>().Where(x => x.Id == Id).SingleOrDefault();
            if (persona != null)
            {
                context.Set<Persona>().Remove(persona);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Modificar(Persona p)
    {
        using (var context = new CentroDeportivoContext())
        {
            var existe = context.Set<Persona>().Any(x => x.Id == p.Id);
            if (existe)
            {
                context.Set<Persona>().Update(p);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public Persona? ObtenerPorId(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var persona = context.Set<Persona>().Where(x => x.Id == Id).SingleOrDefault();
            if (persona != null)
            {
                return persona;
            }
            else
            {
                return null;
            }
        }
    }

    public bool ExisteConDNI(string DNI, int? idAExcluir = null)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Personas.Any(p => p.DNI == DNI && (!idAExcluir.HasValue || p.Id != idAExcluir));
        }
    }

    public bool ExisteConEmail(string email, int? idAExcluir = null)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Personas.Any(p => p.Email == email && (!idAExcluir.HasValue || p.Id != idAExcluir));
        }
    }

    public List<Persona> Listar()
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Persona>().ToList();
        }
    }
}