using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaClase
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();

            // Establecemos la cadena de conexion
            Conexion.EstablecerCadenaConexion("127.0.0.1", "instituto", "root", "root");
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlumnos alumnos = new FormAlumnos();
            alumnos.ShowDialog();

        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignatura asignaturas = new FormAsignatura();
            asignaturas.ShowDialog();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstadisticas estadisticas = new FormEstadisticas();
            estadisticas.ShowDialog();
        }

        private void listadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListado FormularioListados = new FormListado();
            FormularioListados.ShowDialog();
        }
    }
}
