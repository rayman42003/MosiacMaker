using System.Drawing;
using System.Windows.Forms;

namespace MosiacMaker
{
    class Program
    {
        const int PATCH_SIZE = 1;
        static void Main(string[] args)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            string filename = @"E:\Dev\Projects\MosaicMaker\Example.jpg";
            ImgLoader loader = new FileImgLoader(filename);
            Image img = loader.Load();
            Bitmap bmp = (Bitmap)img;


            for (int i = 0; i < bmp.Width/2; i += PATCH_SIZE)
            {
                for (int j = 0; j < bmp.Height/2;  j += PATCH_SIZE)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }

            Application.Run(new MosaicForm(bmp));

            System.Console.ReadKey();
        }
    }
}
