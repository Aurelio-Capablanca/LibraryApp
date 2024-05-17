using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppBibilioteca.Modelo;

namespace AppBibilioteca.Ayudante
{
    internal class AccionesBaseDeDatos : Acciones
    {

        public DataTable RealizarConsultaTotal(string query)
        {
            DataTable retorno;
            try
            {
                SqlCommand ejecutar = new SqlCommand(query, Conexion.Conexionsql());
                SqlDataAdapter adaptar = new SqlDataAdapter(ejecutar);
                retorno = new DataTable();
                adaptar.Fill(retorno);
                //ImprimirTablaDeDatos(retorno);
                return retorno;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador",
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

        protected DataTable RealizarConsultaConParametros(ArrayList parametros, string query)
        {
            DataTable retorno;
            try
            {
                SqlCommand consultaParametrizada = new SqlCommand(query, Conexion.Conexionsql());
                for (int i = 0; i < parametros.Count; i++)
                {
                    consultaParametrizada.Parameters.Add(new SqlParameter("param" + (i + 1), parametros[i]));
                }
                SqlDataAdapter adaptar = new SqlDataAdapter(consultaParametrizada);
                retorno = new DataTable();
                adaptar.Fill(retorno);
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la obtencion de datos, consulte con su administrador" + ex.Message,
                "Error Critico de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }
            finally
            {
                Conexion.Conexionsql().Close();
            }
        }

        protected int EjecutarAccion(ArrayList parametros, string query) 
        {
            int retorno = 0;
            try
            {
                SqlCommand consultaEjecutar = new SqlCommand(query, Conexion.Conexionsql());
                for (int i = 0; i < parametros.Count; i++)
                {
                    consultaEjecutar.Parameters.Add(new SqlParameter("param" + (i + 1), parametros[i]));
                }
                retorno = Convert.ToInt32(consultaEjecutar.ExecuteNonQuery());
                if (retorno >= 1)
                    MessageBox.Show("El usuario se ingreso de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El usuario no se a podido ingresar", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion :  " + ex, "Error critico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return retorno;
            }
            return retorno;
        }

    }
}
