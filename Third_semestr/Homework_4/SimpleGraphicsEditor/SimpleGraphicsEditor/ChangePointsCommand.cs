using LogNamespace;
using ShapeNamespace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphicsEditor
{
    class ChangePointsCommand : ICommand
    {
        private Log log;
        private Shape shape;
        private Point point;
        private Point prevPoint;

        public ChangePointsCommand(Log log, Shape shape, Point point)
        {
            this.log = log;
            this.shape = shape;
            this.point = point;
        }

        public string Name
        {
            get { return "Move"; }
        }

        public void Execute()
        {
            prevPoint = shape.Parameter.start;
            shape.Parameter.move = point;
        }

        public void UnExecute()
        {
            shape.Parameter.move = prevPoint;
        }
    }
}
