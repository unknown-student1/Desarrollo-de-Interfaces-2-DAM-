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
    public partial class FormVentas : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormVentas()
        {
            InitializeComponent();

            // Cargar datos en el DataGridView
            CargarDatos();
        }

        public void AdaptarDataGrid()
        {
            // Ajustar el tamaño de todas las columnas al contenido
            foreach (DataGridViewColumn columna in dataGridViewVentas.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Luego, ajustar la última columna para que ocupe el espacio restante
            dataGridViewVentas.Columns[dataGridViewVentas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL con JOIN para obtener el nombre del cliente
                    string query = @"
                SELECT 
                    VENTAS.ID,
                    CLIENTES.NOMBRE AS Cliente,
                    VENTAS.FECHAVENTA,
                    VENTAS.TOTAL
                FROM 
                    VENTAS
                INNER JOIN 
                    CLIENTES ON VENTAS.CLIENTE = CLIENTES.ID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar los datos al DataGridView
                            dataGridViewVentas.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AdaptarDataGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FormVentaAdd AgregarVenta = new FormVentaAdd();
            AgregarVenta.ShowDialog();

            // Recargar DataGridView
            CargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVentas.SelectedRows.Count > 0)
            {
                // Guardar el codigo de la venta
                string codigoSeleccionado = dataGridViewVentas.SelectedRows[0].Cells["ID"].Value.ToString();

                // Cargamos el formulario
                FormVentaEdit EditarVenta = new FormVentaEdit(codigoSeleccionado);
                EditarVenta.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVentas.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar esta venta?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el ID de la venta
                    string codigoSeleccionado = dataGridViewVentas.SelectedRows[0].Cells["ID"].Value.ToString();

                    BorrarVenta(codigoSeleccionado);

                    // Recargar datos
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Método para borrar una venta
        private void BorrarVenta(string codigoCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteDetallesQuery = "DELETE FROM DETALLESVENTA WHERE IDVENTA = @CodigoVenta";
                string deleteVentaQuery = "DELETE FROM VENTAS WHERE ID = @CodigoVenta";

                try
                {
                    conexion.Open();

                    // Borrar los detalles de la venta
                    using (MySqlCommand deleteDetallesCmd = new MySqlCommand(deleteDetallesQuery, conexion))
                    {
                        deleteDetallesCmd.Parameters.AddWithValue("@CodigoVenta", codigoCliente);
                        deleteDetallesCmd.ExecuteNonQuery();
                    }

                    // Borrar venta 
                    using (MySqlCommand deleteVentaCmd = new MySqlCommand(deleteVentaQuery, conexion))
                    {
                        deleteVentaCmd.Parameters.AddWithValue("@CodigoVenta", codigoCliente);
                        deleteVentaCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Venta borrada exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la venta: {ex.Message}");
                }
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridViewVentas.SelectedRows.Count > 0)
            {
                    // Obtener el ID de la venta
                    string codigoSeleccionado = dataGridViewVentas.SelectedRows[0].Cells["ID"].Value.ToString();

                    FormDetalles DetallesVenta = new FormDetalles(codigoSeleccionado);
                    DetallesVenta.ShowDialog();

                    // Recargar datos
                    CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para ver los datalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
