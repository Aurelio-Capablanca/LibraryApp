using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo;
using AppBibilioteca.Modelo.Entradas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Controlador
{
    internal class SesionControlador : AccionesBaseDeDatos
    {
        public bool IniciarSesion(CrearSesion sesion) {            
            Usuario usuario = ConvertirUsuario(RealizarConsultaConParametros(new ArrayList { sesion.Usuario }, "Select * from Usuarios Where correoUsuario = @param1"));            
            if (usuario.EsUsuarioNulo()) {
                MessageBox.Show("Usuario Inexistente", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (usuario.Bloqueado.Equals(1)) {
                MessageBox.Show("Usuario Bloqueado", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Boolean verificarClave = BCrypt.Net.BCrypt.EnhancedVerify(sesion.Clave, usuario.Clave);
            if (verificarClave.Equals(true))
            {
                AccesoGlobal.DefinirUsuario(usuario);
                MessageBox.Show("Credenciales Correctas");
                return true;
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            

        }
    }
}
