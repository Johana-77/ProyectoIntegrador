using System;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // carga los datos de la base, si no se puede conectar muestra el error y no abre el sistema
            try
            {
                Datos.Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos " + Conexion.BASE_DE_DATOS
                    + " en el servidor " + Conexion.SERVIDOR + ".\n\n"
                    + "Revise que:\n"
                    + "1. SQL Server Express esté instalado y encendido.\n"
                    + "2. Ejecutó los scripts de la carpeta database (01 y 02).\n"
                    + "3. El nombre del servidor en Datos\\Conexion.cs sea el correcto.\n\n"
                    + "Detalle: " + ex.Message,
                    "Huertos Sumaj Pacha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
