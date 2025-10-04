using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi
{
    public partial class ucIlamMahkemesi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIlamMahkemesi()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_ILAM_MAHKEMESI> MyDataSource
        {
            get
            {
                if (vgIlamMahkemesi.DataSource is TList<AV001_TI_BIL_ILAM_MAHKEMESI>)
                    return (TList<AV001_TI_BIL_ILAM_MAHKEMESI>)vgIlamMahkemesi.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null)
                    vgIlamMahkemesi.DataSource = value;
            }
        }

        private void ucIlamMahkemesi_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //vgIlamMahkemesi.DataSource= initIlamMahkemesiGetir();
                BelgeUtil.Inits.DovizTipGetir(rlkDovizId);
                BelgeUtil.Inits.FaizTipiGetir(rlkFaizTip);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlkAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirim);
                BelgeUtil.Inits.MahkemeGoreviGetir(rlkAdliBirimGorev, true);
                BelgeUtil.Inits.IlamTipiGetir(rlkIlamTipi);
                BelgeUtil.Inits.ParaBicimiAyarla(rudPara);
                BelgeUtil.Inits.YuzdeBicimiAyarla(rudOran);
                BelgeUtil.Inits.CariFirmaGetir(rLueCari);
            }
        }

        private void rlkIlamTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if ((e.Button.Tag as string) == "Yeni")
            {
                TDI_KOD_ILAM_BELGE_TUR tur = new TDI_KOD_ILAM_BELGE_TUR();
                tur.BELGE_TUR = lue.Text;
                tur.UYAP_KOD = "3";
                tur.UYAP_ACIKLAMA = "Diğer";
                tur.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
                tur.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                tur.SUBE_KODU = AvukatProLib.Kimlik.DefaultStamp;
                tur.ADMIN_KAYIT_MI = true;
                tur.KONTROL_NE_ZAMAN = DateTime.Now;
                tur.KONTROL_KIM = "AVUKATPRO";
                tur.KONTROL_VERSIYON = 0;
                tur.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_ILAM_BELGE_TURProvider.DeepSave(tran, tur);
                    tran.Commit();
                    XtraMessageBox.Show(lue.Text + " Bu Türün Kaydetme İşlemi Başarıyla Gerçekleşmiştir.");
                    ((TList<TDI_KOD_ILAM_BELGE_TUR>)(lue.Properties.DataSource)).Add(tur);
                }
                catch
                {
                    XtraMessageBox.Show("Kayıt İşlemi Sırasında Bir Hata Oluşmuştur");
                }
            }
        }

        private void rlkIlamTipi_ProcessNewValue(object sender,
                                                 DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (!string.IsNullOrEmpty(lue.Text))
            {
                TDI_KOD_ILAM_BELGE_TUR tur = new TDI_KOD_ILAM_BELGE_TUR();
                tur.BELGE_TUR = lue.Text;
                tur.UYAP_KOD = "3";
                tur.UYAP_ACIKLAMA = "Diğer";
                tur.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
                tur.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                tur.SUBE_KODU = AvukatProLib.Kimlik.DefaultStamp;
                tur.ADMIN_KAYIT_MI = true;
                tur.KONTROL_NE_ZAMAN = DateTime.Now;
                tur.KONTROL_KIM = "AVUKATPRO";
                tur.KONTROL_VERSIYON = 0;
                tur.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.TDI_KOD_ILAM_BELGE_TURProvider.DeepSave(tran, tur);
                    tran.Commit();
                    XtraMessageBox.Show(lue.Text + " Bu Türün Kaydetme İşlemi Başarıyla Gerçekleşmiştir.");
                    ((TList<TDI_KOD_ILAM_BELGE_TUR>)(lue.Properties.DataSource)).Add(tur);
                }
                catch
                {
                    XtraMessageBox.Show("Kayıt İşlemi Sırasında Bir Hata Oluşmuştur");
                }
            }
        }

        private void rLueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "Yeni")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.Firma = true;
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              BelgeUtil.Inits.perCariGetir(rLueCari);
                                          }
                                      };
            }
        }

        private void rLueCari_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if (!string.IsNullOrEmpty(lue.Text))
            {
                frm.tmpCariAd = lue.Text;
                frm.Firma = true;
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              BelgeUtil.Inits.perCariGetir(rLueCari);
                                          }
                                      };
            }
        }

        #region Eski

        //private DataTable initIlamMahkemesiGetir()
        //{
        //    DataTable dt = new DataTable("IlamMahkemesi");
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("ICRA_FOY_ID");
        //    dt.Columns.Add("ADLI_BIRIM_ADLIYE_ID");
        //    dt.Columns.Add("ADLIYE");
        //    dt.Columns.Add("ADLI_BIRIM_GOREV_ID");
        //    dt.Columns.Add("GOREV");
        //    dt.Columns.Add("ADLI_BIRIM_NO_ID");
        //    dt.Columns.Add("BIRIM_NO");
        //    dt.Columns.Add("ESAS_NO");
        //    dt.Columns.Add("KARAR_NO");
        //    dt.Columns.Add("KARAR_TARIHI");
        //    dt.Columns.Add("KARAR_KESINLESME_TARIHI");
        //    dt.Columns.Add("KARAR_BOZULMA_TARIHI");
        //    dt.Columns.Add("DAVA_FOY_ID");
        //    dt.Columns.Add("DAVA_OZET_FOY_ID");
        //    dt.Columns.Add("ILAM_TIP_ID");
        //    dt.Columns.Add("ILAM_TIP");
        //    dt.Columns.Add("INKAR_TAZMINAT_FAIZ_ISLESIN_MI", typeof(bool));
        //    dt.Columns.Add("INKAR_TAZMINAT_FAIZ_ORANI");
        //    dt.Columns.Add("INKAR_TAZMINATI_DOVIZ_ID");
        //    dt.Columns.Add("INKAR_TAZMINATI_DOVIZ");
        //    dt.Columns.Add("INKAR_TAZMINATI_KUR");
        //    dt.Columns.Add("INKAR_TAZMINATI");
        //    dt.Columns.Add("KO_INKAR_TAZMINATI");
        //    dt.Columns.Add("YARGILAMA_GIDERI_FAIZ_ISLESIN_MI",typeof(bool));
        //    dt.Columns.Add("YARGILAMA_GIDERI_FAIZ_ORANI");
        //    dt.Columns.Add("YARGILAMA_GIDERI_DOVIZ_ID");
        //    dt.Columns.Add("YARGILAMA_GIDERI_DOVIZ");
        //    dt.Columns.Add("YARGILAMA_GIDERI_KUR");
        //    dt.Columns.Add("YARGILAMA_GIDERI");
        //    dt.Columns.Add("KO_YARGILAMA_GIDERI");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI",typeof(bool));
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_FAIZ_ORANI");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_DOVIZ_ID");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_DOVIZ");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_KUR");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI");
        //    dt.Columns.Add("KO_BAKIYE_KARAR_HARCI");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI", typeof(bool));
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_FAIZ_ORANI");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_DOVIZ_ID");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_DOVIZ");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_KUR");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI");
        //    dt.Columns.Add("KO_YARGITAY_ONAMA_HARCI");
        //    dt.Columns.Add("ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI", typeof(bool));
        //    dt.Columns.Add("ILAM_VEKALET_UCRET_FAIZ_ORANI");
        //    dt.Columns.Add("ILAM_VEKALET_UCRETI_DOVIZ_ID");
        //    dt.Columns.Add("ILAM_VEKALET_UCRETI_DOVIZ");
        //    dt.Columns.Add("ILAM_VEKALET_UCRETI_KUR");
        //    dt.Columns.Add("ILAM_VEKALET_UCRETI");
        //    dt.Columns.Add("KO_ILAM_VEKALET_UCRETI");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI", typeof(bool));
        //    dt.Columns.Add("ILAM_TEBLIG_GIDER_FAIZ_ORANI");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDERI_DOVIZ_ID");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDERI_DOVIZ");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDERI_KUR");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDERI");
        //    dt.Columns.Add("KO_ILAM_TEBLIG_GIDERI");
        //    dt.Columns.Add("TAHLIYE_ADRESI");
        //    dt.Columns.Add("ILAM_ACIKLAMASI");
        //    dt.Columns.Add("KAYIT_TARIHI");
        //    dt.Columns.Add("KLASOR_KODU");
        //    dt.Columns.Add("SUBE_KODU");
        //    dt.Columns.Add("KONTROL_NE_ZAMAN");
        //    dt.Columns.Add("KONTROL_KIM");
        //    dt.Columns.Add("KONTROL_VERSIYON");
        //    dt.Columns.Add("STAMP");
        //    dt.Columns.Add("INKAR_TAZMINAT_FAIZ_TIP_ID");
        //    dt.Columns.Add("YARGILAMA_GIDERI_FAIZ_TIP_ID");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_FAIZ_TIP_ID");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID");
        //    dt.Columns.Add("ILAM_VEKALET_UCRET_FAIZ_TIP_ID");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDER_FAIZ_TIP_ID");
        //    dt.Columns.Add("INKAR_TAZMINAT_FAIZ_TIP");
        //    dt.Columns.Add("YARGILAMA_GIDERI_FAIZ_TIP");
        //    dt.Columns.Add("BAKIYE_KARAR_HARCI_FAIZ_TIP");
        //    dt.Columns.Add("YARGITAY_ONAMA_HARCI_FAIZ_TIP");
        //    dt.Columns.Add("ILAM_VEKALET_UCRET_FAIZ_TIP");
        //    dt.Columns.Add("ILAM_TEBLIG_GIDER_FAIZ_TIP");

        //    DataRow dr = dt.NewRow();
        //    dr["INKAR_TAZMINAT_FAIZ_TIP_ID"] = 1;
        //    dr["YARGILAMA_GIDERI_FAIZ_TIP_ID"] = 1;
        //    dr["BAKIYE_KARAR_HARCI_FAIZ_TIP_ID"] = 1;
        //    dr["YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID"] = 1;
        //    dr["ILAM_VEKALET_UCRET_FAIZ_TIP_ID"] = 1;
        //    dr["ILAM_TEBLIG_GIDER_FAIZ_TIP_ID"] = 1;
        //    dr["INKAR_TAZMINAT_FAIZ_TIP"] = 1;
        //    dr["YARGILAMA_GIDERI_FAIZ_TIP"] = 1;
        //    dr["BAKIYE_KARAR_HARCI_FAIZ_TIP"] = 1;
        //    dr["YARGITAY_ONAMA_HARCI_FAIZ_TIP"] = 1;
        //    dr["ILAM_VEKALET_UCRET_FAIZ_TIP"] = 1;
        //    dr["ILAM_TEBLIG_GIDER_FAIZ_TIP"] = 1;
        //    dr["INKAR_TAZMINATI_DOVIZ_ID"] = 1;
        //    dr["YARGILAMA_GIDERI_DOVIZ_ID"] = 1;
        //    dr["BAKIYE_KARAR_HARCI_DOVIZ_ID"] = 1;
        //    dr["YARGITAY_ONAMA_HARCI_DOVIZ_ID"] = 1;
        //    dr["ILAM_VEKALET_UCRETI_DOVIZ_ID"] = 1;
        //    dr["ILAM_TEBLIG_GIDERI_DOVIZ_ID"] = 1;
        //    dr["INKAR_TAZMINAT_FAIZ_ISLESIN_MI"] = true;
        //    dr["YARGILAMA_GIDERI_FAIZ_ISLESIN_MI"] = true;
        //    dr["BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI"] = true;
        //    dr["YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI"] = true;
        //    dr["ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI"] = true;
        //    dr["ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI"] = true;

        //    dt.Rows.Add(dr);
        //    return dt;
        //}

        #endregion
    }
}