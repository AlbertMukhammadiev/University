using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShapeNamespace
{
    /// <summary>
    /// this class represents the shape
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// class constuctor
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="parameter"></param>
        public Shape(bool visible, Parameters parameter)
        {
            this.Parameter = parameter;
        }

        /// <summary>
        /// checks if the shape is caught
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract bool IsSeized(Point p);

        /// <summary>
        /// the shape paints itself
        /// </summary>
        /// <param name="e"></param>
        public abstract void Draw(PaintEventArgs e);

        /// <summary>
        /// some parameters of shape
        /// </summary>
        public Parameters Parameter { get; set; }
    }

    public class Parameters
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="npen"></param>
        public Parameters(Point point1, Point point2, Pen npen)
        {
            this.Start = point1;
            this.Move = point2;
            this.Pen = npen;
        }

        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; set; }
        public Point Move { get; set; }
    }

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

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Parameter.Pen, Parameter.Start, Parameter.Move);
        }
    }
}
