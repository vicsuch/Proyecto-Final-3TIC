namespace Proyecto_Final
{
    partial class Form1
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
            this.actualisador = new System.Windows.Forms.Timer(this.components);
            this.CarShow0 = new System.Windows.Forms.PictureBox();
            this.CarShow1 = new System.Windows.Forms.PictureBox();
            this.CarShow2 = new System.Windows.Forms.PictureBox();
            this.CarShow3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow3)).BeginInit();
            this.SuspendLayout();
            // 
            // actualisador
            // 
            this.actualisador.Tick += new System.EventHandler(this.Actualisador_Tick);
            // 
            // CarShow0
            // 
            this.CarShow0.BackColor = System.Drawing.Color.Lime;
            this.CarShow0.Location = new System.Drawing.Point(163, 95);
            this.CarShow0.Name = "CarShow0";
            this.CarShow0.Size = new System.Drawing.Size(10, 10);
            this.CarShow0.TabIndex = 0;
            this.CarShow0.TabStop = false;
            // 
            // CarShow1
            // 
            this.CarShow1.BackColor = System.Drawing.Color.Lime;
            this.CarShow1.Location = new System.Drawing.Point(206, 108);
            this.CarShow1.Name = "CarShow1";
            this.CarShow1.Size = new System.Drawing.Size(10, 10);
            this.CarShow1.TabIndex = 1;
            this.CarShow1.TabStop = false;
            this.CarShow1.Click += new System.EventHandler(this.CarShow1_Click);
            // 
            // CarShow2
            // 
            this.CarShow2.BackColor = System.Drawing.Color.DarkRed;
            this.CarShow2.Location = new System.Drawing.Point(219, 132);
            this.CarShow2.Name = "CarShow2";
            this.CarShow2.Size = new System.Drawing.Size(10, 10);
            this.CarShow2.TabIndex = 2;
            this.CarShow2.TabStop = false;
            // 
            // CarShow3
            // 
            this.CarShow3.BackColor = System.Drawing.Color.DarkRed;
            this.CarShow3.Location = new System.Drawing.Point(163, 160);
            this.CarShow3.Name = "CarShow3";
            this.CarShow3.Size = new System.Drawing.Size(10, 10);
            this.CarShow3.TabIndex = 3;
            this.CarShow3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CarShow3);
            this.Controls.Add(this.CarShow2);
            this.Controls.Add(this.CarShow1);
            this.Controls.Add(this.CarShow0);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CarShow0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer actualisador;
        public System.Windows.Forms.PictureBox CarShow0;
        public System.Windows.Forms.PictureBox CarShow1;
        public System.Windows.Forms.PictureBox CarShow2;
        public System.Windows.Forms.PictureBox CarShow3;
    }
}

