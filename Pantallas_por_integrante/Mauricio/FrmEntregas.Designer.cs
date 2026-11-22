namespace Sumaj_Pacha
{
    partial class FrmEntregas
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
            this.pnlNuevaEntrega = new System.Windows.Forms.Panel();
            this.lblNuevaEntrega = new System.Windows.Forms.Label();
            this.lblParcela = new System.Windows.Forms.Label();
            this.cboParcela = new System.Windows.Forms.ComboBox();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.btnRegistrarEntrega = new System.Windows.Forms.Button();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.dgvEntregas = new System.Windows.Forms.DataGridView();
            this.colEntregasFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregasAnular = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNotaAnular = new System.Windows.Forms.Label();
            this.pnlNuevaEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).BeginInit();
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
            // pnlNuevaEntrega
            // 
            this.pnlNuevaEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.pnlNuevaEntrega.Controls.Add(this.lblNuevaEntrega);
            this.pnlNuevaEntrega.Location = new System.Drawing.Point(0, 0);
            this.pnlNuevaEntrega.Name = "pnlNuevaEntrega";
            this.pnlNuevaEntrega.Size = new System.Drawing.Size(1000, 38);
            this.pnlNuevaEntrega.TabIndex = 0;
            // 
            // lblNuevaEntrega
            // 
            this.lblNuevaEntrega.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblNuevaEntrega.Location = new System.Drawing.Point(16, 0);
            this.lblNuevaEntrega.Name = "lblNuevaEntrega";
            this.lblNuevaEntrega.Size = new System.Drawing.Size(400, 38);
            this.lblNuevaEntrega.TabIndex = 0;
            this.lblNuevaEntrega.Text = "Nueva entrega de insumos";
            this.lblNuevaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblParcela.Location = new System.Drawing.Point(20, 52);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(52, 18);
            this.lblParcela.TabIndex = 1;
            this.lblParcela.Text = "Parcela";
            // 
            // cboParcela
            // 
            this.cboParcela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParcela.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParcela.FormattingEnabled = true;
            this.cboParcela.Items.AddRange(new object[] {
            });
            this.cboParcela.Location = new System.Drawing.Point(20, 76);
            this.cboParcela.Name = "cboParcela";
            this.cboParcela.Size = new System.Drawing.Size(215, 25);
            this.cboParcela.TabIndex = 2;
            // 
            // lblInsumo
            // 
            this.lblInsumo.AutoSize = true;
            this.lblInsumo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsumo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblInsumo.Location = new System.Drawing.Point(250, 52);
            this.lblInsumo.Name = "lblInsumo";
            this.lblInsumo.Size = new System.Drawing.Size(51, 18);
            this.lblInsumo.TabIndex = 3;
            this.lblInsumo.Text = "Insumo";
            // 
            // cboInsumo
            // 
            this.cboInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsumo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInsumo.FormattingEnabled = true;
            this.cboInsumo.Items.AddRange(new object[] {
            "Plantines de brócoli",
            "Plantines de coliflor",
            "Plantines de repollo",
            "Plantines de lechuga",
            "Abono orgánico"});
            this.cboInsumo.Location = new System.Drawing.Point(250, 76);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(215, 25);
            this.cboInsumo.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblCantidad.Location = new System.Drawing.Point(480, 52);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 18);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCantidad.Location = new System.Drawing.Point(480, 76);
            this.numCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(95, 25);
            this.numCantidad.TabIndex = 6;
            this.numCantidad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblUnidad.Location = new System.Drawing.Point(590, 52);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(50, 18);
            this.lblUnidad.TabIndex = 7;
            this.lblUnidad.Text = "Unidad";
            // 
            // cboUnidad
            // 
            this.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Items.AddRange(new object[] {
            "plantines",
            "kg"});
            this.cboUnidad.Location = new System.Drawing.Point(590, 76);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(115, 25);
            this.cboUnidad.TabIndex = 8;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblFecha.Location = new System.Drawing.Point(720, 52);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(42, 18);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(720, 76);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 25);
            this.dtpFecha.TabIndex = 10;
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.lblTecnico.Location = new System.Drawing.Point(855, 52);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(54, 18);
            this.lblTecnico.TabIndex = 11;
            this.lblTecnico.Text = "Técnico";
            // 
            // txtTecnico
            // 
            this.txtTecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtTecnico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTecnico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.txtTecnico.Location = new System.Drawing.Point(855, 76);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.ReadOnly = true;
            this.txtTecnico.Size = new System.Drawing.Size(125, 27);
            this.txtTecnico.TabIndex = 12;
            this.txtTecnico.Text = "Automático";
            // 
            // btnRegistrarEntrega
            // 
            this.btnRegistrarEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnRegistrarEntrega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarEntrega.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.btnRegistrarEntrega.FlatAppearance.BorderSize = 0;
            this.btnRegistrarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEntrega.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRegistrarEntrega.Location = new System.Drawing.Point(790, 118);
            this.btnRegistrarEntrega.Name = "btnRegistrarEntrega";
            this.btnRegistrarEntrega.Size = new System.Drawing.Size(190, 40);
            this.btnRegistrarEntrega.TabIndex = 13;
            this.btnRegistrarEntrega.Text = "Registrar entrega";
            this.btnRegistrarEntrega.UseVisualStyleBackColor = false;
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(112)))), ((int)(((byte)(45)))));
            this.pnlHistorial.Controls.Add(this.lblHistorial);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 176);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1000, 38);
            this.pnlHistorial.TabIndex = 14;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHistorial.Location = new System.Drawing.Point(16, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(400, 38);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "Historial de entregas";
            this.lblHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEntregas
            // 
            this.dgvEntregas.AllowUserToAddRows = false;
            this.dgvEntregas.AllowUserToDeleteRows = false;
            this.dgvEntregas.AllowUserToResizeRows = false;
            this.dgvEntregas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntregas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntregas.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntregas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEntregas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEntregas.ColumnHeadersHeight = 34;
            this.dgvEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEntregas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntregasFecha,
            this.colEntregasParcela,
            this.colEntregasInsumo,
            this.colEntregasCantidad,
            this.colEntregasTecnico,
            this.colEntregasEstado,
            this.colEntregasAnular});
            this.dgvEntregas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEntregas.EnableHeadersVisualStyles = false;
            this.dgvEntregas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.dgvEntregas.Location = new System.Drawing.Point(20, 228);
            this.dgvEntregas.MultiSelect = false;
            this.dgvEntregas.Name = "dgvEntregas";
            this.dgvEntregas.ReadOnly = true;
            this.dgvEntregas.RowHeadersVisible = false;
            this.dgvEntregas.RowTemplate.Height = 30;
            this.dgvEntregas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntregas.Size = new System.Drawing.Size(960, 280);
            this.dgvEntregas.TabIndex = 15;
            // 
            // colEntregasFecha
            // 
            this.colEntregasFecha.FillWeight = 90F;
            this.colEntregasFecha.HeaderText = "Fecha";
            this.colEntregasFecha.MinimumWidth = 6;
            this.colEntregasFecha.Name = "colEntregasFecha";
            // 
            // colEntregasParcela
            // 
            this.colEntregasParcela.FillWeight = 160F;
            this.colEntregasParcela.HeaderText = "Parcela";
            this.colEntregasParcela.MinimumWidth = 6;
            this.colEntregasParcela.Name = "colEntregasParcela";
            // 
            // colEntregasInsumo
            // 
            this.colEntregasInsumo.FillWeight = 170F;
            this.colEntregasInsumo.HeaderText = "Insumo";
            this.colEntregasInsumo.MinimumWidth = 6;
            this.colEntregasInsumo.Name = "colEntregasInsumo";
            // 
            // colEntregasCantidad
            // 
            this.colEntregasCantidad.FillWeight = 110F;
            this.colEntregasCantidad.HeaderText = "Cantidad";
            this.colEntregasCantidad.MinimumWidth = 6;
            this.colEntregasCantidad.Name = "colEntregasCantidad";
            // 
            // colEntregasTecnico
            // 
            this.colEntregasTecnico.FillWeight = 120F;
            this.colEntregasTecnico.HeaderText = "Técnico";
            this.colEntregasTecnico.MinimumWidth = 6;
            this.colEntregasTecnico.Name = "colEntregasTecnico";
            // 
            // colEntregasEstado
            // 
            this.colEntregasEstado.FillWeight = 90F;
            this.colEntregasEstado.HeaderText = "Estado";
            this.colEntregasEstado.MinimumWidth = 6;
            this.colEntregasEstado.Name = "colEntregasEstado";
            // 
            // colEntregasAnular
            // 
            this.colEntregasAnular.FillWeight = 90F;
            this.colEntregasAnular.HeaderText = "Acción";
            this.colEntregasAnular.MinimumWidth = 6;
            this.colEntregasAnular.Name = "colEntregasAnular";
            this.colEntregasAnular.Text = "Anular";
            this.colEntregasAnular.UseColumnTextForButtonValue = true;
            // 
            // lblNotaAnular
            // 
            this.lblNotaAnular.AutoSize = true;
            this.lblNotaAnular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaAnular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblNotaAnular.Location = new System.Drawing.Point(20, 520);
            this.lblNotaAnular.Name = "lblNotaAnular";
            this.lblNotaAnular.Size = new System.Drawing.Size(460, 16);
            this.lblNotaAnular.TabIndex = 16;
            this.lblNotaAnular.Text = "Solo la directora puede anular una entrega; las entregas anuladas no se borran.";
            // 
            // FrmEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.lblNotaAnular);
            this.Controls.Add(this.dgvEntregas);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.btnRegistrarEntrega);
            this.Controls.Add(this.txtTecnico);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cboUnidad);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.cboInsumo);
            this.Controls.Add(this.lblInsumo);
            this.Controls.Add(this.cboParcela);
            this.Controls.Add(this.lblParcela);
            this.Controls.Add(this.pnlNuevaEntrega);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huertos Sumaj Pacha - Entregas de insumos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.pnlNuevaEntrega.ResumeLayout(false);
            this.pnlNuevaEntrega.PerformLayout();
            this.pnlHistorial.ResumeLayout(false);
            this.pnlHistorial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNuevaEntrega;
        private System.Windows.Forms.Label lblNuevaEntrega;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.ComboBox cboParcela;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.TextBox txtTecnico;
        private System.Windows.Forms.Button btnRegistrarEntrega;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvEntregas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregasEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEntregasAnular;
        private System.Windows.Forms.Label lblNotaAnular;
    }
}
