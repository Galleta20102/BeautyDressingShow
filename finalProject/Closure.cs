using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject
{
    class Closure
    {
        public int[,,] process(int[,,] rgb, int width, int height)
        {
            int[,,] rgbFlag = new int[width, height, 3];

            //expansion
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    rgbFlag[x, y, 0] = rgb[x, y, 0];
                }
            }

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    if (rgbFlag[x - 1, y - 1, 0] == 255 || rgbFlag[x, y - 1, 0] == 255 || rgbFlag[x + 1, y - 1, 0] == 255 || rgbFlag[x - 1, y, 0] == 255 ||
                        rgbFlag[x + 1, y, 0] == 255 || rgbFlag[x - 1, y + 1, 0] == 255 || rgbFlag[x, y + 1, 0] == 255 || rgbFlag[x + 1, y + 1, 0] == 255)
                    {
                        rgb[x, y, 0] = 255;
                    }
                    else rgb[x, y, 0] = 0;
                }
            }

            //erosion
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    rgbFlag[x, y, 0] = rgb[x, y, 0];
                }
            }

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    if (rgbFlag[x - 1, y - 1, 0] == 255 && rgbFlag[x, y - 1, 0] == 255 && rgbFlag[x + 1, y - 1, 0] == 255 && rgbFlag[x - 1, y, 0] == 255 &&
                        rgbFlag[x + 1, y, 0] == 255 && rgbFlag[x - 1, y + 1, 0] == 255 && rgbFlag[x, y + 1, 0] == 255 && rgbFlag[x + 1, y + 1, 0] == 255)
                    {
                        rgb[x, y, 0] = 255;
                    }
                    else rgb[x, y, 0] = 0;
                }
            }

            return rgb;
        }
    }
}
