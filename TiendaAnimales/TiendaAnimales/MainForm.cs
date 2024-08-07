using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaAnimales
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Establecemos la cadena de conexion
            Conexion.EstablecerCadenaConexion("127.0.0.1", "tiendamascotas", "root", "root");
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes Clientes = new FormClientes();
            Clientes.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArticulos Articulos = new FormArticulos();
            Articulos.ShowDialog();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas Ventas = new FormVentas();
            Ventas.ShowDialog();
        }
    }
}
