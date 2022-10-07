using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject
{
    class Binarization
    {
        public int[,,] process(Bitmap img, int width, int height)
        {
            int[,,] rgb = new int[width, height, 3];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int flag = 0;
                    double h, s, v;
                    Color pixelColor = img.GetPixel(x, y);

                    h = pixelColor.R;
                    s = pixelColor.G;
                    v = pixelColor.B;

                    if (h <= 3 && h >= 0 && s >= 10 && v >= 45 && s + v >= 70)
                        flag = 1;
                    rgb[x, y, 0] = rgb[x, y, 1] = rgb[x, y, 2] = flag * 255;
                }
            }
            return rgb;
        }
    }
}
