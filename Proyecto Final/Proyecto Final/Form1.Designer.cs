namespace Proyecto_Final
{
    partial class PantallaDeJuego
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaDeJuego));
            this.actualisador = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDeRegreso = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowCurrent = new System.Windows.Forms.PictureBox();
            this.CarShow3 = new System.Windows.Forms.PictureBox();
            this.CarShow2 = new System.Windows.Forms.PictureBox();
            this.CarShow1 = new System.Windows.Forms.PictureBox();
            this.CarShow0 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // actualisador
            // 
            this.actualisador.Interval = 10;
            this.actualisador.Tick += new System.EventHandler(this.Actualisador_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // BtnDeRegreso
            // 
            this.BtnDeRegreso.Location = new System.Drawing.Point(12, 12);
            this.BtnDeRegreso.Name = "BtnDeRegreso";
            this.BtnDeRegreso.Size = new System.Drawing.Size(75, 23);
            this.BtnDeRegreso.TabIndex = 5;
            this.BtnDeRegreso.TabStop = false;
            this.BtnDeRegreso.Text = "Regresar";
            this.BtnDeRegreso.UseVisualStyleBackColor = true;
            this.BtnDeRegreso.Click += new System.EventHandler(this.BtnDeRegreso_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Proyecto_Final.Properties.Resources.brujula;
            this.pictureBox1.Location = new System.Drawing.Point(297, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ShowCurrent
            // 
            this.ShowCurrent.Location = new System.Drawing.Point(12, 77);
            this.ShowCurrent.Name = "ShowCurrent";
            this.ShowCurrent.Size = new System.Drawing.Size(200, 200);
            this.ShowCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowCurrent.TabIndex = 6;
            this.ShowCurrent.TabStop = false;
            // 
            // CarShow3
            // 
            this.CarShow3.BackColor = System.Drawing.Color.DarkRed;
            this.CarShow3.Location = new System.Drawing.Point(762, 25);
            this.CarShow3.Name = "CarShow3";
            this.CarShow3.Size = new System.Drawing.Size(10, 10);
            this.CarShow3.TabIndex = 3;
            this.CarShow3.TabStop = false;
            this.CarShow3.Visible = false;
            // 
            // CarShow2
            // 
            this.CarShow2.BackColor = System.Drawing.Color.DarkRed;
            this.CarShow2.Location = new System.Drawing.Point(762, 12);
            this.CarShow2.Name = "CarShow2";
            this.CarShow2.Size = new System.Drawing.Size(10, 10);
            this.CarShow2.TabIndex = 2;
            this.CarShow2.TabStop = false;
            this.CarShow2.Visible = false;
            // 
            // CarShow1
            // 
            this.CarShow1.BackColor = System.Drawing.Color.Lime;
            this.CarShow1.Location = new System.Drawing.Point(778, 25);
            this.CarShow1.Name = "CarShow1";
            this.CarShow1.Size = new System.Drawing.Size(10, 10);
            this.CarShow1.TabIndex = 1;
            this.CarShow1.TabStop = false;
            this.CarShow1.Visible = false;
            this.CarShow1.Click += new System.EventHandler(this.CarShow1_Click);
            // 
            // CarShow0
            // 
            this.CarShow0.BackColor = System.Drawing.Color.Lime;
            this.CarShow0.Location = new System.Drawing.Point(778, 12);
            this.CarShow0.Name = "CarShow0";
            this.CarShow0.Size = new System.Drawing.Size(10, 10);
            this.CarShow0.TabIndex = 0;
            this.CarShow0.TabStop = false;
            this.CarShow0.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Proyecto_Final.Properties.Resources.flecha;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(306, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // PantallaDeJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Final.Properties.Resources.fondo_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ShowCurrent);
            this.Controls.Add(this.BtnDeRegreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarShow3);
            this.Controls.Add(this.CarShow2);
            this.Controls.Add(this.CarShow1);
            this.Controls.Add(this.CarShow0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PantallaDeJuego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantallaDeJuego_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox CarShow0;
        public System.Windows.Forms.PictureBox CarShow1;
        public System.Windows.Forms.PictureBox CarShow2;
        public System.Windows.Forms.PictureBox CarShow3;
        public System.Windows.Forms.Timer actualisador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDeRegreso;
        private System.Windows.Forms.PictureBox ShowCurrent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

