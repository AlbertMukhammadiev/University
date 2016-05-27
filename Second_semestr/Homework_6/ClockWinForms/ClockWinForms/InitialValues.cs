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

            CreateCoordinatesOfPoints();

            CreateCoordinatesOfHands();
        }

        

        /// <summary>
        /// coordinates of center of the clock face
        /// </summary>
        private float x0;
        private float y0;

        /// <summary>
        /// coordinates of points
        /// </summary>
        private float[] xPoints;
        private float[] yPoints;
        private float radiusPoints;

        /// <summary>
        /// coordinates of sec hand
        /// </summary>
        private float[] x2Sec;
        private float[] y2Sec;
        private float lengthOfSec;

        /// <summary>
        /// coordinates of minute
        /// </summary>
        private float[] x2Minute;
        private float[] y2Minute;
        private float lengthOfMinute;

        /// <summary>
        /// coordinates of points
        /// </summary>
        private float[] x2Hour;
        private float[] y2Hour;
        private float lengthOfHour;

        private void CreateCoordinatesOfPoints()
        {
            xPoints = new float[12];
            yPoints = new float[12];
            int fi = 0;
            xPoints[0] = x0 - 5;
            yPoints[0] = y0 / 10 - 5;
            radiusPoints = y0 - yPoints[0];
            for (int i = 0; i < 12; ++i)
            {
                fi += 30;
                xPoints[i] = x0 + radiusPoints * (float)Math.Cos(((Math.PI * fi) / 180)) - 5;
                yPoints[i] = y0 + radiusPoints * (float)Math.Sin(((Math.PI * fi) / 180)) - 5;
            }
        }

        private void CreateCoordinatesOfHands()
        {
            x2Sec = new float[60];
            y2Sec = new float[60];
            int fi = -90;
            x2Sec[0] = x0;
            y2Sec[0] = y0 / 8;
            lengthOfSec = y0 - y2Sec[0];
            for (int i = 0; i < 60; ++i)
            {
                fi += 24;
                x2Sec[i] = x0 + lengthOfSec * (float)Math.Cos(((Math.PI * fi) / 180));
                y2Sec[i] = y0 + lengthOfSec * (float)Math.Sin(((Math.PI * fi) / 180));
            }

            x2Minute = new float[60];
            y2Minute = new float[60];
            fi = -90;
            x2Minute[0] = x0;
            y2Minute[0] = y0 / 8;
            lengthOfMinute = y0 - y2Minute[0];
            for (int i = 0; i < 60; ++i)
            {
                fi += 6;
                x2Minute[i] = x0 + lengthOfMinute * (float)Math.Cos(((Math.PI * fi) / 180));
                y2Minute[i] = y0 + lengthOfMinute * (float)Math.Sin(((Math.PI * fi) / 180));
            }

            x2Hour = new float[60];
            y2Hour = new float[60];
            fi = -90;
            x2Hour[0] = x0;
            y2Hour[0] = y0 / 8;
            lengthOfHour = y0 - y2Hour[0];
            for (int i = 0; i < 60; ++i)
            {
                fi += 6;
                x2Hour[i] = x0 + lengthOfHour * (float)Math.Cos(((Math.PI * fi) / 180));
                y2Hour[i] = y0 + lengthOfHour * (float)Math.Sin(((Math.PI * fi) / 180));
            }
        }

        public float[] GetCoordinatesOfxPoints() => xPoints;
        public float[] GetCoordinatesOfyPoints() => yPoints;

        public float[] Get_x2_OfSecHand() => x2Sec;
        public float[] Get_y2_OfSecHand() => y2Sec;

        public float[] Get_x2_OfMinuteHand() => x2Minute;
        public float[] Get_y2_OfMinuteHand() => y2Minute;

        public float[] Get_x2_OfHourHand() => x2Hour;
        public float[] Get_y2_OfHourHand() => y2Hour;
    }
}
