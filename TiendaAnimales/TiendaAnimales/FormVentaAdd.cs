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
    public partial class FormVentaAdd : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormVentaAdd()
        {
            InitializeComponent();

            // Cargar clientes en el comboBox
            CargarClientes();
        }

        // Método para cargar los clientes
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Llamar al método para guardar los datos
            GuardarVenta();

            //Cerrar el formulario
            this.Close();
        }

        // Método para guardar una transacción
        public void GuardarVenta()
        {
            // Insertar los datos en la base de datos
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open(); // Abrimos la conexión

                    int cliente = (int)cbxClientes.SelectedValue;
                    DateTime FechaVenta = dateTimePicker1.Value;
                    int total = 0;

                    string query = "INSERT INTO VENTAS (CLIENTE, FECHAVENTA, TOTAL) VALUES (@Cliente, @FechaVenta, @Total)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cliente", cliente);
                    command.Parameters.AddWithValue("@FechaVenta", FechaVenta);
                    command.Parameters.AddWithValue("@Total", total);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Venta insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La insercción de la venta ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }
}
