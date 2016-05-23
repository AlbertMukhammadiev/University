using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClockWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            Timer time = new Timer();
            time.Interval = 500;
            time.Tick += Arrow;
            time.Enabled = true;
        }

        Pen MyPen = new Pen(Color.Red, 5);
        float x2 = 175;
        float y2 = 50;
        int fi = -90;
        int r = 125;

        


        ////////public SomeForm()
        ////////{
        ////////    InitializeComponent();

        ////////    bitmap = new Bitmap(picturebox.Width, picturebox.Height);
        ////////    picturebox.Image = bitmap;

        ////////    Timer timer = new Timer();
        ////////    timer.Tick += new EventHandler(performTick);
        ////////    timer.Interval = 10;

        ////////    timer.Start();
        ////////}

        ////////void performTick(object sender, EventArgs e)
        ////////{
        ////////    // Здесь перерисовать bitmap
        ////////    picturebox.Image = bitmap;
        ////////}

        private void Clock(object sender, PaintEventArgs e)
        {
            ////Graphics g;
            ////Bitmap drawing = null;

            ////// шрифт для отображения
            ////Font textFont = new System.Drawing.Font("GOST type B", 14);

            ////SolidBrush textBrush = new System.Drawing.SolidBrush(Color.Green);
            ////StringFormat textFormat = new StringFormat();

            ////// сначала рисуем в битмапе, затем отображаем на экране
            ////drawing = new Bitmap(this.Width, this.Height, e.Graphics);
            ////g = Graphics.FromImage(drawing);

            ////g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ////Rectangle rec = this.ClientRectangle;
            ////// собственно рисование
            //////g.FillRectangle(Brushes.Black, rec);
            ////g.DrawString("string 1", textFont, textBrush, 150, 150);
            ////g.DrawEllipse(new Pen(textBrush), 10, 10, 100, 100);

            ////e.Graphics.DrawImageUnscaled(drawing, 0, 0);
            ////g.Dispose();

            ////time.Interval = 500;
            ////time.Tick += Arrow;
            ////time.Enabled = true;


            e.Graphics.DrawEllipse(MyPen, 10, 10, 380, 380);
            e.Graphics.DrawLine(MyPen, 200, 200, x2, y2);

            



        }




        private void Arrow(object sender, EventArgs e)
        {

            ClockFace.Invalidate();
            fi += 6;
            float cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi) / 180));

            x2 = 200 + r * cosFi;
            y2 = 200 + r * sinFi;

        }

        private void Movement(object sender, EventArgs e)
        {

            fi += 6;
            float cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi) / 180));

            x2 = 200 + r * cosFi;
            y2 = 200 + r * sinFi;
        }
    }
}
