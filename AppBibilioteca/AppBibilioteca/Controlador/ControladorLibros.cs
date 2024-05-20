﻿using AppBibilioteca.Ayudante;
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
        public const string consultarLibrosIncial = "select TOP 5  idLibro ,nombreLibro, cantidadLibros  from Libros lbr order by idLibro DESC ";

        public const string consultarUnLibro = "select idLibro, nombreLibro, cantidadLibros from Libros where idLibro = @param1";

        public List<CatalogoLibros> ConvertirLibros(string consulta)
        {
            List<CatalogoLibros> lista = new List<CatalogoLibros>();
            try
            {
                SqlCommand ejecutar = new SqlCommand(consulta, Conexion.Conexionsql());
                SqlDataReader leer = ejecutar.ExecuteReader();
                while (leer.Read())
                {
                    lista.Add(new CatalogoLibros(leer.GetInt32(0), leer.GetString(1), leer.GetInt32(2)));
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

        public CatalogoLibros ObtenerUnLibro(string consulta, int id)
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
                    MessageBox.Show("El Usuario no se a podido " + accion, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    libro.estado.Clear();
                    return 0;
                }
            }
            return libro.Id.Equals(0) ?
                EjecutarAccion
                (
                    new ArrayList { },
                    "Insert into Libros (nombreLibro, ISBN, cantidadLibros, foto) values (@param1, @param2, @param3, @param4)"
                )
                :
                EjecutarAccion
                (
                    new ArrayList { },
                    ""
                );

        }



    }
}
