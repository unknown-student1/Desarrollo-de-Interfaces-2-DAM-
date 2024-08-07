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
    public partial class FormDetalles : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        // Variable para almacenar el ID de cliente
        private string codigoVenta;

        public FormDetalles(string codigoVenta)
        {
            InitializeComponent();

            // Establecer el codigo de venta
            this.codigoVenta = codigoVenta;

            // Cargar ComboBox
            CargarDatos();

            // Recargar Total
            MostrarTotal();
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para obtener los detalles de la venta
                    string query = @"
                        SELECT dv.ID, dv.IDVENTA, a.DESCRIPCION AS PRODUCTO, dv.CANTIDAD, a.PRECIO, 
                               (dv.CANTIDAD * a.PRECIO) AS SUBTOTAL
                        FROM DETALLESVENTA dv
                        JOIN ARTICULOS a ON dv.IDPRODUCTO = a.ID
                        WHERE dv.IDVENTA = @CodigoVenta";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoVenta", codigoVenta);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar los datos al DataGridView
                            dataGridViewDetalles.DataSource = dataTable;
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
            FormDetalleAdd AgregarDetalles = new FormDetalleAdd(codigoVenta);
            AgregarDetalles.ShowDialog();

            // Recargar los datos del DataGridView
            CargarDatos();

            // Recargar Total
            MostrarTotal();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetalles.SelectedRows.Count > 0)
            {
                // Guardar el codigo de la venta
                string codigoSeleccionado = dataGridViewDetalles.SelectedRows[0].Cells["ID"].Value.ToString();

                // Cargamos el formulario
                FormDetalleEdit EditarDetalle = new FormDetalleEdit(codigoSeleccionado);
                EditarDetalle.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();

                // Recargar Total
                MostrarTotal();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un detalle para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetalles.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar este detalle de la venta?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el ID de la venta
                    string codigoSeleccionado = dataGridViewDetalles.SelectedRows[0].Cells["ID"].Value.ToString();

                    BorrarDetalle(codigoSeleccionado);

                    // Recargar datos
                    CargarDatos();

                    // Recargar Total
                    MostrarTotal();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para borrar el detalle de una venta
        private void BorrarDetalle(string codigoDetalle)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteDetallesQuery = "DELETE FROM DETALLESVENTA WHERE ID = @CodigoDetalle";

                try
                {
                    conexion.Open();

                    // Borrar los detalles de la venta
                    using (MySqlCommand deleteDetallesCmd = new MySqlCommand(deleteDetallesQuery, conexion))
                    {
                        deleteDetallesCmd.Parameters.AddWithValue("@CodigoDetalle", codigoDetalle);
                        deleteDetallesCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Detalle de venta borrado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el detalle de la venta: {ex.Message}");
                }
            }
        }

        // Metodo para cargar los datos en el DataGridView y el total en el TextBox
        private void MostrarTotal()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para obtener las notas del alumno seleccionado
                    string queryTotal = "SELECT TOTAL FROM VENTAS WHERE ID = @CodigoVenta";

                    using (MySqlCommand command = new MySqlCommand(queryTotal, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoVenta", codigoVenta);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            object result = command.ExecuteScalar();

                            // Asignar el total al TextBox
                            if (result != DBNull.Value)
                            {
                                decimal totalVenta = Convert.ToDecimal(result);
                                txtTotal.Text = totalVenta.ToString("C2"); // Formato de moneda
                            }
                            else
                            {
                                txtTotal.Text = "0.00"; // Si no hay ventas, mostrar 0.00
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
