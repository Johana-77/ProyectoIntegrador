using System;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmLogin : Form
    {
        private const int MAX_INTENTOS = 3;
        private int intentos = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("Ingrese su usuario y contraseña.", "Iniciar sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (usuario == "")
                    txtUsuario.Focus();
                else
                    txtContrasena.Focus();
                return;
            }

            if (cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione su rol.", "Iniciar sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return;
            }

            Usuario u = Datos.BuscarUsuario(usuario);

            if (u == null || u.Contrasena != Seguridad.ObtenerHash(contrasena))
            {
                intentos++;
                if (intentos >= MAX_INTENTOS)
                {
                    MessageBox.Show("Superó el número de intentos permitidos. El sistema se cerrará.",
                        "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                MessageBox.Show("Usuario o contraseña incorrectos.\nLe quedan " + (MAX_INTENTOS - intentos) + " intento(s).",
                    "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            if (!u.Activo)
            {
                MessageBox.Show("Este usuario está desactivado. Consulte con el administrador.",
                    "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (u.Rol != cboRol.Text)
            {
                MessageBox.Show("El usuario " + u.NombreUsuario + " no tiene el rol de " + cboRol.Text + ".",
                    "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return;
            }

            intentos = 0;
            Sesion.Iniciar(u);

            FrmPrincipal principal = new FrmPrincipal();
            this.Hide();
            principal.ShowDialog();

            // si cerró sesión vuelve al login, si cerró la ventana sale del sistema
            if (principal.SesionCerrada)
            {
                Limpiar();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void lnkOlvido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para recuperar su contraseña comuníquese con el administrador del sistema.",
                "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Limpiar()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            cboRol.SelectedIndex = -1;
            intentos = 0;
            this.ActiveControl = txtUsuario;
        }
    }
}
