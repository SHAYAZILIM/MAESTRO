using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sozlesme.Forms
{
    public partial class frmSozlesmeDetay : Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TDI_BIL_SOZLESME_DETAY> myDataSource;

        private AV001_TDI_BIL_SOZLESME mySozlesme;

        public frmSozlesmeDetay()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmSozlesmeDetay_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_DETAY> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                myDataSource = value;
                if (value != null)
                    initData(value);
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                mySozlesme = value;
                if (MyDataSource == null)
                    MyDataSource = new TList<AV001_TDI_BIL_SOZLESME_DETAY>();
            }
        }

        public void Show(AV001_TDI_BIL_SOZLESME sozlesme)
        {
            this.MySozlesme = sozlesme;
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TDI_BIL_SOZLESME_DETAY detay in MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection)
            {
                if (detay.IsNew || detay.IsDirty)
                {
                    return false;
                }
            }

            return true;
        }

        private void dnSozlesmeDetay_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag == "Sil")
            {
                DialogResult ds = XtraMessageBox.Show("Silmek istediðinizden emin misiniz ?", "Sil",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ds == DialogResult.Yes)
                {
                    try
                    {
                        MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.Remove(
                            (AV001_TDI_BIL_SOZLESME_DETAY)
                            vgSozlesmeDetay.GetRecordObject(vgSozlesmeDetay.FocusedRecord));

                        initData(MyDataSource);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void frmSozlesmeDetay_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                foreach (var item in MyDataSource)
                {
                    if (item.SOZLESME_ID == null)
                        item.SOZLESME_ID = MySozlesme.ID;
                }
                trans.BeginTransaction();
                DataRepository.AV001_TDI_BIL_SOZLESME_DETAYProvider.DeepSave(trans, MyDataSource);
                trans.Commit();
            }
            catch
            {
            }
            this.Close();
        }

        private void frmSozlesmeDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CikabilirMi())
                this.Close();
            else
            {
                DialogResult ds =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmedi.Yinede çýkmak istiyor musunuz ?", "Vazgeç",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ds == DialogResult.Yes)
                {
                    GeriAl();
                    this.Close();
                }
            }
        }

        private void frmSozlesmeDetay_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.MalKategoriGetir(rlueMalKat);
                BelgeUtil.Inits.MalTurGetir(rlueMalTuru);
                BelgeUtil.Inits.MalcinsGetir(rlueMalCinsi);
                BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
                BelgeUtil.Inits.DovizTipGetir(rluedoviz);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);

                this.dnSozlesmeDetay.ButtonClick += dnSozlesmeDetay_ButtonClick;

                MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.DeletedItems.Clear();
            }
        }

        private void GeriAl()
        {
            for (int i = 0; i < MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.Count; i++)
            {
                if (MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection[i].IsNew ||
                    MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection[i].HasDataChanged())
                    MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.RemoveAt(i);
            }

            if (MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.DeletedItems.Count > 0)

                MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.AddRange(
                    MySozlesme.AV001_TDI_BIL_SOZLESME_DETAYCollection.DeletedItems);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSozlesmeDetay_Button_Kaydet_Click;

            // this.Cikiyor += new AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil.OnCikis(frmSozlesmeDetay_Cikiyor);
        }

        private void initData(TList<AV001_TDI_BIL_SOZLESME_DETAY> sDetay)
        {
            dnSozlesmeDetay.DataSource = sDetay;
            vgSozlesmeDetay.DataSource = dnSozlesmeDetay.DataSource;
            gSozlesmeDetay.DataSource = dnSozlesmeDetay.DataSource;
        }
    }
}