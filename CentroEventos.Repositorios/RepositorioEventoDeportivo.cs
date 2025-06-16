using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CentroEventos.Repositorios;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public void Agregar(EventoDeportivo e)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Set<EventoDeportivo>().Add(e);
            context.SaveChanges();
        }
    }

    public bool Eliminar(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var evento = context.Set<EventoDeportivo>().Where(x => x.Id == Id).SingleOrDefault();
            if (evento != null)
            {
                context.Set<EventoDeportivo>().Remove(evento);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Modificar(EventoDeportivo evento)
    {
        using (var context = new CentroDeportivoContext())
        {
            var existe = context.Set<EventoDeportivo>().Any(x => x.Id == evento.Id);
            if (existe)
            {
                context.Set<EventoDeportivo>().Update(evento);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public EventoDeportivo? ObtenerPorId(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var evento = context.Set<EventoDeportivo>().Where(x => x.Id == Id).SingleOrDefault();
            if (evento != null)
            {
                return evento;
            }
            else
            {
                return null;
            }
        }
    }

    public List<EventoDeportivo> Listar()
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<EventoDeportivo>().ToList();
        }
    }

    public int ObtenerCupoMaximo(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var evento = context.Set<EventoDeportivo>().Where(x => x.Id == Id).SingleOrDefault();
            return evento?.CupoMaximo ?? 0;
        }
    }

    public bool PersonaResponsable(int IdPersona)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<EventoDeportivo>().Any(x => x.ResponsableId == IdPersona);
        }
    }
}