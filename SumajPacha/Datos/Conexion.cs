using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SumajPacha.Presentacion
{
    // conexion con SQL Server
    // si en tu compu el servidor tiene otro nombre hay que cambiar SERVIDOR
    // (el nombre sale cuando te conectas en SQL Server Management Studio)
    public static class Conexion
    {
        public const string SERVIDOR = @".\SQLEXPRESS";
        public const string BASE_DE_DATOS = "SumajPachaDB";

        // Integrated Security = entra con el usuario de Windows
        // TrustServerCertificate = para que no salga error por el certificado de SQL Server Express
        public static string Cadena()
        {
            return "Server=" + SERVIDOR + ";Database=" + BASE_DE_DATOS
                + ";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=10;";
        }

        // abre la conexion, se usa con using para que se cierre sola
        public static SqlConnection Abrir()
        {
            SqlConnection cn = new SqlConnection(Cadena());
            cn.Open();
            return cn;
        }

        // mensaje de error cuando no se puede guardar
        public static void MostrarError(string accion, Exception ex)
        {
            MessageBox.Show("No se pudo " + accion + " en la base de datos.\n"
                + "Revise que SQL Server esté encendido.\n\nDetalle: " + ex.Message,
                "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
