using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioHashHelper
{
    string CalcularSha256(string texto);
}