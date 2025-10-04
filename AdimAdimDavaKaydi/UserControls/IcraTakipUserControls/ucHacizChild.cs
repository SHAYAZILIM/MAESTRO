using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using AdimAdimDavaKaydi.IcraTakipForms;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucHacizChild : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHacizChild()
        {
            InitializeComponent();
            this.Load += ucHacizChild_Load;
        }

        public void KategoriyeGoreAlanlar(bool aracMi)
        {
            if (aracMi)
            {
                vgHacizChild.Rows["mRowMalDeger"].Visible = true;
                vgHacizChild.Rows["rowARAC_PLAKA_NO"].Visible = true;
                vgHacizChild.Rows["rowHACIZ_ISLEM_DURUM_ID"].Visible = true;
                vgHacizChild.Rows["rowYEDIEMIN_CARI_ID"].Visible = true;
            }
            else
            {
                vgHacizChild.Rows["mRowMalDeger"].Visible = false;
                vgHacizChild.Rows["rowARAC_PLAKA_NO"].Visible = false;
                vgHacizChild.Rows["rowHACIZ_ISLEM_DURUM_ID"].Visible = false;
                vgHacizChild.Rows["rowYEDIEMIN_CARI_ID"].Visible = false;
            }
        }

        private void MalCinsEkle(object sender)
        {
            //LookUpEdit lue = (LookUpEdit)sender;
            //if (lue.Text != "")
            //{
            //    AV001_TI_BIL_HACIZ_CHILD HacizChild = MyDataSource[vgHacizChild.FocusedRecord];
            //    if (HacizChild.HACIZLI_MAL_KATEGORI_ID == null && HacizChild.HACIZLI_MAL_KATEGORI_ID <= 0)
            //    {
            //        XtraMessageBox.Show("Lütfen Önce Bir Mal Kategorisi Seçiniz");
            //        return;
            //    }
            //    TI_KOD_MAL_CINS maltur = new TI_KOD_MAL_CINS();
            //    maltur.KATEGORI_ID = HacizChild.HACIZLI_MAL_KATEGORI_ID;
            //    maltur.CINS = lue.Text;
            //    maltur.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            //    maltur.KATEGORI = HacizChild.HACIZLI_MAL_KATEGORI_IDSource.KATEGORI;
            //    DataRepository.TI_KOD_MAL_CINSProvider.Save(maltur);
            //    BelgeUtil.Inits.MalCinsGetirRefersh();
            //    BelgeUtil.Inits.MalcinsGetir(rlueMalCinsi);
            //    VList<per_TI_KOD_MAL_CINS> TUR = rlueMalCinsi.DataSource as VList<per_TI_KOD_MAL_CINS>;
            //    TUR.Filter = "KATEGORI_ID = " + HacizChild.HACIZLI_MAL_KATEGORI_ID;
            //    rlueMalCinsi.DataSource = TUR;
            //}

            AV001_TI_BIL_HACIZ_CHILD HacizChild = MyDataSource[vgHacizChild.FocusedRecord];
            if (HacizChild.HACIZLI_MAL_KATEGORI_ID == null && HacizChild.HACIZLI_MAL_KATEGORI_ID <= 0)
            {
                XtraMessageBox.Show("Lütfen Önce Bir Mal Kategorisi Seçiniz");
                return;
            }

            if (HacizChild.HACIZLI_MAL_TUR_ID == null && HacizChild.HACIZLI_MAL_TUR_ID <= 0)
            {
                XtraMessageBox.Show("Lütfen Önce Bir Mal Türü Seçiniz");
                return;
            }

            frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.MalCinsi, HacizChild.HACIZLI_MAL_KATEGORI_ID);
            frmalt.SEKTOR_ID = HacizChild.HACIZLI_MAL_TUR_ID;
            frmalt.ShowDialog();

            AvukatPro.Services.Implementations.DevExpressService.MalcinsGetirTureGore(rlueMalCins, HacizChild.HACIZLI_MAL_TUR_ID);
        }

        private void MalTurEkle(object sender)
        {
            //LookUpEdit lue = (LookUpEdit)sender;
            //if (lue.Text != "")
            //{
            AV001_TI_BIL_HACIZ_CHILD HacizChild = MyDataSource[vgHacizChild.FocusedRecord];
            if (HacizChild.HACIZLI_MAL_KATEGORI_ID == null && HacizChild.HACIZLI_MAL_KATEGORI_ID <= 0)
            {
                XtraMessageBox.Show("Lütfen Önce Bir Mal Kategorisi Seçiniz");
                return;
            }


            frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.MalTuru, HacizChild.HACIZLI_MAL_KATEGORI_ID);
            frmalt.ShowDialog();

            BelgeUtil.Inits.MalTurGetirKategoriyeGore(rlueMalTur, HacizChild.HACIZLI_MAL_KATEGORI_ID);


            //TI_KOD_MAL_TUR maltur = new TI_KOD_MAL_TUR();
            //maltur.KATEGORI_ID = HacizChild.HACIZLI_MAL_KATEGORI_ID;
            //maltur.TUR = lue.Text;
            //maltur.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            //maltur.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            //maltur.KATEGORI = HacizChild.HACIZLI_MAL_KATEGORI_IDSource.KATEGORI;
            //maltur.KOD = lue.Text.Substring(0, 3).ToUpper();
            //DataRepository.TI_KOD_MAL_TURProvider.Save(maltur);
            //BelgeUtil.Inits.MalTurGetirRefersh();
            //BelgeUtil.Inits.MalTurGetir(rlueMalTur);
            //VList<per_TI_KOD_MAL_TUR> TUR = rlueMalTur.DataSource as VList<per_TI_KOD_MAL_TUR>;
            //TUR.Filter = "KATEGORI_ID = " + HacizChild.HACIZLI_MAL_KATEGORI_ID;
            //rlueMalTur.DataSource = TUR;
            //}
        }

        private void rlueMalCins_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "MalCins")
                MalCinsEkle(sender);
        }

        private void rlueMalCins_ProcessNewValue(object sender,
                                                 DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            MalCinsEkle(sender);
        }

        private void rlueMalTur_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "MalTur")
                MalTurEkle(sender);
        }

        private void rlueMalTur_ProcessNewValue(object sender,
                                                DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            MalTurEkle(sender);
        }

        private void rlueYeddiemin_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;

            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.Button.Tag.ToString() == "mEkle")
            {
                try
                {
                    if (lue.Text != string.Empty)
                    {
                        cari.tmpCariAd = lue.Text;
                        cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cari.Show();
                        DialogResult dr = cari.KayitBasarili;

                        if (dr == System.Windows.Forms.DialogResult.OK)
                        {
                            ((TList<AV001_TDI_BIL_CARI>)(rlueYeddiemin.DataSource)).Add(cari.MyCari);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rlueYeddiemin_ProcessNewValue(object sender,
                                                   DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (lue.Text != string.Empty)
            {
                try
                {
                    if (lue.Text != string.Empty)
                    {
                        cari.tmpCariAd = lue.Text;
                        cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        cari.Show();
                        cari.FormClosed += delegate
                                               {
                                                   DialogResult dr = cari.KayitBasarili;
                                                   if (dr == System.Windows.Forms.DialogResult.OK)
                                                   {
                                                       BelgeUtil.Inits.perCariGetir(rlueYeddiemin);
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

        private void ucHacizChild_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.MalTurGetir(rlueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rlueMalCins);
            BelgeUtil.Inits.MalKategoriGetir(rlueMalKat);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.HacizIslemDurumGetir(rlueHacizIslemDurum);
            BelgeUtil.Inits.perCariGetir(rlueYeddiemin);
        }

        #region Properties

        private int _MyKategoriID;

        private int _MyTurId;

        [Browsable(false),
         Description("Haciz Child FocusedRecordIndex"),
         Category("Haciz Child Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HacizChildFocusedRecord
        {
            get
            {
                if (vgHacizChild.FocusedRecord < 0)
                    return 0;

                return vgHacizChild.FocusedRecord;
            }
        }

        [Browsable(false),
         Description("DataSource"),
         Category("Haciz Child Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_CHILD> MyDataSource
        {
            get
            {
                if (vgHacizChild.DataSource is TList<AV001_TI_BIL_HACIZ_CHILD> && vgHacizChild.DataSource != null)
                    return (TList<AV001_TI_BIL_HACIZ_CHILD>)vgHacizChild.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    dnHacizChild.DataSource = value;
                    vgHacizChild.DataSource = dnHacizChild.DataSource;
                }
            }
        }

        [Browsable(false), Description("AV001_TI_BIL_FOY"), Category("Haciz Child Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MyKategoriID
        {
            get { return _MyKategoriID; }
            set
            {
                if (value != null)
                {
                    _MyKategoriID = value;
                    BelgeUtil.Inits.MalTurGetirKategoriyeGore(rlueMalTur, value);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MyTurId
        {
            get { return _MyTurId; }
            set
            {
                if (value != null)
                {
                    _MyTurId = value;
                    //BelgeUtil.Inits.MalcinsGetirTureGore(rlueMalCins, value);
                    AvukatPro.Services.Implementations.DevExpressService.MalcinsGetirTureGore(rlueMalCins, value);
                }
            }
        }

        #endregion Properties

        #region Events

        [Category("Haciz Child Events")]
        public event IndexChangedEventHandler HacizChildFocusedRecordChanged;

        [Category("Haciz Child Events")]
        public event ListedenGetirEventHandler HacizChildListedenGetir;

        [Category("Haciz Child Events")]
        public event ValidateRecordEventHandler HacizChildValidateRecord;

        private void dnHacizChild_OnListedenGetirClick(object sender, ListedenGetirEventArgs e)
        {
            if (HacizChildListedenGetir != null)
            {
                HacizChildListedenGetir(sender, e);
            }
        }

        private void vgHacizChild_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (HacizChildFocusedRecordChanged != null)
            {
                HacizChildFocusedRecordChanged(sender, e);
            }
        }

        private void vgHacizChild_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            if (HacizChildValidateRecord != null)
            {
                HacizChildValidateRecord(sender, e);
            }
        }

        #endregion Events

        #region Static Methods

        /// <summary>
        /// Otomatik mal sýra numarasý
        /// </summary>
        /// <param name="list">AV001_TI_BIL_HACIZ_CHILD türündeki kayýtlarýn tutulduðu temp liste</param>
        /// <param name="foy">AV001_TI_BIL_FOY türündeki dosya üzerindeki aktif foy nesnesi</param>
        /// <returns>MAL_SIRA_NO</returns>
        public static int MalSiraNo(AV001_TI_BIL_HACIZ_MASTER master)
        {
            int i = 1;

            if (master.AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(master, false, DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));

            if (master.AV001_TI_BIL_HACIZ_CHILDCollection.Count > 0)
            {
                int sonMalSira = master.AV001_TI_BIL_HACIZ_CHILDCollection.Last().MAL_SIRA_NO;

                i = ++sonMalSira;
            }

            return i;
        }

        #endregion Static Methods
    }
}