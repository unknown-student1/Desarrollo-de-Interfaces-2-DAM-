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
    public partial class FormPublicacionEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;
        
        private string codigoPublicacion;

        public FormPublicacionEdit(string codigoPublicacion)
        {
            InitializeComponent();

            this.codigoPublicacion = codigoPublicacion;

            // Metodo para cargar las secciones
            CargarSecciones();

            //Cargarmos los datos del alumno
            CargarDatosPublicacion();
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

        // Metodo para cargar los datos de la publicacion
        private void CargarDatosPublicacion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM publicaciones WHERE id = @CodigoPublicacion";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@CodigoPublicacion", codigoPublicacion);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitulo.Text = reader["titulo"].ToString();
                                txtAutor.Text = reader["autor"].ToString();
                                txtCuerpo.Text = reader["cuerpo"].ToString();
                                txtPalabrasClave.Text = reader["palabrasclave"].ToString();
                                txtCalificacion.Text = reader["calificacion"].ToString();
                                cbxSecciones.SelectedValue = reader["seccion"];
                                dateTimePickerFecha.Value = Convert.ToDateTime(reader["fecha"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de la publicacion: {ex.Message}");
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

        // Método para guardar los datos modificados de la publicación
        private void GuardarPublicacion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE publicaciones SET fecha = @fecha, titulo = @titulo, cuerpo = @cuerpo, seccion = @seccion, calificacion = @calificacion, palabrasclave = @palabrasclae, autor = @autor WHERE id = @CodigoPublicacion";

                try
                {
                    conexion.Open();

                    using (MySqlCommand command = new MySqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@fecha", dateTimePickerFecha.Value);
                        command.Parameters.AddWithValue("@titulo", txtTitulo.Text);
                        command.Parameters.AddWithValue("@cuerpo", txtCuerpo.Text);
                        command.Parameters.AddWithValue("@seccion", cbxSecciones.SelectedValue);
                        command.Parameters.AddWithValue("@calificacion", int.Parse(txtCalificacion.Text));
                        command.Parameters.AddWithValue("@palabrasclave", txtPalabrasClave.Text);
                        command.Parameters.AddWithValue("@autor", txtAutor.Text);
                        command.Parameters.AddWithValue("@CodigoPublicacion", codigoPublicacion);


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos dela publicación actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en la publicación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los datos de la publicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La modificación de la publicacion ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }
}
