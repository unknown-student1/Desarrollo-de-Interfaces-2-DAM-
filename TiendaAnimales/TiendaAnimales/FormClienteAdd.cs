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
    public partial class FormClienteAdd : Form
    {
        private string cadenaConexion = Conexion.ObtenerCadena;

        // Obtener Datos Formulario
        public string Nombre { get { return txtNombre.Text; } }
        public string Apellidos { get { return txtApellidos.Text; } }
        public string Correo { get { return txtMail.Text; } }
        public string Phone { get { return txtPhone.Text; } }
        public int ProvinciaId { get { return (int)cbxProvincia.SelectedValue; } }
        public long MunicipioId { get { return (long)cbxMunicipio.SelectedValue; } }

        public FormClienteAdd()
        {
            InitializeComponent();

            // Cargar Provincias
            CargarProvincias();
            
            // Desabilitar ComboBox (Municipio)
            cbxMunicipio.Enabled = false;
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

        // Método para realizar la validación de los campos
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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Establecer DialogResult.OK para indicar que se ha confirmado la acción de guardar
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Establecer DialogResult.Cancel para indicar que se ha cancelado la acción
            this.DialogResult = DialogResult.Cancel;

            // Cerrar el formulario
            this.Close();
        }
    }
}
