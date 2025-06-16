using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Utilidades;

public static class HashHelper
{
    public static string CalcularSha256(string texto)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);

            byte[] hashBytes = sha256.ComputeHash(bytesTexto);

            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
