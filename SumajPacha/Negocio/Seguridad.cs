using System.Security.Cryptography;
using System.Text;

namespace SumajPacha.Presentacion
{
    public static class Seguridad
    {
        // convierte la contraseña a SHA-256 para no guardarla como texto
        public static string ObtenerHash(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
