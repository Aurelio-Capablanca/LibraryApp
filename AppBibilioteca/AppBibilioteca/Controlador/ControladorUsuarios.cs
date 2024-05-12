using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo;
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
    internal class ControladorUsuarios : Acciones
    {

        public const string consultarUsuario = "SELECT count(idUsuarios) FROM Usuarios";

        public const string consultarTipo = "SELECT * FROM TipoUsuarios tu";

        public const string consultarRol = "SELECT * FROM Roles r";

        public const string consultarTodosLosUsuarios = "select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario, us.correoUsuario, CASE when us.bloqueado = 0 then 'No' When us.bloqueado = 1 then 'Si' else 'Indeterminado' end as bloqueo from Usuarios us Inner join TipoUsuarios tu on idTipoUsuarios = us.idTipoUsuario  inner join Roles r  on r.idRol = us.idRol";

        public int InsertarUsuario(Usuario usuario)
        {            
            for (int i = 0; i < usuario.estado.Count; i++) 
            {
                if (usuario.estado[i].Equals(0)) 
                {
                    MessageBox.Show("El usuario no se a podido ingresar***", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usuario.estado.Clear();
                    return 0;
                }
            } 
            return EjecutarAccion(
                new ArrayList { usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.Clave, false, usuario.TipoUsuario, usuario.Rol },
                "insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol) values (@param1, @param2, @param3, @param4, @param5, @param6, @param7)"
                );
        }
        



    }
}
