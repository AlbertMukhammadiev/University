using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ShapeNamespace
{

    public abstract class Shape
    {
        public Shape(bool visible, Parameters parameter)
        {
            this.Parameter = parameter;
        }

        public abstract bool IsSeized(Point p);

        public abstract void Draw(PaintEventArgs e);

        public abstract Shape Copy();

        public Parameters Parameter { get; set; }
    }

    public class Parameters
    {
        public Parameters(Point np1, Point np2, Pen npen)
        {
            this.start = np1;
            this.move = np2;
            this.pen = npen;
        }

        public Pen pen;
        public Brush brush;
        public Point start, move;
    }

    public class Line : Shape
    {
        public Line(bool visible, Parameters parameter) : base(visible, parameter)
        {
            this.Parameter = parameter;
        }

        public override Shape Copy() => new Line(true, this.Parameter);

        public override bool IsSeized(Point p)
        {
            //throw new NotImplementedException();
            var distanceFirst = Math.Sqrt(Math.Pow(p.X - this.Parameter.start.X, 2) + Math.Pow(p.Y - this.Parameter.start.Y, 2));
            var distanceSecond = Math.Sqrt(Math.Pow(p.X - this.Parameter.move.X, 2) + Math.Pow(p.Y - this.Parameter.move.Y, 2));
            var distance = distanceFirst <= distanceSecond ? distanceFirst : distanceSecond;
            if (distanceFirst <= distanceSecond)
            {
                var point = this.Parameter.start;
                this.Parameter.start = this.Parameter.move;
                this.Parameter.move = point;
            }
            return distance < 50;
        }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Parameter.pen, Parameter.start, Parameter.move);
        }
    }
}
