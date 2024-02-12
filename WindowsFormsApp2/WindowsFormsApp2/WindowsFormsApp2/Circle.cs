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
    public partial class Circle : Form
    {
        public Circle()
        {
            InitializeComponent();
        }

            private void button2_Click(object sender, EventArgs e)
            {
               
            }

            private void button3_Click(object sender, EventArgs e)
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
            public bool printP(int p)
            {
                textBox5.AppendText("__(" + p + ")__");
                textBox5.AppendText("\n");
                return true;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var aBrush = Brushes.White;
                var g = panel1.CreateGraphics();

                int x1 = Convert.ToInt32(textBox1.Text);
                int y1 = Convert.ToInt32(textBox2.Text);

                int r = Convert.ToInt32(textBox3.Text);

                panel1.Controls.Clear();
                this.Refresh();
                circleMidpoint(x1, y1, r);
                drawAxis();



                void circleMidpoint(int xCenter, int yCenter, int radius)
                {
                    textBox5.AppendText("__Circle__");
                    int x = 0;
                    int y = radius;
                    int p = 1 - radius;
                    circlePlotPoints(xCenter, yCenter, x, y);
                    printP(p);
                    while (x < y)
                    {
                        x++;
                        if (p < 0)
                            p += 2 * x + 1;
                        else
                        {
                            y--;
                            p += 2 * (x - y) + 1;
                        }
                        circlePlotPoints(xCenter, yCenter, x, y);
                        printP(p);
                    }
                }
                void circlePlotPoints(int xCenter, int yCenter, int x, int y)
                {
                    setPixel(xCenter + x, yCenter + y);
                    setPixel(xCenter - x, yCenter + y);
                    setPixel(xCenter + x, yCenter - y);
                    setPixel(xCenter - x, yCenter - y);
                    setPixel(xCenter + y, yCenter + x);
                    setPixel(xCenter - y, yCenter + x);
                    setPixel(xCenter + y, yCenter - x);
                    setPixel(xCenter - y, yCenter - x);
                }


            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }



            private void textBox4_TextChanged(object sender, EventArgs e)
            {

            }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            panel1.Invalidate();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
    }
