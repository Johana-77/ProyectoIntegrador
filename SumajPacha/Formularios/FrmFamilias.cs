using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmFamilias : Form
    {
        public FrmFamilias()
        {
            InitializeComponent();
        }

        private void FrmFamilias_Load(object sender, EventArgs e)
        {
            MostrarFamilias(Datos.Familias);

            foreach (Familia f in Datos.Familias)
            {
                if (f.Activa)
                    cboFamilia.Items.Add(f);
            }

            // los proyectos salen de la tabla PROYECTO
            cboProyecto.Items.Clear();
            foreach (string proyecto in Datos.Proyectos)
                cboProyecto.Items.Add(proyecto);

            // no se puede registrar una instalación en el futuro
            dtpInstalacion.Value = DateTime.Today;
            dtpInstalacion.MaxDate = DateTime.Today;
            LimpiarFormulario();
        }

        private void MostrarFamilias(List<Familia> lista)
        {
            dgvFamilias.Rows.Clear();
            foreach (Familia f in lista)
            {
                dgvFamilias.Rows.Add(f.Codigo, f.Nombres, f.Apellidos, f.Comunidad, f.Sexo, f.Edad, f.Miembros);
            }
            dgvFamilias.ClearSelection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (texto == "")
            {
                MostrarFamilias(Datos.Familias);
                return;
            }

            List<Familia> encontradas = new List<Familia>();
            foreach (Familia f in Datos.Familias)
            {
                if (f.Codigo.ToLower().Contains(texto)
                    || f.Nombres.ToLower().Contains(texto)
                    || f.Apellidos.ToLower().Contains(texto)
                    || f.Comunidad.ToLower().Contains(texto))
                {
                    encontradas.Add(f);
                }
            }

            MostrarFamilias(encontradas);

            if (encontradas.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna familia con \"" + txtBuscar.Text.Trim() + "\".",
                    "Buscar familia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // buscar también con la tecla Enter
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        // doble clic en una familia la elige para la nueva parcela
        private void dgvFamilias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string codigo = dgvFamilias.Rows[e.RowIndex].Cells[colFamiliasCodigo.Index].Value.ToString();
            foreach (Familia f in cboFamilia.Items)
            {
                if (f.Codigo == codigo)
                {
                    cboFamilia.SelectedItem = f;
                    break;
                }
            }

            int cantidad = Datos.ParcelasDeFamilia(Datos.BuscarFamilia(codigo)).Count;
            if (cantidad > 0)
            {
                MessageBox.Show("Esta familia ya tiene " + cantidad + " parcela(s) registrada(s).\nPuede agregar otra si es necesario.",
                    "Nueva parcela", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cboTipo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboFamilia.SelectedIndex == -1)
            {
                Aviso("Seleccione la familia.", cboFamilia);
                return;
            }
            if (cboProyecto.SelectedIndex == -1)
            {
                Aviso("Seleccione el proyecto.", cboProyecto);
                return;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                Aviso("Seleccione el tipo de parcela.", cboTipo);
                return;
            }
            if (numSuperficie.Value <= 0)
            {
                Aviso("La superficie debe ser mayor a 0 m².", numSuperficie);
                return;
            }
            if (cboRiego.SelectedIndex == -1)
            {
                Aviso("Indique si la parcela tiene riego.", cboRiego);
                return;
            }

            Parcela p = new Parcela();
            p.Familia = (Familia)cboFamilia.SelectedItem;
            p.Proyecto = cboProyecto.Text;
            p.Tipo = cboTipo.Text;
            p.Superficie = numSuperficie.Value;
            p.TieneRiego = cboRiego.Text == "Sí";
            p.FechaInstalacion = dtpInstalacion.Value.Date;
            p.Estado = "Sin visita";

            // el código (P-13, P-14...) lo da la base de datos al guardar
            try
            {
                Datos.RegistrarParcela(p);
            }
            catch (Exception ex)
            {
                Conexion.MostrarError("guardar la parcela", ex);
                return;
            }

            MessageBox.Show("Parcela " + p.Codigo + " registrada para la familia " + p.Familia.Apellidos + ".\n"
                + "Ya puede registrar la entrega de insumos para esta parcela.",
                "Nueva parcela", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cboFamilia.SelectedIndex = -1;
            if (cboProyecto.Items.Count > 0)
                cboProyecto.SelectedIndex = 0;
            cboTipo.SelectedIndex = -1;
            numSuperficie.Value = 150;
            cboRiego.SelectedIndex = -1;
            dtpInstalacion.Value = DateTime.Today;
        }

        private void Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Nueva parcela", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
