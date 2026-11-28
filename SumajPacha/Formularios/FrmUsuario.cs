using System;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    // sirve para crear un usuario nuevo o editar uno que ya existe
    public partial class FrmUsuario : Form
    {
        private Usuario usuario; // null cuando es nuevo

        public FrmUsuario(Usuario usuarioAEditar)
        {
            InitializeComponent();
            usuario = usuarioAEditar;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            if (usuario == null)
            {
                this.Text = "Nuevo usuario";
                lblTitulo.Text = "Nuevo usuario";
                lblNota.Visible = false;
            }
            else
            {
                this.Text = "Editar usuario";
                lblTitulo.Text = "Editar usuario";
                txtNombre.Text = usuario.Nombre;
                txtUsuario.Text = usuario.NombreUsuario;
                cboRol.SelectedItem = usuario.Rol;
                txtPerfil.Text = usuario.Perfil;
                lblNota.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string nombreUsuario = txtUsuario.Text.Trim().ToLower();
            string contrasena = txtContrasena.Text;

            if (nombre == "")
            {
                Aviso("Escriba el nombre completo.", txtNombre);
                return;
            }
            if (nombreUsuario == "")
            {
                Aviso("Escriba el nombre de usuario.", txtUsuario);
                return;
            }
            if (nombreUsuario.Contains(" "))
            {
                Aviso("El nombre de usuario no debe tener espacios.", txtUsuario);
                return;
            }

            Usuario existente = Datos.BuscarUsuario(nombreUsuario);
            if (existente != null && existente != usuario)
            {
                Aviso("Ya existe un usuario con el nombre \"" + nombreUsuario + "\".", txtUsuario);
                return;
            }

            // al crear la contraseña es obligatoria, al editar es opcional
            if (usuario == null && contrasena == "")
            {
                Aviso("Escriba una contraseña.", txtContrasena);
                return;
            }
            if (contrasena != "" && contrasena.Length < 4)
            {
                Aviso("La contraseña debe tener al menos 4 caracteres.", txtContrasena);
                return;
            }
            if (cboRol.SelectedIndex == -1)
            {
                Aviso("Seleccione el rol.", cboRol);
                return;
            }

            try
            {
                if (usuario == null)
                {
                    Usuario nuevo = new Usuario();
                    nuevo.Nombre = nombre;
                    nuevo.NombreUsuario = nombreUsuario;
                    nuevo.Contrasena = Seguridad.ObtenerHash(contrasena);
                    nuevo.Rol = cboRol.Text;
                    nuevo.Perfil = txtPerfil.Text.Trim();
                    nuevo.Activo = true;
                    Datos.RegistrarUsuario(nuevo);
                }
                else
                {
                    // si no escribió contraseña nueva, se queda la anterior
                    string hash = usuario.Contrasena;
                    if (contrasena != "")
                        hash = Seguridad.ObtenerHash(contrasena);
                    Datos.ActualizarUsuario(usuario, nombre, nombreUsuario, hash, cboRol.Text, txtPerfil.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Conexion.MostrarError("guardar el usuario", ex);
                return;
            }

            MessageBox.Show("Usuario guardado correctamente.", this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
