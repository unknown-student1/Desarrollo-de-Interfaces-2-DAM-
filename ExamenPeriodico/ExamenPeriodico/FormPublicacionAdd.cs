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

namespace ExamenPeriodico
{
    public partial class FormPublicacionAdd : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormPublicacionAdd()
        {
            InitializeComponent();

            // Metodo para cargar las secciones
            CargarSecciones();
        }

        private void CargarSecciones()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT id, descripcion  FROM secciones";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxSecciones.DataSource = dataTable;
                        cbxSecciones.DisplayMember = "descripcion";
                        cbxSecciones.ValueMember = "id";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las secciones: {ex.Message}");
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) && string.IsNullOrWhiteSpace(txtAutor.Text) &&
                 string.IsNullOrWhiteSpace(txtCuerpo.Text) && string.IsNullOrWhiteSpace(txtCuerpo.Text) && 
                 string.IsNullOrWhiteSpace(txtCalificacion.Text) && string.IsNullOrWhiteSpace(txtPalabrasClave.Text) && 
                 cbxSecciones.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor rellenes los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            { // Verificar si el campo nombre está vacío
                MessageBox.Show("Por favor, ingrese el titulo de la publicación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtAutor.Text))
            { // Verificar si el campo de apellidos está vacío
                MessageBox.Show("Por favor, ingrese el autor de la publicacion.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAutor.Focus();
                return false;
            }
            else if (cbxSecciones.SelectedIndex == -1)
            { // Verificar si no se ha seleccionado una provincia

                MessageBox.Show("Por favor, seleccione una sección.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxSecciones.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCuerpo.Text))
            {
                MessageBox.Show("Por favor, ingrese el cuerpo de la publicación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuerpo.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPalabrasClave.Text))
            {
                MessageBox.Show("Por favor, ingrese las palabras claves de la publicación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalabrasClave.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCalificacion.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor para la calificaciónd de la publicación.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalificacion.Focus();
                return false;
            }

            // Verificar si el campo de media es un número
            if (!int.TryParse(txtCalificacion.Text, out int _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalificacion.Focus();
                return false;
            }
            else if (int.Parse(txtCalificacion.Text) < 1 || int.Parse(txtCalificacion.Text) > 10)// Verificar si el número está entre 1 y 10
            {
                MessageBox.Show("Por favor, ingrese un valor entre 1 y 10.", "Campo fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalificacion.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Llamar al método para guardar los datos
                GuardarPublicacion();

                //Cerrar el formulario
                this.Close();
            }
        }

            // Método para guardar los datos modificados del alumno en la base de datos
            private void GuardarPublicacion()
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    // Insertar los datos en la base de datos
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                        {
                            connection.Open();
                            string query = "INSERT INTO publicaciones (fecha, titulo, cuerpo, seccion, calificacion, palabrasclave, autor) VALUES (@fecha, @titulo, @cuerpo, @seccion, @calificacion, @palabrasclave, @autor)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@fecha", dateTimePickerFecha.Value);
                            command.Parameters.AddWithValue("@titulo", txtTitulo.Text);
                            command.Parameters.AddWithValue("@cuerpo", txtCuerpo.Text);
                            command.Parameters.AddWithValue("@seccion", cbxSecciones.SelectedValue);
                            command.Parameters.AddWithValue("@calificacion", int.Parse(txtCalificacion.Text));
                            command.Parameters.AddWithValue("@palabrasclave", txtPalabrasClave.Text);
                            command.Parameters.AddWithValue("@autor", txtAutor.Text);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Publicación insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar publicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La inserción ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }


}
