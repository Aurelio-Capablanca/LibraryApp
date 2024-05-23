namespace AppBibilioteca.Vista
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.BtnUsuarios = new System.Windows.Forms.Button();
            this.BtnLibros = new System.Windows.Forms.Button();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(194, -1);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(606, 452);
            this.panelContenedor.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(52, 50);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(71, 13);
            this.lblLogo.TabIndex = 3;
            this.lblLogo.Text = "Here the logo";
            // 
            // BtnUsuarios
            // 
            this.BtnUsuarios.Location = new System.Drawing.Point(12, 120);
            this.BtnUsuarios.Name = "BtnUsuarios";
            this.BtnUsuarios.Size = new System.Drawing.Size(165, 58);
            this.BtnUsuarios.TabIndex = 4;
            this.BtnUsuarios.Text = "Usuarios";
            this.BtnUsuarios.UseVisualStyleBackColor = true;
            this.BtnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);
            // 
            // BtnLibros
            // 
            this.BtnLibros.Location = new System.Drawing.Point(12, 205);
            this.BtnLibros.Name = "BtnLibros";
            this.BtnLibros.Size = new System.Drawing.Size(165, 58);
            this.BtnLibros.TabIndex = 5;
            this.BtnLibros.Text = "Libros";
            this.BtnLibros.UseVisualStyleBackColor = true;
            this.BtnLibros.Click += new System.EventHandler(this.BtnLibros_Click);
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.Location = new System.Drawing.Point(12, 303);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(165, 58);
            this.BtnCatalogo.TabIndex = 6;
            this.BtnCatalogo.Text = "Catalogo de Libros";
            this.BtnCatalogo.UseVisualStyleBackColor = true;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(44, 403);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(102, 23);
            this.BtnCerrar.TabIndex = 7;
            this.BtnCerrar.Text = "Cerrar Sesion";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnCatalogo);
            this.Controls.Add(this.BtnLibros);
            this.Controls.Add(this.BtnUsuarios);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button BtnUsuarios;
        private System.Windows.Forms.Button BtnLibros;
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Button BtnCerrar;
    }
}