namespace Sumaj_Pacha
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            lblRol = new Label();
            cboRol = new ComboBox();
            btnIngresar = new Button();
            lnkOlvide = new LinkLabel();
            picLogo = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(74, 110, 42);
            lblTitulo.Location = new Point(15, 123);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(666, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Huertos Sumaj Pacha";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(60, 258);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(79, 28);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(210, 252);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(426, 34);
            txtUsuario.TabIndex = 2;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(60, 325);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(110, 28);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña\t";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(210, 320);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(426, 34);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(60, 393);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(40, 28);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol";
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FormattingEnabled = true;
            cboRol.Items.AddRange(new object[] { "Administrador ", "Técnico de campo", "Consulta" });
            cboRol.Location = new Point(210, 387);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(426, 36);
            cboRol.TabIndex = 6;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(74, 110, 42);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(210, 462);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(345, 60);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // lnkOlvide
            // 
            lnkOlvide.LinkColor = Color.FromArgb(74, 110, 42);
            lnkOlvide.Location = new Point(210, 537);
            lnkOlvide.Name = "lnkOlvide";
            lnkOlvide.Size = new Size(345, 33);
            lnkOlvide.TabIndex = 8;
            lnkOlvide.TabStop = true;
            lnkOlvide.Text = "¿Olvidaste tu contraseña?";
            lnkOlvide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(306, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(84, 84);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(15, 183);
            label1.Name = "label1";
            label1.Size = new Size(666, 33);
            label1.TabIndex = 10;
            label1.Text = "ONG Yachay Chhalaku - Sacaba, Cochabamba";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 243, 232);
            ClientSize = new Size(698, 649);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Controls.Add(lnkOlvide);
            Controls.Add(btnIngresar);
            Controls.Add(cboRol);
            Controls.Add(lblRol);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(10, 25);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Huertos Sumaj Pacha ";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Label lblRol;
        private ComboBox cboRol;
        private Button btnIngresar;
        private LinkLabel lnkOlvide;
        private PictureBox picLogo;
        private Label label1;
    }
}
