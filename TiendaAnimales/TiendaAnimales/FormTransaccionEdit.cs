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
    public partial class FormTransaccionEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        // Variable para almacenar el ID de cliente
        private string codigoVenta;

        public FormTransaccionEdit(string codigoVenta)
        {
            InitializeComponent();

            // Establecer el codigo de venta
            this.codigoVenta = codigoVenta;

            // Cargamos los datos en el ComboBox
            CargarClientes();

            // Deshabilitar el campo cliente
            cbxClientes.Enabled = false;

            // Cargamos los datos de la venta
            CargarDatosVenta();
        }

        // Método para cargar 
        private void CargarClientes()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT id, CONCAT(nombre, ' ', apellidos) AS nombre_completo FROM CLIENTES";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxClientes.DataSource = dataTable;
                        cbxClientes.DisplayMember = "nombre_completo";
                        cbxClientes.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los clientes: {ex.Message}");
                }
            }
        }

        // Metodo para cargar los datos de la venta
        private void CargarDatosVenta()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM ventas WHERE id = @IDVenta";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IDventa", codigoVenta);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cbxClientes.SelectedValue = reader["cliente"];
                                dateTimePicker1.Value = Convert.ToDateTime(reader["fechaventa"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de la venta: {ex.Message}");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                // Llamar al método para guardar los datos
                GuardarTransaccion();

                //Cerrar el formulario
                this.Close();
        }

        // Método para guardar los datos modificados de la venta
        private void GuardarTransaccion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE ventas SET cliente = @Cliente, fechaventa = @FechaVenta WHERE id = @IDVenta";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cliente", cbxClientes.SelectedValue);
                        cmd.Parameters.AddWithValue("@FechaVenta", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@IDVenta", codigoVenta);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Venta actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en los datos de la venta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La modificación de la venta ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }
}
