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
    public partial class PantallaModoLibre : Form
    {
        System.IO.Ports.SerialPort ArduinoPort;
        public PantallaModoLibre()
        {
            InitializeComponent();
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3";  //sustituir por vuestro 
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();
            ArduinoPort.Write("e");
        }

        private void PantallaModoLibre_Load(object sender, EventArgs e)
        {

        }

        int direccion = 0;

        private void Teclas(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                ArduinoPort.Write("w");

            }
            if (e.KeyCode == Keys.S)
            {
                ArduinoPort.Write("s");

            }
            if (e.KeyCode == Keys.A)
            {
                ArduinoPort.Write("a");

            }
            if (e.KeyCode == Keys.D)
            {
                ArduinoPort.Write("d");

            }
        }

        private void TeclasUp(object sender, KeyEventArgs e)
        {
            ArduinoPort.Write("e");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
