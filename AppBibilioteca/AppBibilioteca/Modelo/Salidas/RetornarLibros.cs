using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Modelo.Salidas
{
    internal class RetornarLibros
    {
        private int idPrestamo;
        private int idLibro;
        private string nombreLibro;
        private int cantidadLibros;
        private byte[] foto;

        public RetornarLibros(int idPrestamo, int idLibro, string nombreLibro, int cantidadLibros, byte[] foto)
        {
            this.idPrestamo = idPrestamo;
            this.idLibro = idLibro;
            this.nombreLibro = nombreLibro;
            this.cantidadLibros = cantidadLibros;
            this.foto = foto;
        }        

        public int IdPrestamo
        {
            get { return idPrestamo; }
            set { idPrestamo = value; }
        }

        public int IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public string NombreLibro { get { return nombreLibro; } }

        public int CantidadLibros { get { return cantidadLibros; } }
    }
}
