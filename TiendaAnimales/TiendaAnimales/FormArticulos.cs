using MySqlConnector;
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
    public partial class FormArticulos : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormArticulos()
        {
            InitializeComponent();

            // Cargar DataGridView
            CargarDatos();
        }

        public void AdaptarDataGrid()
        {
            // Ajustar el tamaño de todas las columnas al contenido
            foreach (DataGridViewColumn columna in dataGridViewArticulos.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Luego, ajustar la última columna para que ocupe el espacio restante
            dataGridViewArticulos.Columns[dataGridViewArticulos.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL con JOIN para obtener las familias
                    string query = @"
                SELECT 
                    ARTICULOS.ID,
                    ARTICULOS.DESCRIPCION,
                    ARTICULOS.PRECIO,
                    ARTICULOS.STOCK,
                    FAMILIAS.DESCRIPCION AS Familia
                FROM 
                    ARTICULOS
                INNER JOIN 
                    FAMILIAS ON ARTICULOS.FAMILIA = FAMILIAS.ID";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTableArticulos = new DataTable();
                        adapter.Fill(dataTableArticulos);

                        // Asignar los datos al DataGridView
                        dataGridViewArticulos.DataSource = dataTableArticulos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos desde la base de datos: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FormArticuloAdd AgregarArticulo = new FormArticuloAdd();
            AgregarArticulo.ShowDialog();

            // Recargar los datos del DataGridView
            CargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewArticulos.SelectedRows[0].Cells["ID"].Value.ToString();

                FormArticuloEdit EditarArticulo = new FormArticuloEdit(codigoSeleccionado);
                EditarArticulo.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un articulo para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar este articulo?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewArticulos.SelectedRows[0].Cells["ID"].Value.ToString();
                    BorrarArticulo(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista después de borrar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un articulo para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarArticulo(string codigoArticulo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteVentasQuery = "DELETE FROM ARTICULOS WHERE ID = @CodigoArticulo";

                try
                {
                    conexion.Open();

                    // Ejecutar la QUERY para borrar el articulo
                    using (MySqlCommand deleteVentasCmd = new MySqlCommand(deleteVentasQuery, conexion))
                    {
                        deleteVentasCmd.Parameters.AddWithValue("@CodigoArticulo", codigoArticulo);
                        deleteVentasCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Articulo borrado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el articulo: {ex.Message}");
                }
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text.Length != 0)
            {
                for (int i = 0; i < dataGridViewArticulos.Rows.Count; i++)
                {
                    string nombre = dataGridViewArticulos.Rows[i].Cells["Descripcion"].Value + " " + dataGridViewArticulos.Rows[i].Cells["Familia"].Value;
                    if (nombre.ToLower().Contains(txtBuscador.Text.ToLower()))
                    {
                        dataGridViewArticulos.Rows[i].Visible = true;
                    }
                    else if (!dataGridViewArticulos.Rows[i].IsNewRow)
                    {
                        dataGridViewArticulos.CurrentCell = null;
                        dataGridViewArticulos.Rows[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int n = 0; n < dataGridViewArticulos.Rows.Count; n++)

                {
                    dataGridViewArticulos.Rows[n].Visible = true;
                }

            }
        }
    }
}
