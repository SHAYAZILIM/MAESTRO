using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucKiymetTakdiri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public bool EkspertizKaydiMi;

        public bool HacizKayitEkraniMi;

        private AV001_TI_BIL_KIYMET_TAKDIRI addNew;

        private TList<TI_KOD_MAL_CINS> MallarDataSource = new TList<TI_KOD_MAL_CINS>();

        private ViewType myType;

        public ucKiymetTakdiri()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_KIYMET_TAKDIRI> MyDataSource
        {
            get { return (TList<AV001_TI_BIL_KIYMET_TAKDIRI>)gridKiymetTakdiri.DataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    dnKiymetTakdiri.DataSource = value;
                    gridKiymetTakdiri.DataSource = dnKiymetTakdiri.DataSource;
                    vGKiymetTakdiri.DataSource = dnKiymetTakdiri.DataSource;
                    foreach (AV001_TI_BIL_KIYMET_TAKDIRI var in value)
                    {
                        var.ColumnChanged += var_ColumnChanged;
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MyType
        {
            get { return myType; }
            set
            {
                myType = value;
                if (value == ViewType.GridView)
                {
                    panelControl1.Visible = false;
                    gridKiymetTakdiri.Visible = true;
                    extendedGridControl1.Visible = false;
                    gridKiymetTakdiri.BringToFront();
                }
                if (value == ViewType.LayoutView)
                {
                    panelControl1.Visible = false;
                    gridKiymetTakdiri.Visible = false;
                    extendedGridControl1.Visible = true;
                    extendedGridControl1.BringToFront();
                }
                if (value == ViewType.VGrid)
                {
                    panelControl1.Visible = true;
                    gridKiymetTakdiri.Visible = false;
                    extendedGridControl1.Visible = false;
                    panelControl1.BringToFront();
                }
            }
        }

        public static string Validate(AV001_TI_BIL_KIYMET_TAKDIRI row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.HACIZLI_MAL_KATEGORI_ID == 0)
                sb.AppendLine("* Hacizli mal kategorisi boþ olamaz.");
            if (row.HACIZLI_MAL_TUR_ID == 0)
                sb.AppendLine("* Hacizli mal türü boþ olamaz.");
            if (row.HACIZLI_MAL_CINS_ID == 0)
                sb.AppendLine("* Hacizli mal cinsi boþ olamaz.");

            return sb.ToString();
        }

        private void dnKiymetTakdiri_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (e.Button.Tag != null && e.Button.Tag.ToString() == "ListedenGetir")
            //{
            //    frm = new frmHacizliMallar();
            //    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //    frm.Show(MyFoy);
            //}
        }

        private void extendedGridControl1_ButtonClick(object sender,
                                                      DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmKiymetTakdiri frm = new frmKiymetTakdiri();
                frm.MyIcraFoy = MyFoy;
                frm.Show(MyFoy);
            }
        }

        private void gridKiymetTakdiri_ButtonCevirClick(object sender,
                                                        DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (gridKiymetTakdiri.Visible)
            {
                extendedGridControl1.Visible = true;
                gridKiymetTakdiri.Visible = false;
                extendedGridControl1.BringToFront();
            }
            else
            {
                extendedGridControl1.Visible = false;
                gridKiymetTakdiri.Visible = true;
                gridKiymetTakdiri.BringToFront();
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            addNew = e.NewObject as AV001_TI_BIL_KIYMET_TAKDIRI;

            if (addNew == null)
                addNew = new AV001_TI_BIL_KIYMET_TAKDIRI();

            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = "GENEL";
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = 1;
            addNew.ADMIN_KAYIT_MI = true;
            addNew.STAMP = 1;
            addNew.SUBE_KODU = 1;
            addNew.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_ID = 1;
            addNew.HACIZLI_MAL_MIKTARI_DOVIZ_ID = 1;
            addNew.HACIZLI_MAL_ADET_BIRIM_ID = 9;
            addNew.ColumnChanged += var_ColumnChanged;
            e.NewObject = addNew;
        }

        private void ucKiymetTakdiri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!this.DesignMode)
            {
                try
                {
                    BelgeUtil.Inits.perCariAvukatGetir(rlueYeniSahis);
                    BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                    BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                    BelgeUtil.Inits.BirimKodGetir(rlueAdtBirim);
                    BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonuc);

                    if (MyFoy != null)
                    {
                        BelgeUtil.Inits.HacizChildGetir(MyFoy, rlueMallar);
                        if (MyDataSource != null)
                            MyDataSource.AddingNew += MyDataSource_AddingNew;
                    }

                    if (EkspertizKaydiMi)
                    {
                        vGKiymetTakdiri.Rows[1].Properties.Caption = "Ekspertiz Tarihi";
                        vGKiymetTakdiri.Rows.GetRowByFieldName("ITIRAZ_SONUCU").Visible = false;
                        rowKIYMET_TAKDIRI_YAPAN1_ID.Properties.Caption = "Eksper Adý";
                        rowKIYMET_TAKDIRI_YAPAN2_ID.Visible = false;
                        rowKIYMET_TAKDIRI_YAPAN3_ID.Visible = false;
                        rowKIYMET_TAKDIRI_YAPAN4_ID.Visible = false;
                        if (HacizKayitEkraniMi)
                            rowMallar.Visible = false;
                        multiEditorRow1.Visible = false;
                        mRowHACIZLI_MAL_ADET.Visible = false;
                        mRowHACIZLI_MAL_MIKTARI.Visible = false;
                        mrRowRAPOR_TARIHI.Visible = false;
                        rowDEGERIN_KESINLESME_TARIHI.Visible = false;
                        rowITIRAZ_VARMI.Visible = false;
                        rowSIKAYET_VARMI.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void var_ColumnChanged(object sender, AV001_TI_BIL_KIYMET_TAKDIRIEventArgs e)
        {
            if (e.Column == AV001_TI_BIL_KIYMET_TAKDIRIColumn.HACIZLI_MAL_CINS_ID)
            {
                if (MallarDataSource != null)
                {
                    TI_KOD_MAL_CINS cins = DataRepository.TI_KOD_MAL_CINSProvider.GetByID((int)e.Value);
                    addNew.HACIZLI_MAL_KATEGORI_ID = cins.KATEGORI_ID;
                    addNew.HACIZLI_MAL_TUR_ID = cins.TUR_ID;
                }
            }
        }

        #region <MB-20100623>

        //Þahýslar için yeni kayýt ekleyebilmemiz için eklendi.

        public void InsertNewPersonFromLookUpEdit(object obj, RepositoryItemLookUpEdit rlue)
        {
            if (obj == null) return;

            LookUpEdit lue = (LookUpEdit)obj;

            frmCariGenelGiris frm = new frmCariGenelGiris();
            frm.tmpCariAd = lue.Text;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      DialogResult dr = frm.KayitBasarili;
                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                      {
                                          BelgeUtil.Inits.perCariGetir(rlue);

                                          //Bu property, eðer yeni kaydedilen þahýs varsa, gridler üzerindeki lookup'ýn yeniden dolmasýný saðlamak için eklendi.
                                          frmKiymetTakdiri.YeniCariKaydiYapildi = true;
                                      }
                                  };
        }

        private void rlueYeniSahis_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "YeniKayit")
                InsertNewPersonFromLookUpEdit(sender, rlueYeniSahis);
        }

        #endregion <MB-20100623>

        //void frm_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (frm.Secilenler.Count > 0)
        //    {
        //        SecilenleriEkle();
        //    }
        //}
        //private void SecilenleriEkle()
        //{
        //    for (int i = 0; i < frm.Secilenler.Count; i++)
        //    {
        //        AV001_TI_BIL_KIYMET_TAKDIRI kt=MyFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection.AddNew();
        //        if (kt.HACIZ_CHILD_IDSource == null) kt.HACIZ_CHILD_IDSource = new AV001_TI_BIL_HACIZ_CHILD();

        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_CINS_ID = frm.Secilenler[i].HACIZLI_MAL_CINS_ID;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_TUR_ID = frm.Secilenler[i].HACIZLI_MAL_TUR_ID;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_KATEGORI_ID = frm.Secilenler[i].HACIZLI_MAL_KATEGORI_ID;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_DEGERI_DOVIZ_ID = frm.Secilenler[i].HACIZLI_MAL_DEGERI_DOVIZ_ID;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_DEGERI = frm.Secilenler[i].HACIZLI_MAL_DEGERI.Value;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_ADET_BIRIM_ID = frm.Secilenler[i].HACIZLI_MAL_ADET_BIRIM_ID;
        //        kt.HACIZ_CHILD_IDSource.HACIZLI_MAL_ADEDI = frm.Secilenler[i].HACIZLI_MAL_ADEDI;

        //    }
        //    vGKiymetTakdiri.DataSource = MyFoy.AV001_TI_BIL_KIYMET_TAKDIRICollection;

        //}
    }
}