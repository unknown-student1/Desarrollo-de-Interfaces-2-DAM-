
namespace TareaClase
{
    partial class FormAlumnoEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMunicipio = new System.Windows.Forms.ComboBox();
            this.cbxProvincia = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Municipio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Provincia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Apellidos";
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(412, 157);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(206, 28);
            this.cbxMunicipio.TabIndex = 16;
            // 
            // cbxProvincia
            // 
            this.cbxProvincia.FormattingEnabled = true;
            this.cbxProvincia.Location = new System.Drawing.Point(93, 160);
            this.cbxProvincia.Name = "cbxProvincia";
            this.cbxProvincia.Size = new System.Drawing.Size(206, 28);
            this.cbxProvincia.TabIndex = 15;
            this.cbxProvincia.SelectedIndexChanged += new System.EventHandler(this.cbxProvincia_SelectedIndexChanged);
            // 
            // dateTimePickerFechaNacimiento
            // 
            this.dateTimePickerFechaNacimiento.Location = new System.Drawing.Point(618, 103);
            this.dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            this.dateTimePickerFechaNacimiento.Size = new System.Drawing.Size(325, 26);
            this.dateTimePickerFechaNacimiento.TabIndex = 14;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(300, 106);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(246, 26);
            this.txtApellidos.TabIndex = 13;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(93, 106);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(118, 26);
            this.txtNombre.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("FiraCode Nerd Font", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 49);
            this.label1.TabIndex = 11;
            this.label1.Text = "Modificar Alumno";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(336, 228);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(441, 228);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(716, 157);
            this.txtMedia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(140, 26);
            this.txtMedia.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Media";
            // 
            // FormAlumnoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 283);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMunicipio);
            this.Controls.Add(this.cbxProvincia);
            this.Controls.Add(this.dateTimePickerFechaNacimiento);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAlumnoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Alumno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMunicipio;
        private System.Windows.Forms.ComboBox cbxProvincia;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacimiento;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.Label label7;
    }
}