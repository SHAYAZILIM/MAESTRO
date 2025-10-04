using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucGayriMenkulTaraf : AvpXUserControl
    {
        public ucGayriMenkulTaraf()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucGayriMenkulTaraf_Load;
        }

        private void ucGayriMenkulTaraf_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            BindData();
        }

        private void InitsData()
        {
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.GayriMenkulTarafSifatGetir(rLueSifat);
        }

        public void RefreshMenkulTaraf()
        {
            gridControl1.RefreshDataSource();
        }

        private TList<AV001_TI_BIL_GAYRIMENKUL_TARAF> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TI_BIL_GAYRIMENKUL_TARAF> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public void BindData()
        {
            if (MyDataSource != null && !this.DesignMode)
            {
                gridControl1.DataSource = MyDataSource;

                extendedGridControl1.DataSource = gridControl1.DataSource;
                InitsData();
            }
        }

        [Category("GayriMenkulTaraf")]
        public event DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler TarafFocusedRowChanged;

        private void gridView1_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (TarafFocusedRowChanged != null)
            {
                TarafFocusedRowChanged(sender, e);
            }
        }

        private void rLueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != string.Empty && e.Button.Tag == "mEkle")
            {
                try
                {
                    frmCariGenelGiris cari = new frmCariGenelGiris();
                    LookUpEdit lue = sender as LookUpEdit;
                    cari.tmpCariAd = lue.Text;
                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                    //.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   BelgeUtil.Inits.perCariGetir(rLueCari);
                                               }
                                           };
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rLueCari_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();
                LookUpEdit lue = sender as LookUpEdit;
                if (lue.Text != string.Empty || (int)lue.EditValue > 0)
                {
                    cari.tmpCariAd = lue.Text;

                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                    // cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   BelgeUtil.Inits.perCariGetir(rLueCari);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}