using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Properties;
using AdimAdimDavaKaydi.Util;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace AdimAdimDavaKaydi.IcraTakip.component
{
    public partial class GridControlExtender : Control
    {
        public GridControlExtender()
        {
        }

        private ExtendedGridControl _gridControl;
        private XtraForm _form;

        NavigatorCustomButton btnFullScreen = null;
        NavigatorCustomButton btnPrint = null;

        private static bool tamEkran = false;

        public XtraForm Form
        {
            get { return _form; }
            set
            {
                _form = value;
                if (_form != null)
                {
                    formBoyutlari();
                    this._form.SizeChanged += new EventHandler(_form_SizeChanged);
                }
            }
        }

        private void _form_SizeChanged(object sender, EventArgs e)
        {
        }

        public ExtendedGridControl GridControl
        {
            get { return _gridControl; }
            set
            {
                _gridControl = value;
                if (_gridControl != null)
                {
                    AddButtons();
                    GridLocationAl();

                    GridSizeAl();
                    //MessageBox.Show(this._gridSize.Height + " " + GridSize.Width.ToString());
                    //FormSizeAl();
                }
            }
        }

        //[Browsable(true)]
        private Point _gridLocation;

        public Point GridLocation
        {
            get { return _gridLocation; }
            set
            {
                _gridLocation = value;
            }
        }

        private Size _gridSize;

        public Size GridSize
        {
            get { return _gridSize; }
            set { _gridSize = value; }
        }

        private Size _formSize;

        public Size FormSize
        {
            get { return _formSize; }
            set { _formSize = value; }
        }

        private Point GridLocationAl()
        {
            GridLocation = new Point(this.GridControl.Location.X, this.GridControl.Location.Y);
            return GridLocation;
        }

        private Size GridSizeAl()
        {
            GridSize = new Size(this.GridControl.Width, this.GridControl.Height);
            return GridSize;
        }

        //private Size FormSizeAl()
        //{
        //    FormSize = new Size(this._form.Width, this._form.Height);
        //    return FormSize;
        //}

        private void TamEktan()
        {
            List<int> i = formBoyutlari();

            this.GridControl.Width = i[0] - 10;
            this.GridControl.Height = i[1] - 30;

            //this.GridControl.Size = new Size(FormSize.Width, FormSize.Height);
            this.GridControl.Location = new Point(0, 0);
        }

        private void OncekiBoyut()
        {
            //this.GridControl.Height = 300;
            //this.GridControl.Width = 400;

            ////this.GridControl.Location = new Point(this.GridLocation.X, this.GridLocation.Y);

            this.GridControl.Size = new Size(400, 200);
        }

        private List<int> formBoyutlari()
        {
            List<int> size = new List<int>();

            size.Add(this._form.Width);
            size.Add(this._form.Height);

            return size;
        }

        private void AddButtons()
        {
            if (!this.DesignMode)
            {
                GridControl.UseEmbeddedNavigator = true;

                ImageList imgList = new ImageList();
                imgList.Images.Add(Resources.tam_ekran1);

                GridControl.EmbeddedNavigator.Buttons.ImageList = imgList;

                btnFullScreen = new NavigatorCustomButton();
                btnFullScreen.ImageIndex = 0;
                btnFullScreen.Tag = (Int32)0;//0 Önceki Boyut 1 TamEkran
                btnFullScreen.Hint = "Tam ekran";

                btnPrint = new NavigatorCustomButton();
                btnPrint.ImageIndex = 1;
                btnPrint.Tag = (Int32)1;
                btnPrint.Hint = "Yazdýr";

                GridControl.EmbeddedNavigator.Buttons.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[]
             {
                 btnFullScreen,btnPrint
             }
                        );

                this.Invalidate();
                this.Refresh();

                GridControl.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(CustomButtonClick);
            }
        }

        private void CustomButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                if (e.Button.Tag == null) return;

                if ((Int32)e.Button.Tag == 0)
                {
                    if (tamEkran != false)//Önceki Boyut
                    {
                        OncekiBoyut();
                        //MessageBox.Show(this._gridSize.Height + " " + GridSize.Width.ToString());
                        btnFullScreen.Hint = "Ekraný kapla";
                        tamEkran = false;
                    }
                    else//Tam Ekran
                    {
                        TamEktan();
                        //MessageBox.Show(this._gridSize.Height + " " + GridSize.Width.ToString());
                        btnFullScreen.Hint = "Önceki boyuta geri dön.";
                        tamEkran = true;
                    }
                }

                else if ((Int32)e.Button.Tag == 1)
                {
                    DialogResult res = MessageBox.Show("Bu raporu yazdýrmak istediðinizden emin misiniz?", "Yazdýrma Ýþlemi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (res != DialogResult.Cancel)
                        GridControl.Print();
                }
            }

            catch { }
        }
    }
}