using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    internal class BarCodeCODE39Generator
    {
        private String alphabet39 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";

        private String code = "1234567890";

        private String[] coded39Char =
        {
            /* 0 */ "000110100",
            /* 1 */ "100100001",
            /* 2 */ "001100001",
            /* 3 */ "101100000",
            /* 4 */ "000110001",
            /* 5 */ "100110000",
            /* 6 */ "001110000",
            /* 7 */ "000100101",
            /* 8 */ "100100100",
            /* 9 */ "001100100",
            /* A */ "100001001",
            /* B */ "001001001",
            /* C */ "101001000",
            /* D */ "000011001",
            /* E */ "100011000",
            /* F */ "001011000",
            /* G */ "000001101",
            /* H */ "100001100",
            /* I */ "001001100",
            /* J */ "000011100",
            /* K */ "100000011",
            /* L */ "001000011",
            /* M */ "101000010",
            /* N */ "000010011",
            /* O */ "100010010",
            /* P */ "001010010",
            /* Q */ "000000111",
            /* R */ "100000110",
            /* S */ "001000110",
            /* T */ "000010110",
            /* U */ "110000001",
            /* V */ "011000001",
            /* W */ "111000000",
            /* X */ "010010001",
            /* Y */ "110010000",
            /* Z */ "011010000",
            /* - */ "010000101",
            /* . */ "110000100",
            /*' '*/ "011000100",
            /* $ */ "010101000",
            /* / */ "010100010",
            /* + */ "010001010",
            /* % */ "000101010",
            /* * */ "010010100"
        };

        private Font footerFont = new Font("Arial", 10, FontStyle.Bold);

        private Font headerFont = new Font("Courier", 10, FontStyle.Bold);

        private String headerText = "kenan ersoy";

        private int height = 20;

        private bool showFooter;

        private bool showHeader;

        private BarCodeWeight weight = BarCodeWeight.Small;

        public enum AlignType
        {
            Left, Center, Right
        }

        public enum BarCodeWeight
        {
            Small = 1, Medium, Large
        }

        public String BarCode
        {
            get { return code; }
            set { code = value.ToUpper(); }
        }

        public void SaveImage(String file, int barkodTip)
        {
            int a = 0;
            int b = 0;
            int i = 0;
            for (i = 0; i < 12; i++)
            {
                int bCode;
                bCode = Convert.ToInt32(BarCode.Substring(i, 1));
                if (i % 2 == 1)
                {
                    b += bCode;
                }
                else
                {
                    a += bCode;
                }
            }
            i = (a + (b * 3)) % 10;
            if (i == 0)
            {
                //   bCode[12] = 0;
                BarCode = BarCode + "0";
            }
            else
            {
                //  bCode[12] = (byte)((int)(10 - i));
                BarCode = BarCode + (10 - i).ToString();
            }

            Bitmap bmp = new Bitmap(260, 50, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            if (barkodTip == 4)
            {
                showHeader = true;
                showFooter = true;
                headerText = "HIZLI TEBLİGAT";
                //Font headerFont = new Font("times new roman", 8);
                //PointF headerPoint = new PointF(0, 0);
                //g.DrawString("HIZLI TEBLİGAT", headerFont, Brushes.Black, headerPoint);
            }
            else if (barkodTip == 2)
            {
                showHeader = true;
                showFooter = true;
                headerText = "TAAHHÜTLÜ";
            }
            else
            {
                showHeader = false;
                showFooter = true;
                headerText = "";
            }
            Rectangle rec = new Rectangle(0, 0, 260, 50);
            g.FillRectangle(Brushes.White, rec);
            Paint(null, new PaintEventArgs(g, rec));
            bmp.Save(file);
        }

        private void Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            String intercharacterGap = "0";
            String str = '*' + code.ToUpper() + '*';
            int strLength = str.Length;

            for (int i = 0; i < code.Length; i++)
            {
                if (alphabet39.IndexOf(code[i]) == -1 || code[i] == '*')
                {
                    // Font headerFont = new Font("times new roman", 8);
                    e.Graphics.DrawString("INVALID BAR CODE TEXT", headerFont, Brushes.Red, 10, 10);
                    return;
                }
            }

            String encodedString = "";

            for (int i = 0; i < strLength; i++)
            {
                if (i > 0)
                    encodedString += intercharacterGap;

                encodedString += coded39Char[alphabet39.IndexOf(str[i])];
            }

            int encodedStringLength = encodedString.Length;
            double wideToNarrowRatio = 3;

            int x = 10;
            int yTop = 15;
            int wid = 20;
            int footerX = 10;

            for (int i = 0; i < encodedStringLength; i++)
            {
                if (encodedString[i] == '1')
                    wid = (int)(wideToNarrowRatio * (int)weight);
                else
                    wid = (int)weight;

                e.Graphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, x, yTop, wid, height); // barkodu renk veriyo çizgiler siyah boşluklar beyaz

                x += wid;
            }

            yTop += height;

            if (showFooter)
            {
                e.Graphics.DrawString(code, footerFont, Brushes.Black, footerX, yTop);
            }
            if (showHeader)
            {
                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, 10, 0);
            }
        }
    }
}