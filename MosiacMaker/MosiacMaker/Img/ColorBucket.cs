using System.Collections.Generic;
using System.Drawing;

namespace MosiacMaker.Img
{
    class ColorBucket
    {
        public List<Color> bucket { get; set; }
        public Color min { get; set; }
        public Color max { get; set; }

        public ColorBucket(Color min, Color max)
        {
            this.min = min;
            this.max = max;
            bucket = new List<Color>();
        }
    }
}
