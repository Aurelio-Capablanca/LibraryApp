using AppBibilioteca.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Vista
{
    public partial class FrmLibrosPendientes : Form
    {

        private readonly ControladorLibros control = new ControladorLibros();

        private void MostrarLibrosPendientes()
        {
            dgvLibrosPrestados.DataSource = control.RealizarConsultaTotal(ControladorLibros.consultarLibrosPrestadosTodos);
        }

        private void MostrarLibrosVencidos()
        {
            dgvLibrosVencidos.DataSource = control.RealizarConsultaTotal(ControladorLibros.consultarLibrosVencidosTodos);
        }

        public FrmLibrosPendientes()
        {
            InitializeComponent();
            MostrarLibrosPendientes();
            MostrarLibrosVencidos();
        }        

        private void FrmLibrosPendientes_Load(object sender, EventArgs e)
        {

        }
    }
}
