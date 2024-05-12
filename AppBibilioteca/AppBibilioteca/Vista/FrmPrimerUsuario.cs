using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo;
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
    public partial class FrmPrimerUsuario : Form
    {
        public FrmPrimerUsuario()
        {
            InitializeComponent();
        }

        private void FrmPrimerUsuario_Load(object sender, EventArgs e)
        {
            //ControladorUsuarios controlador = new ControladorUsuarios();            
            //CmbTipoUsuario.DataSource = controlador.RealizarConsultaTotal(ControladorUsuarios.consultarTipo);
            //CmbTipoUsuario.DisplayMember = "TipoUsuario";
            //CmbTipoUsuario.ValueMember = "idTipoUsuarios";

            //CmbRol.DataSource = controlador.RealizarConsultaTotal(ControladorUsuarios.consultarRol);
            //CmbRol.DisplayMember = "RolUsuario";
            //CmbRol.ValueMember = "idRol";
            CmbRol.Hide();
            CmbTipoUsuario.Hide();

        }


        private void CrearPrimerUsuario() {
            ControladorUsuarios control = new ControladorUsuarios();
            Usuario usuario = new Usuario();
            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Correo = TxtCorreo.Text;

            usuario.TipoUsuario = 1;//Convert.ToInt16(CmbTipoUsuario.SelectedValue);
            usuario.Rol = 1;//Convert.ToInt16(CmbRol.SelectedValue);
            if (TxtClave.Text.Equals(TxtConfirmar.Text))
            {               
                usuario.Clave = BCrypt.Net.BCrypt.EnhancedHashPassword(TxtClave.Text, 13);
            }
            else 
            {
                MessageBox.Show("Las Claves deben ser iguales", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            control.InsertarUsuario(usuario);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearPrimerUsuario();
        }
    }
}
