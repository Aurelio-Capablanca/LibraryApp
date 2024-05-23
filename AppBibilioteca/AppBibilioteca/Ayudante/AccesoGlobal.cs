using AppBibilioteca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Ayudante
{
    internal class AccesoGlobal
    {

        private static Usuario usuarioSesion;

        public static Usuario ObtenerUsuarios() { 
            return usuarioSesion;
        }

        public static void DefinirUsuario(Usuario usuario) {
            usuarioSesion = usuario;
        }

    }
}
