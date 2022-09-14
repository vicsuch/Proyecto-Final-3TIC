using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Final
{
    public partial class PantallaDeOpciones : Form
    {
        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mapaSeleccionado.txt");
        public PantallaDeOpciones()
        {
            InitializeComponent();
        }

        private void BtnDeRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PantallaDeOpciones_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog p = new OpenFileDialog();

            string J = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mapas");

            p.InitialDirectory = J;

            p.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            p.ShowDialog();

            if(p.FileName == "")
            {
                return;
            }

            
            J = p.FileName.Replace(J, "");
            J = J.Remove(0,1);
            
            if
            (
                J[J.Length - 1] != 't' ||
                J[J.Length - 2] != 'x' ||
                J[J.Length - 3] != 't' ||
                J[J.Length - 4] != '.' 
            )
            {
                MessageBox.Show("Archivo no valido, por favor que el archivo termine en .txt");
                return;
            }

            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                newTask.WriteLine(J.ToString());

            }


        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenFileDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
