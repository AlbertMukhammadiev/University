using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeNamespace;
using System.Drawing;
using System.Windows.Forms;

namespace LogNamespace
{
    /// <summary>
    /// the log stores all activities that occur in the picture box
    /// </summary>
    public class Log
    {
        private List<Shape> shapes = new List<Shape>();

        /// <summary>
        /// adds new shape in log
        /// </summary>
        /// <param name="newShape"></param>
        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }

        internal void RemoveLastShape()
        {
            if (shapes.Count == 0) throw new ArgumentException();
            shapes.RemoveAt(shapes.Count - 1);
        }

        public Shape LastShape
        {
            get { return shapes.Count == 0 ? null : shapes[shapes.Count - 1]; }
        }

        public Shape CatchPoint(Point p)
        {
            foreach (var shape in shapes)
            {
                if (shape.IsSeized(p))
                {
                    return shape;
                }
            }

            throw new Exception();
        }

        /// <summary>
        /// draws all the figures from the log
        /// </summary>
        /// <param name="e"></param>
        public void DrawPicture(PaintEventArgs e)
        {
            foreach (Shape element in shapes)
            {
                element.Draw(e);
            }
        }

    }
}
