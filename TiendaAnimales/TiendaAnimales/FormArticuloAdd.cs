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
    public partial class FormArticuloAdd : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormArticuloAdd()
        {
            InitializeComponent();

            // Cargar ComboBox Familia
            CargarFamilias();
            cbxFamilias.SelectedIndex = -1;
        }

        // Método para cargar las familias
        private void CargarFamilias()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM FAMILIAS";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxFamilias.DataSource = dataTable;
                        cbxFamilias.DisplayMember = "DESCRIPCION";
                        cbxFamilias.ValueMember = "ID";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las familias: {ex.Message}");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La insercción del articulo ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Llamar al método para guardar los datos
                GuardarArticulo();

                //Cerrar el formulario
                this.Close();
            }
        }

        // Método para guardar un articulo
        public void GuardarArticulo()
        {
            // Insertar los datos en la base de datos
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open(); // Abrimos la conexión

                    string query = "INSERT INTO ARTICULOS (DESCRIPCION, PRECIO, STOCK, FAMILIA) VALUES (@Descripcion, @Precio, @Stock, @Familia)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    command.Parameters.AddWithValue("@Precio", float.Parse(txtPrecio.Text));
                    command.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                    command.Parameters.AddWithValue("@Familia", cbxFamilias.SelectedValue);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Articulo insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el articulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para validar los campos
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) && string.IsNullOrWhiteSpace(txtPrecio.Text) && string.IsNullOrWhiteSpace(txtStock.Text) &&
                 cbxFamilias.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor rellenes los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese la descripción del articulo.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, ingrese el precio del producto.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor, ingrese el stock del producto.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }
            else if (cbxFamilias.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una familia.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxFamilias.Focus();
                return false;
            }

            // Verificar si el campo de precio es un número valido
            if (!float.TryParse(txtPrecio.Text, out float _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para el precio.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            // Verificar si el campo de stock es un número valido
            if (!int.TryParse(txtStock.Text, out int _))
            {
                MessageBox.Show("Por favor, ingrese un valor entero valido para el stock.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }
    }
}
