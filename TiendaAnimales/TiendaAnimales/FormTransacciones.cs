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
    public partial class FormTransacciones : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        // Variable para almacenar el ID de cliente
        private string codigoCliente;

        public FormTransacciones(string codigoCliente)
        {
            InitializeComponent();

            // Establecer el codigo de cliente
            this.codigoCliente = codigoCliente;

            // Cargamos los datos en el ComboBox
            CargarDatos();
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para obtener las ventas con el nombre del cliente
                    string query = @"
                        SELECT v.ID, c.NOMBRE AS CLIENTE, v.FECHAVENTA, v.TOTAL
                        FROM VENTAS v
                        JOIN CLIENTES c ON v.CLIENTE = c.ID
                        WHERE v.CLIENTE = @CodigoCliente";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoCliente", codigoCliente);

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
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FormTransaccionAdd AgregarTransaccion = new FormTransaccionAdd(codigoCliente);
            AgregarTransaccion.ShowDialog();

            // Recargar datos
            CargarDatos();
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
                    
                    BorrarTransaccion(codigoSeleccionado);

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
        private void BorrarTransaccion(string codigoCliente)
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
                    MessageBox.Show($"Error al borrar el detalle de la venta: {ex.Message}");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVentas.SelectedRows.Count > 0)
            {
                // Guardar el codigo de la venta
                string codigoSeleccionado = dataGridViewVentas.SelectedRows[0].Cells["ID"].Value.ToString();

                // Cargamos el formulario
                FormTransaccionEdit EditarTransaccion = new FormTransaccionEdit(codigoSeleccionado);
                EditarTransaccion.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
