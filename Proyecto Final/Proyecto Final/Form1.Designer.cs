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
            this.CarShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CarShow)).BeginInit();
            this.SuspendLayout();
            // 
            // actualisador
            // 
            this.actualisador.Enabled = true;
            this.actualisador.Tick += new System.EventHandler(this.Actualisador_Tick);
            // 
            // CarShow
            // 
            this.CarShow.BackColor = System.Drawing.Color.DarkRed;
            this.CarShow.Location = new System.Drawing.Point(163, 95);
            this.CarShow.Name = "CarShow";
            this.CarShow.Size = new System.Drawing.Size(50, 100);
            this.CarShow.TabIndex = 0;
            this.CarShow.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CarShow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CarShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer actualisador;
        private System.Windows.Forms.PictureBox CarShow;
    }
}

