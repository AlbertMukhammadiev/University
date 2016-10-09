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

namespace SimpleGraphicsEditor
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
            bitmap = new Bitmap(field.Width, field.Height);
            isClicked = false;
            log = new Log(field.Width, field.Height);
        }



        private void OnButtonShapesClick(object sender, EventArgs e)
        {
            currentButton = (Button)sender;

            if (currentButton.Text == "|")
            {
                draw = Graphics.FromImage(bitmap).DrawLine;
            }
            else
            {
                return;
            }
        }

        bool isClicked;
        private Button currentButton;
        private delegate void DrawShape(Pen pen, Point pt1, Point pt2);
        private DrawShape draw;
        private DrawShape drawMove;
        private Log log;
        private Bitmap bitmap;
        private Point start;
        private Point move;

        private void field_MouseDown(object sender, MouseEventArgs e)
        {
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
            draw(Pens.Black, start, move);
            field.Image = bitmap;
            log.AddShape(new Line(start, move, log));
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            if (undo)
            {
                return;
            }

            drawMove = ShapeShape(e);
            drawMove(Pens.Black, start, move);
        }

        private DrawShape ShapeShape(PaintEventArgs e)
        {
            //if (currentButton.Text == "|")
            //{
            //    return e.Graphics.DrawLine;
            //}

            return e.Graphics.DrawLine;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            field.Image = log.GetBitmap();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            log.Undo();
            field.Image = log.GetBitmap();
            undo = true;
        }

        private bool undo = false;

        private void button26_Click(object sender, EventArgs e)
        {
            log.Redo();
            field.Image = log.GetBitmap();
        }
    }
}
