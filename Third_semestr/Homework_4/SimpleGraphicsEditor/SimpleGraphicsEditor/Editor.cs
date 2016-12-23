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
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            isClicked = false;
            log = new Log();
            start.X = 0;
            start.Y = 0;
            myPen = new Pen(Color.Black);
            field.Invalidate();
            first = true;
            movement = false;
        }

        private void OnButtonLinesClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            this.Cursor = Cursors.Cross;
        }

        private bool isClicked;
        private bool isCaught;
        private Button currentButton;
        private Log log;
        private Point start;
        private Point move;
        private Pen myPen;
        private bool first;
        private bool movement;
        private Point caughtPoint;

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
                if (movement)
                {
                    move.X = e.X;
                    move.Y = e.Y;
                    isCaught = true;
                    if (first)
                    {
                        start = log.Catch(new Point { X = e.X, Y = e.Y });
                    }
                    else
                    {
                        start = caughtPoint;
                    }

                }

                movement = true;
            }
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if ((isClicked) && (currentButton.Text == "|"))
            {
                move.X = e.X;
                move.Y = e.Y;
                field.Invalidate();
            }

            if (movement)
            {
                if (isCaught)
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
                isClicked = false;
                Pen pen = new Pen(Color.Black);
                log.Add(new Line(true, new Parameters(new Point(start.X, start.Y), new Point(move.X, move.Y), pen)));
            }

            if (movement)
            {
                if (isCaught)
                {
                    isCaught = false;
                    
                    if (first)
                    {
                        first = false;
                        caughtPoint = move;
                    }
                    else
                    {
                        Pen pen = new Pen(Color.Black);
                        log.Add(new Line(true, new Parameters(new Point(start.X, start.Y), new Point(move.X, move.Y), pen)));
                        movement = false;
                        first = true;
                    }
                }
            }
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            if ((isClicked) || (isCaught))
            {
                e.Graphics.DrawLine(Pens.Black, start, move);
            }

            log.DrawPicture(e);
        }


        private void button12_Click(object sender, EventArgs e)
        {
            //
        }

        private void OnButtonUndoClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            log.Undo();
            field.Invalidate();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            log.Redo();
            field.Invalidate();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            this.Cursor = Cursors.Hand;
        }
    }
}
