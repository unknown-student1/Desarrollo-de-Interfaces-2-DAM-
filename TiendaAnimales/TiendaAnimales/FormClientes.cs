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
    public partial class FormClientes : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormClientes()
        {
            InitializeComponent();

            // Cargar DataGridView
            CargarDatos();

            // Ajustar DataGridView
            AdaptarDataGrid();
        }

        public void AdaptarDataGrid()
        {
            // Ajustar el tamaño de todas las columnas al contenido
            foreach (DataGridViewColumn columna in dataGridViewClientes.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Luego, ajustar la última columna para que ocupe el espacio restante
            dataGridViewClientes.Columns[dataGridViewClientes.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL con JOIN para obtener nombres de provincia y municipio
                    string query = @"
                    SELECT 
                        CLIENTES.ID,
                        CLIENTES.NOMBRE,
                        CLIENTES.APELLIDOS,
                        CLIENTES.TELEFONO,
                        CLIENTES.CORREO,
                        PROVINCIAS.PROVINCIA AS PROVINCIA,
                        MUNICIPIOS.MUNICIPIO AS MUNICIPIO
                    FROM CLIENTES
                    INNER JOIN PROVINCIAS ON CLIENTES.PROVINCIA = PROVINCIAS.ID
                    INNER JOIN MUNICIPIOS ON CLIENTES.MUNICIPIO = MUNICIPIOS.ID";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTableClientes = new DataTable();
                        adapter.Fill(dataTableClientes);

                        // Asignar los datos al DataGridView
                        dataGridViewClientes.DataSource = dataTableClientes;
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
            using (FormClienteAdd AgregarCliente= new FormClienteAdd())
            {
                if (AgregarCliente.ShowDialog() == DialogResult.OK)
                {

                    // Obtener los datos del formulario FormAlumnoAdd
                    string nombre = AgregarCliente.Nombre;
                    string apellidos = AgregarCliente.Apellidos;
                    string correo = AgregarCliente.Correo;
                    string phone = AgregarCliente.Phone;
                    int provinciaId = AgregarCliente.ProvinciaId;
                    long municipioId = AgregarCliente.MunicipioId;

                    // Insertar los datos en la base de datos
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                        {
                            connection.Open();
                            string query = "INSERT INTO clientes (nombre, apellidos, telefono, correo, provincia, municipio) VALUES (@nombre, @apellidos, @telefono, @correo, @provincia, @municipio)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@nombre", nombre);
                            command.Parameters.AddWithValue("@apellidos", apellidos);
                            command.Parameters.AddWithValue("@telefono", phone);
                            command.Parameters.AddWithValue("@correo", correo);
                            command.Parameters.AddWithValue("@provincia", provinciaId);
                            command.Parameters.AddWithValue("@municipio", municipioId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Cliente insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Recargar datos del DataGrid
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar Cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La inserción del cliente ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewClientes.SelectedRows[0].Cells["ID"].Value.ToString();

                FormClienteEdit EditarCliente = new FormClienteEdit(codigoSeleccionado);
                EditarCliente.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un alumno para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar a este cliente?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewClientes.SelectedRows[0].Cells["ID"].Value.ToString();
                    BorrarCliente(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista después de borrar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarCliente(string codigoCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteVentasQuery = "DELETE FROM VENTAS WHERE CLIENTE = @CodigoCliente";
                string deleteClienteQuery = "DELETE FROM CLIENTES WHERE ID = @CodigoCliente";

                try
                {
                    conexion.Open();

                    // Borrar las compras de ese cliente
                    using (MySqlCommand deleteVentasCmd = new MySqlCommand(deleteVentasQuery, conexion))
                    {
                        deleteVentasCmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                        deleteVentasCmd.ExecuteNonQuery();
                    }

                    // Borrar al cliente
                    using (MySqlCommand deleteClienteCmd = new MySqlCommand(deleteClienteQuery, conexion))
                    {
                        deleteClienteCmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);
                        deleteClienteCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente borrado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el cliente: {ex.Message}");
                }
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewClientes.SelectedRows[0].Cells["ID"].Value.ToString();


                FormTransacciones TransaccionesForm = new FormTransacciones(codigoSeleccionado);
                TransaccionesForm.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
