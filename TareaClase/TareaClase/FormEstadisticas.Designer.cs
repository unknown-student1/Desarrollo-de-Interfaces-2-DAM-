
namespace TareaClase
{
    partial class FormEstadisticas
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAlumnos = new System.Windows.Forms.ComboBox();
            this.txtEstadisticas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("FiraCode Nerd Font", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estadisticas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alumno:";
            // 
            // cbxAlumnos
            // 
            this.cbxAlumnos.FormattingEnabled = true;
            this.cbxAlumnos.Location = new System.Drawing.Point(82, 57);
            this.cbxAlumnos.Name = "cbxAlumnos";
            this.cbxAlumnos.Size = new System.Drawing.Size(347, 21);
            this.cbxAlumnos.TabIndex = 3;
            this.cbxAlumnos.SelectedIndexChanged += new System.EventHandler(this.cbxAlumnos_SelectedIndexChanged);
            // 
            // txtEstadisticas
            // 
            this.txtEstadisticas.Location = new System.Drawing.Point(12, 84);
            this.txtEstadisticas.Multiline = true;
            this.txtEstadisticas.Name = "txtEstadisticas";
            this.txtEstadisticas.Size = new System.Drawing.Size(417, 155);
            this.txtEstadisticas.TabIndex = 4;
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 251);
            this.Controls.Add(this.txtEstadisticas);
            this.Controls.Add(this.cbxAlumnos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAlumnos;
        private System.Windows.Forms.TextBox txtEstadisticas;
    }
}