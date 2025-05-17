using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios
{
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly string _filePath = "reservas.txt";
        private readonly string _idFilePath = "ultimo_id_reserva.txt";

        public RepositorioReserva()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
            }

            if (!File.Exists(_idFilePath))
            {
                File.WriteAllText(_idFilePath, "0");
            }
        }

        public void Agregar(Reserva reserva)
        {
            reserva.Id = GenerarNuevoId();
            using var sw = new StreamWriter(_filePath, true);
            EscribirReserva(sw, reserva);
        }

        public bool Eliminar(int id)
        {
            var reservas = Listar();
            bool encontrado = false;

            using var sw = new StreamWriter(_filePath, false);
            foreach (var reserva in reservas)
            {
                if (reserva.Id != id)
                {
                    EscribirReserva(sw, reserva);
                }
                else
                {
                    encontrado = true;
                }
            }

            return encontrado;
        }

        public Reserva? ObtenerPorId(int id)
        {
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                var reserva = LeerReserva(sr);
                if (reserva.Id == id)
                {
                    return reserva;
                }
            }
            return null;
        }

        public List<Reserva> Listar()
        {
            var reservas = new List<Reserva>();
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                reservas.Add(LeerReserva(sr));
            }
            return reservas;
        }

        public bool Modificar(Reserva reserva)
        {
            var reservas = Listar();
            bool encontrado = false;

            using var sw = new StreamWriter(_filePath, false);
            foreach (var r in reservas)
            {
                if (r.Id == reserva.Id)
                {
                    EscribirReserva(sw, reserva);
                    encontrado = true;
                }
                else
                {
                    EscribirReserva(sw, r);
                }
            }

            return encontrado;
        }

        public int ContarReservas(int eventoDeportivoId)
        {
            var reservas = Listar();
            return reservas.Count(r => r.EventoDeportivoId == eventoDeportivoId);
        }

        public bool PersonaReserva(int idPersona)
        {
            var reservas = Listar();
            foreach (var reserva in reservas)
            {
                if (reserva.PersonaId == idPersona)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonaReservaEvento(int idPersona, int idEventoDeportivo)
        {
            var reservas = Listar();
            foreach (var reserva in reservas)
            {
                if (reserva.PersonaId == idPersona && reserva.EventoDeportivoId == idEventoDeportivo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EventoDeportivoReserva(int idEventoDeportivo)
        {
            var reservas = Listar();
            foreach (var reserva in reservas)
            {
                if (reserva.EventoDeportivoId == idEventoDeportivo)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Reserva> ListarPresenteId(int eventoDeportivoId)
        {
            var reservas = Listar();
            var resultado = new List<Reserva>();
            foreach (var reserva in reservas)
            {
                if (reserva.EventoDeportivoId == eventoDeportivoId && reserva.EstadoAsistencia == Estado.Presente)
                {
                    resultado.Add(reserva);
                }
            }
            return resultado;
        }

        private int GenerarNuevoId()
        {
            var ultimoId = int.Parse(File.ReadAllText(_idFilePath));
            var nuevoId = ultimoId + 1;
            File.WriteAllText(_idFilePath, nuevoId.ToString());
            return nuevoId;
        }

        private Reserva LeerReserva(StreamReader sr)
        {
            return new Reserva
            {
                Id = int.Parse(sr.ReadLine() ?? "0"),
                PersonaId = int.Parse(sr.ReadLine() ?? "0"),
                EventoDeportivoId = int.Parse(sr.ReadLine() ?? "0"),
                FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? DateTime.MinValue.ToString("o")),
                EstadoAsistencia = Enum.Parse<Estado>(sr.ReadLine() ?? "Pendiente")
            };
        }

        private void EscribirReserva(StreamWriter sw, Reserva reserva)
        {
            sw.WriteLine(reserva.Id);
            sw.WriteLine(reserva.PersonaId);
            sw.WriteLine(reserva.EventoDeportivoId);
            sw.WriteLine(reserva.FechaAltaReserva.ToString("o"));
            sw.WriteLine(reserva.EstadoAsistencia);
        }
    }
}