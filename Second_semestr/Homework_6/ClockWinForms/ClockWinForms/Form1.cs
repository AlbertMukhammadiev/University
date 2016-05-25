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
            time.Interval = 100;
            time.Tick += Arrow;
            time.Enabled = true;

            Timer time2 = new Timer();
            time2.Interval = 10000;
            time2.Tick += Arrow2;
            time2.Enabled = true;

            Timer time3 = new Timer();
            time3.Interval = 800;
            time3.Tick += Arrow3;
            time3.Enabled = true;
        }

        Pen MyPen = new Pen(Color.DarkSeaGreen, 5);
        float x2 = 200;
        float y2 = 20;
        int fi = -90;
        int r = 175;

        Pen MyPen2 = new Pen(Color.Pink, 10);
        float x22 = 200;
        float y22 = 100;
        int fi2 = -90;
        int r2 = 100;

        Pen MyPen3 = new Pen(Color.DarkOrchid, 2);
        float x23 = 200;
        float y23 = 100;
        int fi3 = -90;
        int r3 = 150;

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


            e.Graphics.DrawEllipse(MyPen, 10, 10, 380, 380);
            e.Graphics.DrawLine(MyPen, 200, 200, x2, y2);
            e.Graphics.DrawLine(MyPen2, 200, 200, x22, y22);
            e.Graphics.DrawLine(MyPen3, 200, 200, x23, y23);
        }


        private void Arrow2(object sender, EventArgs e)
        {

            ClockFace.Invalidate();
            fi2 += 30;
            float cosFi = (float)Math.Cos(((Math.PI * fi2) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi2) / 180));

            x22 = 200 + r2 * cosFi;
            y22 = 200 + r2 * sinFi;
        }

        private void Arrow3(object sender, EventArgs e)
        {

            ClockFace.Invalidate();
            fi3 += 60;
            float cosFi = (float)Math.Cos(((Math.PI * fi3) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi3) / 180));

            x23 = 200 + r3 * cosFi;
            y23 = 200 + r3 * sinFi;

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
    }
}
