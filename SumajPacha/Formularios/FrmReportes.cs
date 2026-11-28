using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SumajPacha.Presentacion
{
    public partial class FrmReportes : Form
    {
        // medidas del grafico
        private const int BASE_GRAFICO = 380; // línea del 0 %
        private const double PIXELES_POR_PUNTO = 3.2; // 320 px = 100 %

        private Panel[] barras;
        private Label[] valores;
        private Label[] nombres;
        private Color[] coloresOriginales;
        private readonly Color colorBajoUmbral = Color.FromArgb(215, 63, 43);

        private List<ResumenCultivo> resumen = new List<ResumenCultivo>();
        private int mujeres = 0;
        private int hombres = 0;
        private int[] porEdad = new int[3];

        private bool cargando = true;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            barras = new Panel[] { pnlBarra1, pnlBarra2, pnlBarra3, pnlBarra4 };
            valores = new Label[] { lblValorBarra1, lblValorBarra2, lblValorBarra3, lblValorBarra4 };
            nombres = new Label[] { lblCultivo1, lblCultivo2, lblCultivo3, lblCultivo4 };
            coloresOriginales = new Color[barras.Length];
            for (int i = 0; i < barras.Length; i++)
                coloresOriginales[i] = barras[i].BackColor;

            cboComunidad.Items.Add("Todas");
            foreach (string c in Datos.Comunidades)
                cboComunidad.Items.Add(c);

            cboPeriodo.Items.Add("Toda la campaña");
            cboPeriodo.Items.Add("Último mes");
            cboPeriodo.Items.Add("Últimos 15 días");

            cboComunidad.SelectedIndex = 0;
            cboSexo.SelectedIndex = 0;
            cboEdad.SelectedIndex = 0;
            cboPeriodo.SelectedIndex = 0;

            cargando = false;
            GenerarReporte();
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
                GenerarReporte();
        }

        // --- cálculo del reporte ---

        private bool CumpleFiltros(Familia f)
        {
            if (cboComunidad.Text != "Todas" && f.Comunidad != cboComunidad.Text)
                return false;

            if (cboSexo.Text == "Mujeres" && f.Sexo != "Mujer")
                return false;
            if (cboSexo.Text == "Hombres" && f.Sexo != "Hombre")
                return false;

            if (cboEdad.Text == "18-30" && (f.Edad < 18 || f.Edad > 30))
                return false;
            if (cboEdad.Text == "31-50" && (f.Edad < 31 || f.Edad > 50))
                return false;
            if (cboEdad.Text == "51+" && f.Edad < 51)
                return false;

            return true;
        }

        private DateTime FechaDesde()
        {
            if (cboPeriodo.Text == "Último mes")
                return DateTime.Today.AddMonths(-1);
            if (cboPeriodo.Text == "Últimos 15 días")
                return DateTime.Today.AddDays(-15);
            return DateTime.MinValue;
        }

        private void GenerarReporte()
        {
            List<Familia> familias = new List<Familia>();
            foreach (Familia f in Datos.Familias)
            {
                if (f.Activa && CumpleFiltros(f))
                    familias.Add(f);
            }

            // familias por sexo y edad
            mujeres = 0;
            hombres = 0;
            porEdad = new int[3];
            foreach (Familia f in familias)
            {
                if (f.Sexo == "Mujer")
                    mujeres++;
                else
                    hombres++;

                if (f.Edad <= 30)
                    porEdad[0]++;
                else if (f.Edad <= 50)
                    porEdad[1]++;
                else
                    porEdad[2]++;
            }

            dgvPorSexo.Rows.Clear();
            dgvPorSexo.Rows.Add("Mujeres", mujeres);
            dgvPorSexo.Rows.Add("Hombres", hombres);
            dgvPorSexo.ClearSelection();

            dgvPorEdad.Rows.Clear();
            dgvPorEdad.Rows.Add("18 a 30 años", porEdad[0]);
            dgvPorEdad.Rows.Add("31 a 50 años", porEdad[1]);
            dgvPorEdad.Rows.Add("51 años o más", porEdad[2]);
            dgvPorEdad.ClearSelection();

            // supervivencia por cultivo: se toma la última visita de cada parcela dentro del período
            DateTime desde = FechaDesde();
            resumen = new List<ResumenCultivo>();
            foreach (Cultivo c in Datos.Cultivos)
            {
                ResumenCultivo r = new ResumenCultivo();
                r.Cultivo = c.Nombre;
                resumen.Add(r);
            }

            foreach (Parcela p in Datos.Parcelas)
            {
                if (!familias.Contains(p.Familia))
                    continue;

                Visita ultima = null;
                foreach (Visita v in Datos.Visitas)
                {
                    if (v.Parcela == p && v.Fecha >= desde && (ultima == null || v.Fecha > ultima.Fecha))
                        ultima = v;
                }
                if (ultima == null)
                    continue;

                foreach (DetalleVisita d in ultima.Detalles)
                {
                    foreach (ResumenCultivo r in resumen)
                    {
                        if (r.Cultivo == d.Cultivo)
                        {
                            r.Entregados += d.Entregados;
                            r.Vivas += d.Vivas;
                        }
                    }
                }
            }

            DibujarGrafico();
        }

        private void DibujarGrafico()
        {
            // solo hay espacio para 4 barras: se muestran los primeros 4 cultivos con datos
            List<ResumenCultivo> conDatos = new List<ResumenCultivo>();
            foreach (ResumenCultivo r in resumen)
            {
                if (r.Entregados > 0)
                    conDatos.Add(r);
            }

            for (int i = 0; i < barras.Length; i++)
            {
                if (i >= conDatos.Count)
                {
                    barras[i].Visible = false;
                    valores[i].Visible = false;
                    nombres[i].Visible = false;
                    continue;
                }

                double porcentaje = conDatos[i].Porcentaje();
                int alto = (int)Math.Round(porcentaje * PIXELES_POR_PUNTO);
                if (alto < 2)
                    alto = 2;

                barras[i].Visible = true;
                valores[i].Visible = true;
                nombres[i].Visible = true;

                barras[i].Top = BASE_GRAFICO - alto;
                barras[i].Height = alto;
                valores[i].Top = barras[i].Top - 24;
                valores[i].Text = porcentaje.ToString("0") + " %";
                nombres[i].Text = conDatos[i].Cultivo;

                if (porcentaje < Calculos.UMBRAL_MEDIO)
                    barras[i].BackColor = colorBajoUmbral;
                else
                    barras[i].BackColor = coloresOriginales[i];
            }

            if (conDatos.Count == 0)
                lblTituloGrafico.Text = "Supervivencia por cultivo (sin visitas en este filtro)";
            else
                lblTituloGrafico.Text = "Supervivencia por cultivo";
        }

        private string TextoFiltros()
        {
            return "Comunidad: " + cboComunidad.Text + " | Sexo: " + cboSexo.Text
                + " | Edad: " + cboEdad.Text + " | Período: " + cboPeriodo.Text;
        }

        // --- exportar ---

        // se exporta como CSV separado por punto y coma, que Excel abre directo
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Title = "Exportar reporte a Excel";
            guardar.Filter = "Archivo de Excel (CSV)|*.csv";
            guardar.FileName = "Reporte_SumajPacha_" + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";

            if (guardar.ShowDialog() != DialogResult.OK)
                return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Huertos Sumaj Pacha - Reporte");
            sb.AppendLine("Generado;" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ";Usuario;" + Sesion.UsuarioActual.NombreUsuario);
            sb.AppendLine("Comunidad;" + cboComunidad.Text + ";Sexo;" + cboSexo.Text + ";Rango de edad;" + cboEdad.Text + ";Período;" + cboPeriodo.Text);
            sb.AppendLine();

            sb.AppendLine("Supervivencia por cultivo");
            sb.AppendLine("Cultivo;Plantines entregados;Plantas vivas;Supervivencia (%)");
            foreach (ResumenCultivo r in resumen)
            {
                if (r.Entregados > 0)
                    sb.AppendLine(r.Cultivo + ";" + r.Entregados + ";" + r.Vivas + ";" + r.Porcentaje().ToString("0.0"));
            }
            sb.AppendLine("Umbral de alerta;;;" + Calculos.UMBRAL_MEDIO);
            sb.AppendLine();

            sb.AppendLine("Familias por sexo");
            sb.AppendLine("Sexo;Familias");
            sb.AppendLine("Mujeres;" + mujeres);
            sb.AppendLine("Hombres;" + hombres);
            sb.AppendLine();

            sb.AppendLine("Familias por rango de edad");
            sb.AppendLine("Rango de edad;Familias");
            sb.AppendLine("18 a 30 años;" + porEdad[0]);
            sb.AppendLine("31 a 50 años;" + porEdad[1]);
            sb.AppendLine("51 años o más;" + porEdad[2]);

            try
            {
                // para que Excel muestre bien las tildes
                File.WriteAllText(guardar.FileName, sb.ToString(), new UTF8Encoding(true));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el archivo.\n" + ex.Message, "Exportar a Excel",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreguntarAbrir(guardar.FileName);
        }

        // el PDF se genera con la impresora "Microsoft Print to PDF" que trae Windows
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            PrintDocument documento = new PrintDocument();
            documento.DocumentName = "Reporte Sumaj Pacha";
            documento.DefaultPageSettings.Landscape = false;
            documento.PrintPage += Documento_PrintPage;
            documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            if (!documento.PrinterSettings.IsValid)
            {
                MessageBox.Show("No se encontró la impresora \"Microsoft Print to PDF\".\n"
                    + "Se abrirá la vista previa para que lo imprima con otra impresora.",
                    "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrintPreviewDialog vista = new PrintPreviewDialog();
                documento.PrinterSettings = new PrinterSettings();
                vista.Document = documento;
                vista.Width = 900;
                vista.Height = 700;
                vista.ShowDialog();
                return;
            }

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Title = "Exportar reporte a PDF";
            guardar.Filter = "Documento PDF|*.pdf";
            guardar.FileName = "Reporte_SumajPacha_" + DateTime.Today.ToString("yyyy-MM-dd") + ".pdf";

            if (guardar.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                documento.PrinterSettings.PrintToFile = true;
                documento.PrinterSettings.PrintFileName = guardar.FileName;
                documento.PrintController = new StandardPrintController(); // sin la ventanita de "imprimiendo"
                documento.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el PDF.\n" + ex.Message, "Exportar a PDF",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreguntarAbrir(guardar.FileName);
        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle margen = e.MarginBounds;
            int y = margen.Top;

            using (Font titulo = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font normal = new Font("Segoe UI", 9))
            using (Brush verde = new SolidBrush(Color.FromArgb(70, 112, 45)))
            {
                g.DrawString("Huertos Sumaj Pacha - Reporte", titulo, verde, margen.Left, y);
                y += 34;
                g.DrawString("ONG Yachay Chhalaku · Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    + " por " + Sesion.UsuarioActual.Nombre, normal, Brushes.Black, margen.Left, y);
                y += 18;
                g.DrawString(TextoFiltros(), normal, Brushes.Black, margen.Left, y);
                y += 30;
            }

            // se copia la imagen de los paneles y se dibuja en la hoja
            using (Bitmap grafico = new Bitmap(pnlGrafico.Width, pnlGrafico.Height))
            using (Bitmap familias = new Bitmap(pnlFamilias.Width, pnlFamilias.Height))
            {
                pnlGrafico.DrawToBitmap(grafico, new Rectangle(0, 0, grafico.Width, grafico.Height));
                pnlFamilias.DrawToBitmap(familias, new Rectangle(0, 0, familias.Width, familias.Height));

                float escala = Math.Min(1f, (float)margen.Width / grafico.Width);
                int ancho = (int)(grafico.Width * escala);
                int alto = (int)(grafico.Height * escala);
                g.DrawImage(grafico, margen.Left, y, ancho, alto);
                y += alto + 20;

                float escala2 = Math.Min(escala, (float)(margen.Bottom - y) / familias.Height);
                g.DrawImage(familias, margen.Left, y, (int)(familias.Width * escala2), (int)(familias.Height * escala2));
            }

            e.HasMorePages = false;
        }

        private void PreguntarAbrir(string ruta)
        {
            DialogResult r = MessageBox.Show("Reporte guardado en:\n" + ruta + "\n\n¿Desea abrirlo?",
                "Reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el archivo.\n" + ex.Message, "Reporte",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
