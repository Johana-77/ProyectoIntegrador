using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        // colores del menú
        private readonly Color colorMenu = Color.FromArgb(70, 112, 45);
        private readonly Color colorMenuActivo = Color.FromArgb(110, 145, 80);

        private Parcela parcelaEnAlerta = null;

        public bool SesionCerrada { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Usuario u = Sesion.UsuarioActual;
            lblSaludo.Text = "Hola, " + u.PrimerNombre() + " · " + u.Rol;
            tslUsuario.Text = "Usuario: " + u.NombreUsuario + " (" + u.Rol + ")";
            tslConexion.Text = "Sesión iniciada: " + Sesion.Inicio.ToString("dd/MM/yyyy HH:mm");

            CargarResumen();
        }

        // --- panel de inicio ---

        private void CargarResumen()
        {
            CargarIndicadores();
            CargarAlerta();
            CargarProximasVisitas();
        }

        private void CargarIndicadores()
        {
            int familiasActivas = 0;
            foreach (Familia f in Datos.Familias)
            {
                if (f.Activa)
                    familiasActivas++;
            }
            lblValorInd1.Text = familiasActivas.ToString();

            // supervivencia general con la última visita de cada parcela
            int entregados = 0;
            int vivas = 0;
            decimal superficie = 0;
            foreach (Parcela p in Datos.Parcelas)
            {
                superficie += p.Superficie;
                Visita ultima = Datos.UltimaVisita(p);
                if (ultima != null)
                {
                    entregados += ultima.TotalEntregados();
                    vivas += ultima.TotalVivas();
                }
            }
            double supervivencia = Calculos.Supervivencia(vivas, entregados);
            lblValorInd2.Text = supervivencia.ToString("0") + " %";

            // todo lo cosechado en la campaña
            decimal kgCosechados = 0;
            foreach (Visita v in Datos.Visitas)
                kgCosechados += v.TotalKg();

            decimal rendimiento = 0;
            if (superficie > 0)
                rendimiento = kgCosechados / superficie;
            lblValorInd3.Text = rendimiento.ToString("0.000");

            double co2 = (double)kgCosechados * Calculos.FACTOR_CO2;
            lblValorInd4.Text = co2.ToString("0.0");
        }

        private void CargarAlerta()
        {
            parcelaEnAlerta = null;
            double peor = 100;
            int parcelasEnAlerta = 0;

            foreach (Parcela p in Datos.Parcelas)
            {
                Visita ultima = Datos.UltimaVisita(p);
                if (ultima == null)
                    continue;

                double s = ultima.Supervivencia();
                if (s < Calculos.UMBRAL_MEDIO)
                {
                    parcelasEnAlerta++;
                    if (s < peor)
                    {
                        peor = s;
                        parcelaEnAlerta = p;
                    }
                }
            }

            if (parcelaEnAlerta == null)
            {
                pnlAlerta.BackColor = Color.FromArgb(226, 239, 218);
                lblAlerta.ForeColor = Color.FromArgb(70, 112, 45);
                lblAlerta.Text = "✓ Todas las parcelas están sobre el umbral de supervivencia (81 %)";
                lblAlerta.Cursor = Cursors.Default;
                return;
            }

            string nivel = Calculos.NivelAlerta(peor);
            if (nivel == "ALTO")
            {
                pnlAlerta.BackColor = Color.FromArgb(253, 226, 222);
                lblAlerta.ForeColor = Color.FromArgb(176, 42, 25);
            }
            else
            {
                pnlAlerta.BackColor = Color.FromArgb(255, 243, 205);
                lblAlerta.ForeColor = Color.FromArgb(122, 82, 0);
            }

            if (parcelasEnAlerta == 1)
            {
                lblAlerta.Text = "⚠ Alerta " + nivel + ": parcela " + parcelaEnAlerta.Codigo + " con "
                    + peor.ToString("0.0") + " % de supervivencia (umbral 81 %)";
            }
            else
            {
                lblAlerta.Text = "⚠ Alerta " + nivel + ": " + parcelaEnAlerta.Codigo + " con "
                    + peor.ToString("0.0") + " % y " + (parcelasEnAlerta - 1) + " parcela(s) más bajo el 81 %";
            }
            lblAlerta.Cursor = Cursors.Hand;
        }

        private void CargarProximasVisitas()
        {
            dgvProximasVisitas.Rows.Clear();

            // se ordenan por fecha, las más cercanas primero
            List<Parcela> parcelas = new List<Parcela>();
            foreach (Parcela p in Datos.Parcelas)
            {
                if (p.Familia.Activa)
                    parcelas.Add(p);
            }
            parcelas.Sort((a, b) => Datos.ProximaVisita(a).CompareTo(Datos.ProximaVisita(b)));

            foreach (Parcela p in parcelas)
            {
                DateTime fecha = Datos.ProximaVisita(p);
                string texto = fecha.ToString("dd/MM/yyyy");
                if (fecha < DateTime.Today)
                    texto += "  (atrasada)";
                else if (fecha == DateTime.Today)
                    texto += "  (hoy)";

                int fila = dgvProximasVisitas.Rows.Add(p.Familia.NombreCompleto(), p.Codigo, texto);
                if (fecha < DateTime.Today)
                    dgvProximasVisitas.Rows[fila].DefaultCellStyle.ForeColor = Color.FromArgb(212, 104, 55);
            }
            dgvProximasVisitas.ClearSelection();
        }

        // --- menú ---

        private void MarcarBoton(Button boton)
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = colorMenu;
                    ((Button)c).FlatAppearance.BorderColor = colorMenu;
                }
            }
            boton.BackColor = colorMenuActivo;
            boton.FlatAppearance.BorderColor = colorMenuActivo;
        }

        private void AbrirFormulario(Form formulario, Button boton)
        {
            MarcarBoton(boton);
            formulario.ShowDialog(this);
            formulario.Dispose();

            // al volver se actualiza el resumen con lo que se registró
            MarcarBoton(btnInicio);
            CargarResumen();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MarcarBoton(btnInicio);
            CargarResumen();
        }

        // el rol Consulta solo ve el inicio y los reportes, no registra nada
        private bool SoloConsulta()
        {
            if (!Sesion.EsConsulta())
                return false;

            MessageBox.Show("Su rol (Consulta) solo puede ver el inicio y los reportes.", "Acceso restringido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            // solo el administrador entra a Administracion
            if (!Sesion.EsAdministrador())
            {
                MessageBox.Show("Su rol no tiene acceso a Administración.", "Acceso restringido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirFormulario(new FrmAdministracion(), btnAdministracion);
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            if (SoloConsulta())
                return;
            AbrirFormulario(new FrmFamilias(), btnFamilias);
        }

        private void btnEntregas_Click(object sender, EventArgs e)
        {
            if (SoloConsulta())
                return;
            AbrirFormulario(new FrmEntregas(), btnEntregas);
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            if (SoloConsulta())
                return;
            AbrirFormulario(new FrmVisitas(), btnVisitas);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes(), btnReportes);
        }

        // doble clic en una próxima visita abre la visita técnica de esa parcela
        private void dgvProximasVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || SoloConsulta())
                return;
            string codigo = dgvProximasVisitas.Rows[e.RowIndex].Cells[colProximasVisitasParcela.Index].Value.ToString();
            AbrirFormulario(new FrmVisitas(codigo), btnVisitas);
        }

        private void lblAlerta_Click(object sender, EventArgs e)
        {
            if (parcelaEnAlerta != null && !SoloConsulta())
                AbrirFormulario(new FrmVisitas(parcelaEnAlerta.Codigo), btnVisitas);
        }

        // --- salir ---

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea cerrar la sesión?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SesionCerrada = true;
                Sesion.Cerrar();
                this.Close();
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SesionCerrada)
                return;

            DialogResult r = MessageBox.Show("¿Desea salir del sistema?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
