namespace SumajPacha.Presentacion
{
    partial class FrmVisitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblParcela = new System.Windows.Forms.Label();
            this.cboParcela = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEstadoParcela = new System.Windows.Forms.Label();
            this.cboEstadoParcela = new System.Windows.Forms.ComboBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblVisitaTecnica = new System.Windows.Forms.Label();
            this.dgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.colSeguimientoCultivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeguimientoEntregados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeguimientoVivas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeguimientoKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegla = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnGuardarVisita = new System.Windows.Forms.Button();
            this.pnlSeparador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).BeginInit();
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(231)))));
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblParcela.Location = new System.Drawing.Point(20, 22);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(59, 16);
            this.lblParcela.TabIndex = 0;
            this.lblParcela.Text = "PARCELA";
            // 
            // cboParcela
            // 
            this.cboParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParcela.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParcela.FormattingEnabled = true;
            this.cboParcela.Items.AddRange(new object[] {
            });
            this.cboParcela.Location = new System.Drawing.Point(20, 44);
            this.cboParcela.Name = "cboParcela";
            this.cboParcela.Size = new System.Drawing.Size(260, 25);
            this.cboParcela.TabIndex = 1;
            this.cboParcela.SelectedIndexChanged += new System.EventHandler(this.cboParcela_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblFecha.Location = new System.Drawing.Point(20, 88);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 16);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "FECHA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(20, 110);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(260, 25);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblEstadoParcela
            // 
            this.lblEstadoParcela.AutoSize = true;
            this.lblEstadoParcela.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoParcela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblEstadoParcela.Location = new System.Drawing.Point(20, 154);
            this.lblEstadoParcela.Name = "lblEstadoParcela";
            this.lblEstadoParcela.Size = new System.Drawing.Size(148, 16);
            this.lblEstadoParcela.TabIndex = 4;
            this.lblEstadoParcela.Text = "ESTADO DE LA PARCELA";
            // 
            // cboEstadoParcela
            // 
            this.cboEstadoParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoParcela.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstadoParcela.FormattingEnabled = true;
            this.cboEstadoParcela.Items.AddRange(new object[] {
            "Bueno",
            "Regular",
            "Malo"});
            this.cboEstadoParcela.Location = new System.Drawing.Point(20, 176);
            this.cboEstadoParcela.Name = "cboEstadoParcela";
            this.cboEstadoParcela.Size = new System.Drawing.Size(260, 25);
            this.cboEstadoParcela.TabIndex = 5;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblObservacion.Location = new System.Drawing.Point(20, 220);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(91, 16);
            this.lblObservacion.TabIndex = 6;
            this.lblObservacion.Text = "OBSERVACIÓN";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(20, 242);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(260, 110);
            this.txtObservacion.TabIndex = 7;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.pnlSeparador.Location = new System.Drawing.Point(304, 20);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(1, 450);
            this.pnlSeparador.TabIndex = 8;
            // 
            // lblVisitaTecnica
            // 
            this.lblVisitaTecnica.AutoSize = true;
            this.lblVisitaTecnica.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitaTecnica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(115)))), ((int)(((byte)(50)))));
            this.lblVisitaTecnica.Location = new System.Drawing.Point(325, 20);
            this.lblVisitaTecnica.Name = "lblVisitaTecnica";
            this.lblVisitaTecnica.Size = new System.Drawing.Size(122, 19);
            this.lblVisitaTecnica.TabIndex = 9;
            this.lblVisitaTecnica.Text = "VISITA TÉCNICA";
            // 
            // dgvSeguimiento
            // 
            this.dgvSeguimiento.AllowUserToAddRows = false;
            this.dgvSeguimiento.AllowUserToDeleteRows = false;
            this.dgvSeguimiento.AllowUserToResizeRows = false;
            this.dgvSeguimiento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeguimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeguimiento.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeguimiento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSeguimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeguimiento.ColumnHeadersHeight = 34;
            this.dgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSeguimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeguimientoCultivo,
            this.colSeguimientoEntregados,
            this.colSeguimientoVivas,
            this.colSeguimientoKg});
            this.dgvSeguimiento.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSeguimiento.EnableHeadersVisualStyles = false;
            this.dgvSeguimiento.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.dgvSeguimiento.Location = new System.Drawing.Point(325, 52);
            this.dgvSeguimiento.MultiSelect = false;
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.RowHeadersVisible = false;
            this.dgvSeguimiento.RowTemplate.Height = 40;
            this.dgvSeguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSeguimiento.Size = new System.Drawing.Size(655, 230);
            this.dgvSeguimiento.TabIndex = 10;
            this.dgvSeguimiento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeguimiento_CellEndEdit);
            // 
            // colSeguimientoCultivo
            // 
            this.colSeguimientoCultivo.FillWeight = 120F;
            this.colSeguimientoCultivo.HeaderText = "Cultivo";
            this.colSeguimientoCultivo.MinimumWidth = 6;
            this.colSeguimientoCultivo.Name = "colSeguimientoCultivo";
            this.colSeguimientoCultivo.ReadOnly = true;
            // 
            // colSeguimientoEntregados
            // 
            this.colSeguimientoEntregados.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSeguimientoEntregados.FillWeight = 150F;
            this.colSeguimientoEntregados.HeaderText = "Plantines entregados";
            this.colSeguimientoEntregados.MinimumWidth = 6;
            this.colSeguimientoEntregados.Name = "colSeguimientoEntregados";
            this.colSeguimientoEntregados.ReadOnly = true;
            // 
            // colSeguimientoVivas
            // 
            this.colSeguimientoVivas.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSeguimientoVivas.FillWeight = 120F;
            this.colSeguimientoVivas.HeaderText = "Plantas vivas";
            this.colSeguimientoVivas.MinimumWidth = 6;
            this.colSeguimientoVivas.Name = "colSeguimientoVivas";
            // 
            // colSeguimientoKg
            // 
            this.colSeguimientoKg.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSeguimientoKg.FillWeight = 120F;
            this.colSeguimientoKg.HeaderText = "Kg cosechados";
            this.colSeguimientoKg.MinimumWidth = 6;
            this.colSeguimientoKg.Name = "colSeguimientoKg";
            // 
            // lblRegla
            // 
            this.lblRegla.AutoSize = true;
            this.lblRegla.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(63)))), ((int)(((byte)(43)))));
            this.lblRegla.Location = new System.Drawing.Point(325, 292);
            this.lblRegla.Name = "lblRegla";
            this.lblRegla.Size = new System.Drawing.Size(401, 18);
            this.lblRegla.TabIndex = 11;
            this.lblRegla.Text = "Las plantas vivas no pueden superar los plantines entregados";
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblEstado.Location = new System.Drawing.Point(325, 330);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(655, 36);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Supervivencia de la parcela: se calcula al guardar la visita";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardarVisita
            // 
            this.btnGuardarVisita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnGuardarVisita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarVisita.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnGuardarVisita.FlatAppearance.BorderSize = 0;
            this.btnGuardarVisita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarVisita.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarVisita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGuardarVisita.Location = new System.Drawing.Point(780, 428);
            this.btnGuardarVisita.Name = "btnGuardarVisita";
            this.btnGuardarVisita.Size = new System.Drawing.Size(200, 46);
            this.btnGuardarVisita.TabIndex = 13;
            this.btnGuardarVisita.Text = "Guardar visita";
            this.btnGuardarVisita.UseVisualStyleBackColor = false;
            this.btnGuardarVisita.Click += new System.EventHandler(this.btnGuardarVisita_Click);
            // 
            // FrmVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.btnGuardarVisita);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblRegla);
            this.Controls.Add(this.dgvSeguimiento);
            this.Controls.Add(this.lblVisitaTecnica);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.cboEstadoParcela);
            this.Controls.Add(this.lblEstadoParcela);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cboParcela);
            this.Controls.Add(this.lblParcela);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVisitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huertos Sumaj Pacha - Visita técnica";
            this.Load += new System.EventHandler(this.FrmVisitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.pnlSeparador.ResumeLayout(false);
            this.pnlSeparador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.ComboBox cboParcela;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblEstadoParcela;
        private System.Windows.Forms.ComboBox cboEstadoParcela;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Label lblVisitaTecnica;
        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeguimientoCultivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeguimientoEntregados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeguimientoVivas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeguimientoKg;
        private System.Windows.Forms.Label lblRegla;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnGuardarVisita;
    }
}
