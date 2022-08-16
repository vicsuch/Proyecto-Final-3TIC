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
using System.Numerics;

namespace Proyecto_Final
{


    public partial class Form1 : Form
    {

        string[] map;
        public Form1()
        {
            InitializeComponent();
            
            map = mapPreset();
            for(int i = 0; i<11;i++)
            {   
                Console.WriteLine(map[i]);
            }

            McQueen.getInitialPos(map);

        }
        Car McQueen = new Car();
        

        public static string[] mapPreset()//C:\Users\47701283\source\repos\Laberinto\Laberinto\mapas\primerMapa.txt
        {
            //es necesario tener "using System.IO;" para poder usar esta funcion
            string[] array1;
            String line;
            try
            {
                string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mapas\\primerMapa.txt");
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);
                //Read the first line of text
                array1 = new string[Convert.ToInt32(sr.ReadLine())];
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                int i = 0;
                while (line != null)
                {
                    //write the line to console window
                    //MessageBox.Show(line);
                    array1[i] = line;
                    //Read the next line
                    line = sr.ReadLine();
                    i++;
                }
                //close the file
                sr.Close();
                return array1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            finally
            {
                //MessageBox.Show("Executing finally block.");
            }

            return new string[0];
        }
        private void Actualisador_Tick(object sender, EventArgs e)
        {
            CarShow.Location = new System.Drawing.Point(Convert.ToInt32(McQueen.pos.X * -100), Convert.ToInt32(McQueen.pos.Y * -100));
        }
    }
    public class Car
    {
        public Vector2 pos = new Vector2(0f, 0f);
        Vector2 vel = new Vector2(0f, 0f);
        float rotateVelocity = 1f;
        float linearVelocity = 1f;
        float rotacion = 0f;
        private Vector2 s = new Vector2(0.5f, 0.4f);

        
        public Vector2 size
        {
            get
            {
                return s;
            }
        }
        public void getInitialPos(string[] map)
        {
            int x = 0;
            int y;
            for (y = 0 ; y < map.Length ; y++)
            {
                x = map[y].IndexOf('i');
                if (x != -1)
                {
                    pos = new Vector2(x, y);
                }
            }
            pos = new Vector2(-1, -1);
        }
        
    }
}
