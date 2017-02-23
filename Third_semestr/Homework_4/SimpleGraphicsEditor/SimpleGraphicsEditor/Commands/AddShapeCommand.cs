using LogNamespace;
using SimpleGraphicsEditor.Models;

namespace SimpleGraphicsEditor.Commands
{
    /// <summary>
    /// the command which accounts for the adding new shapes
    /// </summary>
    public class AddShapeCommand : ICommand
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="log">log of shapes</param>
        /// <param name="shape"></param>
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
