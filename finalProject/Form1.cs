using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class Form1 : Form
    {
        static Bitmap img = new Bitmap(1, 1);
        static Bitmap img_origin = new Bitmap(1, 1);
        //toHSV
        ToHSV toHSV = new ToHSV();
        //Binarization
        Binarization binarization = new Binarization();
        //closure
        Closure closure = new Closure();
        //Opening
        Opening opening = new Opening();
        //Connected
        Connected connected = new Connected();
        //find facial features
        FacialFeatures facialFeatures = new FacialFeatures();
        int[] firstXY, faceXY;
        int[,] faceFeature;
        //accessory
        accessory Accessory = new accessory();
        //儲存最原始的Hat
        Bitmap accessoryBmp;
        //變色後的Hat
        Bitmap HatColorful;
        Bitmap resultImg;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Beret (Black)");
            comboBox1.Items.Add("Bucket Hat (White)");
            comboBox1.Items.Add("Bucket Hat (Brow)");
            comboBox1.Items.Add("Knit Cap (Black)");
            comboBox1.Items.Add("Straw Hat");
            comboBox1.Items.Add("Top Hat (Black)");
            comboBox1.Items.Add("Ushanka");
            comboBox1.Items.Add("Cowboy Hat (Brow)");
            comboBox1.Items.Add("Crown (Black)");
            comboBox1.Items.Add("Police Hat");
        }
        void RGB_bar()
        {
            float changered = Rbar.Value * 0.001f;
            float changegreen = Gbar.Value * 0.001f;
            float changeblue = Bbar.Value * 0.001f;

            Image img = accessoryBmp;
            Bitmap img_result = new Bitmap(img.Width, img.Height);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix CMimage = new ColorMatrix(new float[][]
            {
                    new float[]{1+changered, 0, 0, 0, 0},
                    new float[]{0, 1+changegreen, 0, 0, 0},
                    new float[]{0, 0, 1+changeblue, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
            });

            imageAttributes.SetColorMatrix(CMimage);
            Graphics g = Graphics.FromImage(img_result);

            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            hat.Image = img_result;
            HatColorful = img_result;
        }

        public static int[,,] GetRGBData(Bitmap bitImg)
        {
            int height = bitImg.Height;
            int width = bitImg.Width;

            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            IntPtr imgPtr = bitmapData.Scan0;

            int stride = bitmapData.Stride;

            int widthByte = width * 3;

            int skipByte = stride - widthByte;

            int[,,] rgbData = new int[width, height, 3];

            unsafe
            {
                byte* p = (byte*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        rgbData[i, j, 2] = p[0];
                        p++;
                        rgbData[i, j, 1] = p[0];
                        p++;
                        rgbData[i, j, 0] = p[0];
                        p++;
                    }
                    p += skipByte;
                }
            }
            bitImg.UnlockBits(bitmapData);
            return rgbData;
        }

        public static Bitmap SetRGBData(int[,,] rgbData)
        {
            Bitmap bitImg;

            int width = rgbData.GetLength(0);
            int height = rgbData.GetLength(1);

            bitImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            IntPtr imgPtr = bitmapData.Scan0;

            int stride = bitmapData.Stride;

            int widthByte = width * 3;

            int skipByte = stride - widthByte;

            unsafe
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        p[0] = (byte)rgbData[i, j, 0];
                        p++;
                        p[0] = (byte)rgbData[i, j, 0];
                        p++;
                        p[0] = (byte)rgbData[i, j, 0];
                        p++;
                    }
                    p += skipByte;
                }
            }
            bitImg.UnlockBits(bitmapData);
            return bitImg;
        }

        public static Bitmap SetRGBData_Nongray(int[,,] rgbData)
        {
            Bitmap bitImg;

            int width = rgbData.GetLength(0);
            int height = rgbData.GetLength(1);

            bitImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            IntPtr imgPtr = bitmapData.Scan0;

            int stride = bitmapData.Stride;

            int widthByte = width * 3;

            int skipByte = stride - widthByte;

            unsafe
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        p[0] = (byte)rgbData[i, j, 2];
                        p++;
                        p[0] = (byte)rgbData[i, j, 1];
                        p++;
                        p[0] = (byte)rgbData[i, j, 0];
                        p++;
                    }
                    p += skipByte;
                }
            }
            bitImg.UnlockBits(bitmapData);
            return bitImg;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Image File";
            openFileDialog.Filter = "All files (*.jpg)|*.*|All files(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                img = new Bitmap(Image.FromFile(openFileDialog.FileName));
                img_origin = new Bitmap(img);

                //記錄用的堆疊要清空
                //StepStack.Clear();
                //StepStack.Push(img);

                pictureBox1.Image = img_origin;

            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Image File";
            saveFileDialog.InitialDirectory = @"D:\";
            saveFileDialog.Filter = "All Files (*.jpg)|*.*|All files(*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                img.Save(saveFileDialog.FileName + ".Jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            
        }

        private void button_toHSV_Click(object sender, EventArgs e)
        {
            img = SetRGBData_Nongray(toHSV.process(img, img.Width, img.Height));
            pictureBox5.Image = img;
        }

        private void button_Binarization_Click(object sender, EventArgs e)
        {
            img = SetRGBData_Nongray(binarization.process(img, img.Width, img.Height));
            pictureBox5.Image = img;
        }

        private void button_Closure_Click(object sender, EventArgs e)
        {
            int[,,] rgb = GetRGBData(img);
            img = SetRGBData(closure.process(rgb, img.Width, img.Height));
            pictureBox5.Image = img;
        }

        private void button_Opening_Click(object sender, EventArgs e)
        {
            int[,,] rgb = GetRGBData(img);
            img = SetRGBData(opening.process(rgb, img.Width, img.Height));
            pictureBox5.Image = img;
        }

        private void button_Connected_Click(object sender, EventArgs e)
        {
            if (img.Width >= 1500 || Height >= 1500)
            {
                img = SetRGBData(connected.maxPooling(img));
            }
            
            //int[,,] rgb = GetRGBData(img);
            //img = SetRGBData(connected.process(img, img.Width, img.Height));
            img = connected.process(img, img.Width, img.Height);
            pictureBox5.Image = img;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rbar.Value = 0;
            Gbar.Value = 0;
            Bbar.Value = 0;

            Image accessoryImg = Image.FromFile("Hat/" + comboBox1.SelectedItem + ".jpg");
            accessoryBmp = Accessory.ClearBack((Bitmap)accessoryImg);
            hat.Image = accessoryBmp;
            HatColorful = accessoryBmp;
        }

        private void poolingBtn_Click(object sender, EventArgs e)
        {
            int poolingFlag = Math.Max(img.Width / 700, img.Height / 700);
            if (poolingFlag > 1)
            {
                img = SetRGBData(facialFeatures.maxPooling(img, poolingFlag));
            }
            pictureBox5.Image = img;
        }

        private void findFaceBtn_Click(object sender, EventArgs e)
        {
            firstXY = facialFeatures.firstPoint(img);
            faceXY = facialFeatures.findRange(img, firstXY);
            int marLen = (faceXY[2] - faceXY[0]) / 15;
            resultImg = new Bitmap(img.Width, img.Height);
            Graphics g = Graphics.FromImage(resultImg);
            Pen pen = new Pen(Color.Red, img.Width / 110);

            g.DrawImage(img, 0, 0);

            g.DrawLine(pen, firstXY[0] - marLen, firstXY[1], firstXY[0] + marLen, firstXY[1]);
            g.DrawLine(pen, firstXY[0], firstXY[1] - marLen, firstXY[0], firstXY[1] + marLen);

            pen = new Pen(Color.Green, img.Width / 110);
            g.DrawEllipse(pen, faceXY[3], faceXY[0]
                , faceXY[1] - faceXY[3], faceXY[2] - faceXY[0]);
            g.Dispose();

            pictureBox5.Image = resultImg;
        }

        private void facialFeaturesBtn_Click(object sender, EventArgs e)
        {
            int k = 6;
            faceFeature = facialFeatures.findFaceFeature(img, faceXY, k);
            int marLen = (faceXY[2] - faceXY[0]) / 15;
            Graphics g = Graphics.FromImage(resultImg);
            Pen pen = new Pen(Color.DeepSkyBlue, img.Width / 110);

            for (int i = 0; i < k; i++)
            {
                g.DrawLine(pen
                    , faceFeature[i, 0] - marLen, faceFeature[i, 1]
                    , faceFeature[i, 0] + marLen, faceFeature[i, 1]);
                g.DrawLine(pen
                    , faceFeature[i, 0], faceFeature[i, 1] - marLen
                    , faceFeature[i, 0], faceFeature[i, 1] + marLen);
            }
            g.Dispose();
            pictureBox5.Image = resultImg;
        }

        private void combineBtn_Click(object sender, EventArgs e)
        {
            Bitmap resultBmp = new Bitmap(img_origin.Width, img_origin.Height);
            Graphics g = Graphics.FromImage(resultBmp);

            Pen penR = new Pen(Color.Red, 10);
            Pen penG = new Pen(Color.Green, 10);
            int poolingFlag = Math.Max(img_origin.Height / 700, img_origin.Width / 700);

            if (poolingFlag == 0) poolingFlag = 1;
            int[] forahead = { (faceFeature[1, 0] + faceFeature[0, 0]) / 2 * poolingFlag
                    , (int)((faceFeature[0, 1] + faceFeature[1, 1])/2 - ((faceFeature[1, 0] - faceFeature[0, 0]) * 0.3)) * poolingFlag };
            double sizeRate = (double)((faceXY[1] - faceXY[3]) * poolingFlag)
                                / (double)(Accessory.accessoryXY[1] - Accessory.accessoryXY[3]) * 1.5;

            g.DrawImage(img_origin, 0, 0);
            g.DrawImage(HatColorful
                , forahead[0] - (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2)
                , forahead[1] - (int)(Accessory.accessoryXY[2] * sizeRate)
                , (int)(HatColorful.Width * sizeRate)
                , (int)(HatColorful.Height * sizeRate));

            g.DrawLine(penR, forahead[0] - resultBmp.Width / 20, forahead[1], forahead[0] + resultBmp.Width / 20, forahead[1]);
            g.DrawLine(penR, forahead[0], forahead[1] - resultBmp.Width / 20, forahead[0], forahead[1] + resultBmp.Width / 20);
            g.DrawLine(penG
                , forahead[0] - (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) + (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) - resultBmp.Width / 20
                , forahead[1] - (int)(Accessory.accessoryXY[2] * sizeRate) + (int)((Accessory.accessoryXY[2] + Accessory.accessoryXY[0]) * sizeRate / 2)
                , forahead[0] - (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) + (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) + resultBmp.Width / 20
                , forahead[1] - (int)(Accessory.accessoryXY[2] * sizeRate) + (int)((Accessory.accessoryXY[2] + Accessory.accessoryXY[0]) * sizeRate / 2));
            g.DrawLine(penG
                , forahead[0] - (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) + (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2)
                , forahead[1] - (int)(Accessory.accessoryXY[2] * sizeRate) + (int)((Accessory.accessoryXY[2] + Accessory.accessoryXY[0]) * sizeRate / 2) - resultBmp.Width / 20
                , forahead[0] - (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2) + (int)((Accessory.accessoryXY[1] + Accessory.accessoryXY[3]) * sizeRate / 2)
                , forahead[1] - (int)(Accessory.accessoryXY[2] * sizeRate) + (int)((Accessory.accessoryXY[2] + Accessory.accessoryXY[0]) * sizeRate / 2) + resultBmp.Width / 20);

            g.Dispose();
            pictureBox1.Image = resultBmp;
        }

        private void RValueChange(object sender, EventArgs e)
        {
            RGB_bar();
        }

        private void GValueChange(object sender, EventArgs e)
        {
            RGB_bar();
        }

        private void BValueChange(object sender, EventArgs e)
        {
            RGB_bar();
        }
    }
}
