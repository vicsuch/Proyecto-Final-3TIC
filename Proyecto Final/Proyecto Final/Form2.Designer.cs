﻿namespace Proyecto_Final
{
    partial class PantallaDeInicio
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
            this.BtnDeJuego = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDeJuego
            // 
            this.BtnDeJuego.Location = new System.Drawing.Point(353, 108);
            this.BtnDeJuego.Name = "BtnDeJuego";
            this.BtnDeJuego.Size = new System.Drawing.Size(75, 23);
            this.BtnDeJuego.TabIndex = 0;
            this.BtnDeJuego.Text = "Jugar";
            this.BtnDeJuego.UseVisualStyleBackColor = true;
            this.BtnDeJuego.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PantallaDeInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnDeJuego);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PantallaDeInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnDeJuego;
    }
}