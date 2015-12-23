using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosiacMaker.Img
{
    class QuantizationSampler : Sampler
    {
        private const int DEFAULT_CUBE_SIDE = 2;
        public int cubeSide { get; set; }

        public QuantizationSampler() : this(DEFAULT_CUBE_SIDE)
        {
        }

        public QuantizationSampler(int cubeSide)
        {
            this.cubeSide = cubeSide;
        }

        public override Color Sample(Patch patch)
        {
            // Split color spectrum into quantized regions
            ColorCube cube = new ColorCube(cubeSide);
            // Categorize colors in the patch into the regions
            List<Color> list = new List<Color>(patch.Width * patch.Height);
            foreach (var color in patch.pixels)
                list.Add(color);
            cube.Put(list);
            
            // Find the region with the highest frequency
            var bucket = cube.HighestFrequency();

            // Return the average of that region
            long accR = 0;
            long accG = 0;
            long accB = 0;
            long count = 0;

            foreach (var color in bucket.bucket)
            {
                accR += color.R;
                accG += color.G;
                accB += color.B;
                ++count;
            }
            return Color.FromArgb(Convert.ToInt32(accR / count),
                Convert.ToInt32(accG / count), Convert.ToInt32(accB / count));
        }
    }
}
