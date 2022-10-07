using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace finalProject
{
    class accessory
    {
        public int[] accessoryXY;
        public Bitmap ClearBack(Bitmap img)
        {
            accessoryXY = new int[]
            {
                img.Height, //top
                0, //right
                0, //buttom
                img.Width //left
            };
            Bitmap img_CB = new Bitmap(img.Width, img.Height);
            int alpha = 0;
            int white = 240;
            Color pixel;
            for (int x = 1; x < img.Width; x++)
            {
                for (int y = 1; y < img.Height; y++)
                {
                    pixel = img.GetPixel(x, y);
                    int R = pixel.R;
                    int G = pixel.G;
                    int B = pixel.B;

                    if (R >= white && G >= white && B >= white)
                    {
                        alpha = 0;
                    }
                    else
                    {
                        alpha = 255;
                        if (x < accessoryXY[3]) accessoryXY[3] = x;
                        if (x > accessoryXY[1]) accessoryXY[1] = x;
                        if (y < accessoryXY[0]) accessoryXY[0] = y;
                        if (y > accessoryXY[2]) accessoryXY[2] = y;
                    }
                    img_CB.SetPixel(x, y, Color.FromArgb(alpha, R, G, B));
                }
            }
            return img_CB;
        }
    }
}
