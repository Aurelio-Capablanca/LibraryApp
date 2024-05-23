namespace AppBibilioteca.Vista
{
    partial class FrmRetornoLibros
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
            this.SuspendLayout();
            // 
            // flpLibros
            // 
            this.flpLibros.Location = new System.Drawing.Point(12, 12);
            this.flpLibros.Name = "flpLibros";
            this.flpLibros.Size = new System.Drawing.Size(686, 426);
            this.flpLibros.TabIndex = 1;
            // 
            // FrmRetornoLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.flpLibros);
            this.Name = "FrmRetornoLibros";
            this.Text = "FrmRetornoLibros";
            this.Load += new System.EventHandler(this.FrmRetornoLibros_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpLibros;
    }
}