using System.Drawing;

namespace SimpleGraphicsEditor.Models
{
    public class Parameters
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="pen"></param>
        public Parameters(Point point1, Point point2, Pen pen)
        {
            this.Start = point1;
            this.Move = point2;
            this.Pen = pen;
        }

        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; set; }
        public Point Move { get; set; }
    }
}
