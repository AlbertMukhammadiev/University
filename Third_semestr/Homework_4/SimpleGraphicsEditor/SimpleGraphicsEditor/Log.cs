using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SimpleGraphicsEditor;

namespace LogNamespace
{
    public class Shape
    {
        public Shape(Point p1, Point p2, Log log)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Point p1 { get; set; }
        public Point p2 { get; set; }

        public delegate void DrawShape(Pen pen, Point pt1, Point pt2);
        public DrawShape draw;
    }

    public class Line : Shape
    {
        public Line(Point p1, Point p2, Log log) : base(p1, p2, log)
        {
            draw = Graphics.FromImage(log.bitmap).DrawLine;
        }
    }

    public class Log
    {
        public Log(int width, int height)
        {
            list = new List<Shape>();
            del = new List<int>();
            real = new List<int>();

            bitmap = new Bitmap(width, height);
        }

        public void AddShape(Shape shape)
        {
            list.Add(shape);
            real.Add(position);
            ++position;
            step = 0;
        }

        public void RemoveShape(Shape shape)
        {
            list.Add(shape);
            del.Add(position);
            ++position;
        }

        public void Undo()
        {
            
            del.Add(position - step - 1);
            real.Remove(position - step - 1);
            ++step;
        }

        public void Redo()
        {
            del.Add(position + step - 1);
            real.Remove(position + step - 1);
            --step;
        }

        public Bitmap GetBitmap()
        {
            foreach (int i in del)
            {
                list[i].draw(Pens.White, list[i].p1, list[i].p2);
            }


            foreach (int j in real)
            {
                list[j].draw(Pens.Black, list[j].p1, list[j].p2);
            }

            return bitmap;
        }

        private int step;
        private List<int> del;
        private List<int> real;
        private List<Shape> list;
        private int position;
        public Bitmap bitmap { get; }
    }
}