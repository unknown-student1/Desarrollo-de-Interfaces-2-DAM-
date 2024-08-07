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
    public partial class FormArticuloEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;
        
        // Variable para almacenar el ID del articulo
        private string codigoArticulo;

        public FormArticuloEdit(string codigoArticulo)
        {
            InitializeComponent();

            // Establecer el ccodigo articulo
            this.codigoArticulo = codigoArticulo;

            // Cargar ComboBox Familia
            CargarFamilias();

            // Cargar datos del articulo
            CargarDatosArticulo();
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

        // Metodo para cargar los datos del articulo en el formulario
        private void CargarDatosArticulo()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM ARTICULOS WHERE ID = @ID";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ID", codigoArticulo);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtDescripcion.Text = reader["descripcion"].ToString();
                                txtPrecio.Text = reader["precio"].ToString();
                                txtStock.Text = reader["stock"].ToString();
                                cbxFamilias.SelectedValue = reader["familia"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos del articulo: {ex.Message}");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La edición del articulo ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        // Método para guardar los datos modificados del articulo
        private void GuardarArticulo()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE ARTICULOS SET DESCRIPCION = @Descripcion, PRECIO = @Precio, PRECIO = @Precio, STOCK = @Stock, FAMILIA = @Familia WHERE ID = @IDArticulo";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@Precio", float.Parse(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("@Familia", cbxFamilias.SelectedValue);
                        cmd.Parameters.AddWithValue("@IDArticulo", codigoArticulo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Articulo actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en los datos del articulo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el articulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            // Verificar si el campo de stockx es un número valido
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
