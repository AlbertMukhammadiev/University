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
        public Shape(bool visible, Parameters parameter, PaintEventArgs e)
        {
            this.parameter = parameter;
            this.e = e;
            this.visibility = visible;
        }

        public void ChangeVisibility()
        {
            this.visibility = !this.visibility;
        }

        public abstract void Draw();
        protected bool visibility;
        protected PaintEventArgs e;
        protected Parameters parameter;
    }

    public class Parameters
    {
        public Parameters(Point np1, Point np2, Pen npen)
        {
            this.p1 = np1;
            this.p2 = np2;
            this.pen = npen;
        }

        public Pen pen;
        public Brush brush;
        public Point p1, p2;
    }

    public class Line : Shape
    {
        public Line(bool visible, Parameters parameter, PaintEventArgs e) : base(visible, parameter, e)
        {
            this.parameter = parameter;
            this.e = e;
            this.visibility = visible;
        }

        public override void Draw()
        {
            if (this.visibility)
            {
                e.Graphics.DrawLine(parameter.pen, parameter.p1, parameter.p2);
            }
        }
    }
}
