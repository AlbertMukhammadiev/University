using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockWinForms
{
    public class InitialValues
    {
        public InitialValues(float width, float height)
        {
            x0 = width / 2;
            y0 = height / 2;
            smallerSide = width < height ? x0 : y0;
            CreateCoordinatesOfPoints();
            CreateCoordinatesOfHands();
        }

        /// <summary>
        /// coordinates of center of the clock face
        /// </summary>
        public float x0 { get; }
        public float y0 { get; }
        private float smallerSide;

        /// <summary>
        /// methods, that return x2 y2 coordinates of hands and numbers
        /// </summary>
        /// <returns></returns>
        public float[] GetCoordinatesOfxPoints() => xPoints;
        public float[] GetCoordinatesOfyPoints() => yPoints;
        public float[] Get_x2_OfSecHand() => x2_ofSecHand;
        public float[] Get_y2_OfSecHand() => y2_ofSecHand;
        public float[] Get_x2_OfMinuteHand() => x2_ofMinuteHand;
        public float[] Get_y2_OfMinuteHand() => y2_ofMinuteHand;
        public float[] Get_x2_OfHourHand() => x2_ofHourHand;
        public float[] Get_y2_OfHourHand() => y2_ofHourHand;

        /// <summary>
        /// coordinates of points
        /// </summary>
        private float[] xPoints;
        private float[] yPoints;

        /// <summary>
        /// coordinates x2 and y2 of hands
        /// </summary>
        private float[] x2_ofSecHand;
        private float[] y2_ofSecHand;
        private float[] x2_ofMinuteHand;
        private float[] y2_ofMinuteHand;
        private float[] x2_ofHourHand;
        private float[] y2_ofHourHand;

        private void CreateCoordinatesOfPoints()
        {
            xPoints = new float[12];
            yPoints = new float[12];
            int fi = -90;
            float radius = smallerSide * 9 / 10;
            for (int i = 0; i < 12; ++i)
            {
                fi += 30;
                xPoints[i] = x0 + radius * (float)Math.Cos(((Math.PI * fi) / 180)) - 5;
                yPoints[i] = y0 + radius * (float)Math.Sin(((Math.PI * fi) / 180)) - 5;
            }
        }

        private void CreateCoordinatesOfHands()
        {
            x2_ofSecHand = new float[60];
            y2_ofSecHand = new float[60];
            x2_ofMinuteHand = new float[60];
            y2_ofMinuteHand = new float[60];
            x2_ofHourHand = new float[60];
            y2_ofHourHand = new float[60];

            int fi = -90;
            float radius = smallerSide * 9 / 10;
            for (int i = 0; i < 60; ++i)
            {
                x2_ofSecHand[i] = x0 + radius * (float)Math.Cos(((Math.PI * fi) / 180));
                y2_ofSecHand[i] = y0 + radius * (float)Math.Sin(((Math.PI * fi) / 180));
                fi += 6;
            }
            
            fi = -90;
            radius = smallerSide * 8 / 10;
            for (int i = 0; i < 60; ++i)
            {
                x2_ofMinuteHand[i] = x0 + radius * (float)Math.Cos(((Math.PI * fi) / 180));
                y2_ofMinuteHand[i] = y0 + radius * (float)Math.Sin(((Math.PI * fi) / 180));
                fi += 6;
            }

            fi = -90;
            radius = smallerSide * 6 / 10;
            for (int i = 0; i < 60; ++i)
            {
                x2_ofHourHand[i] = x0 + radius * (float)Math.Cos(((Math.PI * fi) / 180));
                y2_ofHourHand[i] = y0 + radius * (float)Math.Sin(((Math.PI * fi) / 180));
                fi += 6;
            }
        }
    }
}
