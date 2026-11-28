using System;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmAdministracion : Form
    {
        public FrmAdministracion()
        {
            InitializeComponent();
        }

        private void FrmAdministracion_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            MostrarCatalogos();
            MostrarAnulados();

            // solo el administrador puede manejar los usuarios
            if (!Sesion.EsAdministrador())
            {
                btnNuevoUsuario.Enabled = false;
                btnEditar.Enabled = false;
                btnDesactivar.Enabled = false;
            }
        }

        // --- usuarios ---

        private void MostrarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            foreach (Usuario u in Datos.Usuarios)
            {
                string estado = u.Activo ? "Activo" : "Inactivo";
                int fila = dgvUsuarios.Rows.Add(u.Nombre, u.Rol, u.Perfil, estado);
                dgvUsuarios.Rows[fila].Tag = u;
                if (!u.Activo)
                    dgvUsuarios.Rows[fila].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private Usuario UsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null)
                return null;
            return (Usuario)dgvUsuarios.CurrentRow.Tag;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            Usuario u = UsuarioSeleccionado();
            if (u != null && !u.Activo)
                btnDesactivar.Text = "Activar";
            else
                btnDesactivar.Text = "Desactivar";
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario(null);
            if (frm.ShowDialog(this) == DialogResult.OK)
                MostrarUsuarios();
            frm.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Usuario u = UsuarioSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Seleccione el usuario que quiere editar.", "Editar usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmUsuario frm = new FrmUsuario(u);
            if (frm.ShowDialog(this) == DialogResult.OK)
                MostrarUsuarios();
            frm.Dispose();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            Usuario u = UsuarioSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (u == Sesion.UsuarioActual)
            {
                MessageBox.Show("No puede desactivar su propio usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = u.Activo ? "desactivar" : "activar";
            DialogResult r = MessageBox.Show("¿Desea " + accion + " al usuario " + u.Nombre + "?", "Usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                try
                {
                    Datos.CambiarEstadoUsuario(u, !u.Activo);
                }
                catch (Exception ex)
                {
                    Conexion.MostrarError(accion + " el usuario", ex);
                    return;
                }
                MostrarUsuarios();
            }
        }

        // --- catálogos ---

        private void MostrarCatalogos()
        {
            dgvCultivos.Rows.Clear();
            foreach (Cultivo c in Datos.Cultivos)
                dgvCultivos.Rows.Add(c.Nombre, c.DiasCosecha, c.PrecioReferencia.ToString("0.00"));
            dgvCultivos.ClearSelection();

            lstInsumos.Items.Clear();
            foreach (Insumo i in Datos.Insumos)
                lstInsumos.Items.Add(i.Nombre);

            lstComunidades.Items.Clear();
            foreach (string c in Datos.Comunidades)
                lstComunidades.Items.Add(c);
        }

        private void btnAgregarCultivo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCultivo.Text.Trim().ToLower();

            if (nombre == "")
            {
                Aviso("Escriba el nombre del cultivo.", txtNombreCultivo);
                return;
            }
            if (Datos.BuscarCultivo(nombre) != null)
            {
                Aviso("El cultivo \"" + nombre + "\" ya está en el catálogo.", txtNombreCultivo);
                return;
            }
            if (numDiasCosecha.Value <= 0)
            {
                Aviso("Indique los días a cosecha.", numDiasCosecha);
                return;
            }
            if (numPrecioRef.Value <= 0)
            {
                Aviso("Indique el precio de referencia en Bs/kg.", numPrecioRef);
                return;
            }

            Cultivo c = new Cultivo();
            c.Nombre = nombre;
            c.DiasCosecha = (int)numDiasCosecha.Value;
            c.PrecioReferencia = numPrecioRef.Value;

            try
            {
                Datos.RegistrarCultivo(c);
            }
            catch (Exception ex)
            {
                Conexion.MostrarError("guardar el cultivo", ex);
                return;
            }

            MostrarCatalogos();
            MessageBox.Show("Cultivo agregado. Ya aparece como \"Plantines de " + nombre + "\" en Entregas.",
                "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombreCultivo.Clear();
            numDiasCosecha.Value = 0;
            numPrecioRef.Value = 0;
        }

        // --- registros anulados ---

        private void MostrarAnulados()
        {
            dgvAnulados.Rows.Clear();
            foreach (Entrega en in Datos.Entregas)
            {
                if (!en.Anulada)
                    continue;

                // si se anuló directo en SQL Server no se sabe quién fue
                string quien = en.AnuladaPor;
                if (quien == null)
                    quien = "—";

                dgvAnulados.Rows.Add("Entrega de " + en.Insumo.ToLower(), en.Fecha.ToString("dd/MM/yyyy"),
                    en.Parcela.Codigo, quien);
            }
            dgvAnulados.ClearSelection();
        }

        private void tabAdministracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabAdministracion.SelectedTab == tabAnulados)
                MostrarAnulados();
        }

        private void Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Administración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
