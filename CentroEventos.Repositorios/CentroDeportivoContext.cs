using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class CentroDeportivoContext : DbContext
{
    #nullable disable
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CentroDeportivo.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Persona>().ToTable("Persona");
        modelBuilder.Entity<EventoDeportivo>().ToTable("EventoDeportivo");
        modelBuilder.Entity<Reserva>().ToTable("Reserva");
        modelBuilder.Entity<Usuario>().ToTable("Usuario");
    }
}
