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

        public QuantizationSampler(int cubeSide)
        {
            this.cubeSide = cubeSide;
        }

        public override Color Sample(Patch p)
        {
            // Split color spectrum into quantized regions 
            // Categorize colors in the patch into the regions
            // Find the region with the highest frequency
            // Return the average of the area
            throw new NotImplementedException();
        }
    }
}
