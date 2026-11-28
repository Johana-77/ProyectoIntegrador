using System;
using System.Drawing;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmEntregas : Form
    {
        public FrmEntregas()
        {
            InitializeComponent();
        }

        private void FrmEntregas_Load(object sender, EventArgs e)
        {
            foreach (Parcela p in Datos.Parcelas)
                cboParcela.Items.Add(p);

            // un insumo de plantines por cada cultivo del catálogo
            foreach (Cultivo c in Datos.Cultivos)
                cboInsumo.Items.Add("Plantines de " + c.Nombre);

            // y los insumos que no son plantines (abono, bioinsumos) de la tabla INSUMO
            foreach (Insumo i in Datos.Insumos)
            {
                if (i.Cultivo == null)
                    cboInsumo.Items.Add(i.Nombre);
            }

            txtTecnico.Text = Sesion.UsuarioActual.Nombre;

            dtpFecha.Value = DateTime.Today;
            dtpFecha.MaxDate = DateTime.Today;

            MostrarEntregas();
        }

        private void MostrarEntregas()
        {
            dgvEntregas.Rows.Clear();

            // las más recientes arriba
            for (int i = Datos.Entregas.Count - 1; i >= 0; i--)
            {
                Entrega en = Datos.Entregas[i];
                string cantidad = en.Cantidad.ToString("0.##") + " " + en.Unidad;
                string accion = "Anular";
                if (en.Anulada)
                    accion = "—";

                int fila = dgvEntregas.Rows.Add(en.Fecha.ToString("dd/MM/yyyy"), en.Parcela.ToString(),
                    en.Insumo, cantidad, en.Tecnico, en.Estado, accion);
                dgvEntregas.Rows[fila].Tag = en;

                if (en.Anulada)
                    dgvEntregas.Rows[fila].DefaultCellStyle.ForeColor = Color.Gray;
            }
            dgvEntregas.ClearSelection();
        }

        // la unidad se elige sola según el insumo
        private void cboInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInsumo.SelectedIndex == -1)
                return;

            if (cboInsumo.Text.StartsWith("Plantines"))
            {
                cboUnidad.SelectedItem = "plantines";
                numCantidad.DecimalPlaces = 0;
            }
            else
            {
                cboUnidad.SelectedItem = "kg";
                numCantidad.DecimalPlaces = 1;
            }
        }

        private void btnRegistrarEntrega_Click(object sender, EventArgs e)
        {
            if (cboParcela.SelectedIndex == -1)
            {
                Aviso("Seleccione la parcela.", cboParcela);
                return;
            }
            if (cboInsumo.SelectedIndex == -1)
            {
                Aviso("Seleccione el insumo.", cboInsumo);
                return;
            }
            if (numCantidad.Value <= 0)
            {
                Aviso("La cantidad debe ser mayor a 0.", numCantidad);
                return;
            }
            if (cboUnidad.SelectedIndex == -1)
            {
                Aviso("Seleccione la unidad.", cboUnidad);
                return;
            }

            string insumo = cboInsumo.Text;
            bool sonPlantines = insumo.StartsWith("Plantines de ");

            if (sonPlantines && cboUnidad.Text != "plantines")
            {
                Aviso("Los plantines se registran por unidad (plantines).", cboUnidad);
                return;
            }
            if (!sonPlantines && cboUnidad.Text == "plantines")
            {
                Aviso("El abono se registra en kg.", cboUnidad);
                return;
            }

            Parcela parcela = (Parcela)cboParcela.SelectedItem;
            if (dtpFecha.Value.Date < parcela.FechaInstalacion)
            {
                Aviso("La fecha no puede ser anterior a la instalación de la parcela ("
                    + parcela.FechaInstalacion.ToString("dd/MM/yyyy") + ").", dtpFecha);
                return;
            }

            Entrega entrega = new Entrega();
            entrega.Fecha = dtpFecha.Value.Date;
            entrega.Parcela = parcela;
            entrega.Insumo = insumo;
            if (sonPlantines)
                entrega.Cultivo = insumo.Substring("Plantines de ".Length);
            entrega.Cantidad = numCantidad.Value;
            entrega.Unidad = cboUnidad.Text;
            entrega.Tecnico = Sesion.UsuarioActual.Nombre;

            try
            {
                Datos.RegistrarEntrega(entrega);
            }
            catch (Exception ex)
            {
                Conexion.MostrarError("guardar la entrega", ex);
                return;
            }

            MostrarEntregas();
            MessageBox.Show("Entrega registrada: " + entrega.Cantidad.ToString("0.##") + " " + entrega.Unidad
                + " de " + insumo.ToLower() + " para la parcela " + parcela.Codigo + ".",
                "Entregas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void dgvEntregas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colEntregasAnular.Index)
                return;

            Entrega entrega = (Entrega)dgvEntregas.Rows[e.RowIndex].Tag;

            if (entrega.Anulada)
            {
                string quien = "";
                if (entrega.AnuladaPor != null)
                    quien = " por " + entrega.AnuladaPor;
                MessageBox.Show("Esta entrega ya fue anulada" + quien + ".",
                    "Anular entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // solo el administrador puede anular
            if (!Sesion.EsAdministrador())
            {
                MessageBox.Show("Solo el administrador puede anular una entrega.", "Anular entrega",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show("¿Anular la entrega de " + entrega.Insumo.ToLower()
                + " a la parcela " + entrega.Parcela.Codigo + " del " + entrega.Fecha.ToString("dd/MM/yyyy") + "?\n\n"
                + "La entrega no se borra, queda guardada como anulada.",
                "Anular entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                try
                {
                    Datos.AnularEntrega(entrega, Sesion.UsuarioActual);
                }
                catch (Exception ex)
                {
                    Conexion.MostrarError("anular la entrega", ex);
                    return;
                }
                MostrarEntregas();
            }
        }

        private void LimpiarFormulario()
        {
            cboParcela.SelectedIndex = -1;
            cboInsumo.SelectedIndex = -1;
            cboUnidad.SelectedIndex = -1;
            numCantidad.DecimalPlaces = 0;
            numCantidad.Value = 0;
            dtpFecha.Value = DateTime.Today;
        }

        private void Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Entregas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
