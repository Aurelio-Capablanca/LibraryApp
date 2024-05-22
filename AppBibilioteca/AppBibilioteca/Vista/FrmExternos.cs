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
    public partial class FrmExternos : Form
    {
        public FrmExternos()
        {
            InitializeComponent();
        }

        private void CrearPerfil()
        {
            ControladorUsuarios control = new ControladorUsuarios();
            Usuario usuario = new Usuario();
            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Correo = TxtCorreo.Text;
            usuario.TipoUsuario = 2;
            usuario.Rol = 4;
            if (TxtClave.Text.Equals(TxtConfirmar.Text))
            {
                usuario.Clave = BCrypt.Net.BCrypt.EnhancedHashPassword(TxtClave.Text, 13);
            }
            else
            {
                MessageBox.Show("Las Claves deben ser iguales", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            control.GuardarUsuario(usuario);
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearPerfil();
            FrmMenuPrincipal login = new FrmMenuPrincipal();
            login.Show();
            this.Hide();
        }
    }
}
