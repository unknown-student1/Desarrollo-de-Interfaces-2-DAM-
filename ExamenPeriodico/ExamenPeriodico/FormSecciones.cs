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
    public partial class FormSecciones : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormSecciones()
        {
            InitializeComponent();

            // Metodo para cargar las secciones
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
                    string query = "SELECT * FROM secciones";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTableSecciones = new DataTable();
                        adapter.Fill(dataTableSecciones);

                        // Asignar los datos al DataGridView
                        dataGridViewSecciones.DataSource = dataTableSecciones;
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
            FormSeccionAdd agregarSeccion = new FormSeccionAdd();
            agregarSeccion.ShowDialog();

            // Recargar el DataGrid
            CargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSecciones.SelectedRows.Count > 0)
            {
                // Guardar el codigo del alumno
                string codigoSeleccionado = dataGridViewSecciones.SelectedRows[0].Cells["id"].Value.ToString();

                FormSeccionEdit modificarSeccion = new FormSeccionEdit(codigoSeleccionado);
                modificarSeccion.ShowDialog();

                // Recargar los datos del DataGridView
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una publicacion para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewSecciones.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de borrar esta seccion?", "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string codigoSeleccionado = dataGridViewSecciones.SelectedRows[0].Cells["id"].Value.ToString();
                    BorrarPublicacion(codigoSeleccionado);
                    CargarDatos(); // Recargar la lista después de borrar
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una seccion para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarPublicacion(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string deleteQuery = "DELETE FROM secciones WHERE id = @Codigo";

                try
                {
                    conexion.Open();

                    // Borrar Publicacion
                    using (MySqlCommand deleteAlumnoCmd = new MySqlCommand(deleteQuery, conexion))
                    {
                        deleteAlumnoCmd.Parameters.AddWithValue("@Codigo", codigo);
                        deleteAlumnoCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Seccion borrada exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la seccion: {ex.Message}");
                }
            }
        }
    }
}
