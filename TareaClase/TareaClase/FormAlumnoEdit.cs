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

namespace TareaClase
{
    public partial class FormAlumnoEdit : Form
    {
        private string cadenaConexion = Conexion.ObtenerCadena;
        private string codigoAlumno;

        public FormAlumnoEdit(string codigoAlumno)
        {
            InitializeComponent();
            this.codigoAlumno = codigoAlumno;
            
            // Cargamos los datos en el ComboBox
            CargarProvincias();

            //Cargarmos los datos del alumno
            CargarDatosAlumno();

            // Deshabilitar el ComboBox (Municipio)
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

        // Metodo para cargar los datos del alumno en el formulario
        private void CargarDatosAlumno()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM alumnos WHERE Codigo = @Codigo";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigoAlumno);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["nombre"].ToString();
                                txtApellidos.Text = reader["apellidos"].ToString();
                                dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(reader["fechaNacimiento"]);
                                cbxProvincia.SelectedValue = reader["provincia"];
                                cbxMunicipio.SelectedValue = reader["municipio"];
                                txtMedia.Text = reader["media"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos del alumno: {ex.Message}");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Llamar al método para guardar los datos
                GuardarDatosAlumno();

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

        // Método para guardar los datos modificados del alumno en la base de datos
        private void GuardarDatosAlumno()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE alumnos SET nombre = @Nombre, apellidos = @Apellidos, fechaNacimiento = @FechaNacimiento, provincia = @Provincia, municipio = @Municipio, media = @NotaMedia WHERE Codigo = @Codigo";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dateTimePickerFechaNacimiento.Value);
                        cmd.Parameters.AddWithValue("@Provincia", cbxProvincia.SelectedValue);
                        cmd.Parameters.AddWithValue("@Municipio", cbxMunicipio.SelectedValue);
                        cmd.Parameters.AddWithValue("@Codigo", codigoAlumno);
                        cmd.Parameters.AddWithValue("@NotaMedia", float.Parse(txtMedia.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos del alumno actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en los datos del alumno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los datos del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtApellidos.Text) &&
                dateTimePickerFechaNacimiento.Value > DateTime.Today && cbxProvincia.SelectedIndex == -1 && cbxMunicipio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor rellenes los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { // Verificar si el campo nombre está vacío
                MessageBox.Show("Por favor, ingrese el nombre del alumno.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            { // Verificar si el campo de apellidos está vacío
                MessageBox.Show("Por favor, ingrese los apellidos del alumno.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }
            else if (dateTimePickerFechaNacimiento.Value > DateTime.Today)
            { // Verificar si el campo de fecha de nacimiento está vacío o es una fecha futura
                MessageBox.Show("La fecha de nacimiento no puede ser en el futuro.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerFechaNacimiento.Focus();
                return false;
            }
            else if (cbxProvincia.SelectedIndex == -1)
            { // Verificar si no se ha seleccionado una provincia

                MessageBox.Show("Por favor, seleccione la provincia del alumno.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxProvincia.Focus();
                return false;
            }
            else if (cbxMunicipio.SelectedIndex == -1)
            { // Verificar si no se ha seleccionado un municipio
                MessageBox.Show("Por favor, seleccione el municipio del alumno.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMunicipio.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtMedia.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor para la media.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedia.Focus();
                return false;
            }

            // Verificar si el campo de media es un número
            if (!float.TryParse(txtMedia.Text, out float _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la media.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedia.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
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

    }
}
