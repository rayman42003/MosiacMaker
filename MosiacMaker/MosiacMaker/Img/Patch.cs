using System.Drawing;

namespace MosiacMaker.Img
{
    class Patch
    {
        public int StartWidth { get; set; }
        public int EndWidth { get; set; }
        public int StartHeight { get; set; }
        public int EndHeight { get; set; }

        public int Width { get { return EndWidth - StartWidth; } }
        public int Height { get { return EndHeight - StartHeight; } }

        public Color[,] pixels;
        public Image match { get; set; }

        public Patch(Image src, int StartWidth, int EndWidth, int StartHeight, int EndHeight)
        {
            this.StartWidth = StartWidth;
            this.EndWidth = EndWidth;
            this.StartHeight = StartHeight;
            this.EndHeight = EndHeight;

            pixels = new Color[Width, Height];
            for (int row = 0; row < Width; row++)
                for (int col = 0; col < Height; col++)
                    pixels[row, col] =
                        ((Bitmap)src).GetPixel(row + StartWidth, col + StartHeight);
        }

    }
}
