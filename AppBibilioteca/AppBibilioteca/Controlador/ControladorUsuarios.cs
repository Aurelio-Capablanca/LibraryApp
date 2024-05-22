using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo;
using AppBibilioteca.Modelo.Salidas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Controlador
{
    internal class ControladorUsuarios : AccionesBaseDeDatos
    {

        public const string consultarUsuario = "SELECT count(idUsuarios) FROM Usuarios";

        public const string consultarTipo = "SELECT * FROM TipoUsuarios tu";

        public const string consultarRol = "SELECT * FROM Roles r Where r.idRol < 4";

        public const string consultarTodosLosUsuarios = "select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario, us.correoUsuario, CASE when us.bloqueado = 0 then 'No' When us.bloqueado = 1 then 'Si' else 'Indeterminado' end as bloqueo from Usuarios us Inner join TipoUsuarios tu on idTipoUsuarios = us.idTipoUsuario  inner join Roles r  on r.idRol = us.idRol";

        public int GuardarUsuario(Usuario usuario)
        {
            string accion = usuario.Id.Equals(0) ? "Insertar" : "Actualizar";
            for (int i = 0; i < usuario.estado.Count; i++)
            {
                if (usuario.estado[i].Equals(0))
                {
                    MessageBox.Show("El Usuario no se a podido " + accion, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usuario.estado.Clear();
                    return 0;
                }
            }
            return usuario.Id.Equals(0) ?
                EjecutarAccion
                (
                new ArrayList { usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.Clave, false, usuario.TipoUsuario, usuario.Rol },
                "insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol) values (@param1, @param2, @param3, @param4, @param5, @param6, @param7)",
                "Usuario",
                accion
                )
                :
                EjecutarAccion
                (
                    new ArrayList { usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.TipoUsuario, usuario.Rol, usuario.Id },
                    "update Usuarios set nombreUsuario = @param1, apellidoUsuario = @param2, correoUsuario = @param3, idTipoUsuario = @param4, idRol = @param5 where idUsuarios = @param6",
                    "Usuario",
                    accion
                );
        }


        public UsuarioRetorno ObtenerUnUsuario(int idUsuario)
        {
            UsuarioRetorno objeto = new UsuarioRetorno();
            try
            {
                SqlCommand ejecutar = new SqlCommand("select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario , us.correoUsuario, us.idTipoUsuario, us.idRol  from Usuarios us Where us.idUsuarios = @param1", Conexion.Conexionsql());
                ejecutar.Parameters.Add(new SqlParameter("param1", idUsuario));
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    objeto = new UsuarioRetorno(leer.GetInt32(0), leer.GetString(1), leer.GetString(2), leer.GetString(3), leer.GetInt32(4), leer.GetInt32(5));
                }
                return objeto;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador",
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new UsuarioRetorno();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }


        public void EliminarUsuario(int idUsuario) 
        {            
            EjecutarAccion
               (
               new ArrayList { idUsuario },
               "Delete From Usuarios Where idUsuarios = @param1",
               "Usuario",
               "Borrar"
               );
        }



    }
}
