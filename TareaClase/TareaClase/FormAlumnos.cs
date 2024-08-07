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
    public partial class FormAlumnos : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;
        
        public FormAlumnos()
        {
            InitializeComponent();
            
        }

        private void FormAlumnos_Load(object sender, EventArgs e)
        {
            // Cargar los datos en el DataGridView
            CargarDatos();
        }

        // Metodo para cargar los datos en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL
                    string query = "SELECT * FROM alumnos";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTableAlumnos = new DataTable();
                        adapter.Fill(dataTableAlumnos);

                        // Asignar los datos al DataGridView
                        dataGridViewAlumnos.DataSource = dataTableAlumnos;
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
            using (FormAlumnoAdd AgregarAlumno = new FormAlumnoAdd())
            {
                if (AgregarAlumno.ShowDialog() == DialogResult.OK)
                {

                    // Obtener los datos del formulario FormAlumnoAdd
                    string nombre = AgregarAlumno.Nombre;
                    string apellidos = AgregarAlumno.Apellidos;
                    DateTime fechaNacimiento = AgregarAlumno.FechaNacimiento;
                    int provinciaId = AgregarAlumno.ProvinciaId;
                    long municipioId = AgregarAlumno.MunicipioId;
                    float notaMedia = AgregarAlumno.Media;

                    // Insertar los datos en la base de datos
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                        {
                            connection.Open();
                            string query = "INSERT INTO alumnos (nombre, apellidos, fechaNacimiento, provincia, municipio, media) VALUES (@nombre, @apellidos, @fechaNacimiento, @provincia, @municipio, @media)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@nombre", nombre);
                            command.Parameters.AddWithValue("@apellidos", apellidos);
                            command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                            command.Parameters.AddWithValue("@provincia", provinciaId);
                            command.Parameters.AddWithValue("@municipio", municipioId);
                            command.Parameters.AddWithValue("@media", notaMedia);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Alumno insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Recargar datos del DataGrid
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La inserción del alumno ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlumnos.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewAlumnos.SelectedRows[0].Cells["Codigo"].Value.ToString();

                FormAlumnoEdit modificarAlumno = new FormAlumnoEdit(codigoSeleccionado);
                modificarAlumno.ShowDialog();

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
            if (dataGridViewAlumnos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar a este alumno?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewAlumnos.SelectedRows[0].Cells["Codigo"].Value.ToString();
                    BorrarAlumnos(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista después de borrar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarAlumnos(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteNotasQuery = "DELETE FROM notas WHERE codigo_alumno = @Codigo";
                string deleteAlumnoQuery = "DELETE FROM alumnos WHERE codigo = @Codigo";

                try
                {
                    conexion.Open();

                    // Borrar las notas del alumno
                    using (MySqlCommand deleteNotasCmd = new MySqlCommand(deleteNotasQuery, conexion))
                    {
                        deleteNotasCmd.Parameters.AddWithValue("@Codigo", codigo);
                        deleteNotasCmd.ExecuteNonQuery();
                    }

                    // Borrar al alumno
                    using (MySqlCommand deleteAlumnoCmd = new MySqlCommand(deleteAlumnoQuery, conexion))
                    {
                        deleteAlumnoCmd.Parameters.AddWithValue("@Codigo", codigo);
                        deleteAlumnoCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Alumno y notas borradas exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar el alumno y sus notas: {ex.Message}");
                }
            }
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlumnos.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewAlumnos.SelectedRows[0].Cells["Codigo"].Value.ToString();

                FormNotas notas = new FormNotas(codigoSeleccionado);
                notas.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
