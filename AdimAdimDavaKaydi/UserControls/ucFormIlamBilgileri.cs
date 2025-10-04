using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucFormIlamBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucFormIlamBilgileri()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy { get; set; }

        private TList<AV001_TI_BIL_ILAM_MAHKEMESI> ilamBilgileri = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();

        [Browsable(false)]
        public TList<AV001_TI_BIL_ILAM_MAHKEMESI> IlamBilgileri
        {
            get { return ilamBilgileri; }
            set { ilamBilgileri = value; }
        }

        private void Ekle()
        {
            AV001_TI_BIL_ILAM_MAHKEMESI ilam = new AV001_TI_BIL_ILAM_MAHKEMESI();

            if (lueIlamTipi.EditValue != null)
                ilam.ILAM_TIP_ID = (int)lueIlamTipi.EditValue;

            if (rLueMahkeme.EditValue != null)
                ilam.ADLI_BIRIM_ADLIYE_ID = (int)rLueMahkeme.EditValue;

            if (rLueGorev.EditValue != null)
                ilam.ADLI_BIRIM_GOREV_ID = (int)rLueGorev.EditValue;

            if (dtKararTarihi.EditValue != null)
                ilam.KARAR_TARIHI = dtKararTarihi.DateTime;

            if (dtKararBozulmaTarihi.EditValue != null)
                ilam.KARAR_BOZULMA_TARIHI = dtKararBozulmaTarihi.DateTime;

            if (dtKesinlesmeTarihi.EditValue != null)
                ilam.KARAR_KESINLESME_TARIHI = dtKesinlesmeTarihi.DateTime;

            if (rudTebligGideri.EditValue != null)
                ilam.ILAM_TEBLIG_GIDERI = (decimal)rudTebligGideri.EditValue;

            if (rLueTebligDovizTip.EditValue != null)
                ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID = (int)rLueTebligDovizTip.EditValue;

            if (rudYargilamaGideri.EditValue != null)
                ilam.YARGILAMA_GIDERI = (decimal)rudYargilamaGideri.EditValue;

            if (rLueYargilamaDoviz.EditValue != null)
                ilam.YARGILAMA_GIDERI_DOVIZ_ID = (int)rLueYargilamaDoviz.EditValue;

            if (rudVekaletUcreti.EditValue != null)
                ilam.ILAM_VEKALET_UCRETI = (decimal)rudVekaletUcreti.EditValue;

            if (rLueVekaletDoviz.EditValue != null)
                ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID = (int)rLueYargilamaDoviz.EditValue;

            if (rudInkarTazminati.EditValue != null)
                ilam.INKAR_TAZMINATI = (decimal)rudInkarTazminati.EditValue;

            if (rLueInkarDovizTip.EditValue != null)
                ilam.INKAR_TAZMINATI_DOVIZ_ID = (int)rLueInkarDovizTip.EditValue;
            if (lueAdliBirimNo.EditValue != null)
                ilam.ADLI_BIRIM_NO_ID = (int)lueAdliBirimNo.EditValue;

            ilam.YARGILAMA_GIDERI_FAIZ_ISLESIN_MI = chcYargilamaFaiz.Checked;
            ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI = chcInkarFaiz.Checked;
            ilam.INKAR_TAZMINAT_FAIZ_ISLESIN_MI = chcIlamVekaletFaiz.Checked;
            ilam.ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI = chcIlamTebligFaiz.Checked;
            ilam.ESAS_NO = txtEsasNo.Text;
            ilam.KARAR_NO = txtKararNo.Text;

            Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Add(ilam);
        }

        private void ucFormIlamBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //Týklayýnca gelecekler
                lueIlamTipi.Properties.NullText = "Seç";
                rLueGorev.Properties.NullText = "Seç";
                rLueMahkeme.Properties.NullText = "Seç";
                lueAdliBirimNo.Properties.NullText = "Seç";
                //Dolu gelecekler
                rLueIlamTipID.NullText = "Seç";
                rudInkarTazminati.Properties.NullText = "Seç";
                rudTebligGideri.Properties.NullText = "Seç";
                rudVekaletUcreti.Properties.NullText = "Seç";
                rudYargilamaGideri.Properties.NullText = "Seç";
                rLueTebligDovizTip.Properties.NullText = "Seç";
                rLueVekaletDoviz.Properties.NullText = "Seç";
                rLueYargilamaDoviz.Properties.NullText = "Seç";
                rLueInkarDovizTip.Properties.NullText = "Seç";
                rLueAdliyeBirimAdliyeID.NullText = "Seç";
                rLueDovizID.NullText = "Seç";
                rLueGorevID.NullText = "Seç";
                rTutar.NullText = "Seç";
                rLueAdliBirimNo.NullText = "Seç";
                lueIlamTipi.Enter += BelgeUtil.Inits.IlamTipiGetir_Enter;
                BelgeUtil.Inits.IlamTipiGetir(rLueIlamTipID);
                rLueGorev.Enter += BelgeUtil.Inits.MahkemeGoreviGetir_Enter;
                rLueMahkeme.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
                BelgeUtil.Inits.ParaBicimiAyarla(rudInkarTazminati.Properties);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTebligGideri.Properties);
                BelgeUtil.Inits.ParaBicimiAyarla(rudVekaletUcreti.Properties);
                BelgeUtil.Inits.ParaBicimiAyarla(rudYargilamaGideri.Properties);
                BelgeUtil.Inits.DovizTipGetir(rLueTebligDovizTip);
                BelgeUtil.Inits.DovizTipGetir(rLueVekaletDoviz);
                BelgeUtil.Inits.DovizTipGetir(rLueYargilamaDoviz);
                BelgeUtil.Inits.DovizTipGetir(rLueInkarDovizTip);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliyeBirimAdliyeID);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorevID);
                BelgeUtil.Inits.ParaBicimiAyarla(rTutar);
                lueAdliBirimNo.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            }
        }

        private void btnIlamBilgisiEkle_Click(object sender, EventArgs e)
        {
            Ekle();
            gwIlamBilgisi.DataSource = Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection;
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Name.Contains("Ilam") && e.IsTypedValue)
                {
                    try
                    {
                        TDI_KOD_ILAM_BELGE_TUR ozel = new TDI_KOD_ILAM_BELGE_TUR();
                        ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                        ozel.KONTROL_KIM = "AVUKATPRO";
                        ozel.STAMP = 1;
                        ozel.KONTROL_VERSIYON = 1;
                        ozel.BELGE_TUR = e.TypedValue;
                        ozel.UYAP_ACIKLAMA = "Diðer";
                        ozel.UYAP_KOD = "3";
                        DataRepository.TDI_KOD_ILAM_BELGE_TURProvider.Save(ozel);
                        ((TList<TDI_KOD_ILAM_BELGE_TUR>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        XtraMessageBox.Show("Ýlam Tipi Baþarýyla Eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
        }

        private void btnIlamBilgisiSil_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0) return;

            TList<AV001_TI_BIL_ILAM_MAHKEMESI> secilenler = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
            IlamBilgileri = Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection;
            for (int j = 0; j < IlamBilgileri.Count; j++)
            {
                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[j].IsSelected &&
                    !secilenler.Contains(Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[j]))

                    secilenler.Add(IlamBilgileri[j]);
            }
            DialogResult ds = XtraMessageBox.Show("Seçili kayýtlarý silmek istediðinizden emin misiniz ?",
                                                  "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                for (int i = 0; i < secilenler.Count; i++)
                {
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Remove(secilenler[i]);
                }
            }
            gwIlamBilgisi.DataSource = Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection;
        }
    }
}