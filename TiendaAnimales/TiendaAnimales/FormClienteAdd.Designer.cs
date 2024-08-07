
namespace TiendaAnimales
{
    partial class FormClienteAdd
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelProvincia = new System.Windows.Forms.Label();
            this.labelMunicipio = new System.Windows.Forms.Label();
            this.cbxProvincia = new System.Windows.Forms.ComboBox();
            this.cbxMunicipio = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("FiraCode Nerd Font", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(95, 24);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(397, 49);
            this.TitleLabel.TabIndex = 13;
            this.TitleLabel.Text = "AGREGAR CLIENTE";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(642, 120);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(284, 26);
            this.txtPhone.TabIndex = 26;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(597, 123);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(39, 20);
            this.labelPhone.TabIndex = 25;
            this.labelPhone.Text = "Telf.";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(353, 120);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(238, 26);
            this.txtApellidos.TabIndex = 24;
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Location = new System.Drawing.Point(274, 123);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(73, 20);
            this.labelApellidos.TabIndex = 23;
            this.labelApellidos.Text = "Apellidos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 120);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(164, 26);
            this.txtNombre.TabIndex = 22;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(33, 123);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 21;
            this.labelNombre.Text = "Nombre";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(104, 170);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(273, 26);
            this.txtMail.TabIndex = 28;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(32, 173);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(57, 20);
            this.labelMail.TabIndex = 27;
            this.labelMail.Text = "Correo";
            // 
            // labelProvincia
            // 
            this.labelProvincia.AutoSize = true;
            this.labelProvincia.Location = new System.Drawing.Point(383, 173);
            this.labelProvincia.Name = "labelProvincia";
            this.labelProvincia.Size = new System.Drawing.Size(72, 20);
            this.labelProvincia.TabIndex = 29;
            this.labelProvincia.Text = "Provincia";
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.AutoSize = true;
            this.labelMunicipio.Location = new System.Drawing.Point(659, 173);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(75, 20);
            this.labelMunicipio.TabIndex = 30;
            this.labelMunicipio.Text = "Municipio";
            // 
            // cbxProvincia
            // 
            this.cbxProvincia.FormattingEnabled = true;
            this.cbxProvincia.Location = new System.Drawing.Point(461, 170);
            this.cbxProvincia.Name = "cbxProvincia";
            this.cbxProvincia.Size = new System.Drawing.Size(186, 28);
            this.cbxProvincia.TabIndex = 31;
            this.cbxProvincia.SelectedIndexChanged += new System.EventHandler(this.cbxProvincia_SelectedIndexChanged);
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(740, 170);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(186, 28);
            this.cbxMunicipio.TabIndex = 32;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(344, 225);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 37);
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(442, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 37);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TiendaAnimales.Properties.Resources.agregar_usuario;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // FormClienteAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 276);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbxMunicipio);
            this.Controls.Add(this.cbxProvincia);
            this.Controls.Add(this.labelMunicipio);
            this.Controls.Add(this.labelProvincia);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.labelApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormClienteAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelProvincia;
        private System.Windows.Forms.Label labelMunicipio;
        private System.Windows.Forms.ComboBox cbxProvincia;
        private System.Windows.Forms.ComboBox cbxMunicipio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}