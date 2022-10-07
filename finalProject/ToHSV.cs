using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject
{
    class ToHSV
    {
        public int[,,] process(Bitmap img, int width, int height)
        {
            int[,,] rgb = new int[width, height, 3];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double h, s, v;
                    Color pixelColor = img.GetPixel(x, y);
                    //h = pixelColor.GetHue();
                    //s = pixelColor.GetSaturation();
                    //v = pixelColor.GetBrightness();
                    //h
                    double h1 = Math.Acos(0.5 * ((pixelColor.R - pixelColor.G) + (pixelColor.R - pixelColor.B)) * (1.0 / Math.Sqrt(Math.Pow((pixelColor.R - pixelColor.G), 2) + (pixelColor.R - pixelColor.B) * (pixelColor.G - pixelColor.B))));
                    if (pixelColor.B <= pixelColor.G)
                        h = h1;
                    else
                        h = (360 - h1);

                    double rgbMax = Math.Max(pixelColor.R, pixelColor.G), rgbMin = Math.Min(pixelColor.R, pixelColor.G);
                    rgbMax = Math.Max(rgbMax, pixelColor.B);
                    rgbMin = Math.Min(rgbMin, pixelColor.B);

                    //s
                    s = ((rgbMax - rgbMin) / rgbMax);
                    //v
                    v = (rgbMax / 255);

                    rgb[x, y, 0] = (int)h;
                    rgb[x, y, 1] = (int)(s*100);
                    rgb[x, y, 2] = (int)(v*100);
                }
            }
            return rgb;
        }
    }
}
