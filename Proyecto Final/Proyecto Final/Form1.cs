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
using System.Drawing.Drawing2D;

namespace Proyecto_Final
{


    public partial class PantallaDeJuego : Form
    {
        System.IO.Ports.SerialPort ArduinoPort;
        Vector2 scale = new Vector2(40f, 40f);
        string[] map;
        public float bSize = 100f;
        int[,] refInt;
        public bool showEverything = false;
        public bool win = false;
        Bitmap flecha;

        /// <summary>
        /// method to rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise
        /// negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        public PantallaDeJuego()
        {
            InitializeComponent();

            map = mapPreset();
            for (int i = 0; i < map.Length; i++)
            {
                Console.WriteLine(map[i]);
            }

            McQueen.McQueen(map);
            //MessageBox.Show("" + McQueen.pos);

            if (showEverything)
            {
                blockShow();
                CarShow0.Visible = true;
                CarShow1.Visible = true;
                CarShow2.Visible = true;
                CarShow3.Visible = true;
                label1.Visible = true;
            }


            refInt = new int[,] {
                { 1, 1},
                { 1, 0},
                { 1,-1},
                { 0, 1},
                {-1, 1},
                {-1, 0},
                {-1,-1},
                { 0,-1},
            };

            flecha = new Bitmap(Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "flecha.png")));
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3";  //sustituir por vuestro 
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();
            ArduinoPort.Write("e");
            actualisador.Enabled = true;
            
        }
        Car McQueen = new Car();

        public static string[] mapPreset()//C:\Users\47701283\source\repos\Laberinto\Laberinto\mapas\primerMapa.txt
        {
            //es necesario tener "using System.IO;" para poder usar esta funcion
            string[] array1;
            String line;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "mapaSeleccionado.txt");

            try
            {
                StreamReader sr = new StreamReader(path);
                path = sr.ReadLine();
                sr.Close();
            }
            catch
            {

            }

            try
            {
                
                string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                //Pass the file path and file name to the StreamReader constructor

                StreamReader sr = new StreamReader(Path.Combine(filePath, "mapas", path));
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
                MessageBox.Show("Hubo un error al cargar el mapa. \n Porfavor intente volver a cargar el mapa. \n" + "Excepción: " + e.Message);
            }
            finally
            {
                //MessageBox.Show("Executing finally block.");
            }

            return new string[]
            {
                "█████",
                "█i█f█",
                "█████"
            };
        }


        public void selectColide()
        {
            //int[] posInt = new int[] { };
            //McQueen.colision()

            int[] carPos = new int[]
            {
                Convert.ToInt32(Math.Round(McQueen.pos.X)),
                Convert.ToInt32(Math.Round(McQueen.pos.Y))
            };
            bool n = false;
            string k = " {" + carPos[0] + ", " + carPos[1] + "} " + "{" + McQueen.pos.X + ", " + McQueen.pos.Y + "} \n";
            for (int i = 0 ; i < 8 ; i++)
            {
                int[] blocPos = new int[]
                {
                    refInt[i,0] + carPos[1],
                    refInt[i,1] + carPos[0],
                };
                try
                {
                    Console.WriteLine(blocPos[0] + " " + blocPos[1]);
                    if (map[blocPos[0]][blocPos[1]] == '█' && McQueen.colision(blocPos))
                    {
                        //McQueen.colisionReaction();
                        k = k + " (" + blocPos[1] +", "+ blocPos[0] + ") "; 
                    }
                    else if (map[blocPos[0]][blocPos[1]] == 'f' && McQueen.colision(blocPos))
                    {
                        MessageBox.Show("WON");
                    }
                }
                catch
                {

                }
                
            }
            label1.Text = k;
        }

        public void colisionDetection()
        {
            //int[] posInt = new int[] { };
            //McQueen.colision()

            int[] carPos = new int[]
            {
                Convert.ToInt32(Math.Round(McQueen.pos.X)),
                Convert.ToInt32(Math.Round(McQueen.pos.Y))
            };

            if (map[carPos[1]][carPos[0]]=='f')
            {
                win = true;
                this.Hide();
            }
            String imgPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "bloques", (map[carPos[1]][carPos[0]] + ".png"));
            if (File.Exists(imgPath))
            {
                ShowCurrent.Image = Image.FromFile(imgPath);
                ShowCurrent.Visible = true;
            }
            else
            {
                ShowCurrent.Visible = false;
            }

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);


            Vector2 p0 = Vector2.Transform(McQueen.size, rotate) + (McQueen.pos);
            Vector2 p1 = Vector2.Transform(McQueen.size * new Vector2(1, -1), rotate) + (McQueen.pos);
            Vector2 p2 = Vector2.Transform(McQueen.size * new Vector2(-1, 1), rotate) + (McQueen.pos);
            Vector2 p3 = Vector2.Transform(McQueen.size * new Vector2(-1, -1), rotate) + (McQueen.pos);

            int[,] carPoints = new int[,]
            {
                { Convert.ToInt32(Math.Round(p0.X)) , Convert.ToInt32(Math.Round(p0.Y))},
                { Convert.ToInt32(Math.Round(p1.X)) , Convert.ToInt32(Math.Round(p1.Y))},
                { Convert.ToInt32(Math.Round(p2.X)) , Convert.ToInt32(Math.Round(p2.Y))},
                { Convert.ToInt32(Math.Round(p3.X)) , Convert.ToInt32(Math.Round(p3.Y))}
            };

            McQueen.notMoveSides = new int[] { 0, 0 };

            string f = "Pos: " + carPos[0] + " | " + carPos[1] + "\n";
            for (int i = 0; i < 4; i++)
            {
                f += i + ": " + carPoints[i, 0] + " | " + carPoints[i, 1];
                try
                {
                    if (map[carPoints[i, 1]][carPoints[i, 0]] == '█')
                    {
                        f += " -- ";
                        if(carPos[0] < carPoints[i, 0])
                        {
                            f += "izquierda";
                            McQueen.notMoveSides[0] = 1;
                            //McQueen.pos.X = Convert.ToSingle(carPos[0]) + 0.5f;
                        }
                        if (carPos[0] > carPoints[i, 0])
                        {
                            f += "derecha";
                            McQueen.notMoveSides[0] = -1;
                            //McQueen.pos.X = Convert.ToSingle(carPos[0]) + 0.5f;
                        }
                        if (carPos[1] < carPoints[i, 1])
                        {
                            f += "abajo";
                            McQueen.notMoveSides[1] = 1;
                            //McQueen.pos.X = Convert.ToSingle(carPos[0]) + 0.5f;
                        }
                        if (carPos[1] > carPoints[i, 1])
                        {
                            f += "arriba";
                            McQueen.notMoveSides[1] = -1;
                            //McQueen.pos.X = Convert.ToSingle(carPos[0]) + 0.5f;
                        }
                    }
                }
                catch
                {
                    label1.Text = "" + i + "\n" + carPoints[0,0];
                }
                f += "\n";
            }
            label1.Text = f;

            
        }




        int contador = 0;

        private void Actualisador_Tick(object sender, EventArgs e)
        {
            if (showEverything) { carShow(); } // Muestra el mapa y el auto en la computadora para asegurarme que funcione bien

            ControlUpdateMode(); // Actualisa los controles de Movimiento

            colisionDetection(); // Chequea si el auto esta chocandose

            serialComunication(); // Manda informacion al arduino sobre el movimiento

            McQueen.update(); // Actualisa la posicion del auto

            if (contador == 4) // Cada 40 milisegundos actualisa la brujula
            {
                contador = 0;
                ShowBrujula();
            }
            contador++;
        }
        
        public void serialComunication()
        {
            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);
            float minimoAdelante = 0f;
            
            float vel = Vector2.Dot(McQueen.vel, Vector2.Transform(new Vector2(1, 0), rotate));


            Console.WriteLine("" + vel);
            
            if (vel > minimoAdelante)
            {
                ArduinoPort.Write("w");
            }
            else if (vel < -minimoAdelante)
            {
                ArduinoPort.Write("s");
            }
            else if(McQueen.rotateVelocity > 0)
            {
                ArduinoPort.Write("a");
            }
            else if (McQueen.rotateVelocity < 0)
            {
                ArduinoPort.Write("d");
            }
            else
            {
                ArduinoPort.Write("e");
            }
        }

        public void ShowBrujula()
        {
            Vector2 fpos = new Vector2(200, 0);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);

            fpos = Vector2.Transform(fpos, rotate);

            //pictureBox1.Image = RotateImage(brujula, Convert.ToSingle(180 / Math.PI) * McQueen.rotation + 90);
            pictureBox2.BackgroundImage = RotateImage(flecha, Convert.ToSingle(180 / Math.PI) * McQueen.rotation + 90);

            pictureBox2.Location = new Point(Convert.ToInt32(fpos.X) + this.Size.Width/2 - pictureBox2.Size.Width/2,Convert.ToInt32(fpos.Y) + this.Height/2 - pictureBox2.Size.Height/2);
        }

        public void ControlUpdateMode()
        {
            float v = 0.05f;
            float t = 1.5f;

            if (w)
            {
                McQueen.accelerate += v;
            }
            else if (s)
            {
                McQueen.accelerate -= v;
            }
            else if (a)
            {
                McQueen.rotateVelocity = -t;
            }
            else if (d)
            {
                McQueen.rotateVelocity = t;
            }
            
            if(w && s || !w && !s)
            {
                McQueen.accelerate = 0;
            }
            if(a && d || !a && !d)
            {
                McQueen.rotateVelocity = 0;
            }
        }
        

        public void blockShow()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    String imgPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "bloques",(map[i][j] + ".png"));
                    if (File.Exists(imgPath))
                    {
                        PictureBox pic = new PictureBox();
                        pic.Location = new Point(Convert.ToInt32(scale.X) * j, Convert.ToInt32(scale.Y) * i);
                        pic.BackColor = Color.Black;
                        pic.Name = "pic" + i + "--" + j;
                        pic.Size = new Size(Convert.ToInt32(scale.X), Convert.ToInt32(scale.Y));
                        pic.BackgroundImage = Image.FromFile(imgPath);
                        pic.BackgroundImageLayout.Equals(1);

                        this.Controls.Add(pic);
                    }
                    else if (map[i][j] == 'f' || map[i][j] == 'i')
                    {
                        PictureBox pic = new PictureBox();
                        pic.Location = new Point(Convert.ToInt32(scale.X) * j, Convert.ToInt32(scale.Y) * i);
                        pic.BackColor = Color.Red;
                        pic.Name = "pic" + i + "--" + j;
                        pic.Size = new Size(Convert.ToInt32(scale.X), Convert.ToInt32(scale.Y));

                        this.Controls.Add(pic);
                    }
                }
            }
        }

        public void carShow()
        {

            Vector2 move = new Vector2(15f, 15f);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, McQueen.rotation);

            Vector2 p0 = Vector2.Transform(McQueen.size * scale, rotate) + (McQueen.pos * scale) + move;
            Vector2 p1 = Vector2.Transform(McQueen.size * new Vector2(1, -1) * scale, rotate) + (McQueen.pos * scale) + move;
            Vector2 p2 = Vector2.Transform(McQueen.size * new Vector2(-1, 1) * scale, rotate) + (McQueen.pos * scale) + move;
            Vector2 p3 = Vector2.Transform(McQueen.size * new Vector2(-1, -1) * scale, rotate) + (McQueen.pos * scale) + move;


            CarShow0.Location = new Point(Convert.ToInt32(p0.X), Convert.ToInt32(p0.Y));
            CarShow1.Location = new Point(Convert.ToInt32(p1.X), Convert.ToInt32(p1.Y));
            CarShow2.Location = new Point(Convert.ToInt32(p2.X), Convert.ToInt32(p2.Y));
            CarShow3.Location = new Point(Convert.ToInt32(p3.X), Convert.ToInt32(p3.Y));
        }

        private void CarShow1_Click(object sender, EventArgs e)
        {

        }

        bool w = false;
        bool s = false;
        bool a = false;
        bool d = false;


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            
            if (e.KeyCode == Keys.W)
            {
                w = true;
                
            }
            if (e.KeyCode == Keys.S)
            {
                s = true;

            }
            if (e.KeyCode == Keys.A)
            {
                a = true;

            }
            if (e.KeyCode == Keys.D)
            {
                d = true;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                w = false;

            }
            if (e.KeyCode == Keys.S)
            {
                s = false;

            }
            if (e.KeyCode == Keys.A)
            {
                a = false;

            }
            if (e.KeyCode == Keys.D)
            {
                d = false;

            }
        }

        private void BtnDeRegreso_Click(object sender, EventArgs e)
        {
            this.Hide();
            actualisador.Enabled = false;
            ArduinoPort.Close();
        }

        private void PantallaDeJuego_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Size.Width / 2 - pictureBox1.Size.Width / 2, this.Size.Height / 2 - pictureBox1.Height / 2);
        }

        private void PantallaDeJuego_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ArduinoPort.IsOpen) { ArduinoPort.Close(); }
        }
    }
    public class Car
    {
        public int[] notMoveSides = new int[] { 0, 0 };

        float updateTime = 0.5f; //default time 100 ms

        public Vector2 pos = new Vector2(0f, 0f);
        public Vector2 vel = new Vector2(0f, 0f);
        public float rotateVelocity = 0f; //in radians per update

        Vector2 resistance = new Vector2(0.8f,0.1f);
        
        public float rotation = 0f; //in radians
        private Vector2 s = new Vector2(0.15f, 0.1f);
        public float accelerate = 0f;

        
        public Vector2 size
        {
            get
            {
                return s;
            }
        }
        public void McQueen(string[] map)
        {


            int x = 0;
            int y;
            for (y = 0 ; y < map.Length ; y++)
            {
                x = map[y].IndexOf('i');
                if (x != -1)
                {
                    pos = new Vector2(x, y);
                    
                    return;
                }
            }
            
        }

        public void update()
        {

            

            

            float ninety = Convert.ToSingle((180d / Math.PI) * 90d);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, rotation);

            Quaternion rotate2 = Quaternion.CreateFromYawPitchRoll(0f, 0f, rotation - ninety);

            float dotProduct = Vector2.Dot(vel, Vector2.Transform(new Vector2(1, 0), rotate));

            float dotProduct2 = Vector2.Dot(vel, Vector2.Transform(new Vector2(0, 1), rotate));

            

            //accelerate = 0;



            //Console.WriteLine(vel);

            vel = Vector2.Transform(new Vector2(accelerate, 0), rotate);

            if (Vector2.Dot(new Vector2(notMoveSides[0],notMoveSides[1]),vel) > 0f)
            {
                vel = new Vector2(0, 0);
            }
            
            


            pos += vel * updateTime;
            rotation += rotateVelocity * updateTime;

        }
        public void colisionReaction()
        {

        }
        
        public bool colision(int [] posB)
        {
            float ninety = Convert.ToSingle((180d / Math.PI) * 90d);


            Vector2 blockPos = new Vector2(posB[0], posB[1]);

            Quaternion rotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, rotation);
            Quaternion opositeRotate = Quaternion.CreateFromYawPitchRoll(0f, 0f, -rotation);

            Vector2 pos1 = Vector2.Transform(pos, opositeRotate);
            //Console.WriteLine(rotate + "  " + opositeRotate);

            Vector2 p0 = size; // + pos1;
            Vector2 p1 = size * new Vector2(1f, -1f); // + pos1;
            Vector2 p2 = size * new Vector2(-1f, 1f); // + pos1;
            Vector2 p3 = size * new Vector2(-1f, -1f); // + pos1;


            Vector2 b0 = new Vector2(0.5f, 0.5f) + blockPos - pos;
            Vector2 b1 = new Vector2(0.5f, -0.5f) + blockPos - pos;
            Vector2 b2 = new Vector2(-0.5f, 0.5f) + blockPos - pos;
            Vector2 b3 = new Vector2(-0.5f, -0.5f) + blockPos - pos;





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

            if (IsInside(size, b0) || IsInside(size, b1) || IsInside(size, b2) || IsInside(size, b3))
            {
                return true;
            }

            p0 = Vector2.Transform(size, rotate) - blockPos + pos;
            p1 = Vector2.Transform(size * new Vector2(1, -1), rotate) - blockPos + pos;
            p2 = Vector2.Transform(size * new Vector2(-1, 1), rotate) - blockPos + pos;
            p3 = Vector2.Transform(size * new Vector2(-1, -1), rotate) - blockPos + pos;

            b0 = new Vector2(0.5f, 0.5f) + blockPos;// - McQueen.pos;
            b1 = new Vector2(0.5f, -0.5f) + blockPos;// - McQueen.pos;
            b2 = new Vector2(-0.5f, 0.5f) + blockPos;// - McQueen.pos;
            b3 = new Vector2(-0.5f, -0.5f) + blockPos;// - McQueen.pos;

            Vector2 bSpace = new Vector2(0.5f, 0.5f);

            Console.WriteLine(p3 + "" + b3);

            if (IsInside(bSpace, p0) || IsInside(bSpace, p1) || IsInside(bSpace, p2) || IsInside(bSpace, p3))
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
