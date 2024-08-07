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
    public partial class FormAsignaturaEdit : Form
    {
        public string Asignatura { get { return TextBoxAsignatura.Text; } }

        public FormAsignaturaEdit(string asignatura)
        {
            InitializeComponent();
            TextBoxAsignatura.Text = asignatura;
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
            if (string.IsNullOrWhiteSpace(TextBoxAsignatura.Text))
            {
                MessageBox.Show("Por favor inserte el nombre de la asignatura", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Si todos los campos requeridos están llenos y válidos, la validación es exitosa
            return true;
        }
    }
}
