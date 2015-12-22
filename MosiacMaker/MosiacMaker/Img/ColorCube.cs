using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosiacMaker.Img
{
    class ColorCube
    {
        private const int RGB_MAX = 256;
        private ColorBucket[,,] cube;

        public ColorCube(int cubesPerRow)
        {
            cube = new ColorBucket[cubesPerRow, cubesPerRow, cubesPerRow];

            for (int r = 0; r < cubesPerRow; r++)
            {
                for (int g = 0; g < cubesPerRow; g++)
                {
                    for (int b = 0; b < cubesPerRow; b++)
                    {
                        int step = RGB_MAX / cubesPerRow;

                        int rMin = r * step;
                        int rMax = (r + 1) * step - 1;

                        int gMin = g * step;
                        int gMax = (g + 1) * step - 1;

                        int bMin = b * step;
                        int bMax = (b + 1) * step - 1;
                        cube[r, g, b] = new ColorBucket(Color.FromArgb(rMin, gMin, bMin),
                            Color.FromArgb(rMax, gMax, bMax));
                    }
                }
            }
        }

        public void Put(List<Color> colors)
        {
            foreach(var bucket in cube)
            {
                var matches = colors.Where(x => InRange(bucket, x));
                bucket.bucket.AddRange(matches);
            }
        }

        private bool InRange(ColorBucket bucket, Color color)
        {
            return color.R >= bucket.min.R &&
                color.R <= bucket.max.R &&
                color.G >= bucket.min.G &&
                color.G <= bucket.max.G &&
                color.B >= bucket.min.B &&
                color.B <= bucket.max.B;
        } 

        // TODO: Case where more than one bucket has the same frequency
        public ColorBucket HighestFrequency()
        {
            ColorBucket max = null;
            foreach (var bucket in cube)
                if (max == null || max.bucket.Count <= bucket.bucket.Count)
                    max = bucket;
            return max;
        }

    }
}
