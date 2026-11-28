namespace SumajPacha.Presentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.tslConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslEspacio = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.lblSeguimiento = new System.Windows.Forms.Label();
            this.btnFamilias = new System.Windows.Forms.Button();
            this.btnEntregas = new System.Windows.Forms.Button();
            this.btnVisitas = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblSaludo = new System.Windows.Forms.Label();
            this.pnlInd1 = new System.Windows.Forms.Panel();
            this.lblTituloInd1 = new System.Windows.Forms.Label();
            this.lblValorInd1 = new System.Windows.Forms.Label();
            this.pnlInd2 = new System.Windows.Forms.Panel();
            this.lblTituloInd2 = new System.Windows.Forms.Label();
            this.lblValorInd2 = new System.Windows.Forms.Label();
            this.pnlInd3 = new System.Windows.Forms.Panel();
            this.lblTituloInd3 = new System.Windows.Forms.Label();
            this.lblValorInd3 = new System.Windows.Forms.Label();
            this.lblUnidadInd3 = new System.Windows.Forms.Label();
            this.pnlInd4 = new System.Windows.Forms.Panel();
            this.lblTituloInd4 = new System.Windows.Forms.Label();
            this.lblValorInd4 = new System.Windows.Forms.Label();
            this.lblUnidadInd4 = new System.Windows.Forms.Label();
            this.lblProximas = new System.Windows.Forms.Label();
            this.pnlAlerta = new System.Windows.Forms.Panel();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.dgvProximasVisitas = new System.Windows.Forms.DataGridView();
            this.colProximasVisitasFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProximasVisitasParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProximasVisitasFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssEstado.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlInd1.SuspendLayout();
            this.pnlInd2.SuspendLayout();
            this.pnlInd3.SuspendLayout();
            this.pnlInd4.SuspendLayout();
            this.pnlAlerta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProximasVisitas)).BeginInit();
            this.SuspendLayout();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            // 
            // ssEstado
            // 
            this.ssEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(222)))));
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslConexion,
            this.tslEspacio,
            this.tslUsuario});
            this.ssEstado.Location = new System.Drawing.Point(0, 576);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Size = new System.Drawing.Size(1000, 24);
            this.ssEstado.TabIndex = 0;
            this.ssEstado.Text = "ssEstado";
            // 
            // tslConexion
            // 
            this.tslConexion.Name = "tslConexion";
            this.tslConexion.Size = new System.Drawing.Size(320, 17);
            this.tslConexion.Text = "Conectado a SQL Server • Último respaldo: 18/11/2026";
            // 
            // tslEspacio
            // 
            this.tslEspacio.Name = "tslEspacio";
            this.tslEspacio.Spring = true;
            this.tslEspacio.Size = new System.Drawing.Size(400, 17);
            this.tslEspacio.Text = "";
            // 
            // tslUsuario
            // 
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Size = new System.Drawing.Size(230, 17);
            this.tslUsuario.Text = "Usuario: erodriguez (Administrador)";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.pnlMenu.Controls.Add(this.btnCerrarSesion);
            this.pnlMenu.Controls.Add(this.btnReportes);
            this.pnlMenu.Controls.Add(this.btnVisitas);
            this.pnlMenu.Controls.Add(this.btnEntregas);
            this.pnlMenu.Controls.Add(this.btnFamilias);
            this.pnlMenu.Controls.Add(this.lblSeguimiento);
            this.pnlMenu.Controls.Add(this.btnAdministracion);
            this.pnlMenu.Controls.Add(this.btnInicio);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 576);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(145)))), ((int)(((byte)(80)))));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(145)))), ((int)(((byte)(80)))));
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInicio.Location = new System.Drawing.Point(10, 20);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(180, 38);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnAdministracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministracion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnAdministracion.FlatAppearance.BorderSize = 0;
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdministracion.Location = new System.Drawing.Point(10, 66);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(180, 38);
            this.btnAdministracion.TabIndex = 1;
            this.btnAdministracion.Text = "Administración";
            this.btnAdministracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministracion.UseVisualStyleBackColor = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
            // 
            // lblSeguimiento
            // 
            this.lblSeguimiento.AutoSize = true;
            this.lblSeguimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeguimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSeguimiento.Location = new System.Drawing.Point(20, 118);
            this.lblSeguimiento.Name = "lblSeguimiento";
            this.lblSeguimiento.Size = new System.Drawing.Size(84, 18);
            this.lblSeguimiento.TabIndex = 2;
            this.lblSeguimiento.Text = "Seguimiento";
            // 
            // btnFamilias
            // 
            this.btnFamilias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnFamilias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFamilias.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnFamilias.FlatAppearance.BorderSize = 0;
            this.btnFamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamilias.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFamilias.Location = new System.Drawing.Point(20, 146);
            this.btnFamilias.Name = "btnFamilias";
            this.btnFamilias.Size = new System.Drawing.Size(170, 38);
            this.btnFamilias.TabIndex = 3;
            this.btnFamilias.Text = "Familias y parcelas";
            this.btnFamilias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFamilias.UseVisualStyleBackColor = false;
            this.btnFamilias.Click += new System.EventHandler(this.btnFamilias_Click);
            // 
            // btnEntregas
            // 
            this.btnEntregas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnEntregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnEntregas.FlatAppearance.BorderSize = 0;
            this.btnEntregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregas.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEntregas.Location = new System.Drawing.Point(20, 186);
            this.btnEntregas.Name = "btnEntregas";
            this.btnEntregas.Size = new System.Drawing.Size(170, 38);
            this.btnEntregas.TabIndex = 4;
            this.btnEntregas.Text = "Entregas";
            this.btnEntregas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntregas.UseVisualStyleBackColor = false;
            this.btnEntregas.Click += new System.EventHandler(this.btnEntregas_Click);
            // 
            // btnVisitas
            // 
            this.btnVisitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnVisitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisitas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnVisitas.FlatAppearance.BorderSize = 0;
            this.btnVisitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitas.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnVisitas.Location = new System.Drawing.Point(20, 226);
            this.btnVisitas.Name = "btnVisitas";
            this.btnVisitas.Size = new System.Drawing.Size(170, 38);
            this.btnVisitas.TabIndex = 5;
            this.btnVisitas.Text = "Visitas";
            this.btnVisitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitas.UseVisualStyleBackColor = false;
            this.btnVisitas.Click += new System.EventHandler(this.btnVisitas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReportes.Location = new System.Drawing.Point(10, 276);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(180, 38);
            this.btnReportes.TabIndex = 6;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCerrarSesion.Location = new System.Drawing.Point(10, 322);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(180, 38);
            this.btnCerrarSesion.TabIndex = 7;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblSaludo.Location = new System.Drawing.Point(224, 20);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(326, 28);
            this.lblSaludo.TabIndex = 2;
            this.lblSaludo.Text = "Hola, Escarlem · Administrador";
            // 
            // pnlInd1
            // 
            this.pnlInd1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.pnlInd1.Controls.Add(this.lblValorInd1);
            this.pnlInd1.Controls.Add(this.lblTituloInd1);
            this.pnlInd1.Location = new System.Drawing.Point(225, 70);
            this.pnlInd1.Name = "pnlInd1";
            this.pnlInd1.Size = new System.Drawing.Size(175, 145);
            this.pnlInd1.TabIndex = 3;
            // 
            // lblTituloInd1
            // 
            this.lblTituloInd1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInd1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblTituloInd1.Location = new System.Drawing.Point(0, 10);
            this.lblTituloInd1.Name = "lblTituloInd1";
            this.lblTituloInd1.Size = new System.Drawing.Size(175, 40);
            this.lblTituloInd1.TabIndex = 0;
            this.lblTituloInd1.Text = "Familias activas";
            this.lblTituloInd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorInd1
            // 
            this.lblValorInd1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInd1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblValorInd1.Location = new System.Drawing.Point(0, 50);
            this.lblValorInd1.Name = "lblValorInd1";
            this.lblValorInd1.Size = new System.Drawing.Size(175, 55);
            this.lblValorInd1.TabIndex = 1;
            this.lblValorInd1.Text = "35";
            this.lblValorInd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInd2
            // 
            this.pnlInd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.pnlInd2.Controls.Add(this.lblValorInd2);
            this.pnlInd2.Controls.Add(this.lblTituloInd2);
            this.pnlInd2.Location = new System.Drawing.Point(413, 70);
            this.pnlInd2.Name = "pnlInd2";
            this.pnlInd2.Size = new System.Drawing.Size(175, 145);
            this.pnlInd2.TabIndex = 4;
            // 
            // lblTituloInd2
            // 
            this.lblTituloInd2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInd2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblTituloInd2.Location = new System.Drawing.Point(0, 10);
            this.lblTituloInd2.Name = "lblTituloInd2";
            this.lblTituloInd2.Size = new System.Drawing.Size(175, 40);
            this.lblTituloInd2.TabIndex = 0;
            this.lblTituloInd2.Text = "Supervivencia\r\nde plantines";
            this.lblTituloInd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorInd2
            // 
            this.lblValorInd2.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInd2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblValorInd2.Location = new System.Drawing.Point(0, 50);
            this.lblValorInd2.Name = "lblValorInd2";
            this.lblValorInd2.Size = new System.Drawing.Size(175, 55);
            this.lblValorInd2.TabIndex = 1;
            this.lblValorInd2.Text = "90 %";
            this.lblValorInd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInd3
            // 
            this.pnlInd3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.pnlInd3.Controls.Add(this.lblUnidadInd3);
            this.pnlInd3.Controls.Add(this.lblValorInd3);
            this.pnlInd3.Controls.Add(this.lblTituloInd3);
            this.pnlInd3.Location = new System.Drawing.Point(601, 70);
            this.pnlInd3.Name = "pnlInd3";
            this.pnlInd3.Size = new System.Drawing.Size(175, 145);
            this.pnlInd3.TabIndex = 5;
            // 
            // lblTituloInd3
            // 
            this.lblTituloInd3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInd3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblTituloInd3.Location = new System.Drawing.Point(0, 10);
            this.lblTituloInd3.Name = "lblTituloInd3";
            this.lblTituloInd3.Size = new System.Drawing.Size(175, 40);
            this.lblTituloInd3.TabIndex = 0;
            this.lblTituloInd3.Text = "Rendimiento";
            this.lblTituloInd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorInd3
            // 
            this.lblValorInd3.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInd3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblValorInd3.Location = new System.Drawing.Point(0, 50);
            this.lblValorInd3.Name = "lblValorInd3";
            this.lblValorInd3.Size = new System.Drawing.Size(175, 55);
            this.lblValorInd3.TabIndex = 1;
            this.lblValorInd3.Text = "1,8";
            this.lblValorInd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnidadInd3
            // 
            this.lblUnidadInd3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadInd3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblUnidadInd3.Location = new System.Drawing.Point(0, 108);
            this.lblUnidadInd3.Name = "lblUnidadInd3";
            this.lblUnidadInd3.Size = new System.Drawing.Size(175, 26);
            this.lblUnidadInd3.TabIndex = 2;
            this.lblUnidadInd3.Text = "kg/m²";
            this.lblUnidadInd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInd4
            // 
            this.pnlInd4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.pnlInd4.Controls.Add(this.lblUnidadInd4);
            this.pnlInd4.Controls.Add(this.lblValorInd4);
            this.pnlInd4.Controls.Add(this.lblTituloInd4);
            this.pnlInd4.Location = new System.Drawing.Point(789, 70);
            this.pnlInd4.Name = "pnlInd4";
            this.pnlInd4.Size = new System.Drawing.Size(175, 145);
            this.pnlInd4.TabIndex = 6;
            // 
            // lblTituloInd4
            // 
            this.lblTituloInd4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInd4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblTituloInd4.Location = new System.Drawing.Point(0, 10);
            this.lblTituloInd4.Name = "lblTituloInd4";
            this.lblTituloInd4.Size = new System.Drawing.Size(175, 40);
            this.lblTituloInd4.TabIndex = 0;
            this.lblTituloInd4.Text = "CO₂ evitado";
            this.lblTituloInd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorInd4
            // 
            this.lblValorInd4.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInd4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblValorInd4.Location = new System.Drawing.Point(0, 50);
            this.lblValorInd4.Name = "lblValorInd4";
            this.lblValorInd4.Size = new System.Drawing.Size(175, 55);
            this.lblValorInd4.TabIndex = 1;
            this.lblValorInd4.Text = "115,5";
            this.lblValorInd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnidadInd4
            // 
            this.lblUnidadInd4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadInd4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(104)))), ((int)(((byte)(55)))));
            this.lblUnidadInd4.Location = new System.Drawing.Point(0, 108);
            this.lblUnidadInd4.Name = "lblUnidadInd4";
            this.lblUnidadInd4.Size = new System.Drawing.Size(175, 26);
            this.lblUnidadInd4.TabIndex = 2;
            this.lblUnidadInd4.Text = "kg por campaña";
            this.lblUnidadInd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProximas
            // 
            this.lblProximas.AutoSize = true;
            this.lblProximas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProximas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblProximas.Location = new System.Drawing.Point(224, 236);
            this.lblProximas.Name = "lblProximas";
            this.lblProximas.Size = new System.Drawing.Size(132, 21);
            this.lblProximas.TabIndex = 7;
            this.lblProximas.Text = "Próximas visitas";
            // 
            // pnlAlerta
            // 
            this.pnlAlerta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlAlerta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlerta.Controls.Add(this.lblAlerta);
            this.pnlAlerta.Location = new System.Drawing.Point(420, 234);
            this.pnlAlerta.Name = "pnlAlerta";
            this.pnlAlerta.Size = new System.Drawing.Size(544, 32);
            this.pnlAlerta.TabIndex = 8;
            // 
            // lblAlerta
            // 
            this.lblAlerta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlerta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(82)))), ((int)(((byte)(0)))));
            this.lblAlerta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAlerta.Location = new System.Drawing.Point(0, 0);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(544, 32);
            this.lblAlerta.TabIndex = 0;
            this.lblAlerta.Text = "⚠ Alerta MEDIO: parcela P-07 con 76,3 % de supervivencia (umbral 81 %)";
            this.lblAlerta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlerta.Click += new System.EventHandler(this.lblAlerta_Click);
            // 
            // dgvProximasVisitas
            // 
            this.dgvProximasVisitas.AllowUserToAddRows = false;
            this.dgvProximasVisitas.AllowUserToDeleteRows = false;
            this.dgvProximasVisitas.AllowUserToResizeRows = false;
            this.dgvProximasVisitas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProximasVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProximasVisitas.BackgroundColor = System.Drawing.Color.White;
            this.dgvProximasVisitas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProximasVisitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProximasVisitas.ColumnHeadersHeight = 34;
            this.dgvProximasVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProximasVisitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProximasVisitasFamilia,
            this.colProximasVisitasParcela,
            this.colProximasVisitasFecha});
            this.dgvProximasVisitas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProximasVisitas.EnableHeadersVisualStyles = false;
            this.dgvProximasVisitas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.dgvProximasVisitas.Location = new System.Drawing.Point(225, 278);
            this.dgvProximasVisitas.MultiSelect = false;
            this.dgvProximasVisitas.Name = "dgvProximasVisitas";
            this.dgvProximasVisitas.ReadOnly = true;
            this.dgvProximasVisitas.RowHeadersVisible = false;
            this.dgvProximasVisitas.RowTemplate.Height = 30;
            this.dgvProximasVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProximasVisitas.Size = new System.Drawing.Size(739, 280);
            this.dgvProximasVisitas.TabIndex = 9;
            this.dgvProximasVisitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProximasVisitas_CellDoubleClick);
            // 
            // colProximasVisitasFamilia
            // 
            this.colProximasVisitasFamilia.FillWeight = 180F;
            this.colProximasVisitasFamilia.HeaderText = "Familia";
            this.colProximasVisitasFamilia.MinimumWidth = 6;
            this.colProximasVisitasFamilia.Name = "colProximasVisitasFamilia";
            // 
            // colProximasVisitasParcela
            // 
            this.colProximasVisitasParcela.FillWeight = 90F;
            this.colProximasVisitasParcela.HeaderText = "Parcela";
            this.colProximasVisitasParcela.MinimumWidth = 6;
            this.colProximasVisitasParcela.Name = "colProximasVisitasParcela";
            // 
            // colProximasVisitasFecha
            // 
            this.colProximasVisitasFecha.FillWeight = 110F;
            this.colProximasVisitasFecha.HeaderText = "Fecha de visita";
            this.colProximasVisitasFecha.MinimumWidth = 6;
            this.colProximasVisitasFecha.Name = "colProximasVisitasFecha";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvProximasVisitas);
            this.Controls.Add(this.pnlAlerta);
            this.Controls.Add(this.lblProximas);
            this.Controls.Add(this.pnlInd4);
            this.Controls.Add(this.pnlInd3);
            this.Controls.Add(this.pnlInd2);
            this.Controls.Add(this.pnlInd1);
            this.Controls.Add(this.lblSaludo);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.ssEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huertos Sumaj Pacha";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProximasVisitas)).EndInit();
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlInd1.ResumeLayout(false);
            this.pnlInd1.PerformLayout();
            this.pnlInd2.ResumeLayout(false);
            this.pnlInd2.PerformLayout();
            this.pnlInd3.ResumeLayout(false);
            this.pnlInd3.PerformLayout();
            this.pnlInd4.ResumeLayout(false);
            this.pnlInd4.PerformLayout();
            this.pnlAlerta.ResumeLayout(false);
            this.pnlAlerta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel tslConexion;
        private System.Windows.Forms.ToolStripStatusLabel tslEspacio;
        private System.Windows.Forms.ToolStripStatusLabel tslUsuario;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.Label lblSeguimiento;
        private System.Windows.Forms.Button btnFamilias;
        private System.Windows.Forms.Button btnEntregas;
        private System.Windows.Forms.Button btnVisitas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Panel pnlInd1;
        private System.Windows.Forms.Label lblTituloInd1;
        private System.Windows.Forms.Label lblValorInd1;
        private System.Windows.Forms.Panel pnlInd2;
        private System.Windows.Forms.Label lblTituloInd2;
        private System.Windows.Forms.Label lblValorInd2;
        private System.Windows.Forms.Panel pnlInd3;
        private System.Windows.Forms.Label lblTituloInd3;
        private System.Windows.Forms.Label lblValorInd3;
        private System.Windows.Forms.Label lblUnidadInd3;
        private System.Windows.Forms.Panel pnlInd4;
        private System.Windows.Forms.Label lblTituloInd4;
        private System.Windows.Forms.Label lblValorInd4;
        private System.Windows.Forms.Label lblUnidadInd4;
        private System.Windows.Forms.Label lblProximas;
        private System.Windows.Forms.Panel pnlAlerta;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.DataGridView dgvProximasVisitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProximasVisitasFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProximasVisitasParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProximasVisitasFecha;
    }
}
