
namespace TiendaAnimales
{
    partial class FormClienteEdit
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbxMunicipio = new System.Windows.Forms.ComboBox();
            this.cbxProvincia = new System.Windows.Forms.ComboBox();
            this.labelMunicipio = new System.Windows.Forms.Label();
            this.labelProvincia = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(443, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 37);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(345, 227);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 37);
            this.btnGuardar.TabIndex = 49;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(741, 172);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(186, 28);
            this.cbxMunicipio.TabIndex = 48;
            // 
            // cbxProvincia
            // 
            this.cbxProvincia.FormattingEnabled = true;
            this.cbxProvincia.Location = new System.Drawing.Point(462, 172);
            this.cbxProvincia.Name = "cbxProvincia";
            this.cbxProvincia.Size = new System.Drawing.Size(186, 28);
            this.cbxProvincia.TabIndex = 47;
            this.cbxProvincia.SelectedIndexChanged += new System.EventHandler(this.cbxProvincia_SelectedIndexChanged);
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.AutoSize = true;
            this.labelMunicipio.Location = new System.Drawing.Point(660, 175);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(75, 20);
            this.labelMunicipio.TabIndex = 46;
            this.labelMunicipio.Text = "Municipio";
            // 
            // labelProvincia
            // 
            this.labelProvincia.AutoSize = true;
            this.labelProvincia.Location = new System.Drawing.Point(384, 175);
            this.labelProvincia.Name = "labelProvincia";
            this.labelProvincia.Size = new System.Drawing.Size(72, 20);
            this.labelProvincia.TabIndex = 45;
            this.labelProvincia.Text = "Provincia";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(105, 172);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(273, 26);
            this.txtMail.TabIndex = 44;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(33, 175);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(57, 20);
            this.labelMail.TabIndex = 43;
            this.labelMail.Text = "Correo";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(643, 122);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(284, 26);
            this.txtPhone.TabIndex = 42;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(598, 125);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(39, 20);
            this.labelPhone.TabIndex = 41;
            this.labelPhone.Text = "Telf.";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(354, 122);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(238, 26);
            this.txtApellidos.TabIndex = 40;
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Location = new System.Drawing.Point(275, 125);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(73, 20);
            this.labelApellidos.TabIndex = 39;
            this.labelApellidos.Text = "Apellidos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 122);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(164, 26);
            this.txtNombre.TabIndex = 38;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(34, 125);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 37;
            this.labelNombre.Text = "Nombre";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("FiraCode Nerd Font", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(99, 22);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(447, 49);
            this.TitleLabel.TabIndex = 35;
            this.TitleLabel.Text = "MODIFICAR CLIENTE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TiendaAnimales.Properties.Resources.editar_perfil;
            this.pictureBox1.Location = new System.Drawing.Point(16, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // FormClienteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 278);
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
            this.Name = "FormClienteEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbxMunicipio;
        private System.Windows.Forms.ComboBox cbxProvincia;
        private System.Windows.Forms.Label labelMunicipio;
        private System.Windows.Forms.Label labelProvincia;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleLabel;
    }
}