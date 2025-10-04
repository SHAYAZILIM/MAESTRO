using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AvukatProImageEditor
{
    public partial class AvproImageEditor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Fields

        private string _openedFile;
        private Point _Position;
        private string _text;
        private Font _yaziTipi;
        private Bitmap bmp;
        private Font fnt;

        #endregion Fields

        #region Constructors

        public AvproImageEditor()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string OpenedFile
        {
            get { return _openedFile; }
            set
            {
                _openedFile = value;
                this.c_txtDosya.Text = value;
                c_pnlResim.ContentImage = Image.FromFile(value);
            }
        }

        public Image OpenedImage
        {
            get { return this.c_pnlResim.ContentImage; }
            set { this.c_pnlResim.ContentImage = value; }
        }

        public Point Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Font YaziTipi
        {
            get { return _yaziTipi; }
            set { _yaziTipi = value; }
        }

        #endregion Properties

        #region Methods

        public static List<Deger> TabloAlani()
        {
            List<Deger> returnValues = new List<Deger>();

            Deger deger = new Deger();
            deger.Ad = "Icra";
            deger.Tip = typeof(string);
            deger.Id = 1;
            deger.Degeri = "AV001_TI_BIL_FOY";
            deger.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger);

            Deger deger2 = new Deger();
            deger2.Ad = "Dava";
            deger2.Id = 2;
            deger2.Tip = typeof(string);
            deger2.Degeri = "AV001_TD_BIL_FOY";
            deger2.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger2);

            Deger deger3 = new Deger();
            deger3.Ad = "Rücu";
            deger3.Id = 3;
            deger3.Tip = typeof(string);
            deger3.Degeri = "AV001_TDI_BIL_RUCU";
            deger3.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger3);

            Deger deger4 = new Deger();
            deger4.Ad = "Hazırlık";
            deger4.Id = 4;
            deger4.Tip = typeof(string);
            deger4.Degeri = "AV001_TD_BIL_HAZIRLIK";
            deger4.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger4);

            Deger deger5 = new Deger();
            deger5.Ad = "Sözleşme";
            deger5.Id = 5;
            deger5.Tip = typeof(string);
            deger5.Degeri = "AV001_TDI_BIL_SOZLESME";
            deger5.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger5);

            Deger deger6 = new Deger();
            deger6.Ad = "Tebligat";
            deger6.Id = 6;
            deger6.Tip = typeof(string);
            deger6.Degeri = "AV001_TDI_BIL_TEBLIGAT";
            deger6.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger6);

            Deger deger7 = new Deger();
            deger7.Ad = "Muhasebe";
            deger7.Id = 7;
            deger7.Tip = typeof(string);
            deger7.Degeri = "AV001_TDI_BIL_MUHASEBE";
            deger7.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger7);

            Deger deger8 = new Deger();
            deger8.Ad = "Görev";
            deger8.Id = 8;
            deger8.Tip = typeof(string);
            deger8.Degeri = "AV001_TDI_BIL_IS_GOREV";
            deger8.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger8);

            Deger deger9 = new Deger();
            deger9.Ad = "Mesaj";
            deger9.Id = 9;
            deger9.Tip = typeof(string);
            deger9.Degeri = "AV001_TDIE_BIL_MESAJ";
            deger9.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger9);

            Deger deger10 = new Deger();
            deger10.Ad = "İş";
            deger10.Id = 10;
            deger10.Tip = typeof(string);
            deger10.Degeri = "AV001_TDI_BIL_IS";
            deger10.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger10);

            Deger deger11 = new Deger();
            deger11.Ad = "Belge";
            deger11.Id = 11;
            deger11.Tip = typeof(string);
            deger11.Degeri = "AV001_TDIE_BIL_BELGE";
            deger11.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger11);

            Deger deger12 = new Deger();
            deger12.Ad = "Cari";
            deger12.Id = 12;
            deger12.Tip = typeof(string);
            deger12.Degeri = "AV001_TDI_BIL_CARI";
            deger12.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger12);

            Deger deger13 = new Deger();
            deger13.Ad = "Haciz";
            deger13.Id = 13;
            deger13.Tip = typeof(string);
            deger13.Degeri = "AV001_TI_BIL_HACIZ";
            deger13.Aciklama = "Bir Tablosu ile ilişkili Koşullar";
            returnValues.Add(deger13);

            Deger deger14 = new Deger();
            deger14.Ad = "Değer";
            deger14.Id = 14;
            deger14.Degeri = "VALUE";
            deger14.Tip = typeof(object);
            deger14.Aciklama = "Bir Değer ile ilişkili Koşullar";
            returnValues.Add(deger14);

            return returnValues;
        }

        public void GetImageFromControl()
        {
            bmp = new Bitmap(c_pnlResim.ContentImage);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < c_pnlResim.Controls.Count; i++)
            {
                if (c_pnlResim.Controls[i] is LabelControl)
                {
                    LabelControl lblCnt = (LabelControl)c_pnlResim.Controls[i];
                    int lft = lblCnt.Left;
                    int tp = lblCnt.Top;
                    string tx = lblCnt.Text;
                    g.DrawString(tx, fnt, Brushes.Black, lft, tp);
                }
            }
        }

        private void AvproImageEditor_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = TabloAlani();
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.ValueMember = "Degeri";
            lookUpEdit2.Properties.ValueMember = "Name";
            lookUpEdit2.Properties.DisplayMember = "Name";
        }

        private void c_txtFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            c_txtFont.Text = fontDialog1.Font.ToString();
            c_mmYazi.Font = fontDialog1.Font;
            fnt = fontDialog1.Font;
            _yaziTipi = fontDialog1.Font;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            c_txtFont.Text = fontDialog1.Font.ToString();
            c_mmYazi.Font = fontDialog1.Font;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit2.Properties.DataSource = Datas.TablesColumn.TablesColumnData.GetColumns(lookUpEdit1.EditValue.ToString());
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenedFile = c_openFileDialog.FileName;
            c_pePosition.BackgroundImage = Image.FromFile(c_openFileDialog.FileName);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            c_openFileDialog.ShowDialog();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            LabelControl lbl = new LabelControl();

            lbl.Text = c_mmYazi.Text;

            this.c_pnlResim.Controls.Add(lbl);
            lbl.AutoSizeMode = LabelAutoSizeMode.Default;
            lbl.Left = c_pnlResim.Left;
            lbl.Top = c_pnlResim.Top;
            lbl.Height = lbl.Font.Height;
            int indexci = 0;
            while (lbl.Width > c_pnlResim.Width)
            {
                indexci++;
                lbl.Text = lbl.Text.Insert(this.c_pnlResim.Width / (lbl.Font.Height / 2) * indexci, Environment.NewLine);

                lbl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                lbl.Width = c_pnlResim.Width - 10;
            }
            lbl.Font = fnt;
            lbl.BringToFront();
            this.mover2.MyControl = lbl;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this._Position = c_pePosition.Location;
            this._text = this.c_mmYazi.Text;
            this.Close();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            c_mmYazi.SelectedText += lookUpEdit2.EditValue.ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            GetImageFromControl();
            bmp.Save("c:\\aaa.bmp");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            c_pePosition.Top = 10;
            c_pePosition.Left = 10;
        }

        #endregion Methods

        #region Nested Types

        public class Deger
        {
            #region Fields

            private string _aciklama;
            private string _ad;
            private string _deger;
            private int _id;
            private Type _tip;

            #endregion Fields

            #region Properties

            public string Aciklama
            {
                get { return _aciklama; }
                set { _aciklama = value; }
            }

            public string Ad
            {
                get { return _ad; }
                set { _ad = value; }
            }

            public string Degeri
            {
                get { return _deger; }
                set { _deger = value; }
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public Type Tip
            {
                get { return _tip; }
                set { _tip = value; }
            }

            #endregion Properties
        }

        #endregion Nested Types
    }
}