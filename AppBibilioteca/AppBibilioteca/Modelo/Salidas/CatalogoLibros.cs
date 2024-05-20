using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Modelo.Salidas
{
    internal class CatalogoLibros
    {
        private int id;
        private string nombreLibro;
        private int cantidadLibros;

        public CatalogoLibros() 
        { }

        public CatalogoLibros(int id, string nombreLibro, int cantidadLibros) { 
            this.id = id;
            this.nombreLibro = nombreLibro;
            this.cantidadLibros = cantidadLibros;
        }

        public int ID 
        { 
            get { return id; } 
            //set { id = value; }
        }

        public string NombreLibro { get { return nombreLibro; } }

        public int CantidadLibros { get {  return cantidadLibros; } }
    }
}
