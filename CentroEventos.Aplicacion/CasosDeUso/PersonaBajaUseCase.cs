using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace Almacen.Aplicacion.CasosDeUso;

public class PersonaBajaUseCase(IRepositorioPersona repositorio)
{
    public void Ejecutar(int id)
    {
        bool eliminada = repositorio.Eliminar(id);

        if (!eliminada)
        {
            throw new EntidadNotFoundException(id);
        }
    }
}