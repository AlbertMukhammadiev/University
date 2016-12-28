using LogNamespace;
using ShapeNamespace;
using System;
namespace SimpleGraphicsEditor
{
    /// <summary>
    /// the command which accounts for change of the location of the shape
    /// </summary>
    class ChangePointsCommand : ICommand
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="log">log of shapes</param>
        /// <param name="shape"></param>
        /// <param name="parameters"></param>
        public ChangePointsCommand(Log log, Shape shape, Parameters parameters)
        {
            this.log = log;
            this.shape = shape;
            this.parameters = parameters;
        }

        public string Name { get { return "Move"; } }

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
