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
    .AddTransient<UsuarioConsultaUseCase>()
    .AddTransient<UsuarioModificacionUseCase>()
    .AddTransient<UsuarioLoginUseCase>()
    .AddTransient<UsuarioRegistroUseCase>()
    .AddTransient<ListarUsuariosUseCase>()
    .AddTransient<OtorgarPermisoAUsuarioUseCase>()
    .AddTransient<QuitarPermisoAUsuarioUseCase>()

    // Casos de uso Persona
    .AddTransient<PersonaAltaUseCase>()
    .AddTransient<PersonaBajaUseCase>()
    .AddTransient<PersonaConsultaUseCase>()
    .AddTransient<PersonaModificacionUseCase>()
    .AddTransient<ListarPersonasUseCase>()
    .AddTransient<EventoDeportivoAltaUseCase>()
    .AddTransient<EventoDeportivoBajaUseCase>()
    .AddTransient<EventoDeportivoConsultaUseCase>()
    .AddTransient<EventoDeportivoModificacionUseCase>()
    .AddTransient<ListarEventosDeportivosUseCase>()
    .AddTransient<ListarEventosConCupoDisponibleUseCase>()
    .AddTransient<ListarAsistenciaAEventoUseCase>()
    .AddTransient<ReservaAltaUseCase>()
    .AddTransient<ReservaBajaUseCase>()
    .AddTransient<ReservaConsultaUseCase>()
    .AddTransient<ReservaModificacionUseCase>()
    .AddTransient<ListarReservasUseCase>()

    // Validadores
    .AddScoped<ValidadorUsuario>()
    .AddScoped<ValidadorUsuarioDuplicado>()
    .AddScoped<ValidadorPersona>()
    .AddScoped<ValidadorPersonaDependencia>()
    .AddScoped<ValidadorPersonaDuplicado>()
    .AddScoped<ValidadorEventoDeportivo>()
    .AddScoped<ValidadorEventoDeportivoDependencia>()
    .AddScoped<ValidadorEventoDeportivoExistePersona>()
    .AddScoped<ValidadorReservaExiste>()
    .AddScoped<ValidadorReservaCupo>()
    .AddScoped<ValidadorReservaDuplicado>()

    // Repositorios
    .AddScoped<IRepositorioUsuario, RepositorioUsuario>()
    .AddScoped<IRepositorioPersona, RepositorioPersona>()
    .AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>()
    .AddScoped<IRepositorioReserva, RepositorioReserva>()

    // Servicios
    .AddScoped<IServicioAutorizacion, ServicioAutorizacion>()
    .AddScoped<IServicioUsuarioSesion, ServicioUsuarioSesion>()
    .AddScoped<IServicioHashHelper, ServicioHashHelper>();

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
