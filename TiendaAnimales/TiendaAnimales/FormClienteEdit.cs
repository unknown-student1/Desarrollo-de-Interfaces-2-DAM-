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
    public partial class FormClienteEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;
        // Variable para almacenar el ID de cliente
        private string codigoCliente;

        public FormClienteEdit(string codigoCliente)
        {
            InitializeComponent();
            
            // Establecer el codigo de cliente
            this.codigoCliente = codigoCliente;

            // Cargamos los datos en el ComboBox
            CargarProvincias();

            // Cargarmos datos cliente
            CargarDatosCliente();

            // Deshabilitar el ComboBox (Municipio)
            cbxMunicipio.Enabled = false;

        }

        // Metodo para cargar los datos del cliente en el formulario
        private void CargarDatosCliente()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM clientes WHERE ID = @ID";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ID", codigoCliente);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellidos.Text = reader["apellidos"].ToString();
                                txtPhone.Text = reader["telefono"].ToString();
                                txtMail.Text = reader["correo"].ToString();
                                cbxProvincia.SelectedValue = reader["provincia"];
                                cbxMunicipio.SelectedValue = reader["municipio"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos del cliente: {ex.Message}");
                }
            }
        }

        // Metodo para cargar las provincias en el ComboBox
        private void CargarProvincias()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM provincias";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxProvincia.DataSource = dataTable;
                        cbxProvincia.DisplayMember = "provincia";
                        cbxProvincia.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las provincias: {ex.Message}");
                }
            }
        }

        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (cbxProvincia.SelectedItem != null)
            {
                // Obtener el DataRowView asociado a la fila seleccionada
                DataRowView selectedRow = (DataRowView)cbxProvincia.SelectedItem;

                // Obtener el valor del campo "id" del DataRowView
                int provinciaId = Convert.ToInt32(selectedRow["id"]);

                // Consulta SQL para obtener los municipios de la provincia seleccionada
                string query = "SELECT id, municipio FROM municipios WHERE provincia = @provinciaId";

                // Limpiar el ComboBox de municipios antes de cargar los nuevos datos
                cbxMunicipio.DataSource = null;
                cbxMunicipio.Items.Clear();

                // Conexión y adaptador de datos
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@provinciaId", provinciaId);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Asignar los municipios al ComboBox
                                cbxMunicipio.DataSource = dataTable;
                                cbxMunicipio.DisplayMember = "municipio";
                                cbxMunicipio.ValueMember = "id";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar los municipios: {ex.Message}");
                    }
                }
            }

            // Habilitar el ComboBox (Municipios)
            cbxMunicipio.Enabled = true;
        }

        private bool ValidarCampos()
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingrese los apellidos del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Por favor, ingrese el teléfono del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Por favor, ingrese el correo electrónico del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return false;
            }
            if (cbxProvincia.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione la provincia del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxProvincia.Focus();
                return false;
            }
            if (cbxMunicipio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el municipio del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMunicipio.Focus();
                return false;
            }

            // Validación del formato del correo electrónico
            try
            {
                var addr = new System.Net.Mail.MailAddress(txtMail.Text);
                if (addr.Address != txtMail.Text)
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMail.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return false;
            }

            // Validación del formato del teléfono (simplificado a números de cierta longitud, adaptar según necesidad)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{9,10}$"))
            {
                MessageBox.Show("El número de teléfono debe tener entre 9 y 10 dígitos sin espacios ni caracteres especiales.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }

        // Método para guardar los datos modificados del alumno en la base de datos
        private void GuardarDatosCliente()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE clientes SET nombre = @Nombre, apellidos = @Apellidos, telefono = @Telefono, correo = @Correo, provincia = @Provincia, municipio = @Municipio WHERE id = @Id";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtMail.Text);
                        cmd.Parameters.AddWithValue("@Provincia", cbxProvincia.SelectedValue);
                        cmd.Parameters.AddWithValue("@Municipio", cbxMunicipio.SelectedValue);
                        cmd.Parameters.AddWithValue("@Id", codigoCliente);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos del cliente actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en los datos del cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los datos del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Llamar al método para guardar los datos
                GuardarDatosCliente();

                //Cerrar el formulario
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La modificación del alumno ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }
}
