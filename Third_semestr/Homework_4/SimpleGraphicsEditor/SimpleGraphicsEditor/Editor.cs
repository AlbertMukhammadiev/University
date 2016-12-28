using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogNamespace;
using ShapeNamespace;

namespace SimpleGraphicsEditor
{
    /// <summary>
    /// simple graphics editor
    /// </summary>
    public partial class Editor : Form
    {

        /// <summary>
        /// class constructor
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            isClicked = false;
            isCaught = false;
            log = new Log();
            start.X = 0;
            start.Y = 0;
            myPen = new Pen(Color.Black, 3);
            field.Invalidate();

        }

        private Pen myPen;
        private Shape movedShape;
        private bool isClicked;
        private bool isCaught;
        private Button currentButton;
        private Log log;
        private Point start;
        private Point move;

        private void OnButtonLinesClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            this.Cursor = Cursors.Cross;
        }

        private void field_MouseDown(object sender, MouseEventArgs e)
        {
            
            move = e.Location;

            if (currentButton.Text == "|")
            {
                isClicked = true;
                field.Invalidate();
                start = e.Location;
            }

            if (currentButton.Text == "allocate")
            {
                
                movedShape = log.CatchPoint(new Point(e.X, e.Y));
                if (movedShape != null)
                {
                    start = movedShape.Parameter.start;
                    isClicked = true;
                }
            }
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                move = e.Location;
                field.Invalidate();
            }
        }

        private void field_MouseUp(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                Pen pen = new Pen(Color.Black);

                if (currentButton.Text == "|")
                {
                    var command = new AddShapeCommand(log, new Line(true, new Parameters(start, e.Location, pen)));
                    manager.Execute(command);
                }

                if ((currentButton.Text == "allocate") && (movedShape != null))
                {
                    isCaught = false;
                    var command = new ChangePointsCommand(log, movedShape, new Parameters(start, e.Location, pen));
                    manager.Execute(command);
                }
                
                isClicked = false;
            }

            field.Invalidate();
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            if (isClicked)
            {
                if (currentButton.Text == "|")
                {
                    myPen.Width = 3;
                    myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                }

                if (currentButton.Text == "allocate")
                {
                    myPen.Width = 5;
                    myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                }

                e.Graphics.DrawLine(myPen, start, move);
            }

            log.DrawPicture(e);
        }

        private void OnButtonAllocateClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            this.Cursor = Cursors.Hand;
        }

        #region OK

        private void OnButtonUndoClick(object sender, EventArgs e)
        {
            manager.Undo();
            field.Invalidate();
        }

        private void OnButtonRedoClick(object sender, EventArgs e)
        {
            manager.Redo();
            field.Invalidate();
        }

        private List<Shape> shapes = new List<Shape>();
        private UndoRedoManager manager = new UndoRedoManager();

        #endregion


    }
}
