using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly string _filePath = "personas.txt";
        private readonly string _idFilePath = "ultimo_id_persona.txt";

        public RepositorioPersona()
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

        public void Agregar(Persona persona) 
        {
            persona.Id = GenerarNuevoId();
            using var sw = new StreamWriter(_filePath, true);
            EscribirPersona(sw, persona);
        }

        public bool Eliminar(int id)
        {
            var personas = Listar();
            using var sw = new StreamWriter(_filePath, false);
            bool eliminado = false;
            foreach (var persona in personas)
            {
                if (persona.Id != id)
                {
                    EscribirPersona(sw, persona);
                }
                else {
                    eliminado = true;
                }
            }
            return eliminado;
        }


        public Persona? ObtenerPorId(int id)
        {
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                var persona = LeerPersona(sr);
                if (persona.Id == id)
                {
                    return persona;
                }
            }
            return null;
        }

        public List<Persona> Listar()
        {
            var personas = new List<Persona>();
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                personas.Add(LeerPersona(sr));
            }
            return personas;
        }

        public bool Modificar(Persona persona)
        {
            var personas = Listar();
            bool encontrado = false;

            using var sw = new StreamWriter(_filePath, false);
            foreach (var p in personas) {
                if (p.Id == persona.Id) {
                    EscribirPersona(sw, persona);
                    encontrado = true;
                }
            else {
                EscribirPersona(sw, p);
            }
        }

        return encontrado;
        }
        
        public bool ExisteConDNI(int dni)
        {
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                var persona = LeerPersona(sr);
                if (persona.DNI == dni)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteConEmail(string email)
        {
            using var sr = new StreamReader(_filePath);
            while (!sr.EndOfStream)
            {
                var persona = LeerPersona(sr);
                if (persona.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private int GenerarNuevoId()
        {
            var ultimoId = int.Parse(File.ReadAllText(_idFilePath));
            var nuevoId = ultimoId + 1;
            File.WriteAllText(_idFilePath, nuevoId.ToString());
            return nuevoId;
        }

        private Persona LeerPersona(StreamReader sr)
        {
            return new Persona
            {
                Id = int.Parse(sr.ReadLine() ?? "0"),
                Nombre = sr.ReadLine() ?? "",
                Apellido = sr.ReadLine() ?? "",
                Email = sr.ReadLine() ?? "",
                Telefono = sr.ReadLine() ?? ""
            };
        }

        private void EscribirPersona(StreamWriter sw, Persona persona)
        {
            sw.WriteLine(persona.Id);
            sw.WriteLine(persona.Nombre);
            sw.WriteLine(persona.Apellido);
            sw.WriteLine(persona.Email);
            sw.WriteLine(persona.Telefono);
        }
    }
}