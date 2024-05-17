using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo.Salidas;
using System;
using System.Collections;
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
    public partial class FrmCatalogoLibros : Form
    {
        public FrmCatalogoLibros()
        {
            InitializeComponent();
            flpLibros.AutoScroll = true;
        }
        
        private readonly ControladorLibros control = new ControladorLibros();

        private void InicializarLibros()
        {
            List<CatalogoLibros> listaLibros = control.ConvertirLibros();
            //foreach (CatalogoLibros subLista in listaLibros) 
            //{
            //    MessageBox.Show(subLista.ID+" "+subLista.NombreLibro+" "+subLista.CantidadLibros);
            //}

            for (int i = 0; i < listaLibros.Count; i++)
            {
                int indice = i;

                // Create a panel to represent a card
                Panel panelTarjeta = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new System.Drawing.Size(200, 100)
                };

                // Create a Label for card content
                Label texto = new Label
                {
                    Text = listaLibros[i].NombreLibro,
                    Dock = DockStyle.Top
                };
                panelTarjeta.Controls.Add(texto);

                // Create a Button for card content
                Button boton = new Button
                {
                    Text = "Click me",
                    Dock = DockStyle.Bottom // Dock button to the bottom of the panel
                };
                boton.Click += (s, evt) => MessageBox.Show("Button clicked on card " + listaLibros[indice].ID);
                panelTarjeta.Controls.Add(boton);

                // Add the card panel to the FlowLayoutPanel
                flpLibros.Controls.Add(panelTarjeta);
            }
        }


        private void FrmCatalogoLibros_Load(object sender, EventArgs e)
        {
            InicializarLibros();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
