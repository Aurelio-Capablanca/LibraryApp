using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Modelo.Entradas
{
    internal class CrearSesion
    {

        private string usuario;
        private string clave;


        public CrearSesion() 
        { 
        }

        public CrearSesion(string usuario, string clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        public string Usuario 
        { 
            get { return usuario; }
            set { usuario = value; }
        }

        public string Clave 
        { 
            get { return clave; }
            set { clave = value; }
        }

    }
}
