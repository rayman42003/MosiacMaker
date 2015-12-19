using System.Drawing;
using System.Windows.Forms;

namespace MosiacMaker
{
    class Program
    {
        const int PATCH_SIZE = 8;
        static void Main(string[] args)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            string filename = @"E:\Dev\Projects\MosaicMaker\Example.jpg";
            ImgLoader loader = new FileImgLoader(filename);
            Image img = loader.Load();
            Bitmap bmp = (Bitmap)img;


            for (int row = 0; row < bmp.Width; row += PATCH_SIZE)
            {
                for (int col = 0; col < bmp.Height;  col += PATCH_SIZE)
                {
                    int accR = 0;
                    int accG = 0;
                    int accB = 0;
                    int count = 0;
                    for (int i = row; i < row + PATCH_SIZE && i < bmp.Width; i++)
                    {
                        for (int j = col; j < col + PATCH_SIZE && j < bmp.Height; j++)
                        {
                            Color curr = bmp.GetPixel(i, j);
                            accR += curr.R;
                            accG += curr.G;
                            accB += curr.B;
                            ++count;
                        }
                    }
                    Color avg = Color.FromArgb(accR / count, accG / count, accB / count);
                    for (int i = row; i < row + PATCH_SIZE && i < bmp.Width; i++)
                        for (int j = col; j < col + PATCH_SIZE && j < bmp.Height; j++)
                            bmp.SetPixel(i, j, avg);
                }
            }

            Application.Run(new MosaicForm(bmp));

            System.Console.ReadKey();
        }
    }
}
