using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Vista
{
    public partial class FrmLibro : Form
    {
        private readonly MemoryStream stream = new MemoryStream();
        private readonly ControladorLibros control = new ControladorLibros();

        private void CrearLibro()
        {
            pbFoto.Image.Save(stream, ImageFormat.Jpeg);
            control.GuardarLibro(new Libros { Nombre = txtNombre.Text, ISBN = txtISBN.Text, CantidadLibros = Convert.ToInt32(nudCantidad.Value), Foto = stream.ToArray() });
        }

        private void ActualizarLibro() 
        {
            pbFoto.Image.Save(stream, ImageFormat.Jpeg);
            control.GuardarLibro(new Libros {Id = Convert.ToInt32(txtID.Text), Nombre = txtNombre.Text, ISBN = txtISBN.Text, CantidadLibros = Convert.ToInt32(nudCantidad.Value), Foto = stream.ToArray() });
        }

        private void MostrarLibros()
        {
            dgvLibros.DataSource = control.RealizarConsultaTotal(ControladorLibros.consultarTodosLosLibros);
        }

        private void Limpiar() 
        {
            pbFoto.Image = null;
            txtNombre.Clear();
            txtISBN.Clear();
            nudCantidad.Value = 1;
        }

        public FrmLibro()
        {
            InitializeComponent();
            txtID.Visible = false;
            MostrarLibros();
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

       
        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearLibro();
            MostrarLibros();
            Limpiar();
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lugar = dgvLibros.CurrentRow.Index;
            Libros libro = control.ObtenerUnLibro(Validador.ValidarEnteros(this.dgvLibros[0, lugar].Value.ToString()));

            txtID.Text = libro.Id.ToString();
            txtNombre.Text = libro.Nombre;
            txtISBN.Text = libro.ISBN;
            nudCantidad.Value = libro.CantidadLibros;
            if (libro.Foto != null && libro.Foto.Length > 1)
            {
                using (MemoryStream stream = new MemoryStream(libro.Foto))
                {
                    Image image = Image.FromStream(stream);
                    pbFoto.Image = image;

                }
            }
            else 
            {
                pbFoto.Image = null;
            }

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarLibro();            
            MostrarLibros();
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            control.BorrarLibro(Convert.ToInt32(txtID.Text));
            MostrarLibros();
            Limpiar();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
