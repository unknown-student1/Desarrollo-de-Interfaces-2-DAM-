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
    public partial class FormSeccionEdit : Form
    {
        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        private string codigoSeccion;
        public FormSeccionEdit(string codigoSeccion)
        {
            InitializeComponent();

            this.codigoSeccion = codigoSeccion;

            //Cargarmos los datos
            CargarSeccion();
        }

        // Metodo para cargar los datos del alumno en el formulario
        private void CargarSeccion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM secciones WHERE id = @CodigoSeccion";

                try
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@CodigoSeccion", codigoSeccion);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtDescripcion.Text = reader["descripcion"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de la seccion: {ex.Message}");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                // Llamar al método para guardar los datos
                GuardarSeccion();

                //Cerrar el formulario
                this.Close();
            }
        }

        // Método para guardar los datos modificados de la publicación
        private void GuardarSeccion()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "UPDATE secciones SET descripcion = @descripcion WHERE id = @CodigoSeccion";

                try
                {
                    conexion.Open();

                    using (MySqlCommand command = new MySqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        command.Parameters.AddWithValue("@CodigoSeccion", codigoSeccion);


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos de la seccion actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizaron cambios en la seccion.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los datos de la seccion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje
            MessageBox.Show("La modificación de la seccion ha sido cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Cierra el formulario sin realizar ninguna acción
            this.Close();
        }
    }
}
