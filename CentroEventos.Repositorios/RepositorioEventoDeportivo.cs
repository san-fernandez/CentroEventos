using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios
{
    public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
    {
        private readonly string _filePath = "eventos_deportivos.txt";
        private readonly string _idFilePath = "ultimo_id_evento_deportivo.txt";

        public RepositorioEventoDeportivo()
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

        public void Agregar(EventoDeportivo evento)
        {
            evento.Id = GenerarNuevoId();
            using var sw = new StreamWriter(_filePath, true);
            EscribirEvento(sw, evento);
        }

        public EventoDeportivo? ObtenerPorId(int id)
        {
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                var evento = LeerEvento(sr);
                if (evento.Id == id)
                {
                    return evento;
                }
            }
            return null;
        }

        public List<EventoDeportivo> Listar()
        {
            var eventos = new List<EventoDeportivo>();
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                eventos.Add(LeerEvento(sr));
            }
            return eventos;
        }

        public void Actualizar(EventoDeportivo evento)
        {
            var eventos = Listar();
            using var sw = new StreamWriter(_filePath, false);
            foreach (var e in eventos)
            {
                if (e.Id == evento.Id)
                {
                    EscribirEvento(sw, evento);
                }
                else
                {
                    EscribirEvento(sw, e);
                }
            }
        }

        public void Eliminar(int id)
        {
            var eventos = Listar();
            using var sw = new StreamWriter(_filePath, false);
            foreach (var evento in eventos)
            {
                if (evento.Id != id)
                {
                    EscribirEvento(sw, evento);
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

        private EventoDeportivo LeerEvento(StreamReader sr)
        {
            return new EventoDeportivo
            {
                Id = int.Parse(sr.ReadLine()),
                Nombre = sr.ReadLine(),
                Descripcion = sr.ReadLine(),
                FechaHoraInicio = DateTime.Parse(sr.ReadLine()),
                DuracionHoras = double.Parse(sr.ReadLine()),
                CupoMaximo = int.Parse(sr.ReadLine()),
                ResponsableId = int.Parse(sr.ReadLine())
            };
        }

        private void EscribirEvento(StreamWriter sw, EventoDeportivo evento)
        {
            sw.WriteLine(evento.Id);
            sw.WriteLine(evento.Nombre);
            sw.WriteLine(evento.Descripcion);
            sw.WriteLine(evento.FechaHoraInicio.ToString("o")); // Formato ISO 8601 para la fecha
            sw.WriteLine(evento.DuracionHoras);
            sw.WriteLine(evento.CupoMaximo);
            sw.WriteLine(evento.ResponsableId);
        }
    }
}