using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo.Salidas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Vista
{
    public partial class FrmRetornoLibros : Form
    {
        public FrmRetornoLibros()
        {
            InitializeComponent();
            flpLibros.AutoScroll = true;
        }

        private readonly ControladorLibros control = new ControladorLibros();
        private readonly ControladorPrestamos controlPrestamo = new ControladorPrestamos();
        private Panel panelTarjeta;

        private void GenerarCartas(List<RetornarLibros> listaLibros)
        {
            foreach (RetornarLibros libro in listaLibros)
            {
                RetornarLibros indice = libro;

                panelTarjeta = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new System.Drawing.Size(200, 100)
                };

                Label texto = new Label
                {
                    Text = libro.NombreLibro,
                    Dock = DockStyle.Top
                };
                panelTarjeta.Controls.Add(texto);

                Button boton = new Button
                {
                    Text = "Click me",
                    Dock = DockStyle.Bottom
                };

                PictureBox imagen = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (libro.Foto != null && libro.Foto.Length > 1)
                {
                    using (MemoryStream stream = new MemoryStream(libro.Foto))
                    {
                        //MessageBox.Show(libro.Foto.Length + " Iteration " + libro.IdLibro);
                        Image image = Image.FromStream(stream);
                        imagen.Image = image;

                    }
                }
                panelTarjeta.Controls.Add(imagen);
                boton.Click += (s, evt) => controlPrestamo.RegresarLibro(indice);
                panelTarjeta.Controls.Add(boton);
                flpLibros.Controls.Add(panelTarjeta);
            }
        }

        private void FrmRetornoLibros_Load(object sender, EventArgs e)
        {
            List<RetornarLibros> listaLibros = control.ConvertirLibrosPrestados(AccesoGlobal.ObtenerUsuarios().Id);
            GenerarCartas(listaLibros);
        }
    }
}
