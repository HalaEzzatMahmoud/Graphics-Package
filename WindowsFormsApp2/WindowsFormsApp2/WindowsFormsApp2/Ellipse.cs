using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Ellipse : Form
    {
        public Ellipse()
        {
            InitializeComponent();
        }

            private void button2_Click(object sender, EventArgs e)
            {
               
            }
            public Point origin = new Point(300, 300);
            public void drawAxis()
            {

                var g = panel1.CreateGraphics();
                Point p1 = new Point(origin.X - 300, origin.Y);
                Point p2 = new Point(origin.X + 300, origin.Y);
                Point p3 = new Point(origin.X, origin.Y - 300);
                Point p4 = new Point(origin.X, origin.Y + 300);
                Pen p = new Pen(Color.Black);
                g.DrawLine(p, p1, p2);
                g.DrawLine(p, p3, p4);

            }
            public bool setPixel(int x, int y)
            {
                var aBrush = Brushes.White;
                var g = panel1.CreateGraphics();
                g.FillRectangle(aBrush, origin.X + x, origin.Y - y, 2, 2);
                textBox5.AppendText("(" + x + "," + y + ")");
                return true;
            }
            public bool printP(int p, int temp)
            {
                if (temp == 0)
                {
                    textBox5.AppendText("P1 = " + p + "__");
                }
                else
                {
                    textBox5.AppendText("P2 = " + p + "__");
                }
                return true;
            }



            private void button1_Click(object sender, EventArgs e)
            {
                var aBrush = Brushes.White;
                var g = panel1.CreateGraphics();

                int x1 = Convert.ToInt32(textBox1.Text);
                int y1 = Convert.ToInt32(textBox2.Text);

                int r1 = Convert.ToInt32(textBox3.Text);
                int r2 = Convert.ToInt32(textBox4.Text);

                panel1.Controls.Clear();
                this.Refresh();
                ellipseMidpoint(x1, y1, r1, r2);
                drawAxis();




                void ellipseMidpoint(int xCenter, int yCenter, int rx, int ry)
                {

                    textBox5.AppendText("__Ellipse__");
                    int temp = 0;
                    int x = 0;
                    int y = ry;
                    int Rx = rx * rx;
                    int Ry = ry * ry;
                    int dx = 0; // 2rx^y 
                    int dy = 2 * Rx * y;
                    ellipsePlotPoints(xCenter, yCenter, x, y);
                    int p1 = (int)Math.Round(Ry - (Rx * ry) + (0.25 * Rx));
                    printP(p1, temp);
                    while (dx < dy)
                    {
                        x++;
                        dx += 2 * Ry;
                        if (p1 < 0)
                        {
                            p1 += dx + Ry;
                        }
                        else
                        {
                            y--;
                            dy -= 2 * Rx;
                            p1 += dy - dx + Ry;
                        }
                        ellipsePlotPoints(xCenter, yCenter, x, y);
                        printP(p1, temp);
                    }
                    double X2 = (x + 0.5) * (x + 0.5);
                    int Y2 = (y - 1) * (y - 1);
                    temp = 1;
                    int p2 = (int)Math.Round(Ry * X2 + Rx * Y2 - Rx * Ry);
                    printP(p2, temp);
                    while (y > 0)
                    {
                        y--;
                        dy -= 2 * Rx;
                        if (p2 > 0)
                            p2 += Rx - dy;
                        else
                        {
                            x++;
                            dx += 2 * Ry;
                            p2 += Rx - dy + dx;
                        }
                        ellipsePlotPoints(xCenter, yCenter, x, y);
                        printP(p2, temp);
                    }
                }

                void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
                {
                    setPixel(xCenter + x, yCenter + y);
                    setPixel(xCenter - x, yCenter + y);
                    setPixel(xCenter + x, yCenter - y);
                    setPixel(xCenter - x, yCenter - y);
                }



            }
          
           

        private void button3_Click_2(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            panel1.Invalidate();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
    }

