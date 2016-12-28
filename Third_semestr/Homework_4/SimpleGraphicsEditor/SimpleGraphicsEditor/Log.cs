using System;
using System.Collections.Generic;
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
        /// <summary>
        /// adds new shape in log
        /// </summary>
        /// <param name="newShape"></param>
        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }

        /// <summary>
        /// removes the last shape from the list
        /// </summary>
        public void RemoveLastShape()
        {
            if (shapes.Count == 0) throw new ArgumentException();
            shapes.RemoveAt(shapes.Count - 1);
        }

        /// <summary>
        /// returns the shape which we caught
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Shape Catch(Point p)
        {
            foreach (var shape in shapes)
            {
                if (shape.IsSeized(p))
                {
                    return shape;
                }
            }

            return null;
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

        private List<Shape> shapes = new List<Shape>();
    }
}
