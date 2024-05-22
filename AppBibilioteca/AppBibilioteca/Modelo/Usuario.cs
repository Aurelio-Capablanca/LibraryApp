using AppBibilioteca.Ayudante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
idUsuarios int primary key identity,
nombreUsuario varchar(25) not null,
apellidoUsuario varchar(25) not null,
correoUsuario varchar(30) not null,
claveUsuario varchar(100) not null,
bloqueado bit,
idTipoUsuario int foreign key references TipoUsuarios(idTipoUsuarios)
*/

namespace AppBibilioteca.Modelo
{

    internal class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private string clave;
        private byte bloqueado;
        private int tipoUsuario;
        private int rol;

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string correo, string clave, byte bloqueado, int tipoUsuario, int rol)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.clave = clave;
            this.bloqueado = bloqueado;
            this.tipoUsuario = tipoUsuario;
            this.rol = rol;
        }

        private readonly Validador validar = new Validador();
        public List<Int16> estado = new List<Int16>();


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int TipoUsuario
        {
            get { return tipoUsuario; }
            set
            {
                if (value > 0)
                {
                    tipoUsuario = value;
                    estado.Add(1);
                }
                else
                {
                    MessageBox.Show("No se pueden ingresar numeros negativos para el tipo de Usuario ", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
            }
        }

        public int Rol
        {
            get { return rol; }
            set
            {
                if (value > 0)
                {
                    rol = value;
                    estado.Add(1);
                }
                else
                {
                    MessageBox.Show("No se pueden ingresar numeros negativos para el Rol", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!validar.ValidarAlfabeticos(value, 30, false))
                {
                    MessageBox.Show(string.Format("{0} Error en el Nombre", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    nombre = value;
                    estado.Add(1);
                }
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (!validar.ValidarAlfabeticos(value, 30, false))
                {
                    MessageBox.Show(string.Format("{0} Error en el Apellido", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    apellido = value;
                    estado.Add(1);
                }
            }
        }

        public string Correo
        {
            get { return correo; }
            set
            {
                if (!validar.ValidarCorreos(value, 45, false))
                {
                    MessageBox.Show(string.Format("{0} Error en el Correo", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    correo = value;
                    estado.Add(1);
                }
            }
        }

        public string Clave
        {
            get { return clave; }
            set
            {
                if (!validar.ValidarAlfanumericosConCaracteres(value, 100, false))
                {
                    MessageBox.Show(string.Format("{0} Error en la Clave", validar.Mensaje), "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    estado.Add(0);
                }
                else
                {
                    clave = value;
                    estado.Add(1);
                }
            }
        }

        public byte Bloqueado
        {
            get { return bloqueado; }
            set { bloqueado = value; }
        }

        public String ConvertirEnCadena()
        {
            return string.Format(
                "Usuario[ID:({0}), Nombre:({1}), Apellido:({2}), Correo:({3}), Clave:({4}), Bloqueado:({5}), TipoUsuario:({6}), Rol:({7})]",
                this.id,
                this.nombre,
                this.apellido,
                this.correo,
                this.clave,
                this.bloqueado,
                this.TipoUsuario,
                this.Rol);
        }

        public bool EsUsuarioNulo() 
        {
            return this.nombre == null;
        }
    }
}
