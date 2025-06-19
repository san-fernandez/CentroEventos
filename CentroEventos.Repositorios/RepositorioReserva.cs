using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CentroEventos.Repositorios;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    public void Agregar(Reserva reserva)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Set<Reserva>().Add(reserva);
            context.SaveChanges();
        }
    }

    public bool Eliminar(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var reserva = context.Set<Reserva>().FirstOrDefault(r => r.Id == Id);
            if (reserva != null)
            {
                context.Set<Reserva>().Remove(reserva);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }

    public bool Modificar(Reserva reserva)
    {
        using (var context = new CentroDeportivoContext())
        {
            var existente = context.Set<Reserva>().Any(r => r.Id == reserva.Id);
            if (existente)
            {
                context.Set<Reserva>().Update(reserva);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }

    public Reserva? ObtenerPorId(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            var reserva = context.Set<Reserva>().FirstOrDefault(r => r.Id == Id);
            if (reserva != null)
            {
                return reserva;
            }
            else
            {
                return null;
            }
        }
    }

    public List<Reserva> Listar()
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().ToList();
        }
    }

    public List<Reserva> ListarPresenteId(int IdEventoDeportivo)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().Where(r => r.EventoDeportivoId == IdEventoDeportivo && r.EstadoAsistencia==Estado.Presente).ToList();
        }
    }

    public int ContarReservas(int Id)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().Count(r => r.EventoDeportivoId == Id);
        }
    }

    public bool PersonaReserva(int IdPersona)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().Any(r => r.PersonaId == IdPersona);
        }
    }

    public bool PersonaReservaEvento(int IdPersona, int IdEventoDeportivo, int? idAExcluir)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().Any(r => r.PersonaId == IdPersona && (!idAExcluir.HasValue || r.Id != idAExcluir) && r.EventoDeportivoId == IdEventoDeportivo);
        }
    }

    public bool EventoDeportivoReserva(int IdEventoDeportivo)
    {
        using (var context = new CentroDeportivoContext())
        {
            return context.Set<Reserva>().Any(r => r.EventoDeportivoId == IdEventoDeportivo);
        }
    }
}