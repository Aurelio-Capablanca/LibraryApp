using AppBibilioteca.Modelo;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Ayudante
{
    internal class Acciones : AccionesBaseDeDatos
    {
        public static void ImprimirTablaDeDatos(DataTable tabla)
        {
            String columna = "";
            String fila = "";

            foreach (DataColumn column in tabla.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
                columna += column.ColumnName;
            }
            Console.WriteLine();
            // Print data rows
            foreach (DataRow row in tabla.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item}\t");
                    fila += item.ToString();
                }
                Console.WriteLine();
            }
            MessageBox.Show(columna + " " + fila);
        }

        public static ArrayList ConvertirTablaDeDatos(DataTable tabla)
        {
            ArrayList lista = new ArrayList();
            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    lista.Add(row[0].ToString());
                }
            }
            return lista;
        }
        

        public Usuario ConvertirUsuario(DataTable table)
        {
            Usuario usuario = new Usuario();
            foreach (DataRow columna in table.Rows)
            {
                usuario = new Usuario(Convert.ToInt16(columna["IdUsuarios"]),
                   Convert.ToString(columna["nombreUsuario"]),
                   Convert.ToString(columna["apellidoUsuario"]),
                   Convert.ToString(columna["correoUsuario"]),
                   Convert.ToString(columna["claveUsuario"]),
                   Convert.ToByte(columna["bloqueado"]),
                   Convert.ToInt16(columna["idTipoUsuario"]),
                   Convert.ToInt16(columna["idRol"]));
            }
            return usuario;
        }


        public Boolean EsNulo(object valor)
        {
            return valor == null;
        }

    }
}
