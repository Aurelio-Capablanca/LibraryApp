using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Modelo.Salidas
{
    internal class UsuarioRetorno
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private int tipoUsuario;
        private int rol;

        public UsuarioRetorno(int id, string nombre, string apellido, string correo, int tipoUsuario, int rol) 
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.tipoUsuario = tipoUsuario;
            this.rol = rol;
        }

        public UsuarioRetorno() 
        {
        }

        public int ID
        {
            get{ return id; }
        }

        public string Nombre 
        {
            get { return nombre; }
        }

        public string Apellido 
        {
            get { return apellido; }
        }

        public string Correo 
        {
            get { return correo; }
        }

        public int TipoUsuario
        {
            get { return tipoUsuario; }
        }

        public int Rol 
        { 
            get { return rol; }
        }

        public string ConvertirEnCadena() 
        {
            return string.Format(
                "Usuario[ID:({0}), Nombre:({1}), Apellido:({2}), Correo:({3}), TipoUsuario:({4}), Rol:({5})]",
                this.id,
                this.nombre,
                this.apellido,
                this.correo,
                this.tipoUsuario,
                this.rol);
        }

    }
}
