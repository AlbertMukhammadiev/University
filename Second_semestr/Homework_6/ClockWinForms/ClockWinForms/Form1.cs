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

            Timer sec = new Timer();
            sec.Interval = 100;
            sec.Tick += SecHand;
            sec.Enabled = true;


            Timer min = new Timer();
            min.Interval = 6000;
            min.Tick += MinHand;
            min.Enabled = true;

            Timer hour = new Timer();
            hour.Interval = 72000;
            hour.Tick += HourHand;
            hour.Enabled = true;


            initialValues = new InitialValues(ClockFace.Width, ClockFace.Height);
            xPoints = initialValues.GetCoordinatesOfxPoints();
            yPoints = initialValues.GetCoordinatesOfyPoints();
        }

        InitialValues initialValues;
        float[] xPoints;
        float[] yPoints;



        Brush yellow = Brushes.Yellow;
        Brush red = Brushes.Red;
        Brush blue = Brushes.Blue;


        Pen redPen40 = new Pen(Color.Red, 40);
        Pen redPen10 = new Pen(Color.Red, 10);
        Pen secPen = new Pen(Color.Black, 3);
        Pen minPen = new Pen(Color.Gray, 5);
        Pen hourPen = new Pen(Color.White, 10);

        /// <summary>
        /// coordinates of center of the clock face
        /// </summary>
        float x0 = 200;
        float y0 = 200;

        int fi = -90;
        int gamma = -90;
        float cosFi;
        float sinFi;

        float xSec = 200;
        float ySec = 100;
        
        int lengthOfSecHand = 175;

        float xMin = 200;
        float yMin = 100;
        int minRadius = 175;
        
        float xHour = 200;
        float yHour = 100;
        int hourRadius = 175;



        private void Clock(object sender, PaintEventArgs e)
        {
            
            e.Graphics.FillEllipse(yellow, 30, 30, 340, 340);

            e.Graphics.FillEllipse(red, 190, 190, 20, 20);

            

            e.Graphics.FillEllipse(red, 5, 5, 60, 60);

            e.Graphics.FillEllipse(blue, 335, 335, 60, 60);



            e.Graphics.DrawEllipse(redPen40, 30, 30, 340, 340);

            e.Graphics.DrawEllipse(redPen10, 160, 160, 80, 80);

            
            e.Graphics.DrawLine(secPen, x0, y0, xSec, ySec);

            e.Graphics.DrawLine(minPen, x0, y0, xMin, yMin);
            e.Graphics.DrawLine(hourPen, x0, y0, xHour, yHour);

            for (int i = 0; i < 12; ++i)
            {
                e.Graphics.FillEllipse(yellow, xPoints[i], yPoints[i], 10, 10);
            }
        }

        int i = 0;

        private void MinHand(object sender, EventArgs e)
        {
            
            ClockFace.Invalidate();
            gamma += 6;
            cosFi = (float)Math.Cos(((Math.PI * gamma) / 180));
            sinFi = (float)Math.Sin(((Math.PI * gamma) / 180));
            
            xMin = x0 + minRadius * cosFi;
            yMin = y0 + minRadius * sinFi;
        }

        private void HourHand(object sender, EventArgs e)
        {
            ClockFace.Invalidate();
            fi += 6;
            cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
            sinFi = (float)Math.Sin(((Math.PI * fi) / 180));
            xHour = x0 + hourRadius * cosFi;
            yHour = y0 + hourRadius * sinFi;

        }

        private void SecHand(object sender, EventArgs e)
        {
            ClockFace.Invalidate();
            fi += 6;
            float cosFi = (float)Math.Cos(((Math.PI * fi) / 180));
            float sinFi = (float)Math.Sin(((Math.PI * fi) / 180));

            xSec = x0 + lengthOfSecHand * cosFi;
            ySec = y0 + lengthOfSecHand * sinFi;
            ++i;
        }
    }

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

    //-----------------------------------------------------------------------

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
}
