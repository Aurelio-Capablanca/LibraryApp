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

namespace AppBibilioteca.Controlador
{
    internal class ControladorLibros : AccionesBaseDeDatos
    {
        public const string consultarLibrosIncial = "select TOP 5  idLibro ,nombreLibro, cantidadLibros  from Libros lbr order by idLibro DESC ";

        public List<CatalogoLibros> ConvertirLibros() {
            List<CatalogoLibros> lista = new List<CatalogoLibros>();            
            try
            {
                SqlCommand ejecutar = new SqlCommand(consultarLibrosIncial, Conexion.Conexionsql());
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read()) 
                {
                    lista.Add(new CatalogoLibros(leer.GetInt32(0), leer.GetString(1) , leer.GetInt32(2)));
                }
                return lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador",
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
