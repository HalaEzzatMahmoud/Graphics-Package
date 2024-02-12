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
    public partial class Transation : Form
    {
        public Transation()
        {
            InitializeComponent();
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
            //var aBrush = Brushes.White;
            //var g = panel1.CreateGraphics();
           // g.FillRectangle(aBrush, origin.X + x, origin.Y - y, 2, 2);
            textBox5.AppendText("(" + x + "," + y + ")");
            return true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
        public void DrawTr(int x,int y ,int x1,int y1,int x2,int y2)
        {
            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            // Transation1(tx, ty);
            drawAxis();


            /* int tx = Convert.ToInt32(textBox1.Text);
             int ty = Convert.ToInt32(textBox2.Text);*/



            /* LineBresenham(x, y, x1, y1);
             LineBresenham(x1, y1, x2, y2);
             LineBresenham(x2, y2, x, y);*/
            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y -  y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y -  y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X +x2, origin.Y - y2, origin.X + x, origin.Y -  y);
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);


        }
        private void button3_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);

            DrawTr(x, y, x1, y1, x2, y2);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int tx = Convert.ToInt32(textBox1.Text);
            int ty = Convert.ToInt32(textBox2.Text);
            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);
           
           //s DrawTr(x, y, x1, y1, x2, y2);
            Transation1(tx, ty, x, y, x1, y1,x2 , y2);



        }
        public void Transiation2(ref int X, ref int Y, int X_Translation, int Y_Translation)
        {
            X += X_Translation;
            Y += Y_Translation;
        }
        public void Transation1(int tx, int ty, int x, int y, int x1, int y1, int x2, int y2)
        {
          
            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black,3);
            Pen pen_draw2 = new Pen(Color.White,4);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            
            drawAxis();

            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);


            Transiation2(ref x, ref y, tx, ty);
            Transiation2(ref x1, ref y1, tx, ty);
            Transiation2(ref x2, ref y2, tx, ty);

            /*LineBresenham(x, y, x1, y1);
            LineBresenham(x1, y1, x2, y2);
            LineBresenham(x2, y2, x, y);*/

            g.DrawLine(pen_draw2, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw2, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw2, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int sx = Convert.ToInt32(textBox4.Text);
            int sy = Convert.ToInt32(textBox5.Text);
            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);

            Scale(sx, sy, x, y, x1, y1, x2, y2);
        }
        public void Scaling(ref int X, ref int Y, int X_Scaling, int Y_Scaling)
        {
            X = X * X_Scaling;
            Y = Y * Y_Scaling;
        }
        public void Scale(int Sx, int Sy, int x, int y, int x1, int y1, int x2, int y2)
        {

            //Transation t = new Transation();
            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black, 3);
            Pen pen_draw2 = new Pen(Color.White, 4);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            // Transation1(tx, ty);
            drawAxis();

            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);

            Scaling(ref x, ref y, Sx, Sy);
            Scaling(ref x1, ref y1, Sx, Sy);
            Scaling(ref x2, ref y2, Sx, Sy);

            /*LineBresenham(x, y, x1, y1);
            LineBresenham(x1, y1, x2, y2);
            LineBresenham(x2, y2, x, y);*/
            g.DrawLine(pen_draw2, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw2, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw2, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);

        }
       
        private void button6_Click_1(object sender, EventArgs e)
        {
            string axis = textBox6.Text;
            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);

            Reflaction(axis, x, y, x1, y1, x2, y2);
        }
        public void Reflaction(string r, int x, int y, int x1, int y1, int x2, int y2)
        {

            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black, 3);
            Pen pen_draw2 = new Pen(Color.White, 4);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();

            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);



            if (r == "x")
            {
                /* LineBresenham(x, -y, x1, -y1);
                 LineBresenham(x1, -y1, x2, -y2);
                 LineBresenham(x2, -y2, x, -y);*/
                g.DrawLine(pen_draw2, origin.X + x, origin.Y -(-y), origin.X + x1, origin.Y - (-y1));
                g.DrawLine(pen_draw2, origin.X + x1, origin.Y - ( -y1), origin.X + x2, origin.Y - (-y2));
                g.DrawLine(pen_draw2, origin.X + x2, origin.Y - (-y2), origin.X + x, origin.Y - (-y));

            }
            else if (r == "y")
            {

                /*LineBresenham(-x, y, -x1, y1);
                LineBresenham(-x1, y1, -x2, y2);
                LineBresenham(-x2, y2, -x, y);*/
                g.DrawLine(pen_draw2, origin.X + (-x), origin.Y - y, origin.X + (-x1), origin.Y - y1);
                g.DrawLine(pen_draw2, origin.X + (-x1), origin.Y - y1, origin.X + (-x2), origin.Y - y2);
                g.DrawLine(pen_draw2, origin.X + (-x2), origin.Y - y2, origin.X + (-x), origin.Y - y);

            }
            else if (r == "o")
            {
                /*LineBresenham(-x, -y, -x1, -y1);
                LineBresenham(-x1, -y1, -x2, -y2);
                LineBresenham(-x2, -y2, -x, -y);*/
                g.DrawLine(pen_draw2, origin.X + (-x), origin.Y - (-y), origin.X + (-x1), origin.Y - (-y1));
                g.DrawLine(pen_draw2, origin.X + (-x1), origin.Y - (-y1), origin.X + (-x2), origin.Y - (-y2));
                g.DrawLine(pen_draw2, origin.X + (-x2), origin.Y - (-y2), origin.X + (-x), origin.Y - (-y));

            }
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int sh = Convert.ToInt32(textBox9.Text);
            string axis = textBox10.Text;
            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);

            Shear(sh, axis, x, y, x1, y1, x2, y2);

        }
        public void Shearing_X(ref int X, ref int Y, int Y_Shearing)
        {
            X = X + Y_Shearing * Y;
            
        }
        public void Shearing_Y(ref int X, ref int Y, int X_Shearing)
        {
           
            Y = X * X_Shearing + Y;
           
        }
        public void Shear(int s, string XorY, int x, int y, int x1, int y1, int x2, int y2)
        {
            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black, 3);
            Pen pen_draw2 = new Pen(Color.White, 4);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();

            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);


            if (XorY == "x")
            {
                Shearing_X(ref x, ref y, s);
                Shearing_X(ref x1, ref y1, s);
                Shearing_X(ref x2, ref y2, s);

            }
            else if (XorY == "y")
            {
                Shearing_Y(ref x, ref y, s);
                Shearing_Y(ref x1, ref y1, s);
                Shearing_Y(ref x2, ref y2, s);
            }

            /* LineBresenham(x, y, x1, y1);
             LineBresenham(x1, y1, x2, y2);
             LineBresenham(x2, y2, x, y);*/
            g.DrawLine(pen_draw2, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw2, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw2, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            double th = Convert.ToDouble(textBox7.Text);
            int x = Convert.ToInt32(textBox16.Text);
            int y = Convert.ToInt32(textBox15.Text);
            int x1 = Convert.ToInt32(textBox14.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox12.Text);
            int y2 = Convert.ToInt32(textBox11.Text);

            Rotation(th, x, y, x1, y1, x2, y2);
        }
        public double Cos(double Angel)
        {
            double angel = Convert.ToInt32(Math.Cos(Math.PI * Angel / 180) * 100);
            angel = Convert.ToDouble(angel / 100);
            return angel;
        }
        public void Rotation1(ref int X, ref int Y, double Angel)
        {

            double x, y, con, sin;
            con = Cos(Angel);
            sin = Math.Sin(Math.PI * Convert.ToDouble(Angel / 180));



            x = (X * con) + (Y * sin);
            y = (X * sin) - (Y * con);

            X = Convert.ToInt32(Math.Round(x));
            Y = Convert.ToInt32(Math.Round(y));

        }
        public void Rotation(double th, int x, int y, int x1, int y1, int x2, int y2)
        {
            var aBrush = Brushes.White;
            Pen pen_draw = new Pen(Color.Black, 3);
            Pen pen_draw2 = new Pen(Color.White, 4);

            var g = panel1.CreateGraphics();

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();

            g.DrawLine(pen_draw, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);

            Rotation1(ref x, ref y, th);
            Rotation1(ref x1, ref y1, th);
            Rotation1(ref x2, ref y2, th);

            /* LineBresenham(x, y, x1, y1);
             LineBresenham(x1, y1, x2, y2);
             LineBresenham(x2, y2, x, y);*/
            g.DrawLine(pen_draw2, origin.X + x, origin.Y - y, origin.X + x1, origin.Y - y1);
            g.DrawLine(pen_draw2, origin.X + x1, origin.Y - y1, origin.X + x2, origin.Y - y2);
            g.DrawLine(pen_draw2, origin.X + x2, origin.Y - y2, origin.X + x, origin.Y - y);
            setPixel(x, y);
            setPixel(x1, y1);
            setPixel(x2, y2);

        }


        private void butten8_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox11.Text = "";
            panel1.Invalidate();
        }

        private void butten8_Click(object sender, EventArgs e)
        {

        }

       
    }
}
