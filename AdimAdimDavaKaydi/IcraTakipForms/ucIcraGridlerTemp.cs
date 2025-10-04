using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Muhasebe;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using System.Data;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class ucIcraGridlerTemp : AvpXUserControl
    {
        public AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.ucbelgetakip ucbelgetakip1;
        private AV001_TI_BIL_FOY _myFoy;
        private TList<AV001_TDI_BIL_SOZLESME> sozList;
        private AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel ucMuhasebeGenel3;

        public ucIcraGridlerTemp()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIcraGridler_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (ucGenelNotlar != null)
                    ucGenelNotlar.MyFoy = value;

                if (value != null)
                {
                    if (value.FORM_TIP_ID.Value == (int)(FormTipleri.Form151)
                        || value.FORM_TIP_ID.Value == (int)(FormTipleri.Form152))
                    {
                        tbHacizIslemleri.Text = "İpotek İşlemleri";
                    }
                    else if (value.FORM_TIP_ID.Value == (int)(FormTipleri.Form50)
                             || value.FORM_TIP_ID.Value == (int)(FormTipleri.Form201))
                    {
                        tbHacizIslemleri.Text = "Rehin İşlemleri";
                    }
                    else
                    {
                        tbHacizIslemleri.Text = "Haciz İşlemleri";
                    }

                    CreateMasrafAvansGrid();
                    CreateUcBorcluMalBilgileri1(this.resources);
                    CreateUcHasarBilgileri1(this.resources);
                    CreateUcbelgeTakip1(this.resources);
                    Create();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        public void BindData()
        {
            try
            {
                this.DataDegistir(MyFoy);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public void EnableParent(Control parent)
        {
            try
            {
                if (parent is ucIcraCore)
                    parent.Enabled = true;
                else if (parent.Parent != null)
                    EnableParent(parent.Parent);
            }
            catch
            {
            }
        }

        public void FormTipineGoreGridAyarla(FormTipleri tip, AvukatProLib.Extras.FormKonusu konu, AvukatProLib.Extras.AlacakNeden neden)
        {
            if (!this.IsLoaded)
                return;

            switch (tip)
            {
                case FormTipleri.Form49:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_49 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form51:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form50:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_50 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbHacizIslemleri.Text = "REHİN";
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tbHacizIslemleri.Text = "REHİN";
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form52:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbMehilBilgileri.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tabPolice.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                    }
                    else
                    {
                        tbMehilBilgileri.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tabPolice.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form53:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        switch (konu)
                        {
                            case FormKonusu.Form53_NAFAKA:
                            case FormKonusu.Form53_ISCI_ALACAGI:
                            case FormKonusu.Form53_ILAMLI_ALACAK:
                                tbGelismeler.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tpKiymetliEvrak.PageVisible = true;
                                break;

                            case FormKonusu.Form53_ISIN_YAPILMASI:
                            case FormKonusu.Form53_IRTIFAK_HAKKI:
                                tbGelismeler.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tpKiymetliEvrak.PageVisible = true;
                                tabPolice.PageVisible = false;
                                tabHasar.PageVisible = false;
                                tabHasarVePolice.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tabOdemeDagilimi.PageVisible = false;
                                tabKefalet.PageVisible = false;
                                break;
                        }
                    }
                    else
                    {
                        switch (konu)
                        {
                            case FormKonusu.Form53_NAFAKA:
                            case FormKonusu.Form53_ISCI_ALACAGI:
                            case FormKonusu.Form53_ILAMLI_ALACAK:
                                tbGelismeler.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tpKiymetliEvrak.PageVisible = false;
                                break;

                            case FormKonusu.Form53_ISIN_YAPILMASI:
                            case FormKonusu.Form53_IRTIFAK_HAKKI:
                                tbGelismeler.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tpKiymetliEvrak.PageVisible = false;
                                tabPolice.PageVisible = false;
                                tabHasar.PageVisible = false;
                                tabHasarVePolice.PageVisible = false;
                                tabPSozlesmeBilgileri.PageVisible = false;
                                tabOdemeDagilimi.PageVisible = false;
                                tabKefalet.PageVisible = false;
                                break;
                        }
                    }
                    break;

                case FormTipleri.Form55:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbGelismeler.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tabPolice.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabOdemeDagilimi.PageVisible = false;
                        tabKefalet.PageVisible = false;
                    }
                    else
                    {
                        tbGelismeler.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tabPolice.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabOdemeDagilimi.PageVisible = false;
                        tabKefalet.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form54:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tabKefalet.PageVisible = false;
                        tabOdemeDagilimi.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tabKefalet.PageVisible = false;
                        tabOdemeDagilimi.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form56:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form151:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_151 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbHacizIslemleri.Text = "İPOTEK";
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tbHacizIslemleri.Text = "İPOTEK";
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form152:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_152 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbHacizIslemleri.Text = "İPOTEK";
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                    }
                    else
                    {
                        tbHacizIslemleri.Text = "İPOTEK";
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form153:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_153 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tpKiymetliEvrak.PageVisible = true;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                    }
                    else
                    {
                        tpKiymetliEvrak.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form163:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.Senet || neden == AlacakNeden.Senet_2 ||
                        neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 || neden == AlacakNeden.Police ||
                        neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tpKiymetliEvrak.PageVisible = true;
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tabPolice.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    else
                    {
                        tpKiymetliEvrak.PageVisible = false;
                        tabMahsup.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tabPolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabHasar.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tbGelismeler.PageVisible = false;
                    }
                    break;

                case FormTipleri.Form201:
                    if (neden == AlacakNeden.Cek || neden == AlacakNeden.Cek_33 || neden == AlacakNeden.Cek_34 ||
                        neden == AlacakNeden.Cek_35 || neden == AlacakNeden.CekYapragi_201 || neden == AlacakNeden.Senet ||
                        neden == AlacakNeden.Senet_2 || neden == AlacakNeden.Senet_36 || neden == AlacakNeden.Senet_38 ||
                        neden == AlacakNeden.Police || neden == AlacakNeden.Police_39 || neden == AlacakNeden.Police_40 ||
                        neden == AlacakNeden.Police_41)
                    {
                        tbHacizIslemleri.Text = "REHİN";
                        tabOdemeDagilimi.PageVisible = false;
                        tabFeragat.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tabMahsup.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = true;
                        tabPolice.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabHasar.PageVisible = false;
                    }
                    else
                    {
                        tbHacizIslemleri.Text = "REHİN";
                        tabOdemeDagilimi.PageVisible = false;
                        tabFeragat.PageVisible = false;
                        tbMehilBilgileri.PageVisible = false;
                        tabMahsup.PageVisible = false;
                        tpKiymetliEvrak.PageVisible = false;
                        tabPolice.PageVisible = false;
                        tabHasarVePolice.PageVisible = false;
                        tabPSozlesmeBilgileri.PageVisible = false;
                        tabHasar.PageVisible = false;
                    }
                    break;
            }
        }

        public void HacizMasterDefaultColumns()
        {
            for (int i = 0; i < tabHacizGridler1.gwHaciz.Columns.Count; i++)
            {
                if (!tabHacizGridler1.gwHaciz.Columns[i].Visible)
                    tabHacizGridler1.gwHaciz.Columns[i].Visible = true;
            }
        }

        public void HacizMasterDuzenle()
        {
            for (int i = 0; i < tabHacizGridler1.gwHaciz.Columns.Count; i++)
            {
                if (tabHacizGridler1.gwHaciz.Columns[i].Visible)
                    tabHacizGridler1.gwHaciz.Columns[i].Visible = false;
            }

            tabHacizGridler1.gwHaciz.Columns["HACIZ_TARIHI"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TARIHI"].Caption = "Rehin T.";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TARIHI"].VisibleIndex = 0;

            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTENEN_CARI_ID"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTENEN_CARI_ID"].Caption = "Rehin Veren";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTENEN_CARI_ID"].VisibleIndex = 1;

            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTEYEN_CARI_ID"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTEYEN_CARI_ID"].Caption = "Rehin Alan";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ISTEYEN_CARI_ID"].VisibleIndex = 2;

            tabHacizGridler1.gwHaciz.Columns["HACIZ_ACIKLAMA"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ACIKLAMA"].Caption = "Rehin Açıklama";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_ACIKLAMA"].VisibleIndex = 3;

            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI"].Caption = "Rehin Toplam Değeri";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI"].VisibleIndex = 4;

            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI_DOVIZ_ID"].Visible = true;
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI_DOVIZ_ID"].Caption = "Brm";
            tabHacizGridler1.gwHaciz.Columns["HACIZ_TOPLAM_DEGERI_DOVIZ_ID"].VisibleIndex = 5;
        }

        public void NedeneBagliEvrakGetir()
        {
            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
            {
                AV001_TI_BIL_ALACAK_NEDEN focusNeden;
                if (ucAlacaklar1.gwAlacak.GetFocusedRow() != null)
                    focusNeden = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID((ucAlacaklar1.gwAlacak.GetFocusedRow() as AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN).ID);
                else
                    focusNeden = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[0];

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(focusNeden, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(
                                                                              TList
                                                                              <AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>
                                                                              ),
                                                                          typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                if (
                    focusNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.
                        Count > 0)
                {
                    if (ucKiymetliEvrakGrid1 != null)
                    {
                        ucKiymetliEvrakGrid1.Foy = this.MyFoy;
                        ucKiymetliEvrakGrid1.MyDataSource =
                            focusNeden.
                                AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;

                        int ID =
                            focusNeden.
                                AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK[0].
                                ID;
                        if (ucKiymetliEvrakTaraf1 != null)
                        {
                            TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> trfList =
                                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.GetByKIYMETLI_EVRAK_ID(ID);
                            ucKiymetliEvrakTaraf1.MyDataSource = trfList;
                        }
                    }
                }
            }
        }

        public void NedeneBagliSozlesmeGetir(FormTipleri tip)
        {
            switch (tip)
            {
                case FormTipleri.Form151:
                case FormTipleri.Form152:
                case FormTipleri.Form54:
                case FormTipleri.Form201:
                case FormTipleri.Form50:
                case FormTipleri.Form56:
                case FormTipleri.Form51:

                    if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN focusNeden;

                        if (ucAlacaklar1.gwAlacak.GetFocusedRow() != null)
                            focusNeden = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID((ucAlacaklar1.gwAlacak.GetFocusedRow() as AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN).ID);
                        else
                            focusNeden = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[0];

                        ucAlacakNedenSozlesme.Foy = this.MyFoy;

                        if (focusNeden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.Count <= 0)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW>), typeof(TList<AV001_TDI_BIL_SOZLESME>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));

                        sozList =
                            focusNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                        if (sozList.Count > 0)
                        {
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozList, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>), typeof(TList<TDI_BIL_BORCLU_MAL>), typeof(TList<NN_SOZLESME_GAYRIMENKUL>), typeof(TList<NN_SOZLESME_KIYMETLI_EVRAK>), typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));

                            ucAlacakNedenSozlesme.MyDataSource = sozList;
                            ucAlacakNedenSozlesme.FocusRecord += ucAlacakNedenSozlesme_FocusRecord;
                            SozlesmeAyarla(sozList);
                        }
                    }
                    break;
                default:
                    tpSozlesme.PageVisible = false;
                    break;
            }
        }

        private void checkButton1_CheckedeklenenChanged(object sender, EventArgs e)
        {
            if ((sender as CheckButton).Checked)
                tabGridler.HeaderOrientation = TabOrientation.Horizontal;
            else
                tabGridler.HeaderOrientation = TabOrientation.Vertical;
        }

        private void Create()
        {
            CreateGcBorcluOdeme(this.resources);
            CreateUcItiraz(this.resources);
            CreateGcGorusme(this.resources);
            CreateGcIhtiyatiHaciz(this.resources);
            CreateGcDusmeYenileme(this.resources);
            CreateGcTaahhut(this.resources);
            CreateTabHacizGridler1(this.resources);
            CreateUcSatisMaster1(this.resources);
            CreateGcGelisme(this.resources);
            CreateGcTakipAsama(this.resources);
            CreateUcIliskiDetay(this.resources);
            CreateUcGorevler1(this.resources);
            CreateUcMehilBilgileri1(this.resources);
            CreateUcPoliceBilgileri1(this.resources);

            //CreateUcTebligat1(this.resources);
            CreateucTebligatMuhatapForGiris1(this.resources);
            CreateUcMuvekkilTalimatlari1(this.resources);
            CreateUcSozlesmeGrid1(this.resources);
            CreateUcTakipHikayesi(this.resources);
            CreateUcIcraTalimatlari(this.resources);
            CreateUcIcraTeminatMektup1(this.resources);
        }

        private void DataDegistir(AV001_TI_BIL_FOY foy)
        {
            #region Okan ARDIÇ- Performans çalışması

            if (MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form151)
                || MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form152)
                || MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form50)
                || MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form201))
            {
                tbHacizIslemleri.Text = "Rehin İşlemleri";
            }
            else
            {
                tbHacizIslemleri.Text = "Haciz İşlemleri";
            }

            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0
                && foy.FORM_TIP_ID.HasValue
                && foy.TAKIP_TALEP_ID.HasValue
                && foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].ALACAK_NEDEN_KOD_ID.HasValue)
            {
                FormTipineGoreGridAyarla((FormTipleri)foy.FORM_TIP_ID, (FormKonusu)foy.TAKIP_TALEP_ID,
                                         (AlacakNeden)foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].ALACAK_NEDEN_KOD_ID);
            }

            #endregion Okan ARDIÇ- Performans çalışması
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                NedeneBagliEvrakGetir();
                AV001_TDI_BIL_SOZLESME var =
                    ucAlacakNedenSozlesme.gridView1.GetRow(e.FocusedRowHandle) as AV001_TDI_BIL_SOZLESME;

                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(var, true, DeepLoadType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>),
                                                                       typeof(TList<AV001_TI_BIL_GAYRIMENKUL>),
                                                                       typeof(TList<TDI_BIL_BORCLU_MAL>),
                                                                       typeof(TList<NN_SOZLESME_GAYRIMENKUL>),
                                                                       typeof(TList<NN_SOZLESME_KIYMETLI_EVRAK>),
                                                                       typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));

                if (var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.Count > 0)
                {
                    if (ucUcakGemiArac1 != null) ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(var.ID);
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                }
                if (var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count > 0)
                {
                    TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList =
                        var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    if (ucGayriMenkul1 != null) ucGayriMenkul1.MyDataSource = gayrimenkulList;
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
                }
                else if (var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.Count > 0 &&
                         var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count > 0)
                {
                    TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList =
                        var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    if (ucGayriMenkul1 != null) ucGayriMenkul1.MyDataSource = gayrimenkulList;
                    if (ucUcakGemiArac1 != null) ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(var.ID);
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                }
                else if (var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.Count == 0 &&
                         var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count == 0)
                {
                    tabpGayrimenkulArac.PageVisible = true;
                    if (ucGayriMenkul1 != null)
                        ucGayriMenkul1.MyDataSource =
                            var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    if (ucUcakGemiArac1 != null)
                        ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(var.ID);
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                }
            }
        }

        private void SozlesmeAyarla(TList<AV001_TDI_BIL_SOZLESME> sozList)
        {
            foreach (AV001_TDI_BIL_SOZLESME var in sozList)
            {
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(var, false, DeepLoadType.IncludeChildren,
                                                                       typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>),
                                                                       typeof(TList<TDI_BIL_BORCLU_MAL>),
                                                                       typeof(TList<NN_SOZLESME_GAYRIMENKUL>));
                if (var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.Count > 0)
                {
                    tabpGayrimenkulArac.PageVisible = true;
                    tabPageMenkulMal.PageVisible = false;
                    if (ucUcakGemiArac1 != null) ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(var.ID);
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                }
                if (var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count > 0)
                {
                    tabpGayrimenkulArac.PageVisible = true;
                    tabPageMenkulMal.PageVisible = false;
                    TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList =
                        var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    if (ucGayriMenkul1 != null) ucGayriMenkul1.MyDataSource = gayrimenkulList;
                    if (ucGayriMenkulTaraf1 != null)
                    {
                        DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayrimenkulList[0], false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                        ucGayriMenkulTaraf1.MyDataSource = gayrimenkulList[0].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                    }
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
                }
                else if (var.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.Count > 0 &&
                         var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count > 0)
                {
                    tabpGayrimenkulArac.PageVisible = true;
                    tabPageMenkulMal.PageVisible = false;
                    TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList =
                        var.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    if (ucGayriMenkul1 != null) ucGayriMenkul1.MyDataSource = gayrimenkulList;
                    if (ucGayriMenkulTaraf1 != null)
                    {
                        DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(gayrimenkulList[0], false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TI_BIL_GAYRIMENKUL_TARAF
                                                                                     >));
                        ucGayriMenkulTaraf1.MyDataSource =
                            gayrimenkulList[0].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                    }
                    if (ucUcakGemiArac1 != null) ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId(var.ID);
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                }
                else if (var.TDI_BIL_BORCLU_MALCollection.Count > 0)
                {
                    tabpGayrimenkulArac.PageVisible = false;
                    tabPageMenkulMal.PageVisible = true;
                    if (sozlesmeMenkul != null)
                    {
                        sozlesmeMenkul.OutSource = true;
                        sozlesmeMenkul.MyFoy = MyFoy;
                        sozlesmeMenkul.MyDataSource = var.TDI_BIL_BORCLU_MALCollection;
                    }
                }
            }
        }

        private void tabGridler_Selected(object sender, TabPageEventArgs e)
        {
            if (e.Page.Tag != null)
                if (e.Page.Tag.ToString() == "1")
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));
                }
                else if (e.Page.Tag.ToString() == "2")
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                    foreach (var item in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                    {
                        DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(item, false,
                                                                                  DeepLoadType.IncludeChildren,
                                                                                  typeof(
                                                                                      TList<AV001_TI_BIL_ODEME_DAGILIM>));
                    }
                    gcBorcluOdeme.MyDataSource = MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection;
                    if (gcOdemeDagilim == null)
                    {
                        CreateGcOdemeDagilim(this.resources);
                    }
                    gcOdemeDagilim.MyFoy = MyFoy;
                }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void ucAlacakNedenSozlesme_FocusRecord(object sender, EventArgs e)
        {
            if (ucAlacakNedenSozlesme.gridView1 != null)
                ucAlacakNedenSozlesme.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void ucGorevler1_Saved(IList Records, IEntity Record)
        {
            YapilacakIsYukle();
        }

        private void ucIcraGridler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                (this.ParentForm as _frmIcraTakip).ValidateRowEvents(tabHacizGridler1);

                //var pages = tabGridler.TabPages.OrderBy(vi => vi.Text).ToList();
                //tabGridler.TabPages.Clear();
                //for (int i = 0; i < pages.Count(); i++)
                //{
                //    tabGridler.TabPages.Add(pages[i]);
                //}

                if (ucGenelNotlar == null)
                {
                    CreateUcGenelNotlar(this.resources);
                    ucGenelNotlar.MyFoy = MyFoy;
                }

                tabGridler.SelectedPageChanging += tabGridler_SelectedPageChanging;
                xtraTabControl3.SelectedPageChanging += xtraTabControl3_SelectedPageChanging;
                xtraTabControl1.SelectedPageChanging += xtraTabControl1_SelectedPageChanging;
                xtraTabControl8.SelectedPageChanging += xtraTabControl8_SelectedPageChanging;
                xtraTabControl12.SelectedPageChanging += xtraTabControl12_SelectedPageChanging;
                xtraTabControl5.SelectedPageChanging += xtraTabControl5_SelectedPageChanging;
                xtraTabControl7.SelectedPageChanging += xtraTabControl7_SelectedPageChanging;
                xtraTabControl11.SelectedPageChanging += xtraTabControl11_SelectedPageChanging;
                xtraTabControl13.SelectedPageChanging += xtraTabControl13_SelectedPageChanging;
                xtraTabControl9.SelectedPageChanging += xtraTabControl9_SelectedPageChanging;
                xtraTabControl4.SelectedPageChanging += xtraTabControl4_SelectedPageChanging;
                xtraTabControl10.SelectedPageChanging += xtraTabControl10_SelectedPageChanging;
                xtraTabControl14.SelectedPageChanging += xtraTabControl14_SelectedPageChanging;
                xtraTabControl2.SelectedPageChanging += xtraTabControl2_SelectedPageChanging;
                xTabControlMuvekkilMuhasebe.SelectedPageChanging += xTabControlMuvekkilMuhasebe_SelectedPageChanging;
                IsLoaded = true;
                if (tbBos.PageVisible) tabGridler.SelectedTabPage = tbBos;
                else tabGridler.SelectedTabPage = tbGelismeler;

                tabDokumanlar.Text = "Dokümanlar";
            }
            if (MyFoy != null)
            {
                BindData();
            }
        }

        private void vgGayrimenkul_FocusedRecordChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex != null)
                ucGayriMenkulTaraf1.MyDataSource =
                    DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.GetByGAYRI_MENKUL_ID(e.NewIndex);
        }

        private void YapilacakIsYukle()
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS>));

            ucGorevler1.MyDataSource = MyFoy.AV001_TDI_BIL_ISCollection_From_NN_IS_ICRA_FOY;
            ucGorevler1.SelectedRecord = MyFoy;
            ucGorevler1.SelectedRecordId = MyFoy.ID;
        }

        #region Tab Page Geçişleri

        public void TabGridUyapAlacak()
        {
            tabGridler.SelectedTabPage = this.tbAlacaklar;
        }

        private void AlacaklariAyarla()
        {
            if (ucAlacaklar1 == null)
            {
                CreateUcAlacaklar1(this.resources);
            }

            #region Alacaklar

            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren
                                                                 , typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            try
            {
                for (int i = 0; i < MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
                {
                    for (int j = 0;
                         j <
                         MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.
                             Count;
                         j++)
                    {
                        if (
                            HesapAraclari.Icra.GetTarafSifatTakipEdenMi(
                                MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                    AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[j].TARAF_SIFAT_ID))
                        {
                            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.
                                Remove(
                                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[j]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            finally
            {
                ucAlacaklar1.MyFoy = MyFoy;
            }

            #region Alacak Nedenine Göre Gelen Kıymetli Evraklar

            //ucAlacaklar1.Load += new EventHandler(delegate
            //{
            //NedeneBagliEvrakGetir();

            #region Alacak Nedenine Göre Gelen Sözleşme Bilgileri

            FormTipleri tip = (FormTipleri)MyFoy.FORM_TIP_ID;

            switch (tip)
            {
                case FormTipleri.Form151:
                case FormTipleri.Form152:
                case FormTipleri.Form54:
                case FormTipleri.Form201:
                case FormTipleri.Form50:
                case FormTipleri.Form56:
                case FormTipleri.Form51:
                    tpSozlesme.PageVisible = true;
                    break;
                default:
                    tpSozlesme.PageVisible = false;
                    break;
            }

            //  NedeneBagliSozlesmeGetir(tip);

            #endregion Alacak Nedenine Göre Gelen Sözleşme Bilgileri

            //  });
            //ucAlacaklar1.gwAlacak.FocusedRowChanged += new FocusedRowChangedEventHandler(gwAlacak_FocusedRowChanged);

            #endregion Alacak Nedenine Göre Gelen Kıymetli Evraklar

            #endregion Alacaklar
        }

        private void CreateMasrafAvansGrid()
        {
            this.tabMasraflar.Controls.Clear();

            ucMuhasebeGenel3 = new AdimAdimDavaKaydi.UserControls.ucMuhasebeGenel("İcra", "Masraf", MyFoy);
            ucMuhasebeGenel3.Dock = System.Windows.Forms.DockStyle.Fill;
            ucMuhasebeGenel3.Location = new System.Drawing.Point(0, 0);
            ucMuhasebeGenel3.Name = "ucMuhasebeGenel3";
            ucMuhasebeGenel3.SaveStatus = false;
            ucMuhasebeGenel3.Size = new System.Drawing.Size(918, 276);
            ucMuhasebeGenel3.TabIndex = 9;
            this.tabMasraflar.Controls.Add(ucMuhasebeGenel3);
        }

        private void frmMuhasebe_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraFoyId(MyFoy.ID);
        }

        private void tabGridler_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tbOdeme.Name)
            {
                if (gcBorcluOdeme == null)
                    CreateGcBorcluOdeme(this.resources);
                (this.ParentForm as _frmIcraTakip).ValidateRowEvents(gcBorcluOdeme);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(this.MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>), typeof(TList<AV001_TI_BIL_BORCLU_ODEME_DETAY>));
                gcBorcluOdeme.MyFoy = this.MyFoy;
                gcBorcluOdeme.MyGelisme = this.MyGelisme;
            }
            else if (e.Page.Name == this.tbMalBeyani.Name)
            {
                if (ucBorcluMalBilgileri1 == null)
                    CreateUcBorcluMalBilgileri1(this.resources);
                ucBorcluMalBilgileri1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbItiraz.Name)
            {
                if (ucItiraz == null)
                    CreateUcItiraz(this.resources);
                ucItiraz.Foy = MyFoy;
                (this.ParentForm as _frmIcraTakip).ValidateRowEvents(ucItiraz);
            }
            else if (e.Page.Name == this.tbGorusmeVeIletisim.Name)
            {
                if (gcGorusme == null)
                    CreateGcGorusme(this.resources);
                gcGorusme.MyIcraFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbDegisikIsler.Name)
            {
                if (gcIhtiyatiHaciz == null)
                    CreateGcIhtiyatiHaciz(this.resources);
                gcIhtiyatiHaciz.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbDusmeYenileme.Name)
            {
                if (gcDusmeYenileme == null)
                    CreateGcDusmeYenileme(this.resources);
                gcDusmeYenileme.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbTaahhutler.Name)
            {
                if (gcTaahhut == null)
                    CreateGcTaahhut(this.resources);
                gcTaahhut.MyFoy = this.MyFoy;
            }
            else if (e.Page.Name == this.tbHacizIslemleri.Name)
            {
                if (tabHacizGridler1 == null)
                    CreateTabHacizGridler1(this.resources);

                tabHacizGridler1.MyFoy = MyFoy;

                if (MyFoy != null)
                {
                    if (MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form151)
                        || MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form152))
                    {
                        ((XtraTabControl)tabHacizGridler1.Controls[0]).TabPages[0].Text = "İpotek";
                        tabHacizGridler1.xtraTabControl1.TabPages[0].Text = "İpotek Bilgileri";

                        #region HacizMaster Üzerindeki Column Degisiklikleri

                        HacizMasterDuzenle();

                        #endregion HacizMaster Üzerindeki Column Degisiklikleri
                    }
                    else if (MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form50)
                             || MyFoy.FORM_TIP_ID.Value == (int)(FormTipleri.Form201))
                    {
                        ((XtraTabControl)tabHacizGridler1.Controls[0]).TabPages[0].Text = "Rehin";
                        tabHacizGridler1.xtraTabControl1.TabPages[0].Text = "Rehin Bilgileri";

                        #region HacizMaster Üzerindeki Column Degisiklikleri

                        HacizMasterDuzenle();

                        #endregion HacizMaster Üzerindeki Column Degisiklikleri
                    }
                    else
                    {
                        ((XtraTabControl)tabHacizGridler1.Controls[0]).TabPages[0].Text = "Haciz";
                        tabHacizGridler1.xtraTabControl1.TabPages[0].Text = "Haciz Bilgileri";

                        #region HacizMasterdaki Default Columnlar

                        HacizMasterDefaultColumns();

                        #endregion HacizMasterdaki Default Columnlar
                    }
                }
            }
            else if (e.Page.Name == this.tbSatis.Name)
            {
                if (ucSatisMaster1 == null)
                    CreateUcSatisMaster1(this.resources);
                (this.ParentForm as _frmIcraTakip).ValidateRowEvents(ucSatisMaster1);
                ucSatisMaster1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbBos.Name)
            {
                if (ucGenelNotlar == null)
                    CreateUcGenelNotlar(this.resources);
                ucGenelNotlar.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbAlacaklar.Name)
            {
                AlacaklariAyarla();
            }
            else if (e.Page.Name == this.tbGelismeler.Name)
            {
                if (gcGelisme == null)
                    CreateGcGelisme(this.resources);
                if (MyFoy.AV001_TI_BIL_FOY_GELISMECollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_GELISME>));
                gcGelisme.FoyID = MyFoy.ID;
                gcGelisme.MyDataSource = MyFoy.AV001_TI_BIL_FOY_GELISMECollection;
            }
            else if (e.Page.Name == this.tbTakipAsama.Name)
            {
                if (gcTakipAsama == null)
                    CreateGcTakipAsama(this.resources);

                //(this.ParentForm as _frmIcraTakip).TakipAsamasiDoldur(this.MyFoy);
                gcTakipAsama.MyFoy = this.MyFoy;
            }
            else if (e.Page.Name == this.tbDosyaBaglantilari.Name)
            {
                if (ucIliskiDetay1 == null)
                    CreateUcIliskiDetay(this.resources);
                ucIliskiDetay1.FoyId = MyFoy.ID;
                ucIliskiDetay1.GetList(MyFoy.ID, ucIliskiDetay.IliskiTur.İCRA_DOSYASI);
            }
            else if (e.Page.Name == this.c_tpGorevler.Name)
            {
                if (ucGorevler1 == null)
                    CreateUcGorevler1(this.resources);
                this.ucGorevler1.Saved += ucGorevler1_Saved;
                YapilacakIsYukle();
            }
            else if (e.Page.Name == this.tbMehilBilgileri.Name)
            {
                if (ucMehilBilgileri1 == null)
                    CreateUcMehilBilgileri1(this.resources);
                ucMehilBilgileri1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabHasarVePolice.Name)
            {
                if (tabHasar.PageVisible)
                {
                    if (ucHasarBilgileri1 == null)
                        CreateUcHasarBilgileri1(this.resources);
                }
                else
                {
                    if (ucPoliceBilgileri1 == null)
                        CreateUcPoliceBilgileri1(this.resources);
                }
            }
            else if (e.Page.Name == this.tabDokumanlar.Name)
            {
                if (ucbelgetakip1 == null)
                    CreateUcbelgeTakip1(this.resources);

                ucbelgetakip1.IdValue = MyFoy.ID;
                ucbelgetakip1.CurrentRecord = MyFoy;
                ucbelgetakip1.MyDataSource = BelgeUtil.Inits.BelgeGetirByIcraFoyId(MyFoy.ID);
            }
            else if (e.Page.Name == this.tabDosyaMuhasebesi.Name)
            {
                if (ucMuhasebeGenel3 == null)
                    CreateMasrafAvansGrid();
                //aykut hızlandırma 25.01.2013
                //List<RMasrafAvansDetayli2Entity> gelen = null;
                //if (MyFoy != null)
                //    gelen = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByIcraFoyId(MyFoy.ID);
                //ucMuhasebeGenel3.MyMasrafAvansDetayli = gelen;

                ucMuhasebeGenel3.MyMasrafAvansDetayli = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByIcraFoyId(MyFoy.ID);
            }

            else if (e.Page.Name == this.tabTebligatGelenGidenEvrak.Name)
            {
                if (ucTebligatMuhatapForGiris1 == null)
                    CreateucTebligatMuhatapForGiris1(this.resources);
                ucTebligatMuhatapForGiris1.MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetEvrakByIcraFoyID(MyFoy.ID);

                //    CreateUcTebligat1(this.resources);
                //ucTebligat1.MyIcraFoy = MyFoy;
            }

            else if (e.Page.Name == this.tabPMuvekkilTalimat.Name)
            {
                if (ucMuvekkilTalimatlari1 == null)
                    CreateUcMuvekkilTalimatlari1(this.resources);
                ucMuvekkilTalimatlari1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabpSozlesme.Name)
            {
                if (ucSozlesmeGrid1 == null)
                    CreateUcSozlesmeGrid1(this.resources);
                ucSozlesmeGrid1.Foy = MyFoy;
            }
            else if (e.Page.Name == this.tabpTakipHikayesi.Name)
            {
                if (ucTakipHikayesi1 == null)
                    CreateUcTakipHikayesi(this.resources);
                ucTakipHikayesi1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabpIcraTalimatlari.Name)
            {
                if (ucIcraTalimatlari1 == null)
                    CreateUcIcraTalimatlari(this.resources);
                ucIcraTalimatlari1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbIadeAlinmamisTeminatlar.Name)
            {
                if (ucIcraTeminatMektup1 == null)
                    CreateUcIcraTeminatMektup1(this.resources);

                ucIcraTeminatMektup1.MyIcraFoy = MyFoy;
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xTabControlMuvekkilMuhasebe_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.xTabPageMuvDosyaHesabi.Name)
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;

                if (ucMuhasebeGenel1 == null)
                {
                    CreateUcMuvekkilDosyaHesabi(this.resources);
                }

                //aykut hızlandırma 25.01.2013
                //List<RCariHesapDetayliEntity> hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraFoyId(MyFoy.ID);
                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraFoyId(MyFoy.ID);

                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar;
                if (ucMuhasebeGenel2.ucPivotChart1 != null)
                    ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;

                //bool muvekkil =
                //    AvukatProLib.Arama.R_CARI_HESAP_MUVEKKIL.KullaniciMuvekkilMi(
                //        AvukatProLib.Kimlik.SirketBilgisi.ConStr, AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                ////muvekkil
                //if (!true) return;

                //if (MyFoy.AV001_TDI_BIL_CARI_HESAP_DETAYCollection.Count == 0)
                //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                //                                                     typeof(TList<AV001_TDI_BIL_CARI_HESAP_DETAY>));

                //TList<AV001_TDI_BIL_CARI_HESAP_DETAY> cariHesapDetaylari =
                //    MyFoy.AV001_TDI_BIL_CARI_HESAP_DETAYCollection;
                //List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY> kullaniciHesaplar =
                //    context.AV001_TDI_BIL_CARI_HESAP_DETAYs.Where(
                //        vi => vi.KONTROL_KIM_ID == AvukatProLib.Kimlik.Bilgi.ID && vi.ICRA_FOY_ID == MyFoy.ID).
                //        ToList();

                //List<Av001TdiBilCariHesapDetayEntity> hesaplar =
                //    new List<Av001TdiBilCariHesapDetayEntity>();

                //foreach (var item in cariHesapDetaylari)
                //{
                //    Av001TdiBilCariHesapDetayEntity tmp = AvukatPro.Services.Implementations.CariService.GetCariHesapDetayById(item.ID);

                //    if (tmp != null)
                //        hesaplar.Add(tmp);
                //}

                //if (hesaplar.Count > 0)
                //{
                //    ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = hesaplar;
                //    if (ucMuhasebeGenel2.ucPivotChart1 != null)
                //        ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;
                //}
            }
            else if (e.Page.Name == this.xTabPageMuvTumHesap.Name)
            {
                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue) return;

                if (ucMuhasebeGenel2 == null)
                {
                    CreateUcMuvekkilTumHesabi(this.resources);
                }

                DataTable hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraTaraf(MyFoy.ID);
                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = hesaplar;

                if (ucMuhasebeGenel2.ucPivotChart1 != null)
                    ucMuhasebeGenel2.ucPivotChart1.MyCarHesapDetayliArama = hesaplar;

                //    bool muvekkil =
                //        AvukatProLib.Arama.R_CARI_HESAP_MUVEKKIL.KullaniciMuvekkilMi(
                //            AvukatProLib.Kimlik.SirketBilgisi.ConStr, AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
                //    if (!true) return;

                //    List<Av001TdiBilCariHesapDetayEntity> hesaplar1 =
                //new List<Av001TdiBilCariHesapDetayEntity>();

                //    List<Av001TdiBilCariHesapDetayEntity> hesaplar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetay().Where(h => h.KontrolKimId == AvukatProLib.Kimlik.Bilgi.ID).ToList();

                //var hazirlikfoy = MyFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(vi => vi.TARAF_KODU == 1);

                //if (hazirlikfoy.Count == 0)
                //    hesaplar1 = hesaplar;
                //if (hazirlikfoy.Count == 1)
                //    hesaplar1 = hesaplar.FindAll(vi => vi.CariHesapId == hazirlikfoy[0].CARI_IDSource.ToString());

                //if (hazirlikfoy.Count == 2)
                //    hesaplar1 = hesaplar.FindAll(vi => vi.CARI_AD == hazirlikfoy[0].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[1].CARI_IDSource.ToString());
                //if (hazirlikfoy.Count == 3)
                //    hesaplar1 = hesaplar.FindAll(vi => vi.CARI_AD == hazirlikfoy[0].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[1].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[2].CARI_IDSource.ToString());
                //if (hazirlikfoy.Count == 4)
                //    hesaplar1 = hesaplar.FindAll(vi => vi.CARI_AD == hazirlikfoy[0].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[1].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[2].CARI_IDSource.ToString() || vi.CARI_AD == hazirlikfoy[3].CARI_IDSource.ToString());
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabMalBeyan.Name)
            {
                if (gcMalBeyani == null)
                {
                    CreateGcMalBeyani(this.resources);
                }
                gcMalBeyani.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabBorclununMallari.Name)
            {
                if (ucBorcluMalBilgileri1 == null)
                {
                    CreateUcBorcluMalBilgileri1(this.resources);
                }
                ucBorcluMalBilgileri1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabArastırmaIleTespit.Name)
            {
                if (ucBorcluMalBilgileri2 == null)
                {
                    CreateUcBorcluMalBilgileri2(this.resources);
                }
                ucBorcluMalBilgileri2.Taraf = true;
                ucBorcluMalBilgileri2.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl10_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.c_tpBelge.Name)
            {
                if (ucbelgetakip1 == null)
                {
                    CreateUcbelgeTakip1(this.resources);
                }
                ucbelgetakip1.IdValue = MyFoy.ID;
                ucbelgetakip1.CurrentRecord = MyFoy;
                ucbelgetakip1.MyDataSource = BelgeUtil.Inits.BelgeGetirByIcraFoyId(MyFoy.ID);
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl11_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabAlacaklar.Name)
            {
                AlacaklariAyarla();
            }
            else if (e.Page.Name == this.tabKefalet.Name)
            {
                if (gcKefalet == null)
                {
                    CreateGcKefalet(this.resources);
                }
                gcKefalet.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl12_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabGorusmeler.Name)
            {
                if (gcGorusme == null)
                {
                    CreateGcGorusme(this.resources);
                }
                gcGorusme.MyIcraFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabSMS.Name)
            {
                if (ucDavaSMS1 == null) CreateUcDavaSMS1(this.resources);
            }
            else if (e.Page.Name == this.tabEmail.Name)
            {
                if (ucEPosta1 == null) CreateUcEPosta1(this.resources);
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl13_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabPSozlesmeBilgileri.Name)
            {
                if (ucAlacakNedenSozlesme == null)
                {
                    CreateUcAlacakNedenSozlesme(this.resources);
                    NedeneBagliSozlesmeGetir((FormTipleri)MyFoy.FORM_TIP_ID);
                }
            }
            else if (e.Page.Name == this.tabpGayrimenkulArac.Name)
            {
                if (ucGayriMenkulTaraf1 == null)
                    CreateUcGayriMenkulTaraf1(this.resources);
                if (ucUcakGemiArac1 == null)
                {
                    CreateUcUcakGemiArac1(this.resources);
                    if (ucAlacakNedenSozlesme.MyDataSource != null && ucAlacakNedenSozlesme.MyDataSource.Count > 0)
                    {
                        ucUcakGemiArac1.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirBySozlesmeFoyId((ucAlacakNedenSozlesme.MyDataSource)[ucAlacakNedenSozlesme.gridView1.FocusedRowHandle].ID);
                    }
                    SozlesmeAyarla(sozList);
                }
            }
            else if (e.Page.Name == this.tabPageMenkulMal.Name)
            {
                if (sozlesmeMenkul == null)
                {
                    CreateSozlesmeMenkul(this.resources);
                    SozlesmeAyarla(sozList);
                }
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl14_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabMuvekkilHesabı.Name)
            {
                if (this.xTabMeslekMakbuzu.Visible)//ts
                {
                    if (ucMeslekMakbuzu1 == null)
                    {
                        CreateUcMeslekMakbuzu1(this.resources);
                    }
                    ucMeslekMakbuzu1.MyIcraFoy = MyFoy;
                }
                else
                    if (this.xTabMuvekkilOdeme.Visible)
                    {
                        if (gcMuvekkilOdemeleri == null)
                        {
                            CreateGcMuvekkilOdemeleri(this.resources);
                        }
                        gcMuvekkilOdemeleri.MyIcraFoy = MyFoy;
                    }
                    else if (this.xTabVekaletSozlesme.Visible)
                    {
                        if (ucIcraVekaletSozlesmesi1 == null)
                        {
                            CreateucIcraVekaletSozlesmesi1(this.resources);
                        }
                        ucIcraVekaletSozlesmesi1.MyIcraFoy = MyFoy;
                    }
                    else if (this.xTabVekaletIsSozlesme.Visible)
                    {
                        if (ucYapilcakIsSozlesme1 == null)
                            CreateUcYapilcakIsSozlesme1(this.resources);
                    }
                    else
                    {
                        if (this.ucIcraTakipMuvekkilHesabi1 == null)//ts
                        {
                            CreateUcIcraTakipMuvekkilHesabi(this.resources);
                        }
                        ucIcraTakipMuvekkilHesabi1.MyFoy = MyFoy;
                    }
            }
            else if (e.Page.Name == this.tabMasraflar.Name)
            {
                if (gcMasraflar == null)
                {
                    CreateGcMasraflar(this.resources);
                }
                gcMasraflar.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabIcraDosyasiMuhasebesi.Name)
            {
                #region Masraf Avansdan Dosya Muhasebe ve detay oluştur

                bool olustur = false;
                if (MyFoy != null)
                {
                    int foyID = MyFoy.ID;
                    TList<AV001_TDI_BIL_MASRAF_AVANS> gelenMasrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(foyID);

                    try
                    {
                        foreach (var masrafAvans in gelenMasrafAvans)
                        {
                            AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (gelenMuhasebe == null)
                            {
                                olustur = true;
                            }

                            if (gelenMuhasebe != null)
                            {
                                TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                {
                                    olustur = true;
                                }
                            }
                        }

                        if (olustur)
                        {
                            if (XtraMessageBox.Show("Bu dosyada dosya muhasebesine aktarılmamış masraf ve / veya avans kayıtları var.\nMüvekkil muhasebesine aktarılabilmesi için öncelikle bu kayıtların oluşturulması gerekiyor.\nŞimdi oluşturulmasını ister misiniz?",
                           "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                foreach (var masrafAvans in gelenMasrafAvans)
                                {
                                    AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    if (gelenMuhasebe == null)
                                    {
                                        CreateFoyMuhasebeByMasrafAvansRequest request = new CreateFoyMuhasebeByMasrafAvansRequest();
                                        request.MasrafAvansId = masrafAvans.ID;
                                        request.ModulId = masrafAvans.CARI_HESAP_HEDEF_TIP;
                                        AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeByMasrafAvans(request);

                                        gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    }

                                    if (gelenMuhasebe != null)
                                    {
                                        TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                        TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                        if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                        {
                                            foreach (var item in mevcutMasrafDetay)
                                            {
                                                //kontrol versiyon alanında masraf avans detay id tutulmaktadır
                                                if (!gelenMuhasebeDetay.Any(m => m.KONTROL_VERSIYON == item.ID))
                                                {
                                                    CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request = new CreateFoyMuhasebeDetayByMasrafAvansDetayRequest();
                                                    request.MasrafAvansDetayId = item.ID;
                                                    request.MuhasebeId = gelenMuhasebe.ID;
                                                    request.YenidenHesaplanabilir = !item.MA_MANUAL_KAYIT_MI;
                                                    AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeDetayByMasrafAvansDetay(request);

                                                    // son parametre yeniden hesaplanabilir olması için verildi
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            XtraMessageBox.Show("Masraf avans kayıtlarının dosya muhasebesine aktarılması tamamlandı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    catch (Exception)
                    {
                        XtraMessageBox.Show("Aktarım tamamlanamadı!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion Masraf Avansdan Dosya Muhasebe ve detay oluştur

                this.tabIcraDosyasiMuhasebesi.Controls.Clear();

                UserControls.ucMuhasebeGenel ucMuhasebeIcra = new UserControls.ucMuhasebeGenel("İcra", "Dosya", null);
                ucMuhasebeIcra.Dock = System.Windows.Forms.DockStyle.Fill;
                ucMuhasebeIcra.Location = new System.Drawing.Point(0, 0);
                ucMuhasebeIcra.Name = "ucMuhasebeIcra";
                ucMuhasebeIcra.SaveStatus = false;
                ucMuhasebeIcra.Size = new System.Drawing.Size(918, 276);
                ucMuhasebeIcra.TabIndex = 9;

                //int[] idler = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByICRA_FOY_ID(MyFoy.ID).Select(i => i.ID).Distinct().ToArray();

                //foreach (var id in idler)
                //{
                //    icraMuhasebe.AddRange((VList<R_FOY_MUHASEBESI_ICRA>)DataRepository.R_FOY_MUHASEBESI_ICRAProvider.Get("ID = " + id, "TARIH"));
                //}

                ucMuhasebeIcra.MyIcraFoyMuhasebeDetay = AvukatPro.Services.Implementations.MuhasebeService.GetAllMuhasebeFromIcraFoy(MyFoy.ID);
                ucMuhasebeIcra.mainView.FocusedRowChanged += ucMuhasebeIcra.gridView2_FocusedRowChanged;
                this.tabIcraDosyasiMuhasebesi.Controls.Add(ucMuhasebeIcra);
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl2_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.xTabDosyaOzeti.Name)
            {
                if (this.ucIcraTakipMuvekkilHesabi1 == null)
                    CreateUcIcraTakipMuvekkilHesabi(this.resources);

                ucIcraTakipMuvekkilHesabi1.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.xTabMuvekkilOdeme.Name)
            {
                if (gcMuvekkilOdemeleri == null)
                    CreateGcMuvekkilOdemeleri(this.resources);

                gcMuvekkilOdemeleri.MyIcraFoy = MyFoy;
            }
            else if (e.Page.Name == this.xTabVekaletSozlesme.Name)
            {
                if (ucIcraVekaletSozlesmesi1 == null)
                    CreateucIcraVekaletSozlesmesi1(this.resources);

                ucIcraVekaletSozlesmesi1.MyIcraFoy = MyFoy;
            }
            else if (e.Page.Name == this.xTabVekaletIsSozlesme.Name)
            {
                if (ucYapilcakIsSozlesme1 == null)
                    CreateUcYapilcakIsSozlesme1(this.resources);
            }
            else if (e.Page.Name == this.xTabMeslekMakbuzu.Name)
            {
                if (ucMeslekMakbuzu1 == null)
                    CreateUcMeslekMakbuzu1(this.resources);

                ucMeslekMakbuzu1.MyIcraFoy = MyFoy;
            }
            else if (e.Page.Name == this.xTabMuvekkMuh.Name)
            {
                #region DosyaMuhasebesi kontrol ve muyasebeleştirme ekranına gönderme

                decimal? carilestirilebilirToplam = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(MyFoy.ID, 1).Select(m => m.MuhasebelestirilmemisMiktar).Sum();

                if (carilestirilebilirToplam > 0)
                {
                    if (XtraMessageBox.Show("Bu dosyada dosya muhasebesine aktarılmış ancak müvekkiller adına muhasebeleştirilmemiş kayıtlar bulunmaktadır.\nŞimdi muhasebeleştirmek istiyormusunuz?",
                   "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme(1, MyFoy.ID);
                        frm.MdiParent = AnaForm.mdiAvukatPro.MainForm;
                        frm.FormClosed += new FormClosedEventHandler(frmMuhasebe_FormClosed);
                        frm.Show();
                    }
                }

                #endregion DosyaMuhasebesi kontrol ve muyasebeleştirme ekranına gönderme

                if (!AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                    return;

                if (ucMuhasebeGenel1 == null)
                    CreateUcMuvekkilDosyaHesabi(this.resources);

                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraFoyId(MyFoy.ID);
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl3_SelectedPageChanging(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page.Name == this.tabBorcluOdemeler.Name)
            {
                if (gcBorcluOdeme == null)
                {
                    CreateGcBorcluOdeme(this.resources);
                    (this.ParentForm as _frmIcraTakip).ValidateRowEvents(gcBorcluOdeme);
                }
                gcBorcluOdeme.MyFoy = this.MyFoy;
                gcBorcluOdeme.MyGelisme = this.MyGelisme;
            }
            else if (e.Page.Name == this.tabFeragat.Name)
            {
                if (gcFeragat == null)
                {
                    CreateGcFeragat(this.resources);
                    (this.ParentForm as _frmIcraTakip).ValidateRowEvents(gcFeragat);
                }
                gcFeragat.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabMahsup.Name)
            {
                if (gcMahsup == null)
                {
                    CreateGcMahsup(this.resources);
                }
                gcMahsup.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tabOdemeDagilimi.Name)
            {
                if (gcOdemeDagilim == null)
                {
                    CreateGcOdemeDagilim(this.resources);
                }
                gcOdemeDagilim.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl4_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabHasar.Name)
            {
                if (ucHasarBilgileri1 == null)
                {
                    CreateUcHasarBilgileri1(this.resources);
                    if (MyFoy.AV001_TDI_BIL_POLICE_HASARCollection_From_NN_HASAR_ICRA_FOY.Count == 0)
                    {
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren
                                                                         , typeof(TList<NN_HASAR_ICRA_FOY>)
                                                                         , typeof(TList<AV001_TDI_BIL_POLICE_HASAR>));
                    }
                }
                ucHasarBilgileri1.MyDataSource = MyFoy.AV001_TDI_BIL_POLICE_HASARCollection_From_NN_HASAR_ICRA_FOY;
            }
            else if (e.Page.Name == this.tabPolice.Name)
            {
                if (ucPoliceBilgileri1 == null)
                {
                    CreateUcPoliceBilgileri1(this.resources);
                    if (MyFoy.AV001_TDI_BIL_POLICECollection_From_NN_ICRA_POLICE.Count == 0)
                    {
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren
                                                                         , typeof(TList<NN_ICRA_POLICE>)
                                                                         , typeof(TList<AV001_TDI_BIL_POLICE>));
                    }
                }
                ucPoliceBilgileri1.MyDataSource = MyFoy.AV001_TDI_BIL_POLICECollection_From_NN_ICRA_POLICE;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl5_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tbIhtHaciz.Name)
            {
                if (gcIhtiyatiHaciz == null)
                {
                    CreateGcIhtiyatiHaciz(this.resources);
                }
                gcIhtiyatiHaciz.MyFoy = MyFoy;
            }
            else if (e.Page.Name == this.tbIhtTedbir.Name)
            {
                if (gcIhtiyatiTedbir == null)
                {
                    CreateGcIhtiyatiTedbir(this.resources);
                }
                gcIhtiyatiTedbir.MyFoy = MyFoy;
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl7_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tpAlacaklar.Name)
            {
                AlacaklariAyarla();
            }
            else if (e.Page.Name == this.tpKiymetliEvrak.Name)
            {
                if (ucKiymetliEvrakTaraf1 == null)
                {
                    CreateUcKiymetliEvrakTaraf1(this.resources);
                }
                if (ucKiymetliEvrakGrid1 == null)
                {
                    CreateUcKiymetliEvrakGrid1(this.resources);
                    if (ucAlacaklar1.gwAlacak.FocusedRowHandle >= 0)
                    {
                        AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN aNeden = (AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN)ucAlacaklar1.gwAlacak.GetFocusedRow();
                        ucKiymetliEvrakGrid1.MyDataSource = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByALACAK_NEDEN_IDFromAV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK(aNeden.ID);
                        ucKiymetliEvrakGrid1.Foy = this.MyFoy;
                    }
                }
                if (ucKiymetliEvrakTaraf1.IsLoaded)
                    if (ucKiymetliEvrakTaraf1.MyDataSource != null && ucKiymetliEvrakTaraf1.MyDataSource.Count > 0 &&
                        ucKiymetliEvrakGrid1.MyDataSource != null && ucKiymetliEvrakGrid1.MyDataSource.Count > 0)
                        ucKiymetliEvrakTaraf1.MyDataSource =
                            ucKiymetliEvrakGrid1.MyDataSource[0].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
                NedeneBagliEvrakGetir();
            }
            else if (e.Page.Name == this.tpSozlesme.Name)
            {
                if (ucAlacakNedenSozlesme == null)
                {
                    CreateUcAlacakNedenSozlesme(this.resources);
                }
                NedeneBagliSozlesmeGetir((FormTipleri)MyFoy.FORM_TIP_ID);
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl8_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.tabItirazlar.Name)
            {
                if (ucItiraz == null)
                {
                    CreateUcItiraz(this.resources);
                }
                ucItiraz.Foy = MyFoy;
            }
            else if (e.Page.Name == this.tabSikayetler.Name)
            {
                if (ucSikayetBilgileri1 == null)
                {
                    CreateUcSikayetBilgileri1(this.resources);
                }
                ucSikayetBilgileri1.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl9_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.xtraTabPage2.Name)
            {
                if (ucGayriMenkul1 == null)
                {
                    CreateUcGayriMenkul1(this.resources);
                    if (ucAlacakNedenSozlesme.MyDataSource != null && ucAlacakNedenSozlesme.MyDataSource.Count > 0)
                    {
                        if ((ucAlacakNedenSozlesme.MyDataSource)[ucAlacakNedenSozlesme.gridView1.FocusedRowHandle].
                                AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count == 0)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad((ucAlacakNedenSozlesme.MyDataSource)[ucAlacakNedenSozlesme.gridView1.FocusedRowHandle], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
                        ucGayriMenkul1.MyDataSource =
                            (ucAlacakNedenSozlesme.MyDataSource)[ucAlacakNedenSozlesme.gridView1.FocusedRowHandle].
                                AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;
                    }
                    SozlesmeAyarla(sozList);
                    ucGayriMenkul1.Load += delegate
                    {
                        if (ucGayriMenkul1.MyDataSource != null &&
                            ucGayriMenkul1.MyDataSource.Count > 0)
                        {
                            DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(
                                ucGayriMenkul1.MyDataSource[0], false,
                                DeepLoadType.IncludeChildren,
                                typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                            ucGayriMenkulTaraf1.MyDataSource =
                                ucGayriMenkul1.MyDataSource[0].
                                    AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                        }
                        ucGayriMenkul1.vgGayrimenkul.FocusedRecordChanged +=
                            vgGayrimenkul_FocusedRecordChanged;
                    };
                }
            }
            else if (e.Page.Name == this.xtraTabPage3.Name)
            {
                if (ucGayriMenkulTaraf1 == null)
                    CreateUcGayriMenkulTaraf1(this.resources);
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        #endregion Tab Page Geçişleri
    }
}