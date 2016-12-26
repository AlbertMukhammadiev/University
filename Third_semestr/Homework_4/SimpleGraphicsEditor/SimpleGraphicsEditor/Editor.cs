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
            field.Invalidate();

        }

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
            if (currentButton.Text == "|")
            {
                field.Invalidate();
                isClicked = true;
                start.X = e.X;
                start.Y = e.Y;
                move.X = e.X;
                move.Y = e.Y;
            }

            if (currentButton.Text == "allocate")
            {
                if (isCaught)
                {
                    
                    isClicked = true;
                    start = movedShape.Parameter.start;
                    move.X = e.X;
                    move.Y = e.Y;
                }

                movedShape = log.CatchPoint(new Point(e.X, e.Y));
                isCaught = true;
            }

            
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                if (currentButton.Text == "|")
                {
                    move.X = e.X;
                    move.Y = e.Y;
                    field.Invalidate();
                }

                if ((currentButton.Text == "allocate") && (isCaught))
                {
                    move.X = e.X;
                    move.Y = e.Y;
                    field.Invalidate();
                }
            }

            
        }

        private void field_MouseUp(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                Pen pen = new Pen(Color.Black);

                if (currentButton.Text == "|")
                {
                    var command = new AddShapeCommand(log, new Line(true, new Parameters(new Point(start.X, start.Y), new Point(move.X, move.Y), pen)));
                    manager.Execute(command);
                }

                if (currentButton.Text == "allocate")
                {
                    isCaught = false;
                    var command = new ChangePointsCommand(log, movedShape, new Point(move.X, move.Y));
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
                e.Graphics.DrawLine(Pens.Black, start, move);
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
