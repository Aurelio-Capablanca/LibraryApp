namespace AppBibilioteca.Vista
{
    partial class FrmLibrosPendientes
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
            this.dgvLibrosPrestados = new System.Windows.Forms.DataGridView();
            this.dgvLibrosVencidos = new System.Windows.Forms.DataGridView();
            this.grpPendientes = new System.Windows.Forms.GroupBox();
            this.grpVencidos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibrosPrestados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibrosVencidos)).BeginInit();
            this.grpPendientes.SuspendLayout();
            this.grpVencidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLibrosPrestados
            // 
            this.dgvLibrosPrestados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibrosPrestados.Location = new System.Drawing.Point(39, 19);
            this.dgvLibrosPrestados.Name = "dgvLibrosPrestados";
            this.dgvLibrosPrestados.Size = new System.Drawing.Size(586, 159);
            this.dgvLibrosPrestados.TabIndex = 0;
            // 
            // dgvLibrosVencidos
            // 
            this.dgvLibrosVencidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibrosVencidos.Location = new System.Drawing.Point(39, 19);
            this.dgvLibrosVencidos.Name = "dgvLibrosVencidos";
            this.dgvLibrosVencidos.Size = new System.Drawing.Size(586, 150);
            this.dgvLibrosVencidos.TabIndex = 1;
            // 
            // grpPendientes
            // 
            this.grpPendientes.Controls.Add(this.dgvLibrosPrestados);
            this.grpPendientes.Location = new System.Drawing.Point(30, 21);
            this.grpPendientes.Name = "grpPendientes";
            this.grpPendientes.Size = new System.Drawing.Size(657, 199);
            this.grpPendientes.TabIndex = 2;
            this.grpPendientes.TabStop = false;
            this.grpPendientes.Text = "Libros Pendientes";
            // 
            // grpVencidos
            // 
            this.grpVencidos.Controls.Add(this.dgvLibrosVencidos);
            this.grpVencidos.Location = new System.Drawing.Point(30, 226);
            this.grpVencidos.Name = "grpVencidos";
            this.grpVencidos.Size = new System.Drawing.Size(657, 188);
            this.grpVencidos.TabIndex = 3;
            this.grpVencidos.TabStop = false;
            this.grpVencidos.Text = "Libros Vencidos";
            // 
            // FrmLibrosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 426);
            this.Controls.Add(this.grpVencidos);
            this.Controls.Add(this.grpPendientes);
            this.Name = "FrmLibrosPendientes";
            this.Text = "FrmLibrosPendientes";
            this.Load += new System.EventHandler(this.FrmLibrosPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibrosPrestados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibrosVencidos)).EndInit();
            this.grpPendientes.ResumeLayout(false);
            this.grpVencidos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLibrosPrestados;
        private System.Windows.Forms.DataGridView dgvLibrosVencidos;
        private System.Windows.Forms.GroupBox grpPendientes;
        private System.Windows.Forms.GroupBox grpVencidos;
    }
}