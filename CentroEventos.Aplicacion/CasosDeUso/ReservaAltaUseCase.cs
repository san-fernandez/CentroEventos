using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase (IRepositorioReserva repositorioReserva, IRepositorioEventoDeportivo repositorioEvento, IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Reserva reserva) {
        if (!servicioAutorizacion.PoseeElPermiso(reserva.PersonaId, Permiso.ReservaAlta)) {
            throw new FalloAutorizacionException();
        }
        if (repositorioPersona.)  // verificar si persona existe (capaz implementar existe con id)
    }