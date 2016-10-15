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
        }

        private void OnButtonShapesClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
        }

        private bool isClicked;
        private Button currentButton;
        private delegate void DrawShape(Pen pen, Point pt1, Point pt2);
        private DrawShape drawMove;
        private Log log;
        private Point start;
        private Point move;
        private bool undo = false;
        private PaintEventArgs pictureBoxArg;
        private bool first = false;
        private Pen myPen;

        private void field_MouseDown(object sender, MouseEventArgs e)
        {
            field.Invalidate();
            isClicked = true;
            start.X = e.X;
            start.Y = e.Y;
            move.X = e.X;
            move.Y = e.Y;
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                move.X = e.X;
                move.Y = e.Y;
                field.Invalidate();
            }
        }

        private void field_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            Pen ppeenn = new Pen(Color.Black);
            log.Add(new Line(true, new Parameters(new Point(start.X, start.Y), new Point(move.X, move.Y), ppeenn), pictureBoxArg));
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            ShapeShape(e);
            e.Graphics.DrawLine(Pens.Black, start, move);
            
            log.DrawPicture();
            
        }

        private void ShapeShape(PaintEventArgs e)
        {
            pictureBoxArg = e;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //log.Undo();
            //field.Image = log.GetBitmap();
            undo = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //log.Redo();
            //field.Image = log.GetBitmap();
        }
    }
}
