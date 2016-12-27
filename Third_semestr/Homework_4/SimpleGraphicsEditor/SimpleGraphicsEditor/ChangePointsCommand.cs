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
        public ChangePointsCommand(Log log, Shape shape, Parameters parameters)
        {
            this.log = log;
            this.shape = shape;
            this.parameters = parameters;
        }

        public string Name
        {
            get { return "Move"; }
        }

        public void Execute()
        {
            prevParameters = shape.Parameter;
            shape.Parameter = parameters;
        }

        public void UnExecute()
        {
            shape.Parameter = prevParameters;
        }

        private Parameters parameters;
        private Parameters prevParameters;
        private Log log;
        private Shape shape;
    }
}
