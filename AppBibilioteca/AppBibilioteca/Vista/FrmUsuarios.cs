using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Modelo;
using AppBibilioteca.Modelo.Salidas;
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
    public partial class FrmUsuarios : Form
    {

        private readonly ControladorUsuarios control = new ControladorUsuarios();
        private readonly Usuario usuario = new Usuario();

        private void CrearUsuario()
        {            
            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Correo = TxtCorreo.Text;
            usuario.TipoUsuario = Convert.ToInt16(CmbTipoUsuario.SelectedValue);
            usuario.Rol = Convert.ToInt16(CmbRol.SelectedValue);
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

        private void ActualizarUsuario() 
        {
            usuario.Id = Convert.ToInt32(txtID.Text);
            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Correo = TxtCorreo.Text;
            usuario.TipoUsuario = Convert.ToInt16(CmbTipoUsuario.SelectedValue);
            usuario.Rol = Convert.ToInt16(CmbRol.SelectedValue);
            control.GuardarUsuario(usuario);
        }

        private void MostrarUsuarios()
        {
            dgvUsuarios.DataSource = control.RealizarConsultaTotal(ControladorUsuarios.consultarTodosLosUsuarios);
        }

        public FrmUsuarios()
        {
            InitializeComponent();
            MostrarUsuarios();
            CmbTipoUsuario.DataSource = control.RealizarConsultaTotal(ControladorUsuarios.consultarTipo);
            CmbTipoUsuario.DisplayMember = "TipoUsuario";
            CmbTipoUsuario.ValueMember = "idTipoUsuarios";

            CmbRol.DataSource = control.RealizarConsultaTotal(ControladorUsuarios.consultarRol);
            CmbRol.DisplayMember = "RolUsuario";
            CmbRol.ValueMember = "idRol";
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            CrearUsuario();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lugar = dgvUsuarios.CurrentRow.Index;
            UsuarioRetorno obtenerUsuario = control.ObtenerUnUsuario(Validador.ValidarEnteros(this.dgvUsuarios[0, lugar].Value.ToString()));
            MessageBox.Show(obtenerUsuario.ConvertirEnCadena());

            txtID.Text = obtenerUsuario.ID.ToString();
            TxtNombre.Text = obtenerUsuario.Nombre;
            TxtApellido.Text = obtenerUsuario.Apellido;
            TxtCorreo.Text = obtenerUsuario.Correo;
            CmbTipoUsuario.SelectedValue = obtenerUsuario.TipoUsuario;
            CmbRol.SelectedValue = obtenerUsuario.Rol;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarUsuario();
        }
    }
}
