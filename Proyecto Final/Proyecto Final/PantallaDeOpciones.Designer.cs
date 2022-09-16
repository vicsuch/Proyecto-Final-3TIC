namespace Proyecto_Final
{
    partial class PantallaDeOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaDeOpciones));
            this.BtnDeRegresar = new System.Windows.Forms.Button();
            this.BtnDeSeleccionarMapa = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnDeRegresar
            // 
            this.BtnDeRegresar.Location = new System.Drawing.Point(12, 12);
            this.BtnDeRegresar.Name = "BtnDeRegresar";
            this.BtnDeRegresar.Size = new System.Drawing.Size(75, 23);
            this.BtnDeRegresar.TabIndex = 0;
            this.BtnDeRegresar.Text = "Regresar";
            this.BtnDeRegresar.UseVisualStyleBackColor = true;
            this.BtnDeRegresar.Click += new System.EventHandler(this.BtnDeRegresar_Click);
            // 
            // BtnDeSeleccionarMapa
            // 
            this.BtnDeSeleccionarMapa.Location = new System.Drawing.Point(93, 12);
            this.BtnDeSeleccionarMapa.Name = "BtnDeSeleccionarMapa";
            this.BtnDeSeleccionarMapa.Size = new System.Drawing.Size(115, 23);
            this.BtnDeSeleccionarMapa.TabIndex = 1;
            this.BtnDeSeleccionarMapa.Text = "Opciones";
            this.BtnDeSeleccionarMapa.UseVisualStyleBackColor = true;
            this.BtnDeSeleccionarMapa.Click += new System.EventHandler(this.Button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PantallaDeOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources.fondo_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.BtnDeSeleccionarMapa);
            this.Controls.Add(this.BtnDeRegresar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaDeOpciones";
            this.Text = "PantallaDeOpciones";
            this.Load += new System.EventHandler(this.PantallaDeOpciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnDeRegresar;
        private System.Windows.Forms.Button BtnDeSeleccionarMapa;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}