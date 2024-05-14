using AppBibilioteca.Ayudante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Modelo
{

    /*
     idLibro int IDENTITY(1,1) NOT NULL,
	nombreLibro varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ISBN varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	cantidadLibros int DEFAULT 0 NULL,
     */

    internal class Libros
    {
        private int id;
        private string nombreLibro;
        private string isbn;
        private int cantidadLibros;

        public Libros() { }

        public Libros(int id, string nombreLibro, string isbn, int cantidaLibros)
        {
            this.id = id;
            this.nombreLibro = nombreLibro;
            this.isbn = isbn;
            this.cantidadLibros = cantidaLibros;
        }


        private readonly Validador validar = new Validador();
        public List<Int16> estado = new List<Int16>();


        public int Id { 
            get { return id; }
            set { id = value; }
        }

        public int CantidadLibros
        {
            get { return cantidadLibros; }
            set
            {
                if (value > 0)
                {
                    cantidadLibros = value;
                    estado.Add(1);
                }
                else
                {
                    MessageBox.Show("No se pueden ingresar numeros negativos para la cantidad de libros ", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
            }
        }

        public string Nombre
        {
            get { return nombreLibro; }
            set
            {
                if (!validar.ValidarAlfabeticos(value, 30, false))
                {
                    MessageBox.Show(string.Format("{0} Error en el Nombre", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    nombreLibro = value;
                    estado.Add(1);
                }
            }
        }

        public string ISBN
        {
            get { return isbn; }
            set
            {
                if (!validar.ValidarAlfabeticos(value, 30, false))
                {
                    MessageBox.Show(string.Format("{0} Error en el Nombre", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    isbn = value;
                    estado.Add(1);
                }
            }
        }

        public String ConvertirEnCadena() 
        {
            return string.Format("Libro[ ID:({0}) , nombre:({1}), ISBN:({2}), cantidadLibros:({3}) ]",
                this.id,
                this.nombreLibro,
                this.cantidadLibros);
        }
    }
}
