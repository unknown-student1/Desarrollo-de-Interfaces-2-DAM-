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
    public partial class FormNotas : Form
    {
        private string cadenaConexion = Conexion.ObtenerCadena;
        private string codigoAlumno;

        public FormNotas(string codigoAlumno)
        {
            InitializeComponent();
            this.codigoAlumno = codigoAlumno;
        }

        private void FormNotas_Load(object sender, EventArgs e)
        {
            CargarNotas();
        }

        // Metodo para cargar las notas en el DataGridView
        private void CargarNotas()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL para obtener las notas del alumno seleccionado
                    string query = "SELECT * FROM notas WHERE codigo_alumno = @CodigoAlumno";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoAlumno", codigoAlumno);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Asignar los datos al DataGridView de notas
                            dataGridViewNotas.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las notas del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (FormNotaAdd AgragarNota = new FormNotaAdd())
            {
                if (AgragarNota.ShowDialog() == DialogResult.OK)
                {

                    // Obtener los datos del formulario FormAlumnoAdd
                    string asignatura = AgragarNota.Asignatura;
                    float nota = AgragarNota.Nota;

                    // Insertar los datos en la base de datos
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                        {
                            connection.Open();
                            string query = "INSERT INTO notas (asignatura, nota, codigo_alumno) VALUES (@asignatura, @nota, @codigoAlumno)";
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@asignatura", asignatura);
                            command.Parameters.AddWithValue("@nota", nota);
                            command.Parameters.AddWithValue("@codigoAlumno", codigoAlumno);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Nota insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Recargar datos el DataGridView
                        CargarNotas();
                        // Actualizar la media
                        ActualizarMedia(codigoAlumno);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar la nota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La inserción del nota ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotas.SelectedRows.Count > 0)
            {
                // Guardar el codigo
                string codigoNotaSeleccionado = dataGridViewNotas.SelectedRows[0].Cells["id"].Value.ToString();

                // Variables para guardar la informacion sobre la nota
                string asignaturaModificar = "";
                string notaModificar = "";

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    string query = "SELECT * FROM notas WHERE id = @codigoNotaSeleccionado";

                    try
                    {
                        conexion.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@codigoNotaSeleccionado", codigoNotaSeleccionado);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    asignaturaModificar = reader["asignatura"].ToString();
                                    notaModificar = reader["nota"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la información sobre la nota: {ex.Message}");
                    }
                }



                using (FormNotaEdit ModificarNota = new FormNotaEdit(asignaturaModificar,notaModificar))
                {
                    if (ModificarNota.ShowDialog() == DialogResult.OK)
                    {

                        // Obtener los datos del formulario
                        string asignatura = ModificarNota.Asignatura;
                        float nota = ModificarNota.Nota;

                        // Realizar un update para actualizar los datos
                        try
                        {
                            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                            {
                                string query = "UPDATE notas SET asignatura = @Asignatura, nota = @Nota WHERE id = @Codigo";

                                try
                                {
                                    conexion.Open();

                                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                                    {
                                        cmd.Parameters.AddWithValue("@Asignatura", asignatura);
                                        cmd.Parameters.AddWithValue("@Nota",nota);
                                        cmd.Parameters.AddWithValue("@Codigo", codigoNotaSeleccionado);

                                        int rowsAffected = cmd.ExecuteNonQuery();
                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Nota del alumno actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se realizaron cambios en los datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al actualizar la nota del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            // Recargar datos el DataGridView
                            CargarNotas();
                            // Actualizar la media
                            ActualizarMedia(codigoAlumno);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al insertar la nota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La inserción del nota ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Recargar los datos del DataGridView
                CargarNotas();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una nota para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotas.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar esta nota?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewNotas.SelectedRows[0].Cells["id"].Value.ToString();
                    BorrarNota(codigoSeleccionado);
                    
                    // Recargar la lista después de borrar
                    CargarNotas();
                    // Actualizar la media
                    ActualizarMedia(codigoAlumno);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarNota(string idNota)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "DELETE FROM notas WHERE id = @idNota";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idNota", idNota);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Nota borrada exitosamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la nota: {ex.Message}");
                }
            }
        }

        private void ActualizarMedia(string codigoAlumno)
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
                        double media = Convert.ToDouble(commandMedia.ExecuteScalar());

                        // Consulta SQL para actualizar el campo de media en la tabla de alumnos
                        string queryUpdateMedia = "UPDATE alumnos SET media = @Media WHERE codigo = @CodigoAlumno";

                        using (MySqlCommand commandUpdateMedia = new MySqlCommand(queryUpdateMedia, connection))
                        {
                            commandUpdateMedia.Parameters.AddWithValue("@Media", media);
                            commandUpdateMedia.Parameters.AddWithValue("@CodigoAlumno", codigoAlumno);
                            int rowsAffected = commandUpdateMedia.ExecuteNonQuery();

                            /*if (rowsAffected > 0)
                            {
                                MessageBox.Show("Media del alumno actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se realizaron cambios en la media del alumno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }*/
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la media del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
