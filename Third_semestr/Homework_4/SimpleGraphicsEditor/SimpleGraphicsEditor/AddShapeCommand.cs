using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogNamespace;
using ShapeNamespace;

namespace SimpleGraphicsEditor
{
    public class AddShapeCommand : ICommand
    {
        public AddShapeCommand(Log log, Shape shape)
        {
            this.log = log;
            this.shape = shape;
        }

        public string Name { get { return "Add shape"; } }

        public void Execute()
        {
            log.Add(shape);
        }

        public void UnExecute()
        {
            log.RemoveLastShape();
        }

        private Log log;
        private Shape shape;
    }
}
