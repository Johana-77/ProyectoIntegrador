using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmVisitas : Form
    {
        private string parcelaInicial = null;

        private readonly Color colorTexto = Color.FromArgb(57, 57, 57);
        private readonly Color colorBien = Color.FromArgb(70, 112, 45);
        private readonly Color colorMedio = Color.FromArgb(196, 120, 0);
        private readonly Color colorAlto = Color.FromArgb(215, 63, 43);

        public FrmVisitas()
        {
            InitializeComponent();
        }

        // se usa cuando se abre desde el panel principal con una parcela elegida
        public FrmVisitas(string codigoParcela) : this()
        {
            parcelaInicial = codigoParcela;
        }

        private void FrmVisitas_Load(object sender, EventArgs e)
        {
            foreach (Parcela p in Datos.Parcelas)
                cboParcela.Items.Add(p);

            dtpFecha.Value = DateTime.Today;
            dtpFecha.MaxDate = DateTime.Today;
            txtObservacion.MaxLength = 255; // en la tabla VISITA es VARCHAR(255)
            lblRegla.Visible = false;
            btnGuardarVisita.Enabled = false;

            if (parcelaInicial != null)
            {
                foreach (Parcela p in cboParcela.Items)
                {
                    if (p.Codigo == parcelaInicial)
                    {
                        cboParcela.SelectedItem = p;
                        break;
                    }
                }
            }
        }

        // al elegir la parcela se cargan los cultivos que recibió
        private void cboParcela_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSeguimiento.Rows.Clear();
            lblRegla.Visible = false;
            lblEstado.ForeColor = colorTexto;

            if (cboParcela.SelectedIndex == -1)
            {
                lblEstado.Text = "Supervivencia de la parcela: se calcula al guardar la visita";
                btnGuardarVisita.Enabled = false;
                return;
            }

            Parcela parcela = (Parcela)cboParcela.SelectedItem;

            foreach (string cultivo in Datos.CultivosEntregados(parcela))
            {
                dgvSeguimiento.Rows.Add(cultivo, Datos.PlantinesEntregados(parcela, cultivo), "", "0");
            }

            if (dgvSeguimiento.Rows.Count == 0)
            {
                lblEstado.Text = "Esta parcela todavía no recibió plantines. Primero registre una entrega.";
                lblEstado.ForeColor = colorMedio;
                btnGuardarVisita.Enabled = false;
                return;
            }

            Visita ultima = Datos.UltimaVisita(parcela);
            if (ultima == null)
            {
                lblEstado.Text = "Primera visita de la parcela " + parcela.Codigo + ". Registre las plantas vivas de cada cultivo.";
            }
            else
            {
                lblEstado.Text = "Última visita: " + ultima.Fecha.ToString("dd/MM/yyyy") + " · supervivencia "
                    + ultima.Supervivencia().ToString("0.0") + " % · estado " + ultima.EstadoParcela.ToLower();
            }
            btnGuardarVisita.Enabled = true;
        }

        private void dgvSeguimiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            RevisarFila(e.RowIndex, false);
            MostrarReglaSiHaceFalta();

            // si ya están todas las plantas vivas se muestra cómo va quedando
            int entregados = 0;
            int vivas = 0;
            foreach (DataGridViewRow fila in dgvSeguimiento.Rows)
            {
                int v;
                if (!int.TryParse(Convert.ToString(fila.Cells[colSeguimientoVivas.Index].Value), out v))
                    return;
                if (fila.Cells[colSeguimientoVivas.Index].ErrorText != "")
                    return;
                vivas += v;
                entregados += Convert.ToInt32(fila.Cells[colSeguimientoEntregados.Index].Value);
            }

            double s = Calculos.Supervivencia(vivas, entregados);
            lblEstado.Text = "Supervivencia calculada: " + s.ToString("0.0") + " % (se guarda al presionar Guardar visita)";
            lblEstado.ForeColor = ColorSegunNivel(s);
        }

        // revisa una fila, si exigirTodo es true tambien marca las celdas vacias
        private bool RevisarFila(int indice, bool exigirTodo)
        {
            DataGridViewRow fila = dgvSeguimiento.Rows[indice];
            DataGridViewCell celdaVivas = fila.Cells[colSeguimientoVivas.Index];
            DataGridViewCell celdaKg = fila.Cells[colSeguimientoKg.Index];
            int entregados = Convert.ToInt32(fila.Cells[colSeguimientoEntregados.Index].Value);
            bool correcto = true;

            celdaVivas.ErrorText = "";
            celdaKg.ErrorText = "";

            string textoVivas = Convert.ToString(celdaVivas.Value).Trim();
            int vivas;
            if (textoVivas == "")
            {
                if (exigirTodo)
                {
                    celdaVivas.ErrorText = "Falta registrar las plantas vivas";
                    correcto = false;
                }
            }
            else if (!int.TryParse(textoVivas, out vivas) || vivas < 0)
            {
                celdaVivas.ErrorText = "Debe ser un número entero, 0 o mayor";
                correcto = false;
            }
            else if (vivas > entregados)
            {
                celdaVivas.ErrorText = "No puede ser mayor a " + entregados + " (plantines entregados)";
                correcto = false;
            }

            string textoKg = Convert.ToString(celdaKg.Value).Trim();
            decimal kg;
            if (textoKg == "")
            {
                if (exigirTodo)
                {
                    celdaKg.ErrorText = "Escriba 0 si todavía no hay cosecha";
                    correcto = false;
                }
            }
            else if (!LeerDecimal(textoKg, out kg) || kg < 0)
            {
                celdaKg.ErrorText = "Debe ser un número, 0 o mayor";
                correcto = false;
            }

            return correcto;
        }

        private void MostrarReglaSiHaceFalta()
        {
            bool hayError = false;
            foreach (DataGridViewRow fila in dgvSeguimiento.Rows)
            {
                if (fila.Cells[colSeguimientoVivas.Index].ErrorText.StartsWith("No puede ser mayor"))
                    hayError = true;
            }
            lblRegla.Visible = hayError;
        }

        // acepta 12,5 o 12.5
        private bool LeerDecimal(string texto, out decimal valor)
        {
            string separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            texto = texto.Replace(".", separador).Replace(",", separador);
            return decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out valor);
        }

        private Color ColorSegunNivel(double supervivencia)
        {
            string nivel = Calculos.NivelAlerta(supervivencia);
            if (nivel == "ALTO")
                return colorAlto;
            if (nivel == "MEDIO")
                return colorMedio;
            return colorBien;
        }

        private void btnGuardarVisita_Click(object sender, EventArgs e)
        {
            dgvSeguimiento.EndEdit();

            if (cboParcela.SelectedIndex == -1)
            {
                Aviso("Seleccione la parcela.", cboParcela);
                return;
            }
            if (cboEstadoParcela.SelectedIndex == -1)
            {
                Aviso("Seleccione el estado de la parcela.", cboEstadoParcela);
                return;
            }

            bool todoCorrecto = true;
            for (int i = 0; i < dgvSeguimiento.Rows.Count; i++)
            {
                if (!RevisarFila(i, true))
                    todoCorrecto = false;
            }
            MostrarReglaSiHaceFalta();

            if (!todoCorrecto)
            {
                Aviso("Revise la tabla de seguimiento: hay datos vacíos o incorrectos (marcados con el ícono rojo).", dgvSeguimiento);
                return;
            }

            Parcela parcela = (Parcela)cboParcela.SelectedItem;
            if (dtpFecha.Value.Date < parcela.FechaInstalacion)
            {
                Aviso("La fecha de la visita no puede ser anterior a la instalación de la parcela ("
                    + parcela.FechaInstalacion.ToString("dd/MM/yyyy") + ").", dtpFecha);
                return;
            }

            Visita visita = new Visita();
            visita.Parcela = parcela;
            visita.Fecha = dtpFecha.Value.Date;
            visita.EstadoParcela = cboEstadoParcela.Text;
            visita.Observacion = txtObservacion.Text.Trim();
            visita.Tecnico = Sesion.UsuarioActual.Nombre;

            foreach (DataGridViewRow fila in dgvSeguimiento.Rows)
            {
                decimal kg;
                LeerDecimal(Convert.ToString(fila.Cells[colSeguimientoKg.Index].Value).Trim(), out kg);

                DetalleVisita d = new DetalleVisita();
                d.Cultivo = Convert.ToString(fila.Cells[colSeguimientoCultivo.Index].Value);
                d.Entregados = Convert.ToInt32(fila.Cells[colSeguimientoEntregados.Index].Value);
                d.Vivas = int.Parse(Convert.ToString(fila.Cells[colSeguimientoVivas.Index].Value).Trim());
                d.KgCosechados = kg;
                visita.Detalles.Add(d);
            }

            try
            {
                Datos.RegistrarVisita(visita);
            }
            catch (Exception ex)
            {
                Conexion.MostrarError("guardar la visita", ex);
                return;
            }

            double supervivencia = visita.Supervivencia();
            string nivel = Calculos.NivelAlerta(supervivencia);
            string resultado = "Supervivencia de la parcela " + parcela.Codigo + ": " + supervivencia.ToString("0.0") + " %";
            if (nivel == "")
                resultado += " · sin alerta";
            else
                resultado += " · Alerta " + nivel + " (umbral " + Calculos.UMBRAL_MEDIO + " %)";

            MessageBox.Show("Visita guardada.\n\n" + resultado, "Visita técnica", MessageBoxButtons.OK,
                nivel == "" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            LimpiarFormulario();
            lblEstado.Text = resultado;
            lblEstado.ForeColor = ColorSegunNivel(supervivencia);
        }

        private void LimpiarFormulario()
        {
            cboParcela.SelectedIndex = -1;
            cboEstadoParcela.SelectedIndex = -1;
            txtObservacion.Clear();
            dtpFecha.Value = DateTime.Today;
        }

        private void Aviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Visita técnica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
