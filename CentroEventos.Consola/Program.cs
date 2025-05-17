using System;
using Almacen.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Repositorios;

class Program
{
    static PersonaAltaUseCase? agregarPersona;
    static PersonaBajaUseCase? eliminarPersona;
    static PersonaModificacionUseCase? modificarPersona;
    static ListarPersonasUseCase? listarPersonas;
    static EventoDeportivoAltaUseCase? agregarEvento;
    static EventoDeportivoBajaUseCase? eliminarEvento;
    static EventoDeportivoModificacionUseCase? modificarEvento;
    static ListarEventosDeportivosUseCase? listarEventos;
    static ListarAsistenciaAEventoUseCase? listarAsistentes;
    static ListarEventosConCupoDisponibleUseCase? listarEventosConCupo;

    static ReservaAltaUseCase? agregarReserva;
    static ReservaBajaUseCase? eliminarReserva;
    static ReservaModificacionUseCase? modificarReserva;
    static ListarReservasUseCase? listarReservas;

    public static void Main()
    {
        var repoPersona = new RepositorioPersona();
        var repoEvento = new RepositorioEventoDeportivo();
        var repoReserva = new RepositorioReserva();

        var servicioAutorizacion = new ServicioAutorizacionProvisorio();

        agregarPersona = new PersonaAltaUseCase(repoPersona, servicioAutorizacion);
        eliminarPersona = new PersonaBajaUseCase(repoPersona, repoEvento, repoReserva, servicioAutorizacion);
        modificarPersona = new PersonaModificacionUseCase(repoPersona, servicioAutorizacion);
        listarPersonas = new ListarPersonasUseCase(repoPersona);

        agregarEvento = new EventoDeportivoAltaUseCase(repoEvento, repoPersona, servicioAutorizacion);
        eliminarEvento = new EventoDeportivoBajaUseCase(repoEvento, repoReserva, servicioAutorizacion);
        modificarEvento = new EventoDeportivoModificacionUseCase(repoEvento, servicioAutorizacion);
        listarEventos = new ListarEventosDeportivosUseCase(repoEvento);
        listarAsistentes = new ListarAsistenciaAEventoUseCase(repoEvento, repoReserva, repoPersona);
        listarEventosConCupo = new ListarEventosConCupoDisponibleUseCase(repoEvento, repoReserva);

        agregarReserva = new ReservaAltaUseCase(repoReserva, repoEvento, repoPersona, servicioAutorizacion);
        eliminarReserva = new ReservaBajaUseCase(repoReserva, servicioAutorizacion);
        modificarReserva = new ReservaModificacionUseCase(repoReserva, repoPersona, repoEvento, servicioAutorizacion);
        listarReservas = new ListarReservasUseCase(repoReserva);

        while (true)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Personas");
            Console.WriteLine("2. Eventos Deportivos");
            Console.WriteLine("3. Reservas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    MenuPersonas();
                    break;
                case "2":
                    MenuEventos();
                    break;
                case "3":
                    MenuReservas();
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void MenuPersonas()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENÚ PERSONAS ---");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Baja");
            Console.WriteLine("3. Modificación");
            Console.WriteLine("4. Listado");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    try
                    {
                        var persona = LeerPersona();
                        if (agregarPersona != null)
                        {
                            agregarPersona.Ejecutar(persona, 1);
                            Console.WriteLine("Persona cargada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al dar de alta: {ex.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.Write("Ingrese ID de persona a eliminar: ");
                        int idBaja = int.Parse(Console.ReadLine() ?? "0");
                        if (eliminarPersona != null)
                        {
                            eliminarPersona.Ejecutar(idBaja, 1);
                            Console.WriteLine("Persona eliminada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar: {ex.Message}");
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Ingrese ID de persona a modificar: ");
                        int idMod = int.Parse(Console.ReadLine() ?? "0");
                        var personaMod = LeerPersona();
                        personaMod.Id = idMod;
                        if (modificarPersona != null)
                        {
                            modificarPersona.Ejecutar(personaMod, 1);
                            Console.WriteLine("Persona modificada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al modificar: {ex.Message}");
                    }
                    break;
                case "4":
                    try
                    {
                        if (listarPersonas != null)
                        {
                            var personas = listarPersonas.Ejecutar();
                            Console.WriteLine("\n--- Listado de Personas ---");
                            foreach (var p in personas)
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al listar: {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void MenuEventos()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENÚ EVENTOS DEPORTIVOS ---");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Baja");
            Console.WriteLine("3. Modificación");
            Console.WriteLine("4. Listado");
            Console.WriteLine("5. Listar eventos con cupo disponible");
            Console.WriteLine("6. Listar asistentes a un evento");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    try
                    {
                        var evento = LeerEventoDeportivo();
                        if (agregarEvento != null)
                        {
                            agregarEvento.Ejecutar(evento, 1);
                            Console.WriteLine("Evento cargado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al dar de alta: {ex.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.Write("Ingrese ID de evento a eliminar: ");
                        int idBaja = int.Parse(Console.ReadLine() ?? "0");
                        if (eliminarEvento != null)
                        {
                            eliminarEvento.Ejecutar(idBaja, 1);
                            Console.WriteLine("Evento eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar: {ex.Message}");
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Ingrese ID de evento a modificar: ");
                        int idMod = int.Parse(Console.ReadLine() ?? "0");
                        var eventoMod = LeerEventoDeportivo();
                        eventoMod.Id = idMod;
                        if (modificarEvento != null)
                        {
                            modificarEvento.Ejecutar(eventoMod, 1);
                            Console.WriteLine("Evento modificado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al modificar: {ex.Message}");
                    }
                    break;
                case "4":
                    try
                    {
                        if (listarEventos != null)
                        {
                            var eventos = listarEventos.Ejecutar();
                            Console.WriteLine("\n--- Listado de Eventos Deportivos ---");
                            foreach (var e in eventos)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al listar: {ex.Message}");
                    }
                    break;
                case "5":
                    try
                    {
                        if (listarEventosConCupo != null)
                        {
                            var eventos = listarEventosConCupo.Ejecutar();
                            Console.WriteLine("\n--- Eventos con Cupo Disponible ---");
                            foreach (var e in eventos)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al listar eventos con cupo: {ex.Message}");
                    }
                    break;
                case "6":
                    try
                    {
                        Console.Write("Ingrese ID de evento para ver asistentes: ");
                        int idEvento = int.Parse(Console.ReadLine() ?? "0");
                        if (listarAsistentes != null)
                        {
                            var asistentes = listarAsistentes.Ejecutar(idEvento);
                            Console.WriteLine("\n--- Asistentes al Evento ---");
                            foreach (var persona in asistentes)
                            {
                                Console.WriteLine(persona);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al listar asistentes: {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void MenuReservas()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENÚ RESERVAS ---");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Baja");
            Console.WriteLine("3. Modificación");
            Console.WriteLine("4. Listado");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    try
                    {
                        var reserva = LeerReserva();
                        if (agregarReserva != null)
                        {
                            agregarReserva.Ejecutar(reserva, 1);
                            Console.WriteLine("Reserva cargada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al dar de alta: {ex.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        Console.Write("Ingrese ID de reserva a eliminar: ");
                        int idBaja = int.Parse(Console.ReadLine() ?? "0");
                        if (eliminarReserva != null)
                        {
                            eliminarReserva.Ejecutar(idBaja, 1);
                            Console.WriteLine("Reserva eliminada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar: {ex.Message}");
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Ingrese ID de reserva a modificar: ");
                        int idMod = int.Parse(Console.ReadLine() ?? "0");
                        var reservaMod = LeerReserva();
                        reservaMod.Id = idMod;
                        if (modificarReserva != null)
                        {
                            modificarReserva.Ejecutar(reservaMod, 1);
                            Console.WriteLine("Reserva modificada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al modificar: {ex.Message}");
                    }
                    break;
                case "4":
                    try
                    {
                        if (listarReservas != null)
                        {
                            var reservas = listarReservas.Ejecutar();
                            Console.WriteLine("\n--- Listado de Reservas ---");
                            foreach (var r in reservas)
                            {
                                Console.WriteLine(r);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caso de uso no disponible.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al listar: {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static Persona LeerPersona()
    {
        Console.Write("DNI: ");
        string dni = Console.ReadLine() ?? "";
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine() ?? "";

        return new Persona
        {
            DNI = dni,
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            Telefono = telefono
        };
    }

    static EventoDeportivo LeerEventoDeportivo()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine() ?? "";
        Console.Write("Fecha y hora de inicio (yyyy-MM-dd HH:mm): ");
        DateTime fechaHoraInicio = DateTime.Parse(Console.ReadLine() ?? "");
        Console.Write("Duración en horas: ");
        double duracionHoras = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Cupo máximo: ");
        int cupoMaximo = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("ID Responsable: ");
        int responsableId = int.Parse(Console.ReadLine() ?? "0");

        return new EventoDeportivo
        {
            Nombre = nombre,
            Descripcion = descripcion,
            FechaHoraInicio = fechaHoraInicio,
            DuracionHoras = duracionHoras,
            CupoMaximo = cupoMaximo,
            ResponsableId = responsableId
        };
    }

    static Reserva LeerReserva()
    {
        Console.Write("ID Persona: ");
        int personaId = int.Parse(Console.ReadLine() ?? "");
        Console.Write("ID Evento Deportivo: ");
        int eventoDeportivoId = int.Parse(Console.ReadLine() ?? "");

        return new Reserva
        {
            PersonaId = personaId,
            EventoDeportivoId = eventoDeportivoId
        };
    }
}

