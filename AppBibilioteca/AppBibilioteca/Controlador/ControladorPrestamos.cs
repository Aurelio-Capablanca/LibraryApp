using AppBibilioteca.Ayudante;
using AppBibilioteca.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBibilioteca.Controlador
{
    internal class ControladorPrestamos : AccionesBaseDeDatos
    {
        /*Insert the loaned book*/

        public void RealizarPrestamo(PrestamoLibro prestamo)
        {
            EjecutarAccion
                (
                new ArrayList {prestamo.IdLibro, prestamo.IdUsuario, false, prestamo.FechaPrestamo, prestamo.FechaDevolucion},
                "Insert into PrestamoLibros (idLibro, idUsuario, devolucion, fechaprestamo, fechadevolucion) values (@param1, @param2, @param3, CONVERT(date, @param4, 105), CONVERT(date, @param5, 105))"
                );
            /*Execute other action for update the book Stock*/
        }

    }
}
