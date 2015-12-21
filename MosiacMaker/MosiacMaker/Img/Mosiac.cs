using System;
using System.Drawing;

namespace MosiacMaker.Img
{
    class Mosiac
    {
        public const int DEFAULT_PATCH_SIZE = 64;
        public Image Img;
        public Patch[,] patches;

        public Mosiac(Image img) : this(img, DEFAULT_PATCH_SIZE)
        {
        }

        public Mosiac(Image img, int patchSize)
        {
            this.Img = img;
            patches = CreatePatches(patchSize);
        }

        private Patch[,] CreatePatches(int patchSize)
        {
            int patchWidth = Convert.ToInt32(Math.Ceiling((double)Img.Width / patchSize));
            int patchHeight = Convert.ToInt32(Math.Ceiling((double)Img.Height / patchSize));
            Patch[,] patches = new Patch[patchWidth, patchHeight];
            for (int row = 0; row < patchWidth; row++)
            {
                for (int col = 0; col < patchHeight; col++)
                {
                    patches[row,col] =
                        new Patch(Img, row * patchSize, Math.Min((row + 1) * patchSize - 1, Img.Width-1),
                                        col * patchSize, Math.Min((col + 1) * patchSize - 1, Img.Height-1));
                }
            }
            return patches;
        }

        public void Test(Sampler s)
        {
            foreach(Patch p in patches)
            {
                Color avg = s.Sample(p);
                for (int row = p.StartWidth; row <= p.EndWidth; row++)
                    for (int col = p.StartHeight; col <= p.EndHeight; col++)
                        ((Bitmap)Img).SetPixel(row, col, avg);
            }
        }
    }
}
