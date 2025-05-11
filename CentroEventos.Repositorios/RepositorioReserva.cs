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

        public void Actualizar(Reserva reserva)
        {
            var reservas = Listar();
            using var sw = new StreamWriter(_filePath, false);
            foreach (var r in reservas)
            {
                if (r.Id == reserva.Id)
                {
                    EscribirReserva(sw, reserva);
                }
                else
                {
                    EscribirReserva(sw, r);
                }
            }
        }

        public void Eliminar(int id)
        {
            var reservas = Listar();
            using var sw = new StreamWriter(_filePath, false);
            foreach (var reserva in reservas)
            {
                if (reserva.Id != id)
                {
                    EscribirReserva(sw, reserva);
                }
            }
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
                Id = int.Parse(sr.ReadLine()),
                PersonaId = int.Parse(sr.ReadLine()),
                EventoDeportivoId = int.Parse(sr.ReadLine()),
                FechaAltaReserva = DateTime.Parse(sr.ReadLine()),
                EstadoAsistencia = Enum.Parse<Estado>(sr.ReadLine())
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