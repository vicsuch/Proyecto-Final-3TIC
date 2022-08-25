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
            for(int i = 0 ; i< map.Length ; i++)
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

            bool u = carColide(new int[] { 10 , 5 });
            //Console.WriteLine("Has colided: " + u + McQueen.pos);
            if (u) { MessageBox.Show(".---.-.-.-" + u); }
            else { McQueen.pos += new Vector2(0.175f, 0.1f); McQueen.rotation += 0.035f; carShow(); }

        }

        public void blockShow()
        {
            
        }

        public void carShow()
        {
            Vector2 scale = new Vector2(40f, 40f);
            Vector2 midle = new Vector2(400,200f);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);

            Vector2 p0 = Vector2.Transform(McQueen.size * scale, rotate) + midle;
            Vector2 p1 = Vector2.Transform(McQueen.size * new Vector2(1, -1) * scale, rotate) + midle;
            Vector2 p2 = Vector2.Transform(McQueen.size * new Vector2(-1, 1) * scale, rotate) + midle;
            Vector2 p3 = Vector2.Transform(McQueen.size * new Vector2(-1, -1) * scale, rotate) + midle;


            CarShow0.Location = new Point(Convert.ToInt32(p0.X), Convert.ToInt32(p0.Y));
            CarShow1.Location = new Point(Convert.ToInt32(p1.X), Convert.ToInt32(p1.Y));
            CarShow2.Location = new Point(Convert.ToInt32(p2.X), Convert.ToInt32(p2.Y));
            CarShow3.Location = new Point(Convert.ToInt32(p3.X), Convert.ToInt32(p3.Y));
        }

        public bool carColide(int[] posB)
        {
            


            float ninety = Convert.ToSingle((180d / Math.PI) * 90d);
            

            Vector2 blockPos = new Vector2(posB[0], posB[1]);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);
            Quaternion opositeRotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, -McQueen.rotation);

            Vector2 pos1 = Vector2.Transform(McQueen.pos, opositeRotate);
            //Console.WriteLine(rotate + "  " + opositeRotate);

            Vector2 p0 = McQueen.size; // + pos1;
            Vector2 p1 = McQueen.size * new Vector2(1f, -1f); // + pos1;
            Vector2 p2 = McQueen.size * new Vector2(-1f, 1f); // + pos1;
            Vector2 p3 = McQueen.size * new Vector2(-1f, -1f); // + pos1;


            Vector2 b0 = new Vector2(0.5f, 0.5f) + blockPos - McQueen.pos;
            Vector2 b1 = new Vector2(0.5f, -0.5f) + blockPos - McQueen.pos;
            Vector2 b2 = new Vector2(-0.5f, 0.5f) + blockPos - McQueen.pos;
            Vector2 b3 = new Vector2(-0.5f, -0.5f) + blockPos - McQueen.pos;

            



            //math-----------------------
            // https://www.omnicalculator.com/math/right-triangle-side-angle#:~:text=If%20you%20have%20the%20hypotenuse,side%20adjacent%20to%20the%20angle.

            //b = c * cos(α)        tan(β) = b / a     β: α = 90 - β



            //p0 = Vector2.Transform(McQueen.size, rotate);// + McQueen.pos;
            //p1 = Vector2.Transform(McQueen.size * new Vector2(1, -1), rotate);// + McQueen.pos;
            //p2 = Vector2.Transform(McQueen.size * new Vector2(-1, 1), rotate);// + McQueen.pos;
            //p3 = Vector2.Transform(McQueen.size * new Vector2(-1, -1), rotate);// + McQueen.pos;

            b0 = Vector2.Transform(b0, opositeRotate);
            b1 = Vector2.Transform(b1, opositeRotate);
            b2 = Vector2.Transform(b2, opositeRotate);
            b3 = Vector2.Transform(b3, opositeRotate);

            if (IsInside(McQueen.size, b0) || IsInside(McQueen.size, b1) || IsInside(McQueen.size, b2) || IsInside(McQueen.size, b3))
            {
                return true;
            }

            p0 = Vector2.Transform(McQueen.size, rotate) - blockPos + McQueen.pos;
            p1 = Vector2.Transform(McQueen.size * new Vector2(1, -1), rotate) - blockPos + McQueen.pos;
            p2 = Vector2.Transform(McQueen.size * new Vector2(-1, 1), rotate) - blockPos + McQueen.pos;
            p3 = Vector2.Transform(McQueen.size * new Vector2(-1, -1), rotate) - blockPos + McQueen.pos;

            b0 = new Vector2(0.5f, 0.5f) + blockPos;// - McQueen.pos;
            b1 = new Vector2(0.5f, -0.5f) + blockPos;// - McQueen.pos;
            b2 = new Vector2(-0.5f, 0.5f) + blockPos;// - McQueen.pos;
            b3 = new Vector2(-0.5f, -0.5f) + blockPos;// - McQueen.pos;

            Vector2 bSpace = new Vector2(0.5f , 0.5f);

            Console.WriteLine(p3 +""+ b3);

            if (IsInside(bSpace, p0) || IsInside(bSpace, p1) || IsInside(bSpace, p2) || IsInside(bSpace, p3))
            {
                return true;
            }



            return false;
        }

        public bool IsInside(Vector2 space, Vector2 point)
        {
            if (point.X <= space.X)
            {
                if (point.Y <= space.Y)
                {
                    if (point.Y >= -space.Y)
                    {
                        if (point.X >= -space.X)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CarShow1_Click(object sender, EventArgs e)
        {

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
                    MessageBox.Show(""+pos);
                }
            }
            pos = new Vector2(-1, -1);
        }

        
        public bool colision(int [] posB)
        {
            pos += new Vector2(3f, 1f);
            float ninety = Convert.ToSingle((180d / Math.PI) * 90d);


            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, rotation);
            Quaternion opositeRotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, -1);

            Vector2 pos1 = Vector2.Transform(pos,opositeRotate);
            Console.WriteLine(rotate + "  " + opositeRotate);

            Vector2 p0 = size + pos1;
            Vector2 p1 = size * new Vector2(1f, -1f) + pos1;
            Vector2 p2 = size * new Vector2(-1f, 1f) + pos1;
            Vector2 p3 = size * new Vector2(-1f, -1f) + pos1;


            Vector2 b0 = new Vector2(0.5f, 0.5f) + new Vector2(posB[0], posB[1]);
            Vector2 b1 = new Vector2(0.5f,- 0.5f) + new Vector2(posB[0], posB[1]);
            Vector2 b2 = new Vector2(- 0.5f, 0.5f) + new Vector2(posB[0], posB[1]);
            Vector2 b3 = new Vector2(- 0.5f,- 0.5f) + new Vector2(posB[0], posB[1]);

            b0 = Vector2.Transform(b0, opositeRotate)-pos1;
            b1 = Vector2.Transform(b1, opositeRotate)-pos1;
            b2 = Vector2.Transform(b2, opositeRotate)-pos1;
            b3 = Vector2.Transform(b3, opositeRotate)-pos1;

            //math-----------------------
            // https://www.omnicalculator.com/math/right-triangle-side-angle#:~:text=If%20you%20have%20the%20hypotenuse,side%20adjacent%20to%20the%20angle.

            //b = c * cos(α)        tan(β) = b / a     β: α = 90 - β

            if (IsInside(size,b0) || IsInside(size, b1) || IsInside(size, b2) || IsInside(size, b3))
            {
                return true;
            }

            p0 = Vector2.Transform(size, rotate) + pos;
            p1 = Vector2.Transform(size * new Vector2(1, -1), rotate) + pos;
            p2 = Vector2.Transform(size * new Vector2(-1, 1), rotate) + pos;
            p3 = Vector2.Transform(size * new Vector2(-1, -1), rotate) + pos;

            Vector2 B = new Vector2(1,1);

            if (IsInside(B, b0) || IsInside(B, b1) || IsInside(B, b2) || IsInside(B, b3))
            {
                return true;
            }




            return false;


        }

        public bool IsInside(Vector2 space , Vector2 point)
        {
            if (point.X<=space.X)
            {
                if(point.Y<=space.Y)
                {
                    if(point.Y>=-space.Y)
                    {
                        if(point.Y>=-space.X)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        


    }
}
