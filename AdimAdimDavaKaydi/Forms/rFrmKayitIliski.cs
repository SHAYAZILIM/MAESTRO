using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public class IlskiliDosyaKaydedildiEventArgs : EventArgs
    {
        public IlskiliDosyaKaydedildiEventArgs(AV001_TDI_BIL_KAYIT_ILISKI_DETAY mFoy)
        {
            KayitIliskiFoy = mFoy;
        }

        public AV001_TDI_BIL_KAYIT_ILISKI_DETAY KayitIliskiFoy { get; set; }
    }

    public partial class rFrmKayitIliski : Util.BaseClasses.AvpXtraForm
    {
        public rFrmKayitIliski()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private AV001_TDI_BIL_KAYIT_ILISKI iliskim = new AV001_TDI_BIL_KAYIT_ILISKI();

        private TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> KayitIliskiSource =
            new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();

        public event EventHandler<IlskiliDosyaKaydedildiEventArgs> KayitliDosyaKaydedildi;

        public AvukatProLib.Extras.Modul Mod { get; set; }

      

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem26_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET BUTONU

            if (KayitIliskiSource.Count > 1)
            {
                for (int i = 0; i < KayitIliskiSource.Count; i++)
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(iliskim);

                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.DeepSave(
                        KayitIliskiSource[i]);

                    iliskim.AKTIF_MI = true;
                }
            }
            else
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(iliskim);

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.DeepSave(KayitIliskiSource);
                if (KayitliDosyaKaydedildi != null)
                {
                    KayitIliskiSource.Sort("KAYIT_TARIHI DESC");
                    KayitliDosyaKaydedildi(this, new IlskiliDosyaKaydedildiEventArgs(KayitIliskiSource[0]));
                }
                iliskim.AKTIF_MI = true;
            }

            //AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find("ID='"+iliskim.ID+"'");
        }

        private void gLueDava_EditValueChanged(object sender, EventArgs e)
        {
            grpControl2.Visible = true;
            grdIliskiDetay.Visible = true;
        }

        private void gLueDava_EditValueChanged_1(object sender, EventArgs e)
        {
            iliskim.KAYNAK_DAVA_FOY_ID = (int)gLueDava.EditValue;
            iliskim.KAYNAK_KAYIT_ID = (int)gLueDava.EditValue;
            iliskim.KAYNAK_TIP = Convert.ToByte(lueKaynakModul.EditValue);
            iliskim.ILISKI_TUR_ID = Convert.ToInt32(lueUstIliskiTur.EditValue);

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Save(iliskim);
        }

        private void gLueDavaAlt_EditValueChanged(object sender, EventArgs e)
        {
            //BURDA SEÇÝLENLERÝ KAYIT ÝLÞKÝ DETAY GRÝDÝNE EKLEYECEÐÝZ ..
            //Dava Dosyasý
            //TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> listem = grdIliskiDetay.DataSource as TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yeni = new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();
            yeni.HEDEF_DAVA_FOY_ID = (int?)gLueDavaAlt.EditValue;
            yeni.HEDEF_FOY_NO = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).FOY_NO;
            yeni.HEDEF_ADLI_BIRIM_ADLIYE_ID = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).ADLIYE_ID;
            yeni.HEDEF_ADLI_BIRIM_GOREV_ID = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).GOREV_ID;
            yeni.HEDEF_ADLI_BIRIM_NO_ID = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).BIRIM_ID;
            yeni.HEDEF_ESAS_NO = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).ESAS_NO;
            yeni.ILISKI_NEDEN_ID = Convert.ToInt32(lueKayitIliskiNeden.EditValue);
            yeni.KAYIT_ILISKI_ID = iliskim.ID;
            yeni.ILISKI_TUR_ID = Convert.ToInt32(lueIliskiTur.EditValue);
            yeni.HEDEF_KAYIT_ID = ((AvukatProLib.Arama.VTD_DAVA_DOSYALAR)gLueDavaAlt.Properties.View.GetFocusedRow()).ID;
            yeni.HEDEF_TIP = 2;
            KayitIliskiSource.Add(yeni);
            grdIliskiDetay.RefreshDataSource();
        }

        private void gLueIcra_EditValueChanged(object sender, EventArgs e)
        {
            iliskim.KAYNAK_ICRA_FOY_ID = (int)gLueIcra.EditValue;
            iliskim.KAYNAK_KAYIT_ID = (int)gLueIcra.EditValue;
            iliskim.KAYNAK_TIP = Convert.ToByte(lueKaynakModul.EditValue);
            iliskim.ILISKI_TUR_ID = Convert.ToInt32(lueUstIliskiTur.EditValue);
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Save(iliskim);
        }

        private void gLueIcraAlt_EditValueChanged(object sender, EventArgs e)
        {
            //BURDA SEÇÝLENLERÝ KAYIT ÝLÞKÝ DETAY GRÝDÝNE EKLEYECEÐÝZ ..
            //ICRA Dosyasý
            //TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> listem = grdIliskiDetay.DataSource as TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yeni = new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();
            yeni.HEDEF_ICRA_FOY_ID = (int?)gLueIcraAlt.EditValue;
            yeni.HEDEF_FOY_NO =
                ((AvukatProLib.Arama.VTI_ICRA_DOSYALAR)gLueIcraAlt.Properties.View.GetFocusedRow()).FOY_NO;
            yeni.HEDEF_ADLI_BIRIM_ADLIYE_ID =
                ((AvukatProLib.Arama.VTI_ICRA_DOSYALAR)gLueIcraAlt.Properties.View.GetFocusedRow()).ADLIYE_ID;
            yeni.HEDEF_ADLI_BIRIM_GOREV_ID =
                ((AvukatProLib.Arama.VTI_ICRA_DOSYALAR)gLueIcraAlt.Properties.View.GetFocusedRow()).GOREV_ID;
            yeni.HEDEF_ADLI_BIRIM_NO_ID =
                ((AvukatProLib.Arama.VTI_ICRA_DOSYALAR)gLueIcraAlt.Properties.View.GetFocusedRow()).BIRIM_ID;
            yeni.HEDEF_ESAS_NO =
                ((AvukatProLib.Arama.VTI_ICRA_DOSYALAR)gLueIcraAlt.Properties.View.GetFocusedRow()).ESAS_NO;

            //yeni.KAYIT_ILISKI_ID
            yeni.HEDEF_TIP = Convert.ToByte(lueModulAlt.EditValue);
            yeni.ILISKI_NEDEN_ID = Convert.ToInt32(lueKayitIliskiNeden.EditValue);
            yeni.ILISKI_TUR_ID = Convert.ToInt32(lueIliskiTur.EditValue);
            yeni.HEDEF_KAYIT_ID =
                ((AvukatProLib.Arama.per_AV001_TI_BIL_FOY)gLueIcraAlt.Properties.View.GetFocusedRow()).ID;
            yeni.HEDEF_TIP = 1; // Convert.ToByte(lueModulAlt.EditValue);
            yeni.KAYIT_ILISKI_ID = iliskim.ID;
            KayitIliskiSource.Add(yeni);
            grdIliskiDetay.RefreshDataSource();
        }

        private void gLueRucu_EditValueChanged(object sender, EventArgs e)
        {
            iliskim.KAYNAK_RUCU_ID = (int)gLueRucu.EditValue;
            iliskim.KAYNAK_KAYIT_ID = (int)gLueRucu.EditValue;
            iliskim.KAYNAK_TIP = Convert.ToByte(lueKaynakModul.EditValue);
            iliskim.ILISKI_TUR_ID = Convert.ToInt32(lueUstIliskiTur.EditValue);
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Save(iliskim);
        }

        private void gLueRucuAlt_EditValueChanged(object sender, EventArgs e)
        {
            //BURDA SEÇÝLENLERÝ KAYIT ÝLÞKÝ DETAY GRÝDÝNE EKLEYECEÐÝZ ..
            //Rücu Dosyasý

            //TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> listem = grdIliskiDetay.DataSource as TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yeni = new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();
            yeni.HEDEF_RUCU_ID = (int?)gLueRucuAlt.EditValue;
            yeni.HEDEF_FOY_NO = ((AV001_TDI_BIL_RUCU)gLueRucuAlt.Properties.View.GetFocusedRow()).DOSYA_NO;
            yeni.HEDEF_TIP = Convert.ToByte(lueModulAlt.EditValue);
            yeni.ILISKI_NEDEN_ID = Convert.ToInt32(lueKayitIliskiNeden.EditValue);
            yeni.ILISKI_TUR_ID = Convert.ToInt32(lueIliskiTur.EditValue);
            yeni.KAYIT_ILISKI_ID = iliskim.ID;
            yeni.ILISKI_NEDEN_ID = Convert.ToInt32(lueKayitIliskiNeden.EditValue);
            yeni.HEDEF_TIP = 4; //Convert.ToByte(lueModulAlt.EditValue);
            yeni.HEDEF_KAYIT_ID = ((AV001_TDI_BIL_RUCU)gLueRucuAlt.Properties.View.GetFocusedRow()).ID;
            KayitIliskiSource.Add(yeni);
            grdIliskiDetay.RefreshDataSource();
        }

        private void gLueSorusturma_EditValueChanged(object sender, EventArgs e)
        {
            iliskim.KAYNAK_HAZIRLIK_ID = (int)gLueSorusturmaAlt.EditValue;
            iliskim.KAYNAK_KAYIT_ID = (int)gLueSorusturmaAlt.EditValue;
            iliskim.KAYNAK_TIP = Convert.ToByte(lueKaynakModul.EditValue);
            iliskim.ILISKI_TUR_ID = Convert.ToInt32(lueUstIliskiTur.EditValue);
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Save(iliskim);

            //KAYIT ID AL
        }

        private void gLueSorusturmaAlt_EditValueChanged(object sender, EventArgs e)
        {
            //BURDA SEÇÝLENLERÝ KAYIT ÝLÞKÝ DETAY GRÝDÝNE EKLEYECEÐÝZ ..
            //SORUSTURMA HAzirlik Dosyasý
            //TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> listem = grdIliskiDetay.DataSource as TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yeni = new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();
            yeni.HEDEF_HAZIRLIK_ID = (int?)gLueSorusturmaAlt.EditValue;
            yeni.HEDEF_FOY_NO =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    HAZIRLIK_NO;
            yeni.HEDEF_ADLI_BIRIM_ADLIYE_ID =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    ADLI_BIRIM_ADLIYE_ID;
            yeni.HEDEF_ADLI_BIRIM_GOREV_ID =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    ADLI_BIRIM_GOREV_ID;
            yeni.HEDEF_ADLI_BIRIM_NO_ID =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    ADLI_BIRIM_NO_ID;
            yeni.HEDEF_ESAS_NO =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    HAZIRLIK_ESAS_NO;

            //yeni.KAYIT_ILISKI_ID
            yeni.HEDEF_TIP = Convert.ToByte(lueModulAlt.EditValue);
            yeni.ILISKI_NEDEN_ID = Convert.ToInt32(lueKayitIliskiNeden.EditValue);
            yeni.ILISKI_TUR_ID = Convert.ToInt32(lueIliskiTur.EditValue);
            yeni.HEDEF_KAYIT_ID =
                ((AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW)gLueSorusturmaAlt.Properties.View.GetFocusedRow()).
                    ID;

            yeni.HEDEF_TIP = 3; // Convert.ToByte(lueModulAlt.EditValue);
            yeni.KAYIT_ILISKI_ID = iliskim.ID;
            KayitIliskiSource.Add(yeni);
            grdIliskiDetay.RefreshDataSource();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Outlook_Click += barButtonItem24_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_PDF_Click += barButtonItem26_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        private void lueKayitIliskiNeden_EditValueChanged(object sender, EventArgs e)
        {
            object EditValueIliskiNeden = lueKayitIliskiNeden.EditValue;
            if (EditValueIliskiNeden != null)
            {
                gLueDavaAlt.Enabled = true;
                gLueIcraAlt.Enabled = true;
                gLueRucuAlt.Enabled = true;
                gLueSorusturmaAlt.Enabled = true;
            }
            else
            {
                gLueDavaAlt.Enabled = false;
                gLueIcraAlt.Enabled = false;
                gLueRucuAlt.Enabled = false;
                gLueSorusturmaAlt.Enabled = false;
            }
        }

        private void lueKaynakModul_EditValueChanged(object sender, EventArgs e)
        {
            object EditValueKaynakModul = lueKaynakModul.EditValue;
            if (EditValueKaynakModul != null)
            {
                //Seçilen Module göre icra-dava vb bilgilerinden Foy Noyu göster..
                switch ((AvukatProLib.Extras.Modul)(int)(EditValueKaynakModul))
                {
                    case AvukatProLib.Extras.Modul.Icra:
                        break;

                    case AvukatProLib.Extras.Modul.Dava:

                        #region SUBEKONTROLLU VERI CEKME

                        if (AvukatProLib.Kimlik.Bilgi != null &&
                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                                gLueDava.Properties.DataSource = BelgeUtil.Inits.DavaDosyalariGetir();
                            else
                                gLueDava.Properties.DataSource =
                                    BelgeUtil.Inits.DavaDosyalariGetir().FindAll(
                                        vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                        #endregion SUBEKONTROLLU VERI CEKME

                        gLueDava.Properties.ValueMember = "ID";
                        gLueDava.Properties.DisplayMember = "FOY_NO";
                        gLueDava.Visible = true;
                        gLueIcra.Visible = false;
                        gLueRucu.Visible = false;
                        gLueSorusturma.Visible = false;
                        lblDosyaSecUst.Visible = true;

                        break;

                    //case AvukatProLib.Extras.Modul.Rucu:

                    //    #region SUBEKONTROLLU VERI CEKME

                    //    if (AvukatProLib.Kimlik.Bilgi != null &&
                    //        AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    //        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    //            gLueRucu.Properties.DataSource = BelgeUtil.Inits.RucuGetir();
                    //        else
                    //            gLueRucu.Properties.DataSource = BelgeUtil.Inits.context.per_AV001_TDI_BIL_RUCUs.Where(item => item.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();

                    //    #endregion

                    //    gLueRucu.Properties.DisplayMember = "DOSYA_NO";
                    //    gLueRucu.Properties.ValueMember = "ID";

                    //    gLueRucu.Visible = true;
                    //    gLueDava.Visible = false;
                    //    gLueIcra.Visible = false;
                    //    gLueSorusturma.Visible = false;
                    //    lblDosyaSecUst.Visible = true;
                    //    break;

                    case AvukatProLib.Extras.Modul.Sorusturma:

                        #region SUBEKONTROLLU VERI CEKME

                        if (AvukatProLib.Kimlik.Bilgi != null &&
                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                                gLueSorusturma.Properties.DataSource = BelgeUtil.Inits.HazirlikDosyalariGetir();
                            else
                                gLueSorusturma.Properties.DataSource =
                                    BelgeUtil.Inits.HazirlikDosyalariGetir().FindAll(
                                        vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                        #endregion SUBEKONTROLLU VERI CEKME

                        gLueSorusturma.Properties.DisplayMember = "HAZIRLIK_NO";
                        gLueSorusturma.Properties.ValueMember = "ID";

                        gLueSorusturma.Visible = true;
                        gLueRucu.Visible = false;
                        gLueIcra.Visible = false;
                        gLueDava.Visible = false;
                        lblDosyaSecUst.Visible = true;
                        break;
                }
            }
        }

        private void lueModulAlt_EditValueChanged(object sender, EventArgs e)
        {
            object EditValueAltKaynak = lueModulAlt.EditValue;
            if (EditValueAltKaynak != null)
            {
                switch ((AvukatProLib.Extras.Modul)(int)(EditValueAltKaynak))
                {
                    case AvukatProLib.Extras.Modul.Icra:

                        #region SUBEKONTROLLU VERI CEKME

                        if (AvukatProLib.Kimlik.Bilgi != null &&
                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                                gLueIcraAlt.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
                            else
                                gLueIcraAlt.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetirBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                        #endregion SUBEKONTROLLU VERI CEKME

                        gLueIcraAlt.Properties.ValueMember = "ID";
                        gLueIcraAlt.Properties.DisplayMember = "FOY_NO";
                        gLueRucuAlt.Visible = false;
                        gLueSorusturmaAlt.Visible = false;
                        gLueDavaAlt.Visible = false;
                        gLueIcraAlt.Visible = true;

                        break;

                    case AvukatProLib.Extras.Modul.Dava:

                        #region SUBEKONTROLLU VERI CEKME

                        if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                                gLueDavaAlt.Properties.DataSource = BelgeUtil.Inits.DavaDosyalariGetir();
                            else
                                gLueDavaAlt.Properties.DataSource = BelgeUtil.Inits.DavaDosyalariGetirbySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                        #endregion SUBEKONTROLLU VERI CEKME

                        gLueDavaAlt.Properties.DisplayMember = "FOY_NO";
                        gLueDavaAlt.Properties.ValueMember = "ID";
                        gLueDavaAlt.Visible = true;
                        gLueIcraAlt.Visible = false;
                        gLueRucuAlt.Visible = false;
                        gLueSorusturmaAlt.Visible = false;
                        break;

                    case AvukatProLib.Extras.Modul.Sorusturma:

                        #region SUBEKONTROLLU VERI CEKME

                        if (AvukatProLib.Kimlik.Bilgi != null &&
                            AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                                gLueSorusturmaAlt.Properties.DataSource = BelgeUtil.Inits.HazirlikDosyalariGetir();
                            else
                                gLueSorusturmaAlt.Properties.DataSource = BelgeUtil.Inits.HazirlikDosyalariGetirBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

                        #endregion SUBEKONTROLLU VERI CEKME

                        gLueSorusturmaAlt.Properties.DisplayMember = "HAZIRLIK_NO";
                        gLueSorusturmaAlt.Properties.ValueMember = "ID";
                        gLueSorusturmaAlt.Visible = true;
                        gLueRucuAlt.Visible = false;
                        gLueIcraAlt.Visible = false;
                        gLueDavaAlt.Visible = false;

                        break;

                    //case AvukatProLib.Extras.Modul.Rucu:

                    //    #region SUBEKONTROLLU VERI CEKME

                    //    if (AvukatProLib.Kimlik.Bilgi != null &&
                    //        AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    //        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    //            gLueRucuAlt.Properties.DataSource = BelgeUtil.Inits.RucuGetir();
                    //        else
                    //            gLueRucuAlt.Properties.DataSource = BelgeUtil.Inits.context.per_AV001_TDI_BIL_RUCUs.Where(item => item.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();

                    //    #endregion

                    //    gLueRucuAlt.Properties.DisplayMember = "ID";
                    //    gLueRucuAlt.Properties.ValueMember = "DOSYA_NO";
                    //    gLueRucuAlt.Visible = true;
                    //    gLueSorusturmaAlt.Visible = false;
                    //    gLueIcraAlt.Visible = false;
                    //    gLueDavaAlt.Visible = false;

                    //    break;
                    default:
                        break;
                }
            }
        }

        private void rFrmKayitIliski_Load(object sender, EventArgs e)
        {
            grdIliskiDetay.DataSource = KayitIliskiSource;

            BelgeUtil.Inits.ModulKodGetirForKayitIliski(lueKaynakModul);
            BelgeUtil.Inits.KayitIliskiNedenGetir(lueKayitIliskiNeden);
            BelgeUtil.Inits.ModulKodGetirForKayitIliski(lueModulAlt);
            BelgeUtil.Inits.KayitIliskiTurGetir(lueIliskiTur);

            //
            BelgeUtil.Inits.KayitIliskiTurGetir(rLueIlýskiTur);
            BelgeUtil.Inits.KayitIliskiNedenGetir(rLueIliskiNeden);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimGorev);

            //

            BelgeUtil.Inits.KayitIliskiTurGetir(lueUstIliskiTur);

            //GridLookuplarýn RepositoryLokkuplarý
            repositoryLookUpDoldur();

            gLueDava.EditValueChanged += gLueDava_EditValueChanged;
            gLueIcra.EditValueChanged += gLueDava_EditValueChanged;
            gLueRucu.EditValueChanged += gLueDava_EditValueChanged;
            gLueSorusturma.EditValueChanged += gLueDava_EditValueChanged;
        }

        #region LookUplarý Doldurduk

        private void repositoryLookUpDoldur()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeIcra);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevIcra);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoIcra);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeDava);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimAdliGorevDava);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoDava);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeSorusturma);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevSorusturma);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoSorusturma);
            BelgeUtil.Inits.RucuKaynakKodGetir(rLueRucuKaynakRucu);
            BelgeUtil.Inits.RucuKaynakKodGetir(rLueRucuKaynakAlt);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeAlt);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevAlt);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdlibirimNoAlt);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeDavaAlt);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdlibirimGorevDavaAlt);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoDavaAlt);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeSorAlt);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevSorAlt);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoSorAlt);
        }

        #endregion LookUplarý Doldurduk
    }
}