using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenPeriodico
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            // Establecemos la cadena de conexion
            Conexion.EstablecerCadenaConexion("127.0.0.1", "periodico", "root", "root");
        }

        private void publicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPublicaciones publicaciones = new FormPublicaciones();
            publicaciones.ShowDialog();
        }

        private void seccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSecciones secciones = new FormSecciones();
            secciones.ShowDialog();
        }
    }
}
