using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sozlesme.Forms
{
    public partial class frmSozlesmeGelismeAsamalari : AvpXtraForm
    {
        private bool kaydedildi;

        private TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM> myDataSource;

        private AV001_TDI_BIL_SOZLESME mySozlesme;

        public frmSozlesmeGelismeAsamalari()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmSozlesmeGelismeAsamalari_FormClosing;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDataSource = value;
                    dnAsama.DataSource = value;
                    vgAsama.DataSource = dnAsama.DataSource;
                }
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
                    MyDataSource = new TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM>();
                MyDataSource.AddingNew += MyDataSource_AddingNew;

                // MyDataSource.AddNew();
            }
        }
        
        private bool CikabilirMi()
        {
            foreach (
                AV001_TDI_BIL_SOZLESME_GELISME_ADIM gelisme in MySozlesme.AV001_TDI_BIL_SOZLESME_GELISME_ADIMCollection)
            {
                if (gelisme.IsNew || gelisme.IsDirty)
                {
                    return false;
                }
            }

            return true;
        }

        private void frmSozlesmeGelismeAsamalari_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmSozlesmeGelismeAsamalari_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmSozlesmeGelismeAsamalari_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmSozlesmeGelismeAsamalari_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadData();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSozlesmeGelismeAsamalari_Button_Kaydet_Click;
        }

        private void LoadData()
        {
            BelgeUtil.Inits.SozlesmeGelismeAdimGetir(rLueGelismeAdim);
            BelgeUtil.Inits.perCariGetir(rLueCari);
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        private bool Save()
        {
            bool sonuc = false;

            MyDataSource.ForEach(delegate(AV001_TDI_BIL_SOZLESME_GELISME_ADIM k) { k.SOZLESME_ID = MySozlesme.ID; });
            MySozlesme.AV001_TDI_BIL_SOZLESME_GELISME_ADIMCollection.AddRange(MyDataSource);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_SOZLESME_GELISME_ADIMProvider.DeepSave(tran,
                                                                                    MySozlesme.
                                                                                        AV001_TDI_BIL_SOZLESME_GELISME_ADIMCollection);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < MyDataSource.Count; i++)
                {
                    MySozlesme.AV001_TDI_BIL_SOZLESME_GELISME_ADIMCollection.Remove(MyDataSource[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }
    }
}