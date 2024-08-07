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
    
    public partial class FormPublicaciones : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormPublicaciones()
        {
            InitializeComponent();

            // Metodo para cargar las secciones
            CargarSecciones();

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
                    string query = "SELECT * FROM publicaciones";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTablePublicaciones = new DataTable();
                        adapter.Fill(dataTablePublicaciones);

                        // Asignar los datos al DataGridView
                        dataGridViewPublicaciones.DataSource = dataTablePublicaciones;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos desde la base de datos: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSecciones()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM secciones";

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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void ObtenerPublicionesxSeccion(string codigoSeccion)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                // Consulta SQL para obtener las publicaciones por seccion
                string query = "SELECT * FROM publicaciones WHERE seccion = @CodigoSeccion";

                try
                {
                    conexion.Open();

                    // Configurar el comando con la consulta y los parámetros
                    using (MySqlCommand commandSecciones = new MySqlCommand(query, conexion))
                    {
                        commandSecciones.Parameters.AddWithValue("@CodigoSeccion", codigoSeccion);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(commandSecciones))
                        {
                            DataTable dataTablePublicaciones = new DataTable();
                            adapter.Fill(dataTablePublicaciones);

                            // Asignar los datos al DataGridView
                            dataGridViewPublicaciones.DataSource = dataTablePublicaciones;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las publicaciones: {ex.Message}");
                }
            }
        }


        private void cbxSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigoSeccion = cbxSecciones.SelectedValue.ToString();

            ObtenerPublicionesxSeccion(codigoSeccion);
        }

        private void BorrarPublicacion(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM publicaciones WHERE id = @CodigoPublicacion";

                try
                {
                    conexion.Open();

                    // Borrar Publicacion
                    using (MySqlCommand deleteAlumnoCmd = new MySqlCommand(deleteQuery, conexion))
                    {
                        deleteAlumnoCmd.Parameters.AddWithValue("@CodigoPublicacion", codigo);
                        deleteAlumnoCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Publicacion borrada exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la publicacion: {ex.Message}");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPublicaciones.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar esta publicación?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewPublicaciones.SelectedRows[0].Cells["id"].Value.ToString();
                    BorrarPublicacion(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista después de borrar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una publicación para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPublicaciones.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewPublicaciones.SelectedRows[0].Cells["id"].Value.ToString();

                FormPublicacionEdit modificarPublicacion = new FormPublicacionEdit(codigoSeleccionado);
                modificarPublicacion.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una publicacion para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            FormPublicacionAdd agregarPublicacion = new FormPublicacionAdd();
            agregarPublicacion.ShowDialog();

            // Recargar los datos del DataGridView
            CargarDatos();
        }
    }

}
