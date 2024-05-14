using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBibilioteca.Ayudante;
using AppBibilioteca.Controlador;
using AppBibilioteca.Vista;

namespace AppBibilioteca
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ControladorUsuarios usuario = new ControladorUsuarios();
            ArrayList estaPresente = Acciones.ConvertirTablaDeDatos(usuario.RealizarConsultaTotal(ControladorUsuarios.consultarUsuario));
            MessageBox.Show(estaPresente[0].ToString());

            if (Convert.ToInt16(estaPresente[0]).Equals(0))
                Application.Run(new FrmPrimerUsuario());
            else
                Application.Run(new FrmLogin());

            //Application.Run(new tester());
        }
    }
}
