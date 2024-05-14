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
        
        ControladorLibros control = new ControladorLibros();

        private void InicializarLibros()
        {
            List<CatalogoLibros> listaLibros = control.ConvertirLibros();
            foreach (CatalogoLibros subLista in listaLibros) 
            {
                MessageBox.Show(subLista.ID+" "+subLista.NombreLibro+" "+subLista.CantidadLibros);
            }

            for (int i = 0; i < listaLibros.Count; i++)
            {
                int indice = i;

                // Create a panel to represent a card
                Panel cardPanel = new Panel();
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Size = new System.Drawing.Size(200, 100);

                // Create a Label for card content
                Label label = new Label();
                label.Text = listaLibros[i].NombreLibro;
                label.Dock = DockStyle.Top; // Dock label to the top of the panel
                cardPanel.Controls.Add(label);

                // Create a Button for card content
                Button button = new Button();
                button.Text = "Click me";
                button.Dock = DockStyle.Bottom; // Dock button to the bottom of the panel
                button.Click += (s, evt) => MessageBox.Show("Button clicked on card " + listaLibros[indice].ID);
                cardPanel.Controls.Add(button);

                // Add the card panel to the FlowLayoutPanel
                flpLibros.Controls.Add(cardPanel);
            }
        }


        private void FrmCatalogoLibros_Load(object sender, EventArgs e)
        {
            InicializarLibros();
        }
    }
}
