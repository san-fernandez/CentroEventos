using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Utilidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;
using CentroEventos.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IServicioUsuarioSesion, ServicioUsuarioSesion>();

// Inyección de dependencias de repositorios
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddTransient<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddTransient<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();

// Inyección de dependencias de servicios y validadores
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ValidadorUsuario>();

// Casos de uso
builder.Services.AddTransient<UsuarioAltaUseCase>();

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
