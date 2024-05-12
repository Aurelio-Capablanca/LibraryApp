using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo.Entradas;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //SesionControlador sesion = new SesionControlador();
            //sesion.IniciarSesion(new CrearSesion("test@mail.com","123"));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SesionControlador sesion = new SesionControlador();
            bool verificar = sesion.IniciarSesion(new CrearSesion(TxtCorreo.Text, TxtClave.Text));
            if (verificar.Equals(true))
            {
                MessageBox.Show(AccesoGlobal.ObtenerUsuarios().ConvertirEnCadena());
                this.Hide();
                FrmMenuPrincipal principal = new FrmMenuPrincipal();
                principal.Show();
            }
        }
    }
}
