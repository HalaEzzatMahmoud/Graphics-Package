using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class formLine : Form
    {
        public formLine()
        {
            InitializeComponent();
        }

            private void Form1_Load(object sender, EventArgs e)
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
            public void lineDDA(int x0, int y0, int xEnd, int yEnd)
            {

                textBox5.AppendText("__DDA__");
                int dx = xEnd - x0, dy = yEnd - y0, steps, k;

                float xIncrement, yIncrement, x = x0, y = y0;

                if (Math.Abs(dx) > Math.Abs(dy))
                    steps = Math.Abs(dx);
                else
                    steps = Math.Abs(dy);

                xIncrement = (float)(dx) / (float)(steps);
                yIncrement = (float)(dy) / (float)(steps);
                setPixel((int)Math.Round(x), (int)Math.Round(y));
                for (k = 0; k < steps; k++)
                {
                    x += xIncrement;
                    y += yIncrement;
                    setPixel((int)(Math.Round(x)), (int)(Math.Round(y)));
                }

            }
            public void LineBresenham(int x0, int y0, int xEnd, int yEnd)
            {


                int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
                int x, y, p = 2 * dy - dx;
                int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);
                float slope = (float)(yEnd - y0) / (float)(xEnd - x0); ;
                setPixel(x0, y0);
                printP(p);

                if (slope <= 1 && slope >= 0)
                {

                    if (x0 < xEnd)
                    {

                        textBox5.AppendText("____Bresenham Octant 1____");
                        x = x0; y = y0;

                        while (x < xEnd)
                        {
                            x++;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y++;
                                p += twoDyMinusDx;
                            }

                            setPixel(x, y);
                            printP(p);
                        }
                    }
                    else if (x0 > xEnd)
                    {

                        textBox5.AppendText("____Bresenham Octant 5____");
                        dx = -(xEnd - x0);
                        dy = -(yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (x0 > xEnd)
                        {
                            x0--;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0--;
                                p += twoDyMinusDx;
                            }
                            setPixel(x0, y0);
                            printP(p);
                        }
                    }
                }




                else if (slope > 1)
                {
                    if (y0 < yEnd)
                    {


                        textBox5.AppendText("____Bresenham Octant 2____");
                        int temp = x0;
                        x0 = y0;
                        y0 = temp;
                        int ytemp = xEnd;
                        xEnd = yEnd;
                        yEnd = ytemp;
                        dx = (xEnd - x0);
                        dy = (yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);

                        while (x0 < xEnd)
                        {
                            x0++;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0++;
                                p += twoDyMinusDx;
                            }

                            setPixel(y0, x0);
                            printP(p);
                        }
                    }
                    else if (y0 > yEnd)
                    {
                        textBox5.AppendText("____Bresenham Octant 6____");
                        int temp = x0;
                        x0 = y0;
                        y0 = temp;
                        int ytemp = xEnd;
                        xEnd = yEnd;
                        yEnd = ytemp;
                        dx = -(xEnd - x0);
                        dy = -(yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (xEnd < x0)
                        {
                            x0--;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0--;
                                p += twoDyMinusDx;
                            }

                            setPixel(y0, x0);
                            printP(p);
                        }
                    }
                }
                else if (slope < -1)
                {
                    if (y0 < yEnd)
                    {


                        textBox5.AppendText("____Bresenham Octant 3____");
                        int temp = x0;
                        x0 = y0;
                        y0 = temp;
                        int ytemp = xEnd;
                        xEnd = yEnd;
                        yEnd = ytemp;
                        dx = (xEnd - x0);
                        dy = -(yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (x0 < xEnd)
                        {
                            x0++;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0--;
                                p += twoDyMinusDx;
                            }
                            setPixel(y0, x0);
                            printP(p);
                        }
                    }
                    else if (y0 > yEnd)
                    {

                        textBox5.AppendText("____Bresenham Octant 7____");
                        int temp = x0;
                        x0 = y0;
                        y0 = temp;
                        int ytemp = xEnd;
                        xEnd = yEnd;
                        yEnd = ytemp;
                        dx = -(xEnd - x0);
                        dy = (yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (x0 > xEnd)
                        {
                            x0--;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0++;
                                p += twoDyMinusDx;
                            }
                            setPixel(y0, x0);
                            printP(p);
                        }
                    }
                }

                else if (slope < 0 && slope > -1)
                {
                    if (x0 < xEnd)
                    {

                        textBox5.AppendText("____Bresenham Octant 4____");
                        dx = (xEnd - x0);
                        dy = -(yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (x0 < xEnd)
                        {
                            x0++;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0--;
                                p += twoDyMinusDx;
                            }
                            setPixel(x0, y0);
                            printP(p);
                        }
                    }

                    else if (x0 > xEnd)
                    {

                        textBox5.AppendText("____Bresenham Octant 8____");
                        dx = -(xEnd - x0);
                        dy = (yEnd - y0);
                        p = 2 * dy - dx;
                        twoDy = 2 * dy;
                        twoDyMinusDx = 2 * (dy - dx);
                        while (x0 > xEnd)
                        {
                            x0--;
                            if (p < 0)
                                p += twoDy;
                            else
                            {
                                y0++;
                                p += twoDyMinusDx;
                            }
                            setPixel(x0, y0);
                            printP(p);
                        }
                    }
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {


                var aBrush = Brushes.White;
                var g = panel1.CreateGraphics();

                int x1 = Convert.ToInt32(textBox1.Text);
                int y1 = Convert.ToInt32(textBox2.Text);

                int x2 = Convert.ToInt32(textBox3.Text);
                int y2 = Convert.ToInt32(textBox4.Text);

                panel1.Controls.Clear();
                this.Refresh();

                if (radioButton1.Checked == true)
                {
                    lineDDA(x1, y1, x2, y2);
                    drawAxis();

                }
                if (radioButton2.Checked == true)
                {
                    LineBresenham(x1, y1, x2, y2);
                    drawAxis();
                }


            }



            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void DDA_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {
               
            }

            private void textBox5_TextChanged_1(object sender, EventArgs e)
            {

            }

            private void label9_Click(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {


            }

            private void label11_Click(object sender, EventArgs e)
            {

            }

            private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {
            }

            private void button3_Click_1(object sender, EventArgs e)
            {
               
            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {

            }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            panel1.Invalidate();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
    }


