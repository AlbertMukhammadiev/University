using System.Drawing;
using System.Windows.Forms;

namespace SimpleGraphicsEditor.Models
{
    /// <summary>
    /// this class represents the shape
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// class constuctor
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="parameter"></param>
        public Shape(bool visible, Parameters parameter)
        {
            this.Parameter = parameter;
        }

        /// <summary>
        /// checks if the shape is caught
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public abstract bool IsSeized(Point p);

        /// <summary>
        /// the shape paints itself
        /// </summary>
        /// <param name="e"></param>
        public abstract void Draw(PaintEventArgs e);

        /// <summary>
        /// some parameters of shape
        /// </summary>
        public Parameters Parameter { get; set; }
    }
}
