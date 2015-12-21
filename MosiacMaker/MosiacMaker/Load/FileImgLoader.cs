using System.Drawing;

namespace MosiacMaker
{
    class FileImgLoader : ImgLoader
    {
        public string Filename { get; set; }
        public FileImgLoader(string Filename)
        {
            this.Filename = Filename;
        }

        public override Image Load()
        {
            return Image.FromFile(Filename);
        }
    }
}
