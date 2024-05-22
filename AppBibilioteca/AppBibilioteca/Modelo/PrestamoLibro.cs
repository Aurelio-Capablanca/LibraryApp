using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Modelo
{
    internal class PrestamoLibro
    {
        /*
idPrestamo int primary key identity,
idLibro int foreign key references Libros(idLibro),
idUsuario int foreign key references Usuarios(idUsuarios),
devolucion bit default 0
         */

        private int id;
        private int idLibro;
        private int idUsuario;
        private byte devolucion;
        private int cantidad;
        private string fechaPrestamo;
        private string fechaDevolucion;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdLibro 
        {
            get { return idLibro; }
            set { idLibro = value; }
        }

        public int IdUsuario 
        { 
            get { return idUsuario; } 
            set { idUsuario = value; }
        }

        public byte Devolucion 
        {
            get { return devolucion; }
            set { devolucion = value; }
        }

        public string FechaPrestamo 
        {
            get { return fechaPrestamo;}
            set { fechaPrestamo = value;}
        }

        public string FechaDevolucion 
        {
            get { return fechaDevolucion;}
            set { fechaDevolucion = value;}
        }

        public int Cantidad 
        {
            get { return cantidad; } 
            set { cantidad = value; }
        }
    }
}
