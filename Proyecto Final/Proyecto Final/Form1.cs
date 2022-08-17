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
        public float bSize = 100f;
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
            carShow();
            Console.WriteLine("Has colided: " + McQueen.colision(new int[] {200,100}) + McQueen.pos);
        }
        public void carShow()
        {
            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);
            Vector2 p0 = Vector2.Transform(McQueen.size * bSize, rotate) + McQueen.pos;
            Vector2 p1 = Vector2.Transform(McQueen.size * new Vector2(bSize,-bSize), rotate) + McQueen.pos;
            Vector2 p2 = Vector2.Transform(McQueen.size * new Vector2(-bSize, bSize), rotate) + McQueen.pos;
            Vector2 p3 = Vector2.Transform(McQueen.size * new Vector2(-bSize, -bSize), rotate) + McQueen.pos;


            CarShow0.Location = new Point(Convert.ToInt32(p0.X), Convert.ToInt32(p0.Y));
            CarShow1.Location = new Point(Convert.ToInt32(p1.X), Convert.ToInt32(p1.Y));
            CarShow2.Location = new Point(Convert.ToInt32(p2.X), Convert.ToInt32(p2.Y));
            CarShow3.Location = new Point(Convert.ToInt32(p3.X), Convert.ToInt32(p3.Y));
        }
    }
    public class Car
    {
        public Vector2 pos = new Vector2(0f, 0f);
        Vector2 vel = new Vector2(0f, 0f);
        float rotateVelocity = 1f;
        float linearVelocity = 1f;
        public float rotation = 0f;
        private Vector2 s = new Vector2(0.25f, 0.2f);

        
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

        public bool colision(int [] posB)
        {
            pos += new Vector2(2f, 1f);
            

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, rotation);
            Vector2 p0 = Vector2.Transform(size, rotate) + pos;
            Vector2 p1 = Vector2.Transform(size * new Vector2(1f, -1f), rotate) + pos;
            Vector2 p2 = Vector2.Transform(size * new Vector2(-1f, 1f), rotate) + pos;
            Vector2 p3 = Vector2.Transform(size * new Vector2(-1f, -1f), rotate) + pos;

            Vector2 b0 = new Vector2(posB[0] + 0.5f, posB[1] + 0.5f);
            Vector2 b1 = new Vector2(posB[0] + 0.5f, posB[1] - 0.5f);
            Vector2 b2 = new Vector2(posB[0] - 0.5f, posB[1] + 0.5f);
            Vector2 b3 = new Vector2(posB[0] - 0.5f, posB[1] - 0.5f);

            Console.WriteLine(Math.Atan(b0.Y / b0.X));

            if (Math.Atan(b0.Y / b0.X)> 1.5708f || Math.Atan(b0.Y / b0.X) < -1.5708f)
            {
                
                return true;
            }

            

            //rotation += 0.1f;

            return false;
        }
        
    }
}
