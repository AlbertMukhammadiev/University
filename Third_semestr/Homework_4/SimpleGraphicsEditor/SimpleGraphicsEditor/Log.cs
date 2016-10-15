using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeNamespace;

namespace LogNamespace
{
    class Log
    {
        public Log()
        {
            list = new List<Shape>();
        }

        public void Add(Shape newShape)
        {
            list.Add(newShape);
        }

        public void Remove(Shape newShape)
        {
            list.Remove(newShape);
            newShape.ChangeVisibility();
            list.Add(newShape);
        }

        public void DrawPicture()
        {
            foreach (Shape element in list)
            {
                element.Draw();
            }
        }

        private List<Shape> list;
    }
}
