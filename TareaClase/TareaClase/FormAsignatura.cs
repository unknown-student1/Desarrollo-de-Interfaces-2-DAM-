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
    public partial class FormAsignatura : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormAsignatura()
        {
            InitializeComponent();
            // Cargar los datos en el DataGridView
            CargarDatos();
        }

        // Metodo para cargar los notas en el DataGridView
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                {
                    connection.Open();

                    // Consulta SQL
                    string query = "SELECT * FROM asignaturas";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTableAlumnos = new DataTable();
                        adapter.Fill(dataTableAlumnos);

                        // Asignar los datos al DataGridView
                        dataGridViewAsignaturas.DataSource = dataTableAlumnos;
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
            FormAsignaturaAdd AgregarAsignatura = new FormAsignaturaAdd();
            AgregarAsignatura.ShowDialog();

            if (AgregarAsignatura.ShowDialog() == DialogResult.OK)
            {
                // Obtener los datos del formulario
                string asignatura = AgregarAsignatura.Asignatura;

                // Insertar los datos en la base de datos
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                    {
                        connection.Open();
                        string query = "INSERT INTO asignaturas (asignatura) VALUES (@asignatura)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@asignatura", asignatura);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Asignatura insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Recargar datos del DataGrid
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar la asignatura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else 
            {
                MessageBox.Show("La inserción de la asignatura ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAsignaturas.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string CodigoAsignaturaModificar = dataGridViewAsignaturas.SelectedRows[0].Cells["id"].Value.ToString();

                // Variables para guardar la informacion sobre la nota
                string asignaturaModificar = "";

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    string query = "SELECT * FROM asignaturas WHERE id = @Identificador";

                    try
                    {
                        conexion.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@Identificador", CodigoAsignaturaModificar);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    asignaturaModificar = reader["asignatura"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar los datos de la asignatura: {ex.Message}");
                    }
                }

                FormAsignaturaEdit ModificarAsignatura = new FormAsignaturaEdit(asignaturaModificar);
                ModificarAsignatura.ShowDialog();

                if (ModificarAsignatura.ShowDialog() == DialogResult.OK)
                {
                    // Obtener los datos del formulario
                    string asignatura = ModificarAsignatura.Asignatura;

                    // Insertar los datos en la base de datos
                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                        {
                            string query = "UPDATE asignaturas SET asignatura = @Asignatura WHERE id = @Identificador";

                            try
                            {
                                conexion.Open();

                                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                                {
                                    cmd.Parameters.AddWithValue("@Asignatura", asignatura);
                                    cmd.Parameters.AddWithValue("@Identificador", CodigoAsignaturaModificar);

                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Asignatura actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se realizaron cambios en la asignatura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al actualizar los datos de la asignatura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Recargar datos del DataGrid
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar la asignatura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("La modficación de la asignatura ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una asignatura para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAsignaturas.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas borrar la asignatura seleccionada?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewAsignaturas.SelectedRows[0].Cells["id"].Value.ToString();
                    BorrarNota(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista de notas
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una nota para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarNota(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteAsignaturaQuery = "DELETE FROM asignaturas WHERE id = @Identificador";

                try
                {
                    conexion.Open();

                    // Borrar la nota
                    using (MySqlCommand deleteNotasCmd = new MySqlCommand(deleteAsignaturaQuery, conexion))
                    {
                        deleteNotasCmd.Parameters.AddWithValue("@Identificador", codigo);
                        deleteNotasCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Asignatura borrada exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la asignatura: {ex.Message}");
                }
            }
        }
    }
}
