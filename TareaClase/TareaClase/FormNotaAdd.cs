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
    public partial class FormNotaAdd : Form
    {
        public string Asignatura { get { return cbxAsignatura.SelectedValue.ToString(); } }
        public float Nota { get { return float.TryParse(txtNota.Text, out float media) ? media : 0f; } }

        // Obtener la cadena de conexión
        private string cadenaConexion = Conexion.ObtenerCadena;

        public FormNotaAdd()
        {
            InitializeComponent();
            CargarAsignaturas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == true)
            {
                // Establecer DialogResult.OK para indicar que se ha confirmado la acción de guardar
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Establecer DialogResult.Cancel para indicar que se ha cancelado la acción
            this.DialogResult = DialogResult.Cancel;

            // Cerrar el formulario
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNota.Text))
            { // Verificar si el campo de nota no este vacío
                MessageBox.Show("Por favor, ingrese una nota.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNota.Focus();
                return false;
            }

            // Verificar si el campo de nota es un número
            if (!float.TryParse(txtNota.Text, out float _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la media.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNota.Focus();
                return false;
            }

            // Validar el rango de la nota, por ejemplo, entre 0 y 10
            if (!float.TryParse(txtNota.Text, out float nota) || nota < 0 || nota > 10)
            {
                MessageBox.Show("La nota debe ser un número válido en el rango de 0 a 10.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNota.Focus();
                return false;
            }


            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }

        // Metodo para cargar las provincias en el ComboBox
        private void CargarAsignaturas()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM asignaturas";

                try
                {
                    conexion.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        cbxAsignatura.DataSource = dataTable;
                        cbxAsignatura.DisplayMember = "asignatura";
                        cbxAsignatura.ValueMember = "asignatura";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las asignaturas: {ex.Message}");
                }
            }
        }
    }
}
