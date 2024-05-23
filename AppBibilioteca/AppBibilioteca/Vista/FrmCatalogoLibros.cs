using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo;
using AppBibilioteca.Modelo.Salidas;
using System;
using System.Collections;
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
    public partial class FrmCatalogoLibros : Form
    {
        public FrmCatalogoLibros()
        {
            InitializeComponent();
            flpLibros.AutoScroll = true;
        }

        private readonly ControladorLibros control = new ControladorLibros();
        private Panel panelTarjeta;

        private void PreReservarLibro(Int32 id)
        {
            CatalogoLibros libro = control.ObtenerUnLibroReserva(ControladorLibros.consultarUnLibroReserva, id);

            nudNumeroLibros.Maximum = libro.CantidadLibros;
            lblInicioPrestamo.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblFinPrestamo.Text = DateTime.Now.AddDays(15).ToString("dd-MM-yyyy");
            txtidLibro.Text = libro.ID.ToString();
            MessageBox.Show(libro.ID.ToString());
        }

        private void GenerarCartas(List<CatalogoLibros> listaLibros)
        {
            for (int i = 0; i < listaLibros.Count; i++)
            {
                int indice = i;

                panelTarjeta = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new System.Drawing.Size(200, 100)
                };

                Label texto = new Label
                {
                    Text = listaLibros[i].NombreLibro,
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

                if (listaLibros[i].Foto != null && listaLibros[i].Foto.Length > 1)
                {
                    using (MemoryStream stream = new MemoryStream(listaLibros[i].Foto))
                    {
                        MessageBox.Show(listaLibros[i].Foto.Length + " Iteration " + listaLibros[indice].ID);
                        Image image = Image.FromStream(stream);
                        imagen.Image = image;

                    }
                }
                panelTarjeta.Controls.Add(imagen);
                boton.Click += (s, evt) => PreReservarLibro(listaLibros[indice].ID);
                panelTarjeta.Controls.Add(boton);
                flpLibros.Controls.Add(panelTarjeta);
            }
        }

        private void InicializarLibros()
        {
            List<CatalogoLibros> listaLibros = control.ConvertirLibros(ControladorLibros.consultarLibrosIncial);
            GenerarCartas(listaLibros);
        }


        private void FrmCatalogoLibros_Load(object sender, EventArgs e)
        {
            InicializarLibros();
        }


        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Trim().Length.Equals(0))
            {
                List<CatalogoLibros> listaLibros = control.ConvertirLibros(ControladorLibros.consultarLibrosIncial);
                flpLibros.Controls.Clear();
                GenerarCartas(listaLibros);
            }
            else
            {
                List<CatalogoLibros> listaLibros = control.BuscarLibros(TxtBuscar.Text);
                flpLibros.Controls.Clear();
                GenerarCartas(listaLibros);
            }
        }

        private void BtnAcciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AccesoGlobal.ObtenerUsuarios().ConvertirEnCadena());
            ControladorPrestamos controlPrestamos = new ControladorPrestamos();
            controlPrestamos.RealizarPrestamo(new PrestamoLibro { IdLibro = Convert.ToInt32(txtidLibro.Text), IdUsuario = AccesoGlobal.ObtenerUsuarios().Id, Cantidad = Convert.ToInt32(nudNumeroLibros.Value), FechaPrestamo = lblInicioPrestamo.Text, FechaDevolucion = lblFinPrestamo.Text });
        }
    }
}
