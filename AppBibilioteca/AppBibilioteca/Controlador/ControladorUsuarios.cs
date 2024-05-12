using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Controlador
{
    internal class ControladorUsuarios : Acciones
    {

        public const string consultarUsuario = "SELECT count(idUsuarios) FROM Usuarios";

        public const string consultarTipo = "SELECT * FROM TipoUsuarios tu";

        public const string consultarRol = "SELECT * FROM Roles r";        

        public int InsertarUsuario(Usuario usuario)
        {
            int retorno = 0;
            for (int i = 0; i < usuario.estado.Count; i++) 
            {
                if (usuario.estado[i].Equals(0)) 
                {
                    MessageBox.Show("El usuario no se a podido ingresar***", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usuario.estado.Clear();
                    return 0;
                }
            }

            try
            {
                SqlCommand queryIngresar = new SqlCommand(string.Format(
                    "insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.Clave, false, usuario.TipoUsuario, usuario.Rol),
                    Conexion.Conexionsql());                
                retorno = Convert.ToInt32(queryIngresar.ExecuteNonQuery());
                if (retorno >= 1)
                    MessageBox.Show("El usuario se ingreso de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El usuario no se a podido ingresar", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion :  " + ex, "Error critico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return retorno;
            }
            return retorno;
        }        

    }
}
