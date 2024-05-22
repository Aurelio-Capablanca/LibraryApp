using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo.Salidas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBibilioteca.Modelo;

namespace AppBibilioteca.Controlador
{
    internal class ControladorLibros : AccionesBaseDeDatos
    {

        public const string consultarUnLibroReserva = "select idLibro, nombreLibro, cantidadLibros from Libros where idLibro = @param1";

        public const string consultarLibrosIncial = "select TOP 5  idLibro ,nombreLibro, cantidadLibros, foto  from Libros lbr order by idLibro DESC ";

        public const string consultarTodosLosLibros = "select idLibro as id, nombreLibro as nombre, ISBN as isbn, cantidadLibros as cantidad from Libros Order by idLibro DESC";

        public const string consultarUnLibroActualizar = "select idLibro as id, nombreLibro as nombre, ISBN as isbn, cantidadLibros as cantidad, foto as foto from Libros Where idLibro = @Param1";

        public const string consultarBusqueda = "select idLibro ,nombreLibro, cantidadLibros, foto from Libros lbr  Where CONTAINS(nombreLibro, @param1) order by idLibro DESC";

        public List<CatalogoLibros> ConvertirLibros(string consulta)
        {
            List<CatalogoLibros> lista = new List<CatalogoLibros>();
            try
            {
                SqlCommand ejecutar = new SqlCommand(consulta, Conexion.Conexionsql());
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    int idLibro = leer.GetInt32(0);
                    string nombreLibro = leer.GetString(1);
                    int cantidadLibros = leer.GetInt32(2);
                    byte[] foto = new byte[1] { 0 };
                    if (!leer.IsDBNull(3))
                    {
                        foto = (byte[])leer[3];
                    }

                    lista.Add(new CatalogoLibros(idLibro, nombreLibro, cantidadLibros, foto));
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador : " + ex.Message,
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<CatalogoLibros>();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

        public CatalogoLibros ObtenerUnLibroReserva(string consulta, int id)
        {
            CatalogoLibros lista = new CatalogoLibros();
            try
            {
                SqlCommand ejecutar = new SqlCommand(consulta, Conexion.Conexionsql());
                ejecutar.Parameters.Add(new SqlParameter("param1", id));
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    lista = new CatalogoLibros(leer.GetInt32(0), leer.GetString(1), leer.GetInt32(2));
                }
                return lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador",
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new CatalogoLibros();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

        public int GuardarLibro(Libros libro)
        {
            string accion = libro.Id.Equals(0) ? "Insertar" : "Actualizar";
            for (int i = 0; i < libro.estado.Count; i++)
            {
                if (libro.estado[i].Equals(0))
                {
                    MessageBox.Show("El Libro no se a podido " + accion, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    libro.estado.Clear();
                    return 0;
                }
            }
            return libro.Id.Equals(0) ?
                EjecutarAccion
                (
                    new ArrayList { libro.Nombre, libro.ISBN, libro.CantidadLibros, libro.Foto },
                    "Insert into Libros (nombreLibro, ISBN, cantidadLibros, foto) values (@param1, @param2, @param3, @param4)",
                    "Libro",
                    accion

                )
                :
                EjecutarAccion
                (
                    new ArrayList { libro.Nombre, libro.ISBN, libro.CantidadLibros, libro.Foto, libro.Id },
                    "Update Libros set nombreLibro = @param1, ISBN = @param2, cantidadLibros = @param3, foto = @param4 Where idLibro = @param5",
                    "Libro",
                    accion
                );

        }

        public Libros ObtenerUnLibro(int idLibro)
        {
            Libros libro = new Libros();
            byte[] foto = new byte[1] { 0 };
            try
            {
                SqlCommand ejecutar = new SqlCommand(consultarUnLibroActualizar, Conexion.Conexionsql());
                ejecutar.Parameters.Add(new SqlParameter("param1", idLibro));
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    if (!leer.IsDBNull(4))
                    {
                        foto = (byte[])leer[4];
                    }
                    libro = new Libros(leer.GetInt32(0), leer.GetString(1), leer.GetString(2), leer.GetInt32(3), foto);
                }
                return libro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador : " + ex.Message,
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new Libros();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

        public void BorrarLibro(int idLibros)
        {
            EjecutarAccion
                (
                new ArrayList { idLibros },
                "Delete from Libros Where idLibro = @param1",
                "Libros",
                "Borrar"
                );
        }

        public List<CatalogoLibros> BuscarLibros(string parametro) 
        {
            List<CatalogoLibros> lista = new List<CatalogoLibros>();
            try
            {
                SqlCommand ejecutar = new SqlCommand(consultarBusqueda, Conexion.Conexionsql());
                ejecutar.Parameters.Add(new SqlParameter("param1", parametro));
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    int idLibro = leer.GetInt32(0);
                    string nombreLibro = leer.GetString(1);
                    int cantidadLibros = leer.GetInt32(2);
                    byte[] foto = new byte[1] { 0 };
                    if (!leer.IsDBNull(3))
                    {
                        foto = (byte[])leer[3];
                    }

                    lista.Add(new CatalogoLibros(idLibro, nombreLibro, cantidadLibros, foto));
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador : " + ex.Message,
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<CatalogoLibros>();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

    }
}
