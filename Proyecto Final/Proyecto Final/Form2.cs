using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class PantallaDeInicio : Form
    {
    
        public PantallaDeInicio()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaDeJuego P2 = new PantallaDeJuego();

            P2.ShowDialog();

            try
            {
                if (P2.win)
                {
                    PantallaDeGanar P3 = new PantallaDeGanar();
                    P3.ShowDialog();
                }
            }
            catch
            {

            }

            this.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PantallaDeOpciones P4 = new PantallaDeOpciones();
            P4.ShowDialog();
            this.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            PantallaModoLibre P5 = new PantallaModoLibre();
            this.Hide();
            P5.ShowDialog();
            this.Show();
        }
    }
}
