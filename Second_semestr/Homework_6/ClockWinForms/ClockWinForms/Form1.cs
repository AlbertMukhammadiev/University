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
            sec.Interval = 1000;
            sec.Tick += SecHand;
            sec.Enabled = true;


            Timer min = new Timer();
            min.Interval = 60000 - localSec * 1000;
            min.Tick += MinHand;
            min.Enabled = true;

            Timer hour = new Timer();
            hour.Interval = 720000 - localMinute * 1000;
            hour.Tick += HourHand;
            hour.Enabled = true;

            secFi = secFi + localSec * 6;
            minFi = minFi + localMinute * 6;
            hourFi = hourFi + (localHour % 12) * 30;

            x2sec = x0 + secHandLength * (float)Math.Cos(((Math.PI * secFi) / 180));
            y2sec = y0 + secHandLength * (float)Math.Sin(((Math.PI * secFi) / 180));

            x2minute = x0 + minuteHandLength * (float)Math.Cos(((Math.PI * minFi) / 180));
            y2minute = y0 + minuteHandLength * (float)Math.Sin(((Math.PI * minFi) / 180));

            x2hour = x0 + hourHandLength * (float)Math.Cos(((Math.PI * hourFi) / 180));
            y2hour = y0 + hourHandLength * (float)Math.Sin(((Math.PI * hourFi) / 180));

            //initialValues = new InitialValues(ClockFace.Width, ClockFace.Height);
            //xPoints = initialValues.GetCoordinatesOfxPoints();
            //yPoints = initialValues.GetCoordinatesOfyPoints();

            //x2Sec = initialValues.Get_x2_OfSecHand();
            //y2Sec = initialValues.Get_y2_OfSecHand();

            //x2Minute = initialValues.Get_x2_OfMinuteHand();
            //y2Minute = initialValues.Get_y2_OfMinuteHand();

            //x2Hour = initialValues.Get_x2_OfHourHand();
            //y2Hour = initialValues.Get_y2_OfHourHand();
        }

        //InitialValues initialValues;
        //float[] xPoints;
        //float[] yPoints;

        //float[] x2Sec;
        //float[] y2Sec;

        ///// <summary>
        ///// coordinates of minute
        ///// </summary>
        //private float[] x2Minute;
        //private float[] y2Minute;

        ///// <summary>
        ///// coordinates of points
        ///// </summary>
        //private float[] x2Hour;
        //private float[] y2Hour;



        Brush yellow = Brushes.Yellow;
        Brush red = Brushes.Red;
        Brush blue = Brushes.Blue;


        Pen redPen40 = new Pen(Color.Red, 40);
        Pen redPen10 = new Pen(Color.Red, 10);
        Pen secPen = new Pen(Color.White, 3);
        Pen minPen = new Pen(Color.DarkBlue, 5);
        Pen hourPen = new Pen(Color.Red, 7);

        /// <summary>
        /// coordinates of center of the clock face
        /// </summary>
        float x0 = 200;
        float y0 = 200;

        float secHandLength = 180;
        float minuteHandLength = 160;
        float hourHandLength = 100;

        private void Clock(object sender, PaintEventArgs e)
        {

            e.Graphics.FillEllipse(yellow, 30, 30, 340, 340);

            e.Graphics.FillEllipse(red, 190, 190, 20, 20);



            e.Graphics.FillEllipse(red, 5, 5, 60, 60);

            e.Graphics.FillEllipse(blue, 335, 335, 60, 60);



            e.Graphics.DrawEllipse(redPen40, 30, 30, 340, 340);

            e.Graphics.DrawEllipse(redPen10, 160, 160, 80, 80);

            e.Graphics.DrawLine(secPen, x0, y0, x2sec, y2sec);
            e.Graphics.DrawLine(minPen, x0, y0, x2minute, y2minute);
            e.Graphics.DrawLine(hourPen, x0, y0, x2hour, y2hour);

            //for (int i = 0; i < 12; ++i)
            //{
            //    e.Graphics.FillEllipse(yellow, xPoints[i], yPoints[i], 10, 10);
            //}
        }

        float x2sec;
        float y2sec;
        float x2minute;
        float y2minute;
        float x2hour;
        float y2hour;

        int localSec = DateTime.Now.Second;
        int localMinute = DateTime.Now.Minute;
        int localHour = DateTime.Now.Hour;

        int secFi = -90;
        int minFi = -90;
        int hourFi = -90;

        private void MinHand(object sender, EventArgs e)
        {
            
            //i = (i + 1) % 60;
            minFi += 6;
            x2minute = x0 + minuteHandLength * (float)Math.Cos(((Math.PI * minFi) / 180));
            y2minute = y0 + minuteHandLength * (float)Math.Sin(((Math.PI * minFi) / 180));
            ClockFace.Invalidate();
        }

        private void HourHand(object sender, EventArgs e)
        {
            //j = (j + 1) % 60;
            hourFi += 30;
            x2hour = x0 + hourHandLength * (float)Math.Cos(((Math.PI * hourFi) / 180));
            y2hour = y0 + hourHandLength * (float)Math.Sin(((Math.PI * hourFi) / 180));
            ClockFace.Invalidate();
        }
        
        private void SecHand(object sender, EventArgs e)
        {
            //k = (k + 1) % 60;
            secFi += 6;
            x2sec = x0 + secHandLength * (float)Math.Cos(((Math.PI * secFi) / 180));
            y2sec = y0 + secHandLength * (float)Math.Sin(((Math.PI * secFi) / 180));
            ClockFace.Invalidate();
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
