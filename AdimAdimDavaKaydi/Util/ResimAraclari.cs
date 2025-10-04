using System.Drawing;
using System.IO;

namespace AdimAdimDavaKaydi.Util
{
    public static class ResimAraclari
    {
        public static Image ResmiBoyutlandir(Image orjImg, Size size, bool orantila)
        {
            Size orjSize = orjImg.Size;

            //Tekrar tekrar boyutlandırmayalım diye
            if (orjImg.Width == size.Width
                && orjImg.Height == size.Height)
                return null;

            decimal imgPercent = 0;
            if (orantila)
            {
                if (orjSize.Height > orjSize.Width)
                {
                    imgPercent = orjSize.Width / (decimal)orjSize.Height;
                    size.Width = (int)(size.Width * imgPercent);
                }
                else
                {
                    imgPercent = orjSize.Height / (decimal)orjSize.Width;
                    size.Height = (int)(size.Height * imgPercent);
                }
            }
            Bitmap result = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            g.DrawImage(orjImg, 0, 0, size.Width, size.Height);
            g.Dispose();
            orjImg.Dispose();

            return result;
        }

        public static byte[] ResmiBoyutlandir(byte[] img, Size size)
        {
            return ResmiBoyutlandir(img, size, false);
        }

        public static byte[] ResmiBoyutlandir(byte[] img, Size size, bool orantila)
        {
            MemoryStream ms = new MemoryStream(img);
            Image orjImg = System.Drawing.Image.FromStream(ms);

            orjImg = ResmiBoyutlandir(orjImg, size, orantila);

            MemoryStream fs = new MemoryStream();

            orjImg.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] dizi = fs.GetBuffer();

            return dizi;
        }

        public static Image GetImage(byte[] dizi)
        {
            Image result;

            MemoryStream ms = new MemoryStream();
            ms.Write(dizi, 0, dizi.Length);

            result = System.Drawing.Image.FromStream(ms);
            ms.Dispose();

            return result;
        }
    }
}