using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShapeNamespace;

namespace SimpleGraphicsEditor
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();

            bitmap = new Bitmap(field.Width, field.Height);
            isClicked = false;
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
        private List<Shape> log = new List<Shape>();
        private Bitmap bitmap;
        private Point start;
        private Point move;

        private void field_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            start.X = e.X;
            start.Y = e.Y;
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
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            drawMove = ShapeShape(e);
            drawMove(Pens.Black, start, move);
        }

        private DrawShape ShapeShape(PaintEventArgs e)
        {
            return e.Graphics.DrawLine;
        }
    }
}
