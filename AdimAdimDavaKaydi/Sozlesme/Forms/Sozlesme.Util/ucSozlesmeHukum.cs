using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeHukum : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeHukum()
        {
            InitializeComponent();
            this.Load += ucSozlesmeHukum_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_HUKUM> MyDataSource
        {
            get
            {
                if (gridControl1.DataSource is TList<AV001_TDI_BIL_SOZLESME_HUKUM>)
                    return (TList<AV001_TDI_BIL_SOZLESME_HUKUM>)gridControl1.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && this.DesignMode == false)
                    gridControl1.DataSource = value;
            }
        }

        private void ucSozlesmeHukum_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            gridView1.OptionsView.ShowPreview = true;
            gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            gridView1.PreviewFieldName = "MADDE_ICERIK";
        }
    }
}