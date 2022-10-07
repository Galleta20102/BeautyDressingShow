using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject
{
    class FacialFeatures
    {
        public int[,,] process(Bitmap img)
        {
            int[,,] rgb = new int[img.Width, img.Height, 3];

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    rgb[x, y, 0] = rgb[x, y, 1] = rgb[x, y, 2] = img.GetPixel(x, y).R;
                }
            }

            return rgb;
        }

        public int[,,] maxPooling(Bitmap img, int poolingFlag)
        {
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
        public int[] firstPoint(Bitmap img)
        {
            int[] firstPoint = { img.Width, img.Height };
            int flag = 1;
            while (true)
            {
                firstPoint[0] /= 2; //x
                firstPoint[1] /= 2; //y
                for (int i = 1; i < Math.Pow(2, flag); i += 2)
                {
                    for (int j = 1; j < Math.Pow(2, flag); j += 2)
                    {
                        if (img.GetPixel(firstPoint[0] * i, firstPoint[1] * j).R == 255)
                        {
                            firstPoint[0] *= i;
                            firstPoint[1] *= j;
                            return firstPoint;
                        }
                    }
                }
                flag++;
            }
        }
        public int[] findRange(Bitmap img, int[] firstPoint)
        {
            int range = 0;
            bool notFind = true; // 0:top, 1:right, 2:buttom, 3:left
            int[] faceRange = new int[4]
            {
                img.Height,
                0,
                0,
                img.Width
            };

            while (notFind)
            {
                range++;
                if ((firstPoint[0] + range >= img.Width && firstPoint[1] + range >= img.Height
                    && firstPoint[0] - range <= 0 && firstPoint[1] - range <= 0))
                {
                    break;
                }
                notFind = false;
                for (int i = -range; i <= range; i++)
                {
                    for (int j = -range; j <= range; j++)
                    {
                        if (i == -range || i == range || j == -range || j == range)
                        {
                            int x = firstPoint[0] + i, y = firstPoint[1] + j;
                            if (x >= img.Width) x = img.Width - 1;
                            else if (x <= 0) x = 1;
                            if (y >= img.Height) y = img.Height - 1;
                            else if (y <= 0) y = 1;
                            if (img.GetPixel(x, y).R >= 245)
                            {
                                notFind = true;
                                if (y < faceRange[0]) faceRange[0] = y;
                                else if (y > faceRange[2]) faceRange[2] = y;
                                if (x < faceRange[3]) faceRange[3] = x;
                                else if (x > faceRange[1]) faceRange[1] = x;
                            }
                        }
                    }
                }
            }
            double w = faceRange[1] - faceRange[3], h = faceRange[2] - faceRange[0];
            if (w / h < 0.75)
            {
                faceRange[2] = (int)(faceRange[2] - (double)(faceRange[2] - faceRange[0]) * 0.25);
            }
            return faceRange;
        }
        public int[,] findFaceFeature(Bitmap img, int[] range, int k)
        {
            int rangeWidth = range[1] - range[3], rangeHeight = range[2] - range[0];
            int[] centerXY = { (range[1] + range[3]) / 2, (range[2] + range[0]) / 2 };
            int[,] clusters = new int[k, 2];

            //k=3
            /*clusters[0, 0] = range[3] + (rangeWidth * 3 / 10);
            clusters[0, 1] = clusters[1, 1] = range[0] + (rangeHeight * 1 / 3);
            clusters[1, 0] = range[1] - (rangeWidth * 3 / 10);
            clusters[2, 0] = range[3] + rangeWidth / 2;
            clusters[2, 1] = range[0] + (rangeHeight * 2 / 3);*/

            //k=6
            clusters[0, 0] = range[3] + (rangeWidth * 3 / 10);
            clusters[0, 1] = range[0] + (rangeHeight * 1 / 4);

            clusters[1, 0] = range[1] - (rangeWidth * 3 / 10);
            clusters[1, 1] = range[0] + (rangeHeight * 1 / 4);

            clusters[2, 0] = range[3] + (rangeWidth * 3 / 10);
            clusters[2, 1] = range[0] + (rangeHeight * 2 / 5);

            clusters[3, 0] = range[1] - (rangeWidth * 3 / 10);
            clusters[3, 1] = range[0] + (rangeHeight * 2 / 5);

            clusters[4, 0] = range[3] + (rangeWidth / 2);
            clusters[4, 1] = range[0] + (rangeHeight * 2 / 3);

            clusters[5, 0] = range[3] + rangeWidth / 2;
            clusters[5, 1] = range[0] + (rangeHeight * 5 / 6);

            clusters = K_meas(img, range, k, clusters, centerXY);

            return clusters;
        }
        public int[,] K_meas(Bitmap img, int[] range, int kNumber, int[,] clusters, int[] centerXY)
        {
            int[,] pointSumXY = new int[kNumber, 2];
            int[] kSum = new int[kNumber];
            double a = (range[1] - range[3]) / 2, b = (range[2] - range[0]) / 2;
            int rangeWidth = range[1] - range[3], rangeHeight = range[2] - range[0];
            for (int x = range[3]; x < range[1]; x++)
            {
                for (int y = range[0]; y < range[2]; y++)
                {
                    if (img.GetPixel(x, y).R == 0 && inBroundryDistance(x, y, centerXY, a, b) <= 0.75)
                    {
                        int group = 0;
                        double minDistance = 999999;
                        for (int k = 0; k < kNumber; k++)
                        {
                            double d = distance(x, y, clusters[k, 0], clusters[k, 1]);
                            if (d < minDistance)
                            {
                                minDistance = d;
                                group = k;
                            }
                        }
                        if (minDistance != 99999)
                        {
                            pointSumXY[group, 0] += x;
                            pointSumXY[group, 1] += y;
                            kSum[group]++;
                        }
                    }
                }
            }
            bool recursive = false;
            for (int k = 0; k < kNumber; k++)
            {
                if (kSum[k] == 0) kSum[k] = 1;
                int newX = pointSumXY[k, 0] / kSum[k];
                int newY = pointSumXY[k, 1] / kSum[k];
                if (clusters[k, 0] != newX || clusters[k, 1] != newY)
                {
                    recursive = true;
                    clusters[k, 0] = newX;
                    clusters[k, 1] = newY;
                }
            }
            if (recursive == true)
            {
                return K_meas(img, range, kNumber, clusters, centerXY);
            }
            return clusters;
        }
        private double distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
        private double inBroundryDistance(int x, int y, int[] centerXY, double a, double b)
        {
            double index1 = Math.Pow(x - centerXY[0], 2) / Math.Pow(a, 2);
            double index2 = Math.Pow(y - centerXY[1], 2) / Math.Pow(b, 2);
            return (index1 + index2);
        }
    }
}
