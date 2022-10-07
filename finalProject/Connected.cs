using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace finalProject
{
    class Connected
    {
        public Bitmap process(Bitmap img, int width, int height)
        {
            Mat img_src = new Mat();
            Mat img_bool = new Mat();
            Mat labels = new Mat();
            Mat stats = new Mat();
            Mat centroids = new Mat();
            Mat img_color = new Mat();

            Mat img_srcFlag = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
            Cv2.CvtColor(img_srcFlag, img_bool, ColorConversionCodes.RGB2GRAY);

            int total = Cv2.ConnectedComponentsWithStats(img_bool, labels, stats, centroids, PixelConnectivity.Connectivity8, MatType.CV_32S);

            Vec3b black = new Vec3b(0, 0, 0);
            Vec3b white = new Vec3b(255, 255, 255);

            img_color = Mat.Zeros(img_bool.Size(), MatType.CV_8UC1);
            for (int y = 1; y < img_color.Rows; y++)
            {
                for (int x = 1; x < img_color.Cols; x++)
                {
                    int label = labels.At<int>(y, x);
                    if (0 < label && label <= total)
                    {
                        img_color.Set<Vec3b>(y, x, white);
                        if (stats.At<int>(label, 4) < 0.08 * width * height /*|| stats.At<int>(label, 4) > 180000*/)//100000
                        {
                            img_color.Set<Vec3b>(y, x, black);
                        }
                    }
                }
            }

            img = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img_color);
            return img;
        }

        //connected algorithm
        /*
        private Bitmap getConnected(Bitmap img)
        {
            if (rgb[x + 1, y, 0] == 255)
            {
                num++;
                number++;
                rgb[x + 1, y, 0] = 0;
                record.Add(x + 1);
                record.Add(y);
                getConnectedNumber(rgb, x + 1, y,number);
            }
            if (rgb[x + 1, y+1, 0] == 255)
            {
                num++;
                number++;
                rgb[x + 1, y+1, 0] = 0;
                record.Add(x + 1);
                record.Add(y+1);
                getConnectedNumber(rgb, x + 1, y + 1, number);
            }
            if (rgb[x, y+1, 0] == 255)
            {
                num++;
                number++;
                rgb[x, y+1, 0] = 0;
                record.Add(x);
                record.Add(y+1);
                getConnectedNumber(rgb, x, y + 1, number);
            }
            if (rgb[x - 1, y+1, 0] == 255)
            {
                num++;
                number++;
                rgb[x - 1, y+1, 0] = 0;
                record.Add(x - 1);
                record.Add(y+1);
                getConnectedNumber(rgb, x - 1, y + 1,number);
            }
            if (rgb[x - 1, y, 0] == 255)
            {
                num++;
                number++;
                rgb[x - 1, y, 0] = 0;
                record.Add(x - 1);
                record.Add(y);
                getConnectedNumber(rgb, x - 1, y,number);
            }
            if (rgb[x - 1, y-1, 0] == 255)
            {
                num++;
                number++;
                rgb[x - 1, y-1, 0] = 0;
                record.Add(x - 1);
                record.Add(y-1);
                getConnectedNumber(rgb, x - 1, y - 1,number);
            }
            if (rgb[x, y-1, 0] == 255)
            {
                num++;
                number++;
                rgb[x, y-1, 0] = 0;
                record.Add(x);
                record.Add(y-1);
                getConnectedNumber(rgb, x, y - 1,number);
            }
            if (rgb[x - 1, y-1, 0] == 255)
            {
                num++;
                number++;
                rgb[x - 1, y-1, 0] = 0;
                record.Add(x - 1);
                record.Add(y-1);
                getConnectedNumber(rgb, x - 1, y - 1,number);
            }
            return number;
        }
        */

        //pooling
        public int[,,] maxPooling(Bitmap img)
        {
            int poolingFlag = Math.Max(img.Height / 1500, img.Width / 1500);
            int[,,] rgb = new int[img.Width / poolingFlag, img.Height / poolingFlag, 3];

            for (int x = 0; x < img.Width - 1; x += poolingFlag)
            {
                for (int y = 0; y < img.Height - 1; y += poolingFlag)
                {
                    int isWhite = 0;
                    for (int i = 0; i < poolingFlag; i++)
                    {
                        for (int j = 0; j < poolingFlag; j++)
                        {
                            if (img.GetPixel(x + i, y + j).R == 255)
                            {
                                isWhite = 1;
                                i = j = poolingFlag;
                            }
                        }
                    }
                    rgb[x / poolingFlag, y / poolingFlag, 0]
                        = rgb[x / poolingFlag, y / poolingFlag, 1]
                        = rgb[x / poolingFlag, y / poolingFlag, 2] = isWhite * 255;
                }
            }
            return rgb;
        }

    }
}
