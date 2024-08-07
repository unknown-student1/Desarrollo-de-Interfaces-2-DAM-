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
    public partial class FormDetalleEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        // Variable para almacenar el ID de venta
        private string codigoVenta;

        // Variable para almacenar el ID de venta
        private string codigoDetalle;

        public FormDetalleEdit(string codigoDetalle)
        {
            InitializeComponent();
            
            // Establecer el codigo detalle
            this.codigoDetalle = codigoDetalle;

            // Cargar clientes en el comboBox
            CargarProductos();

            // Cargar detalles de la venta
            CargarDatosDetalle();

            // Desactivar el TextBox de precio
            txtPrecio.Enabled = false;

            // Obtener el id del producto 
            string idProducto = cbxProductos.SelectedValue.ToString();

            // Cargar precio del producto
            CargarPrecioProducto(idProducto);
        }

        // Método para cargar los clientes
        private void CargarProductos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT ID, DESCRIPCION FROM ARTICULOS";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxProductos.DataSource = dataTable;
                        cbxProductos.DisplayMember = "descripcion";
                        cbxProductos.ValueMember = "id";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los articulos: {ex.Message}");
                }
            }
        }

        // Metodo para cargar los datos del articulo en el formulario
        private void CargarDatosDetalle()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM DETALLESVENTA WHERE ID = @IdDetalle";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdDetalle", codigoDetalle);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cbxProductos.SelectedValue = reader["IDPRODUCTO"];
                                txtCantidad.Text = reader["CANTIDAD"].ToString();
                                codigoVenta = reader["IDVENTA"].ToString();  
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los detalles: {ex.Message}");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Llamar al método para guardar los datos
                GuardarDetalle();

                //Cerrar el formulario
                this.Close();
            }
        }

        private void GuardarDetalle()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE DETALLESVENTA SET IDPRODUCTO = @IdProducto, CANTIDAD = @Cantidad WHERE ID = @IdDetalle";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cantidad", int.Parse(txtCantidad.Text));
                        cmd.Parameters.AddWithValue("@IdProducto", cbxProductos.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdDetalle", codigoDetalle);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Detalle de la venta actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en los detalles de la venta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el detalle de la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La modificación del detalle de la venta ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }

        // Metodo para validar los campos
        private bool ValidarCampos()
        {
            // 
            if (cbxProductos.SelectedIndex == -1 && string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor rellenes los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cbxProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxProductos.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, ingrese la cantidad del producto.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            // Verificar si el campo de media es un número
            if (!int.TryParse(txtCantidad.Text, out int _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }
            else if (int.Parse(txtCantidad.Text) < 1 || int.Parse(txtCantidad.Text) > 10)// Verificar si el número está entre 1 y 10
            {
                MessageBox.Show("Por favor, ingrese un valor entre 1 y 10.", "Campo fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }

        // Evento que se dispara cuando cambia la selección del ComboBox
        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del producto seleccionado
            if (cbxProductos.SelectedValue != null)
            {
                string idProducto = cbxProductos.SelectedValue.ToString();
                CargarPrecioProducto(idProducto);
            }
        }

        // Método para cargar el precio del producto seleccionado
        private void CargarPrecioProducto(String idProducto)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT PRECIO FROM ARTICULOS WHERE ID = @IdProducto";

                try
                {
                    conexion.Open();

                    using (MySqlCommand command = new MySqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            decimal precio = Convert.ToDecimal(result);
                            txtPrecio.Text = precio.ToString("C2"); // Formato de moneda
                        }
                        else
                        {
                            txtPrecio.Text = "0.00"; // Si no hay precio, mostrar 0.00
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el precio del producto: {ex.Message}");
                }
            }
        }
    }
}
