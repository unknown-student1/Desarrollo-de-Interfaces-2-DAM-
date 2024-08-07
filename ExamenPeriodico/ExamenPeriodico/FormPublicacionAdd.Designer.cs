
namespace ExamenPeriodico
{
    partial class FormPublicacionAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCuerpo = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCalificacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPalabrasClave = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("FiraCode Nerd Font", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 49);
            this.label1.TabIndex = 12;
            this.label1.Text = "Añadir Publicacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(720, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 49);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(610, 442);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 49);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Cuerpo";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Location = new System.Drawing.Point(540, 91);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(325, 26);
            this.dateTimePickerFecha.TabIndex = 28;
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Location = new System.Drawing.Point(16, 157);
            this.txtCuerpo.Multiline = true;
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Size = new System.Drawing.Size(678, 275);
            this.txtCuerpo.TabIndex = 27;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(76, 91);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(118, 26);
            this.txtTitulo.TabIndex = 26;
            // 
            // cbxSecciones
            // 
            this.cbxSecciones.FormattingEnabled = true;
            this.cbxSecciones.Location = new System.Drawing.Point(968, 89);
            this.cbxSecciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(180, 28);
            this.cbxSecciones.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(890, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Seccion";
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.Location = new System.Drawing.Point(1274, 91);
            this.txtCalificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Size = new System.Drawing.Size(88, 26);
            this.txtCalificacion.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1173, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Calificacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(730, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Palabras Clave";
            // 
            // txtPalabrasClave
            // 
            this.txtPalabrasClave.Location = new System.Drawing.Point(720, 157);
            this.txtPalabrasClave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPalabrasClave.Multiline = true;
            this.txtPalabrasClave.Name = "txtPalabrasClave";
            this.txtPalabrasClave.Size = new System.Drawing.Size(642, 275);
            this.txtPalabrasClave.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Autor";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(272, 91);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(178, 26);
            this.txtAutor.TabIndex = 38;
            // 
            // FormPublicacionAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 508);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPalabrasClave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCalificacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.txtCuerpo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormPublicacionAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Publicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.TextBox txtCuerpo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCalificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPalabrasClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAutor;
    }
}