using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapeNamespace
{
    public abstract class Shape
    {
        public abstract void Draw();

        private List<Point> coordinates = new List<Point>();
    }

    public class Line : Shape
    {
        public override void Draw()
        {

        }


    }
}
