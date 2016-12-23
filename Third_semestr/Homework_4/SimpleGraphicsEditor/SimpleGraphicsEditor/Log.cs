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
    class Log
    {
        public Log()
        {
            list = new List<Shape>();
        }

        public void Undo()
        {
            if (slide > 0)
            {
                list[slide - 1].ChangeVisibility();
                --slide;
            }
        }

        public void Redo()
        {
            if (slide < list.Count)
            {
                list[slide].ChangeVisibility();
                ++slide;
            }
        }

        public void Add(Shape newShape)
        {
            list.Insert(slide, newShape);
            ++slide;
        }

        public void Remove(Shape newShape)
        {
            list.Remove(newShape);
            newShape.ChangeVisibility();
            list.Add(newShape);
        }

        public void DrawPicture(PaintEventArgs e)
        {
            foreach (Shape element in list)
            {
                element.Draw(e);
            }
        }

        public Point Catch(Point point)
        {
            double distance = int.MaxValue;
            var nearest = 0;

            for (int i = 0; i < list.Count; ++i)
            {
                Point center = new Point();
                center.X = (list[i].parameter.point1.X + list[i].parameter.point2.X) / 2;
                center.Y = (list[i].parameter.point1.Y + list[i].parameter.point2.Y) / 2;
                var dist = Math.Sqrt(Math.Pow(center.X - point.X, 2) + Math.Pow(center.Y - point.Y, 2));
                if (dist <= distance)
                {
                    nearest = i;
                    distance = dist;
                }
            }

            var resultPoint = new Point { X = list[nearest].parameter.point1.X, Y = list[nearest].parameter.point1.Y };
            var shape = list[nearest];
            shape.ChangeVisibility();
            list.Add(shape);
            return resultPoint;
        }

        private int slide;
        private List<Shape> list;
    }
}
