using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MosiacMaker
{
    class MosaicForm : Form
    {
        private Container components = null;
        private Image img;
        public MosaicForm(Image img)
        {
            this.components = new Container();
            this.Size = new Size(img.Width+17, img.Height+40); // TODO: Fix to be generic
            this.Text = "Mosaic";
            this.img = img;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(img, ClientRectangle);
        }
    }
}
