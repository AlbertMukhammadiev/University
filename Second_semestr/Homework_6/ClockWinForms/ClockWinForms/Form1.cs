using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ClockWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            i = DateTime.Now.Second;
            j = DateTime.Now.Minute;
            k = (DateTime.Now.Hour) % 12 * 5 + j / 10;

            initialValues = new InitialValues(ClockFace.Width, ClockFace.Height);
            xPoints = initialValues.GetCoordinatesOfxPoints();
            yPoints = initialValues.GetCoordinatesOfyPoints();

            x2Sec = initialValues.Get_x2_OfSecHand();
            y2Sec = initialValues.Get_y2_OfSecHand();

            x2Minute = initialValues.Get_x2_OfMinuteHand();
            y2Minute = initialValues.Get_y2_OfMinuteHand();

            x2Hour = initialValues.Get_x2_OfHourHand();
            y2Hour = initialValues.Get_x2_OfHourHand();

            Timer sec = new Timer();
            sec.Interval = 990;
            sec.Tick += SecHand;
            sec.Enabled = true;

            Timer min = new Timer();
            min.Interval = 60000;
            min.Tick += MinHand;
            min.Enabled = true;

            Timer hour = new Timer();
            hour.Interval = 5 * min.Interval;
            hour.Tick += HourHand;
            hour.Enabled = true;

            sec.Start();
            min.Start();
            hour.Start();
        }

        InitialValues initialValues;
        float[] xPoints;
        float[] yPoints;

        /// <summary>
        /// 
        /// </summary>
        float[] x2Sec;
        float[] y2Sec;

        /// <summary>
        /// coordinates of minute
        /// </summary>
        private float[] x2Minute;
        private float[] y2Minute;

        /// <summary>
        /// coordinates of points
        /// </summary>
        private float[] x2Hour;
        private float[] y2Hour;



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


        private void Clock(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(yellow, 30, 30, 340, 340);

            e.Graphics.FillEllipse(red, 190, 190, 20, 20);



            e.Graphics.FillEllipse(red, 5, 5, 60, 60);

            e.Graphics.FillEllipse(blue, 335, 335, 60, 60);



            e.Graphics.DrawEllipse(redPen40, 30, 30, 340, 340);

            e.Graphics.DrawEllipse(redPen10, 160, 160, 80, 80);

            e.Graphics.DrawLine(secPen, x0, y0, x2Sec[i], y2Sec[i]);
            e.Graphics.DrawLine(minPen, x0, y0, x2Minute[j], y2Minute[j]);
            e.Graphics.DrawLine(hourPen, x0, y0, x2Hour[k], y2Hour[k]);

            for (int i = 0; i < 12; ++i)
            {
                e.Graphics.FillEllipse(yellow, xPoints[i], yPoints[i], 10, 10);
            }
        }

        int i;
        int j;
        int k;

        private void HourHand(object sender, EventArgs e)
        {
            k = (k + 1) % 60;
        }

        private void MinHand(object sender, EventArgs e)
        {
            j = (j + 1) % 60;
        }

        private void SecHand(object sender, EventArgs e)
        {
            i = (i + 1) % 60;
            ClockFace.Invalidate();
        }
    }
}