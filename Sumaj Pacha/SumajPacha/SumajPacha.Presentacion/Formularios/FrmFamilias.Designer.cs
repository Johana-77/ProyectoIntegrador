namespace SumajPacha.Presentacion
{
    partial class FrmFamilias
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
            this.lblFamilias = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvFamilias = new System.Windows.Forms.DataGridView();
            this.colFamiliasCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasComunidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamiliasMiembros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblNuevaParcela = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.cboFamilia = new System.Windows.Forms.ComboBox();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.cboProyecto = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblSuperficie = new System.Windows.Forms.Label();
            this.numSuperficie = new System.Windows.Forms.NumericUpDown();
            this.lblRiego = new System.Windows.Forms.Label();
            this.cboRiego = new System.Windows.Forms.ComboBox();
            this.lblFechaInstalacion = new System.Windows.Forms.Label();
            this.dtpInstalacion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            this.pnlSeparador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).BeginInit();
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
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblFamilias.Location = new System.Drawing.Point(18, 14);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(78, 25);
            this.lblFamilias.TabIndex = 0;
            this.lblFamilias.Text = "Familias";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblBuscar.Location = new System.Drawing.Point(20, 58);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(99, 18);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar familia:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(130, 54);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(330, 27);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuscar.Location = new System.Drawing.Point(470, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 29);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.AllowUserToAddRows = false;
            this.dgvFamilias.AllowUserToDeleteRows = false;
            this.dgvFamilias.AllowUserToResizeRows = false;
            this.dgvFamilias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFamilias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFamilias.BackgroundColor = System.Drawing.Color.White;
            this.dgvFamilias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFamilias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFamilias.ColumnHeadersHeight = 34;
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFamilias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFamiliasCodigo,
            this.colFamiliasNombres,
            this.colFamiliasApellidos,
            this.colFamiliasComunidad,
            this.colFamiliasSexo,
            this.colFamiliasEdad,
            this.colFamiliasMiembros});
            this.dgvFamilias.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFamilias.EnableHeadersVisualStyles = false;
            this.dgvFamilias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.dgvFamilias.Location = new System.Drawing.Point(20, 96);
            this.dgvFamilias.MultiSelect = false;
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.ReadOnly = true;
            this.dgvFamilias.RowHeadersVisible = false;
            this.dgvFamilias.RowTemplate.Height = 30;
            this.dgvFamilias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFamilias.Size = new System.Drawing.Size(580, 400);
            this.dgvFamilias.TabIndex = 4;
            // 
            // colFamiliasCodigo
            // 
            this.colFamiliasCodigo.FillWeight = 62F;
            this.colFamiliasCodigo.HeaderText = "Código";
            this.colFamiliasCodigo.MinimumWidth = 6;
            this.colFamiliasCodigo.Name = "colFamiliasCodigo";
            // 
            // colFamiliasNombres
            // 
            this.colFamiliasNombres.FillWeight = 90F;
            this.colFamiliasNombres.HeaderText = "Nombres";
            this.colFamiliasNombres.MinimumWidth = 6;
            this.colFamiliasNombres.Name = "colFamiliasNombres";
            // 
            // colFamiliasApellidos
            // 
            this.colFamiliasApellidos.FillWeight = 118F;
            this.colFamiliasApellidos.HeaderText = "Apellidos";
            this.colFamiliasApellidos.MinimumWidth = 6;
            this.colFamiliasApellidos.Name = "colFamiliasApellidos";
            // 
            // colFamiliasComunidad
            // 
            this.colFamiliasComunidad.FillWeight = 96F;
            this.colFamiliasComunidad.HeaderText = "Comunidad";
            this.colFamiliasComunidad.MinimumWidth = 6;
            this.colFamiliasComunidad.Name = "colFamiliasComunidad";
            // 
            // colFamiliasSexo
            // 
            this.colFamiliasSexo.FillWeight = 52F;
            this.colFamiliasSexo.HeaderText = "Sexo";
            this.colFamiliasSexo.MinimumWidth = 6;
            this.colFamiliasSexo.Name = "colFamiliasSexo";
            // 
            // colFamiliasEdad
            // 
            this.colFamiliasEdad.FillWeight = 52F;
            this.colFamiliasEdad.HeaderText = "Edad";
            this.colFamiliasEdad.MinimumWidth = 6;
            this.colFamiliasEdad.Name = "colFamiliasEdad";
            // 
            // colFamiliasMiembros
            // 
            this.colFamiliasMiembros.FillWeight = 84F;
            this.colFamiliasMiembros.HeaderText = "Miembros";
            this.colFamiliasMiembros.MinimumWidth = 6;
            this.colFamiliasMiembros.Name = "colFamiliasMiembros";
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.pnlSeparador.Location = new System.Drawing.Point(618, 14);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(1, 482);
            this.pnlSeparador.TabIndex = 5;
            // 
            // lblNuevaParcela
            // 
            this.lblNuevaParcela.AutoSize = true;
            this.lblNuevaParcela.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaParcela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblNuevaParcela.Location = new System.Drawing.Point(636, 14);
            this.lblNuevaParcela.Name = "lblNuevaParcela";
            this.lblNuevaParcela.Size = new System.Drawing.Size(134, 25);
            this.lblNuevaParcela.TabIndex = 6;
            this.lblNuevaParcela.Text = "Nueva parcela";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblFamilia.Location = new System.Drawing.Point(638, 64);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(49, 18);
            this.lblFamilia.TabIndex = 7;
            this.lblFamilia.Text = "Familia";
            // 
            // cboFamilia
            // 
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.Items.AddRange(new object[] {
            });
            this.cboFamilia.Location = new System.Drawing.Point(790, 60);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(190, 25);
            this.cboFamilia.TabIndex = 8;
            // 
            // lblProyecto
            // 
            this.lblProyecto.AutoSize = true;
            this.lblProyecto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyecto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblProyecto.Location = new System.Drawing.Point(638, 108);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(61, 18);
            this.lblProyecto.TabIndex = 9;
            this.lblProyecto.Text = "Proyecto";
            // 
            // cboProyecto
            // 
            this.cboProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProyecto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProyecto.FormattingEnabled = true;
            this.cboProyecto.Items.AddRange(new object[] {
            "Sumaj Pacha"});
            this.cboProyecto.Location = new System.Drawing.Point(790, 104);
            this.cboProyecto.Name = "cboProyecto";
            this.cboProyecto.Size = new System.Drawing.Size(190, 25);
            this.cboProyecto.TabIndex = 10;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblTipo.Location = new System.Drawing.Point(638, 152);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(32, 18);
            this.lblTipo.TabIndex = 11;
            this.lblTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Huerto familiar",
            "Sistema agroforestal (SAF)"});
            this.cboTipo.Location = new System.Drawing.Point(790, 148);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(190, 25);
            this.cboTipo.TabIndex = 12;
            // 
            // lblSuperficie
            // 
            this.lblSuperficie.AutoSize = true;
            this.lblSuperficie.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuperficie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblSuperficie.Location = new System.Drawing.Point(638, 196);
            this.lblSuperficie.Name = "lblSuperficie";
            this.lblSuperficie.Size = new System.Drawing.Size(92, 18);
            this.lblSuperficie.TabIndex = 13;
            this.lblSuperficie.Text = "Superficie m²";
            // 
            // numSuperficie
            // 
            this.numSuperficie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSuperficie.Location = new System.Drawing.Point(790, 192);
            this.numSuperficie.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSuperficie.Name = "numSuperficie";
            this.numSuperficie.Size = new System.Drawing.Size(190, 25);
            this.numSuperficie.TabIndex = 14;
            this.numSuperficie.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // lblRiego
            // 
            this.lblRiego.AutoSize = true;
            this.lblRiego.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblRiego.Location = new System.Drawing.Point(638, 240);
            this.lblRiego.Name = "lblRiego";
            this.lblRiego.Size = new System.Drawing.Size(90, 18);
            this.lblRiego.TabIndex = 15;
            this.lblRiego.Text = "¿Tiene riego?";
            // 
            // cboRiego
            // 
            this.cboRiego.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRiego.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRiego.FormattingEnabled = true;
            this.cboRiego.Items.AddRange(new object[] {
            "Sí",
            "No"});
            this.cboRiego.Location = new System.Drawing.Point(790, 236);
            this.cboRiego.Name = "cboRiego";
            this.cboRiego.Size = new System.Drawing.Size(190, 25);
            this.cboRiego.TabIndex = 16;
            // 
            // lblFechaInstalacion
            // 
            this.lblFechaInstalacion.AutoSize = true;
            this.lblFechaInstalacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInstalacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblFechaInstalacion.Location = new System.Drawing.Point(638, 284);
            this.lblFechaInstalacion.Name = "lblFechaInstalacion";
            this.lblFechaInstalacion.Size = new System.Drawing.Size(136, 18);
            this.lblFechaInstalacion.TabIndex = 17;
            this.lblFechaInstalacion.Text = "Fecha de instalación";
            // 
            // dtpInstalacion
            // 
            this.dtpInstalacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInstalacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInstalacion.Location = new System.Drawing.Point(790, 280);
            this.dtpInstalacion.Name = "dtpInstalacion";
            this.dtpInstalacion.Size = new System.Drawing.Size(190, 25);
            this.dtpInstalacion.TabIndex = 18;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGuardar.Location = new System.Drawing.Point(640, 446);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 42);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnCancelar.Location = new System.Drawing.Point(820, 446);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 42);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FrmFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpInstalacion);
            this.Controls.Add(this.lblFechaInstalacion);
            this.Controls.Add(this.cboRiego);
            this.Controls.Add(this.lblRiego);
            this.Controls.Add(this.numSuperficie);
            this.Controls.Add(this.lblSuperficie);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboProyecto);
            this.Controls.Add(this.lblProyecto);
            this.Controls.Add(this.cboFamilia);
            this.Controls.Add(this.lblFamilia);
            this.Controls.Add(this.lblNuevaParcela);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.dgvFamilias);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblFamilias);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFamilias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huertos Sumaj Pacha - Familias y parcelas";
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            this.pnlSeparador.ResumeLayout(false);
            this.pnlSeparador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFamilias;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvFamilias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasComunidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamiliasMiembros;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Label lblNuevaParcela;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.ComboBox cboFamilia;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.ComboBox cboProyecto;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblSuperficie;
        private System.Windows.Forms.NumericUpDown numSuperficie;
        private System.Windows.Forms.Label lblRiego;
        private System.Windows.Forms.ComboBox cboRiego;
        private System.Windows.Forms.Label lblFechaInstalacion;
        private System.Windows.Forms.DateTimePicker dtpInstalacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
