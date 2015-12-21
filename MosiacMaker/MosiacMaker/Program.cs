using MosiacMaker.Img;
using System.Drawing;
using System.Windows.Forms;

namespace MosiacMaker
{
    class Program
    {
        const int PATCH_SIZE = 64;
        static void Main(string[] args)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            string filename = @"E:\Dev\Projects\MosaicMaker\Example.jpg";
            ImgLoader loader = new FileImgLoader(filename);
            Image img = loader.Load();

            Sampler s = new AvgSampler();
            Mosiac m = new Mosiac(img);
            m.Test(s);
            Application.Run(new MosaicForm(m.Img));
        }
    }
}
