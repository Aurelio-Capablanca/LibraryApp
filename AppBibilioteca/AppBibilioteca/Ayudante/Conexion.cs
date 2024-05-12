using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Ayudante
{
    internal class Conexion
    {

        public static SqlConnection Conexionsql() {
            SqlConnection conexion;
            string servidor = "localhost";
            string puerto = "1433";
            string baseDeDatos = "dbBiblioteca";
            string usuario = "sa";
            string clave = "#!954feae8sss";
            try
            {
                string instruccion = $"Server={servidor},{puerto};Database={baseDeDatos};User Id={usuario};Password={clave};";
                conexion = new SqlConnection(instruccion);
                conexion.Open();
                //MessageBox.Show("Conectado");
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico de conexión: " + ex, "Fallo de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
                return new SqlConnection();
            }
            
        }

    }
}
