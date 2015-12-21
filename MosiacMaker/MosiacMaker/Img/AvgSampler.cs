using System;
using System.Drawing;

namespace MosiacMaker.Img
{
    class AvgSampler : Sampler
    {
        public override Color Sample(Patch p)
        {
            long accR = 0;
            long accG = 0;
            long accB = 0;
            long count = 0;
            for (int row = p.StartWidth; row <= p.EndWidth; row++)
            {
                for (int col = p.StartHeight; col <= p.EndHeight; col++)
                {
                    foreach(Color c in p.pixels)
                    {
                        accR += c.R;
                        accG += c.G;
                        accB += c.B;
                        ++count;
                    }
                }
            }
            Color avg = Color.FromArgb(Convert.ToInt32(accR / count),
                Convert.ToInt32(accG / count), Convert.ToInt32(accB / count));
            return avg;
        }
    }
}
