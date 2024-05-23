using AppBibilioteca.Controlador;
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
    public partial class FrmPanelExternos : Form
    {
        public FrmPanelExternos()
        {
            InitializeComponent();
        }

        Form currentForm;
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                if (currentForm != null)
                {
                    currentForm.Close();
                    panelContenedor.Controls.Remove(currentForm);
                }
                currentForm = formulario;
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmCatalogoLibros>();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmRetornoLibros>();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            SesionControlador sesion = new SesionControlador();
            sesion.CerrarSesion();
            FrmLogin login = new FrmLogin();
            this.Hide();
            login.Show();
        }
    }
}
