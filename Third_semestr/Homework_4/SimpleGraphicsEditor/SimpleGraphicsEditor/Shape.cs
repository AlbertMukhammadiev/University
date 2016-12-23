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
            this.parameter = parameter;
            this.visibility = visible;
        }

        public void ChangeVisibility()
        {
            this.visibility = !this.visibility;
        }

        public abstract void Draw(PaintEventArgs e);

        public abstract Shape Copy();

        public int movedFrom { get; set; } = -1;
        public bool moved { get; set; } = false;
        protected bool visibility;
        public Parameters parameter { get; set; }
    }

    public class Parameters
    {
        public Parameters(Point np1, Point np2, Pen npen)
        {
            this.point1 = np1;
            this.point2 = np2;
            this.pen = npen;
        }

        public Pen pen;
        public Brush brush;
        public Point point1, point2;
    }

    public class Line : Shape
    {
        public Line(bool visible, Parameters parameter) : base(visible, parameter)
        {
            this.parameter = parameter;
            this.visibility = visible;
        }

        public override Shape Copy() => new Line(true, this.parameter);
    
        public override void Draw(PaintEventArgs e)
        {
            if (this.visibility)
            {
                e.Graphics.DrawLine(parameter.pen, parameter.point1, parameter.point2);
            }
        }
    }
}
