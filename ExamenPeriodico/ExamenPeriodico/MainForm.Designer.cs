
namespace ExamenPeriodico
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.Titlelabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.publicacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("FiraCode Nerd Font", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(102, 237);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(519, 20);
            this.label.TabIndex = 5;
            this.label.Text = "Aplicación para gestionar los datos de un periódico";
            // 
            // Titlelabel
            // 
            this.Titlelabel.AutoSize = true;
            this.Titlelabel.Font = new System.Drawing.Font("Bauhaus 93", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlelabel.Location = new System.Drawing.Point(16, 125);
            this.Titlelabel.Name = "Titlelabel";
            this.Titlelabel.Size = new System.Drawing.Size(754, 108);
            this.Titlelabel.TabIndex = 4;
            this.Titlelabel.Text = "APP PERIODICO";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicacionesToolStripMenuItem,
            this.seccionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(795, 35);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // publicacionesToolStripMenuItem
            // 
            this.publicacionesToolStripMenuItem.Name = "publicacionesToolStripMenuItem";
            this.publicacionesToolStripMenuItem.Size = new System.Drawing.Size(134, 29);
            this.publicacionesToolStripMenuItem.Text = "Publicaciones";
            this.publicacionesToolStripMenuItem.Click += new System.EventHandler(this.publicacionesToolStripMenuItem_Click);
            // 
            // seccionesToolStripMenuItem
            // 
            this.seccionesToolStripMenuItem.Name = "seccionesToolStripMenuItem";
            this.seccionesToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.seccionesToolStripMenuItem.Text = "Secciones";
            this.seccionesToolStripMenuItem.Click += new System.EventHandler(this.seccionesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 343);
            this.Controls.Add(this.label);
            this.Controls.Add(this.Titlelabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem publicacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seccionesToolStripMenuItem;
    }
}

