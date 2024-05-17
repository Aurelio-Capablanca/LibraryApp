namespace AppBibilioteca.Vista
{
    partial class FrmCatalogoLibros
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
            this.flpLibros = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.pPrestamo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFinPrestamo = new System.Windows.Forms.Label();
            this.lblInicioPrestamo = new System.Windows.Forms.Label();
            this.BtnAcciones = new System.Windows.Forms.Button();
            this.nudNumeroLibros = new System.Windows.Forms.NumericUpDown();
            this.pPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // flpLibros
            // 
            this.flpLibros.Location = new System.Drawing.Point(12, 76);
            this.flpLibros.Name = "flpLibros";
            this.flpLibros.Size = new System.Drawing.Size(449, 347);
            this.flpLibros.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(23, 37);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(79, 29);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(337, 20);
            this.TxtBuscar.TabIndex = 2;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // pPrestamo
            // 
            this.pPrestamo.Controls.Add(this.label1);
            this.pPrestamo.Controls.Add(this.lblFinPrestamo);
            this.pPrestamo.Controls.Add(this.lblInicioPrestamo);
            this.pPrestamo.Controls.Add(this.BtnAcciones);
            this.pPrestamo.Controls.Add(this.nudNumeroLibros);
            this.pPrestamo.Location = new System.Drawing.Point(484, 29);
            this.pPrestamo.Name = "pPrestamo";
            this.pPrestamo.Size = new System.Drawing.Size(280, 394);
            this.pPrestamo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // lblFinPrestamo
            // 
            this.lblFinPrestamo.AutoSize = true;
            this.lblFinPrestamo.Location = new System.Drawing.Point(151, 183);
            this.lblFinPrestamo.Name = "lblFinPrestamo";
            this.lblFinPrestamo.Size = new System.Drawing.Size(68, 13);
            this.lblFinPrestamo.TabIndex = 3;
            this.lblFinPrestamo.Text = "Fin Prestamo";
            // 
            // lblInicioPrestamo
            // 
            this.lblInicioPrestamo.AutoSize = true;
            this.lblInicioPrestamo.Location = new System.Drawing.Point(20, 183);
            this.lblInicioPrestamo.Name = "lblInicioPrestamo";
            this.lblInicioPrestamo.Size = new System.Drawing.Size(79, 13);
            this.lblInicioPrestamo.TabIndex = 2;
            this.lblInicioPrestamo.Text = "Inicio Prestamo";
            // 
            // BtnAcciones
            // 
            this.BtnAcciones.Location = new System.Drawing.Point(46, 277);
            this.BtnAcciones.Name = "BtnAcciones";
            this.BtnAcciones.Size = new System.Drawing.Size(173, 58);
            this.BtnAcciones.TabIndex = 1;
            this.BtnAcciones.Text = "Texto";
            this.BtnAcciones.UseVisualStyleBackColor = true;
            // 
            // nudNumeroLibros
            // 
            this.nudNumeroLibros.Location = new System.Drawing.Point(23, 95);
            this.nudNumeroLibros.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroLibros.Name = "nudNumeroLibros";
            this.nudNumeroLibros.Size = new System.Drawing.Size(219, 20);
            this.nudNumeroLibros.TabIndex = 0;
            this.nudNumeroLibros.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmCatalogoLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pPrestamo);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.flpLibros);
            this.Name = "FrmCatalogoLibros";
            this.Text = "FrmCatalogoLibros";
            this.Load += new System.EventHandler(this.FrmCatalogoLibros_Load);
            this.pPrestamo.ResumeLayout(false);
            this.pPrestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpLibros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Panel pPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFinPrestamo;
        private System.Windows.Forms.Label lblInicioPrestamo;
        private System.Windows.Forms.Button BtnAcciones;
        private System.Windows.Forms.NumericUpDown nudNumeroLibros;
    }
}