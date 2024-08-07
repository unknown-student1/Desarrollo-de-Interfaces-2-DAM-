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
    public partial class FormNotaEdit : Form
    {
        public string Asignatura { get { return txtAsignatura.Text; } }
        public float Nota { get { return float.TryParse(txtNota.Text, out float media) ? media : 0f; } }

        public FormNotaEdit(string asignatura, string nota)
        {
            InitializeComponent();

            // Insertar los datos en los campos
            txtAsignatura.Text = asignatura;
            txtNota.Text = nota;
            txtAsignatura.Enabled = false;
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
            if (string.IsNullOrWhiteSpace(txtAsignatura.Text) && string.IsNullOrWhiteSpace(txtNota.Text))
            {
                MessageBox.Show("Por favor rellenes los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtAsignatura.Text))
            { // Verificar si el campo nombre está vacío
                MessageBox.Show("Por favor, ingrese el nombre de la asignatura.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAsignatura.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNota.Text))
            { // Verificar si el campo de apellidos está vacío
                MessageBox.Show("Por favor, ingrese una nota.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNota.Focus();
                return false;
            }

            // Verificar si el campo de media es un número
            if (!float.TryParse(txtNota.Text, out float _))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la media.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNota.Focus();
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }
    }
}
