using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

CentroDeportivoInicializar.InicializarBaseDeDatos();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    // Casos de uso Usuario
    .AddTransient<UsuarioAltaUseCase>()
    .AddTransient<UsuarioBajaUseCase>()
    .AddTransient<UsuarioModificacionUseCase>()
    .AddTransient<UsuarioLoginUseCase>()
    .AddTransient<ListarUsuariosUseCase>()

    // Casos de uso Persona
    /* .AddTransient<PersonaAltaUseCase>()
     .AddTransient<PersonaBajaUseCase>()
     .AddTransient<PersonaModificacionUseCase>()
     .AddTransient<ListarPersonasUseCase>()

     // Casos de uso Evento Deportivo
     .AddTransient<EventoDeportivoAltaUseCase>()
     .AddTransient<EventoDeportivoBajaUseCase>()
     .AddTransient<EventoDeportivoModificacionUseCase>()
     .AddTransient<ListarEventosDeportivosUseCase>()

     // Casos de uso Reserva
     .AddTransient<ReservaAltaUseCase>()
     .AddTransient<ReservaBajaUseCase>()
     .AddTransient<ReservaModificacionUseCase>()
     .AddTransient<ListarReservasUseCase>()
     */

    // Validadores
    .AddScoped<ValidadorUsuario>()
    .AddScoped<ValidadorUsuarioDuplicado>()

    // Repositorios
    .AddScoped<IRepositorioUsuario, RepositorioUsuario>()
  //  .AddScoped<IRepositorioPersona, RepositorioPersona>()
    //.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>()
    //.AddScoped<IRepositorioReserva, RepositorioReserva>()

    // Servicios
    .AddScoped<IServicioAutorizacion, ServicioAutorizacion>()
    .AddScoped<ServicioUsuarioSesion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
