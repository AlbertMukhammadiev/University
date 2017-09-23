using System;
using System.Drawing;

namespace SimpleGraphicsEditor.Models
{
    /// <summary>
    /// this clas represents Line
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="parameter"></param>
        public Line(bool visible, Parameters parameter) : base(visible, parameter)
        {
            this.Parameter = parameter;
        }

        public override bool IsSeized(Point p)
        {
            //throw new NotImplementedException();
            var distanceFirst = Math.Sqrt(Math.Pow(p.X - this.Parameter.Start.X, 2) + Math.Pow(p.Y - this.Parameter.Start.Y, 2));
            var distanceSecond = Math.Sqrt(Math.Pow(p.X - this.Parameter.Move.X, 2) + Math.Pow(p.Y - this.Parameter.Move.Y, 2));
            var distance = distanceFirst <= distanceSecond ? distanceFirst : distanceSecond;
            if (distanceFirst <= distanceSecond)
            {
                var point = this.Parameter.Start;
                this.Parameter.Start = this.Parameter.Move;
                this.Parameter.Move = point;
            }

            return distance < 10;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(Parameter.Pen, Parameter.Start, Parameter.Move);
        }
    }
}
