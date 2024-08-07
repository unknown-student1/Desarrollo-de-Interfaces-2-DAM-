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
    public partial class FormSeccionAdd : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormSeccionAdd()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Llamar al método para guardar los datos
            GuardarSeccion();

            //Cerrar el formulario
            this.Close();
        }

        // Método para guardar los datos modificados del alumno en la base de datos
        private void GuardarSeccion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                // Insertar los datos en la base de datos
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(cadenaConexion))
                    {
                        connection.Open();
                        string query = "INSERT INTO secciones (descripcion) VALUES (@descripcion)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seccion insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar seccion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
