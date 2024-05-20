using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Vista
{
    public partial class FrmLibro : Form
    {
        public FrmLibro()
        {
            InitializeComponent();
        }

        private void btnExaminarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OfdCargarImagen.Filter = "Archivo de Imagen (.jpg) |*.jpg | Archivos de Imagen (.png) |*.png | Archivo de Imagen (.jpeg) |*.jpeg | Todos los archivos |*.*";
                DialogResult resultado = OfdCargarImagen.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                   pbFoto.Image = Image.FromFile(OfdCargarImagen.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Opps! Ha ocurrido un error al crgar la imagen", "Error Wey", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
