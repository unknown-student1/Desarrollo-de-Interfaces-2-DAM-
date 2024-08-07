
namespace ExamenPeriodico
{
    partial class FormPublicaciones
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
            this.dataGridViewPublicaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPublicaciones
            // 
            this.dataGridViewPublicaciones.AllowUserToAddRows = false;
            this.dataGridViewPublicaciones.AllowUserToDeleteRows = false;
            this.dataGridViewPublicaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPublicaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPublicaciones.Location = new System.Drawing.Point(18, 125);
            this.dataGridViewPublicaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewPublicaciones.Name = "dataGridViewPublicaciones";
            this.dataGridViewPublicaciones.ReadOnly = true;
            this.dataGridViewPublicaciones.RowHeadersWidth = 62;
            this.dataGridViewPublicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPublicaciones.Size = new System.Drawing.Size(1164, 592);
            this.dataGridViewPublicaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("FiraCode Nerd Font", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "Publicaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtrar x Seccion";
            // 
            // cbxSecciones
            // 
            this.cbxSecciones.FormattingEnabled = true;
            this.cbxSecciones.Location = new System.Drawing.Point(164, 83);
            this.cbxSecciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(247, 28);
            this.cbxSecciones.TabIndex = 3;
            this.cbxSecciones.SelectedIndexChanged += new System.EventHandler(this.cbxSecciones_SelectedIndexChanged);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(928, 75);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(100, 43);
            this.btnBorrar.TabIndex = 7;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(824, 75);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(99, 43);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(723, 75);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(96, 43);
            this.btnInsertar.TabIndex = 5;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(1036, 75);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(146, 43);
            this.btnMostrar.TabIndex = 8;
            this.btnMostrar.Text = "Mostrar Todo";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // FormPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 735);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPublicaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormPublicaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPublicaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnMostrar;
    }
}