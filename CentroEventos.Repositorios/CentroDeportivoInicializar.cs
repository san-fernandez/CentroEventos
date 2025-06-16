using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroDeportivoInicializar
{
    public void InicializarBaseDeDatos()
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Database.EnsureCreated();

            var connection = context.Database.GetDbConnection();
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }
}
