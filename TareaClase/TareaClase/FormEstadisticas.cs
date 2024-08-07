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
    public partial class FormEstadisticas : Form
    {
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormEstadisticas()
        {
            InitializeComponent();
            CargarAlumnos();

            /* Establecer el (-1) para que no haya ningun elemento seleccionado
            cbxAlumnos.SelectedIndex = -1;*/

            txtEstadisticas.Text = "";
            txtEstadisticas.Enabled = false;
        }

        private void CargarAlumnos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT codigo, CONCAT(nombre, ' ', apellidos) AS nombre_completo FROM alumnos";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxAlumnos.DataSource = dataTable;
                        cbxAlumnos.DisplayMember = "nombre_completo";
                        cbxAlumnos.ValueMember = "codigo";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los alumnos: {ex.Message}");
                }
            }
        }

        private void cbxAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigoAlumno = cbxAlumnos.SelectedValue.ToString();

            ObtenerNotas(codigoAlumno);
            ObtenerMedia(codigoAlumno);
        }

        private void ObtenerNotas(string codigoAlumno)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para obtener las notas del alumno con el nombre de la asignatura
                    string queryNotas = "SELECT asignatura,nota FROM notas WHERE codigo_alumno = @CodigoAlumno";

                    using (MySqlCommand commandNotas = new MySqlCommand(queryNotas, connection))
                    {
                        commandNotas.Parameters.AddWithValue("@CodigoAlumno", codigoAlumno);

                        // Utilizamos un StringBuilder para concatenar todas las notas y asignaturas
                        StringBuilder notasBuilder = new StringBuilder();

                        using (MySqlDataReader reader = commandNotas.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string asignatura = reader["asignatura"].ToString();
                                string nota = reader["nota"].ToString();

                                notasBuilder.AppendLine($"{asignatura}: {nota}");
                            }
                        }

                        // Mostrar las notas en el cuadro de texto
                        txtEstadisticas.Text = notasBuilder.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las notas del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerMedia(string codigoAlumno)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para calcular la media de las notas del alumno
                    string queryMedia = "SELECT AVG(nota) FROM notas WHERE codigo_alumno = @CodigoAlumno";

                    using (MySqlCommand commandMedia = new MySqlCommand(queryMedia, connection))
                    {
                        commandMedia.Parameters.AddWithValue("@CodigoAlumno", codigoAlumno);

                        // Utilizamos el método ExecuteScalar para obtener el resultado de la consulta
                        object result = commandMedia.ExecuteScalar();
                        float media = result == DBNull.Value ? 0f : Convert.ToSingle(result);

                        // Agregar la información de la media al cuadro de texto sin sobrescribir
                        txtEstadisticas.AppendText($"Media: {media}\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la media del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
