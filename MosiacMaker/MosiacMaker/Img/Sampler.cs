using System.Drawing;

namespace MosiacMaker.Img
{
    abstract class Sampler
    {
        abstract public Color Sample(Patch p);
    }
}
